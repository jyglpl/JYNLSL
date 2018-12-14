//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseJeevesDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监安监企业调查表
//  作    者：叶念
//  创建日期：2018-02-25 10:30:26
//  功能描述：LicenseJeeves数据访问类
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
    /// LicenseJeeves数据访问操作
    /// </summary>
    public class LicenseJeevesDal : DalImp.BaseDal<LicenseJeevesEntity>
    {
        public LicenseJeevesDal()
        {
            Model = new LicenseJeevesEntity();
        }

        /// <summary>
        /// 使用事务保存占道信息
        /// 添加人：周 鹏 
        /// 添加时间：2018-02-02
        /// </summary>
        /// <param name="mainEntity">主信息实体</param>
        /// <param name="licenseJeevesEntity">占道实体</param>        
        /// <returns></returns>
        public bool TransactionSaveJeeves(LicenseMainEntity mainEntity, LicenseJeevesEntity licenseJeevesEntity)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveJeeves");
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
                strSql.AppendFormat(@"DELETE FROM [LicenseJeeves] WHERE LicenseId='{0}'", mainEntity.Id);
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, strSql.ToString());
                Add(licenseJeevesEntity, transaction);
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
        /// 获取占道集合
        /// 添加人：周 鹏
        /// 添加时间：2018-02-02
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="search">查询实体</param> 
        /// <returns></returns>
        public List<LicenseJeevesEntity> GetSearchResult(LicenseJeevesEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(LicenseJeevesEntity.Parm_LicenseJeeves_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.LicenseId))
            {
                queryCondition.AddLike(LicenseJeevesEntity.Parm_LicenseJeeves_LicenseId, search.LicenseId);
            }
            return Query(queryCondition) as List<LicenseJeevesEntity>;
        }


        /// <summary>
        /// 占道勘验保存信息
        /// </summary>
        /// <param name="licenseJeevesEntity"></param>
        /// <returns></returns>
        public bool SaveJeevesInquest(RequestJeevesInquest licenseJeevesEntity)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveJeevesInquest");
            try
            {
                if (string.IsNullOrEmpty(licenseJeevesEntity.LicenseId))
                    return false;
                var mainModel = new LicenseMainDal().Get(licenseJeevesEntity.LicenseId);
                if (mainModel == null)
                    return false;                
                mainModel.AcceptanceCheck = DateTime.Now;
                mainModel.BaiduLat = licenseJeevesEntity.Latitude.BaiDuLat;
                mainModel.BaiduLng = licenseJeevesEntity.Latitude.BaiDuLng;
                mainModel.GPSLat = licenseJeevesEntity.Latitude.GpsLat;
                mainModel.GPSLng = licenseJeevesEntity.Latitude.GpsLng;
                mainModel.ClosedIdea = licenseJeevesEntity.ClosedIdea;//审批意见
                new LicenseMainDal().Update(mainModel, transaction);

                var JeevesModel = GetSearchResult(new LicenseJeevesEntity() { LicenseId = licenseJeevesEntity.LicenseId })[0];

                JeevesModel.InquestAdress = licenseJeevesEntity.InquestAdress;
                JeevesModel.InquestLength = licenseJeevesEntity.InquestLength;
                JeevesModel.InquestWidth = licenseJeevesEntity.InquestWidth;
                JeevesModel.JeevesArea = licenseJeevesEntity.InquestArea;
                JeevesModel.IsInquest = licenseJeevesEntity.IsInquest;

                Update(JeevesModel, transaction);

                var licensePointEntity = new LicensePointPositionEntity();
                licensePointEntity.Id = Guid.NewGuid().ToString();
                licensePointEntity.PointType="00700001";//踏勘点位
                licensePointEntity.LicenseId = licenseJeevesEntity.LicenseId;//许可编号
                licensePointEntity.BaiduLat = licenseJeevesEntity.Latitude.BaiDuLat;
                licensePointEntity.BaiduLng = licenseJeevesEntity.Latitude.BaiDuLng;
                licensePointEntity.GPSLat = licenseJeevesEntity.Latitude.GpsLat;
                licensePointEntity.GPSLng = licenseJeevesEntity.Latitude.GpsLng;
                licensePointEntity.RowStatus = 1;
                licensePointEntity.CreateOn = DateTime.Now;
                new LicensePointPositionDal().Add(licensePointEntity,transaction);

                #region//更新派发状态
                new LicenseHandUsersDal().SetIsHandle(new LicenseHandLimitsRequest() { LicenseId = licenseJeevesEntity.LicenseId, HandType = 1, HandUserId = licenseJeevesEntity.HandUserId }, transaction);

                #endregion
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message,ex);
            }
            transaction.Commit();
            return true;
        }

        /// <summary>
        /// 占道验收保存信息
        /// </summary>
        /// <param name="licenseJeevesEntity"></param>
        /// <returns></returns>
        public bool SaveJeevesCheck(RequestJeevesCheck licenseJeevesEntity)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveJeevesCheck");
            try
            {
                if (string.IsNullOrEmpty(licenseJeevesEntity.LicenseId))
                    return false;
                var mainModel = new LicenseMainDal().Get(licenseJeevesEntity.LicenseId);
                if (mainModel == null)
                    return false;
                mainModel.BaiduLat = licenseJeevesEntity.Latitude.BaiDuLat;
                mainModel.BaiduLng = licenseJeevesEntity.Latitude.BaiDuLng;
                mainModel.GPSLat = licenseJeevesEntity.Latitude.GpsLat;
                mainModel.GPSLng = licenseJeevesEntity.Latitude.GpsLng;
                mainModel.AcceptanceCheck = DateTime.Now;
                mainModel.ClosedIdea = licenseJeevesEntity.ClosedIdea;//审批意见
                new LicenseMainDal().Update(mainModel, transaction);

                var JeevesModel = GetSearchResult(new LicenseJeevesEntity() { LicenseId = licenseJeevesEntity.LicenseId })[0];

                JeevesModel.CheckLength = licenseJeevesEntity.CheckLength;
                JeevesModel.CheckWidth = licenseJeevesEntity.CheckWidth;
                JeevesModel.JeevesArea = licenseJeevesEntity.CheckArea;
                JeevesModel.IsCheck = licenseJeevesEntity.IsCheck;
                Update(JeevesModel, transaction);

                var licensePointEntity = new LicensePointPositionEntity();
                licensePointEntity.Id = Guid.NewGuid().ToString();
                licensePointEntity.PointType = "00700002";//验收点位
                licensePointEntity.LicenseId = licenseJeevesEntity.LicenseId;//许可编号
                licensePointEntity.BaiduLat = licenseJeevesEntity.Latitude.BaiDuLat;
                licensePointEntity.BaiduLng = licenseJeevesEntity.Latitude.BaiDuLng;
                licensePointEntity.GPSLat = licenseJeevesEntity.Latitude.GpsLat;
                licensePointEntity.GPSLng = licenseJeevesEntity.Latitude.GpsLng;
                licensePointEntity.RowStatus = 1;
                licensePointEntity.CreateOn = DateTime.Now;
                new LicensePointPositionDal().Add(licensePointEntity,transaction);

                #region//更新派发状态
                new LicenseHandUsersDal().SetIsHandle(new LicenseHandLimitsRequest() { LicenseId = licenseJeevesEntity.LicenseId, HandType = 2, HandUserId = licenseJeevesEntity.HandUserId }, transaction);

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