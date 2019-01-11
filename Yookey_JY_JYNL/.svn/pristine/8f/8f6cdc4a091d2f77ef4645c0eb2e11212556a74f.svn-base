using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Mobile
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class MobileUserMenuEntity : ModelImp.BaseModel<MobileUserMenuEntity>
    {
        public MobileUserMenuEntity()
        {
            TB_Name = TB_Mobile_UserMenu;
            Parm_Id = Parm_Mobile_UserMenu_Id;
            Parm_Version = Parm_Mobile_UserMenu_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_Mobile_UserMenu_Insert;
            Sql_Update = Sql_Mobile_UserMenu_Update;
            Sql_Delete = Sql_Mobile_UserMenu_Delete;
        }
        #region Const of table Mobile_UserMenu
        /// <summary>
        /// Table Mobile_UserMenu
        /// </summary>
        public const string TB_Mobile_UserMenu = "Mobile_UserMenu";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_Mobile_UserMenu_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_Mobile_UserMenu_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_Mobile_UserMenu_CreatorId = "CreatorId";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_Mobile_UserMenu_Id = "Id";
        /// <summary>
        /// Parm MenuId
        /// </summary>
        public const string Parm_Mobile_UserMenu_MenuId = "MenuId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_Mobile_UserMenu_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_Mobile_UserMenu_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_Mobile_UserMenu_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_Mobile_UserMenu_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm UserId
        /// </summary>
        public const string Parm_Mobile_UserMenu_UserId = "UserId";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_Mobile_UserMenu_Version = "Version";
        /// <summary>
        /// Insert Query Of Mobile_UserMenu
        /// </summary>
        public const string Sql_Mobile_UserMenu_Insert = "insert into Mobile_UserMenu(CreateBy,CreateOn,CreatorId,Id,MenuId,RowStatus,UpdateBy,UpdateId,UpdateOn,UserId) values(@CreateBy,@CreateOn,@CreatorId,@Id,@MenuId,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@UserId);select @@identity;";
        /// <summary>
        /// Update Query Of Mobile_UserMenu
        /// </summary>
        public const string Sql_Mobile_UserMenu_Update = "update Mobile_UserMenu set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,Id=@Id,MenuId=@MenuId,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn,UserId=@UserId where Id=@Id And Version=@Version;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Mobile_UserMenu_Delete = "update Mobile_UserMenu set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _menuId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string MenuId
        {
            get { return _menuId ?? string.Empty; }
            set { _menuId = value; }
        }
        private string _userId = string.Empty;
        /// <summary>
        /// 
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
        public override MobileUserMenuEntity SetModelValueByDataRow(DataRow dr)
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
        public override MobileUserMenuEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new MobileUserMenuEntity();
            if (fields.Contains(Parm_Mobile_UserMenu_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_Mobile_UserMenu_Id].ToString();
            if (fields.Contains(Parm_Mobile_UserMenu_MenuId) || fields.Contains("*"))
                tmp.MenuId = dr[Parm_Mobile_UserMenu_MenuId].ToString();
            if (fields.Contains(Parm_Mobile_UserMenu_UserId) || fields.Contains("*"))
                tmp.UserId = dr[Parm_Mobile_UserMenu_UserId].ToString();
            if (fields.Contains(Parm_Mobile_UserMenu_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_Mobile_UserMenu_RowStatus].ToString());
            if (fields.Contains(Parm_Mobile_UserMenu_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_Mobile_UserMenu_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_Mobile_UserMenu_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_Mobile_UserMenu_CreatorId].ToString();
            if (fields.Contains(Parm_Mobile_UserMenu_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_Mobile_UserMenu_CreateBy].ToString();
            if (fields.Contains(Parm_Mobile_UserMenu_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Mobile_UserMenu_CreateOn].ToString());
            if (fields.Contains(Parm_Mobile_UserMenu_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_Mobile_UserMenu_UpdateId].ToString();
            if (fields.Contains(Parm_Mobile_UserMenu_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_Mobile_UserMenu_UpdateBy].ToString();
            if (fields.Contains(Parm_Mobile_UserMenu_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Mobile_UserMenu_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="mobile_usermenu">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(MobileUserMenuEntity mobile_usermenu, SqlParameter[] parms)
        {
            parms[0].Value = mobile_usermenu.Id;
            parms[1].Value = mobile_usermenu.MenuId;
            parms[2].Value = mobile_usermenu.UserId;
            parms[3].Value = mobile_usermenu.RowStatus;
            parms[4].Value = mobile_usermenu.CreatorId;
            parms[5].Value = mobile_usermenu.CreateBy;
            parms[6].Value = mobile_usermenu.CreateOn;
            parms[7].Value = mobile_usermenu.UpdateId;
            parms[8].Value = mobile_usermenu.UpdateBy;
            parms[9].Value = mobile_usermenu.UpdateOn;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(MobileUserMenuEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_Mobile_UserMenu_Id, model.Id);
            parms[parms.Length - 1] = new SqlParameter(Parm_Mobile_UserMenu_Version, model.Version);
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Mobile_UserMenu_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_Mobile_UserMenu_Id, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_UserMenu_MenuId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_UserMenu_UserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_UserMenu_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Mobile_UserMenu_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_UserMenu_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_UserMenu_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Mobile_UserMenu_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_UserMenu_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Mobile_UserMenu_UpdateOn, SqlDbType.DateTime, 23)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Mobile_UserMenu_Insert, parms);
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

