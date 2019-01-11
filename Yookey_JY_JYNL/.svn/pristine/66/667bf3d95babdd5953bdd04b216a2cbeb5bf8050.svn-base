//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Consent_AttachDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监统一身份认证
//  作    者：张 晖
//  创建日期：2015/7/29 13:54:33
//  功能描述：Consent_Attach数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Consent;

namespace Yookey.WisdomClassed.SIP.DataAccess.Consent
{
    /// <summary>
    /// 行政许可 数据访问操作
    /// </summary>
    public class Consent_AttachDal : DalImp.BaseDal<Consent_AttachEntity>
    {
        public Consent_AttachDal()
        {
            Model = new Consent_AttachEntity();
        }


        /// <summary>
        /// 请求附件
        /// 添加人：周 鹏
        /// 添加时间：2015-09-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">许可主键编号</param>
        /// <param name="fileViewLink">访问附件地址</param>
        /// <returns>DataTable.</returns>
        public DataTable GetFiles(string resourceId, string fileViewLink)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(
                    @"SELECT '{0}' AS FilePath,[FileName],FileAddress FROM [Consent_Attach] WHERE ResourceId='{1}' AND RowStatus=1",
                    fileViewLink, resourceId);


                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

