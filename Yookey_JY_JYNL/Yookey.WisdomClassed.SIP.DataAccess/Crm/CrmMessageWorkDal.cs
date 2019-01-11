//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComMessageWorkDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：胡耀锋
//  创建日期：2014/4/8 8:53:41
//  功能描述：ComMessageWork数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Linq;
using Yookey;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;
using System.Net;
using System.Xml;
using Yookey.WisdomClassed.SIP.Common;
using System.Web;
using System.IO;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.DataAccess.Crm
{
    /// <summary>
    /// ComMessageWork数据访问操作
    /// </summary>
    public class CrmMessageWorkDal : DalImp.BaseDal<CrmMessageWorkEntity>
    {
        public CrmMessageWorkDal()
        {
            Model = new CrmMessageWorkEntity();
        }

        /// <summary>
        /// 新增待办事宜
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(CrmMessageWorkEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO [dbo].[CrmMessageWork]
           ([Id],[Titles],[ProcessInstanceID],[SendActivityID],[ActivityInstanceID]
           ,[StartDate],[SenderID]
           ,[ExecuteDate],[ActionerID],[FormID],[FormData],[FormAddress]
           ,[ContentTypeID],[IsReply],[State],[Note]
           ,[RowStatus],[CreatorId],[CreateBy],[CreateOn],[UpdateId],[UpdateBy],[UpdateOn])
     VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}')",
            entity.Id, entity.Titles, entity.ProcessInstanceID, entity.SendActivityID, entity.ActivityInstanceID,
            entity.StartDate, entity.SenderID, entity.ExecuteDate, entity.ActionerID,
            entity.FormID, entity.FormData, entity.FormAddress,
            entity.ContentTypeID, entity.IsReply, entity.State, entity.Note,
            entity.RowStatus, entity.CreatorId, entity.CreateBy, entity.CreateOn, entity.UpdateId, entity.UpdateBy, entity.UpdateOn);
            int result = SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString());
            return result > 0 ? true : false;
        }

        /// <summary>
        /// 获取当前表单最后处理的一条消息记录
        /// 添加人：周 鹏
        /// 添加时间：2014-08-05
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public string GetWorkListID(string formID)
        {
            var strSql = string.Format("SELECT TOP 1 Id FROM dbo.CrmMessageWork WHERE FormID='{0}' AND RowStatus=0 ORDER BY CreateOn DESC", formID);

            DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            return "";
        }


        /// <summary>
        /// 获取当前表单最后处理的一条消息记录
        /// 添加人：周 鹏
        /// 添加时间：2015-01-19
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public string GetLastWorkListID(string formID)
        {
            var strSql = string.Format("SELECT TOP 1 Id FROM CrmMessageWork WHERE FormID='{0}' AND RowStatus=1 ORDER BY CreateOn DESC", formID);

            DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            return "";
        }

        /// <summary>
        /// 得到消息记录
        /// 添加人：周 鹏
        /// 添加时间：2014-08-05
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// </summary>
        /// <param name="id">消息编号</param>
        /// <returns></returns>
        public DataTable GetWorkListDrawNear(string id)
        {
            try
            {
                var strSql = string.Format(@"SELECT * FROM CrmMessageWork WHERE Id = '{0}'", id);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 服务端->查询消息列表
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-02-28 周 鹏 更改用户表关联关系 
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="qtype">查询类型</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable GetSearchWork(string userId, WorkListType qtype, int pageIndex, int pageSize, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            //            strSql.AppendFormat(@"SELECT CMW.Id,CMW.Titles,CONVERT(VARCHAR(10),CMW.StartDate,25) AS StartDate,CU.UserName,FormAddress FROM CrmMessageWork AS CMW WITH(NOLOCK)
            //JOIN CrmUser AS CU WITH(NOLOCK) ON CMW.SenderId=CU.Id
            //WHERE ActionerID='{0}' ", userId);

            strSql.AppendFormat(@"SELECT CMW.Id,CMW.Titles,CONVERT(VARCHAR(10),CMW.StartDate,25) AS StartDate,CU.RealName AS UserName,FormAddress,CMW.ContentTypeID FROM CrmMessageWork AS CMW WITH(NOLOCK)
JOIN CrmUser AS CU WITH(NOLOCK) ON CMW.SenderId=CU.Id
WHERE ActionerID='{0}'", userId);

            switch (qtype)
            {
                case WorkListType.Pending:
                    strSql.AppendFormat("AND [State]=0 AND CMW.RowStatus=1");
                    break;
                case WorkListType.Read:
                    strSql.AppendFormat("AND [State]=1 AND CMW.RowStatus=1");
                    break;
                case WorkListType.Processed:
                    strSql.AppendFormat("AND [State]=2 AND CMW.RowStatus=1");
                    break;
                case WorkListType.Delete:
                    strSql.AppendFormat("AND CMW.RowStatus=0");
                    break;
            }

            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "StartDate", "DESC", pageIndex, pageSize, out totalRecords);
        }

        /// <summary>
        /// 查询消息数
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public DataTable WorkListCount(string userId)
        {
            var strSql = new StringBuilder();
            strSql.AppendFormat(@"SELECT
(SELECT COUNT(*) FROM CrmMessageWork WHERE ActionerID='{0}' AND RowStatus=1 AND [State]=0) AS 'Pending',
(SELECT COUNT(*) FROM CrmMessageWork WHERE ActionerID='{0}' AND RowStatus=1 AND [State]=1) AS 'Read',
(SELECT COUNT(*) FROM CrmMessageWork WHERE ActionerID='{0}' AND RowStatus=1 AND [State]=2) AS 'Processed',
(SELECT COUNT(*) FROM CrmMessageWork WHERE ActionerID='{0}' AND RowStatus=0) AS 'Delete'", userId);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 修改消息状态
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="workListId">消息编号</param>
        /// <param name="executeDate">消息处理时间</param>
        /// <param name="state">消息状态,0:待处理,1:已阅读,2:已处理</param>
        /// <returns></returns>
        public bool UpdateWorkListState(string workListId, DateTime executeDate, int state = 2)
        {
            var strSql = string.Format("UPDATE CrmMessageWork SET State={0},ExecuteDate='{1}' WHERE Id='{2}'", state, executeDate.ToString(AppConst.DateFormatLong), workListId);

            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql) > 0;
        }

        /// <summary>
        /// 请求消息明细
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">消息编号</param>
        /// <returns></returns>
        public DataTable GetWorkListDetails(string id)
        {
            var strSql = string.Format("UPDATE CrmMessageWork SET [State]=1 WHERE Id='{0}' AND [State]=0; SELECT (CASE WHEN [State]<>2 THEN FormAddress+'&Id='+FormId ELSE (SUBSTRING(FormAddress,0,CHARINDEX('?',FormAddress))+'?Id='+FormId)END) AS [Address] FROM CrmMessageWork  WHERE Id='{0}'", id);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
        }

        /// <summary>
        /// 删除消息
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="list">待删除的消息集</param>
        /// <param name="htype">操作方式</param>
        /// <returns></returns>
        public bool DeleteWorkList(List<string> list, string htype)
        {
            if (list.Any())
            {
                var transaction = new TransactionLoader().BeginTransaction("DeleteWorkList");
                try
                {
                    var sbSql = new StringBuilder();
                    if (list.Count >= 5)
                    {
                        foreach (var id in list)
                        {
                            sbSql.AppendFormat(@"UPDATE [CrmMessageWork] SET RowStatus={0} WHERE [Id] ={1};", htype.Equals("renew") ? 1 : 0, id);
                        }
                    }
                    else
                    {
                        sbSql.AppendFormat(@"UPDATE [CrmMessageWork] SET RowStatus={0} WHERE [Id] IN ('{1}');", htype.Equals("renew") ? 1 : 0, string.Join("','", list.ToArray()));
                    }
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
                transaction.Commit();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获取未处理的消息数
        /// 添加人：周 鹏
        /// 添加时间：2014-12-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public int GetUntreatedCount(string userid)
        {
            var strSql = string.Format("SELECT COUNT(*) FROM CrmMessageWork WHERE RowStatus=1 AND [State]<>2 AND ActionerID='{0}'", userid);
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
            if (obj != null)
            {
                return int.Parse(obj.ToString());
            }
            return 0;
        }

        /// <summary>
        /// 获取案件的流程（走到哪儿）
        /// 添加人：周 鹏
        /// 添加时间：2014-12-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-03-02 周 鹏 将人员表更改为基础数据平台人员表
        /// </history>
        /// <param name="formId">案件编号</param>
        /// <returns></returns>
        public DataTable GetCaseFlow(string formId)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT CMW.id,SenderID,ActionerID,SendActivityID,CRSend.RealName AS SendName,CRAction.RealName AS ActionName,CMW.FormData AS Idea,WFP.ProcessID AS FlowId,ISNULL(WP.Name,'') AS FlowName,CMW.CreateOn AS 'SendDate',CMW.[State] FROM CrmMessageWork AS CMW
JOIN CrmUser AS CRSend ON CMW.SenderID=CRSend.Id
JOIN CrmUser AS CRAction ON CMW.ActionerID=CRAction.Id
LEFT JOIN WF_ProcessInstance AS WFP WITH(NOLOCK) ON CMW.ProcessInstanceID=WFP.Id AND CMW.FormID=CMW.FormID
LEFT JOIN WF_Process AS WP WITH(NOLOCK) ON WP.Id=WFP.ProcessID
WHERE CMW.FormID='{0}' ORDER BY CMW.CreateOn", formId);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }



        /// <summary>
        /// 获取案件的流程（用于手机端）
        /// 添加人：周 鹏
        /// 添加时间：2018-02-07
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-03-02 周 鹏 将人员表更改为基础数据平台人员表
        /// </history>
        /// <param name="formId">案件编号</param>
        /// <returns></returns>
        public DataTable GetCaseFlowForMobile(string formId)
        {
            var strSql = new StringBuilder("");
            //            strSql.AppendFormat(@"
            //SELECT CRSend.RealName AS SendName,'' AS ActionName,CMW.Idea AS Idea,WFP.ProcessID AS FlowId,ISNULL(WP.Name,'') AS FlowName,CMW.CreateOn AS 'SendDate',2 AS [State]
            //FROM CrmIdeaList AS CMW
            //JOIN CrmUser AS CRSend ON CMW.UserId=CRSend.Id
            //LEFT JOIN WF_ProcessInstance AS WFP WITH(NOLOCK) ON CMW.ProcessInstanceID=WFP.Id
            //LEFT JOIN WF_Process AS WP WITH(NOLOCK) ON WP.Id=WFP.ProcessID
            //WHERE CMW.ResourceID='{0}' ORDER BY CMW.CreateOn", formId);

            strSql.AppendFormat(@"SELECT CRSend.RealName AS SendName,'' AS ActionName,CONVERT(NVARCHAR(500),CMW.FormData) AS Idea,WFP.ProcessID AS FlowId,ISNULL(WP.Name,'') AS FlowName,CMW.CreateOn AS 'SendDate',2 AS [State]
FROM CrmMessageWork AS CMW
JOIN CrmUser AS CRSend ON CMW.SenderID=CRSend.Id
LEFT JOIN WF_ProcessInstance AS WFP WITH(NOLOCK) ON CMW.ProcessInstanceID=WFP.Id
LEFT JOIN WF_Process AS WP WITH(NOLOCK) ON WP.Id=WFP.ProcessID
WHERE CMW.FormId='{0}' ORDER BY CMW.CreateOn", formId);


            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }


        /// <summary>
        /// 手机端->查询消息列表
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-06-15 周 鹏 增加事项类型条件过滤
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="qtype">查询类型</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="totalRecords">总条数</param>
        /// <param name="approveType">事项类型</param>
        /// <returns></returns>
        public DataTable GetMobileSearchWork(string userId, WorkListType qtype, int pageIndex, int pageSize, out int totalRecords, string approveType)
        {
            var strSql = new StringBuilder("");

            strSql.AppendFormat(@"SELECT CMW.Id AS WorkListId,CMW.FormID,CMW.Titles,CMW.StartDate AS SD,CONVERT(VARCHAR(10),CMW.StartDate,25) AS StartDate,
(CASE WHEN CU.RealName IS NULL THEN '系统' ELSE CU.RealName END) AS UserName,
WFP.ProcessID AS 'FlowId',WP.Name AS 'FlowName',ISNULL(WP.MessageType,CMW.ContentTypeID)  AS [Type] FROM CrmMessageWork AS CMW WITH(NOLOCK)
lEFT JOIN CrmUser AS CU WITH(NOLOCK) ON CMW.SenderId=CU.Id
LEFT JOIN WF_ProcessInstance AS WFP WITH(NOLOCK) ON CMW.ProcessInstanceID=WFP.Id AND CMW.FormID=CMW.FormID
LEFT JOIN WF_Process AS WP WITH(NOLOCK) ON WP.Id=WFP.ProcessID
WHERE ActionerID='{0}'", userId);

            switch (qtype)
            {
                case WorkListType.Pending:
                case WorkListType.Read:
                    strSql.AppendFormat("AND [State] IN (0,1) AND CMW.RowStatus=1");
                    break;
                case WorkListType.Processed:
                    strSql.AppendFormat("AND [State]=2 AND CMW.RowStatus=1");
                    break;
                case WorkListType.Delete:
                    strSql.AppendFormat("AND CMW.RowStatus=0");
                    break;
            }

            if (!string.IsNullOrEmpty(approveType))
            {
                switch (approveType)
                {
                    case "Case":
                        strSql.AppendFormat("AND WP.MessageType ='00050001' OR WP.MessageType IS NULL");
                        break;
                    case "Leave":
                        strSql.AppendFormat("AND WP.MessageType ='00050002'");
                        break;
                }
            }

            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "SD", "DESC", pageIndex, pageSize, out totalRecords);
        }

        /// <summary>
        /// 根据用户编号、表单号查询未处理的待办事宜
        /// 添加人：周 鹏
        /// 添加时间：2015-03-30
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="formId">表单号</param>
        /// <returns></returns>
        public DataTable GetUnHandleMessage(string userId, string formId)
        {
            try
            {
                const string strSql = @"SELECT TOP 1 * FROM CrmMessageWork WHERE FormID=@FormId AND ActionerID=@UserId AND ([State]=0 OR [State]=1) ORDER BY StartDate DESC";

                var paramerList = new List<SqlParameter>
                {
                    new SqlParameter("FormId", formId),
                    new SqlParameter("UserId", userId)
                };

                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql, paramerList.ToArray()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 批量更改未处理的消息
        /// 添加人：周 鹏
        /// 添加时间：2015-07-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="formID">表单号</param>
        public bool UpdateUnHandleMessage(string formID)
        {
            var strSql = string.Format("UPDATE CrmMessageWork SET [State]=2,ExecuteDate=GETDATE() WHERE FormID='{0}' AND [State]<>2", formID);

            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
        }
        /// <summary>
        /// 对调班条件查询
        /// </summary>
        /// <param name="wherestr">条件字符串</param>
        /// <returns>实体</returns>
        public bool GetMdoelByWhere(string setStr, string wherestr)
        {
            if (string.IsNullOrEmpty(wherestr) && string.IsNullOrEmpty(setStr))
            {
                return false;
            }
            var sqlStr = new StringBuilder();
            sqlStr.AppendFormat("update CrmMessageWork set {0} where 1=1 {1}", setStr, wherestr);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sqlStr.ToString()) > 0;
        }

        /// <summary>
        /// 获取待办事宜的状态
        /// </summary>
        /// <param name="worklistId">消息ID</param>
        /// <returns></returns>
        public int GetWorkListStatus(string worklistId)
        {
            var sqlStr = string.Format("SELECT State FROM CrmMessageWork WHERE Id='{0}'", worklistId);
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringWrite, CommandType.Text, sqlStr);
            if (obj != null)
                return int.Parse(obj.ToString());
            return -1;
        }


        /// <summary>
        /// 获取流程的2个节点的代办
        /// </summary>
        /// <param name="FlowName">流程名称</param>
        /// <param name="beginActivity">开始节点名称</param>
        /// <param name="endActivity">结束节点名称</param>
        /// <returns></returns>
        public List<CrmMessageWorkEntity> GetWorkListByHandTime(HandTimeSearch searchModel)
        {
            try
            {
                var MessageWorkList = new List<CrmMessageWorkEntity>();
                if (string.IsNullOrEmpty(searchModel.BeginActivity) || string.IsNullOrEmpty(searchModel.EndActivity))
                    return MessageWorkList;
                var sqlStr = string.Format(@"SELECT CM.*,LM.Area CompanyId FROM CRMMESSAGEWORK CM LEFT JOIN  FE_ACTIVITY FA ON FA.ACTIVITYID=CM.ACTIVITYINSTANCEID LEFT JOIN FE_PROCESS FP ON FP.PROCESSID=FA.PROCESSID
LEFT JOIN LicenseMain LM ON LM.Id= CM.FormID
WHERE CM.ROWSTATUS=1 AND FA.ROWSTATUS=1 AND FP.ROWSTATUS=1
AND (FA.NONENAME='{0}' OR FA.NONENAME='{1}')
AND ISREPLY=0 AND CM.[STATE]=2", searchModel.BeginActivity, searchModel.EndActivity);
                if (!string.IsNullOrEmpty(searchModel.FlowName))
                {
                    sqlStr += string.Format(" AND FP.FLOWNAME='{0}'", searchModel.FlowName);
                }
                else
                {
                    sqlStr += " AND FP.FLOWNAME IN('店招标牌批文','临时占道批文','大型户外广告批文')";
                }
                if (searchModel.BeginTime != default(DateTime))
                {
                    sqlStr += string.Format(" AND CM.CREATEON>='{0}'", searchModel.BeginTime.ToString(AppConst.DateFormat));
                }
                if (searchModel.EndTime != default(DateTime))
                {
                    sqlStr += string.Format(" AND CM.CREATEON<='{0} 23:59:59'", searchModel.EndTime.ToString(AppConst.DateFormat));
                }
                sqlStr += " ORDER BY CM.CREATEON";
                MessageWorkList = DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringWrite, CommandType.Text, sqlStr).Tables[0]);
                return MessageWorkList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 通过待办主键获取流程名称
        /// </summary>
        /// <param name="workListId">待办主键</param>
        /// <returns></returns>
        public string GetFlowName(string workListId)
        {
            var sqlStr = string.Format(@"SELECT P.FULLNAME FROM CRMMESSAGEWORK C LEFT JOIN WF_PROCESSINSTANCE W ON C.PROCESSINSTANCEID=W.ID
LEFT JOIN WF_PROCESS P ON P.ID=W.PROCESSID
WHERE C.ID='{0}'", workListId);
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringWrite, CommandType.Text, sqlStr);
            if (obj != null)
                return obj.ToString();
            else
                return string.Empty;
        }


        /// <summary>
        /// 获取所有许可待办
        /// </summary>
        /// <returns></returns>
        public List<CrmMessageWorkEntity> GetWorkListByLicense()
        {
            var sqlStr = @"SELECT CM.*,LM.Area CompanyId FROM CRMMESSAGEWORK CM
INNER JOIN LicenseMain LM ON LM.Id= CM.FormID ORDER BY CM.CreateOn";
            var messageWorkList = DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringWrite, CommandType.Text, sqlStr).Tables[0]);
            return messageWorkList;
        }

        public List<CrmMessageWorkEntity> SearchDeptListCount(CrmMessageWorkEntity pe)
        {
            var sqlStr = @"select * from CrmMessageWork where sendactivityid = '" + pe.SendActivityID + "' and formid = '" + pe.FormID + "'";
            if (!string.IsNullOrEmpty(pe.ActionerID))
            {
                sqlStr += "and actionerid =  '" + pe.ActionerID + "'";
            }
            var messageWorkList = DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringWrite, CommandType.Text, sqlStr).Tables[0]);
            return messageWorkList;
        }

        public bool IsCB(CrmMessageWorkEntity pe)
        {
            var sqlStr = @"select * from CrmMessageWork where formid = '" + pe.FormID + "' and SendActivityID = '1' and ActivityInstanceID is not null and ActivityInstanceID <> '' ";
            var messageWorkList = DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringWrite, CommandType.Text, sqlStr).Tables[0]);
            if (messageWorkList.Count > 0)
            {
                return true;
            }
            return false;
        }

        public List<CrmMessageWorkEntity> MessworkList(string FormID, string SendActivityID)
        {
            string parm = "";
            if (!string.IsNullOrEmpty(SendActivityID))
            {
                parm = "and SendActivityID = ''";
            }

            var sqlStr = @"select * from CrmMessageWork where formid = '" + FormID + "'  " + parm + "  order by createon desc ";
            var messageWorkList = DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringWrite, CommandType.Text, sqlStr).Tables[0]);
            return messageWorkList;
        }

        /// <summary>
        /// 获取最大Note值
        /// </summary>
        /// <param name="NoteCount"></param>
        /// <returns></returns>
        public int GetMaxNoteCount(string FormID)
        {
            var sqlStr = @"select max(note) from CrmMessageWork where formid = '" + FormID + "' ";
            DataTable messageWorkList = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringWrite, CommandType.Text, sqlStr).Tables[0];
            return messageWorkList.Rows[0][0].ToString() == "" ? 0 : int.Parse(messageWorkList.Rows[0][0].ToString());
        }

        /// <summary>
        /// 获取发送人
        /// </summary>
        /// <param name="Note"></param>
        /// <returns></returns>
        public string GetMaxNoteSendId(string Note)
        {
            var sqlStr = @"select SenderId from CrmMessageWork where note = '" + Note + "' ";
            DataTable messageWorkList = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringWrite, CommandType.Text, sqlStr).Tables[0];
            return messageWorkList.Rows[0][0].ToString();
        }

        /// <summary>
        /// 变更Note
        /// </summary>
        /// <param name="Note"></param>
        /// <returns></returns>
        public void UpdateNote(string FormId)
        {
            var sqlStr = @"update crmmessagework set note = '' where Formid = '" + FormId + "' ";
            SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, sqlStr);
        }

        /// <summary>
        /// 判断一个案件的第几个流程是否开启
        /// </summary>
        /// <param name="FormId">案件主键</param>
        /// <returns></returns>
        public int GetIsOpen(string FormId)
        {
            var sqlStr = string.Format("SELECT COUNT(*) FROM (SELECT COUNT(*) NUMBER FROM CRMMESSAGEWORK WHERE FORMID='{0}'  GROUP BY CONTENTTYPEID) AS T", FormId);
            return (int)SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sqlStr);
        }
    }
}

