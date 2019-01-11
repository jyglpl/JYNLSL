//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComAttributeBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/3/19 13:26:45
//  功能描述：ComAttribute业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Business.Com
{
    /// <summary>
    /// ComAttribute业务逻辑
    /// </summary>
    public class ComAttributeBll : BaseBll<ComAttributeEntity>
    {
        public ComAttributeBll()
        {
            BaseDal = new ComAttributeDal();
        }
    }
}
