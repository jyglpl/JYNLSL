//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_CompanyDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/2/9 15:42:45
//  功能描述：Base_Company数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System.Collections.Generic;
using System.Data;
using Yookey;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.DataAccess.Base
{
    /// <summary>
    /// Base_Company数据访问操作
    /// </summary>
    public class BaseCompanyDal
    {

        /// <summary>
        /// 查询所有部门
        /// 添加人：周 鹏
        /// 添加时间：2015-02-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<BaseCompanyEntity> GetAllCompanys()
        {
            var strSql = string.Format("SELECT * FROM CrmCompany WHERE Enabled=1 ORDER BY SortCode");

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql).Tables[0];
            return list != null && list.Rows.Count > 0
                          ? ConvertListHelper<BaseCompanyEntity>.ConvertToList(list)
                          : new List<BaseCompanyEntity>();
        }
        public List<BaseCompanyEntity> GetAllCompany()
        {
            var strSql = string.Format("SELECT Id AS CompanyId,* FROM CrmCompany WHERE ParentId='D51BBD91-1381-4D02-8910-E3654F34D6A0' AND Enabled=1 ORDER BY SortCode");

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql).Tables[0];
            return list != null && list.Rows.Count > 0
                          ? ConvertListHelper<BaseCompanyEntity>.ConvertToList(list)
                          : new List<BaseCompanyEntity>();
 
        }
        /// <summary>
        /// 执法大队 
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public List<BaseCompanyEntity> GetCompanyNameByID(string CompanyID)
        {
            var strSql = string.Format("SELECT * FROM CrmCompany WHERE RowStatus=1 ");
            if (!string.IsNullOrEmpty(CompanyID))
            {
                strSql += string.Format(" AND ID='{0}' ", CompanyID);
            }

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringJcxxdbRead, CommandType.Text, strSql).Tables[0];
            return list != null && list.Rows.Count > 0
                          ? ConvertListHelper<BaseCompanyEntity>.ConvertToList(list)
                          : new List<BaseCompanyEntity>();
        }
    }
}

