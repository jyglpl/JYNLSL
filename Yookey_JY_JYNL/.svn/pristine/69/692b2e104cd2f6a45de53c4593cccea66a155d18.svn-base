using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.WorkFlow;
using Yookey.WisdomClassed.SIP.DataAccess.Petition;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Petition;

namespace Yookey.WisdomClassed.SIP.Business.Petition
{
    /// <summary>
    /// Petition业务逻辑
    /// </summary>
    public class PetitionBll : BaseBll<PetitionEntity>
    {
        public PetitionBll()
        {
            BaseDal = new PetitionDal();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="pe"></param>
        /// <param name="keyWords"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryList(PetitionEntity pe, string keyWords, string status, string sidx,
                                                   string sord, int pageSzie, int pageIndex, string StartTime,
                                                   string EndTime)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var stype = (PetitionStateType)Enum.Parse(typeof(PetitionStateType), status);
            int totalRecords;

            var data = new PetitionDal().QueryList(pe, stype, keyWords, pageSzie, pageIndex, sidx, sord,
                                                   out totalRecords, StartTime, EndTime);

            int totalPage = (totalRecords + pageSzie - 1) / pageSzie;

            stopwatch.Stop();

            return new PageJqDatagrid<DataTable>
                {
                    page = pageIndex,
                    rows = data,
                    total = totalPage,
                    records = totalRecords,
                    costtime = stopwatch.ElapsedMilliseconds.ToString()
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
        public bool SealUpApproveReturn(string eType, string userId, string id, string flowName, bool islastFlow,
                                        string worklistId, DateTime approveDate)
        {
            var isOk = false;

            try
            {
                var entity = Get(id);
                var state = entity.Status;
                if (!string.IsNullOrEmpty(worklistId))
                {
                    new CrmMessageWorkBll().UpdateWorkListState(worklistId, DateTime.Now); //更改消息的状态为已处理
                }

                //验证当前流程环节为最后一步,需将案件状态更改为当前有流程最大值,如果不是最后一步流程,直接在原有状态的基本上面+1
                if (!string.IsNullOrEmpty(flowName) && !string.IsNullOrEmpty(id))
                {
                    if (eType.Equals("agree") && islastFlow)
                    {
                        switch (flowName)
                        {
                            case "信访审批":
                                {
                                    state = 20;
                                }
                                break;
                        }
                        isOk = UpdateState(id, state);
                    }
                    else if ((eType.Equals("agree") || eType.Equals("apply")) && !islastFlow)
                    {
                        isOk = UpdateState(id); //在原有基础上增加1
                    }
                    else if (eType.Equals("disAgree"))
                    {
                        if (state == 13) //节点是各单位的时候退回发起人
                        {
                            state = 10;
                            isOk = UpdateState(id, state);
                        }
                        else if (state == 17) //法制处退回
                        {
                            entity.Status = 14;
                            entity.IsFZCBack = 1;
                            isOk = Update(entity) > 0;
                        }
                        else
                        {
                            state -= 1;
                            isOk = UpdateState(id, state);
                        }

                    }
                    else
                    {
                        isOk = !islastFlow ? UpdateState(id) : UpdateState(id, state);
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
            return new PetitionDal().UpdateState(id);
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
            return new PetitionDal().UpdateState(id, state);
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="pe"></param>
        /// <returns></returns>
        public bool SaveFile(PetitionEntity pe, string userId)
        {
            var userEntity = new CrmUserBll().Get(userId);
            return new PetitionDal().SaveFile(pe, userEntity);
        }

        /// <summary>
        /// 获取编号
        /// </summary>
        /// <returns></returns>
        public string GetNo(string Value)
        {
            string no = new PetitionDal().GetNo(Value);

            if (!string.IsNullOrEmpty(no))
            {
                int count = int.Parse(no.Substring(4));
                count += 1;

                return Value + count.ToString().PadLeft(4, '0');
            }
            return Value + "0001";
        }

        /// <summary>
        /// 获取状态数量
        /// </summary>
        /// <returns></returns>
        public DataTable GetPetitionCount()
        {
            return new PetitionDal().GetPetitionCount();
        }

        /// <summary>
        /// 验证是否已通过终审环节
        /// </summary>
        /// <param name="petionId">信访Id</param>
        /// <returns></returns>
        public bool CheckIsFinalExamine(string petionId)
        {
            try
            {
                return new PetitionDal().CheckIsFinalExamine(petionId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
