//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LegislationGistBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/24 10:22:25
//  功能描述：LegislationGist业务逻辑类
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
    /// 法律法规（法律条文）业务逻辑
    /// </summary>
    public class LegislationGistBll : BaseBll<LegislationGistEntity>
    {
        private LegislationGistDal _legislationGistDal = new LegislationGistDal();

        public LegislationGistBll()
        {
            BaseDal = new LegislationGistDal();
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
        public List<LegislationGistEntity> GetSearchResult(LegislationGistEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(LegislationGistEntity.Parm_LegislationGist_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.LegislationItemId))
            {
                queryCondition.AddEqual(LegislationGistEntity.Parm_LegislationGist_LegislationItemId, search.LegislationItemId);
            }

            return Query(queryCondition) as List<LegislationGistEntity>;
        }


        /// <summary>
        /// 根据审批的步骤,获取默认意见
        /// 添加人：周 鹏
        /// 添加时间：2015-03-30
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="formId">案件编号</param>
        /// <param name="etype">所属类型</param>
        /// <param name="gistId">主键编号</param>
        /// <returns></returns>
        public string GetDefaultIdeal(string formId, string etype, string gistId)
        {
            var punishEntity = Get(gistId);
            if (punishEntity != null && etype.Equals("立案审批"))
            {
                return punishEntity.ReOpinion;
            }
            if (punishEntity != null && etype.Equals("处理审批"))
            {
                var opinion = punishEntity.HaOpinion;
                if (opinion.Contains("${Money}"))
                {
                    var infpunishitem = new InfPunishLegislatioinBll().GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = formId });
                    if (infpunishitem.Count > 0)
                    {
                        opinion = opinion.Replace("${Money}", CommonMethod.MoneyToUpper(infpunishitem[0].PunishAmount.ToString()));
                    }
                }
                return opinion;
            }
            if (punishEntity != null && etype.Equals("结案审批"))
            {
                return punishEntity.EndOpinion;
            }
            return "";
        }

        /// <summary>
        /// 适用案由保存后刷新查询
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public PageJqDatagrid<LegislationGistEntity> QueryToPage(string id, int pageSize = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;
            var data = _legislationGistDal.GetCommonQury(id, pageSize, pageIndex, out totalRecords);

            var list = ConvertListHelper<LegislationGistEntity>.ConvertToList(data);

            stopwatch.Stop();
            var totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
            return new PageJqDatagrid<LegislationGistEntity>
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
            return _legislationGistDal.Delete(id);
        }

        /// <summary>
        /// 删除案由数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteGist(string id)
        {
            return _legislationGistDal.DeleteGist(id);
        }
    }
}
