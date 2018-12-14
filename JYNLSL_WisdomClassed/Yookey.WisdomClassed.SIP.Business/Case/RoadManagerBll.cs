//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="RoadManagerBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/22 16:26:18
//  功能描述：RoadManager业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// RoadManager业务逻辑
    /// </summary>
    public class RoadManagerBll : BaseBll<RoadManagerEntity>
    {
        public RoadManagerBll()
        {
            BaseDal = new RoadManagerDal();
        }

        /// <summary>
        /// 获取数据列表
        /// 添加人：周 鹏
        /// 添加时间：2014-12-28
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<RoadManagerEntity> GetSearchResult(RoadManagerEntity search)
        {
            try
            {
                var queryCondition = QueryCondition.Instance.AddEqual(RoadManagerEntity.Parm_RoadManager_RowStatus, "1");
                if (!string.IsNullOrEmpty(search.RoadName))
                {
                    queryCondition.AddEqual("left(dbo.f_GetPy(RoadName),1)", search.RoadName);
                }
                if (!string.IsNullOrEmpty(search.RoadNo))
                {
                    queryCondition.AddEqual(RoadManagerEntity.Parm_RoadManager_RoadNo, search.RoadNo);
                }
                queryCondition.AddOrderBy(RoadManagerEntity.Parm_RoadManager_RoadNo, true);
                return Query(queryCondition);
            }
            catch (Exception)
            {
                return new List<RoadManagerEntity>();
            }
        }

        /// <summary>
        /// 请求查询路段
        /// 添加人：周 鹏
        /// 添加时间：2014-12-28
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-03-18 周 鹏 增加按部门编号查询
        /// </history>
        /// <param name="deptId">部门编号</param>
        /// <returns></returns>
        public DataTable GetRoad(string deptId)
        {
            return new RoadManagerDal().GetRoad(deptId);
        }

        /// <summary>
        /// 根据路段名称获取路段代码
        /// 添加人：周 鹏
        /// 添加时间：2015-08-06
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="roadName">路段名称</param>
        /// <returns>System.String.</returns>
        public string GetRoadNoByRoadName(string roadName)
        {
            return new RoadManagerDal().GetRoadNoByRoadName(roadName);
        }
    }
}
