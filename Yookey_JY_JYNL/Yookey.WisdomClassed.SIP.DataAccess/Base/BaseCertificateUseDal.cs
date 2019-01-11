//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_CertificateUseDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/18 15:05:07
//  功能描述：Base_CertificateUse数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yookey;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.DataAccess.Base
{
    /// <summary>
    /// 执法证管理数据访问操作
    /// </summary>
    public class BaseCertificateUseDal : DalImp.BaseDal<BaseCertificateUseEntity>
    {
        public BaseCertificateUseDal()
        {           
            Model = new BaseCertificateUseEntity();
        }
        /// <summary>
        /// 执法证（监督证）取得所有使用记录
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public DataTable GetAllCertificateUse(string uid)
        {
            var countSql = new StringBuilder(""); 
            countSql.AppendFormat("SELECT A.Id,UserId,B.RsKey AS UseType,UseDesc ,CONVERT(varchar(100), UseOn, 23) AS UseOn,Row_Number() OVER(order by UseOn desc) ");
            countSql.AppendFormat("AS RowNum FROM Base_CertificateUse A inner join ComResource B on A.UseType=B.Id where UserID='{0}' and A.RowStatus=1", uid);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, countSql.ToString()).Tables[0];
        }
        /// <summary>
        ///查询证件管理类型
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public DataTable GetCertificateType(string typeid)
        {
            var countSql = new StringBuilder("");
            countSql.AppendFormat("SELECT ID,RsKey from ComResource where ParentId='{0}'", typeid);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, countSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 删除执法(监督)证使用记录
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public int Delete(string id)
        {
            var count = new StringBuilder("");
            count.AppendFormat("Update Base_CertificateUse Set RowStatus=0 where Id='{0}';select @@rowcount", id);
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
    }
}
                                                                                                                                         
