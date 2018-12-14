//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComMenuEntity.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/9 18:25:33
//  功能描述：ComMenu表实体
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model.Com
{
    /// <summary>
    /// 菜单、按钮
    /// </summary>
    [Serializable]
    public class ComMenuEntity : ModelImp.BaseModel<ComMenuEntity>
    {
        public ComMenuEntity()
        {
            TB_Name = TB_ComMenu;
            Parm_Id = Parm_ComMenu_Id;
            Parm_Version = Parm_ComMenu_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_ComMenu_Insert;
            Sql_Update = Sql_ComMenu_Update;
            Sql_Delete = Sql_ComMenu_Delete;
        }
        #region Const of table ComMenu
        /// <summary>
        /// Table ComMenu
        /// </summary>
        public const string TB_ComMenu = "ComMenu";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm Action
        /// </summary>
        public const string Parm_ComMenu_Action = "Action";
        /// <summary>
        /// Parm Controller
        /// </summary>
        public const string Parm_ComMenu_Controller = "Controller";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_ComMenu_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_ComMenu_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_ComMenu_CreatorId = "CreatorId";
        /// <summary>
        /// Parm IconPic
        /// </summary>
        public const string Parm_ComMenu_IconPic = "IconPic";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_ComMenu_Id = "Id";
        /// <summary>
        /// Parm IsMenu
        /// </summary>
        public const string Parm_ComMenu_IsMenu = "IsMenu";
        /// <summary>
        /// Parm MenuDesc
        /// </summary>
        public const string Parm_ComMenu_MenuDesc = "MenuDesc";
        /// <summary>
        /// Parm MenuLevel
        /// </summary>
        public const string Parm_ComMenu_MenuLevel = "MenuLevel";
        /// <summary>
        /// Parm MenuName
        /// </summary>
        public const string Parm_ComMenu_MenuName = "MenuName";
        /// <summary>
        /// Parm MenuUrl
        /// </summary>
        public const string Parm_ComMenu_MenuUrl = "MenuUrl";
        /// <summary>
        /// Parm OpenType
        /// </summary>
        public const string Parm_ComMenu_OpenType = "OpenType";
        /// <summary>
        /// Parm ParentMenuId
        /// </summary>
        public const string Parm_ComMenu_ParentMenuId = "ParentMenuId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_ComMenu_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SortCode
        /// </summary>
        public const string Parm_ComMenu_SortCode = "SortCode";
        /// <summary>
        /// Parm Source
        /// </summary>
        public const string Parm_ComMenu_Source = "Source";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_ComMenu_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_ComMenu_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_ComMenu_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_ComMenu_Version = "Version";
        /// <summary>
        /// Insert Query Of ComMenu
        /// </summary>
        public const string Sql_ComMenu_Insert = "insert into ComMenu(Action,Controller,CreateBy,CreateOn,CreatorId,IconPic,IsMenu,MenuDesc,MenuLevel,MenuName,MenuUrl,OpenType,ParentMenuId,RowStatus,SortCode,UpdateBy,UpdateId,UpdateOn,Id) values(@Action,@Controller,@CreateBy,@CreateOn,@CreatorId,@IconPic,@IsMenu,@MenuDesc,@MenuLevel,@MenuName,@MenuUrl,@OpenType,@ParentMenuId,@RowStatus,@SortCode,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of ComMenu
        /// </summary>
        public const string Sql_ComMenu_Update = "update ComMenu set Action=@Action,Controller=@Controller,CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,IconPic=@IconPic,IsMenu=@IsMenu,MenuDesc=@MenuDesc,MenuLevel=@MenuLevel,MenuName=@MenuName,MenuUrl=@MenuUrl,OpenType=@OpenType,ParentMenuId=@ParentMenuId,RowStatus=@RowStatus,SortCode=@SortCode,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_ComMenu_Delete = "update ComMenu set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _menuName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string MenuName
        {
            get { return _menuName ?? string.Empty; }
            set { _menuName = value; }
        }
        private string _parentMenuId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ParentMenuId
        {
            get { return _parentMenuId ?? string.Empty; }
            set { _parentMenuId = value; }
        }
        private string _controller = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Controller
        {
            get { return _controller ?? string.Empty; }
            set { _controller = value; }
        }
        private string _action = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Action
        {
            get { return _action ?? string.Empty; }
            set { _action = value; }
        }
        private string _menuUrl = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string MenuUrl
        {
            get { return _menuUrl ?? string.Empty; }
            set { _menuUrl = value; }
        }
        private int _menuLevel;
        /// <summary>
        /// 
        /// </summary>
        public int MenuLevel
        {
            get { return _menuLevel; }
            set { _menuLevel = value; }
        }
        private int _isMenu;
        /// <summary>
        /// 
        /// </summary>
        public int IsMenu
        {
            get { return _isMenu; }
            set { _isMenu = value; }
        }
        private string _menuDesc = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string MenuDesc
        {
            get { return _menuDesc ?? string.Empty; }
            set { _menuDesc = value; }
        }
        private string _iconPic = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string IconPic
        {
            get { return _iconPic ?? string.Empty; }
            set { _iconPic = value; }
        }
        private int _openType;
        /// <summary>
        /// 
        /// </summary>
        public int OpenType
        {
            get { return _openType; }
            set { _openType = value; }
        }
        private int _sortCode;
        /// <summary>
        /// 
        /// </summary>
        public int SortCode
        {
            get { return _sortCode; }
            set { _sortCode = value; }
        }
        private int _source;
        /// <summary>
        /// 
        /// </summary>
        public int Source
        {
            get { return _source; }
            set { _source = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override ComMenuEntity SetModelValueByDataRow(DataRow dr)
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
        public override ComMenuEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComMenuEntity();
            if (dr.Table.Columns.Contains(Parm_ComMenu_Id))
                tmp.Id = dr[Parm_ComMenu_Id].ToString();
            if (dr.Table.Columns.Contains(Parm_ComMenu_MenuName))
                tmp.MenuName = dr[Parm_ComMenu_MenuName].ToString();
            if (dr.Table.Columns.Contains(Parm_ComMenu_ParentMenuId))
                tmp.ParentMenuId = dr[Parm_ComMenu_ParentMenuId].ToString();
            if (dr.Table.Columns.Contains(Parm_ComMenu_Controller))
                tmp.Controller = dr[Parm_ComMenu_Controller].ToString();
            if (dr.Table.Columns.Contains(Parm_ComMenu_Action))
                tmp.Action = dr[Parm_ComMenu_Action].ToString();
            if (dr.Table.Columns.Contains(Parm_ComMenu_MenuUrl))
                tmp.MenuUrl = dr[Parm_ComMenu_MenuUrl].ToString();
            if (dr.Table.Columns.Contains(Parm_ComMenu_MenuLevel))
                tmp.MenuLevel = int.Parse(dr[Parm_ComMenu_MenuLevel].ToString());
            if (dr.Table.Columns.Contains(Parm_ComMenu_IsMenu))
                tmp.IsMenu = int.Parse(dr[Parm_ComMenu_IsMenu].ToString());
            if (dr.Table.Columns.Contains(Parm_ComMenu_MenuDesc))
                tmp.MenuDesc = dr[Parm_ComMenu_MenuDesc].ToString();
            if (dr.Table.Columns.Contains(Parm_ComMenu_IconPic))
                tmp.IconPic = dr[Parm_ComMenu_IconPic].ToString();
            if (dr.Table.Columns.Contains(Parm_ComMenu_OpenType))
                tmp.OpenType = int.Parse(dr[Parm_ComMenu_OpenType].ToString());
            if (dr.Table.Columns.Contains(Parm_ComMenu_SortCode))
                tmp.SortCode = int.Parse(dr[Parm_ComMenu_SortCode].ToString());
            if (dr.Table.Columns.Contains(Parm_ComMenu_Source))
                tmp.Source = int.Parse(dr[Parm_ComMenu_Source].ToString());
            if (dr.Table.Columns.Contains(Parm_ComMenu_RowStatus))
                tmp.RowStatus = int.Parse(dr[Parm_ComMenu_RowStatus].ToString());
            if (dr.Table.Columns.Contains(Parm_ComMenu_Version))
            {
                var bts = (byte[])(dr[Parm_ComMenu_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (dr.Table.Columns.Contains(Parm_ComMenu_CreatorId))
                tmp.CreatorId = dr[Parm_ComMenu_CreatorId].ToString();
            if (dr.Table.Columns.Contains(Parm_ComMenu_CreateBy))
                tmp.CreateBy = dr[Parm_ComMenu_CreateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_ComMenu_CreateOn))
                tmp.CreateOn = DateTime.Parse(dr[Parm_ComMenu_CreateOn].ToString());
            if (dr.Table.Columns.Contains(Parm_ComMenu_UpdateId))
                tmp.UpdateId = dr[Parm_ComMenu_UpdateId].ToString();
            if (dr.Table.Columns.Contains(Parm_ComMenu_UpdateBy))
                tmp.UpdateBy = dr[Parm_ComMenu_UpdateBy].ToString();
            if (dr.Table.Columns.Contains(Parm_ComMenu_UpdateOn))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_ComMenu_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="commenu">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(ComMenuEntity commenu, SqlParameter[] parms)
        {
            parms[0].Value = commenu.MenuName;
            parms[1].Value = commenu.ParentMenuId;
            parms[2].Value = commenu.Controller;
            parms[3].Value = commenu.Action;
            parms[4].Value = commenu.MenuUrl;
            parms[5].Value = commenu.MenuLevel;
            parms[6].Value = commenu.IsMenu;
            parms[7].Value = commenu.MenuDesc;
            parms[8].Value = commenu.IconPic;
            parms[9].Value = commenu.OpenType;
            parms[10].Value = commenu.SortCode;
            parms[11].Value = commenu.Source;
            parms[12].Value = commenu.RowStatus;
            parms[13].Value = commenu.CreatorId;
            parms[14].Value = commenu.CreateBy;
            parms[15].Value = commenu.CreateOn;
            parms[16].Value = commenu.UpdateId;
            parms[17].Value = commenu.UpdateBy;
            parms[18].Value = commenu.UpdateOn;
            parms[19].Value = commenu.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(ComMenuEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            var parsAll = new SqlParameter[parms.Length - 2];
            for (int i = 0; i < parsAll.Length; i++)
            {
                parsAll[i] = parms[i];
            }
            return parsAll;
        }

        /// <summary>
        /// 获取一个给SQL语句传参用的参数集合
        /// </summary>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] GetParms()
        {
            try
            {
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite,
                                                                          Sql_ComMenu_Insert);
                if (parms == null)
                {
                    parms = new[]
                        {
                            new SqlParameter(Parm_ComMenu_MenuName, SqlDbType.NVarChar, 100),
                            new SqlParameter(Parm_ComMenu_ParentMenuId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComMenu_Controller, SqlDbType.NVarChar, 100),
                            new SqlParameter(Parm_ComMenu_Action, SqlDbType.NVarChar, 100),
                            new SqlParameter(Parm_ComMenu_MenuUrl, SqlDbType.NVarChar, 200),
                            new SqlParameter(Parm_ComMenu_MenuLevel, SqlDbType.Int, 10),
                            new SqlParameter(Parm_ComMenu_IsMenu, SqlDbType.Int, 10),
                            new SqlParameter(Parm_ComMenu_MenuDesc, SqlDbType.NVarChar, 200),
                            new SqlParameter(Parm_ComMenu_IconPic, SqlDbType.NVarChar, 100),
                            new SqlParameter(Parm_ComMenu_OpenType, SqlDbType.Int, 10),
                            new SqlParameter(Parm_ComMenu_SortCode, SqlDbType.Int, 10),
                            new SqlParameter(Parm_ComMenu_Source, SqlDbType.Int, 10),
                            new SqlParameter(Parm_ComMenu_RowStatus, SqlDbType.Int, 10),
                            new SqlParameter(Parm_ComMenu_CreatorId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComMenu_CreateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComMenu_CreateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_ComMenu_UpdateId, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComMenu_UpdateBy, SqlDbType.NVarChar, 50),
                            new SqlParameter(Parm_ComMenu_UpdateOn, SqlDbType.DateTime, 23),
                            new SqlParameter(Parm_ComMenu_Id, SqlDbType.NVarChar, 50)

                        };
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComMenu_Insert, parms);
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

