//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AdvertisingDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：叶念
//  创建日期：2015/7/28 14:33:39
//  功能描述：Advertising数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Consent;

namespace Yookey.WisdomClassed.SIP.DataAccess.Consent
{
    /// <summary>
    /// Advertising数据访问操作
    /// </summary>
    public class AdvertisingDal : DalImp.BaseDal<AdvertisingEntity>
    {
        public AdvertisingDal()
        {
            Model = new AdvertisingEntity();
        }
        /// <summary>
        /// 户外广告 保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveAdvertis(AdvertisingEntity entity)
        {

            var transaction = new TransactionLoader().BeginTransaction("SaveAdvertis");
            try
            {
                var advertisId = "";
                var advertisingEntity = !string.IsNullOrEmpty(entity.Id) ? Get(entity.Id) : null;   //验证该案件是否已经存在

                if (advertisingEntity == null || advertisingEntity.AdvertisNo != entity.AdvertisNo.Trim())
                {
                    if (QueryConsentNo(entity.AdvertisNo))
                    {
                        return false;
                    }
                }
                if (advertisingEntity != null)
                {
                    entity.RowStatus = 1;
                    entity.CreatorId = advertisingEntity.CreatorId;
                    entity.CreateBy = advertisingEntity.CreateBy;
                    entity.CreateOn = advertisingEntity.CreateOn;
                    advertisId = entity.Id;
                    Update(entity);
                }
                else
                {
                    entity.RowStatus = 1;
                    advertisId = Guid.NewGuid().ToString();
                    entity.Id = advertisId;
                    Add(entity);
                }

                //保存接收对象

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
                            ResourceId = advertisId,
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
        /// 验证编号是否已存在
        /// </summary>
        /// <param name="advertisNo">广告编号</param>
        /// <returns></returns>
        public bool QueryConsentNo(string advertisNo)
        {
            try
            {
                var strSql = string.Format("SELECT COUNT(*) FROM Advertising WHERE AdvertisNo='{0}' AND RowStatus=1 ", advertisNo);
                var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
                return obj != null && int.Parse(obj.ToString()) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 户外广告查询
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="typeId"></param>
        /// <param name="keyword"></param>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable QueryAdvertingList(string startTime, string endTime, string typeId, string keyword, string companyId, int pageSzie, int pageIndex, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT Advertising.BatchNum,Advertising.Id, AdvertisNo,INTERNAL_NO,ComResource.RSKEY AS TypeNo,Advertising.TypeNo TypeID,CompanyName,OwnerCompanyName,
[Address],AdvertisContents,CategoryQuantity,StartDate,EndDate,Advertising.CreateOn FROM Advertising 
INNER JOIN dbo.ComResource ON ComResource.ID=Advertising.TypeNo WHERE Advertising.RowStatus=1");

                if (!string.IsNullOrEmpty(typeId))
                {
                    strSql.AppendFormat(@" AND Advertising.TypeNo ='{0}'", typeId);
                }
                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    strSql.AppendFormat(" AND StartDate>'{0}' AND EndDate<='{1} 23:59:59.999'", startTime, endTime);
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat(@" AND(CompanyName LIKE '%{0}%' OR Address LIKE '%{0}%' OR AdvertisContents LIKE '%{0}%' OR CategoryQuantity LIKE  '%{0}%')", keyword);
                }
                if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
                {
                    strSql.AppendFormat(@" AND Advertising.OwnerCompanyId ='{0}'", companyId);
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CreateOn", "DESC", pageIndex, pageSzie, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 户外广告查询
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="typeId"></param>
        /// <param name="keyword"></param>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable QueryLicenseList(string startTime, string endTime, string typeId, string keyword, string companyId, int pageSzie, int pageIndex, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT Advertising.Id,ComResource.RSKEY AS ItemName,CompanyName ApplicantName,OwnerCompanyName,'3' DataSource,
[Address] SetUpAddress,AdvertisContents Content,StartDate ApplicationDate,EndDate PromiseEndDate,Advertising.CreateOn FROM Advertising 
INNER JOIN dbo.ComResource ON ComResource.ID=Advertising.TypeNo WHERE Advertising.RowStatus=1 ");

                if (!string.IsNullOrEmpty(typeId))
                {
                    strSql.AppendFormat(@" AND Advertising.TypeNo ='{0}'", typeId);
                }
                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    strSql.AppendFormat(" AND StartDate>'{0}' AND EndDate<='{1} 23:59:59.999'", startTime, endTime);
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat(@" AND(CompanyName LIKE '%{0}%' OR Address LIKE '%{0}%' OR AdvertisContents LIKE '%{0}%' OR CategoryQuantity LIKE  '%{0}%')", keyword);
                }
                if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
                {
                    strSql.AppendFormat(@" AND Advertising.OwnerCompanyId ='{0}'", companyId);
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
            strSql.AppendFormat(@"SELECT Advertising.BatchNum,Advertising.Id, AdvertisNo,INTERNAL_NO,ComResource.RSKEY AS TypeNo,Advertising.TypeNo TypeID, CompanyName,OwnerCompanyName,
[Address],AdvertisContents,CategoryQuantity,StartDate,EndDate,Advertising.CreateOn FROM Advertising 
INNER JOIN dbo.ComResource ON ComResource.ID=Advertising.TypeNo WHERE Advertising.RowStatus=1 AND Advertising.Id='{0}'", id);

            var data = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            return data;
        }


        /// <summary>
        /// 户外广告删除
        /// </summary>
        /// <param name="advertisingId"></param>
        /// <returns></returns>
        public bool BatchDeleteConsent(string advertisingId)
        {
            if (string.IsNullOrEmpty(advertisingId) || advertisingId.Trim().Split(',').Length.Equals(0))
            {
                return false;
            }
            var sbSql = new StringBuilder();
            sbSql.AppendFormat("UPDATE [Advertising] SET [RowStatus]=0 WHERE [Id] IN ({0})", advertisingId.Trim(','));
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, sbSql.ToString()) > 0;
        }
    }
}

