//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseAttachDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/2/1 9:11:45
//  功能描述：LicenseAttach数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using Yookey.WisdomClassed.SIP.Model.License;
using System;
using System.Text;
using DBHelper;
using System.Data;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Enumerate;
using System.Data.SqlClient;
namespace Yookey.WisdomClassed.SIP.DataAccess.License
{
    /// <summary>
    /// LicenseAttach数据访问操作
    /// </summary>
    public class LicenseAttachDal : DalImp.BaseDal<LicenseAttachEntity>
    {
        public LicenseAttachDal()
        {
            Model = new LicenseAttachEntity();
        }


        /// <summary>
        /// 通过主键编号和材料编号获取附件
        /// </summary>
        /// <param name="resourid">主键编号</param>
        /// <param name="fileType">配置材料编号</param>
        /// <param name="licenseAttachType">附件类型</param>
        /// <returns></returns>
        public List<LicenseAttachEntity> GetLicenseAttachList(string resourid, string fileType, LicenseAttachType licenseAttachType)
        {
            try
            {
                var strSql = @"SELECT * FROM [dbo].[LicenseAttach] WHERE RowStatus=1";                
                if (!string.IsNullOrEmpty(resourid))
                {
                    strSql+=@" AND ResourceId=@ResourceId";
                }
                if (!string.IsNullOrEmpty(fileType))
                {
                    strSql +=@" AND FileType=@FileType";
                }
                if (licenseAttachType == LicenseAttachType.Material)
                {
                    strSql+=@" AND FileType IN (SELECT Id FROM [LicenseMaterialCatalogue])";
                }
                else
                {
                    strSql+=" AND FileType NOT IN (SELECT Id from [dbo].[LicenseMaterialCatalogue])";
                }
                strSql+=" ORDER BY CreateOn";

                var paramerList = new List<SqlParameter>();
                paramerList.Add(new SqlParameter("ResourceId", resourid));
                paramerList.Add(new SqlParameter("FileType", fileType));

                return DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString(),paramerList.ToArray()).Tables[0]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 无效附件
        /// </summary>
        /// <param name="id">附件主键</param>
        /// <returns></returns>
        public bool LicenseAttachDelete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return false;
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"UPDATE [dbo].[LicenseAttach] set RowStatus=0 WHERE Id='{0}'", id);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}

