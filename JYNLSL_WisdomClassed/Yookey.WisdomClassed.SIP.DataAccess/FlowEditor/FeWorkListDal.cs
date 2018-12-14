//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_WorkListDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:36
//  功能描述：FE_WorkList数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using Yookey.WisdomClassed.SIP.Model.FlowEditor;

namespace Yookey.WisdomClassed.SIP.DataAccess.FlowEditor
{
    /// <summary>
    /// FE_WorkList数据访问操作
    /// </summary>
    public class FeWorkListDal : DalImp.BaseDal<FeWorkListEntity>
    {
        public FeWorkListDal()
        {           
            Model = new FeWorkListEntity();
        }     
    }
}
                                                                                                                                         
