﻿//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_RECORDDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 13:58:26
//  功能描述：INF_PUNISH_RECORD数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// 调查询问笔录数据访问操作
    /// </summary>
    public class InfPunishRecordDal : DalImp.BaseDal<InfPunishRecordEntity>
    {
        public InfPunishRecordDal()
        {           
            Model = new InfPunishRecordEntity();
        }     
    }
}
                                                                                                                                         
