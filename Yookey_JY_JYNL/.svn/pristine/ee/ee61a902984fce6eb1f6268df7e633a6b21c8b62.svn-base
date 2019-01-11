//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComResourceBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-02
//  功能描述：ComResource业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;
using System.Linq;
namespace Yookey.WisdomClassed.SIP.Business.Com
{
    /// <summary>
    /// ComResource业务逻辑
    /// </summary>
    public class ComResourceBll : BaseBll<ComResourceEntity>
    {
        public ComResourceBll()
        {
            BaseDal = new ComResourceDal();
        }


        /// <summary>
        /// 根据父编号查询出所有数据
        /// 添加人：周 鹏
        /// 添加时间：2014-01-03
        /// </summary>
        /// <history>
        ///  修改描述：时间+作者+描述
        /// </history>
        /// <param name="parentid">父编号</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">分页索引</param>
        /// <returns></returns>
        public Page<ComResourceEntity> GetResource(string parentid, int pageSize, int pageIndex)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(ComResourceEntity.Parm_ComResource_RowStatus, "1");
            if (!string.IsNullOrEmpty(parentid))
            {
                queryCondition.AddEqual(ComResourceEntity.Parm_ComResource_ParentId, parentid);
            }
            queryCondition.AddOrderBy(ComResourceEntity.Parm_ComResource_OrderNo, true);
            int totalRecord, totalPage;
            var list = Query(queryCondition, out totalRecord, out totalPage) as List<ComResourceEntity>;
            return new Page<ComResourceEntity>
                {
                    CurrentPage = pageIndex,
                    Items = list,
                    PageSize = pageSize,
                    TotalPages = totalPage,
                    TotalRecords = totalRecord
                };
        }

        /// <summary>
        /// 获取数据列表
        /// 添加人：周 鹏
        /// 添加时间：2014-03-28
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<ComResourceEntity> GetSearchResult(ComResourceEntity search)
        {
            try
            {
                var queryCondition = QueryCondition.Instance.AddEqual(ComMenuEntity.Parm_ComMenu_RowStatus, "1");
                if (!string.IsNullOrEmpty(search.ParentId))
                {
                    queryCondition.AddEqual(ComResourceEntity.Parm_ComResource_ParentId, search.ParentId);
                }
                if (!string.IsNullOrEmpty(search.RsValue))
                {
                    queryCondition.AddEqual(ComResourceEntity.Parm_ComResource_RsValue, search.RsValue);
                }
                if (!string.IsNullOrEmpty(search.RsKey))
                {
                    queryCondition.AddEqual(ComResourceEntity.Parm_ComResource_RsKey, search.RsKey);
                }
                if (!string.IsNullOrEmpty(search.Id))
                {
                    queryCondition.AddEqual(ComResourceEntity.Parm_ComResource_Id, search.Id);
                }
                //排序
                queryCondition.AddOrderBy(ComResourceEntity.Parm_ComResource_OrderNo, true);
                return Query(queryCondition);
            }
            catch (Exception)
            {
                return new List<ComResourceEntity>();
            }
        }


        /// <summary>
        /// 根据父编号查询最大的编号
        /// 添加人：周 鹏
        /// 添加时间：2014-01-03
        /// </summary>
        /// <history>
        ///  修改描述：时间+作者+描述
        /// </history>
        /// <param name="parentId">父编号</param>
        /// <returns></returns>
        public string GetMaxId(string parentId)
        {
            return new ComResourceDal().GetMaxId(parentId);
        }

        /// <summary>
        /// 查询Resources 根据父编号
        /// 添加人：叶 念
        /// 添加时间：2014-04-03
        /// </summary>
        /// <param name="parentid"></param>
        /// <returns></returns>
        public DataTable GetResources(string parentid)
        {
            return new ComResourceDal().GetResources(parentid);
        }

        /// <summary>
        /// 查询所有的子系统账号 根据用户ID
        /// 添加人：叶 念
        /// 添加时间：2014-04-08
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public DataTable GetResourcesByUserid(string userid)
        {
            return new ComResourceDal().GetResourcesByUserid(userid);
        }

