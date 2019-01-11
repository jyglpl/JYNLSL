//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainGoodsBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/4 10:20:17
//  功能描述：TempDetainGoods业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.TempDetain;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.TempDetain;

namespace Yookey.WisdomClassed.SIP.Business.TempDetain
{
    /// <summary>
    /// TempDetainGoods业务逻辑
    /// </summary>
    public class TempDetainGoodsBll : BaseBll<TempDetainGoodsEntity>
    {
        #region 状态代码

        /// <summary>
        /// 入库
        /// </summary>
        public static int CODE_PUTIN = 0;
        /// <summary>
        /// 发还
        /// </summary>
        public static int CODE_RETURN = 1;
        /// <summary>
        /// 移交
        /// </summary>
        public static int CODE_TRANSFER = 2;
        /// <summary>
        /// 作废
        /// </summary>
        public static int CODE_CANCEL = 3;
        /// <summary>
        /// 腐烂无价
        /// </summary>
        public static int CODE_DECAY = 4;

        #endregion

        public TempDetainGoodsBll()
        {
            BaseDal = new TempDetainGoodsDal();
        }

        /// <summary>
        /// 添加暂扣物品
        /// 创建人：周庆
        /// 创建日期：2015年5月4日
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>""：暂扣Id为空或不存在 </returns>
        public string CreateTempDetainGoods(TempDetainGoodsEntity entity)
        {
            if (string.IsNullOrEmpty(entity.TempId)) return null;

            string Id = entity.Id = Guid.NewGuid().ToString();
            entity.RowStatus = 1;
            BaseDal.Add(entity);
            return Id;
        }

        /// <summary>
        /// 暂扣物品腐烂无价
        /// 创建人：周庆
        /// 创建日期：2015年5月4日
        /// </summary>
        /// <param name="Id">物品Id</param>
        /// <param name="UpdateId">修改人Id</param>
        /// <param name="UpdateBy">修改人姓名</param>
        /// <returns></returns>
        public int DecayTempDetainGoods(string Id, string UpdateId, string UpdateBy)
        {
            var model = new TempDetainGoodsDal().Get(Id);
            if (model != null && model.State == CODE_PUTIN)
            {
                model.State = CODE_DECAY;
                model.UpdateId = UpdateId;
                model.UpdateOn = DateTime.Now;
                model.UpdateBy = UpdateBy;
                return new TempDetainGoodsDal().Update(model);
            }
            else
                return -1;
        }

        /// <summary>
        /// 物品表
        /// </summary>
        /// <param name="CaseInfoId"></param>
        /// <returns></returns>
        public DataTable GetInventory(string caseInfoId)
        {
            return new TempDetainGoodsDal().GetInventory(caseInfoId);
        }

        /// <summary>
        /// 查询物品清单
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<TempDetainGoodsEntity> GetSearchResult(TempDetainGoodsEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(TempDetainGoodsEntity.Parm_TempDetainGoods_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.TempId))
            {
                queryCondition.AddEqual(TempDetainGoodsEntity.Parm_TempDetainGoods_TempId, search.TempId);
            }
            //排序
            queryCondition.AddOrderBy(TempDetainGoodsEntity.Parm_TempDetainGoods_CreateOn, true);
            return Query(queryCondition) as List<TempDetainGoodsEntity>;
        }

        
        /// <summary>
        /// 获取统计列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<TempDetainGoodsEntity> GetGoodsStatistics(string startTime, string endTime)
        {
            return new TempDetainGoodsDal().GetGoodsStatistics(startTime, endTime);
        }
    }
}
