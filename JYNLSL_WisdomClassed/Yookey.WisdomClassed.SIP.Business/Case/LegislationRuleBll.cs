//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LegislationRuleBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/24 10:22:25
//  功能描述：LegislationRule业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

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
    /// 法律法规（处罚标准）业务逻辑
    /// </summary>
    public class LegislationRuleBll : BaseBll<LegislationRuleEntity>
    {
        private LegislationRuleDal _legislationRuleDal = new LegislationRuleDal();

        public LegislationRuleBll()
        {
            BaseDal = new LegislationRuleDal();
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
        public List<LegislationRuleEntity> GetSearchResult(LegislationRuleEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(LegislationRuleEntity.Parm_LegislationRule_RowStatus,
                                                                  "1");
            if (!string.IsNullOrEmpty(LegislationRuleEntity.Parm_LegislationRule_LegislationId))
            {
                queryCondition.AddEqual(LegislationRuleEntity.Parm_LegislationRule_LegislationId,
                                        search.LegislationId);
            }
            queryCondition.AddOrderBy(LegislationRuleEntity.Parm_LegislationRule_OrderNo, true);
            return Query(queryCondition) as List<LegislationRuleEntity>;
        }

        public PageJqDatagrid<LegislationRuleEntity> QueryToPage(string id, int pageSize = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;
            var data = _legislationRuleDal.GetCommonQury(id, pageSize, pageIndex, out totalRecords);

            var list = ConvertListHelper<LegislationRuleEntity>.ConvertToList(data);

            stopwatch.Stop();
            var totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
            return new PageJqDatagrid<LegislationRuleEntity>
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
           return  _legislationRuleDal.Delete(id);
        }

        /// <summary>
        /// 删除处罚依据数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteRule(string id)
        {
            return _legislationRuleDal.DeleteRule(id);
        }
    }
}
