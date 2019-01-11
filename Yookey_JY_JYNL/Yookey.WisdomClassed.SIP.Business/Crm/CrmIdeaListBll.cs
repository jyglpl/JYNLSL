//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmIdeaListBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/8/5 14:27:36
//  功能描述：CrmIdeaList业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Business.Crm
{
    /// <summary>
    /// CrmIdeaList业务逻辑
    /// </summary>
    public class CrmIdeaListBll : BaseBll<CrmIdeaListEntity>
    {
        public CrmIdeaListBll()
        {
            BaseDal = new CrmIdeaListDal();
        }

        /// <summary>
        /// 根据外键查询出结果并且保存
        /// 添加人：周 鹏
        /// 添加时间：2014-08-05
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="type">状态类型</param>
        /// <param name="userId">用户编号</param>
        /// <param name="resourceId">源ID</param>
        /// <param name="idea">意见</param>
        /// <param name="processID"></param>
        /// <param name="workListId">消息ID</param>
        /// <param name="processInstanceID">消息实例ID</param>
        /// <param name="level">级别</param>
        /// <param name="duty">职务</param>
        /// <param name="ideaCreateDate">审批时间</param>
        /// <returns></returns>
        public bool SaveList(string type, string userId, string resourceId, string idea, string processID, string workListId, string processInstanceID,
            string level, string duty, string ideaCreateDate)
        {
            var entity = new CrmIdeaListEntity();
            try
            {
                entity.Id = Guid.NewGuid().ToString();
                entity.ResourceID = resourceId;
                entity.Type = type;
                entity.UserId = userId;
                entity.CreateOn = Convert.ToDateTime(ideaCreateDate);
                entity.Idea = idea;
                entity.ProcessID = processID;
                entity.WorkList = workListId;
                entity.ProcessInstanceID = processInstanceID;
                entity.LeveL = level;
                entity.Duty = duty;
                entity.UpdateOn = Convert.ToDateTime(ideaCreateDate);
                entity.RowStatus = 1;
                Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询意见
        /// 添加人：周 鹏
        /// 添加时间：2014-08-07
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<CrmIdeaListEntity> GetSearchResult(CrmIdeaListEntity search)
        {
            return new CrmIdeaListDal().GetSearchResult(search);
        }

        /// <summary>
        /// 查询意见
        /// 添加人：周 鹏
        /// 添加时间：2014-09-12
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">办件编号</param>
        /// <returns></returns>
        public DataTable GetMobileFlow(string resourceId)
        {
            return new CrmIdeaListDal().GetMobileFlow(resourceId);
        }

        /// <summary>
        /// 根据办件编号、流程名称查询审批意见
        /// 添加人：周 鹏
        /// 添加时间：2014-12-24
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">办件编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="firstIdeaType">第一条意见的类型->reper:受理人,unper->承办人,user:实际走流程人员</param>
        /// <returns>DataTable Columns->UserName:用户名称,Idea:意见,Duty:环节名称,Adate:审批日期</returns>
        public DataTable GetFlowIdea(string resourceId, string flowName, string firstIdeaType = "user", int Itype = 0)
        {
            var dt = new CrmIdeaListDal().GetFlowIdea(resourceId, flowName, Itype);
            if (dt != null && dt.Rows.Count > 0)
            {
                switch (flowName)
                {
                    case "立案审批":
                    case "处理审批":
                    case "结案审批":
                        if (firstIdeaType.Equals("user"))
                        {
                            var caseEntity = new InfPunishCaseinfoBll().Get(resourceId);
                            if (firstIdeaType.Equals("reper"))
                            {
                                dt.Rows[0]["UserName"] = caseEntity.RePersonelNameFist + "," + caseEntity.RePersonelNameSecond;
                            }
                            else if (firstIdeaType.Equals("unper"))
                            {
                                dt.Rows[0]["UserName"] = caseEntity.UdPersonelNameFirst + "," + caseEntity.UdPersonelNameSecond;
                            }
                        }
                        break;
                }
            }
            return dt;
        }

        /// <summary>
        /// 根据办件编号、流程名称查询审批意见
        /// 添加人：周 鹏
        /// 添加时间：2014-12-24
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        ///           2015-02-06 周 鹏 修改Sql语句
        ///           2015-02-28 周 鹏 修改用户表的关联
        /// </history>
        /// <param name="resourceId">办件编号</param>
        /// <param name="flowName">流程名称</param>
        /// <returns>DataTable Columns->UserName:用户名称,Idea:意见,Duty:环节名称,Adate:审批日期</returns>
        public DataTable GetFlowIdeaForHr(string resourceId, string flowName)
        {
            return new CrmIdeaListDal().GetFlowIdeaForHr(resourceId, flowName);
        }

        /// <summary>
        /// 根据办件编号、流程名称查询最后一条审批意见
        /// 添加人：周 鹏
        /// 添加时间：2015-01-22
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">办件编号</param>
        /// <param name="flowName">流程名称</param>
        /// <returns>DataTable Columns->UserName:用户名称,Idea:意见,Duty:环节名称,Adate:审批日期</returns>
        public DataTable GetLastFlowIdea(string resourceId, string flowName)
        {
            return new CrmIdeaListDal().GetLastFlowIdea(resourceId, flowName);
        }


        /// <summary>
        /// 根据办件编号查询审批意见
        /// 添加人：周 鹏
        /// 添加时间：2018-02-24
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">办件编号</param>
        /// <returns>DataTable Columns->UserName:用户名称,Idea:意见,Duty:环节名称,Adate:审批日期</returns>
        public DataTable GetFlowIdea(string resourceId)
        {
            return new CrmIdeaListDal().GetFlowIdea(resourceId);
        }

        /// <summary>
        /// 根据办件编号、流程名称删除意见【删除非退回的意见】
        /// 添加人：周 鹏
        /// 添加时间：2015-01-22
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">办件编号</param>
        /// <param name="flowName">流程名称</param>
        /// <returns></returns>
        public bool DeleteIdea(string resourceId, string flowName)
        {
            return new CrmIdeaListDal().DeleteIdea(resourceId, flowName);
        }

        /// <summary>
        /// 获取办件的最后一次审批日期
        /// 添加人：周 鹏
        /// 添加时间：2015-06-26
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">办件编号</param>
        /// <returns>DateTime.</returns>
        public DateTime GetMaxIdeaTimeByResourceId(string resourceId)
        {
            return new CrmIdeaListDal().GetMaxIdeaTimeByResourceId(resourceId);
        }

        /// <summary>
        /// 获取案件预审的意见
        /// 添加人：周 鹏
        /// 添加时间：2015-07-28
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">案件主键ID</param>
        /// <returns>DataTable.</returns>
        public DataTable GetPunishCaseFirstTrialIdea(string resourceId)
        {
            return new CrmIdeaListDal().GetPunishCaseFirstTrialIdea(resourceId);
        }

        /// <summary>
        /// 获取许可的消息集合
        /// </summary>
        /// <returns></returns>
        public List<CrmIdeaListEntity> GetIdeaListByLicense()
        {
            return new CrmIdeaListDal().GetIdeaListByLicense();
        }


        /// <summary>
        /// 获取信访的消息结合
        /// </summary>
        /// <returns></returns>
        public DataTable GetIdeaListByPetition(string Id)
        {
            return new CrmIdeaListDal().GetIdeaListByPetition(Id);
        }
    }
}
