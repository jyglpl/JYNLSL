//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_CompanyBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/2/9 15:42:45
//  功能描述：Base_Company业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Business.Base
{
    /// <summary>
    /// Base_Company业务逻辑
    /// </summary>
    public class BaseCompanyBll
    {
        public BaseCompanyBll() { }

        /// <summary>
        /// 查询所有部门
        /// 添加人：周 鹏
        /// 添加时间：2015-02-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<BaseCompanyEntity> GetAllCompanys()
        {
            return new BaseCompanyDal().GetAllCompanys();
        }
        public IEnumerable<BaseCompanyEntity> GetAllCompany()
        {
            return new BaseCompanyDal().GetAllCompany();
        }

        /// <summary>
        /// 执法大队
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <returns></returns>
        public List<BaseCompanyEntity> GetCompanyNameByID(string CompanyID)
        {
            return new BaseCompanyDal().GetCompanyNameByID(CompanyID);
        }
    }
}
