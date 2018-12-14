using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;
using Yookey.WisdomClassed.SIP.DataAccess.IllegalConstruction;
using PetaPoco;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.WorkFlow;

namespace Yookey.WisdomClassed.SIP.Business.IllegalConstruction
{
    public class IllegalCaseInfoBll
    {
        public static readonly IllegalCaseInfoDal Dal = new IllegalCaseInfoDal();
        readonly CrmMessageWorkBll _crmMessageWorkBll = new CrmMessageWorkBll();                        //消息（待办事宜）
        /// <summary>
        /// 审批成功后,执行相应操作
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">当前登录用户编号</param>
        /// <param name="id">案件编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="islastFlow">是否为最后一步审批流程</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="approveDate">审批日期</param>
        /// <returns></returns>
        public bool CaseApproveReturn(string userId, string id, string flowName, bool islastFlow, string worklistId, DateTime approveDate, string eType)
        {
            var isOk = false;
            try
            {
                var state = 0;
                //验证当前流程环节为最后一步,需将案件状态更改为当前有流程最大值,如果不是最后一步流程,直接在原有状态的基本上面+1
                if (!string.IsNullOrEmpty(flowName) && !string.IsNullOrEmpty(id) && islastFlow)
                {
                    switch (flowName)
                    {
                        case "违建结案审批":
                            {
                                state = 90;   //将案件状态直接更改为归档
                                _crmMessageWorkBll.UpdateUnHandleMessage(id);
                            }
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(worklistId))
                {
                    if (eType == "disAgree" || eType == "disagree")
                    {
                        switch (flowName)
                        {

                            case "违建结案审批":
                                {
                                    state = 50;
                                }
                                break;
                        }
                        new CrmIdeaListBll().DeleteIdea(id, flowName);
                        //new WfProcessInstanceBll().UpProcessInstance(flowName, id);
                    }
                }
                if (!string.IsNullOrEmpty(worklistId))
                {
                    new CrmMessageWorkBll().UpdateWorkListState(worklistId, DateTime.Now);  //更改消息的状态为已处理
                }
                if (eType == "disAgree" || eType == "disagree")
                {
                    isOk = Dal.UpdateIllegalCaseStatus(state.ToString(), id);
                }
                else if (eType == "Agree" || eType == "agree")
                {
                    if (!islastFlow) //不是最后节点 保证状态不是最后
                    {
                        isOk = UpdateIllegalCaseNextStatus(id);   //更改案件状态+1
                    }
                    else
                    {
                        isOk = Dal.UpdateIllegalCaseStatus(state.ToString(), id);
                    }
                }
                else if (eType == "applys")
                {
                    state = 51;
                    isOk = Dal.UpdateIllegalCaseStatus(state.ToString(), id);
                    //更新直接结案字段
                    Dal.EndIllegalCaseInfo(id);
                }
                else
                {
                    isOk = !islastFlow ? UpdateIllegalCaseNextStatus(id) : Dal.UpdateIllegalCaseStatus(state.ToString(), id); ;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return isOk;
        }

        /// <summary>
        /// 新增违法案件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertIllegalCaseInfo(IllegalCaseInfoEntity entity)
        {
            return Dal.InsertIllegalCaseInfo(entity);
        }

        /// <summary>
        /// 获取违法案件
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryIllegalCaseList(string companyId, string deptId, string source, string keyword, string userId, string sidx, string sord, int pageSzie = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;

            var data = Dal.QueryIllegalCaseList(companyId, deptId, source, keyword, userId, pageSzie, pageIndex, sidx, sord, out totalRecords);

            data.TableName = "IllegalCaseDT";
            stopwatch.Stop();
            int totalPage = (totalRecords + pageSzie - 1) / pageSzie;   //计算页数
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
        /// 获取违法案件集合
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<IllegalCaseInfoEntity> GetIllegalCaseResult(IllegalCaseInfoEntity search)
        {
            return Dal.GetIllegalCaseResult(search);
        }

        /// <summary>
        /// 获取某月违法案件集合
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<IllegalCaseInfoEntity> GetIllegalCaseResult(IllegalCaseInfoEntity search, string startTime, string endTime)
        {
            return Dal.GetIllegalCaseResult(search, startTime, endTime);
        }

        /// <summary>
        /// 删除违法案件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteIllegalCaseInfo(string Id)
        {
            return Dal.DeleteIllegalCaseInfo(Id);
        }

        /// <summary>
        /// 更新案件状态
        /// </summary>
        /// <param name="Status">案件状态</param>
        /// <param name="PK_ID">案件主键</param>
        /// <returns></returns>
        public bool UpdateIllegalCaseStatus(string Status, string PK_ID)
        {
            return Dal.UpdateIllegalCaseStatus(Status, PK_ID);
        }


        /// <summary>
        /// 更新日期
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="Date"></param>
        /// <param name="PK_ID"></param>
        /// <returns></returns>
        public bool UpdateIllegalCaseDate(string Status, string Date, string PK_ID)
        {
            return Dal.UpdateIllegalCaseDate(Status, Date, PK_ID);
        }

        /// <summary>
        /// 更新案件状态
        /// </summary>
        /// <param name="PK_ID">案件主键</param>
        /// <returns></returns>
        public bool UpdateIllegalCaseNextStatus(string PK_ID)
        {
            return Dal.UpdateIllegalCaseNextStatus(PK_ID);
        }

        /// <summary>
        /// 更新案件实体
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool UpdateIllegalCase(IllegalCaseInfoEntity search)
        {
            return Dal.UpdateIllegalCase(search);
        }

        /// <summary>
        /// 按责任部门统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetDeptStatisticsData()
        {
            return Dal.GetDeptStatisticsData();
        }

        /// <summary>
        /// 按地域统计
        /// </summary>
        /// <returns></returns>
        public DataTable GetAreaStatistics()
        {
            return Dal.GetAreaStatistics();
        }
    }
}
