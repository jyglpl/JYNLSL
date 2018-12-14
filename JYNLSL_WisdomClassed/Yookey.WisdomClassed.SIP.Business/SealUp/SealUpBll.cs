using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.WorkFlow;
using Yookey.WisdomClassed.SIP.DataAccess.SealUp;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.SealUp;

namespace Yookey.WisdomClassed.SIP.Business.SealUp
{
    /// <summary>
    /// SealUp业务逻辑
    /// </summary>
    public class SealUpBll : BaseBll<SealUpEntity>
    {
        public SealUpBll()
        {
            BaseDal = new SealUpDal();
        }

        /// <summary>
        /// 更改案件的状态
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public bool UpdateCaseState(string id, int state)
        {
            try
            {
                return new SealUpDal().UpdateCaseState(id, state);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 删除查封数据
        /// </summary>
        /// <param name="id">查分ID</param>
        /// <returns></returns>
        public bool BatchDelete(string id)
        {
            return new SealUpDal().BatchDelete(id);
        }

        /// <summary>
        /// 数据查询
        /// 添加人：周 鹏
        /// 添加时间：2016-01-08
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns>Page&lt;SealUpEntity&gt;.</returns>
        public PageJqDatagrid<SealUpEntity> GetSearchResult(string keywords, int pageSize, int pageIndex)
        {
            int totalRecords;
            var data = new SealUpDal().GetSearchResult(keywords, pageSize, pageIndex, out totalRecords);
            var totalPage = (totalRecords + pageSize - 1) / pageSize;
            return new PageJqDatagrid<SealUpEntity>
            {
                page = pageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords
            };
        }

        /// <summary>
        /// 审批成功后,执行相应操作
        /// 添加人：周 鹏
        /// 添加时间：2015-04-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-04-28 增加审批类型
        /// </history>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="userId">当前登录用户编号</param>
        /// <param name="id">案件编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="islastFlow">是否为最后一步审批流程</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="approveDate">审批日期</param>
        /// <returns></returns>
        public bool SealUpApproveReturn(string eType, string userId, string id, string flowName, bool islastFlow, string worklistId, DateTime approveDate)
        {
            var isOk = false;
            try
            {
                if (!string.IsNullOrEmpty(worklistId))
                {
                    new CrmMessageWorkBll().UpdateWorkListState(worklistId, DateTime.Now);  //更改消息的状态为已处理
                }

                //验证当前流程环节为最后一步,需将案件状态更改为当前有流程最大值,如果不是最后一步流程,直接在原有状态的基本上面+1
                if (!string.IsNullOrEmpty(flowName) && !string.IsNullOrEmpty(id))
                {
                    var state = 0;
                    if (eType.Equals("agree") && islastFlow)
                    {
                        switch (flowName)
                        {
                            case "查封审批":
                                {
                                    state = 10;
                                }
                                break;
                            case "解封审批":
                                {
                                    state = 20;
                                }
                                break;
                        }
                        isOk = UpdateState(id, state);
                    }
                    else if ((eType.Equals("agree") || eType.Equals("apply")) && !islastFlow)
                    {
                        isOk = UpdateState(id);   //在原有基础上增加1
                    }
                    else if (eType.Equals("disAgree"))
                    {
                        switch (flowName)
                        {
                            case "查封审批":
                                {
                                    state = 0;
                                }
                                break;
                            case "解封审批":
                                {
                                    state = 10;
                                }
                                break;
                        }
                        new CrmIdeaListBll().DeleteIdea(id, flowName);
                        new WfProcessInstanceBll().UpProcessInstance(flowName, id);
                        isOk = UpdateState(id, state);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return isOk;
        }

        /// <summary>
        /// 更改加班的状态，在当前状态上面加1
        /// 添加人：周 鹏
        /// 添加时间：2015-04-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public bool UpdateState(string id)
        {
            return new SealUpDal().UpdateState(id);
        }

        /// <summary>
        /// 更改的状态
        /// 添加人：周 鹏
        /// 添加时间：2015-04-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public bool UpdateState(string id, int state)
        {
            return new SealUpDal().UpdateState(id, state);
        }

        /// <summary>
        /// 事务保存查封物品信息
        /// </summary>
        /// <param name="sealup">查封实体</param>
        /// <param name="sealUpGoodsList">查封物品</param>
        /// <returns></returns>
        public bool TransactionSave(SealUpEntity sealup, List<SealUpGoodsEntity> sealUpGoodsList,string legislationId, string legislationItemId, string legislationGistId)
        {
            return new SealUpDal().TransactionSave(sealup, sealUpGoodsList, legislationId,  legislationItemId,  legislationGistId);

        }
    }
}
