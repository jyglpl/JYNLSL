//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_CertificateDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/18 14:51:40
//  功能描述：Base_Certificate数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Data;
using System.Text;
using Yookey;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Enumerate;

namespace Yookey.WisdomClassed.SIP.DataAccess.Base
{
    /// <summary>
    /// Base_Certificate数据访问操作
    /// </summary>
    public class BaseCertificateDal : DalImp.BaseDal<BaseCertificateEntity>
    {
        public BaseCertificateDal()
        {
            Model = new BaseCertificateEntity();
        }

        ///  <summary>
        /// 查询证件类型
        ///  </summary>
        /// <param name="typeid"></param>
        ///  <returns></returns>
        public DataTable GetCertificateType(string typeid)
        {
            var countSql = new StringBuilder("");
            countSql.AppendFormat("SELECT ID,RsKey from ComResource where ParentId='{0}'", typeid);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, countSql.ToString()).Tables[0];
        }

        /// <summary>
        ///判断用户有无此证件
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="typeid">证件类型</param>
        /// <returns></returns>
        public int CheckHadCardByType(string uid, string typeid)
        {
            var count = new StringBuilder("");
            count.AppendFormat("SELECT count(*) from Base_Certificate where UserId='{0}' and CertificateType='{1}' and RowStatus=1", uid, typeid);
            int totalRecords = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, count.ToString()));
            if (totalRecords > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// 根据用户编号查询详情实体
        /// 添加人：周 鹏
        /// 添加时间：2015-04-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户ID</param>
        /// <returns>BaseCertificateEntity.</returns>
        /// <exception cref="System.Exception"></exception>
        public BaseCertificateEntity GetEntityByUserId(string userId)
        {
            try
            {
                var strSql = string.Format(@"SELECT * FROM Base_Certificate WHERE UserId='{0}'", userId);

                var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
                return dt != null && dt.Rows.Count > 0 ? DataTableToList(dt)[0] : null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 执法证统计
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>DataTable.</returns>
        public DataTable GetCertificateData(string cardType, string deptid, string lyTimeStart, string lyTimeEnd, string njTimeStart, string njTimeEnd,
            string hzTimeStart, string hzTimeEnd, int pageIndex, int pageSize, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            var ZSTypeWhere = new StringBuilder("");
            var CERTIFICATETYPEWhereJD = new StringBuilder(@"SELECT BC.Companyid, BC.FullName AS CompanyName,BD.FullName AS DepartmentName ,BD.DepartmentId,BD.sortcode,
(select COUNT(*) from dbo.Base_Certificate  
inner join ComResource on ComResource.id=certificatetype
  left JOIN JCXXDB.dbo.Base_User u on u.UserId=Base_Certificate.USERID
  left JOIN JCXXDB.dbo.Base_Department AS JBD WITH(NOLOCK) ON JBD.DepartmentId=u.departmentid  
  WHERE JBD.DEPARTMENTID=BD.DepartmentId AND Base_Certificate.ROWSTATUS=1 AND CERTIFICATETYPE='00340001' ) as JDCounts,
  
  (select COUNT(*) from dbo.Base_Certificate  
inner join ComResource on ComResource.id=certificatetype
  left JOIN JCXXDB.dbo.Base_User u on u.UserId=Base_Certificate.USERID
  left JOIN JCXXDB.dbo.Base_Department AS JBD WITH(NOLOCK) ON JBD.DepartmentId=u.departmentid  
  WHERE JBD.DEPARTMENTID=BD.DepartmentId AND Base_Certificate.ROWSTATUS=1 AND CERTIFICATETYPE='00340002' ) as ZFCounts");
            var CERTIFICATETYPEWhereZF = new StringBuilder("");
            var CERTIFICATETYPEWhere = new StringBuilder("");
            if (string.IsNullOrEmpty(lyTimeStart) && string.IsNullOrEmpty(lyTimeEnd) && string.IsNullOrEmpty(njTimeStart) && string.IsNullOrEmpty(njTimeEnd) && string.IsNullOrEmpty(hzTimeStart) && string.IsNullOrEmpty(hzTimeEnd))
            {
                if (!string.IsNullOrEmpty(cardType))
                {
                    if (cardType == "00340001")
                    {

                        CERTIFICATETYPEWhereJD = new StringBuilder(@" SELECT BC.Companyid,  BC.FullName AS CompanyName,BD.FullName AS DepartmentName ,BD.DepartmentId,BD.sortcode,
(select COUNT(*) from dbo.Base_Certificate  
inner join ComResource on ComResource.id=certificatetype
  left JOIN JCXXDB.dbo.Base_User u on u.UserId=Base_Certificate.USERID
  left JOIN JCXXDB.dbo.Base_Department AS JBD WITH(NOLOCK) ON JBD.DepartmentId=u.departmentid  
  WHERE JBD.DEPARTMENTID=BD.DepartmentId AND Base_Certificate.ROWSTATUS=1 AND CERTIFICATETYPE='00340001' ) as JDCounts, '0' AS ZFCounts");
                    }
                    else if (cardType == "00340002")
                    {
                        CERTIFICATETYPEWhereJD = new StringBuilder(@" SELECT BC.Companyid,  BC.FullName AS CompanyName,BD.FullName AS DepartmentName ,BD.DepartmentId,BD.sortcode,
(select COUNT(*) from dbo.Base_Certificate  
inner join ComResource on ComResource.id=certificatetype
  left JOIN JCXXDB.dbo.Base_User u on u.UserId=Base_Certificate.USERID
  left JOIN JCXXDB.dbo.Base_Department AS JBD WITH(NOLOCK) ON JBD.DepartmentId=u.departmentid  
  WHERE JBD.DEPARTMENTID=BD.DepartmentId AND Base_Certificate.ROWSTATUS=1 AND CERTIFICATETYPE='00340002' ) as ZFCounts, '0' AS JDCounts");
                    }
                }
                strSql.AppendFormat(@" select tab.Companyid, tab.sortcode,  tab.CompanyName,tab.DepartmentName,tab.JDCounts,tab.ZFCounts,convert(float,tab.JDCounts)+convert(float, tab.ZFCounts) as counts 
from ( {0}  FROM JCXXDB.dbo.Base_Department AS BD WITH (NOLOCK)
JOIN JCXXDB.dbo.Base_Company AS BC WITH(NOLOCK) ON BD.CompanyId=BC.CompanyId
WHERE BC.ParentId='14482d93-7486-4de5-937e-c10977b5e11c' 
AND BC.CompanyId IN ('def6350f-adf1-417c-b7a8-a09c3299d6c9',
'c1ef0d6f-4ba6-4acb-8c98-cc5a87f3954f','1a814c3e-eb32-4ad1-9a9a-c0bb983544b8') 
) as tab  where  1=1 ", CERTIFICATETYPEWhereJD);

                if (!string.IsNullOrEmpty(deptid))
                {
                    strSql.AppendFormat(" AND tab .departmentid='{0}'", deptid);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(lyTimeStart) && !string.IsNullOrEmpty(lyTimeEnd))
                {
                    if (string.IsNullOrEmpty(ZSTypeWhere.ToString()))
                    {
                        ZSTypeWhere.AppendFormat(@" AND ( ");
                    }

                    ZSTypeWhere.AppendFormat(@"  (usetype ='00350001' and useon>='{0} 00:00:00'  and  useon<='{1} 23:59:59')", lyTimeStart, lyTimeEnd);
                }

                if (!string.IsNullOrEmpty(njTimeStart) && !string.IsNullOrEmpty(njTimeEnd))
                {
                    if (string.IsNullOrEmpty(ZSTypeWhere.ToString()))
                    {
                        ZSTypeWhere.AppendFormat(@" AND ( ");
                    }
                    else
                    {
                        ZSTypeWhere.AppendFormat(@" or ");
                    }

                    ZSTypeWhere.AppendFormat(@"  ( usetype ='00350005' and useon>='{0} 00:00:00' and  useon<='{1} 23:59:59') ", njTimeStart, njTimeEnd);
                }
                if (!string.IsNullOrEmpty(hzTimeStart) && !string.IsNullOrEmpty(hzTimeEnd))
                {
                    if (string.IsNullOrEmpty(ZSTypeWhere.ToString()))
                    {
                        ZSTypeWhere.AppendFormat(@" AND ( ");
                    }
                    else
                    {
                        ZSTypeWhere.AppendFormat(@" or ");
                    }
                    ZSTypeWhere.AppendFormat(@" ( usetype ='00350006' and useon>='{0} 00:00:00'  and  useon<='{1} 23:59:59') ", hzTimeStart, hzTimeEnd);
                }

                if (!string.IsNullOrEmpty(ZSTypeWhere.ToString()))
                {
                    ZSTypeWhere.AppendFormat(@")");
                }
                var WhereSql = string.Format(@"(select COUNT(*) from dbo.Base_Certificate inner  join  Base_CertificateUse
on Base_CertificateUse.userid=Base_Certificate.userid
inner join ComResource on ComResource.id=certificatetype
left JOIN JCXXDB.dbo.Base_User u on u.UserId=Base_Certificate.USERID
  left JOIN JCXXDB.dbo.Base_Department AS JBD WITH(NOLOCK) ON JBD.DepartmentId=u.departmentid  
  WHERE JBD.DEPARTMENTID=BD.DepartmentId  AND Base_Certificate.ROWSTATUS=1 AND Base_CertificateUse.ROWSTATUS=1  AND CERTIFICATETYPE='00340001' {0}) as JDCounts,
  
  (select COUNT(*) from dbo.Base_Certificate inner  join  Base_CertificateUse
on Base_CertificateUse.userid=Base_Certificate.userid
inner join ComResource on ComResource.id=certificatetype
  left JOIN JCXXDB.dbo.Base_User u on u.UserId=Base_Certificate.USERID
  left JOIN JCXXDB.dbo.Base_Department AS JBD WITH(NOLOCK) ON JBD.DepartmentId=u.departmentid  
  WHERE JBD.DEPARTMENTID=BD.DepartmentId AND Base_Certificate.ROWSTATUS=1 AND Base_CertificateUse.ROWSTATUS=1 AND CERTIFICATETYPE='00340002' {0}) as ZFCounts", ZSTypeWhere);
                if (!string.IsNullOrEmpty(cardType))
                {
                    if (cardType == "00340001")
                    {
                        WhereSql = string.Format(@"(select COUNT(*) from dbo.Base_Certificate inner  join  Base_CertificateUse
on Base_CertificateUse.userid=Base_Certificate.userid
inner join ComResource on ComResource.id=certificatetype
  left JOIN JCXXDB.dbo.Base_User u on u.UserId=Base_Certificate.USERID
  left JOIN JCXXDB.dbo.Base_Department AS JBD WITH(NOLOCK) ON JBD.DepartmentId=u.departmentid  
  WHERE JBD.DEPARTMENTID=BD.DepartmentId AND Base_Certificate.ROWSTATUS=1 AND Base_CertificateUse.ROWSTATUS=1 AND CERTIFICATETYPE='00340001' {0}) as JDCounts,'0' as ZFCounts ", ZSTypeWhere);
                    }
                    else if (cardType == "00340002")
                    {
                        WhereSql = string.Format(@"(select COUNT(*) from dbo.Base_Certificate inner  join  Base_CertificateUse
on Base_CertificateUse.userid=Base_Certificate.userid
inner join ComResource on ComResource.id=certificatetype
  left JOIN JCXXDB.dbo.Base_User u on u.UserId=Base_Certificate.USERID
  left JOIN JCXXDB.dbo.Base_Department AS JBD WITH(NOLOCK) ON JBD.DepartmentId=u.departmentid  
  WHERE JBD.DEPARTMENTID=BD.DepartmentId AND Base_Certificate.ROWSTATUS=1 AND Base_CertificateUse.ROWSTATUS=1 AND CERTIFICATETYPE='00340002' {0}) as ZFCounts  ,'0' as JDCounts  ", ZSTypeWhere);
                    }
                }
                strSql.AppendFormat(@"select tab.Companyid, tab.sortcode,  tab.CompanyName,tab.DepartmentName,tab.JDCounts,tab.ZFCounts,convert(float,tab.JDCounts)+convert(float, tab.ZFCounts) as counts from (
SELECT BC.Companyid,  BC.FullName AS CompanyName,BD.FullName AS DepartmentName ,BD.DepartmentId,BD.sortcode,"
    );
                strSql.AppendFormat(WhereSql);
                strSql.AppendFormat(@" FROM JCXXDB.dbo.Base_Department AS BD WITH (NOLOCK)
JOIN JCXXDB.dbo.Base_Company AS BC WITH(NOLOCK) ON BD.CompanyId=BC.CompanyId
WHERE BC.ParentId='14482d93-7486-4de5-937e-c10977b5e11c' 
AND BC.CompanyId IN ('def6350f-adf1-417c-b7a8-a09c3299d6c9','c1ef0d6f-4ba6-4acb-8c98-cc5a87f3954f','1a814c3e-eb32-4ad1-9a9a-c0bb983544b8') 
) as tab  where  1=1 ");
                if (!string.IsNullOrEmpty(deptid))
                {
                    strSql.AppendFormat(" AND tab .departmentid='{0}'", deptid);
                }
            }
           
            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CompanyName, sortcode", "Asc", pageIndex, pageSize, out totalRecords);
        }
    }
}

