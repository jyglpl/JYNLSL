//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ActivityDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：叶念
//  创建日期：2015/7/28 14:33:39
//  功能描述：Activity数据访问类
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
    /// Activity数据访问操作
    /// </summary>
    public class ActivityDal : DalImp.BaseDal<ActivityEntity>
    {
        public ActivityDal()
        {
            Model = new ActivityEntity();
        }

        /// <summary>
        /// 保存举办活动
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveActivity(ActivityEntity entity)
        {

            var transaction = new TransactionLoader().BeginTransaction("SaveAdvertis");
            try
            {
                var activityId = "";
                var activitysEntity = Get(entity.Id);   //验证该案件是否已经存在

                if (activitysEntity == null || activitysEntity.ActivityNo != entity.ActivityNo.Trim())
                {
                    if (QueryConsentNo(entity.ActivityNo))
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
                var strSql = string.Format("SELECT COUNT(*) FROM Activity WHERE ActivityNo='{0}' AND RowStatus=1 ", advertisNo);
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
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable QueryActivityList(string startTime, string endTime, string keyword, int pageSzie, int pageIndex, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT Activity.BatchNum,Activity.Id,ActivityNo,CompanyName,VenueAdress,ActivityName,StartDate,EndDate,Activity.CreateOn FROM Activity WHERE Activity.RowStatus=1");

                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    strSql.AppendFormat(" AND StartDate>'{0}' AND  EndDate<='{1} 23:59:59.999'", startTime, endTime);
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat(@" AND(CompanyName LIKE '%{0}%' OR VenueAdress LIKE '%{0}%' OR ActivityName LIKE  '%{0}%')", keyword);
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
            strSql.AppendFormat(@"SELECT Activity.BatchNum,Activity.Id,ActivityNo,CompanyName,VenueAdress,ActivityName,StartDate,EndDate,Activity.CreateOn FROM Activity WHERE Activity.RowStatus=1 AND Activity.Id='{0}'", id);

            var data = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            return data;
        }

        /// <summary>
        /// 删除举办活动
        /// </summary>
        /// <param name="ActivityId"></param>
        /// <returns></returns>
        public bool BatchDeleteConsent(string ActivityId)
        {
            if (string.IsNullOrEmpty(ActivityId) || ActivityId.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE [Activity] SET [RowStatus] =0 WHERE [Id]  IN ({0})", ActivityId.Trim(','));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
        }
    }
}

