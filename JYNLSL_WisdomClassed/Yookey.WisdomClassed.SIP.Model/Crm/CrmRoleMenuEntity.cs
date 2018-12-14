//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmRoleMenuEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/3/19 13:26:43
//  功能描述：CrmRoleMenu表实体
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
    /// 角色菜单对应关系
    /// </summary>
    [Serializable]
    public class CrmRoleMenuEntity : BaseModel<CrmRoleMenuEntity>
    {
        public CrmRoleMenuEntity()
        {
            TB_Name = TB_CrmRoleMenu;
            Parm_Id = Parm_CrmRoleMenu_Id;
            Parm_Version = Parm_CrmRoleMenu_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_CrmRoleMenu_Insert;
            Sql_Update = Sql_CrmRoleMenu_Update;
            Sql_Delete = Sql_CrmRoleMenu_Delete;
        }
        #region Const of table CrmRoleMenu
        /// <summary>
        /// Table CrmRoleMenu
        /// </summary>
        public const string TB_CrmRoleMenu = "CrmRoleMenu";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_CrmRoleMenu_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_CrmRoleMenu_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_CrmRoleMenu_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_CrmRoleMenu_Id = "Id";
        /// <summary>
        /// Parm MenuId
        /// </summary>
        public const string Parm_CrmRoleMenu_MenuId = "MenuId";
        /// <summary>
        /// Parm RoleId
        /// </summary>
        public const string Parm_CrmRoleMenu_RoleId = "RoleId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_CrmRoleMenu_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_CrmRoleMenu_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_CrmRoleMenu_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_CrmRoleMenu_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_CrmRoleMenu_Version = "Version";
        /// <summary>
        /// Insert Query Of CrmRoleMenu
        /// </summary>
        public const string Sql_CrmRoleMenu_Insert = "insert into CrmRoleMenu(CreateBy,CreateOn,CreatorId,MenuId,RoleId,RowStatus,UpdateBy,UpdateId,UpdateOn) values(@CreateBy,@CreateOn,@CreatorId,@MenuId,@RoleId,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn);select @@identity;";
        /// <summary>
        /// Update Query Of CrmRoleMenu
        /// </summary>
        public const string Sql_CrmRoleMenu_Update = "update CrmRoleMenu set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,MenuId=@MenuId,RoleId=@RoleId,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_CrmRoleMenu_Delete = "update CrmRoleMenu set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        private string _roleId = string.Empty;
        /// <summary>
        /// 角色编号
        /// </summary>
        public string RoleId
        {
            get { return _roleId ?? string.Empty; }
            set { _roleId = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override CrmRoleMenuEntity SetModelValueByDataRow(DataRow dr)
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
        public override CrmRoleMenuEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new CrmRoleMenuEntity();
            if (dr.Table.Columns.Contains(Parm_CrmRoleMenu_Id))
                tmp.Id = dr[Parm_CrmRoleMenu_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRoleMenu_MenuId))
                tmp.MenuId = dr[Parm_CrmRoleMenu_MenuId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRoleMenu_RoleId))
                tmp.RoleId = dr[Parm_CrmRoleMenu_RoleId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRoleMenu_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_CrmRoleMenu_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmRoleMenu_Version))
            {
                var bts = (byte[])(dr[Parm_CrmRoleMenu_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_CrmRoleMenu_CreatorId))
                tmp.CreatorId = dr[Parm_CrmRoleMenu_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRoleMenu_CreateBy))
                tmp.CreateBy = dr[Parm_CrmRoleMenu_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRoleMenu_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_CrmRoleMenu_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_CrmRoleMenu_UpdateId))
                tmp.UpdateId = dr[Parm_CrmRoleMenu_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRoleMenu_UpdateBy))
                tmp.UpdateBy = dr[Parm_CrmRoleMenu_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_CrmRoleMenu_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_CrmRoleMenu_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="crmrolemenu">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(CrmRoleMenuEntity crmrolemenu, SqlParameter[] parms)
        {
            parms[0].Value = crmrolemenu.MenuId;
            parms[1].Value = crmrolemenu.RoleId;
            parms[2].Value = crmrolemenu.RowStatus;
            parms[3].Value = crmrolemenu.CreatorId;
            parms[4].Value = crmrolemenu.CreateBy;
            parms[5].Value = crmrolemenu.CreateOn;
            parms[6].Value = crmrolemenu.UpdateId;
            parms[7].Value = crmrolemenu.UpdateBy;
            parms[8].Value = crmrolemenu.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(CrmRoleMenuEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_CrmRoleMenu_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_CrmRoleMenu_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmRoleMenu_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_CrmRoleMenu_MenuId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmRoleMenu_RoleId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmRoleMenu_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_CrmRoleMenu_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmRoleMenu_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmRoleMenu_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_CrmRoleMenu_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmRoleMenu_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_CrmRoleMenu_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_CrmRoleMenu_Insert, parms);
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
