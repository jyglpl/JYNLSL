//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseMainBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/2/1 9:11:45
//  功能描述：LicenseMain业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.WorkFlow;
using Yookey.WisdomClassed.SIP.DataAccess.License;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.License;
using System.Linq;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Model.Com;
namespace Yookey.WisdomClassed.SIP.Business.License
{
    /// <summary>
    /// LicenseMain业务逻辑
    /// </summary>
    public class LicenseMainBll : BaseBll<LicenseMainEntity>
    {
        public LicenseMainBll()
        {
            BaseDal = new LicenseMainDal();
        }

        /// <summary>
        /// 查询办件的状态
        /// 添加人：周 鹏
        /// 添加时间：2018-02-05
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="userDeptId">当前登录部门的Id</param>
        /// <param name="deptId">部门编号,查询指定部门的数据,不传则查所有</param>
        /// <returns></returns>
        public DataTable GetLicenseStateCount(string companyId, string deptId, string userDeptId)
        {
            return new LicenseMainDal().GetLicenseStateCount(companyId, deptId, userDeptId);
        }

        /// <summary>
        /// 案件查询
        /// 添加人：周 鹏
        /// 添加时间：2018-02-02
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseStateType">案件状态分类</param>
        /// <param name="licenseType">许可类型</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageSzie">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryLicenseList(string caseStateType, string licenseType, string companyId, string keyword, string StartTime, string EndTime, string dataSource, string secpType, string sidx, string sord, int pageSzie = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;

            var stype = (LicenseStateType)Enum.Parse(typeof(LicenseStateType), caseStateType);

            var data = new LicenseMainDal().QueryLicenseList(stype, licenseType, companyId, keyword, StartTime, EndTime, dataSource, secpType, pageSzie, pageIndex, sidx, sord, out totalRecords);

            data.TableName = "LicenseData";
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
        /// 案件查询
        /// 添加人：周 鹏
        /// 添加时间：2018-02-02
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseStateType">案件状态分类</param>
        /// <param name="licenseType">许可类型</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageSzie">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <returns></returns>
        public DataTable MobileQueryLicenseList(string caseStateType, string licenseType, string companyId, string keyword, string StartTime, string EndTime, string dataSource, string secpType, int pageSzie = 15, int pageIndex = 1)
        {
            var stype = (LicenseStateType)Enum.Parse(typeof(LicenseStateType), caseStateType);

            string sidx = "";
            string sord = "";
            int totalRecords = 0;
            var data = new LicenseMainDal().QueryLicenseList(stype, licenseType, companyId, keyword, StartTime, EndTime, dataSource, secpType, pageSzie, pageIndex, sidx, sord, out totalRecords);

            return data;
        }

        /// <summary>
        /// 案件查询
        /// 添加人：周 鹏
        /// 添加时间：2018-02-02
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseStateType">案件状态分类</param>
        /// <param name="licenseType">许可类型</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageSzie">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <returns></returns>
        public DataTable MobileQueryLicenseListAll(string caseStateType, string licenseType, string companyId, string keyword, string StartTime, string EndTime, string dataSource, string secpType, int pageSzie = 15, int pageIndex = 1)
        {
            var stype = (LicenseStateType)Enum.Parse(typeof(LicenseStateType), caseStateType);

            string sidx = "";
            string sord = "";
            int totalRecords = 0;
            var data = new LicenseMainDal().QueryLicenseList(stype, licenseType, companyId, keyword, StartTime, EndTime, dataSource, secpType, pageSzie, pageIndex, sidx, sord, out totalRecords);

            return data;
        }

        /// <summary>
        /// 更改办件的状态，在当前状态上面加1
        /// 添加人：周 鹏
        /// 添加时间：2018-02-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public bool UpdateLicenseState(string id)
        {
            return new LicenseMainDal().UpdateLicenseState(id);
        }

        /// <summary>
        /// 更改办件的状态
        /// 添加人：周 鹏
        /// 添加时间：2018-02-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public bool UpdateLicenseState(string id, int state)
        {
            return new LicenseMainDal().UpdateLicenseState(id, state);
        }

