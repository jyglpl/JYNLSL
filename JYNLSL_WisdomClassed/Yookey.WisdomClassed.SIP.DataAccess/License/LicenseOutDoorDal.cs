//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseOutDoorDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/2/1 9:11:45
//  功能描述：LicenseOutDoor数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.License;

namespace Yookey.WisdomClassed.SIP.DataAccess.License
{
    /// <summary>
    /// LicenseOutDoor数据访问操作
    /// </summary>
    public class LicenseOutDoorDal : DalImp.BaseDal<LicenseOutDoorEntity>
    {

        /// <summary>
        /// 办件查询
        /// 添加人：周 鹏
        /// 添加时间：2018-02-02
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable QueryApplicantInfoList(string keyword, int pageSize,
                                       int pageIndex, string sidx, string sord, out int totalRecords)
        {
            totalRecords = 0;
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"
select distinct ApplicantType,PaperType,PaperCode,ApplicantName,CompanyAddress,LegalPersonName,LegalPersonId,LinkMan,LinkTel,LinkMobile,ZipCode,Email,Fax

from LicenseMain  with(nolock)
where RowStatus=1 
");

                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat(@" and ( PaperCode like '%{0}%'  or ApplicantName like '%{0}%' 
or CompanyAddress like '%{0}%' 
or LegalPersonName  like '%{0}%' 
or LegalPersonId like '%{0}%' 
or LinkMan like '%{0}%' 
or LinkTel like '%{0}%' 
or LinkMobile like '%{0}%' 
or ZipCode like '%{0}%' 
or Email like '%{0}%'  )", keyword);
                }
                else
                {
                    return new DataTable();
                }


                var sortField = "PaperCode"; //排序字段
                var sortType = "DESC"; //排序类型

                if (!string.IsNullOrEmpty(sidx))
                {
                    sortField = sidx;
                    sortType = sord;
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField,
                                                sortType, pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public LicenseOutDoorDal()
        {
            Model = new LicenseOutDoorEntity();
        }


        /// <summary>
        /// 使用事务保存户外广告
        /// 添加人：周 鹏 
        /// 添加时间：2018-02-02
        /// </summary>
        /// <param name="mainEntity">主信息实体</param>
        /// <param name="licenseOutDoorEntity">户外广告实体</param>
        /// <param name="specList">规则集合</param>
        /// <returns></returns>
        public bool TransactionSaveOutDoor(LicenseMainEntity mainEntity, LicenseOutDoorEntity licenseOutDoorEntity, List<LicenseSpecEntity> specList)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveOutDoor");
            try
            {
                //保存许可主表信息
                var mainModel = new LicenseMainDal().Get(mainEntity.Id);
                if (mainModel != null && !string.IsNullOrEmpty(mainModel.Id))
                {
                    mainEntity.CreatorId = mainModel.CreatorId;
                    mainEntity.CreateBy = mainEntity.CreateBy;
                    mainEntity.CreateOn = mainEntity.CreateOn;
                    new LicenseMainDal().Update(mainEntity, transaction);
                }
                else
                {
                    new LicenseMainDal().Add(mainEntity, transaction);
                }

                //删除户外广告和申请规格信息
                var strSql = new StringBuilder();
                strSql.AppendFormat(@"DELETE FROM [LicenseOutDoor] WHERE LicenseId='{0}';DELETE FROM LicenseSpec WHERE LicenseId='{0}';", mainEntity.Id);
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, strSql.ToString());


                Add(licenseOutDoorEntity, transaction);

                foreach (var entity in specList)
                {
                    new LicenseSpecDal().Add(entity, transaction);
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message, ex);
            }
            transaction.Commit();
            return true;
        }



