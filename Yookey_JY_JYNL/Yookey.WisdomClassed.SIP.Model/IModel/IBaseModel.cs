//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComAttachmentEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-02
//  功能描述：ComAttachment表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Yookey.WisdomClassed.SIP.Model.IModel
{
    public interface IBaseModel<T>
    {
        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        T SetModelValueByDataRow(DataRow dr);

        /// <summary>
        /// 根据DataRow给实体相应字段赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fields">字段集合</param>
        /// <returns>实体</returns>
        T SetModelValueByDataRow(DataRow dr, IList<string> fields);

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        SqlParameter[] SetParmsValueByModelForAdd(T model, SqlParameter[] parms);

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        SqlParameter[] SetParmsValueByModelForUpdate(T model, SqlParameter[] parms);

        /// <summary>
        /// 获取一个给SQL语句传参用的参数集合
        /// </summary>
        /// <returns>SqlParameter[] 集合</returns>
        SqlParameter[] GetParms();
        
        /// <summary>
        /// 新增sql语句
        /// </summary>
        string Sql_Insert { get; set; }

        /// <summary>
        /// 修改sql语句
        /// </summary>
        string Sql_Update { get; set; }

        /// <summary>
        /// 删除sql语句
        /// </summary>
        string Sql_Delete { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        string TB_Name { get; set; }

        /// <summary>
        /// 所有参数
        /// </summary>
        string Parm_All_Base { get; set; }

        /// <summary>
        /// 参数主键Id
        /// </summary>
        string Parm_Id { get; set; }

        /// <summary>
        /// 参数版本号
        /// </summary>
        string Parm_Version { get; set; }

        /// <summary>
        /// 主键Id
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// 行状态(0:删除 1:正常 2:隐藏)
        /// </summary>
        int RowStatus { get; set; }

        /// <summary>
        /// 行版本
        /// </summary>
        long Version { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        string CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreateOn { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        string UpdateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime UpdateOn { get; set; }
    }
}