        /// <summary>
        /// 审批成功后,执行相应操作
        /// 添加人：周 鹏
        /// 添加时间：2018-02-04
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
        public bool LicenseApproveReturn(string userId, string id, string flowName, bool islastFlow, string worklistId, DateTime approveDate, string eType)
        {
            var isOk = false;
            try
            {
                var entity = Get(id);
                var state = entity.State;
                //验证当前流程环节为最后一步,需将案件状态更改为当前有流程最大值,如果不是最后一步流程,直接在原有状态的基本上面+1
                if (!string.IsNullOrEmpty(flowName) && !string.IsNullOrEmpty(id) && islastFlow)
                {
                    switch (flowName)
                    {
                        case "店招标牌批文":
                        case "大型户外广告批文":
                        case "临时占道批文":
                            state = 20;
                            break;
                        case "店招标牌发证":
                        case "大型户外广告发证":
                        case "临时占道验收":
                            state = 30;
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(worklistId))
                {
                    if (eType == "disAgree" || eType == "disagree")
                    {
                        if (flowName != "大型户外广告批文")
                        {
                            if (entity.State == 13 || entity.State == 16)
                            {
                                state = entity.State - 2;
                            }
                            else if (entity.State == 23 || entity.State == 26)
                            {
                                state = entity.State - 2;
                            }
                            else
                            {
                                state = entity.State - 1; //退回时状态减1
                            }
                        }
                        else
                        {
                            state = entity.State - 1; //退回时状态减1
                        }

                    }
                }
                if (!string.IsNullOrEmpty(worklistId))
                {
                    new CrmMessageWorkBll().UpdateWorkListState(worklistId, DateTime.Now);  //更改消息的状态为已处理
                }
                if (eType == "disAgree" || eType == "disagree")
                {
                    isOk = UpdateLicenseState(id, state);
                }
                else if (eType == "apply")
                {
                    switch (flowName)
                    {
                        case "店招标牌批文":
                        case "大型户外广告批文":
                        case "临时占道批文":
                            state = 11;
                            break;
                        case "店招标牌发证":
                        case "大型户外广告发证":
                        case "临时占道验收":
                            state = 21;
                            break;
                    }
                    isOk = UpdateLicenseState(id, state);
                }
                else if (eType == "Agree" || eType == "agree")
                {
                    if (!islastFlow)//不是最后节点 保证状态不是最后
                    {
                        if ((flowName == "店招标牌批文" || flowName == "大型户外广告批文" || flowName == "临时占道批文") && state >= 19)//当时批文审批状态大于等于终节点状态
                        {
                            state = 19;
                        }
                        if ((flowName == "店招标牌发证" || flowName == "大型户外广告发证" || flowName == "临时占道验收") && state >= 29)//当时发证审批状态大于等于终节点状态
                        {
                            state = 29;
                        }
                    }
                    isOk = !islastFlow ? UpdateLicenseState(id) : UpdateLicenseState(id, state);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return isOk;
        }

        /// <summary>
        /// 获取某一许可的一年的案件数量
        /// </summary>
        /// <param name="year"></param>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public string GetLicenseCount(string licenseSetNo, string itemCode)
        {
            var countStr = new LicenseMainDal().GetLicenseCount(licenseSetNo, itemCode);
            var result = string.Empty;
            if (string.IsNullOrEmpty(countStr))
            {
                var key = new ComResourceBll().GetSearchResult(new ComResourceEntity { Id = "00710001" }).ToList();
                if (key != null && key.Count > 0)
                    result = key[0].RsValue;
                else
                    result = "1";
            }
            else
            {
                result = (int.Parse(countStr) + 1).ToString();
            }
            return int.Parse(result).ToString("00000");
        }

        /// <summary>
        /// 获取许可信息
        /// 添加人：周 鹏
        /// 添加时间：2018-02-05
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="search">查询实体</param> 
        /// <returns></returns>
        public List<LicenseMainEntity> GetSearchResult(LicenseMainEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(LicenseCheckSpecEntity.Parm_LicenseCheckSpec_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ItemCode))
            {
                queryCondition.AddEqual(LicenseMainEntity.Parm_LicenseMain_ItemCode, search.ItemCode);
            }
            if (!string.IsNullOrEmpty(search.DataSource))
            {
                queryCondition.AddEqual(LicenseMainEntity.Parm_LicenseMain_DataSource, search.DataSource);
            }
            if (search.State != 0)
            {
                queryCondition.AddEqual(LicenseMainEntity.Parm_LicenseMain_State, search.State.ToString());
            }
            //排序
            queryCondition.AddOrderBy(LicenseMainEntity.Parm_LicenseMain_CreateOn, true);
            return Query(queryCondition) as List<LicenseMainEntity>;
        }

        /// <summary>
        /// 案件受理数量查询
        /// </summary>
        /// <param name="handTimeSearch"></param>
        /// <returns></returns>
        public List<HandTimeArea> GetAcceptancedateCount(HandTimeSearch handTimeSearch)
        {
            var companyList = new CrmCompanyBll().GetAllCompany(new CrmCompanyEntity() { IsAcceptLicense = 1 });
            var handTimeAreaList = new List<HandTimeArea>();
            var data = new LicenseMainDal().GetAcceptancedateCount(handTimeSearch);
            foreach (var item in companyList)//循环片区
            {
                var countData = data.Find(i => i.CompanyId == item.Id);
                handTimeAreaList.Add(new HandTimeArea()
                {
                    CompanyId = item.Id,
                    AreaName = item.FullName,
                    CaseCount = (countData == null ? 0 : countData.CaseCount)
                });
            }
            return handTimeAreaList;
        }

        /// <summary>
        /// 获取许可统计报表数据
        /// </summary>
        /// <param name="itemcode">案件分类</param>
        /// <param name="bengin">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public LicenseCountInfo GetLicenseCountInfo(string itemcode, DateTime begin, DateTime endTime)
        {
            var licenseCountInfo = new LicenseCountInfo();
            var handTimeSearch = new HandTimeSearch();
            handTimeSearch.BeginTime = begin;
            handTimeSearch.EndTime = endTime;
            if (!string.IsNullOrEmpty(itemcode))
            {
                handTimeSearch.ItemCode = itemcode;
                switch (itemcode)
                {
                    case "JS050800ZJ-XK-0090":
                        handTimeSearch.FlowName = "店招标牌批文";
                        break;
                    case "JS050800ZJ-XK-0020":
                        handTimeSearch.FlowName = "临时占道批文";
                        break;
                    case "JS050800ZJ-XK-0190":
                        handTimeSearch.FlowName = "大型户外广告批文";
                        break;
                    default:
                        handTimeSearch.FlowName = string.Empty;
                        break;
                }
            }
            else
            {
                handTimeSearch.FlowName = string.Empty;
            }
            var crmMessageWorkBll = new CrmMessageWorkBll();
            licenseCountInfo.AcceptanceCount = this.GetAcceptancedateCount(handTimeSearch);//受理办件数

            handTimeSearch.BeginActivity = "批文街道查勘";
            handTimeSearch.EndActivity = "批文街道审核";
            handTimeSearch.IsMore = false;//按期
            handTimeSearch.Days = 3;//三天以内
            licenseCountInfo.HandleSchedule = crmMessageWorkBll.GetWorkListByHandTimeSub(handTimeSearch);//按期办理数           

            handTimeSearch.BeginActivity = "批文街道查勘";
            handTimeSearch.EndActivity = "批文街道审核";
            handTimeSearch.IsMore = true;//超期期
            handTimeSearch.Days = 3;//三天以内

            licenseCountInfo.HandExceed = crmMessageWorkBll.GetWorkListByHandTimeSub(handTimeSearch);//按期办理数           

            licenseCountInfo.CheckedCount = new List<HandTimeArea>();

            licenseCountInfo.CheckExceed = new List<HandTimeArea>();

            licenseCountInfo.CheckSchedule = new List<HandTimeArea>();

            #region//合计
            licenseCountInfo.HandTimeAreaTotal = new HandTimeAreaTotal();
            licenseCountInfo.HandTimeAreaTotal.AcceptanceCountTotal = licenseCountInfo.AcceptanceCount.Sum(i => i.CaseCount);
            licenseCountInfo.HandTimeAreaTotal.HandleScheduleTota = licenseCountInfo.HandleSchedule.Sum(i => i.CaseCount);
            licenseCountInfo.HandTimeAreaTotal.HandExceedTotal = licenseCountInfo.HandExceed.Sum(i => i.CaseCount);
            licenseCountInfo.HandTimeAreaTotal.CheckedCountTotal = licenseCountInfo.CheckedCount.Sum(i => i.CaseCount);
            licenseCountInfo.HandTimeAreaTotal.CheckScheduleTotal = licenseCountInfo.CheckSchedule.Sum(i => i.CaseCount);
            licenseCountInfo.HandTimeAreaTotal.CheckExceedTotal = licenseCountInfo.CheckExceed.Sum(i => i.CaseCount);

            #endregion
            return licenseCountInfo;
        }

        /// <summary>
        /// 案件退回窗口
        /// </summary>
        /// <param name="licenseId">案件编号</param>
        /// <param name="userId">人员</param>
        /// <returns></returns>
        public bool SendLicenseTowindow(string licenseId, string userId, string workListId, string idea)
        {
            CrmMessageWorkBll _crmMessageWorkBll = new CrmMessageWorkBll();
            var result=_crmMessageWorkBll.UpdateUnHandleMessage(licenseId);
            result=new LicenseMainDal().SendLicenseTowindow(licenseId, userId, workListId, idea);
            return result; 
        }


        /// <summary>
        /// 窗口统计
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public DataTable WindowStatistic(string beginTime, string endTime)
        {
            return SetTotal(new LicenseMainDal().WindowStatistic(beginTime, endTime));

        }

        /// <summary>
        /// 添加合计
        /// </summary>
        /// <param name="table">数据</param>
        public DataTable SetTotal(DataTable table)
        {
            DataRow drr = table.NewRow();
            var sum = new int[3];
            foreach (DataRow row in table.Rows)
            {
                sum[0] += (int)row["TotalNumber"];
                sum[1] += (int)row["FinishNumber"];
                sum[2] += (int)row["InvalidNumber"];
            }
            drr["TypeName"] = "合 计：";
            drr["TotalNumber"] = sum[0];
            drr["FinishNumber"] = sum[1];
            drr["InvalidNumber"] = sum[2];
            table.Rows.InsertAt(drr, 0);
            return table;
        }

    }
}
