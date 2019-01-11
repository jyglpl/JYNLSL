//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="WF_ProcessInstanceBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/8/5 11:25:32
//  功能描述：WF_ProcessInstance业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.DataAccess.WorkFlow;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.WorkFlow;

namespace Yookey.WisdomClassed.SIP.Business.WorkFlow
{
    /// <summary>
    /// WF_ProcessInstance业务逻辑
    /// </summary>
    public class WfProcessInstanceBll : BaseBll<WfProcessInstanceEntity>
    {
        public WfProcessInstanceBll()
        {
            BaseDal = new WfProcessInstanceDal();
        }

        private string _mSendActivityID = "";


        /// <summary>
        /// 获取消息过程
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<WfProcessInstanceEntity> GetSearchResult(WfProcessInstanceEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(WfProcessInstanceEntity.Parm_WF_ProcessInstance_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.Id))
            {
                queryCondition.AddEqual(WfProcessInstanceEntity.Parm_WF_ProcessInstance_Id, search.Id);
            }
            return Query(queryCondition) as List<WfProcessInstanceEntity>;
        }

        /// <summary>
        /// 结束流程
        /// 添加人：周 鹏
        /// 添加时间：2014-08-05
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="workListId">消息ID</param>
        public void EndProcessInstance(string workListId)
        {
            var workListEntity = new CrmMessageWorkBll().Get(workListId);   //消息编号
            var entity = Get(workListEntity.ProcessInstanceID);
            entity.EndDate = DateTime.Now;
            entity.RowStatus = 1;
            Update(entity);
        }

        /// <summary>
        /// 判断流程是否已经开启
        /// 添加时间：2014-08-05
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="fullName">流程编号</param>
        /// <param name="formID">表单编号</param>
        /// <returns></returns>
        public bool IsStartProcess(string fullName, string formID)
        {
            var processInstanceID = new WfProcessInstanceDal().ProcessInstanceID(fullName, formID);
            return !string.IsNullOrEmpty(processInstanceID);
        }

        /// <summary>
        /// 通过流程实例名称找到其流程ID
        /// 添加人：周 鹏
        /// 添加时间：2014-08-05
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="fullName">流程实例名称</param>
        /// <returns></returns>
        private string ProcessID(string fullName)
        {
            return new WfProcessInstanceDal().ProcessID(fullName);
        }

