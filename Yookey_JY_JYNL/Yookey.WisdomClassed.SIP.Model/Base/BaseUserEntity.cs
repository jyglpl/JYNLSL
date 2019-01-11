//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_UserEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/2/9 15:42:42
//  功能描述：Base_User表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Base
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    [Serializable]
    public class BaseUserEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码加密Key
        /// </summary>
        public string Secretkey { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 单位编号
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 部门编号
        /// </summary>
        public string DeptId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 监督证或者执法证编号
        /// </summary>
        public string CertificateNo { get; set; }

        /// <summary>
        /// 修改密码的日期
        /// </summary>
        public DateTime ChangePasswordDate { get; set; }
    }
}

