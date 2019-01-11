//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseMainDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/2/1 9:11:45
//  功能描述：LicenseMain数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.License;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Common;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
namespace Yookey.WisdomClassed.SIP.DataAccess.License
{
    /// <summary>
    /// LicenseMain数据访问操作
    /// </summary>
    public class LicenseMainDal : DalImp.BaseDal<LicenseMainEntity>
    {
        public LicenseMainDal()
        {
            Model = new LicenseMainEntity();
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
            var strSql = new StringBuilder("");
            var childSql = new StringBuilder("");
            if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
            {
                childSql.AppendFormat("AND CompanyId='{0}' ", companyId);
            }
            if (!string.IsNullOrEmpty(deptId) && !deptId.Equals("all"))
            {
                childSql.AppendFormat("AND DeptId='{0}' ", deptId);
            }

            strSql.AppendFormat(@"SELECT
(SELECT COUNT(*) FROM LicenseMain WHERE RowStatus=1 AND DataSource='1' AND [State]=0) AS 'Admissible',
(SELECT COUNT(*) FROM LicenseMain WHERE RowStatus=1 AND DataSource='1' AND [State]>=10 AND [State]<=11) AS 'ToVisit',
(SELECT COUNT(*) FROM LicenseMain WHERE RowStatus=1 AND DataSource='1' AND [State]>11 AND [State]<30) AS 'ToBeAudited',
(SELECT COUNT(*) FROM LicenseMain WHERE RowStatus=1 AND DataSource='1' AND ([State]=20 OR [State]=30) ) AS 'ToBeDone',
(SELECT COUNT(*) FROM LicenseMain WHERE RowStatus=1 AND DataSource='1' AND [State]=40) AS 'HaveDone',
(select count(*) from (
select LM.Id,LM.ItemCode,LM.ApplicantName,CR.RsKey ItemName,DataSource,
LM.ApplicationDate,LM.PromiseEndDate,LM.[State],LM.CreateOn,
(case when LM.ItemCode in('JS050800ZJ-XK-0090','JS050800ZJ-XK-0190') then LO.Content when LM.ItemCode ='JS050800ZJ-XK-0020' then LJ.Content end) Content,
(case when LM.ItemCode in('JS050800ZJ-XK-0090','JS050800ZJ-XK-0190') then LM.SetUpAddress when LM.ItemCode ='JS050800ZJ-XK-0020' then LJ.JeevesAdress end) SetUpAddress,
CM.FullName CompanyName
from [LicenseMain] LM 
left join ComResource CR on Cr.RsValue=LM.ItemCode
left join LicenseOutDoor LO on LO.LicenseId=LM.Id 
left join LicenseJeeves LJ on LJ.LicenseId=LM.Id
left join CrmCompany CM on CM.Id=LM.Area
WHERE 1=1 
UNION ALL
SELECT Advertising.Id,'' ItemCode,CompanyName ApplicantName,ComResource.RSKEY AS ItemName,'3' DataSource,
StartDate ApplicationDate,EndDate PromiseEndDate,'40' [state],Advertising.CreateOn,
AdvertisContents Content,
[Address] SetUpAddress,
OwnerCompanyName CompanyName
FROM Advertising 
INNER JOIN dbo.ComResource ON ComResource.ID=Advertising.TypeNo WHERE Advertising.RowStatus=1) as T) AS 'All'", childSql);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }


        /// <summary>
        /// 办件查询
        /// 添加人：周 鹏
        /// 添加时间：2018-02-02
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseStateType">案件状态分类</param>
        /// <param name="licenseType">许可类型</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable QueryLicenseList(LicenseStateType caseStateType, string licenseType, string companyId, string keyword, string StartTime, string EndTime, string DataSource,string secpType,int pageSize,int pageIndex, string sidx, string sord, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"select *from (
select LM.Id,LM.ItemCode,LM.ApplicantName,CR.RsKey ItemName,DataSource,
LM.ApplicationDate,LM.PromiseEndDate,LM.[State],LM.CreateOn,LM.LicenseNo,
(case when LM.ItemCode in('JS050800ZJ-XK-0090','JS050800ZJ-XK-0190') then LO.Content when LM.ItemCode ='JS050800ZJ-XK-0020' then LJ.Content end) Content,
(case when LM.ItemCode in('JS050800ZJ-XK-0090','JS050800ZJ-XK-0190') then LM.SetUpAddress when LM.ItemCode ='JS050800ZJ-XK-0020' then LJ.JeevesAdress end) SetUpAddress,
CM.FullName CompanyName,LM.Area Area
from [LicenseMain] LM 
left join ComResource CR on Cr.RsValue=LM.ItemCode
left join LicenseOutDoor LO on LO.LicenseId=LM.Id 
left join LicenseJeeves LJ on LJ.LicenseId=LM.Id
left join CrmCompany CM on CM.Id=LM.Area
WHERE 1=1 
UNION ALL
SELECT Advertising.Id,'' ItemCode,CompanyName ApplicantName,ComResource.RSKEY AS ItemName,'3' DataSource,
StartDate ApplicationDate,EndDate PromiseEndDate,'40' [state],Advertising.CreateOn,'' LicenseNo,
AdvertisContents Content,
[Address] SetUpAddress,
OwnerCompanyName CompanyName,'' Area
FROM Advertising 
INNER JOIN dbo.ComResource ON ComResource.ID=Advertising.TypeNo WHERE Advertising.RowStatus=1) as T where 1=1");

                //状态分类
                switch (caseStateType)
                {
                    case LicenseStateType.Admissible:
                        {
                            strSql.Append("AND [State]=0 ");
                        }
                        break;
                    case LicenseStateType.ToVisit:
                        {
                            strSql.Append("AND [State]>=10 AND [State]<=11 ");
                        }
                        break;
                    case LicenseStateType.ToBeAudited:
                        {
                            strSql.Append("AND [State]>11 AND [State]<30 ");
                        }
                        break;
                    case LicenseStateType.ToBeDone:
                        {
                            strSql.Append("AND ([State]=20 OR [State]=30) ");
                        }
                        break;
                    case LicenseStateType.HaveDone:
                        {
                            strSql.Append("AND [State]=40 ");
                        }
                        break;
                    case LicenseStateType.All:
                        break;
                }

                if (caseStateType != LicenseStateType.All)//不是查询的全部
                {
                    strSql.AppendFormat(" AND DataSource = '{0}'", 1);
                }

                if (!string.IsNullOrEmpty(licenseType))
                {
                    strSql.AppendFormat("AND ItemCode='{0}'", licenseType);
                }

                if(!string.IsNullOrEmpty(companyId))
                {
                    strSql.AppendFormat("AND Area='{0}'", companyId);
                }

                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat("AND (ApplicantName LIKE '%{0}%' OR SetUpAddress LIKE '%{0}%' OR Content LIKE '%{0}%')", keyword);
                }

