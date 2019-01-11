//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmIssuanceModelDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/1/7 10:37:34
//  功能描述：CrmIssuanceModel数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.DataAccess.Crm
{
    /// <summary>
    /// CrmIssuanceModel数据访问操作
    /// </summary>
    public class CrmIssuanceModelDal : DalImp.BaseDal<CrmIssuanceModelEntity>
    {
        public CrmIssuanceModelDal()
        {           
            Model = new CrmIssuanceModelEntity();
        }     
    }
}
                                                                                                                                         
