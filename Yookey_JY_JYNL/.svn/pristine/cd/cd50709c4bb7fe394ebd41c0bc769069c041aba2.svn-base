//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="PunishmentBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：城程游
//  作    者：周 鹏
//  创建日期：2017/11/30 13:27:37
//  功能描述：Punishment业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// Punishment业务逻辑
    /// </summary>
    public class PunishmentBll : BaseBll<PunishmentEntity>
    {
        public PunishmentBll()
        {
            BaseDal = new PunishmentDal();
        }

        /// <summary>
        /// 处罚公示数据查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<PunishmentEntity> GetSearchResult(PunishmentEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(PunishmentEntity.Parm_Punishment_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.CardType) && !string.IsNullOrEmpty(search.CF_HM))
            {
                if (search.CardType.Contains("身份证"))
                {
                    queryCondition.AddEqual(PunishmentEntity.Parm_Punishment_CF_XDR_SFZ, search.CF_HM);
                }
                if (search.CardType.Contains("组织机构代码"))
                {
                    queryCondition.AddEqual(PunishmentEntity.Parm_Punishment_CF_XDR_ZDM, search.CF_HM);
                }
                if (search.CardType.Contains("社会信用代码"))
                {
                    queryCondition.AddEqual(PunishmentEntity.Parm_Punishment_CF_XDR_SHXYM, search.CF_HM);
                }
                if (search.CardType.Contains("工商登记"))
                {
                    queryCondition.AddEqual(PunishmentEntity.Parm_Punishment_CF_XDR_GSDJ, search.CF_HM);
                }
            }
            queryCondition.AddOrderBy(PunishmentEntity.Parm_Punishment_CreateOn, true);
            return Query(queryCondition) as List<PunishmentEntity>;
        }

        /// <summary>
        /// 处罚公示数据查询
        /// </summary>
        /// <history>
        /// </history>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryPunishmentlist(string keyword, int pageSize,
                                       int pageIndex, string sidx, string sord)
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                int totalRecords;
                var data = new PunishmentDal().QueryPunishmentlist(keyword, pageSize, pageIndex, sidx, sord, out totalRecords);
                data.TableName = "CaseDT";
                stopwatch.Stop();
                var totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
                return new PageJqDatagrid<DataTable>
                {
                    page = pageIndex,
                    rows = data,
                    total = totalPage,
                    records = totalRecords,
                    costtime = stopwatch.ElapsedMilliseconds.ToString()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 批量保存处罚公示数据
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public bool TransactionSavePunishment(List<PunishmentEntity> lists)
        {
            try
            {
                return new PunishmentDal().TransactionSavePunishment(lists);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 从处罚系统中同步处罚的数据
        /// </summary>
        /// <returns></returns>
        public bool SyncPunishmentFormSystem()
        {
            try
            {
                var punishmentData = new InfPunishCaseinfoDal().GetUnPublicPunishment();   //获取未同步的处罚数据
                if (punishmentData != null && punishmentData.Rows.Count > 0)
                {
                    var list = (from DataRow row in punishmentData.Rows
                                select new PunishmentEntity()
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    CASEINFOID = row["Id"].ToString(),
                                    CASEINFONO = row["CaseInfoNo"].ToString(),
                                    CF_WSH = row["CF_WSH"].ToString(),
                                    CF_AJMC = row["CF_AJMC"].ToString(),
                                    CF_BM = row["CF_BM"].ToString(),
                                    CF_CFLB1 = row["CF_CFLB1"].ToString(),
                                    CF_CFLB2 = row["CF_CFLB2"].ToString(),
                                    CF_SY = row["CF_SY"].ToString(),
                                    CF_YJ = row["CF_YJ"].ToString(),
                                    CF_XDR_MC = row["CF_XDR_MC"].ToString(),
                                    CF_XDR_SHXYM = row["CF_XDR_SHXYM"].ToString(),
                                    CF_XDR_ZDM = row["CF_XDR_ZDM"].ToString(),
                                    CF_XDR_GSDJ = row["CF_XDR_GSJD"].ToString(),
                                    CF_XDR_SWDJ = row["CF_XDR_SWDJ"].ToString(),
                                    CF_XDR_SFZ = row["CF_XDR_SFZ"].ToString(),
                                    CF_FR = row["CF_FR"].ToString(),
                                    CF_JG = row["CF_JG"].ToString(),
                                    CF_JDRQ = Convert.ToDateTime(row["FileDate"].ToString()),
                                    CF_XZJG = row["CFJG"].ToString(),
                                    CF_ZT = row["ZT"].ToString(),
                                    DFBM = "320508",
                                    SJC = DateTime.Now,
                                    BZ = row["BZ"].ToString(),
                                    CF_SYFW = row["FW"].ToString(),
                                    CF_SXYZCD = row["SXDJ"].ToString(),
                                    CF_GSJZQ = Convert.ToDateTime("1900-01-01"),
                                    WhetherPublic = 1,
                                    IsPush = 0,
                                    RowStatus = 1,
                                    CreateOn = DateTime.Now,
                                    UpdateOn = DateTime.Now
                                }).ToList();

                    return TransactionSavePunishment(list);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 推送处罚公示数据
        /// </summary>
        /// <returns></returns>
        public bool PushPunishment()
        {
            try
            {
                var punishmentData = new PunishmentDal().GetUnPushPunishments();
                return new PunishmentDal().TransactionPushPunishment(punishmentData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