                if (!string.IsNullOrEmpty(StartTime))
                {
                    strSql.AppendFormat(" AND ApplicationDate >= '{0}'", StartTime);
                }

                if(!string.IsNullOrEmpty(EndTime))
                {
                    strSql.AppendFormat(" AND ApplicationDate <= '{0} 23:59:59'", EndTime);
                }
               
                if (!string.IsNullOrEmpty(secpType) && DataSource=="2")//历史数据设施类型查询
                {
                    strSql.AppendFormat(" AND ApplicantType = '{0}'", secpType);
                }             

                var sortField = "CreateOn"; //排序字段
                var sortType = "DESC"; //排序类型

                if (!string.IsNullOrEmpty(sidx))
                {
                    sortField = sidx;
                    sortType = sord;
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField,
                                                sortType, pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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
            var strSql = string.Format("UPDATE LicenseMain SET [State]+=1 WHERE Id='{0}'", id);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
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
            try
            {
                var strSql = string.Format("UPDATE LicenseMain SET [State]={0} WHERE Id='{1}'", state, id);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取某一许可的一年的案件数量
        /// </summary>
        /// <param name="year"></param>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public string GetLicenseCount(string licenseSetNo,string itemCode)
        {
            try
            {
                if (string.IsNullOrEmpty(licenseSetNo) || string.IsNullOrEmpty(itemCode))
                    return string.Empty;                
                var strSql = string.Format(@"SELECT TOP 1 CAST(SUBSTRING(LicenseSetNo,CHARINDEX('-',LicenseSetNo)+3,5) AS INT) LicenseSetNo FROM LicenseMain WHERE 1=1 
AND LicenseSetNo LIKE '{0}%' AND ItemCode='{1}'
ORDER BY CAST(SUBSTRING(LicenseSetNo,CHARINDEX('-',LicenseSetNo)+3,5) AS INT) DESC ", licenseSetNo,itemCode);                
                var obj= SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql);
                var numberStr = obj == null ? string.Empty : obj.ToString();

                return numberStr;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        /// <summary>
        /// 案件受理数量查询
        /// </summary>
        /// <param name="handTimeSearch"></param>
        /// <returns></returns>
        public List<HandTimeArea> GetAcceptancedateCount(HandTimeSearch handTimeSearch)
        {
            try
            {                
                var strSql = "SELECT Area CompanyId,COUNT(ID) CaseCount FROM LICENSEMAIN WHERE RowStatus=1 AND Area IS NOT NULL AND [State]>=10 ";
                if (!string.IsNullOrEmpty(handTimeSearch.ItemCode))
                {
                    strSql += string.Format(" AND ItemCode='{0}'", handTimeSearch.ItemCode);
                }
                if (handTimeSearch.BeginTime != default(DateTime))
                {
                    strSql += string.Format(" AND AcceptanceDate>='{0}'", handTimeSearch.BeginTime.ToString(AppConst.DateFormat));
                }
                if (handTimeSearch.EndTime != default(DateTime))
                {
                    strSql += string.Format(" AND AcceptanceDate<='{0} 23:59:59'", handTimeSearch.EndTime.ToString(AppConst.DateFormat));
                }
                strSql += " GROUP BY Area";
                var date=SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringWrite,CommandType.Text,strSql).Tables[0];
                var result= ConvertListHelper<HandTimeArea>.ConvertToList(date);
                return result;
            }
            catch(Exception ex )
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 案件退回窗口
        /// </summary>
        /// <returns></returns>
        public bool SendLicenseTowindow(string licenseId, string userId, string workListId, string idea)
        {
            if (string.IsNullOrEmpty(licenseId)||string.IsNullOrEmpty(userId)||string.IsNullOrEmpty(workListId)||string.IsNullOrEmpty(idea))
                return false;
            var transaction = new TransactionLoader().BeginTransaction("BackWindows");
            //向窗口插入代办
            var sendUser = new CrmUserDal().Get(userId);
            var licenseMain = new LicenseMainDal().Get(licenseId);
            var crmmessage=new CrmMessageWorkDal().Get(workListId);
            var idea_Message=new CrmIdeaListDal().GetSearchResult(new CrmIdeaListEntity(){
                ResourceID=licenseId
            }).Find(i=>i.ProcessInstanceID==crmmessage.ProcessInstanceID);
            if (sendUser == null || licenseMain == null || crmmessage == null)
                return false;
            var formAdress = string.Empty;
            var contentType = string.Empty;
            var title = string.Empty;
            Random rdm = new Random();
            switch (licenseMain.ItemCode)
            {
                case "JS050800ZJ-XK-0090"://店招标牌
                    formAdress = "/LicenseOutDoor/Entity?Radom" + rdm.NextDouble().ToString();
                    contentType = (licenseMain.State > 20 ? "00050008" : "00050009");
                    title = "【店招标牌退回窗口】" + "来自" + sendUser.RealName + "的店招标牌" + "退回窗口";
                    break;
                case "JS050800ZJ-XK-0020"://临时占道
                    formAdress = "/LicenseJeeves/Entity?Radom" + rdm.NextDouble().ToString();
                    contentType = (licenseMain.State > 20 ? "00050012" : "00050013");
                    title = "【临时占道转派】" + "来自" + sendUser.RealName + "的临时占道" + "退回窗口";
                    break;
                case "JS050800ZJ-XK-0190"://大型户外广告
                    formAdress = "/LicensePositionOutDoor/Entity?Radom" + rdm.NextDouble().ToString();
                    contentType = (licenseMain.State > 20 ? "00050010" : "00050011");
                    title = "【大型户外广告转派】" + "来自" + sendUser.RealName + "的大型户外广告" + "退回窗口";
                    break;
                default:
                    formAdress = string.Empty;
                    contentType = string.Empty;
                    break;
            }
            try
            {
                var actinUsers = new CrmUserDal().GetLicenseActionUsers("批文受理");//接受人
                foreach (var item in actinUsers)
                {
                   var messageWork = new CrmMessageWorkEntity();
                   messageWork.Id = Guid.NewGuid().ToString();
                   messageWork.FormID = licenseId;
                   messageWork.FormAddress = formAdress;
                   messageWork.FormData = "";
                   messageWork.ContentTypeID = contentType;
                   messageWork.IsReply = 0;
                   messageWork.State = 0;
                   messageWork.RowStatus = 1;
                   messageWork.SenderID = sendUser.Id;
                   messageWork.StartDate = DateTime.Now;
                   messageWork.ActionerID = item;       //接受人ID
                   messageWork.CreateOn = DateTime.Now;
                   messageWork.Titles = title;
                   new CrmMessageWorkDal().Add(messageWork, transaction);
                }
                licenseMain.State = -1;//状态-1作废
                new LicenseMainDal().Update(licenseMain, transaction);

                crmmessage.State = 2;//当前待办状态已处理
                new CrmMessageWorkDal().Update(crmmessage, transaction);

                //审批消息
                var ideaEntity = new CrmIdeaListEntity();
                ideaEntity.Id = Guid.NewGuid().ToString();
                ideaEntity.ResourceID = licenseId;
                ideaEntity.Duty = "退回窗口("+sendUser.RealName+")";
                ideaEntity.UserId = userId;
                ideaEntity.Type = "1";
                ideaEntity.RowStatus = 1;
                ideaEntity.LeveL = "0";
                ideaEntity.Idea = idea;
                ideaEntity.CreateOn = DateTime.Now;
                ideaEntity.ProcessID = idea_Message.ProcessID;
                ideaEntity.ProcessInstanceID = idea_Message.ProcessInstanceID;
                //插入意见
                new CrmIdeaListDal().Add(ideaEntity,transaction);
                
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message, ex);
            }

        }

        /// <summary>
        /// 窗口统计
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public DataTable WindowStatistic(string beginTime, string endTime)
        {
            var whereStr=string.Empty;
            if(!string.IsNullOrEmpty(beginTime))
            {
                whereStr+=string.Format(" and datediff(dd,'{0}',ApplicationDate)>=0",beginTime);
            }
            if(!string.IsNullOrEmpty(endTime))
            {
                whereStr+=string.Format(" and datediff(dd,'{0}',ApplicationDate)<=0",endTime);
            }
            var strSql = string.Format(@"select '店招标牌' TypeName,
(select count(*) from LicenseMain where 
ItemCode='JS050800ZJ-XK-0090' and  DataSource=1 
{0}) as TotalNumber,
(select count(*) from LicenseMain where 
State=40 and ItemCode='JS050800ZJ-XK-0090' and  DataSource=1 
{0}) as FinishNumber,
(select count(*) from LicenseMain where 
State=-1 and ItemCode='JS050800ZJ-XK-0090' and  DataSource=1 
{0}) as InvalidNumber
union all
select '大型户外广告' TypeName,
(select count(*) from LicenseMain where 
ItemCode='JS050800ZJ-XK-0190'
{0}) as TotalNumber,
(select count(*) from LicenseMain where 
State=40 and ItemCode='JS050800ZJ-XK-0190'
{0}) as FinishNumber,
(select count(*) from LicenseMain where 
State=-1 and ItemCode='JS050800ZJ-XK-0190'
{0}) as InvalidNumber
union all
select '临时占道' TypeName,
(select count(*) from LicenseMain where 
ItemCode='JS050800ZJ-XK-0020'
{0}) as TotalNumber,
(select count(*) from LicenseMain where 
State=40 and ItemCode='JS050800ZJ-XK-0020'
{0}) as FinishNumber,
(select count(*) from LicenseMain where 
State=-1 and ItemCode='JS050800ZJ-XK-0020'
{0}) as InvalidNumber", whereStr);
            try
            {
                var date = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql).Tables[0];
                return date;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取行政许可系统中未公示的许可数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetUnPublicLicensePulicity()
        {
            var strSql = new StringBuilder("");
            strSql.Append(
                @"select  M.Id,LicenseSetNo XK_WSH,
(case when ItemCode='JS050800ZJ-XK-0090' then '店招标牌审批' when ItemCode='JS050800ZJ-XK-0190' then '大型户外广告审批' when ItemCode='JS050800ZJ-XK-0020' then '临时占道审批' end) XK_XMMC,
ItemCode XK_BM,
(case when ItemCode='JS050800ZJ-XK-0090' then O.Content when ItemCode='JS050800ZJ-XK-0190' then O.Content when ItemCode='JS050800ZJ-XK-0020' then J.Content end) XK_NR,
LegalPersonName XK_XDR,
PaperCode XK_XDR_SHXYM,
PaperCode XK_XDR_ZDM,
PaperCode XK_XDR_GSDJ,
PaperCode XK_XDR_SFZ,
LegalPersonName XK_FR,
ClosedDate XK_JDRQ,
PromiseEndDate XK_JZQ,
'苏州市姑苏区综合行政执法局' XK_XZJG,
State XK_ZT,
0 FW
from LicenseMain M
left join LicenseOutDoor O ON O.LicenseId=M.Id
left join LicenseJeeves  J ON J.LicenseId=M.Id
where DataSource='1' and (IsPublic<>'1' or IsPublic is NULL) and (state=40 or State=-1)");
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

    }
}

