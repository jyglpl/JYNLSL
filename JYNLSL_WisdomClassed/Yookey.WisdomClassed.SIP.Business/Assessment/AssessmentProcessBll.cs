﻿//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AssessmentProcessBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/14 15:04:12
//  功能描述：AssessmentProcess业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Assessment;
using Yookey.WisdomClassed.SIP.Model.Assessment;

namespace Yookey.WisdomClassed.SIP.Business.Assessment
{
    /// <summary>
    /// AssessmentProcess业务逻辑
    /// </summary>
    public class AssessmentProcessBll : BaseBll<AssessmentProcessEntity>
    {
        readonly AssessmentProcessDal _assessmentProcessDal = new AssessmentProcessDal();
        public AssessmentProcessBll()
        {

        }

        /// <summary>
        /// 查询案件Id查询附件
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <returns></returns>
        public List<AssessmentProcessEntity> GetAssessmentProcessListByAssessmentId(string assessmentId, int state = -1)
        {

            return _assessmentProcessDal.GetAssessmentProcessListByAssessmentId(assessmentId, state);
        }

    }
}