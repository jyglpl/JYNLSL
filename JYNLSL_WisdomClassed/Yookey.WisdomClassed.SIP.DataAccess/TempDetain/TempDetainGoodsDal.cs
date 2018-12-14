//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainGoodsDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/4 10:20:17
//  功能描述：TempDetainGoods数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.TempDetain;

namespace Yookey.WisdomClassed.SIP.DataAccess.TempDetain
{
    /// <summary>
    /// TempDetainGoods数据访问操作
    /// </summary>
    public class TempDetainGoodsDal : DalImp.BaseDal<TempDetainGoodsEntity>
    {
        public TempDetainGoodsDal()
        {
            Model = new TempDetainGoodsEntity();
        }


        /// <summary>
        /// 物品表
        /// </summary>
        /// <param name="CaseInfoId"></param>
        /// <returns></returns>
        public DataTable GetInventory(string caseInfoId)
        {
            var strSql = new StringBuilder("");

            strSql.AppendFormat(@"   select ROW_NUMBER() OVER (ORDER BY TG.createon) AS Num ,
       TG.GoodsName ArticleName,  TG.Specification Specifications, 
       CONVERT(varchar(100),TG.GoodsCount) + ' '+Unit.RsKey Number,
       TG.Remark
 from TempDetainGoods  TG with(nolock)
  inner join ComResource Unit with(nolock)
 on TG.GoodsUnit=Unit.Id
 
 where TG.RowStatus=1 AND TG.TempId='{0}' ", caseInfoId);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获取统计列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<TempDetainGoodsEntity> GetGoodsStatistics(string startTime, string endTime)
        {
            List<TempDetainGoodsEntity> entityList = new List<TempDetainGoodsEntity>();
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"select * from [dbo].[TempDetainGoods] where[RowStatus]=1 and CreateOn>='{0}' and CreateOn <='{1}'", startTime, endTime);
            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<TempDetainGoodsEntity>();
        }
    }
}

