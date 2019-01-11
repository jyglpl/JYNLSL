//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CAR_CHECKSIGNDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/22 16:26:18
//  功能描述：INF_CAR_CHECKSIGN数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using Yookey;
using System;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Case;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// 违章停车数据访问操作
    /// </summary>
    public class InfCarChecksignDal : DalImp.BaseDal<InfCarChecksignEntity>
    {
        public InfCarChecksignDal()
        {
            Model = new InfCarChecksignEntity();
        }

        public List<InfCarChecksignEntity> GetCommonQury(string caseWhere, string carWhere, int pageIndex, int pageSzie, out int totalRecord)
        {
            try
            {
                var parameters = new SqlParameter[]
                    {
                        
                        new SqlParameter("@ReFieldsStr", SqlDbType.VarChar, 200),
                        new SqlParameter("@OrderString", SqlDbType.VarChar, 200), 
                        new SqlParameter("@WhereCase", SqlDbType.VarChar, 2000),
                        new SqlParameter("@WhereCar", SqlDbType.VarChar, 2000),
                        new SqlParameter("@PageSize", SqlDbType.Int),
                        new SqlParameter("@PageIndex", SqlDbType.Int)
                    };
                parameters[0].Value = "";
                parameters[1].Value = "";
                parameters[2].Value = caseWhere;
                parameters[3].Value = carWhere;
                parameters[4].Value = pageSzie;
                parameters[5].Value = pageIndex;

                var ds = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.StoredProcedure, "PROC_SZYQ_QUERY", parameters);
                totalRecord = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                var result = DataTableToList(ds.Tables[0]);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public override List<InfCarChecksignEntity> DataTableToList(DataTable dt)
        {
            return (from DataRow dr in dt.Rows select Model.SetModelValueByDataRow(dr, new List<string>() { "Id", "CheckSignNo", "TypeNo", "CarNo", "CheckDate", "Address" })).ToList();
        }


        /// <summary>
        /// 查询没有二级审批过的数据
        /// 添加人：周 鹏
        /// 添加时间：2015-04-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <param name="qType">查询类型：未审批、作废审批</param>
        /// <returns></returns>
        public DataTable GetSearchResult(CarList search, string qType)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT ICC.Id,CarNo,CheckDate FROM INF_CAR_CHECKSIGN AS ICC WITH(NOLOCK)
INNER JOIN CrmDepartment AS CD WITH(NOLOCK) ON ICC.DeptId=CD.Id
INNER JOIN CrmCompany AS CC WITH(NOLOCK) ON CC.Id=CD.CompanyId
WHERE ICC.RowStatus=1");

            if (!search.CompanyId.Equals("all"))
            {
                strSql.AppendFormat(" AND CC.Id ='{0}'", search.CompanyId);
            }
            if (!string.IsNullOrEmpty(search.DeptId) && !search.DeptId.Equals("all"))
            {
                strSql.AppendFormat(" AND CD.Id ='{0}'", search.DeptId);
            }

            if (!string.IsNullOrEmpty(search.CarNo))
            {
                strSql.AppendFormat(" AND CarNo LIKE '%{0}%'", search.CarNo);
            }

            if (string.IsNullOrEmpty(qType))
            {
                if (!string.IsNullOrEmpty(search.State))
                {
                    if (search.State == "2")
                    {
                        strSql.AppendFormat(" AND (ICC.Isaudit = '2' OR ICC.Isaudit = '-1')");
                    }
                    else
                    {
                        strSql.AppendFormat(" AND ICC.Isaudit = '{0}'", search.State);
                    }
                }
                else
                {
                    strSql.Append(" AND (Isaudit=0 OR Isaudit=3)");   //未审批、作废申请未通过的数据
                }

                strSql.Append(" AND State=0 ");
            }
            if (!string.IsNullOrEmpty(qType) && qType.Equals("Invalid"))
            {
                strSql.Append(" AND Isaudit=2");   //作废待审批的数据
            }
            if (!string.IsNullOrEmpty(search.StartDate) && !string.IsNullOrEmpty(search.EndDate))
            {
                strSql.AppendFormat(" AND ICC.CheckDate>='{0}' AND ICC.CheckDate<='{1} 23:59:59'", search.StartDate, search.EndDate);
            }
            if (!string.IsNullOrEmpty(search.StartDate) && string.IsNullOrEmpty(search.EndDate))
            {
                strSql.AppendFormat(" AND ICC.CheckDate>='{0}'", search.StartDate);
            }
            if (string.IsNullOrEmpty(search.StartDate) && !string.IsNullOrEmpty(search.EndDate))
            {
                strSql.AppendFormat(" AND ICC.CheckDate<='{0} 23:59:59'", search.EndDate);
            }

            strSql.Append("  ORDER BY CheckDate");
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString());
            return list.Tables[0];
        }


        /// <summary>
        /// 违章停车数据查询
        /// 添加人：周 鹏
        /// 添加时间：2015-04-07
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="carNo">车牌号码</param>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="state">查询状态</param>
        /// <param name="startDate">查询开始时间</param>
        /// <param name="endDate">查询截止时间</param>
        /// <param name="noticeNo">通知书编号</param>
        /// <param name="caseinfoNo">案件编号</param>
        /// <param name="address">地点</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns>System.String.</returns>
        public DataTable GetSearchResult(string carNo, string companyId, string deptId, string state, string startDate, string endDate, string noticeNo, string caseinfoNo, string address, int pageIndex, int pageSize, string sidx, string sord, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT ICC.Id,CarNo,NoticeNo,CheckSignAddress,CheckDate,DeptName,CR.RsKey AS [Status],CfapproveNo AS CaseInfoNo FROM INF_CAR_CHECKSIGN AS ICC WITH(NOLOCK)
JOIN CrmDepartment AS CD WITH(NOLOCK) ON ICC.DeptId=CD.Id
JOIN CrmCompany AS CC WITH(NOLOCK) ON CD.CompanyId=CC.Id
JOIN ComResource AS CR WITH(NOLOCK) ON ICC.[State]=CR.RsValue AND CR.ParentId='0021' WHERE ICC.RowStatus=1");

            if (!companyId.Equals("all"))
            {
                strSql.AppendFormat(@" AND CC.Id='{0}'", companyId);
            }
            if (!string.IsNullOrEmpty(deptId) && !deptId.Equals("all"))
            {
                strSql.AppendFormat(@" AND ICC.DeptId='{0}'", deptId);
            }
            if (!string.IsNullOrEmpty(carNo))
            {
                strSql.AppendFormat(@" AND ICC.CarNo LIKE '%{0}%'", carNo);
            }
            if (!string.IsNullOrEmpty(state))
            {
                strSql.AppendFormat(@" AND ICC.[State]={0}", state);
            }
            if (!string.IsNullOrEmpty(noticeNo))
            {
                strSql.AppendFormat(@" AND ICC.NoticeNo LIKE '%{0}%'", noticeNo);
            }
            if (!string.IsNullOrEmpty(caseinfoNo))
            {
                strSql.AppendFormat(" AND ICC.CfapproveNo LIKE '%{0}%'", caseinfoNo);
            }
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                strSql.AppendFormat(@" AND ICC.CheckDate>'{0}' AND ICC.CheckDate<='{1} 23:59:59' ", startDate, endDate);
            }
            else if (!string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(endDate))
            {
                strSql.AppendFormat(@" AND ICC.CheckDate>'{0}'", startDate);
            }
            else if (string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                strSql.AppendFormat(@" AND ICC.CheckDate<='{0} 23:59:59' ", endDate);
            }
            if (!string.IsNullOrEmpty(address))
            {
                strSql.AppendFormat(@" AND ICC.CheckSignAddress LIKE '%{0}%'", address);
            }
            var sortField = "CheckDate";   //排序字段
            var sortType = "DESC";        //排序类型

            if (!string.IsNullOrEmpty(sidx))
            {
                sortField = sidx;
                sortType = sord;
            }
            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField, sortType, pageIndex, pageSize, out totalRecords);
        }

        public int GetParkingCount(string startTime,string endTime)
        {
            var sbSql = string.Format(@"select count(*) from [dbo].[INF_CAR_CHECKSIGN] where RowStatus=1 and [CheckDate]>='{0}' and [CheckDate]<='{1}'", startTime, endTime);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString()).ToString());
        
        }

        /// <summary>
        /// 查询照片的详细信息
        /// 添加人：周 鹏
        /// 添加时间：2015-04-10
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="fileId">照片ID信息</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable QueryPhotoDetails(string fileId)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT  ( CASE WHEN ICA.ShootTime = ''
                            OR ICA.ShootTime IS NULL THEN IPC.CheckDate
                       ELSE ICA.ShootTime
                  END ) AS ShootTime ,
                IPC.CheckSignAddress AS CaseAddress ,
                IPC.PersonName1 AS RePersonelNameFist ,
                IPC.PersonName2 AS RePersonelNameSecond,
                ICA.ImgAddress
        FROM    INF_CAR_ATTACH AS ICA
                JOIN INF_CAR_CHECKSIGN AS IPC ON ICA.ResourceId = IPC.Id
        WHERE   ICA.Id = '{0}'", fileId);


                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据车牌号码进行查询【用于手机端】
        /// 添加人：周 鹏
        /// 添加时间：2015-05-15
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="fileViewLink">附件预览地址</param>
        /// <param name="carNo">车牌号码</param>
        /// <returns>DataTable Columns->CarNo CheckDate CheckSignAddress FileView</returns>
        public DataTable MobileGetSearchResult(string fileViewLink, string carNo)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM (
SELECT INF_CAR_CHECKSIGNMIDDLE.Id,CarNo,CONVERT(VARCHAR(16),CheckDate,25) AS CheckDate,CheckSignAddress,'未处理' AS 'Status','{0}' AS FileView,
(SELECT TOP 1 ImgAddress FROM INF_CAR_ATTACH WHERE ResourceId=INF_CAR_CHECKSIGNMIDDLE.Id AND FileType=1 ORDER BY CreateOn) AS FileAddress
FROM INF_CAR_CHECKSIGNMIDDLE WHERE RowStatus=1 AND [State]=0 AND CarNo LIKE '{1}%'
UNION ALL
SELECT ICC.Id,CarNo,CONVERT(VARCHAR(16),CheckDate,25) AS CheckDate,CheckSignAddress,CR.RsKey AS 'Status','{0}' AS FileView,
(SELECT TOP 1 ImgAddress FROM INF_CAR_ATTACH WHERE ResourceId=ICC.Id AND FileType=1 ORDER BY CreateOn) AS FileAddress
FROM INF_CAR_CHECKSIGN AS ICC JOIN ComResource AS CR WITH(NOLOCK) ON ICC.[State]=CR.RsValue AND CR.ParentId='0021' AND ICC.CarNo LIKE '{1}%') AS TB
ORDER BY TB.CheckDate DESC", fileViewLink, carNo);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 请求违章停车详情
        /// 添加人：周 鹏
        /// 添加时间：2015-05-15
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">主键ID</param>
        /// <returns>DataTable.</returns>
        public DataTable MobileGetCarDetails(string id)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT CarNo,CheckDate,CheckSignAddress,CR.RsKey AS 'Status' FROM INF_CAR_CHECKSIGN 
