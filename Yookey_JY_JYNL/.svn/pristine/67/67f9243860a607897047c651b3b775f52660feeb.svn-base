//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComMenuBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/1/3 8:51:48
//  功能描述：ComMenu业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Globalization;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Business.Com
{
    /// <summary>
    /// ComMenu业务逻辑
    /// </summary>
    public class ComMenuBll : BaseBll<ComMenuEntity>
    {
        public ComMenuBll()
        {
            BaseDal = new ComMenuDal();
        }

        /// <summary>
        /// 重写新增方法
        /// 添加人：周 鹏
        /// 添加时间：2014-03-28
        /// </summary>
        /// <param name="model">菜单实体类</param>
        /// <returns></returns>
        public override ComMenuEntity Add(ComMenuEntity model)
        {
            if (string.IsNullOrEmpty(model.ParentMenuId))
            {
                model.ParentMenuId = "0000";
            }
            var menuId = new ComMenuDal().GetMenuMaxId(model.ParentMenuId);
            model.Id = menuId;
            return base.Add(model);
        }



        /// <summary>
        /// 判断是否包含该菜单
        /// 添加人：张晖
        /// 添加时间：2014-04-11
        /// </summary>
        /// <param name="menu">菜单</param>
        /// <param name="menus">菜单集合</param>
        /// <returns></returns>
        public static bool IsEqualMenu(ComMenuEntity menu, List<ComMenuEntity> menus)
        {
            foreach (ComMenuEntity item in menus)
            {
                if (item.Id.Equals(menu.Id))
                {
                    return true;
                }

            }
            return false;
        }



        /// <summary>
        /// 获取菜单列表
        /// 添加人：周 鹏
        /// 添加时间：2014-01-03
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="search">查询实体</param>
        /// <param name="pageSzie">分页大小</param>
        /// <param name="pageIndex">页面索引</param>
        /// <returns></returns>
        public Page<ComMenuEntity> GetSearchResult(ComMenuEntity search, int pageSzie = 15, int pageIndex = 1)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(ComMenuEntity.Parm_ComMenu_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ParentMenuId))
            {
                //queryCondition.AddOr(OrCondition.Instance.AddEqual(ComMenuEntity.Parm_ComMenu_Id, search.ParentMenuId));
                queryCondition.AddOr(OrCondition.Instance.AddEqual(ComMenuEntity.Parm_ComMenu_ParentMenuId, search.ParentMenuId));
            }
            if (!string.IsNullOrEmpty(search.MenuName))
            {
                queryCondition.AddLike(ComMenuEntity.Parm_ComMenu_MenuName, search.MenuName);
            }
            if (search.MenuLevel > 0)
            {
                queryCondition.AddEqual(ComMenuEntity.Parm_ComMenu_MenuLevel, search.MenuLevel.ToString(CultureInfo.InvariantCulture));
            }

            //排序
            queryCondition.AddOrderBy(ComMenuEntity.Parm_ComMenu_MenuLevel, true).AddOrderBy(ComMenuEntity.Parm_ComMenu_SortCode, true).SetPager(pageIndex, pageSzie);
            int totalRecord, totalPage;
            var list = Query(queryCondition, out totalRecord, out totalPage);
            return new Page<ComMenuEntity>
                {
                    CurrentPage = pageIndex,
                    Items = list,
                    PageSize = pageSzie,
                    TotalPages = totalPage,
                    TotalRecords = totalRecord
                };
        }

        /// <summary>
        /// 获取所有菜单
        /// 添加人：周 鹏
        /// 添加时间：2014-01-03
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// edit by lpl
        /// 2019-1-2
        /// 19年的第一段代码
        /// </hisotry> 
        /// <param name="search">查询实体</param> 
        /// <returns></returns>
        public List<ComMenuEntity> GetAllMenu(ComMenuEntity search,bool isAdmin = false)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(ComMenuEntity.Parm_ComMenu_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.MenuName))
            {
                queryCondition.AddLike(ComMenuEntity.Parm_ComMenu_MenuName, search.MenuName);
            }
            if (!string.IsNullOrEmpty(search.ParentMenuId))
            {
                queryCondition.AddEqual(ComMenuEntity.Parm_ComMenu_ParentMenuId, search.ParentMenuId);
            }
            if (!string.IsNullOrEmpty(search.Id))
            {
                queryCondition.AddLike(ComMenuEntity.Parm_ComMenu_Id, search.Id);
            }

            //排除功能
            if (search.IsMenu == 1)
            {
                queryCondition.AddEqual(ComMenuEntity.Parm_ComMenu_IsMenu,Convert.ToString(search.IsMenu));
            }

            if (isAdmin == false)
            {
                queryCondition.AddNotEqual(ComMenuEntity.Parm_ComMenu_ParentMenuId, "0000110008");
                queryCondition.AddNotEqual(ComMenuEntity.Parm_ComMenu_Id, "0000110008");
            }


            //排序
            queryCondition.AddOrderBy(ComMenuEntity.Parm_ComMenu_MenuLevel, true)
                          .AddOrderBy(ComMenuEntity.Parm_ComMenu_SortCode, true);

            return Query(queryCondition) as List<ComMenuEntity>;
        }

        /// <summary>
        /// 获取所有菜单级别小于menuLevel的菜单
        /// 添加人：周 鹏
        /// 添加时间：2014-01-03
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="menuLevel">菜单级别（menuLevel小于等于1则获取所菜单)</param>
        /// <param name="operateType">操作类型(1:等于 2：小于 4：大于 3：小于等于 5：大于等于)</param>
        /// <returns></returns>
        public List<ComMenuEntity> GetAllMenu(int menuLevel = 1, int operateType = 1)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(ComMenuEntity.Parm_ComMenu_RowStatus, "1");
            switch (operateType)
            {
                case 2:
                    queryCondition.AddSmaller(ComMenuEntity.Parm_ComMenu_MenuLevel, menuLevel.ToString());
                    break;
                case 3:
                    queryCondition.AddEqualSmaller(ComMenuEntity.Parm_ComMenu_MenuLevel, menuLevel.ToString());
                    break;
                case 4:
                    queryCondition.AddLarger(ComMenuEntity.Parm_ComMenu_MenuLevel, menuLevel.ToString());
                    break;
                case 5:
                    queryCondition.AddEqualLarger(ComMenuEntity.Parm_ComMenu_MenuLevel, menuLevel.ToString());
                    break;
                default: queryCondition.AddEqual(ComMenuEntity.Parm_ComMenu_MenuLevel, menuLevel.ToString());
                    break;
            }
            return Query(queryCondition) as List<ComMenuEntity>;
        }


        /// <summary>
        /// 获取用户菜单
        /// 添加人：周 鹏
        /// 添加时间：2014-01-03
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="userid">用户Id</param>
        /// <returns></returns>
        public List<ComMenuEntity> GetUserMenus(string userid)
        {
            return new ComMenuDal().GetUserMenus(userid);
        }


        /// <summary>
        /// 获取用户所有菜单，以,分隔，字符格式为,Controller_Action_1,
        /// 用于页面权限判断
        /// 添加人：周 鹏
        /// 添加时间：2013-09-10
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="currentUserId">当前用户Id</param>
        /// <param name="controllername">Controller Name</param>
        /// <returns></returns>
        public string GetUserMenus(string currentUserId, string controllername)
        {
            return new ComMenuDal().GetUserMenus(currentUserId, controllername);
        }

        /// <summary>
        /// 获取角色菜单
        /// 添加人：周 鹏
        /// 添加时间：2014-01-03
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="roleId">角色Id</param>
        /// <returns></returns>
        public List<ComMenuEntity> GetRoleMenus(string roleId)
        {
            return new ComMenuDal().GetRoleMenus(roleId);
        }

        /// <summary>
        /// 批量删除菜单
        /// 添加人：周 鹏
        /// 添加时间：2014-01-03
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="menuIds">菜单Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDeleteMenu(string menuIds)
        {
            return new ComMenuDal().BatchDeleteMenu(menuIds);
        }
    }
}
