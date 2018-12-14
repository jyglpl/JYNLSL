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
using Yookey.WisdomClassed.SIP.Model.IModel;

namespace Yookey.WisdomClassed.SIP.Model.ModelImp
{
    [Serializable]
    public abstract class BaseModel<T> : IBaseModel<T>
    {
        /// <summary>
        /// 当前时间
        /// </summary>
        public static DateTime NowDate = DateTime.Now;

        /// <summary>
        /// 最小时间1900-01-01
        /// </summary>
        public static DateTime MinDate = Convert.ToDateTime("1900-01-01");


        private string _id = string.Empty;
        public virtual string Id
        {
            get { return _id ?? string.Empty; }
            set { _id = value; }
        }

        /// <summary>
        /// 主键
        /// </summary>
        //public virtual string Id { get; set; }

        /// <summary>
        /// 行状态(0:删除 1:正常 2:隐藏)
        /// </summary>
        public int RowStatus { get; set; }

        /// <summary>
        /// 行版本
        /// </summary>
        public long Version { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public string CreatorId { get; set; }

        private string _createBy = string.Empty;
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy
        {
            get { return _createBy ?? string.Empty; }
            set { _createBy = value; }
        }

        private DateTime _createOn = MinDate;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn
        {
            get { return _createOn; }
            set { _createOn = value; }
        }

        /// <summary>
        /// 修改ID
        /// </summary>
        public string UpdateId { get; set; }

        private string _updateBy = string.Empty;
        /// <summary>
        /// 更新人
        /// </summary>
        public string UpdateBy
        {
            get { return _updateBy; }
            set { _updateBy = value; }
        }

        private DateTime _updateOn = MinDate;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime UpdateOn
        {
            get { return _updateOn; }
            set { _updateOn = value; }
        }

        /// <summary>
        /// INSERT
        /// </summary>
        public string Sql_Insert { get; set; }

        /// <summary>
        /// UPDATE
        /// </summary>
        public string Sql_Update { get; set; }

        /// <summary>
        /// DELETE
        /// </summary>
        public string Sql_Delete { get; set; }

        /// <summary>
        /// TABLE NAME
        /// </summary>
        public string TB_Name { get; set; }

        private string _pramAll = "*";
        /// <summary>
        /// TABLE PARAMS
        /// </summary>
        public string Parm_All_Base
        {
            get { return _pramAll; }
            set { _pramAll = value; }
        }
        private string _pramId = "Id";
        /// <summary>
        /// Primary key
        /// </summary>
        public string Parm_Id
        {
            get { return _pramId; }
            set { _pramId = value; }
        }
        private string _parmVersion = "Version";
        /// <summary>
        /// Version
        /// </summary>
        public string Parm_Version
        {
            get { return _parmVersion; }
            set { _parmVersion = value; }
        }

        private int _pageIndex = 1;
        /// <summary>
        /// 分页值
        /// </summary>
        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        private int _pageSize = 20;
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }
        private bool _isPage = true;
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public bool IsPage
        {
            get { return _isPage; }
            set { _isPage = value; }
        }

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public abstract T SetModelValueByDataRow(System.Data.DataRow dr);

        /// <summary>
        /// 根据DataRow给实体相应字段赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fields">字段集合</param>
        /// <returns>实体</returns>
        public abstract T SetModelValueByDataRow(System.Data.DataRow dr, IList<string> fields);

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public abstract System.Data.SqlClient.SqlParameter[] SetParmsValueByModelForAdd(T model, System.Data.SqlClient.SqlParameter[] parms);

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public abstract System.Data.SqlClient.SqlParameter[] SetParmsValueByModelForUpdate(T model, System.Data.SqlClient.SqlParameter[] parms);

        /// <summary>
        /// 获取一个给SQL语句传参用的参数集合
        /// </summary>
        /// <returns>SqlParameter[] 集合</returns>
        public abstract System.Data.SqlClient.SqlParameter[] GetParms();

    }
}
