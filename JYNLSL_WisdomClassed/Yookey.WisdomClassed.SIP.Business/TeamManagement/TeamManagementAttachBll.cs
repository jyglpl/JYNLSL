﻿//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TeamManagementAttachBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/24 10:23:36
//  功能描述：TeamManagementAttach业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.TeamManagement;
using Yookey.WisdomClassed.SIP.Model.TeamManagement;

namespace Yookey.WisdomClassed.SIP.Business.TeamManagement
{
    /// <summary>
    /// TeamManagementAttach业务逻辑
    /// </summary>
    public class TeamManagementAttachBll : BaseBll<TeamManagementAttachEntity>
    {
        readonly TeamManagementAttachDal _teamManagementAttachDal = new TeamManagementAttachDal();
        public TeamManagementAttachBll()
        {
            BaseDal = new TeamManagementAttachDal();
        }

        /// <summary>
        /// 查询案件Id查询附件
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <returns></returns>
        public List<TeamManagementAttachEntity> GetTeamManagementAttachListByTeamManagementId(string teamManagementId)
        {
            return _teamManagementAttachDal.GetTeamManagementAttachListByTeamManagementId(teamManagementId);
        }
    }
}