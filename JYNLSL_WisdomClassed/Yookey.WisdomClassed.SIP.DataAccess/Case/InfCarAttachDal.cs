//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CAR_ATTACHDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/22 16:26:18
//  功能描述：INF_CAR_ATTACH数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// INF_CAR_ATTACH数据访问操作
    /// </summary>
    public class InfCarAttachDal : DalImp.BaseDal<InfCarAttachEntity>
    {
        public InfCarAttachDal()
        {           
            Model = new InfCarAttachEntity();
        }     
    }
}
                                                                                                                                         
