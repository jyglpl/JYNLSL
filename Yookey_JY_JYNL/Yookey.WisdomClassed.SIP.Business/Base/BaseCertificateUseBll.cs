//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_CertificateUseBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/18 15:05:07
//  功能描述：Base_CertificateUse业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Base;


namespace Yookey.WisdomClassed.SIP.Business.Base
{
    /// <summary>
    /// 执法证管理业务逻辑
    /// </summary>
    public class BaseCertificateUseBll : BaseBll<BaseCertificateUseEntity>
    {
        public BaseCertificateUseBll()
        {
            BaseDal = new BaseCertificateUseDal();
        }
        /// <summary>
        /// 执法证（监督证）取得所有使用记录
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public DataTable GetAllCertificateUse(string uid)
        {
            return new BaseCertificateUseDal().GetAllCertificateUse(uid);
        }
        /// <summary>
        /// 查询证件管理类型
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public DataTable GetCertificateType(string typeid)
        {
            return new BaseCertificateUseDal().GetCertificateType(typeid);
        }
        /// <summary>
        /// 删除执法(监督)证使用记录
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public int CertificateDelete(string id)
        {
            return new BaseCertificateUseDal().Delete(id);
        }


    }
}
