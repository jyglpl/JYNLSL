using System.IO;
using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey;
using Yookey.WisdomClassed.SIP.Common;

namespace Yookey.WisdomClassed.SIP.DataAccess.Mobile
{
    /// <summary>
    /// 事部件
    /// </summary>
    public class DsfxcDal
    {
        public object Obj = new object();

        /// <summary>
        /// 获取所有的事部件类型
        /// 添加人：周 鹏
        /// 添加时间：2015-03-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-08-06 周 鹏 增加父编号
        /// </history>
        /// <param name="parentId">父编号</param>
        /// <returns></returns>
        public DataTable GetCaseType(string parentId = "")
        {
            var strSql = string.Format("SELECT * FROM V_CaseType WHERE 1=1 ");
            if (!string.IsNullOrEmpty(parentId))
            {
                strSql += string.Format(" AND parentid='{0}'", parentId);
            }
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcRead, CommandType.Text, strSql).Tables[0];
        }

        /// <summary>
        /// 获取所有待办【未回复】的事部件
        /// 添加人：周 鹏
        /// 添加时间：2015-03-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-04-16 周 鹏 增加查询条件、排序
        ///           2015-06-11 周 鹏 增加总条数据返回
        ///           2015-06-19 周 鹏 修改Sql可对处理完后重新派遣的数据查询
        ///           2017-04-18 周 鹏 增加检验当前登录用户是否是中队通用账号，如是通用账号只查市局的案件
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="deptId">部门编号</param>
        /// <param name="emergency">紧急程序</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页请求条数</param>
        /// <param name="caseClassI">大类</param>
        /// <param name="caseClassIi">小类</param>
        /// <param name="timeType">时间类型：本日 day、本周 week、所有 all、自定义 user-defined</param>
        /// <param name="startTime">自定义开始时间</param>
        /// <param name="endTime">自定义截止时间</param>
        /// <param name="totalRecords">总条数</param>
        /// <param name="orderType">排序方式</param>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns> Columns->
        /// ProblemNo  单号
        /// CaseClassI 大类
        /// CaseClassII 小类
        /// ReportCaseDesc 问题描述
        /// ReportAddress  上报地址
        /// ReportTime  上报时间
        /// </returns>
        public DataTable GetTask(string userId, string deptId, string caseClassI, string caseClassIi, string timeType,
            string startTime, string endTime, string emergency, int pageIndex, int pageSize, out int totalRecords, string orderType = "DESC")
        {

            var strSql = new StringBuilder("");      //查询数据明细
            var strCountSql = new StringBuilder(""); //查询总条数

            var strTemp = new StringBuilder("");     //拼接Sql


            #region 2017-04-18 周 鹏 增加检验当前登录用户是否是中队通用账号

            var checkUserSql = new StringBuilder("");
            checkUserSql.AppendFormat(@"SELECT Account,RealName,r.Code,r.FullName 
FROM JCXXDB.dbo.Base_User u,JCXXDB.dbo.Base_Roles r,JCXXDB.dbo.Base_ObjectUserRelation ur
WHERE u.UserId = ur.UserId and ur.ObjectId = r.RoleId and u.Code LIKE 'ddzh_%' AND u.UserId='{0}'", userId);

            var checkUserDt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, checkUserSql.ToString()).Tables[0];

            #endregion

            if (string.IsNullOrEmpty(deptId))
            {
                strTemp.AppendFormat(
                   @"SELECT DBC.ProblemNo,DBC.CaseType,DBC.CaseClassI,DBC.CaseClassII,DBC.CaseClassIII,DBC.ReportCaseDesc,DBC.ReportAddress,CONVERT(VARCHAR(16),DBC.ReportTime,25) AS ReportTime,DBC.ApplyStatus,NewCase,EndLimit FROM V_DaiBanCase_Distinct AS DBC
LEFT JOIN WisdomClassed_SZYQOverall.dbo.DsfxcAccept AS DA ON DBC.ProblemNo=DA.ProblemNo
WHERE (DBC.SendToUserId='{0}' OR DA.SendToUserID='{0}') AND DA.ProblemNo IS NULL", userId);

                //如果是通用账号只查“市局”的单子
                if (checkUserDt != null && checkUserDt.Rows.Count > 0)
                {
                    strTemp.AppendFormat(@" AND DBC.Sono<>'' ");
                }
                else
                {
                    strTemp.AppendFormat(@" AND DBC.Sono='' ");
                }

                //增加分页
                strSql.AppendFormat(
                    @"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY NewCase,EndLimit) AS RowId,* FROM ({2}) AS TB ) AS SP WHERE RowId BETWEEN {0} AND {1}",
                    (pageIndex - 1) * pageSize + 1, pageIndex * pageSize, strTemp);
            }
            else
            {
                strSql.AppendFormat("SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY NewCase,EndLimit {0}) AS RowId,* FROM ( ", orderType);

                strTemp.AppendFormat(@"SELECT DBC.ProblemNo,DBC.CaseType,DBC.CaseClassI,DBC.CaseClassII,DBC.CaseClassIII,DBC.ReportCaseDesc,DBC.ReportAddress,CONVERT(VARCHAR(16),DBC.ReportTime,25) AS ReportTime,DBC.ApplyStatus,DBC.EndTimeStatus,NewCase,EndLimit FROM V_DaiBanCase_Distinct AS DBC
LEFT JOIN WisdomClassed_SZYQOverall.dbo.DsfxcAccept AS DA ON DBC.ProblemNo=DA.ProblemNo AND DA.ProblemState=0
WHERE (DBC.DepartmentGUID='{0}') AND (DA.ProblemNo IS NULL) ", deptId);


                //如果是通用账号只查“市局”的单子
                if (checkUserDt != null && checkUserDt.Rows.Count > 0)
                {
                    strTemp.AppendFormat(@" AND DBC.Sono<>'' ");
                }
                else
                {
                    strTemp.AppendFormat(@" AND DBC.Sono='' ");
                }

                if (!string.IsNullOrEmpty(caseClassI))   //大类
                {
                    strTemp.AppendFormat(" AND DBC.CaseClassI='{0}'", caseClassI);
                }
                if (!string.IsNullOrEmpty(caseClassIi))  //小类
                {
                    strTemp.AppendFormat(" AND DBC.CaseClassII='{0}'", caseClassIi);
                }

                if (!string.IsNullOrEmpty(timeType) && !timeType.Equals("all"))   //时间
                {
                    switch (timeType)
                    {
                        case "day":     //今日
                            strTemp.Append(" AND DATEDIFF(DAY,DBC.ReportTime,GETDATE())=0");
                            break;
                        case "week":    //本周
                            strTemp.Append(" AND DATEDIFF(WEEK,DBC.ReportTime,GETDATE())=0");
                            break;
                        case "user-defined":   //自定义
                            {
                                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                                {
                                    strTemp.AppendFormat(" AND DBC.ReportTime>'{0}' AND DBC.ReportTime<='{1} 23:59:59.999'", startTime, endTime);
                                }
                                else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
                                {
                                    strTemp.AppendFormat(" AND DBC.ReportTime>'{0}'", startTime);
                                }
                                else if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                                {
                                    strTemp.AppendFormat(" AND DBC.ReportTime<='{0} 23:59:59.999'", endTime);
                                }
                            }
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(emergency))  //紧急程度
                {
                    strTemp.AppendFormat(" AND DBC.Emergency='{0}''", emergency);
                }
                strSql.AppendFormat("{0} ) AS TB ) AS SP WHERE RowId BETWEEN {1} AND {2}", strTemp, (pageIndex - 1) * pageSize + 1, pageIndex * pageSize);
            }

            strCountSql.AppendFormat("SELECT COUNT(*) FROM ({0}) AS TB", strTemp);

            //数据总条数
            totalRecords = int.Parse(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringDsfxcRead, CommandType.Text, strCountSql.ToString()).ToString());
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 查看事部件详情
        /// 添加人：周 鹏
        /// 添加时间：2015-03-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-06-10 周 鹏 增加请求网络段判断
        /// </history>
        /// <param name="problemNo">单号</param>
        /// <param name="netWork">请求网络的段（内、外网）</param>
        /// <returns></returns>
        public DataTable GetTaskDetails(string problemNo, CommonMethod.NetWorkEnum netWork)
        {
            var filePath = "FilePath";
            switch (netWork)
            {
                case CommonMethod.NetWorkEnum.Intranet:   //内网
                    filePath = "FilePath";
                    break;
                case CommonMethod.NetWorkEnum.OutNet:     //外网
                    filePath = "FilePath_Public";
                    break;
            }

            var strSql = string.Format(@"SELECT TOP 1 ProblemNo,Reporter,ReporterTel,ProblemOrigin,ReportWay,CaseType,
CaseClassI,CaseClassII,CaseClassIII,CurrentStage,SendTo,SendToUserID,SendToGUID,DepartmentName,DepartmentGUID,ReportCaseDesc,ReportAddress,
CONVERT(VARCHAR(16),ReportTime,25) AS ReportTime,{0} AS FilePath,CmdID,Emergency,X,Y,ApplyStatus,CONVERT(VARCHAR(16),EndTime,25) AS EndTime,CONVERT(VARCHAR(16),RefuseTime,25) AS RefuseTime,CmdContent FROM V_DaiBanCase_Distinct WHERE ProblemNo='{1}'", filePath, problemNo);
            var detailsDt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcRead, CommandType.Text, strSql).Tables[0];

            if (detailsDt == null || detailsDt.Rows.Count <= 0)
            {
                strSql = string.Format(@"SELECT ProblemNo,Reporter,ReporterTel,ProblemOrigin,ReportWay,CaseType,
CaseClassI,CaseClassII,CaseClassIII,CurrentStage,SendTo,SendToUserID,SendToGUID,DepartmentName,DepartmentGUID,ReportCaseDesc,ReportAddress,
CONVERT(VARCHAR(16),ReportTime,25) AS ReportTime,{0} AS FilePath,CmdID,Emergency,X,Y,''AS ApplyStatus,CONVERT(VARCHAR(16),EndTime,25) AS EndTime,CONVERT(VARCHAR(16),RefuseTime,25) AS RefuseTime,CmdContent FROM DsfxcAccept WHERE ProblemNo='{1}'", filePath, problemNo);
                detailsDt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            }
            return detailsDt;
        }

        /// <summary>
        /// 事件问题上报
        /// 添加人：周 鹏
        /// 添加时间：2015-03-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-04-16 周 鹏 增加立案条件、紧急程序
        /// </history>
        /// <param name="dsfxcId">上报问题ID</param>
        /// <param name="reporterId">上报人编号</param>
        /// <param name="reporter">报告人</param>
        /// <param name="phone">市民联系电话</param>
        /// <param name="desc">问题的描述</param>
        /// <param name="address">位置描述</param>
        /// <param name="caseType">案件类型（上传编码0601 0602）</param>
        /// <param name="caseTypeDesc">类型描述</param>
        /// <param name="caseClassi">事件大类（上传编码 ，如上传01、02等）</param>
        /// <param name="caseClassiDesc">大类描述</param>
        /// <param name="caseClassii">事件小类（上传编码取代汉字，如上传0101、0201等）</param>
        /// <param name="caseClassiiDesc">小类描述</param>
        /// <param name="caseClassiii">事件子类（上传编码取代汉字，如上传010101、020101等）</param>
        /// <param name="caseClassiiiDesc">子类描述</param>
        /// <param name="lng">位置经度，无值为""</param>
        /// <param name="lat">位置纬度 ，无值为""</param>
        /// <param name="attachment">附件地址</param>
        /// <param name="caseCondition">立案条件</param>
        /// <param name="caseConditionDesc">立案条件描述</param>
        /// <param name="emergency">紧急程序</param>
        /// <returns></returns>
        public bool ReportProblem(string dsfxcId, string reporterId, string reporter, string phone, string desc, string address, string caseType,
            string caseTypeDesc, string caseClassi, string caseClassiDesc, string caseClassii, string caseClassiiDesc, string caseClassiii,
            string caseClassiiiDesc, string lng, string lat, string attachment, string caseCondition, string caseConditionDesc, string emergency)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"EXEC CGZF_reportEvent @reporter = N'{0}',@phone = N'{1}',
                @desc = N'{2}',@address = N'{3}',@caseType = N'{4}',@caseClassI = N'{5}',@caseClassII = N'{6}',@caseClassIII = N'{7}',
                @log = N'{8}',@lat = N'{9}',@attachment = N'{10}',@CaseCondition='{11}',@Emergency='{12}'", reporter, phone, desc, address, caseType, caseClassi, caseClassii, caseClassiii, lng, lat, attachment, caseCondition, emergency);

                SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringDsfxcWrite, CommandType.Text, strSql.ToString());
                var saveSql = new StringBuilder("");
                saveSql.AppendFormat(@"INSERT INTO DsfxcReport (Id,Reporter,Phone,[Desc],[Address],CaseType,CaseTypeDesc,CaseClassI,CaseClassIDesc,CaseClassII,CaseClassIIDesc,CaseClassIII,CaseClassIIIDesc,Lng,Lat,Attachment,CaseCondition,CaseConditionDesc,Emergency,[Version],CreatorId,CreateBy,CreateOn,UpdateId,UpdateBy,UpdateOn) 
VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}',NULL,'{19}','{20}',GETDATE(),'{21}','{22}',GETDATE())",
                  dsfxcId, reporter, phone, desc, address, caseType, caseTypeDesc, caseClassi, caseClassiDesc, caseClassii, caseClassiiDesc, caseClassiii, caseClassiiiDesc, lng, lat, attachment, caseCondition, caseConditionDesc, emergency, reporterId, reporter, reporterId, reporter);

                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, saveSql.ToString()) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 事件回复处理
        /// 添加人：周 鹏
        /// 添加时间：2015-03-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="problemNo">问题编号</param>
        /// <param name="staffID">处理部门guid</param>
        /// <param name="dealTime">处理时间</param>
        /// <param name="dealComment">处理意见</param>
        /// <param name="filePath">附件地址</param>
        /// <param name="cmdID">处理指令ID</param>
        /// <returns></returns>
        public bool HandleProblem(string problemNo, string staffID, string dealTime, string dealComment, string filePath, string cmdID)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"EXEC CGZF_CaseInfo_DealRecord @problemNo = '{0}',
                                                @staffID = '{1}',@dealTime = '{2}',@dealComment = '{3}',@filePath = '{4}',@cmdID = '{5}'", problemNo, staffID, dealTime, dealComment, filePath, cmdID);

                var data = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcWrite, CommandType.Text, strSql.ToString()).Tables[0];
                if (data != null && data.Rows.Count > 0)
                {
                    if (data.Rows[0]["RS"].ToString().Equals("1"))
                    {
                        var upSql = new StringBuilder("");
                        upSql.AppendFormat(@"UPDATE DsfxcAccept SET ProblemState=1,DealTime=GETDATE(),DealComment='{0}',HandleFilePath='{1}' WHERE ProblemNo='{2}' AND ProblemState=0", dealComment, filePath, problemNo);
                        return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, upSql.ToString()) > 0;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 两小时处理回复
        /// 添加人：周 鹏
        /// 添加时间：2018-07-31
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="problemNo">问题编号</param>
        /// <param name="staffID">处理部门guid</param>
        /// <param name="dealTime">处理时间</param>
        /// <param name="dealComment">处理意见</param>
        /// <param name="filePath">附件地址</param>
        /// <param name="cmdID">处理指令ID</param>
        /// <returns></returns>
        public string TwoHourReply(string problemNo, string staffID, string dealTime, string dealComment, string filePath, string cmdID, string fileName, string userId)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"EXEC CGZF_WF_City_TwoHourReply '{0}','{1}','{2}','{3}','{4}'", problemNo, dealComment, userId, filePath, fileName);
                
