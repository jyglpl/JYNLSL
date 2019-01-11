//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseAttachBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/2/1 9:11:45
//  功能描述：LicenseAttach业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.License;
using Yookey.WisdomClassed.SIP.Model.License;
using System;
using System.Data;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Enumerate;
using System.Linq;
namespace Yookey.WisdomClassed.SIP.Business.License
{
    /// <summary>
    /// LicenseAttach业务逻辑
    /// </summary>
    public class LicenseAttachBll : BaseBll<LicenseAttachEntity>
    {
        private readonly LicenseAttachDal _dal = new LicenseAttachDal();

        public LicenseAttachBll()
        {
            BaseDal = new LicenseAttachDal();
        }

        /// <summary>
        /// 通过主键编号和材料编号获取附件
        /// </summary>
        /// <param name="resourid">主键编号</param>
        /// <param name="fileType">配置材料编号</param>
        /// <param name="licenseAttachType">附件类型(默认配置材料列表附件)</param>
        /// <returns></returns>
        public List<LicenseAttachEntity> GetLicenseAttachList(string resourid, string fileType, LicenseAttachType licenseAttachType = LicenseAttachType.Material)
        {
            try
            {
                return _dal.GetLicenseAttachList(resourid, fileType, licenseAttachType);
            }
            catch (Exception)
            {
                return new List<LicenseAttachEntity>();
            }
        }


        /// <summary>
        /// 无效附件
        /// </summary>
        /// <param name="id">附件主键</param>
        /// <returns></returns>
        public bool LicenseAttachDelete(string id)
        {
            return _dal.LicenseAttachDelete(id);
        }


       public List<LicenseAttachEntity> GetAttachList_CheckSpecType(string resourid, LicenseCheckSpecType CheckSpecType)
       {
           try
           {
               var CheckSpecTypeList=this.GetLicenseAttachList(resourid, string.Empty,LicenseAttachType.CheckSpec);
               if (CheckSpecType == LicenseCheckSpecType.Prospect)
               {
                   CheckSpecTypeList = CheckSpecTypeList.FindAll(i => i.FileType.Contains("0063"));
               }
               else
               {
                   CheckSpecTypeList = CheckSpecTypeList.FindAll(i => i.FileType.Contains("0064"));
               }
               return CheckSpecTypeList;
           }
           catch(Exception)
           {
               return new List<LicenseAttachEntity>();
           }
       }
    }
}
