using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.FlowEditor;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Hr;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.Business.Hr
{
    /// <summary>
    /// WorkOvertime业务逻辑
    /// </summary>
    public class WorkOvertimeBll : BaseBll<WorkOvertimeEntity>
    {
        public WorkOvertimeBll()
        {
            BaseDal = new WorkOvertimeDal();
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="companyId">单位</param>
        /// <param name="deptId">部门</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="keyWords">关键字</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public PageJqDatagrid<WorkOvertimeEntity> GetSearchResult(string companyId, string deptId, string startTime, string endTime, string keyWords, int pageSize, int pageIndex)
        {
            int totalRecords;
            var data = new WorkOvertimeDal().GetSearchResult(companyId, deptId, startTime, endTime, keyWords, pageIndex, pageSize, out totalRecords);
            var totalPage = (totalRecords + pageSize - 1) / pageSize;
            return new PageJqDatagrid<WorkOvertimeEntity>
            {
                page = pageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords,
            };
        }

        /// <summary>
        /// 事务保存加班
        /// 添加人：周 鹏
        /// 添加时间：2017-03-24
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="entity">通知实体</param>
        /// <returns></returns>
        public bool TransactionSaveWorkOvertime(WorkOvertimeEntity entity)
        {
            try
            {
                return new WorkOvertimeDal().TransactionSaveWorkOvertime(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 审批成功后,执行相应操作
        /// 添加人：周 鹏
        /// 添加时间：2015-04-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-04-28 增加审批类型
        /// </history>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="userId">当前登录用户编号</param>
        /// <param name="id">案件编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="islastFlow">是否为最后一步审批流程</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="approveDate">审批日期</param>
        /// <returns></returns>
        public bool WorkOvertimeApproveReturn(string eType, string userId, string id, string flowName, bool islastFlow, string worklistId, DateTime approveDate)
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
        /// 更改加班的状态，在当前状态上面加1
        /// 添加人：周 鹏
        /// 添加时间：2015-04-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public bool UpdateState(string id)
        {
            return new WorkOvertimeDal().UpdateState(id);
        }

        /// <summary>
        /// 更改的状态
        /// 添加人：周 鹏
        /// 添加时间：2015-04-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public bool UpdateState(string id, int state)
        {
            return new WorkOvertimeDal().UpdateState(id, state);
        }


        /// <summary>
        /// 加班审批
        /// 添加人：周 鹏
        /// 添加时间：2015-04-27
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,handleType:处理类型（apply:开启流程,agree:同意,disAgree:不同意）,
        ///                                userId:处理人,handleInfo:意见内容, formId:办件编号,processId:所属审批流程,flowName:流程名称,
        ///                                worklistId:消息编号}</param>
        /// <returns></returns>
        public bool WorkOvertimeApprove(string context, out string erMsg)
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
                    var roleId = crmUserBll.UserRoleId(entity.UserId);
                    feProcessBll.Community.Add(entity.DeptId);
                    feProcessBll.RuleCode.Add("@CompanyId", entity.CompanyId);   //对应所属单位
                    feProcessBll.RuleCode.Add("@DeptId", entity.DeptId);   //对应的部门
                    //feProcessBll.RuleCode.Add("@RoleId", !string.IsNullOrEmpty(roleId) ? roleId : "00380001");   //对应的角色
                    //feProcessBll.RuleCode.Add("@Day", Convert.ToString(entity.Overtime));   //设置加班天数


                    var roles = new CrmUserBll().GetUserRoleName(entity.UserId);   //人员对应角色信息

                    if (roles != null && roles.Rows.Count > 0)
                    {
                        feProcessBll.RuleCode.Add("@RoleName", roles.Rows[0]["RoleName"].ToString());
                    }
                    else
                    {
                        var user = new CrmUserBll().Get(entity.UserId);
                        if (user != null)
                        {
                            feProcessBll.RuleCode.Add("@RoleName", user.Account.Contains("市容") ? "市容管理员" : "队员");
                        }
                    }

                    var isArea = 0;  //是否是片区大队
                    var userDeparment = new CrmDepartmentBll().Get(entity.DeptId);     //获取人员部门信息
                    if (userDeparment != null)
                    {
                        var userCompany = new CrmCompanyBll().Get(userDeparment.CompanyId);  //获取人员所属单位
                        //if (userCompany != null)
                        //{
                        //    isArea = userCompany.IsArea;
                        //}
                    }
                    feProcessBll.RuleCode.Add("@IsArea", isArea.ToString());   //是否是片区大队

                    feProcessBll.FullName = flowName;
                    feProcessBll.IdeaCreateDate = DateTime.Now.ToString(AppConst.DateFormatLong);

                    var ideaTitle = "【" + entity.DeptName + "】【" + entity.UserName + "】" + flowName;     //待办事事宜标题

                    var note = "";      //短信内容
                    if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                    {
                        note = string.Format("您有一条来自【{0}】【{1}】的加班审批！", entity.DeptName, entity.UserName);
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
                                note = string.Format("您的加班已审批通过！");

                                //针对片区大队中队长的请假审批短信抄送倪俊和高卫东
                                if (isArea == 1)
                                {
                                    if (roles != null && roles.Rows.Count > 0)
                                    {
                                        if (roles.Rows[0]["RoleName"].ToString().Equals("中队长"))
                                        {
                                            var copyformsg =
                                                string.Format("您有一条来自【{0}】【{1}】【{2}】加班审批抄送，加班时间自{3}至{4}，加班时长为{5}小时。",
                                                              entity.CompanyName, entity.DeptName, entity.UserName,
                                                              entity.BeginTime.ToString(AppConst.DateFormatLong),
                                                              entity.EndTime.ToString(AppConst.DateFormatLong),
                                                              entity.Overtime);

                                            new ComNoteBll().SendNote(AppConfig.DeputyDirector, copyformsg);
                                            new ComNoteBll().SendNote(AppConfig.Director, copyformsg);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                note = string.Format("您有一条来自【{0}】【{1}】的加班审批！", entity.DeptName, entity.UserName);
                            }
                            flag = feProcessBll.SendProcess(worklistId, ideaTitle, userId, formId, idea, true, note);
                        }
                        else if (eType.Equals("disAgree"))  //不同意
                        {
                            note = string.Format("您的加班未审批通过！");
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
                    flag = WorkOvertimeApproveReturn(eType, "", formId, flowName, isLastFlow, worklistId, DateTime.Now);
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
        /// 获取个人的全部加班记录
        /// 添加人：周庆
        /// 添加日期：2015年4月27日
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="deptId">部门Id</param>
        /// <param name="startTime">开始时间（不需要则null）</param>
        /// <param name="endTime">截止时间（不需要则null）</param>
        /// <param name="keyWords">关键字（不需要则null）</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <returns></returns>
        public PageJqDatagrid<WorkOvertimeEntity> GetAllWorkOvertimeByUserDeptId(string userId, string deptId, string startTime, string endTime, string keyWords, int pageSize = 30, int pageIndex = 1)
        {

            int totalRecords;
            var data = new WorkOvertimeDal().GetAllDataByUserDeptId(userId, deptId, startTime, endTime, keyWords, pageIndex, pageSize, out totalRecords);
            var totalPage = (totalRecords + pageSize - 1) / pageSize;
            return new PageJqDatagrid<WorkOvertimeEntity>
            {
                page = pageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords,
            };

        }


        /// <summary>
        /// 添加或保存加班申请
        /// 添加人：周庆
        /// 添加日期：2015年4月27日
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>如果成功则返回对象，否则返回null</returns>
        public WorkOvertimeEntity CreateOrUpdateApply(WorkOvertimeEntity entity)
        {
            try
            {
                //新增
                if (string.IsNullOrEmpty(entity.Id))
                {
                    var id = entity.Id = Guid.NewGuid().ToString();
                    entity.RowStatus = 1;
                    Add(entity);
                    entity.Id = id;//这边Id会丢失保存一下
                    return entity;
                }
                else//修改
                {
                    var one = Get(entity.Id);
                    if (one == null)
                    {   //数据库中不存在
                        entity.RowStatus = 1;
                        var id = entity.Id;
                        Add(entity);
                        entity.Id = id;//这边Id会丢失保存一下
                        return entity;
                    }
                    else
                    {
                        //确实存在，做更新动作
                        entity.RowStatus = 1;
                        var id = entity.Id;
                        if (Update(entity) > 0)
                        {
                            entity.Id = id;
                            return entity;
                        }
                        else
                            return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 删除加班
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int DeleteApply(WorkOvertimeEntity entity)
        {

            var one = Get(entity.Id);
            //status等于0的时候才能执行删除
            if (one != null && one.RowStatus == 1 && one.Status == 0)
            {
                entity.RowStatus = 0;
                return Update(entity);
            }
            else
                return 0;
        }

        /// <summary>
        /// 获取部门所有审核通过的加班记录
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
        public DataTable GetWorkOvertimeByDepartment(string deptmentId, string startTime, string endTime)
        {
            return new WorkOvertimeDal().GetWorkOvertimeByDepartment(deptmentId, startTime, endTime);
        }
    }
}
