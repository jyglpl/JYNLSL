//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TeamManagementBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/24 10:23:36
//  功能描述：TeamManagement业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.TeamManagement;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.TeamManagement;

namespace Yookey.WisdomClassed.SIP.Business.TeamManagement
{
    /// <summary>
    /// TeamManagement业务逻辑
    /// </summary>
    public class TeamManagementBll : BaseBll<TeamManagementEntity>
    {
        readonly TeamManagementDal _teamManagementDal = new TeamManagementDal();
        public TeamManagementBll()
        {
            BaseDal = new TeamManagementDal();
        }


        /// <summary>
        /// 查询路面考核分页列表(手机端使用)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public List<TeamManagementEntity> GetTeamManagementPage(TeamManagementEntity entity, out int totalRecords)
        {
            return _teamManagementDal.GetTeamManagementPage(entity, out totalRecords);
        }

        /// <summary>
        /// 查询路面考核分页列表
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public PageJqDatagrid<TeamManagementEntity> GetTeamManagementPageJqDatagrid(TeamManagementEntity entity)
        {
            int totalRecords;
            var data = _teamManagementDal.GetTeamManagementPageJqDatagrid(entity, out  totalRecords);

            var totalPage = (totalRecords + entity.PageSize - 1) / entity.PageSize;
            return new PageJqDatagrid<TeamManagementEntity>
            {
                page = entity.PageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords
            };

        }

        /// <summary>
        /// 事务新增路面考核
        /// </summary>
        /// <param name="withhold"></param>
        /// <param name="assessmentProcess"></param>
        /// <returns></returns>
        public bool TransactionAddTeamManagement(TeamManagementEntity teamManagement, TeamManagementProcessEntity teamManagementProcess)
        {
            return _teamManagementDal.TransactionAddTeamManagement(teamManagement, teamManagementProcess);
        }

        /// <summary>
        /// 事务处理路面考核
        /// </summary>
        /// <param name="withhold"></param>
        /// <param name="assessmentProcess"></param>
        /// <returns></returns>
        public bool TransactionHandleTeamManagement(TeamManagementEntity teamManagement, TeamManagementProcessEntity teamManagementProcess)
        {
            return _teamManagementDal.TransactionHandleTeamManagement(teamManagement, teamManagementProcess);
        }

        /// <summary>
        /// 查询部门分组的统计报表
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <returns></returns>
        public DataTable GetTeamManagementReportGroupByDept(string companyId, string stime, string etime)
        {
            return _teamManagementDal.GetTeamManagementReportGroupByDept(companyId, stime, etime);
        }

        /// <summary>
        /// 查询路面考核待办数量
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="deptId"></param>
        /// <param name="assignUserId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int GetTeamManagementToDoNumber(string companyId, string deptId, string assignUserId, int state)
        {
            return _teamManagementDal.GetTeamManagementToDoNumber(companyId, deptId, assignUserId, state);
        }
    }
}
