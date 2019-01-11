//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TemporaryDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：叶念
//  创建日期：2015/7/28 14:33:39
//  功能描述：Temporary数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Consent;

namespace Yookey.WisdomClassed.SIP.DataAccess.Consent
{
    /// <summary>
    /// Temporary数据访问操作
    /// </summary>
    public class TemporaryDal : DalImp.BaseDal<TemporaryEntity>
    {
        public TemporaryDal()
        {
            Model = new TemporaryEntity();
        }

        public DataTable QueryTemporaryList(string StartTime, string EndTime, string keyword, string CompanyId, int pageSzie, int pageIndex, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT Temporary.BatchNum,Temporary.CompanyName AS OwnerCompanyName,Temporary.Id,TemporaryNo,INTERNAL_NO,ApplicationName,JeevesAddress, JeevesCause,StartDate, EndDate,Temporary.CreateOn FROM Temporary WHERE Temporary.RowStatus=1");
                if (!string.IsNullOrEmpty(StartTime) && !string.IsNullOrEmpty(EndTime))
                {
                    strSql.AppendFormat(" AND StartDate>'{0}' AND  EndDate<='{1} 23:59:59.999'", StartTime, EndTime);
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat(@" AND(ApplicationName LIKE '%{0}%' OR JeevesAddress LIKE '%{0}%' OR JeevesCause LIKE  '%{0}%')", keyword);
                }
                if (!string.IsNullOrEmpty(CompanyId) && !CompanyId.Equals("all"))
                {
                    strSql.AppendFormat(" AND CompanyId='{0}'", CompanyId);
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CreateOn", "DESC", pageIndex, pageSzie, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// 查询编号是否存在
        /// </summary>
        /// <param name="temporaryNo"></param>
        /// <returns></returns>
        public bool QueryConsentNo(string temporaryNo)
        {
            try
            {
                var strSql = string.Format("SELECT COUNT(*) FROM Temporary WHERE TemporaryNo='{0}' AND RowStatus=1 ", temporaryNo);
                var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);

                return obj != null && int.Parse(obj.ToString()) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public bool SaveTemporary(TemporaryEntity entity)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveTemporary");
            try
            {
                var activityId = "";
                var tempEntity = Get(entity.Id);   //验证该案件是否已经存在

                if (tempEntity == null || tempEntity.TemporaryNo != entity.TemporaryNo.Trim())
                {
                    if (QueryConsentNo(entity.TemporaryNo))   //验证编号是否存在
                    {
                        return false;
                    }
                }
                if (tempEntity != null)
                {
                    entity.RowStatus = 1;
                    entity.CreatorId = entity.CreatorId;
                    entity.CreateBy = entity.CreateBy;
                    entity.CreateOn = entity.CreateOn;
                    activityId = entity.Id;
                    Update(entity);
                }
                else
                {
                    entity.RowStatus = 1;
                    activityId = Guid.NewGuid().ToString();
                    entity.Id = activityId;
                    Add(entity);
                }

                //保存附件
                var sbSql = new StringBuilder();
                sbSql.AppendFormat("DELETE Consent_Attach WHERE ResourceId='{0}'", entity.Id);
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());

                var attachDal = new Consent_AttachDal();
                if (entity.Attachment != null)
                {
                    var splitAttach = entity.Attachment.Split('|');
                    foreach (var attach in splitAttach)
                    {
                        var attachInfo = attach.Split(',');
                        var receiveEntity = new Consent_AttachEntity
                        {
                            Id = Guid.NewGuid().ToString(),
                            ResourceId = activityId,
                            FileName = attachInfo[2],
                            FileReName = attachInfo[3],
                            FileAddress = attachInfo[1],
                            RowStatus = 1,
                            IsCompleted = 1,
                            CreatorId = entity.CreatorId,
                            CreateBy = entity.CreateBy,
                            CreateOn = DateTime.Now,
                            UpdateId = entity.UpdateId,
                            UpdateBy = entity.UpdateBy,
                            UpdateOn = DateTime.Now
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

        /// <summary>
        /// 请求详情
        /// 添加人：周 鹏
        /// 添加时间：2015-09-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">主键编号</param>
        /// <returns>DataTable.</returns>
        public DataTable GetDetail(string id)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT Temporary.BatchNum,Temporary.CompanyName AS OwnerCompanyName,Temporary.Id,TemporaryNo,INTERNAL_NO,ApplicationName,JeevesAddress, JeevesCause,StartDate, EndDate,Temporary.CreateOn FROM Temporary WHERE Temporary.RowStatus=1 AND Temporary.Id='{0}'", id);

            var data = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];

            return data;
        }

        /// <summary>
        /// 删除占道经营
        /// </summary>
        /// <returns></returns>
        public bool BatchDeleteTemporary(string temporaryId)
        {
            if (string.IsNullOrEmpty(temporaryId) || temporaryId.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE [Temporary] SET [RowStatus] =0 WHERE [Id] IN ({0})", temporaryId.Trim(','));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
        }

    }
}

