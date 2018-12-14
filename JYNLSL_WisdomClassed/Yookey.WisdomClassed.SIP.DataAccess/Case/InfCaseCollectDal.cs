//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CASE_COLLECTDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/25 9:28:46
//  功能描述：INF_CASE_COLLECT数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// 其他类案件汇总 数据访问操作
    /// </summary>
    public class InfCaseCollectDal : DalImp.BaseDal<InfCaseCollectEntity>
    {
        public InfCaseCollectDal()
        {
            Model = new InfCaseCollectEntity();
        }

        /// <summary>
        /// 查找案件记录
        /// 创建人：周庆
        /// 创建日期：2015年5月25日
        /// </summary>
        /// <param name="deptId">部门Id</param>
        /// <param name="period">时间（月）</param>
        /// <param name="classNo">类别</param>
        /// <param name="caseType">案件类别</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable SearchCaseCollect(string deptId, string period, string classNo, InfCaseCollectEntity.CaseType caseType, int pageSize, int pageIndex, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.Append(string.Format(@"SELECT
                                            collect.Id,
	                                        dept.FullName DeptName,
	                                        com.RsKey ClassName,
                                            collect.ReportingPeriod,
	                                        collect.Number,
	                                        collect.Area,
                                            collect.CreateOn
                                        FROM INF_CASE_COLLECT collect
                                        LEFT JOIN JCXXDB.dbo.Base_Department dept WITH (NOLOCK)
	                                        ON collect.DeptId = dept.DepartmentId
                                        LEFT JOIN ComResource com WITH (NOLOCK)
	                                        ON collect.ClassesNo = com.Id
                                        WHERE collect.RowStatus = 1
                                        AND collect.TypeNo = '{0}'", (int)caseType));
            if (!string.IsNullOrEmpty(deptId))
                strSql.Append(string.Format(" AND collect.DeptId = '{0}'", deptId));
            if (!string.IsNullOrEmpty(period))
                strSql.Append(string.Format(" AND collect.ReportingPeriod  = '{0}'", period));
            if (!string.IsNullOrEmpty(classNo))
                strSql.Append(string.Format(" AND collect.ClassesNo  = '{0}'", classNo));
            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "ReportingPeriod Desc,CreateOn Desc", "", pageIndex, pageSize, out totalRecords);
        }

        /// <summary>
        /// 获取案件信息
        /// 创建人：周庆
        /// 创建日期：2015年5月26日
        /// </summary>
        /// <param name="deptId">部门Id</param>
        /// <param name="period">所属日期</param>
        /// <param name="classNo">类型</param>
        /// <param name="caseType">案件类型</param>
        /// <returns></returns>
        public InfCaseCollectEntity GetCaseCollent(string deptId, string period, string classNo, InfCaseCollectEntity.CaseType caseType)
        {
            string selSQL = string.Format(@"
                                            SELECT
	                                            Id,
	                                            DeptId,
	                                            ClassesNo,
	                                            TypeNo,
	                                            Number,
	                                            Area,
	                                            ReportingPeriod,
	                                            RowStatus,
	                                            CreatorId,
	                                            CreateBy,
	                                            CreateOn,
	                                            UpdateId,
	                                            UpdateOn,
	                                            UpdateBy
                                            FROM INF_CASE_COLLECT
                                            WHERE RowStatus = 1
                                            AND DeptId = '{0}'
                                            AND ReportingPeriod = '{1}'
                                            AND ClassesNo = '{2}'
                                            AND TypeNo = {3}
                                            ", deptId, period, classNo, (int)caseType);
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.SqlConnStringRead, CommandType.Text, selSQL);
            InfCaseCollectEntity entity = null;
            while (reader.Read())
            {
                entity = new InfCaseCollectEntity(reader);
            }
            return entity;
        }
    }
}

