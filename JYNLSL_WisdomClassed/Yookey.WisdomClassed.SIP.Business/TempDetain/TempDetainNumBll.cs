//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainNumBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/5 15:14:47
//  功能描述：TempDetainNum业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.TempDetain;
using Yookey.WisdomClassed.SIP.Model.TempDetain;

namespace Yookey.WisdomClassed.SIP.Business.TempDetain
{
    /// <summary>
    /// 编号 业务逻辑
    /// </summary>
    public class TempDetainNumBll : BaseBll<TempDetainNumEntity>
    {
        public TempDetainNumBll()
        {
            BaseDal = new TempDetainNumDal();
        }
    }
}