                var data = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcWrite, CommandType.Text, strSql.ToString()).Tables[0];
                if (data != null && data.Rows.Count > 0)
                {
                    if (data.Rows[0]["RS"].ToString().Equals("1"))
                    {
                        return "执行成功";
                    }
                    else if (data.Rows[0]["RS"].ToString().Equals("0"))
                    {
                        return "不是两小时回复案件";
                    }
                }
                return "执行过程出现异常！";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 事部件问题的接收
        /// 添加人：周 鹏
        /// 添加时间：2015-03-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-06-03 周 鹏 接收增加截止时间、拒签时间、派遣意见
        ///           2015-06-10 周 鹏 接收增加公网IP
        /// </history>
        /// <param name="problemNo">问题编号</param>
        /// <param name="userId">接收人ID</param>
        /// <param name="userName">接收人姓名</param>
        /// <returns></returns>
        public bool ProblemAccept(string problemNo, string userId, string userName)
        {
            try
            {
                lock (Obj)
                {
                    var strCheckSql = string.Format(@"SELECT COUNT(*) FROM DsfxcAccept WHERE ProblemNo='{0}' AND ProblemState=0", problemNo);
                    var objCount = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strCheckSql);

                    //验证该问题是否已经被接收
                    if (objCount != null && Convert.ToInt32(objCount) == 0)
                    {
                        var problemDetailsSql = string.Format(@"SELECT * FROM V_DaiBanCase_Distinct WHERE ProblemNo='{0}'", problemNo);
                        var detailsDt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcRead, CommandType.Text, problemDetailsSql)
                                 .Tables[0];

                        if (detailsDt != null && detailsDt.Rows.Count > 0)
                        {
                            var detailRow = detailsDt.Rows[0];

                            var strSql = new StringBuilder("");
                            strSql.AppendFormat(@"INSERT INTO DsfxcAccept (ProblemNo,Reporter,ReporterTel,ProblemOrigin,ReportWay,CaseType,CaseClassI,
CaseClassII,CaseClassIII,CurrentStage,SendTo,SendToUserID,SendToGUID,DepartmentName,DepartmentGUID,ReportCaseDesc,ReportAddress,ReportTime,FilePath,FilePath_Public,
CmdID,X,Y,EndTime,RefuseTime,CmdContent,AcceptId,AcceptUserName,AcceptTime,Emergency) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}',GETDATE(),'{28}')",
detailRow["ProblemNo"],
detailRow["Reporter"],
detailRow["ReporterTel"],
detailRow["ProblemOrigin"],
detailRow["ReportWay"],
detailRow["CaseType"],
detailRow["CaseClassI"],
detailRow["CaseClassII"],
detailRow["CaseClassIII"],
detailRow["CurrentStage"],
detailRow["SendTo"],
detailRow["SendToUserID"],
detailRow["SendToGUID"],
detailRow["DepartmentName"],
detailRow["DepartmentGUID"],
detailRow["ReportCaseDesc"].ToString().Replace("'", ""),
detailRow["ReportAddress"].ToString().Replace("'", ""),
detailRow["ReportTime"],
detailRow["FilePath"], detailRow["FilePath_Public"], detailRow["CmdID"], detailRow["X"], detailRow["Y"], detailRow["EndTime"], detailRow["RefuseTime"], detailRow["CmdContent"], userId, userName, detailRow["Emergency"]);

                            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql.ToString()) > 0;

                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return false;
        }

        /// <summary>
        /// 查询个人接收的事件
        /// 添加人：周 鹏
        /// 添加时间：2015-03-06
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-06-11 周 鹏 增加总条数据返回
        /// </history>
        /// <param name="userId">接收人员编号</param>
        /// <param name="emergency">紧急程序</param>
        /// <param name="stateType">状态类型：0 接收 1：回复处理</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页请求的条数</param>
        /// <param name="caseClassI">大类</param>
        /// <param name="caseClassIi">小类</param>
        /// <param name="timeType">时间类型：本日 day、本周 week、所有 all、自定义 user-defined</param>
        /// <param name="startTime">自定义开始时间</param>
        /// <param name="endTime">自定义截止时间</param>
        /// <param name="totalRecords">总条数</param>
        /// <param name="orderType">排序方式</param>
        /// <returns></returns>
        public DataTable GetMineTask(string userId, string caseClassI, string caseClassIi, string timeType,
            string startTime, string endTime, string emergency, int? stateType, int pageIndex, int pageSize, out int totalRecords, string orderType = "DESC")
        {
            try
            {
                var strSql = new StringBuilder("");
                //strSql.AppendFormat("SELECT ProblemNo,CaseClassI,CaseClassII,ReportCaseDesc,ReportAddress,CONVERT(VARCHAR(16),ReportTime,25) AS ReportTime,AcceptTime FROM DsfxcAccept AS DA WHERE DA.AcceptId='{0}' AND DA.ProblemState={1}", userId, stateType ?? 0);

                stateType = stateType ?? 0;
                if (stateType == 0)
                {
                    strSql.AppendFormat(
                        @"SELECT DA.ProblemNo,DA.CaseClassI,DA.CaseClassII,DA.ReportCaseDesc,DA.ReportAddress,CONVERT(VARCHAR(16),DA.ReportTime,25) AS ReportTime,DA.AcceptTime,VD.ApplyStatus,VD.EndTimeStatus
FROM DsfxcAccept AS DA WITH(NOLOCK)
INNER JOIN DSFXC.dbo.V_DaiBanCase_Distinct AS VD ON VD.ProblemNo=DA.ProblemNo WHERE DA.AcceptId='{0}' AND DA.ProblemState={1}", userId, stateType ?? 0);

                }
                else
                {
                    strSql.AppendFormat(
                            @"SELECT DA.ProblemNo,DA.CaseClassI,DA.CaseClassII,DA.ReportCaseDesc,DA.ReportAddress,CONVERT(VARCHAR(16),DA.ReportTime,25) AS ReportTime,DA.AcceptTime,'' AS ApplyStatus,0 AS EndTimeStatus
FROM DsfxcAccept AS DA WHERE DA.AcceptId='{0}' AND DA.ProblemState={1}", userId, stateType ?? 0);
                }

                if (!string.IsNullOrEmpty(caseClassI))   //大类
                {
                    strSql.AppendFormat(" AND DA.CaseClassI='{0}'", caseClassI);
                }
                if (!string.IsNullOrEmpty(caseClassIi))  //小类
                {
                    strSql.AppendFormat(" AND DA.CaseClassII='{0}'", caseClassIi);
                }

                if (!string.IsNullOrEmpty(timeType) && !timeType.Equals("all"))   //时间
                {
                    switch (timeType)
                    {
                        case "day":     //今日
                            strSql.Append(" AND DATEDIFF(DAY,DA.ReportTime,GETDATE())=0");
                            break;
                        case "week":    //本周
                            strSql.Append(" AND DATEDIFF(WEEK,DA.ReportTime,GETDATE())=0");
                            break;
                        case "user-defined":   //自定义
                            {
                                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                                {
                                    strSql.AppendFormat(" AND DA.ReportTime>'{0}' AND DA.ReportTime<='{1} 23:59:59.999'", startTime, endTime);
                                }
                                else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
                                {
                                    strSql.AppendFormat(" AND DA.ReportTime>'{0}'", startTime);
                                }
                                else if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                                {
                                    strSql.AppendFormat(" AND DA.ReportTime<='{0} 23:59:59.999'", endTime);
                                }
                            }
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(emergency))  //紧急程度
                {
                    strSql.AppendFormat(" AND DA.Emergency='{0}''", emergency);
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "AcceptTime", orderType, pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 案件退回
        /// 添加人：周 鹏
        /// 添加时间：2015-04-09
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">处理人员</param>
        /// <param name="problemNo">案件编号</param>
        /// <param name="dealContent">处理人员意见</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TaskBack(string userId, string problemNo, string dealContent)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"EXEC CGZF_CancelCmd @ProblemNo='{0}',@DealStaff='{1}',@DealContent='{2}'", problemNo, userId, dealContent);
                SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringDsfxcWrite, CommandType.Text, strSql.ToString());

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取立案条件
        /// 添加人：周 鹏
        /// 添加时间：2015-04-16
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseClassI">大类</param>
        /// <param name="caseClassIi">小类</param>
        /// <returns>DataTable.</returns>
        public DataTable GetCaseCondition(string caseClassI, string caseClassIi)
        {
            try
            {
                var strSql = string.Format(@"EXEC CGZF_GetCaseCondition '{0}','{1}'", caseClassI, caseClassIi);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcWrite, CommandType.Text, strSql).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据问题编号查询问题接收人
        /// 添加人：周 鹏
        /// 添加时间：2015-05-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="problemNo">问题编号</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        public string GetAcceptIdByProblemNo(string problemNo)
        {
            try
            {
                var strSql = string.Format(@"SELECT AcceptId FROM dbo.DsfxcAccept WHERE ProblemNo='{0}'", problemNo);
                var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["AcceptId"].ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 申请拒签
        /// 添加人：周 鹏
        /// 添加时间：2015-06-01
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">处理人员</param>
        /// <param name="problemNo">案件编号</param>
        /// <param name="dealContent">处理人员意见</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TaskApplyRefuse(string userId, string problemNo, string dealContent)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"EXEC CGZF_Apply_Refuse @ProblemNo='{0}',@DealStaff='{1}',@DealContent='{2}'", problemNo, userId, dealContent);
                SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringDsfxcWrite, CommandType.Text, strSql.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取申请拒签信息
        /// 添加人：周 鹏
        /// 添加时间：2015-06-01
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">UserId</param>
        /// <param name="problemNo">问题编号</param>
        /// <returns>DataTable</returns>
        public DataTable TaskGetApplyRefuse(string userId, string problemNo)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"EXEC CGZF_GetApply_Refuse @userid='{0}',@problemNo='{1}'", userId, problemNo);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcWrite, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 申请延时
        /// 添加人：周 鹏
        /// 添加时间：2015-06-01
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">处理人员</param>
        /// <param name="problemNo">案件编号</param>
        /// <param name="dealContent">处理人员意见</param>
        /// <param name="applyAsk">申请天数</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TaskApplyDelay(string userId, string problemNo, string dealContent, int applyAsk)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"EXEC CGZF_Apply_Delay @ProblemNo='{0}',@DealStaff='{1}',@applyDesc='{2}',@applyAsk={3}", problemNo, userId, dealContent, applyAsk);
                SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringDsfxcWrite, CommandType.Text, strSql.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取申请拒签信息
        /// 添加人：周 鹏
        /// 添加时间：2015-06-01
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">UserId</param>
        /// <param name="problemNo">问题编号</param>
        /// <returns>DataTable</returns>
        public DataTable TaskGetApplyDelay(string userId, string problemNo)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"EXEC CGZF_GetApply_Delay @userid='{0}',@problemNo='{1}'", userId, problemNo);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcWrite, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 申请缓办
        /// 添加人：周 鹏
        /// 添加时间：2015-06-01
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">处理人员</param>
        /// <param name="problemNo">案件编号</param>
        /// <param name="dealContent">处理人员意见</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TaskApplyPostPone(string userId, string problemNo, string dealContent)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"EXEC CGZF_Apply_PostPone @ProblemNo='{0}',@DealStaff='{1}',@DealContent='{2}'", problemNo, userId, dealContent);
                SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringDsfxcWrite, CommandType.Text, strSql.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取申请缓办信息
        /// 添加人：周 鹏
        /// 添加时间：2015-06-01
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">UserId</param>
        /// <param name="problemNo">问题编号</param>
        /// <returns>DataTable</returns>
        public DataTable TaskGetApplyPostPone(string userId, string problemNo)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"EXEC CGZF_GetApply_PostPone @userid='{0}',@problemNo='{1}'", userId, problemNo);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcWrite, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取上传GPS坐标参数信息
        /// 添加人：周 鹏
        /// 添加时间：2015-07-08
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable GetServerParams()
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"EXEC CGZF_GetServiceParams");
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcWrite, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 根据部门、时间段统计事件数据
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable DsfxcStatistics(string departmentId, string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT UserId,(SELECT COUNT(*) FROM [dbo].[DsfxcReport] WHERE CreateOn>='{0}' AND CreateOn<='{1} 23:59:59' AND CreatorId=UserId) AS SBCNT,
(SELECT COUNT(*) AS CLCNT FROM [dbo].[DsfxcAccept] WHERE DealTime>='{0}' AND DealTime<='{1} 23:59:59' AND AcceptId=UserId) AS CLCNT
FROM JCXXDB.[dbo].[Base_User] WHERE DepartmentId='{2}'", startTime, endTime, departmentId);


                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}