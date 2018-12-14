//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="HolidaysRuleDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监安监企业调查表
//  作    者：叶念
//  创建日期：2018-03-31 01:37:02
//  功能描述：HolidaysRule数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.DataAccess.Hr
{
    /// <summary>
    /// HolidaysRule数据访问操作
    /// </summary>
    public class HolidaysRuleDal : DalImp.BaseDal<HolidaysRuleEntity>
    {
        public HolidaysRuleDal()
        {           
            Model = new HolidaysRuleEntity();
        }     
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
