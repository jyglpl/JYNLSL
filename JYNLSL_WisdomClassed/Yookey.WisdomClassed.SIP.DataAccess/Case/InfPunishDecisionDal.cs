﻿//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_DECISIONDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 13:58:26
//  功能描述：INF_PUNISH_DECISION数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// 行政处罚决定书数据访问操作
    /// </summary>
    public class InfPunishDecisionDal : DalImp.BaseDal<InfPunishDecisionEntity>
    {
        public InfPunishDecisionDal()
        {           
            Model = new InfPunishDecisionEntity();
        }     
    }
}
                                                                                                                                         