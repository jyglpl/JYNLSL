//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainAttachDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/4 10:20:17
//  功能描述：TempDetainAttach数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Model.TempDetain;
using System.Text;
using System.Data;
using System;

namespace Yookey.WisdomClassed.SIP.DataAccess.TempDetain
{
    /// <summary>
    /// TempDetainAttach数据访问操作
    /// </summary>
    public class TempDetainAttachDal : DalImp.BaseDal<TempDetainAttachEntity>
    {
        public TempDetainAttachDal()
        {           
            Model = new TempDetainAttachEntity();
        }

        /// <summary>
        /// 获取暂扣记录的所有附件
        /// 创建人：周庆
        /// 创建日期：2015年5月6日
        /// </summary>
        /// <param name="TempId">暂扣Id</param>
        /// <returns></returns>
        public List<TempDetainAttachEntity> GetTempDetainAttachsByTempId(string TempId)
        {
            string selSql = string.Format(@"SELECT 
                                                    attach.Id,
                                                    attach.ResourceId,
                                                    attach.FileName,
                                                    attach.FileReName,
                                                    attach.FileSize,
                                                    attach.IsCompleted,
                                                    attach.FileAddress,
                                                    attach.FileType,
                                                    attach.FileTypeName,
                                                    attach.ShootTime,
                                                    attach.ShootAddr,
                                                    attach.ShootPersoneFirst,
                                                    attach.ShootPersoneSecond,
                                                    attach.ShootPersoneNameFirst,
                                                    attach.ShootPersoneNameSecond,
                                                    attach.RowStatus,
                                                    attach.Version,
                                                    attach.CreatorId,
                                                    attach.CreateBy,
                                                    attach.CreateOn,
                                                    attach.UpdateId,
                                                    attach.UpdateBy,
                                                    attach.UpdateOn
                                                    FROM TempDetainAttach attach WITH (NOLOCK)
                                                    LEFT JOIN TempDetainInfo info WITH (NOLOCK) ON info.Id = attach.ResourceId
                                                    LEFT JOIN TempDetainGoods goods WITH (NOLOCK) ON goods.Id = attach.ResourceId
                                                    WHERE info.Id = '{0}'", TempId);
            System.Data.SqlClient.SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.SqlConnStringRead, System.Data.CommandType.Text, selSql);
            List<TempDetainAttachEntity> lstEntity = new List<TempDetainAttachEntity>();
            while (reader.Read())
            {
                lstEntity.Add(new TempDetainAttachEntity(reader));
            }
            return lstEntity;
        }


        /// <summary>
        /// 批量删除照片
        /// 添加人：周 鹏
        /// 添加时间：2015-03-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="ids">照片数据集,使用逗号分隔开</param>
        /// <returns></returns>
        public bool DeleteAttach(string ids)
        {
            var transaction = new TransactionLoader().BeginTransaction("DeleteAttach");
            try
            {
                var idsplit = ids.Split(',');
                var sbSql = new StringBuilder("");
                if (idsplit.Length > 0)
                {
                    foreach (var s in idsplit)
                    {
                        sbSql.AppendFormat(@"UPDATE TempDetainAttach SET RowStatus=0 WHERE Id='{0}';", s);
                    }
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
        }
    }
}
                                                                                                                                         
