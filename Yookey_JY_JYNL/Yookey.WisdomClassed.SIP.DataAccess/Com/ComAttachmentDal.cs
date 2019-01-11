//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComAttachmentDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/22 10:52:20
//  功能描述：ComAttachment数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    /// <summary>
    /// ComAttachment数据访问操作
    /// </summary>
    public class ComAttachmentDal : DalImp.BaseDal<ComAttachmentEntity>
    {
        public ComAttachmentDal()
        {
            Model = new ComAttachmentEntity();
        }

        /// <summary>
        /// 通过资源Id删除附件（假删）
        /// 添加人：周庆
        /// 添加日期：2015年4月23日
        /// </summary>
        /// <param name="ResourceId"></param>
        /// <returns></returns>
        public int DeleteAttachmentByResourceId(string ResourceId)
        {


            string sql = string.Format(@"UPDATE ComAttachment
                                                SET RowStatus = 0
                                                WHERE ResourceId = '{0}'
                                                AND RowStatus = 1", ResourceId);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, System.Data.CommandType.Text, sql);
        }

        /// <summary>
        /// 保存附件
        /// </summary>
        /// <param name="resourceId">外键编号</param>
        /// <param name="attachments">附件数据集，以逗号分隔</param>
        /// <returns></returns>
        public bool SaveAttachment(string resourceId, string attachments)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveAttachment");

            try
            {
                //保存附件
                var sbSql = new StringBuilder();
                sbSql.AppendFormat("DELETE ComAttachment WHERE ResourceId='{0}'", resourceId);
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
                if (!(string.IsNullOrEmpty(attachments) || attachments.Split(',').Length.Equals(0)))
                {
                    var attachDal = new ComAttachmentDal();
                    var splitAttach = attachments.Split('|');
                    foreach (var attach in splitAttach)
                    {
                        var attachInfo = attach.Split(',');
                        var receiveEntity = new ComAttachmentEntity
                        {
                            Id = Guid.NewGuid().ToString(),
                            ResourceId = resourceId,
                            FileName = attachInfo[2],
                            FileReName = attachInfo[3],
                            FileAddress = attachInfo[1],
                            RowStatus = 1,
                            CreateOn = DateTime.Now
                        };
                        attachDal.Add(receiveEntity, transaction);
                    }
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

