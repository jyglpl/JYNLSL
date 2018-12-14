//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ExcavationDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/8/26 17:24:11
//  功能描述：Excavation数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.Consent;

namespace Yookey.WisdomClassed.SIP.DataAccess.Consent
{
    /// <summary>
    /// 许可开挖数据访问操作
    /// </summary>
    public class ExcavationDal : DalImp.BaseDal<ExcavationEntity>
    {
        public ExcavationDal()
        {
            Model = new ExcavationEntity();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Save(ExcavationEntity entity)
        {

            var transaction = new TransactionLoader().BeginTransaction("SaveAdvertis");
            try
            {
                var activityId = "";
                var activitysEntity = Get(entity.Id);   //验证该案件是否已经存在

                if (activitysEntity == null || activitysEntity.ExcavationNo != entity.ExcavationNo.Trim())
                {
                    if (QueryConsentNo(entity.ExcavationNo))
                    {
                        return false;
                    }
                }
                if (activitysEntity != null)
                {
                    entity.RowStatus = 1;
                    entity.CreatorId = activitysEntity.CreatorId;
                    entity.CreateBy = activitysEntity.CreateBy;
                    entity.CreateOn = activitysEntity.CreateOn;
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
        /// 查询编号是否存在
        /// </summary>
        /// <param name="advertisNo"></param>
        /// <returns></returns>
        public bool QueryConsentNo(string advertisNo)
        {
            try
            {
                var strSql = string.Format("SELECT COUNT(*) FROM Excavation WHERE ExcavationNo='{0}' AND RowStatus=1 ", advertisNo);
                var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
                return obj != null && int.Parse(obj.ToString()) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 数据查询
        /// 添加人：叶 念
        /// 添加时间：xxxx-xx-xx
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="keyword">关键字</param>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable QueryExcavationList(string startTime, string endTime, string keyword, string companyId, int pageSzie, int pageIndex, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT * FROM Excavation WHERE RowStatus=1");

                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    strSql.AppendFormat(" AND StartDate>'{0}' AND  EndDate<='{1} 23:59:59'", startTime, endTime);
                }
                if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
                {
                    strSql.AppendFormat(" AND OwnerCompanyId='{0}'", companyId);
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat(@" AND(CompanyName LIKE '%{0}%' OR Details LIKE '%{0}%'')", keyword);
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CreateOn", "DESC", pageIndex, pageSzie, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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
            strSql.AppendFormat(@"SELECT BatchNum,ExcavationNo,OwnerCompanyName,CompanyName,Proposer,Mobile,Details,StartDate,EndDate FROM Excavation WHERE RowStatus=1 AND Id='{0}'", id);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool BatchDeleteConsent(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE [Excavation] SET [RowStatus] =0 WHERE [Id]  IN ({0})", id.Trim(','));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
        }
    }
}

