//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CAR_CHECKSIGNMIDDLEDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/22 16:26:18
//  功能描述：INF_CAR_CHECKSIGNMIDDLE数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using Yookey;
using System;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Case;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// INF_CAR_CHECKSIGNMIDDLE数据访问操作
    /// </summary>
    public class InfCarChecksignmiddleDal : DalImp.BaseDal<InfCarChecksignmiddleEntity>
    {
        public InfCarChecksignmiddleDal()
        {
            Model = new InfCarChecksignmiddleEntity();
        }

        /// <summary>
        /// 数据查询
        /// 添加人：周 鹏
        /// 添加时间：2015-04-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询条件</param>
        /// <returns>DataTable.</returns>
        public DataTable GetSearchResult(CarList search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT ICC.Id,CarNo,CheckDate FROM INF_CAR_CHECKSIGNMIDDLE AS ICC WITH(NOLOCK)
INNER JOIN CrmDepartment AS CD WITH(NOLOCK) ON ICC.DeptId=CD.Id
INNER JOIN CrmCompany AS CC WITH(NOLOCK) ON CC.Id=CD.CompanyId
WHERE ICC.RowStatus=1");

            if (!search.CompanyId.Equals("all"))
            {
                strSql.AppendFormat(" AND CC.Id='{0}'", search.CompanyId);
            }
            if (!string.IsNullOrEmpty(search.DeptId) && !search.DeptId.Equals("all"))
            {
                strSql.AppendFormat(" AND ICC.DeptId='{0}'", search.DeptId);
            }
            if (!string.IsNullOrEmpty(search.NoticeNo))
            {
                strSql.AppendFormat(" AND ICC.NoticeNo='{0}'", search.NoticeNo);
            }
            if (!string.IsNullOrEmpty(search.CarNo))
            {
                strSql.AppendFormat(" AND ICC.CarNo LIKE '%{0}%'", search.CarNo);
            }
            if (!string.IsNullOrEmpty(search.State))
            {
                strSql.AppendFormat(" AND ICC.State = '{0}'", search.State);
            }
            strSql.Append("  ORDER BY CheckDate");
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString());
            return list.Tables[0];
        }

        /// <summary>
        /// 验证通知书编号是否可以被使用
        /// 添加人：周 鹏
        /// 添加时间：2015-04-16
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="noticeNo">通知书编号</param>
        /// <returns></returns>
        public bool CheckNoticeNo(string noticeNo)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT COUNT(*) FROM dbo.INF_CAR_CHECKSIGNMIDDLE  WHERE NoticeNo='{0}'", noticeNo);

                var cnt = int.Parse(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).ToString());
                return cnt == 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取一级超48小时未审核的数据
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>DataTable.</returns>
        public DataTable GetSearchAllUnCheck()
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT ICC.Id,CarNo,CheckDate FROM INF_CAR_CHECKSIGNMIDDLE AS ICC WITH(NOLOCK)
INNER JOIN CrmDepartment AS CD WITH(NOLOCK) ON ICC.DeptId=CD.Id
INNER JOIN CrmCompany AS CC WITH(NOLOCK) ON CC.Id=CD.CompanyId
WHERE ICC.RowStatus=1 AND [State]=0 AND CheckDate<=DATEADD(DAY,-2,GETDATE())");

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString());
            return list.Tables[0];
        }

    }
}