AS ICC JOIN ComResource AS CR WITH(NOLOCK) ON ICC.[State]=CR.RsValue AND CR.ParentId='0021'
WHERE ICC.Id='{0}'", id);

            var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];

            if (dt == null || dt.Rows.Count <= 0)
            {
                strSql = new StringBuilder("");
                strSql.AppendFormat("SELECT CarNo,CheckDate,CheckSignAddress,'未处理' AS 'Status' FROM INF_CAR_CHECKSIGNMIDDLE WHERE Id='{0}' AND State=0", id);
                dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 获取案件附件
        /// 添加人：周 鹏
        /// 添加时间：2015-05-19
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseinfoId">案件编号</param>
        /// <param name="fileViewLink"></param>
        /// <returns></returns>
        public DataTable GetFileList(string caseinfoId, string fileViewLink)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT Id,'{0}' AS FileView,ImgAddress AS FileAddress FROM INF_CAR_ATTACH WHERE RowStatus=1 AND FileType=1 AND ResourceId='{1}' ORDER BY CreateOn", fileViewLink, caseinfoId);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 查询违章停车处理数据
        /// 添加人：周 鹏
        /// 添加时间：2015-06-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="handleType">处理类型</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页请求条数</param>
        /// <param name="totalRecord">总条数</param>
        /// <returns>DataTable.</returns>
        public DataTable QueryHandleGrid(string startTime, string endTime, string handleType, int pageIndex, int pageSize, out int totalRecord)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT ICC.Id, ICC.CarNo,ICC.CheckDate,CU.RealName AS UserName,ICH.HandDate,ICH.HandReason 
FROM INF_CAR_CHECKSIGNMIDDLE AS ICC WITH(NOLOCK)
LEFT JOIN INF_CAR_HANDLER AS ICH WITH(NOLOCK) ON ICC.Id=ICH.CheckSigniId
LEFT JOIN CrmUser AS CU WITH(NOLOCK) ON CU.Id=ICH.HandPersonId
WHERE 1=1  ");

            if (!string.IsNullOrEmpty(handleType))
            {
                strSql.AppendFormat(@" AND ICH.HandType={0}", handleType);
            }
            else
            {
                strSql.Append(@" AND ICH.HandType IN (511,777,404,2)");
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(@" AND ICH.HandDate>='{0}' AND ICH.HandDate<'{1} 23:59:59.999'", startTime, endTime);
            }
            else if (!string.IsNullOrEmpty(startTime))
            {
                strSql.AppendFormat(@" AND ICH.HandDate>='{0}'", startTime);
            }
            else if (!string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(@" AND ICH.HandDate<'{0} 23:59:59.999'", endTime);
            }

            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "HandDate", "DESC", pageIndex, pageSize, out totalRecord);
        }


        /// <summary>
        /// 验证是否重复贴单
        /// </summary>
        /// <param name="carNo">车牌号码</param>
        /// <param name="type">验证源：一级审核、二级审核</param>
        /// <returns></returns>
        public bool CheckRepeat(string carNo, string type)
        {
            var strSql = new StringBuilder("");

            switch (type)
            {
                case "First":
                    strSql.AppendFormat("SELECT COUNT(*) FROM INF_CAR_CHECKSIGNMIDDLE WHERE CarNo='{0}' AND [State]=0", carNo);
                    break;
                case "Second":
                    strSql.AppendFormat("SELECT COUNT(*) FROM INF_CAR_CHECKSIGN WHERE [State]=0 AND CarNo='{0}' AND (Isaudit=0 OR Isaudit=3)", carNo);
                    break;
            }

            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString());
            return obj != null && int.Parse(obj.ToString()) > 1;
        }


        /// <summary>
        /// 获取未处理的数据
        /// </summary>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <returns></returns>
        public DataTable GetUnYJ(string stime, string etime)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(
                @"SELECT ICC.[State], ICC.Id,Road,CheckSIgnAddress,Toward,checkdate,CarType,CarNo FROM INF_CAR_CHECKSIGN AS ICC
INNER JOIN RoadManager AS RM ON ICC.Road = RM.RoadNo 
WHERE 1=1 AND ICC.RowStatus=1 AND [State]=0 AND Road<>'99999' AND 
ICC.CheckDate >='{0}' AND ICC.CheckDate <='{1}'", stime, etime);


            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }
    }
}

