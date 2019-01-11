using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.SealUp;

namespace Yookey.WisdomClassed.SIP.DataAccess.SealUp
{
    /// <summary>
    /// SealUp_Legislation数据访问操作
    /// </summary>
    public class SealUpLegislationDal : DalImp.BaseDal<SealUpLegislationEntity>
    {
        public SealUpLegislationDal()
        {
            Model = new SealUpLegislationEntity();
        }

        /// <summary>
        /// 新增案件时，保存法律法规
        /// 添加人：周 鹏
        /// 添加时间：2015-03-30
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseinfoId">案件主键ID</param>
        /// <param name="legislationId">违法行为ID</param>
        /// <param name="legislationItemId">适用案由ID</param>
        /// <param name="legislationGistId">法律条文ID</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        public bool SavePunishLegislation(string caseinfoId, string legislationId, string legislationItemId, string legislationGistId, SqlTransaction transaction)
        {
            try
            {
                var punishLegislations = GetSearchResult(new SealUpLegislationEntity() { CaseInfoId = caseinfoId });

                //是否当前选择的法律法规与之前是否一样,不一样则需要进行变更,否则不执行操作
                if (punishLegislations != null && punishLegislations.Count > 0)
                {
                    var punishLegislationEntity = punishLegislations[0];
                    if (!punishLegislationEntity.LegislationId.Equals(legislationId)
                        || !punishLegislationEntity.LegislationItemId.Equals(legislationItemId)
                        || !punishLegislationEntity.LegislationGistId.Equals(legislationGistId))
                    {
                        //将原有数据进行删除,插入新的数据
                        punishLegislationEntity.RowStatus = 0;
                        Update(punishLegislationEntity, transaction);
                        Add(caseinfoId, legislationId, legislationItemId, legislationGistId, transaction);
                    }
                }
                else
                {
                    Add(caseinfoId, legislationId, legislationItemId, legislationGistId, transaction);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 案件法律法规查询
        /// 添加人：周 鹏
        /// 添加时间：2015-03-30
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<SealUpLegislationEntity> GetSearchResult(SealUpLegislationEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(SealUpLegislationEntity.Parm_SealUp_Legislation_RowStatus, "1");
            //案由编号
            if (!string.IsNullOrEmpty(search.ItemNo))
            {
                queryCondition.AddEqual(SealUpLegislationEntity.Parm_SealUp_Legislation_ItemNo, search.ItemNo);
            }
            //案由编号
            if (!string.IsNullOrEmpty(search.CaseInfoId))
            {
                queryCondition.AddEqual(SealUpLegislationEntity.Parm_SealUp_Legislation_CaseInfoId, search.CaseInfoId);
            }
            return Query(queryCondition) as List<SealUpLegislationEntity>;
        }

        /// <summary>
        /// 新增案件法律法规
        /// 添加人：周 鹏
        /// 添加时间：2015-03-30
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseinfoId">案件主键ID</param>
        /// <param name="legislationId">违法行为ID</param>
        /// <param name="legislationItemId">适用案由ID</param>
        /// <param name="legislationGistId">法律条文ID</param>
        /// <param name="transaction">事务</param>
        private void Add(string caseinfoId, string legislationId, string legislationItemId, string legislationGistId, SqlTransaction transaction)
        {
            try
            {
                var legislationEntity = new LegislationDal().Get(legislationId);
                var legislationItemEntity = new LegislationItemDal().Get(legislationItemId);
                var legislationGistEntity = new LegislationGistDal().Get(legislationGistId);

                var entity = new SealUpLegislationEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    CaseInfoId = caseinfoId,
                    LegislationId = legislationId,
                    ItemCode = legislationEntity.ItemCode,
                    ItemType = legislationEntity.ItemType,
                    ItemNo = legislationEntity.ItemNo,
                    ItemAct = legislationEntity.ItemAct,
                    ClassNo = legislationEntity.ClassNo,
                    ClassNoName = legislationEntity.ClassName,
                    LegislationItemId = legislationItemId,
                    ItemName = legislationItemEntity.ItemName,
                    LegislationGistId = legislationGistId,
                    GistName = legislationGistEntity.GistName,
                    DutyName = legislationGistEntity.DutyName,
                    StipulateFirst = legislationGistEntity.StipulateFirst,
                    StipulateSecond = legislationGistEntity.StipulateSecond,
                    RowStatus = 1,
                    CreateOn = DateTime.Now,
                    UpdateOn = DateTime.Now
                };

                Add(entity, transaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
