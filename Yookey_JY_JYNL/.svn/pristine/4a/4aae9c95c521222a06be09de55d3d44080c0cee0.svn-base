//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainInfo_ProcessBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/13 17:13:46
//  功能描述：TempDetainInfo_Process业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.TempDetain;
using Yookey.WisdomClassed.SIP.Model.TempDetain;

namespace Yookey.WisdomClassed.SIP.Business.TempDetain
{
    /// <summary>
    /// TempDetainInfo_Process业务逻辑
    /// </summary>
    public class TempDetainInfoProcessBll : BaseBll<TempDetainInfoProcessEntity>
    {
        private readonly TempDetainInfoProcessDal _tmpDetainInfoProcessDal = new TempDetainInfoProcessDal();
        public TempDetainInfoProcessBll()
        {
            BaseDal = new TempDetainInfoProcessDal();
        }

        /// <summary>
        /// 通过暂扣Id查询审核过程
        /// </summary>
        /// <param name="tempId"></param>
        /// <returns></returns>
        public List<TempDetainInfoProcessEntity> GetTempDetainInfoProcessList(string tempId)
        {
            return _tmpDetainInfoProcessDal.GetTempDetainInfoProcessList(tempId);
        }
    }
}
