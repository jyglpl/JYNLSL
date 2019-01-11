//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LegislationItemBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/24 10:22:25
//  功能描述：LegislationItem业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// 法律法规（适用案由）业务逻辑
    /// </summary>
    public class LegislationItemBll : BaseBll<LegislationItemEntity>
    {
        private LegislationItemDal _legislationItemDal = new LegislationItemDal();
        public LegislationItemBll()
        {
            BaseDal = new LegislationItemDal();
        }

        /// <summary>
        /// 数据查询
        /// 添加人：周 鹏
        /// 添加时间：2015-03-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<LegislationItemEntity> GetSearchResult(LegislationItemEntity search)
        {
            var queryConditon = QueryCondition.Instance.AddEqual(LegislationItemEntity.Parm_LegislationItem_RowStatus, "1");

            if (!string.IsNullOrEmpty(search.LegislationId))
            {
                queryConditon.AddEqual(LegislationItemEntity.Parm_LegislationItem_LegislationId, search.LegislationId);
            }

            return Query(queryConditon) as List<LegislationItemEntity>;
        }

        /// <summary>
        /// 适用案由保存后刷新查询
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public PageJqDatagrid<LegislationItemEntity> QueryToPage(string id, int pageSize = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;
            var data = _legislationItemDal.GetCommonQury(id, pageSize, pageIndex, out totalRecords);

            var list = ConvertListHelper<LegislationItemEntity>.ConvertToList(data);

            stopwatch.Stop();
            var totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
            return new PageJqDatagrid<LegislationItemEntity>
            {
                page = pageIndex,
                rows = list,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            return _legislationItemDal.Delete(id);
        }


        /// <summary>
        /// 删除案由数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteAnyou(string id)
        {
            return _legislationItemDal.DeleteAnyou(id);
        }
    }
}
