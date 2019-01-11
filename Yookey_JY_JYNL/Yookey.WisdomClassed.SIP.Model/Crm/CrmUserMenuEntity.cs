//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmUserMenuEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/3/19 13:26:42
//  功能描述：CrmUserMenu表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.ModelImp;

namespace Yookey.WisdomClassed.SIP.Model.Crm
{
    /// <summary>
    /// 用户菜单对应关系
    /// </summary>
    [Serializable]
    public class CrmUserMenuEntity : BaseModel<CrmUserMenuEntity>
    {
        public CrmUserMenuEntity()
        {
            TB_Name = TB_CrmUserMenu;
            Parm_Id = Parm_CrmUserMenu_Id;
            Parm_Version = Parm_CrmUserMenu_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_CrmUserMenu_Insert;
            Sql_Update = Sql_CrmUserMenu_Update;
            Sql_Delete = Sql_CrmUserMenu_Delete;
        }
        #region Const of table CrmUserMenu
        /// <summary>
        /// Table CrmUserMenu
        /// </summary>
        public const string TB_CrmUserMenu = "CrmUserMenu";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_CrmUserMenu_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_CrmUserMenu_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_CrmUserMenu_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_CrmUserMenu_Id = "Id";
        /// <summary>
        /// Parm MenuId
        /// </summary>
        public const string Parm_CrmUserMenu_MenuId = "MenuId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_CrmUserMenu_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_CrmUserMenu_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_CrmUserMenu_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_CrmUserMenu_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_CrmUserMenu_UserId = "UserId";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_CrmUserMenu_Version = "Version";
        /// <summary>
        /// Insert Query Of CrmUserMenu
        /// </summary>
        public const string Sql_CrmUserMenu_Insert = "insert into CrmUserMenu(CreateBy,CreateOn,CreatorId,MenuId,RowStatus,UpdateBy,UpdateId,UpdateOn,UserId) values(@CreateBy,@CreateOn,@CreatorId,@MenuId,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@UserId);select @@identity;";
        /// <summary>
        /// Update Query Of CrmUserMenu
        /// </summary>
        public const string Sql_CrmUserMenu_Update = "update CrmUserMenu set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,MenuId=@MenuId,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_CrmUserMenu_Delete = "update CrmUserMenu set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _menuId = string.Empty;
        /// <summary>
        /// 菜单编号
        /// </summary>
        public string MenuId
        {
            get { return _menuId ?? string.Empty; }
            set { _menuId = value; }
        }
        private string _userId = string.Empty;
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserId
        {
            get { return _userId ?? string.Empty; }
            set { _userId = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override CrmUserMenuEntity SetModelValueByDataRow(DataRow dr)
        {
            IList<string> fields = new List<string> { "*" };
            return SetModelValueByDataRow(dr, fields);
        }

        /// <summary>
        /// 根据DataRow给实体相应字段赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fields">字段集合</param>
        /// <returns>实体</returns>
        public override CrmUserMenuEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmUserMenuEntity();
            if (dr.Table.Columns.Contains(Parm_CrmUserMenu_Id))
                tmp.Id = dr[Parm_CrmUserMenu_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUserMenu_MenuId))
                tmp.MenuId = dr[Parm_CrmUserMenu_MenuId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUserMenu_UserId))
                tmp.UserId = dr[Parm_CrmUserMenu_UserId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUserMenu_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_CrmUserMenu_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUserMenu_Version))
            {
                var bts = (byte[])(dr[Parm_CrmUserMenu_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_CrmUserMenu_CreatorId))
                tmp.CreatorId = dr[Parm_CrmUserMenu_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUserMenu_CreateBy))
                tmp.CreateBy = dr[Parm_CrmUserMenu_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUserMenu_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_CrmUserMenu_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmUserMenu_UpdateId))
                tmp.UpdateId = dr[Parm_CrmUserMenu_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUserMenu_UpdateBy))
                tmp.UpdateBy = dr[Parm_CrmUserMenu_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmUserMenu_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmUserMenu_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmusermenu">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(CrmUserMenuEntity crmusermenu, SqlParameter[] parms)
        {
            parms[0].Value = crmusermenu.MenuId;
            parms[1].Value = crmusermenu.UserId;
            parms[2].Value = crmusermenu.RowStatus;
            parms[3].Value = crmusermenu.CreatorId;
            parms[4].Value = crmusermenu.CreateBy;
            parms[5].Value = crmusermenu.CreateOn;
            parms[6].Value = crmusermenu.UpdateId;
            parms[7].Value = crmusermenu.UpdateBy;
            parms[8].Value = crmusermenu.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(CrmUserMenuEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_CrmUserMenu_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_CrmUserMenu_Version, model.Version);
            return parms;
        }

        /// <summary>
        /// 获取一个给SQL语句传参用的参数集合
        /// </summary>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] GetParms()
        {
            try
            {
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmUserMenu_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_CrmUserMenu_MenuId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUserMenu_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUserMenu_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmUserMenu_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUserMenu_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUserMenu_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmUserMenu_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUserMenu_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmUserMenu_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmUserMenu_Insert, parms);
                }
                return parms;
            }
            catch (Exception e)
            {
                throw new Exception("获取查询参数时出错！", e);
            }
        }
    }
}