        /// <summary>
        /// 获取户外广告信息
        /// 添加人：周 鹏
        /// 添加时间：2018-02-02
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="search">查询实体</param> 
        /// <returns></returns>
        public List<LicenseOutDoorEntity> GetSearchResult(LicenseOutDoorEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(LicenseOutDoorEntity.Parm_LicenseOutDoor_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.LicenseId))
            {
                queryCondition.AddLike(LicenseOutDoorEntity.Parm_LicenseOutDoor_LicenseId, search.LicenseId);
            }
            return Query(queryCondition) as List<LicenseOutDoorEntity>;
        }

        /// <summary>
        /// 户外广告现场勘验
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool SaveOutDoorInquestCheckSpec(RequestOutDoorInquestCheckSpec request)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveOutDoorInquestCheckSpec");
            try
            {
                //保存许可主表信息
                var mainModel = new LicenseMainDal().Get(request.LicenseId);

                if (mainModel != null && !string.IsNullOrEmpty(mainModel.Id))
                {
                    mainModel.AcceptanceCheck = DateTime.Now;
                    mainModel.BaiduLat = request.Latitude.BaiDuLat;
                    mainModel.BaiduLng = request.Latitude.BaiDuLng;
                    mainModel.GPSLat = request.Latitude.GpsLat;
                    mainModel.GPSLng = request.Latitude.GpsLng;
                    mainModel.ClosedIdea = request.ClosedIdea;//保存受理意见
                    new LicenseMainDal().Update(mainModel, transaction);
                }

                var outdoorModel = GetSearchResult(new LicenseOutDoorEntity() { LicenseId = request.LicenseId })[0];

                var outdorrModelInquest = new LicenseInquestSizeEntity();
                outdorrModelInquest.Id = Guid.NewGuid().ToString();
                outdorrModelInquest.LicenseId = request.LicenseId;
                outdorrModelInquest.CheckLeftHeight = request.CheckLeftHeight;
                outdorrModelInquest.CheckRightHeight = request.CheckRightHeight;
                outdorrModelInquest.CheckLeftLogn = request.CheckLeftLogn;
                outdorrModelInquest.CheckRightLogn = request.CheckRightLogn;
                outdorrModelInquest.RowStatus = 1;
                outdorrModelInquest.CreateOn = DateTime.Now;
                new LicenseInquestSizeDal().Add(outdorrModelInquest, transaction);


                outdoorModel.CheckNumbers = Convert.ToInt32(request.CheckNumbers);
                outdoorModel.IsInquest = request.IsInquest;  //勘验状态               
                

                Update(outdoorModel, transaction);

                var licensePointEntity = new LicensePointPositionEntity();
                licensePointEntity.Id = Guid.NewGuid().ToString();
                licensePointEntity.PointType = "00700001";//踏勘点位
                licensePointEntity.LicenseId = request.LicenseId;//许可编号
                licensePointEntity.BaiduLat = request.Latitude.BaiDuLat;
                licensePointEntity.BaiduLng = request.Latitude.BaiDuLng;
                licensePointEntity.GPSLat = request.Latitude.GpsLat;
                licensePointEntity.GPSLng = request.Latitude.GpsLng;
                licensePointEntity.RowStatus = 1;
                licensePointEntity.CreateOn = DateTime.Now;
                new LicensePointPositionDal().Add(licensePointEntity,transaction);


                //删除已申请规格信息
                var strSql = new StringBuilder();
                strSql.AppendFormat(@"DELETE FROM [LicenseCheckSpec] WHERE LicenseId='{0}' AND CheckType=1", request.LicenseId);
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, strSql.ToString());

                int index = 1;
                foreach (var spec in request.Specs)
                {
                    new LicenseCheckSpecDal().Add(new LicenseCheckSpecEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        LicenseId = request.LicenseId,
                        CheckType = 1,
                        Width = spec.Width,
                        Height = spec.Height,
                        Long = spec.Long,
                        SortNo = index,
                        RowStatus = 1,
                        CreateOn = DateTime.Now,
                        UpdateOn = DateTime.Now
                    }, transaction);
                    index++;
                }

                #region//更新派发状态
                new LicenseHandUsersDal().SetIsHandle(new LicenseHandLimitsRequest() { LicenseId = request.LicenseId, HandType = 1, HandUserId = request.HandUserId }, transaction);

                #endregion
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message, ex);
            }
            transaction.Commit();
            return true;
        }

        /// <summary>
        /// 保存户外广告现场验收
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool SaveOutDoorAcceptanceCheckSpec(RequestOutDoorAcceptanceCheckSpec request)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveOutDoorAcceptanceCheckSpec");
            try
            {
                //保存许可主表信息
                var mainModel = new LicenseMainDal().Get(request.LicenseId);

                if (mainModel != null && !string.IsNullOrEmpty(mainModel.Id))
                {
                    mainModel.BaiduLat = request.Latitude.BaiDuLat;
                    mainModel.BaiduLng = request.Latitude.BaiDuLng;
                    mainModel.GPSLat = request.Latitude.GpsLat;
                    mainModel.GPSLng = request.Latitude.GpsLng;
                    mainModel.AcceptanceCheck = DateTime.Now;
                    mainModel.ClosedIdea = request.ClosedIdea;//保存受理意见
                    new LicenseMainDal().Update(mainModel, transaction);
                }

                var outdoorModel = GetSearchResult(new LicenseOutDoorEntity() { LicenseId = request.LicenseId })[0];
                outdoorModel.AcceptanceCheckNumbers = Convert.ToInt32(request.AcceptanceCheckNumbers);                
                outdoorModel.IsCheck = request.IsCheck;
                Update(outdoorModel, transaction);

                var licensePointEntity = new LicensePointPositionEntity();
                licensePointEntity.Id = Guid.NewGuid().ToString();
                licensePointEntity.PointType = "00700002";//验收点位
                licensePointEntity.LicenseId = request.LicenseId;//许可编号
                licensePointEntity.BaiduLat = request.Latitude.BaiDuLat;
                licensePointEntity.BaiduLng = request.Latitude.BaiDuLng;
                licensePointEntity.GPSLat = request.Latitude.GpsLat;
                licensePointEntity.GPSLng = request.Latitude.GpsLng;
                licensePointEntity.RowStatus = 1;
                licensePointEntity.CreateOn = DateTime.Now;
                new LicensePointPositionDal().Add(licensePointEntity, transaction);


                //删除已申请规格信息
                var strSql = new StringBuilder();
                strSql.AppendFormat(@"DELETE FROM [LicenseCheckSpec] WHERE LicenseId='{0}' AND CheckType=2", request.LicenseId);
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, strSql.ToString());
                int index = 1;
                foreach (var spec in request.Specs)
                {
                    new LicenseCheckSpecDal().Add(new LicenseCheckSpecEntity()
                        {
                            Id = Guid.NewGuid().ToString(),
                            LicenseId = request.LicenseId,
                            CheckType = 2,
                            Width = spec.Width,
                            Height = spec.Height,
                            Long = spec.Long,
                            RowStatus = 1,
                            SortNo = index,
                            CreateOn = DateTime.Now,
                            UpdateOn = DateTime.Now
                        }, transaction);
                    index++;
                }
                #region//更新派发状态
                new LicenseHandUsersDal().SetIsHandle(new LicenseHandLimitsRequest() { LicenseId = request.LicenseId, HandType = 2, HandUserId = request.HandUserId }, transaction);

                #endregion
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message, ex);
            }
            transaction.Commit();
            return true;
        }


    }
}

