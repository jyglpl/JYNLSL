//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_ATTACHDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/20 18:22:52
//  功能描述：INF_PUNISH_ATTACH数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Data;
using System.Text;
using Yookey;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// INF_PUNISH_ATTACH数据访问操作
    /// </summary>
    public class InfPunishAttachDal : DalImp.BaseDal<InfPunishAttachEntity>
    {
        public InfPunishAttachDal()
        {
            Model = new InfPunishAttachEntity();
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
                        sbSql.AppendFormat(@"UPDATE INF_PUNISH_ATTACH SET RowStatus=0 WHERE Id='{0}';", s);
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