        /// <summary>
        /// 开始流程的方法
        /// </summary>
        /// <param name="fullName">流程名称</param>
        /// <param name="formID">表单Id</param>
        /// <param name="senderUser">创建人</param>
        /// <param name="formData">意见,可以为空</param>
        /// <param name="formAddress">页面地址</param>
        /// <param name="actioner">接收人多个用逗号分开</param>
        /// <param name="actionName">操作类别</param>
        /// <param name="title">消息标题</param>
        /// <param name="level">角色级别</param>
        /// <param name="duty">职务</param>
        /// <param name="activityInstanceID"></param>
        /// <param name="sendActivityID"></param>
        /// <param name="ideaCreateDate"></param>
        /// <param name="isSendMsg">是否发送短信</param>
        /// <param name="msg">短信内容</param>
        /// <returns>发送是否成功</returns>
        public string FE_StartProcessInstance(string fullName, string formID,
            string senderUser, string formData, string formAddress, string actioner, string actionName, string title,
            string level, string duty, string activityInstanceID, string sendActivityID, string ideaCreateDate, bool isSendMsg = false, string msg = "")
        {
            _mSendActivityID = sendActivityID;
            var entity = new WfProcessInstanceEntity();
            try
            {
                if (actioner == "")
                {
                    throw new Exception("接受人不能为空");
                }
                var processInstance = "";
                if (!IsStartProcess(fullName, formID))
                {
                    entity.Id = Guid.NewGuid().ToString();
                    processInstance = entity.Id;
                    entity.FormID = formID;
                    entity.ProcessID = ProcessID(fullName);
                    entity.Rounds = 1;
                    entity.StartDate = DateTime.Now;
                    entity.Originator = senderUser;
                    entity.FormData = formData;
                    entity.Status = 0;
                    entity.CreateOn = DateTime.Now;
                    entity.UpdateOn = DateTime.Now;
                    Add(entity);
                }
                if (string.IsNullOrEmpty(processInstance))
                {
                    throw new Exception("流程开始失败");
                }
                if (!string.IsNullOrEmpty(processInstance) && formData != "")     //保存审批意见
                {
                    new CrmIdeaListBll().SaveList(actionName, senderUser, formID, formData, entity.ProcessID, "",
                                                  processInstance, level, duty, ideaCreateDate);
                }
                if (!string.IsNullOrEmpty(processInstance))   //发送待办事宜
                {
                    new CrmMessageWorkBll().SendWorkList(processInstance, senderUser, formID, formAddress, actioner,
                                                         formData, actionName, title, level, activityInstanceID,
                                                         _mSendActivityID, isSendMsg, msg);
                }
                return processInstance;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 流程下移
        /// </summary>
        /// <param name="processInstanceID"></param>
        /// <param name="workListID">消息Id</param>
        /// <param name="actioner">接收人Id</param>
        /// <param name="senderUser">发送人</param>
        /// <param name="formData">意见</param>
        /// <param name="formAddress">页面地址</param>
        /// <param name="formID">表单Id</param>
        /// <param name="actionName"></param>
        /// <param name="title"></param>
        /// <param name="level"></param>
        /// <param name="duty"></param>
        /// <param name="activityInstanceID"></param>
        /// <param name="fullName"></param>
        /// <param name="sendActivityID"></param>
        /// <param name="ideaCreateDate"></param>
        /// <param name="isSendMsg">是否发送短信</param>
        /// <param name="msg">短信内容</param>
        public void FE_Doction(string processInstanceID, string workListID, string actioner, string senderUser, string formData,
            string formAddress, string formID, string actionName, string title, string level, string duty, string activityInstanceID,
            string fullName, string sendActivityID, string ideaCreateDate, bool isSendMsg = false, string msg = "")
        {
            _mSendActivityID = sendActivityID;


            if (!string.IsNullOrEmpty(workListID))
            {
                CrmMessageWorkEntity entity = new CrmMessageWorkBll().OpenWorkList(workListID);
                processInstanceID = entity.ProcessInstanceID;  //查找流程实例
            }

            if (!string.IsNullOrEmpty(processInstanceID))
            {
                //发送消息
                new CrmMessageWorkBll().SendWorkList(processInstanceID, senderUser, formID,
                       formAddress, actioner, formData, actionName, title, level, activityInstanceID, _mSendActivityID, isSendMsg, msg);

                if (!string.IsNullOrEmpty(formData))
                {
                    //string _strProcessID = "";
                    //if (workListID != -1)
                    //    _strProcessID = WorkListM.ProcessInstance.ProcessID.ToString();
                    //else
                    //    _strProcessID = this.ProcessID(fullName);

                    //保存意见
                    var processId = ProcessID(fullName);
                    new CrmIdeaListBll().SaveList(actionName, senderUser, formID, formData, processId, level,
                                                      processInstanceID, level, duty, ideaCreateDate);
                }
            }
        }

        /// <summary>
        /// 根据消息编号查询所审批流程
        /// 添加人：周 鹏
        /// 添加时间：2014-08-07
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        ///           2014-12-29 周 鹏 增加按照流程名称进行查询
        /// </hisotry> 
        /// <param name="worklistId">消息编号</param>
        /// <param name="flowName"></param>
        /// <returns></returns>
        public List<WfProcessInstanceEntity> QueryProcessInstance(string worklistId, string flowName)
        {
            return new WfProcessInstanceDal().QueryProcessInstance(worklistId, flowName);
        }

        public bool DelProcessInstance(string fullName, string formID)
        {
            return new WfProcessInstanceDal().DelProcessInstance(fullName, formID);
        }

        /// <summary>
        /// 更改流程的状态为-1
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="formID"></param>
        /// <returns></returns>
        public bool UpProcessInstance(string fullName, string formID)
        {
            return new WfProcessInstanceDal().UpProcessInstance(fullName, formID);
        }
    }
}
