//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AttendanceReportBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/5/5 13:22:22
//  功能描述：AttendanceReport业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.FlowEditor;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Hr;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.Business.Hr
{
    /// <summary>
    /// AttendanceReport业务逻辑
    /// </summary>
    public class AttendanceReportBll : BaseBll<AttendanceReportEntity>
    {
        public AttendanceReportBll()
        {
            BaseDal = new AttendanceReportDal();
        }

        /// <summary>
        /// 获取考勤申报信息
        /// </summary>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="startTime">查询开始时间</param>
        /// <param name="endTime">查询截止时间</param>
        /// <param name="keywords"></param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <returns></returns>
        public PageJqDatagrid<AttendanceReportEntity> GetAllAttendanceReport(string companyId, string deptId, string startTime,
                                                                 string endTime, string keywords, int pageSize,
                                                                 int pageIndex)
        {
            int totalRecords;
            var data = new AttendanceReportDal().GetAllAttendanceReport(companyId, deptId, startTime, endTime, keywords,
                                                                  pageSize, pageIndex, out totalRecords);

            var totalPage = (totalRecords + pageSize - 1) / pageSize;
            return new PageJqDatagrid<AttendanceReportEntity>
            {
                page = pageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords
            };
        }


        /// <summary>
        /// 事务保存考勤申报
        /// </summary>
        /// <param name="entity">考勤申报主要信息</param>
        /// <param name="detailList">考勤详细列表</param>
        /// <returns></returns>
        public bool TransactionSave(AttendanceReportEntity entity, List<AttendanceReportDetailsEntity> detailList)
        {
            return new AttendanceReportDal().TransactionSave(entity, detailList);
        }

        /// <summary>
        /// 批量删除申报信息
        /// </summary>
        /// <param name="ids">单位Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            return new AttendanceReportDal().BatchDelete(ids);
        }

        /// <summary>
        /// 更改可用状态
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public bool UpdateState(string id)
        {
            try
            {
                return new AttendanceReportDal().UpdateState(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 更改可用状态
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public bool UpdateState(string id, int state)
        {
            try
            {
                return new AttendanceReportDal().UpdateState(id, state);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 审批成功后,执行相应操作
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="userId">当前登录用户编号</param>
        /// <param name="id">案件编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="islastFlow">是否为最后一步审批流程</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="approveDate">审批日期</param>
        /// <returns></returns>
        public bool AttendanceApproveReturn(string eType, string userId, string id, string flowName, bool islastFlow, string worklistId, DateTime approveDate)
        {
            var isOk = false;
            try
            {
                if (!string.IsNullOrEmpty(worklistId))
                {
                    new CrmMessageWorkBll().UpdateWorkListState(worklistId, DateTime.Now);  //更改消息的状态为已处理
                }

                //验证当前流程环节为最后一步,需将案件状态更改为当前有流程最大值,如果不是最后一步流程,直接在原有状态的基本上面+1
                if (!string.IsNullOrEmpty(flowName) && !string.IsNullOrEmpty(id))
                {
                    var state = 0;
                    if (eType.Equals("agree") && islastFlow)
                    {
                        state = 10;
                        isOk = UpdateState(id, state);
                    }
                    else if ((eType.Equals("agree") || eType.Equals("apply")) && !islastFlow)
                    {
                        isOk = UpdateState(id);   //在原有基础上增加1
                    }
                    else if (eType.Equals("disAgree"))
                    {
                        state = -1;
                        isOk = UpdateState(id, state);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return isOk;
        }

        /// <summary>
        /// 考勤申报审批
        /// 添加人：周 鹏
        /// 添加时间：2017-05-06
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,handleType:处理类型（apply:开启流程,agree:同意,disAgree:不同意）,
        ///                                userId:处理人,handleInfo:意见内容, formId:办件编号,processId:所属审批流程,flowName:流程名称,
        ///                                worklistId:消息编号}</param>
        /// <param name="erMsg"></param>
        /// <returns></returns>
        public bool AttendanceApprove(string context, out string erMsg)
        {
            var isOk = false;
            erMsg = "";
            try
            {
                var feProcessBll = new FeProcessBll();            //流程
                var crmUserBll = new BaseUserBll();               //用户

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var formId = Regex.Match(context, @"(?<=""formId""\:"").*?(?="",)").Value;
                var type = Regex.Match(context, @"(?<=""type""\:"").*?(?="",)").Value;
                var eType = Regex.Match(context, @"(?<=""handleType""\:"").*?(?="",)").Value;
                var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;
                var idea = Regex.Match(context, @"(?<=""handleInfo""\:"").*?(?="",)").Value;
                var processId = Regex.Match(context, @"(?<=""processId""\:"").*?(?="",)").Value;
                var flowName = Regex.Match(context, @"(?<=""flowName""\:"").*?(?="",)").Value;
                var worklistId = Regex.Match(context, @"(?<=""worklistId""\:"").*?(?="",)").Value;

                var flag = false;          //审批状态
                var isLastFlow = false;    //当前流程是否为最后一步流程
                try
                {
                    var entity = Get(formId);                //案件实体
                    feProcessBll.RuleCode.Add("@DeptId", entity.DepartmentId);     //对应的部门
                    feProcessBll.Community.Add(entity.DepartmentId);

                    feProcessBll.FullName = flowName;
                    feProcessBll.IdeaCreateDate = DateTime.Now.ToString(AppConst.DateFormatLong);

                    var ideaTitle = "【" + entity.DepartmentName + "】" + flowName;     //待办事事宜标题

                    var note = "";      //短信内容
                    if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                    {
                        note = string.Format("您有一条来自【{0}】的月度考勤审批！", entity.DepartmentName);
                        //第一次进入
                        flag = feProcessBll.StarProcess(flowName, ideaTitle, userId, formId, idea, true, note);
                    }
                    else
                    {
                        if (eType.Equals("agree")) //同意
                        {
                            if (feProcessBll.IsNextEndProcess(worklistId))
                            {
                                isLastFlow = true;
                                note = string.Format("您申请的月度考勤已审批通过！");
                            }
                            else
                            {
                                note = string.Format("您有一条来自【{0}】的月度考勤审批！", entity.DepartmentName);
                            }
                            flag = feProcessBll.SendProcess(worklistId, ideaTitle, userId, formId, idea, true, note);
                        }
                        else if (eType.Equals("disAgree"))  //不同意
                        {
                            note = string.Format("您申请的月度考勤未审批通过！");
                            flag = feProcessBll.ReturnProcess(worklistId, ideaTitle, userId, formId, idea, true, note);
                        }
                    }
                }
                catch (Exception ex)
                {
                    flag = false;
                }
                if (flag)
                {
                    //审核通过后,调用方法进行相应的处理
                    flag = AttendanceApproveReturn(eType, "", formId, flowName, isLastFlow, worklistId, DateTime.Now);
                }
                isOk = flag;
            }
            catch (Exception ex)
            {
                erMsg = ex.Message;
                isOk = false;
            }
            return isOk;
        }

        /// <summary>
        /// 获取部门所有审核通过的考勤异常记录
        /// 添加人：周 鹏
        /// 添加时间：2017-05-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptmentId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable GetAttendanceReportByDepartment(string deptmentId, string startTime, string endTime)
        {
            return new AttendanceReportDal().GetAttendanceReportByDepartment(deptmentId, startTime, endTime);
        }
    }
}
