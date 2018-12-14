//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TeamManagementAttachDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/24 10:23:36
//  功能描述：TeamManagementAttach数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System.Collections.Generic;
using System.Data;
using Yookey.WisdomClassed.SIP.Model.TeamManagement;

namespace Yookey.WisdomClassed.SIP.DataAccess.TeamManagement
{
    /// <summary>
    /// TeamManagementAttach数据访问操作
    /// </summary>
    public class TeamManagementAttachDal : DalImp.BaseDal<TeamManagementAttachEntity>
    {
        public TeamManagementAttachDal()
        {           
            Model = new TeamManagementAttachEntity();
        }

        /// <summary>
        /// 查询案件Id查询附件
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <returns></returns>
        public List<TeamManagementAttachEntity> GetTeamManagementAttachListByTeamManagementId(string teamManagementId)
        {
            string selSql = string.Format(@"SELECT 
                                                    attach.Id,
                                                    attach.ResourceId,
                                                    attach.FileName,
                                                    attach.FileReName,
                                                    attach.FileSize,
                                                    attach.IsCompleted,
                                                    attach.FileAddress,
                                                    attach.FileType,
                                                    attach.FileTypeName,
                                                    attach.ShootTime,
                                                    attach.ShootAddr,
                                                    attach.ShootPersoneFirst,
                                                    attach.ShootPersoneSecond,
                                                    attach.ShootPersoneNameFirst,
                                                    attach.ShootPersoneNameSecond,
                                                    attach.RowStatus,
                                                    attach.Version,
                                                    attach.CreatorId,
                                                    attach.CreateBy,
                                                    attach.CreateOn,
                                                    attach.UpdateId,
                                                    attach.UpdateBy,
                                                    attach.UpdateOn
                                                    FROM TeamManagementAttach attach WITH (NOLOCK)
                                                    WHERE attach.ResourceId = '{0}'", teamManagementId);
            DataSet data = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, System.Data.CommandType.Text, selSql);

            return data != null && data.Tables[0] != null && data.Tables[0].Rows.Count > 0 ? DataTableToList(data.Tables[0]) : new List<TeamManagementAttachEntity>();
        }
    }
}
                                                                                                                                         
