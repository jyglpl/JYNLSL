//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LegislationBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/24 10:22:25
//  功能描述：Legislation业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// 法律法规（违法行为） 业务逻辑
    /// </summary>
    public class LegislationBll : BaseBll<LegislationEntity>
    {
        private LegislationDal _legislationDal = new LegislationDal();

        public LegislationBll()
        {
            BaseDal = new LegislationDal();
        }

        /// <summary>
        /// 数据查询
        /// 添加人：周 鹏
        /// 添加时间：2015-03-24
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<LegislationEntity> GetSearchResult(LegislationEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(LegislationEntity.Parm_Legislation_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.Id))
            {
                queryCondition.AddEqual(LegislationEntity.Parm_Legislation_Id, search.Id);
            }
            if (!string.IsNullOrEmpty(search.ItemNo))
            {
                queryCondition.AddEqual(LegislationEntity.Parm_Legislation_ItemNo, search.ItemNo);
            }
            if (!string.IsNullOrEmpty(search.ItemAct))
            {
                queryCondition.AddLike(LegislationEntity.Parm_Legislation_ItemAct, search.ItemAct);
            }
            if (!string.IsNullOrEmpty(search.ClassNo))
            {
                queryCondition.AddEqual(LegislationEntity.Parm_Legislation_ClassNo, search.ClassNo);
            }
            if (!string.IsNullOrEmpty(search.KeyWords))
            {
                queryCondition.AddLike(LegislationEntity.Parm_Legislation_ItemNo, search.KeyWords);
            }
            //排序
            queryCondition.AddOrderBy(LegislationEntity.Parm_Legislation_OrderNo, true);
            return Query(queryCondition) as List<LegislationEntity>;
        }

        public DataTable GetLegislation(string keywords, int pageIndex, int pageSize)
        {
            int totalRecords;
            var data = _legislationDal.GetLegislation(keywords, pageIndex, pageSize, out totalRecords);
            return data;
        }

        /// <summary>
        /// 查询案件代码、违法行为
        /// 添加人：胡耀锋
        /// 添加时间：2015-05-24
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LegislationEntity get(string id)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(LegislationEntity.Parm_Legislation_Id, id);
            return BaseDal.Query(queryCondition).Count == 0 ? null : BaseDal.Query(queryCondition)[0];
        }

        public bool IsAdd(LegislationEntity punish)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(LegislationEntity.Parm_Legislation_Id, punish.Id);
            return BaseDal.Query(queryCondition).Count == 0 ? true : false;
        }

        /// <summary>
        /// 获取数据列表
        /// 添加人：胡耀锋
        /// 添加时间：2015-05-14
        /// </summary>
        /// <param name="search"></param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public PageJqDatagrid<LegislationEntity> GetSearchResult(LegislationEntity search, int pageSzie = 15, int pageIndex = 1)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(LegislationEntity.Parm_Legislation_RowStatus, "1");

            if (!string.IsNullOrEmpty(search.ItemNo))
            {
                queryCondition.AddLike(LegislationEntity.Parm_Legislation_ItemNo, search.ItemNo);
            }
            if (!string.IsNullOrEmpty(search.ItemAct))
            {
                queryCondition.AddLike(LegislationEntity.Parm_Legislation_ItemAct, search.ItemAct);
            }
            if (search.ItemType != "-999")
            {
                queryCondition.AddEqual(LegislationEntity.Parm_Legislation_ClassNo, search.ItemType);
            }

            //排序
            queryCondition.AddOrderBy(LegislationEntity.Parm_Legislation_OrderNo, true)
                          .AddOrderBy(LegislationEntity.Parm_Legislation_ItemNo, true)
                          .SetPager(pageIndex, pageSzie);
            int totalRecord, totalPage;

            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var list = Query(queryCondition, out totalRecord, out totalPage);
            stopwatch.Stop();

            return new PageJqDatagrid<LegislationEntity>
            {
                page = pageIndex,
                rows = list,
                total = totalPage,
                records = totalRecord,
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
            return _legislationDal.Delete(id);
        }

        /// <summary>
        /// 查询法律法规
        /// 添加人：周 鹏
        /// 添加时间：2015-03-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="qType">查询类型：Legislation,LegislationItem,LegislationGist,LegislationRule</param>
        /// <returns></returns>
        public DataTable MobileQueryLegislation(string qType)
        {
            try
            {
                return new LegislationDal().MobileQueryLegislation(qType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