        /// <summary>
        /// 根据ID模糊查询字典信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ComResourceEntity> GetResourceLikeId(string id)
        {
            return new ComResourceDal().GetResourceLikeId(id);
        }

        /// <summary>
        /// 获取Resources 查询Resources 根据父编号
        /// 添加人：周 鹏
        /// 添加时间：2015-01-26
        /// </summary>
        /// <history>
        ///  修改描述：时间+作者+描述
        /// </history>
        /// <param name="parentid">父编号</param>
        /// <returns></returns>
        public List<ComResourceEntity> GetResourcesByParentId(string parentid)
        {
            return new ComResourceDal().GetResourcesByParentId(parentid);
        }

        /// <summary>
        /// 批量删除数据
        /// 添加人：周 鹏
        /// 添加时间：2015-01-26
        /// </summary>
        /// <param name="ids">数据Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            return new ComResourceDal().BatchDelete(ids);
        }


        public List<TreeNode> ChildResour(IEnumerable<ComResourceEntity> comresours, string parentId)
        {
            var baseResourceEntities = comresours as ComResourceEntity[] ?? comresours.ToArray();
            var childList = baseResourceEntities.Where(t => t.ParentId == parentId).ToList();

            var list = new List<TreeNode>();
            foreach (var comresourEntity in childList)
            {
                var childs = ChildResour(baseResourceEntities, comresourEntity.Id);
                list.Add(new TreeNode()
                {
                    id = comresourEntity.Id,
                    text = comresourEntity.RsKey,
                    value = "comresour",
                    img = "/Content/Images/Icon16/hostname.png",//tree.js处理路径
                    showcheck = false,
                    isexpand = false,
                    complete = true,
                    hasChildren = childs.Count > 0,
                    ChildNodes = childs
                });
            }
            return list;
        }

        /// <summary>
        /// 根据ParentId获取字典列表
        /// 添加人：zhoulj
        /// 添加时间：2018-09-21
        /// </summary>
        public List<ComResourceEntity> GetListBy(string parentId, string PK_ID)
        {
            return new ComResourceDal().GetListBy(parentId, PK_ID);
        }

        /// <summary>
        /// 模糊查询获取字典列表
        /// 添加人：zhoulj
        /// 添加时间：2018-09-21
        /// </summary>
        public List<ComResourceEntity> GetListLikePk_Id(string PK_ID)
        {
            return new ComResourceDal().GetListLikePk_Id(PK_ID);
        }

        /// <summary>
        /// 获取数据列表
        /// 添加人：machao
        /// 添加时间：2018-09-11
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        //public IList<ComResourceEntity> GetSearchResult(ComResourceEntity search)
        //{
        //    return new ComResourceDal().GetSearchResult(search);
        //}

        /// <summary>
        /// 根据ParentId获取字典列表
        /// 添加人：zhoulj
        /// 添加时间：2018-09-18
        /// </summary>
        public List<ComResourceEntity> GetListByParentId(string parentId)
        {
            return new ComResourceDal().GetListByParentId(parentId);
        }



        public class TreeNode
        {
            public string id { get; set; }
            public string text { get; set; }
            public string value { get; set; }
            /// <summary>
            /// URL
            /// </summary>
            public string Location { get; set; }
            public string parentnodes { get; set; }
            /// <summary>
            /// 类型
            /// </summary>
            public string type { get; set; }
            public string img { get; set; }
            /// <summary>
            /// 是否显示多选
            /// </summary>
            public bool showcheck { get; set; }

            /// <summary>
            /// 选中状态 0：不选 1：全选 2：半选
            /// 创建人：周庆
            /// 创建日期：2015年5月15日
            /// </summary>
            public int checkstate { get; set; }
            /// <summary>
            /// 是否展开
            /// </summary>
            public bool isexpand { get; set; }
            public bool complete { get; set; }
            public bool hasChildren { get; set; }
            public List<TreeNode> ChildNodes { get; set; }
        }
    }
}
