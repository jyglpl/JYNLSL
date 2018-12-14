//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseJeevesBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监安监企业调查表
//  作    者：叶念
//  创建日期：2018-02-26 17:51:45
//  功能描述：LicenseJeeves业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.License;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.License;

namespace Yookey.WisdomClassed.SIP.Business.License
{
    /// <summary>
    /// LicenseJeeves业务逻辑
    /// </summary>
    public class LicenseJeevesBll : BaseBll<LicenseJeevesEntity>
    {
        public LicenseJeevesBll()
        {
            BaseDal = new LicenseJeevesDal();
        }

        /// <summary>
        /// 根据许可主键查询占道信息
        /// 添加人：周 鹏
        /// 添加时间：2018-02-02
        /// </summary>
        /// <param name="licenseId"></param>
        /// <returns></returns>
        public LicenseJeevesEntity GetEntityByLicenseId(string licenseId)
        {
            var list = GetSearchResult(new LicenseJeevesEntity() { LicenseId = licenseId });
            return list != null && list.Count > 0 ? list[0] : new LicenseJeevesEntity();
        }

        /// <summary>
        /// 获取占道信息
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
        /// 使用事务保存占道
        /// 添加人：周 鹏 
        /// 添加时间：2018-02-02
        /// </summary>
        /// <param name="mainEntity">主信息实体</param>
        /// <param name="licenseOutDoorEntity">户外广告实体</param>
        /// <param name="specList">规则集合</param>
        /// <returns></returns>
        public bool TransactionSaveJeeves(LicenseMainEntity mainEntity, LicenseJeevesEntity licenseJeevesEntity)
        {
            try
            {
                return new LicenseJeevesDal().TransactionSaveJeeves(mainEntity, licenseJeevesEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }      


        /// <summary>
        /// 占道勘验保存信息
        /// </summary>
        /// <param name="licenseJeevesEntity"></param>
        /// <returns></returns>
        public bool SaveJeevesInquest(RequestJeevesInquest licenseJeevesEntity)
        {
            try
            {
                return new LicenseJeevesDal().SaveJeevesInquest(licenseJeevesEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 占道现场验收保存信息
        /// </summary>
        /// <param name="licenseJeevesEntity"></param>
        /// <returns></returns>
        public bool SaveJeevesCheck(RequestJeevesCheck licenseJeevesEntity)
        {
            try
            {
                return new LicenseJeevesDal().SaveJeevesCheck(licenseJeevesEntity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
      
}
