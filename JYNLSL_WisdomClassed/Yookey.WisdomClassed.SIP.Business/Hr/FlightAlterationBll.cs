//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FlightAlterationBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/12/20 14:32:38
//  功能描述：FlightAlteration业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.FlowEditor;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Hr;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.Business.Hr
{

    /// <summary>
    /// 调班管理 业务逻辑
    /// </summary>
    public class FlightAlterationBll : BaseBll<FlightAlterationEntity>
    {
        readonly FeProcessBll _feProcessBll = new FeProcessBll();

        public FlightAlterationBll()
        {
            BaseDal = new FlightAlterationDal();
        }

        private readonly FlightAlterationDal _dal = new FlightAlterationDal();


        /// <summary>
        /// 数据查询
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">请求单位ID</param>
        /// <param name="deptId">请求部门ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="keyWords">关键字</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> GetSearchResult(string companyId, string deptId, string startTime, string endTime,string keyWords, int pageSize = 30, int pageIndex = 1)
        {
            int totalRecords;
            var data = _dal.GetSearchResult(companyId, deptId, startTime, endTime, keyWords, pageIndex, pageSize, out totalRecords);
            var totalPage = (totalRecords + pageSize - 1) / pageSize;
            return new PageJqDatagrid<DataTable>
            {
                page = pageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords,
            };
        }


        /// <summary>
        /// 根据中队编号获取中队的调班信息
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">请求单位ID</param>
        /// <param name="deptId">请求部门ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="keyWords">关键字</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable GetSearchResult(string companyId, string deptId, string startTime, string endTime, string keyWords, int pageIndex,
            int pageSize, out int totalRecords)
        {
            return _dal.GetSearchResult(companyId, deptId, startTime, endTime, keyWords, pageIndex, pageSize, out totalRecords);
        }

        /// <summary>
        /// 查询调班信息
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> GetSearchResult(FlightAlterationEntity search)
        {
            var totalRecords = 0;
            var data = _dal.GetSearchResult(search, out totalRecords);

            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            stopwatch.Stop();
            int totalPage = (totalRecords + search.PageSize - 1) / search.PageSize;   //计算页数
            return new Model.PageJqDatagrid<DataTable>
            {
                page = search.PageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        /// <summary>
        /// 更改状态，在当前状态上面加1
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public bool UpdateState(string id)
        {
            return _dal.UpdateState(id);
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
                return _dal.UpdateState(id, state);
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
        public bool AlterationApproveReturn(string eType, string userId, string id, string flowName, bool islastFlow, string worklistId, DateTime approveDate)
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
        /// 调班审批
        /// 添加人：周 鹏
        /// 添加时间：2015-04-27
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,handleType:处理类型（apply:开启流程,agree:同意,disAgree:不同意）,
        ///                                userId:处理人,handleInfo:意见内容, formId:办件编号,processId:所属审批流程,flowName:流程名称,
        ///                                worklistId:消息编号}</param>
        /// <param name="erMsg">审批意见</param>
        /// <returns></returns>
        public bool AlterationApprove(string context, out string erMsg)
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
                    var roleId = crmUserBll.UserRoleId(entity.Id);
                    feProcessBll.Community.Add(entity.DeptId);
                    feProcessBll.RuleCode.Add("@DeptId", entity.DeptId);   //对应的部门

                    feProcessBll.FullName = flowName;
                    feProcessBll.IdeaCreateDate = DateTime.Now.ToString(AppConst.DateFormatLong);

                    var ideaTitle = "【" + entity.DeptName + "】【" + entity.BeforeUserName + "】" + flowName;     //待办事事宜标题

                    var note = "";      //短信内容
                    if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                    {
                        note = string.Format("您有一条来自【{0}】【{1}】的调班审批！", entity.DeptName, entity.BeforeUserName);
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
                                note = string.Format("您的调班申请已审批通过！");
                            }
                            else
                            {
                                note = string.Format("您有一条来自【{0}】【{1}】的调班审批！", entity.DeptName, entity.BeforeUserName);
                            }
                            flag = feProcessBll.SendProcess(worklistId, ideaTitle, userId, formId, idea, true, note);
                        }
                        else if (eType.Equals("disAgree"))  //不同意
                        {
                            note = string.Format("您的调班未审批通过！");
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
                    flag = AlterationApproveReturn(eType, "", formId, flowName, isLastFlow, worklistId, DateTime.Now);
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
        /// 事物新增调班和调班代办消息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddTranByCrmMessageWork(FlightAlterationEntity model)
        {
            return new FlightAlterationDal().AddChangeShift(model);
        }

        /// <summary>
        ///  事物更新调班状态和调班消息状态
        /// </summary>
        /// <param name="applyId"></param>
        /// <param name="state"></param>
        /// <param name="flowName"></param>
        /// <param name="eType"></param>
        /// <param name="worklistId"></param>
        /// <param name="ideadate">yyyy-MM-dd HH:mm:ss</param>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public bool UpdataTranByCrmMessageWork(string formId, int state, string flowName, string eType, string worklistId, string ideadate, BaseUserEntity currentUser)
        {
            FlightAlterationEntity entity = Get(formId);         //请假实体

            if (state == -1)
            {
                entity.Status = -1;
                entity.UpdateBy = currentUser.UserName;
                entity.UpdateId = currentUser.Id;
                entity.UpdateOn = DateTime.Now;

                _dal.UpdataChangeShift(entity);

            }
            else
            {

                #region 申请流程

                var flag = false;          //审批状态
                var rtMsg = "审批发送成功！";    //返回内容
                var isLastFlow = false;    //当前流程是否为最后一步流程
                try
                {
                    entity.Status = 1;
                    entity.UpdateBy = currentUser.UserName;
                    entity.UpdateId = currentUser.Id;
                    entity.UpdateOn = DateTime.Now;

                    _dal.UpdataChangeShift(entity);

                    var ideaTitle = "";

                    //审核通过后,调用方法进行相应的处理
                    switch (flowName)
                    {
                        case "调班审批":
                            {
                                _feProcessBll.RuleCode.Add("@DeptId", entity.DeptId);   //对应的部门

                                _feProcessBll.Community.Add(entity.DeptId);
                                ideaTitle = "【" + entity.DeptName + "】【" + entity.BeforeUserName + "】" + flowName;     //待办事事宜标题
                            }
                            break;
                    }

                    _feProcessBll.FullName = flowName;
                    _feProcessBll.IdeaCreateDate = ideadate;

                    var note = "";
                    if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                    {
                        rtMsg = "【" + flowName + "】流程发启成功！";
                        note = string.Format("您有一条来自【{0}】【{1}】的调班审批！", entity.DeptName, entity.BeforeUserName);
                        //第一次进入
                        flag = _feProcessBll.StarProcess(flowName, ideaTitle, entity.BeforeUserId, formId, entity.Reason, true, note);
                    }
                    else
                    {
                        if (eType.Equals("agree")) //同意
                        {
                            if (_feProcessBll.IsNextEndProcess(worklistId))
                            {
                                isLastFlow = true;
                                note = string.Format("您的调班已审批通过！");
                            }
                            else
                            {
                                note = string.Format("您有一条来自【{0}】【{1}】的调班审批！", entity.DeptName, entity.BeforeUserName);
                            }
                            flag = _feProcessBll.SendProcess(worklistId, ideaTitle, currentUser.Id, formId, entity.Reason, true, note);
                        }
                        else if (eType.Equals("disAgree"))  //不同意
                        {
                            note = string.Format("您的调班未审批通过！");
                            flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, currentUser.Id, formId, entity.Reason, true, note);
                        }
                    }
                }
                catch (Exception ex)
                {
                    rtMsg = ex.Message;
                    flag = false;
                }
                if (flag)
                {
                    //审批成功后,调用该方法进行相应的数据处理
                    //flag = AlterationApproveReturn(eType, currentUser.Id, formId, flowName, isLastFlow,
                    //                                            worklistId, DateTime.Now);



                }

                #endregion
            }

            return true;

        }

        /// <summary>
        /// 审批
        /// </summary>
        /// <param name="formId">表单编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="eType">审批类型：agree、disAgree、apply</param>
        /// <param name="idea">审批意见</param>
        /// <param name="ideadate">审批日期</param>
        /// <param name="worklistId">消息编号</param>
        /// <returns></returns>
        public bool AlterationApproveT(string formId, string flowName, string eType, string idea, string ideadate, string worklistId, BaseUserEntity currentUser)
        {
            var flag = false;          //审批状态
            var rtMsg = "审批发送成功！";    //返回内容
            var isLastFlow = false;    //当前流程是否为最后一步流程
            try
            {

                var entity = new FlightAlterationBll().Get(formId);         //请假实体
                var ideaTitle = "";

                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "调班审批":
                        {
                            _feProcessBll.RuleCode.Add("@DeptId", entity.DeptId);   //对应的部门

                            _feProcessBll.Community.Add(entity.DeptId);
                            ideaTitle = "【" + entity.DeptName + "】【" + entity.BeforeUserName + "】" + flowName;     //待办事事宜标题
                        }
                        break;
                }

                _feProcessBll.FullName = flowName;
                _feProcessBll.IdeaCreateDate = ideadate;

                var note = "";
                if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                {
                    rtMsg = "【" + flowName + "】流程发启成功！";
                    note = string.Format("您有一条来自【{0}】【{1}】的调班审批！", entity.DeptName, entity.BeforeUserName);
                    //第一次进入
                    flag = _feProcessBll.StarProcess(flowName, ideaTitle, currentUser.Id, formId, idea, true, note);
                }
                else
                {
                    if (eType.Equals("agree")) //同意
                    {
                        if (_feProcessBll.IsNextEndProcess(worklistId))
                        {
                            isLastFlow = true;
                            note = string.Format("您的调班已审批通过！");
                        }
                        else
                        {
                            note = string.Format("您有一条来自【{0}】【{1}】的调班审批！", entity.DeptName, entity.BeforeUserName);
                        }
                        flag = _feProcessBll.SendProcess(worklistId, ideaTitle, currentUser.Id, formId, idea, true, note);
                    }
                    else if (eType.Equals("disAgree"))  //不同意
                    {
                        note = string.Format("您的调班未审批通过！");
                        flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, currentUser.Id, formId, idea, true, note);
                    }
                }
            }
            catch (Exception ex)
            {
                rtMsg = ex.Message;
                flag = false;
            }
            if (flag)
            {
                //审批成功后,调用该方法进行相应的数据处理
                flag = new FlightAlterationBll().AlterationApproveReturn(eType, currentUser.Id, formId, flowName, isLastFlow,
                                                            worklistId, DateTime.Now);
            }
            return flag;
        }

        /// <summary>
        /// 事物删除调班和消息状态
        /// </summary>
        /// <returns></returns>
        public bool deleTranByCrmMessageWork(FlightAlterationEntity model)
        {
            return _dal.UpdataChangeShift(model);
        }
    }
}
