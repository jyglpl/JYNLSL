//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmCompanyBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/1 13:56:10
//  功能描述：CrmCompany业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Business.Crm
{
    /// <summary>
    /// CrmCompany业务逻辑
    /// </summary>
    public class CrmCompanyBll : BaseBll<CrmCompanyEntity>
    {
        public CrmCompanyBll()
        {
            BaseDal = new CrmCompanyDal();
        }

        private readonly static CrmCompanyDal Dal = new CrmCompanyDal();

        /// <summary>
        /// 查询所有部门
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmCompanyEntity> GetAllCompany()
        {
            return Dal.GetAllCompany();
        }


        /// <summary>
        /// 查询所有部门
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmCompanyEntity> GetAllCompany(CrmCompanyEntity search)
        {
            return Dal.GetAllCompany(search);
        }

        /// <summary>
        /// 查询所有的执法单位（支队及各区）
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmCompanyEntity> GetAllEnforcementUnit()
        {
            return GetAllCompany(new CrmCompanyEntity() { Enforcement = 1 });
        }


        /// <summary>
        /// 查询所有的可接收许可的单位
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<CrmCompanyEntity> GetAllLicenseUnit()
        {
            return GetAllCompany(new CrmCompanyEntity() {  });
        }

        /// <summary>
        /// 批量删除单位
        /// </summary>
        /// <param name="ids">单位Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            return Dal.BatchDelete(ids);
        }


    }
}
