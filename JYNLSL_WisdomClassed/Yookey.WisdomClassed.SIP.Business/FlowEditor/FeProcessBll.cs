//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_ProcessBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:36
//  功能描述：FE_Process业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.WorkFlow;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.DataAccess.FlowEditor;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.FlowEditor;

namespace Yookey.WisdomClassed.SIP.Business.FlowEditor
{
    /// <summary>
    /// FE_Process业务逻辑
    /// </summary>
    public class FeProcessBll : BaseBll<FeProcessEntity>
    {
        public FeProcessBll()
        {
            BaseDal = new FeProcessDal();
        }

        /// <summary>
        /// 验证流程是否存在
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>  
        /// <param name="processId">流程编号</param>
        /// <returns></returns>
        private bool ExitstProcessId(string processId)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(FeProcessEntity.Parm_FE_Process_RowStatus, "1");
            queryCondition.AddEqual(FeProcessEntity.Parm_FE_Process_ProcessID, processId);
            return QueryCount(queryCondition) > 0;
        }


        /// <summary>
        /// 根据流程名称读取流程
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>  
        /// <param name="flowName">流程名称</param>
        /// <returns></returns>
        public List<FeProcessEntity> QueryByFlowName(string flowName)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(FeProcessEntity.Parm_FE_Process_RowStatus, "1");
            queryCondition.AddEqual(FeProcessEntity.Parm_FE_Process_FlowName, flowName);
            queryCondition.AddOrderBy(FeProcessEntity.Parm_FE_Process_CreateDate, false);

            return Query(queryCondition) as List<FeProcessEntity>;
        }


        /// <summary>
        /// 得到版本号
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="flowName">流程名称</param>
        /// <returns></returns>
        public string GetVersion(string flowName)
        {
            return new FeProcessDal().GetVersion(flowName);
        }

        /// <summary>
        /// 启用流程
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="processId">流程编号</param>
        /// <param name="flowName">流程名称</param>
        /// <returns></returns>
        public bool OpenUnlock(string processId, string flowName)
        {
            return new FeProcessDal().OpenUnlock(processId, flowName);
        }


        /// <summary>
        /// 保存
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveProcess(FeProcessEntity entity)
        {
            //判断该流程是否存在,不存在新增,存在修改
            if (ExitstProcessId(entity.ProcessID))
            {
                entity.UpdateBy = "";
                entity.UpdateOn = DateTime.Now;
                return new FeProcessBll().Update(entity) > 0;
            }
            else
            {
                entity.CreateBy = "";
                entity.CreateDate = DateTime.Now;
                entity.CreateOn = DateTime.Now;
                new FeProcessBll().Add(entity);
                return true;
            }
        }


        /// <summary>
        /// 保存流程
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="xml">XML 内容</param>
        /// <param name="filePath">保存XML路径</param>
        /// <param name="processId">流程的主编号</param>
        /// <param name="mFormerProcessId">发布前的流程编号</param>
        /// <param name="version">版本号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="isIssuance">是否发布</param>
        /// <param name="isFirstIssuance">是否第一次发布</param>
        public bool SaveProcess(string xml, string filePath, string processId, string mFormerProcessId, string version,
                                string flowName, bool isIssuance, bool isFirstIssuance)
        {
            try
            {
                #region 解析、存储、加载XML

                var strXml = xml;
                strXml = strXml.Replace("<?xml:namespace prefix = v ns = \"urn:schemas-microsoft-com:vml\" />",
                                        "<?xml version=\"1.0\" encoding=\"utf-8\" ?> <FlowEditor xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
                //针对IE9+的浏览器
                strXml = strXml.Replace("<?xml:namespace prefix = \"v\" ns = \"urn:schemas-microsoft-com:vml\" />",
                                        "<?xml version=\"1.0\" encoding=\"utf-8\" ?> <FlowEditor xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
                strXml = strXml.Replace("v:", "");
                strXml = strXml.Replace("=DrawFrame", "='DrawFrame'");
                strXml = strXml.Replace("=dragAble", "='dragAble'");
                strXml = strXml.Replace("=EStart", "='EStart'");
                strXml = strXml.Replace("=PointText", "='PointText'");
                strXml = strXml.Replace("=EEnd", "='EEnd'");
                strXml = strXml.Replace("=dragAble", "='dragAble'");
                strXml = strXml.Replace("=PointText", "='PointText'");
                strXml = strXml.Replace("=Line", "='Line'");
                strXml = strXml.Replace("eClick(this);", "'" + "eClick(this);" + "'");
                strXml += "</FlowEditor>";


                //将XML写入至本地
                var strFilePath = filePath + "//Views//FlowEditor//FlowEditor.xml";
                var sw = new StreamWriter(strFilePath, false);
                sw.Write(strXml);
                sw.Close();

                //将XML转换成DataSet对象
                var ds = new DataSet("FlowEditorDS");
                ds.ReadXml(strFilePath);

                #endregion

                processId = string.IsNullOrEmpty(processId) ? Guid.NewGuid().ToString() : processId;

                #region 保存流程主表

                var feProcessEntity = new FeProcessEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProcessID = processId,
                        IsUnlock = string.IsNullOrEmpty(processId),
                        CVersion = version, //流程版本号
                        FlowName = flowName,
                        FlowChart = xml,
                        RowStatus = 1
                    };
                SaveProcess(feProcessEntity);

                #endregion 保存流程主表

                #region 保存结点

                var textBoxDt = ds.Tables["TextBox"];
                for (var i = 0; i < textBoxDt.Rows.Count; i++)
                {
                    //临时保存结点ID
                    var feActivityEntity = new FeActivityEntity();

                    #region 保存结点

                    if (!isIssuance)
                        mFormerProcessId = processId;
                    var strActivityId = new FeActivityBll().GetActivityId(mFormerProcessId,
                                                                          textBoxDt.Rows[i]["TextBox_Text"].ToString());
                    string strFormerActivityId = strActivityId;
                    if (strActivityId == null)
                        strActivityId = Guid.NewGuid().ToString();

                    feActivityEntity.ActivityID = strActivityId;
                    feActivityEntity.ProcessID = processId;
                    feActivityEntity.NoneName = ReplaceStr(textBoxDt.Rows[i]["TextBox_Text"].ToString());
                    var strNoneIds = ReplaceStr(textBoxDt.Rows[i]["TextBox_Text"].ToString()).Split('_');

                    if (strNoneIds.Length <= 1) continue;
                    var strNoneId = strNoneIds[1];
                    if (strNoneId != "EStart" && strNoneId != "EEnd")
                        strNoneId = "C" + strNoneId;
                    feActivityEntity.NoneID = strNoneId;

                    if (isIssuance) //如果是发布，就将已有的结点部份属性Copy给新结点
                    {
                        var activityList = new FeActivityBll().GetActivity(strFormerActivityId);
                        if (activityList.Count > 0)
                        {
                            strNoneId = activityList[0].NoneID;
                            feActivityEntity.NoneID = strNoneId;
                            feActivityEntity.FormAddress = activityList[0].FormAddress;
                            feActivityEntity.SendORWithdrawalActivityID = activityList[0].SendORWithdrawalActivityID;
                            feActivityEntity.FulfillAssemblyName = activityList[0].FulfillAssemblyName;
                            feActivityEntity.FulfillClassFullName = activityList[0].FulfillClassFullName;
                            feActivityEntity.OverdueAssemblyName = activityList[0].OverdueAssemblyName;
                            feActivityEntity.OverdueClassFullName = activityList[0].OverdueClassFullName;
                            feActivityEntity.OverdueHour = activityList[0].OverdueHour;
                            if (!string.IsNullOrEmpty(activityList[0].IsContrastCommunity.ToString()))
                                feActivityEntity.IsContrastCommunity =
                                    bool.Parse(activityList[0].IsContrastCommunity.ToString());
                            if (!string.IsNullOrEmpty(activityList[0].IsContrastRule.ToString()))
                                feActivityEntity.IsContrastRule = bool.Parse(activityList[0].IsContrastRule.ToString());
                            if (!string.IsNullOrEmpty(activityList[0].IsSendOnOpener.ToString()))
                                feActivityEntity.IsSendOnOpener = bool.Parse(activityList[0].IsSendOnOpener.ToString());
                            feActivityEntity.Remark = activityList[0].Remark;
                            feActivityEntity.NoneDisposeManner = activityList[0].NoneDisposeManner;
                            feActivityEntity.NoneDisposeTime = activityList[0].NoneDisposeTime;
                            if (!string.IsNullOrEmpty(activityList[0].DefaultSay))
                                feActivityEntity.DefaultSay = activityList[0].DefaultSay;
                        }
                    }

                    #endregion

                    if (isIssuance) //如果是发布，就将已有的结点部份属性Copy给新结点
                    {
                        #region 保存接收对象

                        var actionInstanceDt = new FeActionInstanceBll().GetActionInstance(strFormerActivityId, -1);
                        for (var ai = 0; ai < actionInstanceDt.Rows.Count; ai++)
                        {
                            var feActionInstanceEntity = new FeActionInstanceEntity()
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    ActionInstanceID = Guid.NewGuid().ToString(),
                                    ActivityID = strActivityId,
                                    CommunityID = actionInstanceDt.Rows[ai]["CommunityID"].ToString(),
                                    CommunityName = actionInstanceDt.Rows[ai]["CommunityName"].ToString(),
                                    UserID = actionInstanceDt.Rows[ai]["UserID"].ToString(),
                                    UserName = actionInstanceDt.Rows[ai]["UserName"].ToString(),
                                    IsUnlock = bool.Parse(actionInstanceDt.Rows[ai]["IsUnlock"].ToString())
                                };
                            new FeActionInstanceBll().Add(feActionInstanceEntity);
                        }

                        #endregion

                        #region 保存规则

                        var ruleCodeDt = new FeRuleCodeBll().GetRuleCode(strFormerActivityId);
                        for (var ai = 0; ai < ruleCodeDt.Rows.Count; ai++)
                        {
                            var ruleCodeEntity = new FeRuleCodeEntity()
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    RuleCodeID = Guid.NewGuid().ToString(),
                                    ActivityID = strActivityId,
                                    RuleClauses = ruleCodeDt.Rows[ai]["RuleClauses"].ToString(),
                                    RiolationRuleID = ruleCodeDt.Rows[ai]["RiolationRuleID"].ToString(),
                                    IsUnlock = bool.Parse(ruleCodeDt.Rows[ai]["IsUnlock"].ToString()),
                                    FulfillAssemblyName = ruleCodeDt.Rows[ai]["FulfillAssemblyName"].ToString(),
                                    FulfillClassFullName = ruleCodeDt.Rows[ai]["FulfillClassFullName"].ToString(),
                                    Remark = ruleCodeDt.Rows[ai]["Remark"].ToString()
                                };
                            new FeRuleCodeBll().Add(ruleCodeEntity);
                        }

                        #endregion
                    }

                    new FeActivityBll().Save(feActivityEntity);
                }

                #endregion 保存结点

                #region 保存节点关系

                if (ds.Tables.Contains("Line"))
                {
                    var lineDt = ds.Tables["Line"];
                    for (var i = 0; i < lineDt.Rows.Count; i++)
                    {
                        var feActionEntity = new FeActionEntity();
                        var tempList = new List<FeActionEntity>();
                        if (isIssuance == false)
                            tempList = new FeActionBll().GetFeAction(
                                ReplaceStr(lineDt.Rows[i]["frompoint"].ToString()),
                                ReplaceStr(lineDt.Rows[i]["topoint"].ToString()), processId);
                        feActionEntity.ActionID = tempList.Count > 0 ? tempList[0].ActionID : Guid.NewGuid().ToString();
                        feActionEntity.ProcessID = processId;
                        feActionEntity.FromPoint = ReplaceStr(lineDt.Rows[i]["frompoint"].ToString());
                        feActionEntity.Topoint = ReplaceStr(lineDt.Rows[i]["topoint"].ToString());
                        feActionEntity.LineID = ReplaceStr(lineDt.Rows[i]["id"].ToString());

                        new FeActionBll().Save(feActionEntity); //保存
                    }
                }

                #endregion 保存节点关系

                #region 退回接收对象ID更新/更新成功规则接收对象ID

                if (isIssuance)
                {
                    new FeActivityBll().UpdateReturnActivityId(mFormerProcessId, processId);
                    new FeRuleCodeBll().UpdateRiolationRuleId(mFormerProcessId, processId);
                }

                #endregion

                #region 如果是第一次发布，就启用此流程

                if (isFirstIssuance)
                {
                    new FeProcessBll().OpenUnlock(processId, flowName);
                }

                #endregion
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 删除流程
        /// 添加人：周 鹏
        /// 添加时间：2014-07-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="processId">流程编号</param>
        /// <returns></returns>
        public bool DeleteProcess(string processId)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(FeProcessEntity.Parm_FE_Process_RowStatus, "1");
            queryCondition.AddEqual(FeProcessEntity.Parm_FE_Process_ProcessID, processId);
            var list = Query(queryCondition) as List<FeProcessEntity>;
            if (list != null && list.Count > 0)
            {
                var entity = list[0];
                entity.RowStatus = 0;
                return Update(entity) > 0;
            }
            return false;
        }

        private string ReplaceStr(string str)
        {
            return str.Replace("\"", "");
        }

        /// <summary>
        /// 得到流程记录
        /// 添加人：张西琼
        /// 添加时间：2014-07-22
        /// </summary>
        /// <param name="flowName">流程名称</param>
        /// <param name="IsUnlock">是否启用 0没有 1启用 不等于0或1就是所有</param>
        /// <param name="isMaxVersion">是否取最大版本号的流程记录</param>
        /// <returns></returns>
        public List<FeProcessEntity> GetProcess(string flowName, int IsUnlock, bool isMaxVersion)
        {
            return new FeProcessDal().DataTableToList(new FeProcessDal().GetProcess(flowName, IsUnlock, isMaxVersion));
        }

        /// <summary>
        /// 得到流程记录
        /// 添加人：张西琼
        /// 添加时间：2014-08-6
        /// </summary>
        /// <param name="flowName">流程名称</param>
        /// <param name="IsUnlock">是否启用 0没有 1启用 不等于0或1就是所有</param>
        /// <param name="isMaxVersion">是否取最大版本号的流程记录</param>
        /// <returns></returns>
        public DataTable GetProcess2(string flowName, int IsUnlock, bool isMaxVersion)
        {
            return new FeProcessDal().GetProcess(flowName, IsUnlock, isMaxVersion);
        }

        /// <summary>
        /// 根据流程Id读取流程
        /// 添加人：张西琼
        /// 添加时间：2014-07-23
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>  
        /// <param name="id">流程Id</param>
        /// <returns></returns>
        public List<FeProcessEntity> QueryByFlowId(string id)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(FeProcessEntity.Parm_FE_Process_ProcessID, id);
            return Query(queryCondition) as List<FeProcessEntity>;
        }

        /// <summary>
        /// 删除流程
        /// 添加人：张西琼
        /// 时间：2014/8/5
        /// </summary>
        /// <param name="processId">流程ID</param>
        /// <returns></returns>
        public bool DelProcess(string processId)
        {
            return new FeProcessDal().DeleteProcess(processId);
        }


        #region 流程审批

        /// <summary>
        /// 退回
        /// </summary>
        /// <param name="workListId">消息编号</param>
        /// <param name="titles">消息标题</param>
        /// <param name="senderID">发送人员ID</param>
        /// <param name="formID">表单ID</param>
        /// <param name="idea">意见</param>
        /// <param name="isSendMsg">是否发送短信</param>
        /// <param name="msg">短信内容</param>
        /// <returns>bool</returns>
        public bool ReturnProcess(string workListId, string titles, string senderID, string formID, string idea, bool isSendMsg, string msg = "")
        {
            try
            {
                //标记为发送流程   
                SendType = 2;
                //标记消息ID
                WorkListId = workListId;
                //用于回滚，记录初次消息ID
                _mWorkListIDRollBack = workListId;
                //标记是那个结点发送的
                SendActivityId = WorkList.ActivityInstanceID;

                //跟据上次发送消息中的结点，得到接收对象
                var activityDr = new FeActivityBll().GetActivity(WorkList.SendActivityID)[0];
                var strProcessID = activityDr.ProcessID;
                //执行发送
                var bReturnValue = SendToWorkList(titles, strProcessID, WorkList.ActivityInstanceID, senderID, formID, idea, isSendMsg, msg);
                new CrmMessageWorkBll().UpdateWorkListState(WorkListId, ExecuteDate);
                return bReturnValue;
            }
            catch (Exception ex)
            {
                RollBackSendAll();
                throw ex;
            }
            return false;
        }


        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="workListId">消息ID</param>
        /// <param name="titles">消息标题</param>
        /// <param name="senderID">发送人员ID</param>
        /// <param name="formID">表单ID</param>
        /// <param name="idea">意见</param>
        /// <param name="isSendMsg">是否发送短信</param>
        /// <param name="msg">短信内容</param>
        /// <returns>bool</returns>
        public bool SendProcess(string workListId, string titles, string senderID, string formID, string idea, bool isSendMsg, string msg = "")
        {
            try
            {
                //标记消息ID
                WorkListId = workListId;
                //用于回滚，记录初次消息ID
                _mWorkListIDRollBack = workListId;
                //标记是那个结点发送的
                SendActivityId = WorkList.ActivityInstanceID;
                //标记为发送流程
                SendType = 1;

                //跟据上次发送消息中的结点，得到接收对象
                var activityDr = new FeActivityBll().GetActivity(WorkList.ActivityInstanceID)[0];
                var strProcessID = activityDr.ProcessID;
                var bReturnValue = false;
                if (bool.Parse(activityDr.IsContrastRule.ToString()) == false || new FeRuleCodeBll().GetRuleCode(SendActivityId, 1).Rows.Count <= 0)//没有规则
                {
                    //得到接收结点
                    var actionDt = new FeActionDal().GetTakeSendFE_Action(WorkList.ActivityInstanceID, strProcessID);
                    if (actionDt.Rows.Count <= 0)
                    {
                        throw new Exception("未找到要接收结点；流程ID：" + strProcessID + "；结点【" + activityDr.NoneName + "】……");
                    }
                    //如果有多个接收结点，就分别发送
                    for (var i = 0; i < actionDt.Rows.Count; i++)
                    {
                        //执行发送
                        bReturnValue = SendToWorkList(titles, strProcessID, actionDt.Rows[i]["ActivityID"].ToString(), senderID, formID, idea, isSendMsg, msg);
                    }
                }
                else
                {
                    //执行发送
                    bReturnValue = SendToWorkList(titles, strProcessID, WorkList.ActivityInstanceID, senderID, formID, idea, isSendMsg, msg);
                }
                return bReturnValue;
            }
            catch (Exception ex)
            {
                RollBackSendAll();
                throw ex;
            }
            return false;
        }


        /// <summary>
        /// 开启流程
        /// 添加人：周 鹏
        /// 添加时间：2014-08-05
        /// </summary>
        /// <param name="flowName">流程名称</param>
        /// <param name="titles">消息标题</param>
        /// <param name="senderID">发送人员ID</param>
        /// <param name="formID">表单ID</param>
        /// <param name="idea">意见</param>
        /// <param name="isSendMsg">是否发送短信</param>
        /// <param name="msg">短信内容</param>
        /// <returns>bool</returns>
        public bool StarProcess(string flowName, string titles, string senderID, string formID, string idea, bool isSendMsg, string msg = "")
        {
            try
            {
                FullName = flowName;
                SendType = 0;
                var strProcessId = new FeProcessDal().GetVersionMaxProcessId(flowName); //得到流程ID
                if (strProcessId.Equals(""))
                {
                    throw new Exception("未找到流程[" + flowName + "]的主键，可能的原因是没有发布……");
                }

                var activityDr = new FeActivityDal().GetActivity(strProcessId, "EStart").Rows[0]; //得到开始结点记录
                //标记是那个结点发送的
                SendActivityId = activityDr["ActivityID"].ToString();
                bool bReturnValue = false;
                if (bool.Parse(activityDr["IsContrastRule"].ToString()) == false ||
                    new FeRuleCodeBll().GetRuleCode(SendActivityId, 1).Rows.Count <= 0) //没有规则
                {
                    //得到接收结点
                    DataTable actionDt = new FeActionDal().GetTakeStartFE_Action("EStart", strProcessId);
                    if (actionDt.Rows.Count <= 0)
                    {
                        throw new Exception("未找到要接收结点；流程ID" + strProcessId + "；所在结点【开始结点】……");
                    }
                    for (var i = 0; i < actionDt.Rows.Count; i++) //如果有多个接收结点，就分别发送
                    {
                        //执行发送
                        bReturnValue = SendToWorkList(titles, strProcessId, actionDt.Rows[i]["ActivityID"].ToString(), senderID, formID, idea, isSendMsg, msg);
                        if (SendType == 0)//如果已开启，次第应为发送
                            SendType = 1;
                    }
                }
                else
                {
                    bReturnValue = SendToWorkList(titles, strProcessId, SendActivityId, senderID, formID, idea, isSendMsg, msg);
                }
                return bReturnValue;
            }
            catch (Exception ex)
            {
                RollBackSendAll();
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 是否进行规则校验，用于SendToWorkList递归调用，只用在SendToWorkList方法中
        /// </summary>
        private bool _mBIsVerifyRule = true;

        /// <summary>
        /// 向消息表中添加记录
        /// </summary>
        /// <param name="titles">消息标题</param>
        /// <param name="processId">流程ID</param>
        /// <param name="activityId">接收结点ID；如果为退回activityID为退回结点ID，而不是接收结点ID</param>
        /// <param name="senderId">发送人员ID</param>
        /// <param name="formId">表单ID</param>
        /// <param name="idea">意见</param>
        /// <param name="isSendMsg">是否发送短信</param>
        /// <param name="msg">短信内容</param>
        /// <returns>bool</returns>
        private bool SendToWorkList(string titles, string processId, string activityId, string senderId, string formId,
                                    string idea, bool isSendMsg, string msg = "")
        {
            FeActivityEntity activityRow = new FeActivityBll().GetActivity(activityId)[0]; //得到结点记录（接收结点）
            FeActivityEntity activityRowSend = new FeActivityBll().GetActivity(SendActivityId)[0]; //得到结点记录（发送结点）

            //职务
            string strNoneName = activityRowSend.NoneName;
            if (!string.IsNullOrEmpty(activityRowSend.Remark))
                strNoneName = activityRowSend.Remark;
            //页面地址
            string strFormAddress = activityRow.FormAddress;

            //接收人员iD
            var actionerIDList = new List<string>();

            #region 退回，设置相应数据

            if (SendType == 2)
            {
                string strSendOrWithdrawalActivityID = activityRow.SendORWithdrawalActivityID; //退回接收对象ID
                switch (strSendOrWithdrawalActivityID)
                {
                    case "3": //至发送人  
                        {
                            DataTable dtTemp = new CrmMessageWorkDal().GetWorkListDrawNear(WorkListId); //得到消息的临近的一条消息
                            activityId = dtTemp.Rows[0]["SendActivityID"].ToString(); //设置接收对象为，发送对象
                            actionerIDList.Add(dtTemp.Rows[0]["SenderID"].ToString()); //设置接收人为，发送人

                            activityRow = new FeActivityBll().GetActivity(activityId)[0]; //得到结点记录
                            strFormAddress = activityRow.FormAddress; //设置页面地址

                            //标记是那个结点发送的
                            SendActivityId = dtTemp.Rows[0]["ActivityInstanceID"].ToString();
                        }
                        break;
                    case "1": //至发启人           
                        {
                            activityId =
                                new FeActivityDal().GetActivity(processId, "EStart").Rows[0]["ActivityID"].ToString();
                            //设置接收对象为开始结点
                            actionerIDList.Add(WorkList.ProcessInstance.Originator); //设置接收对象为发启人
                            activityRow = new FeActivityBll().GetActivity(activityId)[0]; //得到结点记录
                            strFormAddress = activityRow.FormAddress; //设置页面地址
                        }
                        break;
                    case "2": //至发启人并结束流程
                        {
                            activityId =
                                new FeActivityDal().GetActivity(processId, "EStart").Rows[0]["ActivityID"].ToString();
                            //设置接收对象为开始结点
                            actionerIDList.Add(WorkList.ProcessInstance.Originator); //设置接收对象为发启人

                            activityRow = new FeActivityBll().GetActivity(activityId)[0]; //得到结点记录
                            strFormAddress = activityRow.FormAddress; //设置页面地址

                            #region 设置页面地址，标记已结束流程

                            if (strFormAddress.Contains("?"))
                                strFormAddress += "&FE_End=true";
                            else
                                strFormAddress += "?FE_End=true";

                            #endregion
                        }
                        break;
                    default: //发给指定结点
                        {
                            activityId = strSendOrWithdrawalActivityID;
                            activityRow = new FeActivityBll().GetActivity(activityId)[0]; //得到结点记录
                            strFormAddress = activityRow.FormAddress; //设置页面地址
                        }
                        break;
                }
            }

            #endregion

            #region 得到接收人员

            if (actionerIDList.Count <= 0) //如果是退回且已有接收人员，标明退回的不是指定结点，而是（至发送人,至发启人,至发启人并结束流程），所有不走内部代码
            {
                //发送结点是否是服务器处理
                bool bNoneDisposeManner = false;
                if (activityRowSend.NoneDisposeManner.ToString().Equals("1"))
                {
                    bNoneDisposeManner = true;
                    IsNoneDisposeManner = true;
                }

                #region 是否发送给发启人（发送结点）

                bool bIsSendOnOpener = bool.Parse(activityRowSend.IsSendOnOpener.ToString());

                //如果是服务器发送
                if (activityRowSend.NoneDisposeManner.ToString().Equals("1"))
                    bIsSendOnOpener = bool.Parse(activityRow.IsSendOnOpener.ToString());

                #endregion

                #region 流程如果走到结束结点，且不发送给发启人，就提示流程结束（发送结点）

                if (activityRowSend.NoneID.Equals("EEnd") && bIsSendOnOpener == false)
                {
                    throw new Exception("流程已结束，您不能再继续发送……");
                }

                #endregion

                #region 校验是否“匹配规则”；“匹配部门”（发送结点）

                bool bIsContrastRule = bool.Parse(activityRowSend.IsContrastRule.ToString()); //此结点是否要求匹配规则
                //如果是服务器发送
                if (activityRowSend.NoneDisposeManner.ToString().Equals("1"))
                    bIsContrastRule = bool.Parse(activityRow.IsContrastRule.ToString());
                if (bIsContrastRule && RuleCode.Count <= 0 && bNoneDisposeManner == false)
                {
                    throw new Exception("结点【" + activityRow.NoneName + "】要求有匹配规则，但未提供规则……");
                }
                bool bIsContrastCommunity = bool.Parse(activityRow.IsContrastCommunity.ToString()); //此结点是否要求匹配部门
                if (bIsContrastCommunity && Community.Count <= 0 && bNoneDisposeManner == false &&
                    activityId != SendActivityId)
                {
                    throw new Exception("结点【" + activityRow.NoneName + "】要求有匹配部门，但未提供部门匹配项……");
                }

                #endregion 校验是否“匹配规则”；“匹配部门”（发送结点）

                #region  得到接收人员ID

                if (bIsSendOnOpener == false) //如果结点设置为发送给发启人且结束流程，就不寻找人员
                {
                    #region 得到接收人员ID

                    if (RuleCode.Count > 0 && bIsContrastRule && _mBIsVerifyRule) //有规则，且此结点要求匹配规则 && _bNoneDisposeManner == false
                    {
                        bool bIsContinue = false;  //是否继续执行代码，如果符合规则并且是（至发送人，至发启人，至发启人并结束流程就不执行批定代码）
                        DataTable ruleCode = new FeRuleCodeBll().GetRuleCode(SendActivityId, 1); //得到规则记录
                        for (int i = 0; i < ruleCode.Rows.Count; i++)
                        {
                            #region 得到规则表达式

                            string strRuleCode = "";
                            strRuleCode = ruleCode.Rows[i]["RuleClauses"].ToString();
                            foreach (string item in RuleCode.Keys)
                            {
                                if (strRuleCode.Contains(item))
                                {
                                    strRuleCode = strRuleCode.Replace(item, "'" + RuleCode[item] + "'");
                                }
                            }

                            #endregion

                            #region 跟据规则进行发送

                            if (!string.IsNullOrEmpty(strRuleCode))
                            {
                                DataTable dtRuleCodeIf = new FeProcessDal().ExecuteDataTable("SELECT 1 WHERE 1=1 " + " and " + strRuleCode); //执行规则表达式
                                if (dtRuleCodeIf.Rows.Count > 0) //执行成功
                                {
                                    switch (ruleCode.Rows[i]["RiolationRuleID"].ToString())
                                    {
                                        case "3": //至发送人
                                            {
                                                DataTable dtTemp = new CrmMessageWorkDal().GetWorkListDrawNear(WorkListId);
                                                //得到消息的临近的一条消息
                                                activityRowSend = new FeActivityBll().GetActivity(SendActivityId)[0];
                                                //得到结点记录                                           
                                                //执行发送
                                                SendToWorkList(titles, dtTemp.Rows[0]["SendActivityID"].ToString(), senderId, dtTemp.Rows[0]["SenderID"].ToString(), formId, idea, activityRowSend.FormAddress, activityRowSend.NoneName, isSendMsg, msg);
                                                bIsContinue = false;
                                            }
                                            break;
                                        case "1": //至发启人 
                                            {
                                                activityId =
                                                    new FeActivityDal().GetActivity(processId, "EStart").Rows[0][
                                                        "ActivityID"].ToString(); //设置接收对象为开始结点
                                                activityRowSend = new FeActivityBll().GetActivity(SendActivityId)[0];
                                                //得到结点记录
                                                //执行发送
                                                SendToWorkList(titles, activityRow.ActivityID, senderId, WorkList.ProcessInstance.Originator, formId, idea, activityRowSend.FormAddress, activityRowSend.NoneName, isSendMsg, msg);
                                                bIsContinue = false;
                                            }
                                            break;
                                        case "2": //至发启人并结束流程
                                            {
                                                activityId = new FeActivityDal().GetActivity(processId, "EStart").Rows[0]["ActivityID"].ToString(); //设置接收对象为开始结点
                                                activityRowSend = new FeActivityBll().GetActivity(SendActivityId)[0];
                                                //得到结点记录
                                                strFormAddress = activityRow.FormAddress; //设置页面地址

                                                #region 设置页面地址，标记已结束流程

                                                if (strFormAddress.Contains("?"))
                                                    strFormAddress += "&FE_End=true";
                                                else
                                                    strFormAddress += "?FE_End=true";

                                                #endregion

                                                SendActivityId =
                                                    new FeActivityDal().GetActivity(processId, "EEnd").Rows[0]["ActivityID"].ToString(); //标记发送结点是结束结点
                                                //执行发送
                                                SendToWorkList(titles, activityRowSend.ActivityID, senderId, WorkList.ProcessInstance.Originator, formId, idea, strFormAddress, activityRowSend.NoneName, isSendMsg, msg);
                                                bIsContinue = false;
                                            }
                                            break;
                                        default: //发给指定结点，就递归调用自身进行发送 
                                            {
                                                bIsContinue = true;
                                                _mBIsVerifyRule = false;
                                                if (SendToWorkList(titles, processId, ruleCode.Rows[i]["RiolationRuleID"].ToString(), senderId, formId, idea, isSendMsg, msg))
                                                {
                                                    //更新消息表状态
                                                    if (!string.IsNullOrEmpty(WorkListId) && bNoneDisposeManner)
                                                        new CrmMessageWorkBll().UpdateWorkListState(WorkListId, ExecuteDate);
                                                    return true;
                                                }
                                                return false;
                                            }
                                    }
                                }
                            }
                            #endregion
                        }
                        if (!bIsContinue)
                            return true;
                    }
                    else if (bool.Parse(activityRow.IsSendOnOpener.ToString())) // && _bNoneDisposeManner == false
                    {
                        #region 如果发送结点没有规则，且接收结点设置了（发送给发启人且结束流程）就发给发启人
                        actionerIDList.Clear();
                        actionerIDList.Add(WorkList.ProcessInstance.Originator);

                        activityId = new FeActivityDal().GetActivity(processId, "EStart").Rows[0]["ActivityID"].ToString();//设置接收对象为开始结点
                        activityRow = new FeActivityBll().GetActivity(activityId)[0];//得到结点记录
                        strFormAddress = activityRow.FormAddress;//设置页面地址

                        #region 设置页面地址，标记已结束流程
                        if (strFormAddress.Contains("?"))
                            strFormAddress += "&FE_End=true";
                        else
                            strFormAddress += "?FE_End=true";

                        SendActivityId = new FeActivityDal().GetActivity(processId, "EEnd").Rows[0]["ActivityID"].ToString();//标记发送结点是结束结点

                        #endregion
                        #endregion 如果发送结点没有规则，且接收结点设置了（发送给发启人且结束流程）就发给发启人
                    }
                    else
                    {
                        actionerIDList = GetActionerId(activityId, bIsContrastCommunity);//得到接收人员ID
                    }

                    #endregion
                }
                else //将接收人员设置为发启人且结束流程
                {
                    #region 如果发送结点设置了（发送给发启人且结束流程）就发给发启人，不考虑规则及部门
                    actionerIDList.Clear();
                    actionerIDList.Add(WorkList.ProcessInstance.Originator);

                    activityId = new FeActivityDal().GetActivity(processId, "EStart").Rows[0]["ActivityID"].ToString();//设置接收对象为开始结点
                    activityRow = new FeActivityBll().GetActivity(activityId)[0];//得到结点记录
                    strFormAddress = activityRow.FormAddress;//设置页面地址

                    #region 设置页面地址，标记已结束流程
                    if (strFormAddress.Contains("?"))
                        strFormAddress += "&FE_End=true";
                    else
                        strFormAddress += "?FE_End=true";

                    SendActivityId = new FeActivityDal().GetActivity(processId, "EEnd").Rows[0]["ActivityID"].ToString();//标记发送结点是结束结点

                    #endregion 如果发送结点设置了（发送给发启人且结束流程）就发给发启人，不考虑规则及部门


                    #endregion
                }

                #endregion 得到接收人员
            }

            #endregion 得到接收人员

            #region 如果接收结点的下一个结点是结束结点，且不发送给发启人，就标明流程已走到结束
            if (SendType != 2)//退回无需校验
            {
                List<FeActionEntity> _ActionDT = new FeActionBll().GetFeAction(activityRow.NoneID, "EEnd", processId);
                if (_ActionDT.Count > 0)//当前结点的下一个结点是结束结点
                {
                    DataTable _dtNodeTemp = new FeActivityDal().GetActivity(processId, "EEnd");
                    bool _bSendTemp = (new FeActionInstanceBll().GetActionInstance(_dtNodeTemp.Rows[0]["activityID"].ToString(), 1).Rows.Count > 0) ? true : false;
                    if (bool.Parse(_dtNodeTemp.Rows[0]["IsSendOnOpener"].ToString()) == false && _bSendTemp == false)//不发送给发启人
                    {
                        if (strFormAddress.Contains("FE_End") == false && strFormAddress.Contains("?") == false)
                            strFormAddress += "?FE_End=true";
                        else if (strFormAddress.Contains("FE_End") == false && strFormAddress.Contains("?") == true)
                            strFormAddress += "&FE_End=true";
                    }
                }
            }
            #endregion

            #region 向消息表中插入记录

            if (actionerIDList.Count <= 0)
            {
                //没有接收人且接收节点是结束节点,就停止流程实例
                if (activityRow.NoneID.Equals("EEnd"))
                {
                    new WfProcessInstanceBll().EndProcessInstance(WorkListId);
                    return true;
                }
                throw new Exception("结点【" + activityRow.NoneName + "】，未找到接收人员……");
            }
            #region 串连接收人
            if (SendType == 0)
            {
                string _strActioner = "";
                for (int i = 0; i < actionerIDList.Count; i++)
                {
                    _strActioner += actionerIDList[i] + ",";
                }
                _strActioner = _strActioner.Substring(0, _strActioner.Length - 1);
                actionerIDList.Clear();
                actionerIDList.Add(_strActioner);
            }
            #endregion

            if (activityRowSend.DefaultSay != "")
                idea = activityRowSend.DefaultSay;
            //向消息表中添加记录
            for (int i = 0; i < actionerIDList.Count; i++)
            {
                if (actionerIDList.Count > 0 && i > 0)
                {
                    SendToWorkList(titles, activityId, senderId, actionerIDList[i], formId, "", strFormAddress, strNoneName, isSendMsg, msg);
                    continue;
                }
                SendToWorkList(titles, activityId, senderId, actionerIDList[i], formId, idea, strFormAddress, strNoneName, isSendMsg, msg);
            }

            _mBIsVerifyRule = true;
            _mActionerIDList = actionerIDList;
            #endregion

            //更新消息表状态
            if (!string.IsNullOrEmpty(WorkListId) && IsNoneDisposeManner)
                new CrmMessageWorkBll().UpdateWorkListState(WorkListId, ExecuteDate);

            #region 发送成功且配置了成功规则，执行成功规则方法
            try
            {

                string _strFulfillAssemblyName = activityRowSend.FulfillAssemblyName;//成功规则命名空间
                string _strFulfillClassFullName = activityRowSend.FulfillClassFullName;//成功规则类名
                if (_strFulfillAssemblyName != "" && _strFulfillClassFullName != "")
                {
                    //////这里代码先进行注释   周 鹏
                    //////FE_Process_IRule _FE_Process_IRule = CreateInstance(_strFulfillAssemblyName, _strFulfillClassFullName);
                    //////if (_FE_Process_IRule != null)
                    //////{
                    //////    int _iworkListid = m_TWorkListManager.GetWorkListID(formID);
                    //////    if (_iworkListid == -1)
                    //////        _iworkListid = WorkListID;
                    //////    _FE_Process_IRule.SendSucceedRule(_iworkListid.ToString());
                    //////}
                }
            }
            catch (System.Exception ex) { }
            #endregion

            return true;
        }


        /// <summary>
        /// 向消息表中添加记录
        /// 添加人：周 鹏
        /// 添加时间：2014-08-05
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="titles">消息标题</param>
        /// <param name="activityID">接收结点ID</param>
        /// <param name="senderID">发送人员ID</param>
        /// <param name="actionerID">接收人员ID</param>
        /// <param name="formID">表单ID</param>
        /// <param name="idea">意见</param>
        /// <param name="fromAddress">页面地址</param>
        /// <param name="noneName">结点名称</param>
        /// <param name="isSendMsg">是否发送短信</param>
        /// <param name="msg">短信内容</param>
        /// <returns></returns>
        private bool SendToWorkList(string titles, string activityID, string senderID,
            string actionerID, string formID, string idea, string fromAddress, string noneName, bool isSendMsg, string msg = "")
        {

            if (!string.IsNullOrEmpty(WorkListId) && IsJyWorkListState)//该消息已经操作过
            {
                var worklistEntity = new CrmMessageWorkBll().Get(WorkListId);
                if (worklistEntity.State.ToString() == "2")
                    return true;
            }

            //用户所属角色

            //var userRoles = new CrmRoleBll().GetUserRoles(senderID);
            //var _strAttriubuteValue = userRoles[0].RoleName;

            var _strAttriubuteValue = "0";  //角色级别

            if (_strAttriubuteValue.Length > 2)
                _strAttriubuteValue = "";

            #region 设置意见的创建日期

            //2015-02-06 周 鹏 去除人为日期设置

            string _strIdeaCreateDate = new CrmIdeaListDal().GetIdeaListCreateDate(formID);
            if (_strIdeaCreateDate != "")
            {
                if (IsNoneDisposeManner)
                    IdeaCreateDate = DateTime.Parse(IdeaCreateDate).ToShortDateString();
                DateTime _dtIdeaCreateDate = DateTime.Parse(IdeaCreateDate);

                #region 如果传过来日期的年月日 不等于 消息的发布日期年月日 就以传过来的为主
                if ((_dtIdeaCreateDate.Year != DateTime.Parse(_strIdeaCreateDate).Year
                    || _dtIdeaCreateDate.Month != DateTime.Parse(_strIdeaCreateDate).Month
                    || _dtIdeaCreateDate.Day != DateTime.Parse(_strIdeaCreateDate).Day) && _dtIdeaCreateDate.Hour != 0)
                {
                    //IdeaCreateDate = _dtIdeaCreateDate.Year + "-" + _dtIdeaCreateDate.Month + "-" + _dtIdeaCreateDate.Day + " "
                    //        + DateTime.Parse(_strIdeaCreateDate).Hour + ":" + DateTime.Parse(_strIdeaCreateDate).Minute + ":" + DateTime.Parse(_strIdeaCreateDate).Second;

                    IdeaCreateDate = _dtIdeaCreateDate.ToString("yyyy-MM-dd HH:mm:ss");
                }
                #endregion

                else if (_dtIdeaCreateDate.Hour == 0)
                {
                    #region 传过来的日期不存在时分秒 就取当前时分+消息的秒

                    IdeaCreateDate = _dtIdeaCreateDate.Year + "-" + _dtIdeaCreateDate.Month + "-" +
                                     _dtIdeaCreateDate.Day + " "
                                     + DateTime.Parse(_strIdeaCreateDate).Hour + ":" +
                                     DateTime.Parse(_strIdeaCreateDate).Minute + ":" +
                                     DateTime.Parse(_strIdeaCreateDate).Second;
                    #endregion
                }
                else
                {
                    //#region 传过来的有时分秒 就去传过来的时分+消息秒
                    //IdeaCreateDate = _dtIdeaCreateDate.Year + "-" + _dtIdeaCreateDate.Month + "-" + _dtIdeaCreateDate.Day + " "
                    //   + _dtIdeaCreateDate.Hour + ":" + _dtIdeaCreateDate.Minute + ":" + DateTime.Parse(_strIdeaCreateDate).Second;
                    //#endregion

                    #region  传过来的日期不存在时分秒 就取当前时分+消息的秒

                    IdeaCreateDate = _dtIdeaCreateDate.ToString("yyyy-MM-dd") + " " +
                                     +DateTime.Parse(_strIdeaCreateDate).Hour + ":" +
                                     DateTime.Parse(_strIdeaCreateDate).Minute + ":" +
                                     DateTime.Parse(_strIdeaCreateDate).Second;

                    #endregion
                }


                Random ra = new Random();
                int _iRandom = ra.Next(1, 5);
                while (_iRandom > 5 || _iRandom < 1)
                {
                    _iRandom = ra.Next(1, 5);
                }
                IdeaCreateDate = DateTime.Parse(IdeaCreateDate).AddMinutes(3).ToString();//默认添加3分钟
                IdeaCreateDate = DateTime.Parse(IdeaCreateDate).AddSeconds(10).ToString();//默认添加10秒钟
            }

            #endregion

            try
            {
                //// TODO: 增加是否发送短信过滤
                ////临时过滤先判断死
                //if ((actionerID.Equals("26ab6f90-7328-493a-a649-a8dc9f81ab9d") || actionerID.Equals("12a1f24c-3a0a-43a5-92a7-ccfe2c27c67d")) && FullName.Equals("结案审批"))
                //{
                //    isSendMsg = false;
                //}

                //isSendMsg = false;

                if (SendType == 0)//开启
                    ProcessInstanceID = new WfProcessInstanceBll().FE_StartProcessInstance(FullName, formID, senderID, idea, fromAddress, actionerID, "0", titles, _strAttriubuteValue, noneName, activityID, SendActivityId, IdeaCreateDate, isSendMsg, msg);
                else if (SendType == 1)//发送
                    new WfProcessInstanceBll().FE_Doction(ProcessInstanceID, WorkListId, actionerID, senderID, idea, fromAddress, formID, "0", titles, _strAttriubuteValue, noneName, activityID, FullName, SendActivityId, IdeaCreateDate, isSendMsg, msg);
                else if (SendType == 2)//退回
                    new WfProcessInstanceBll().FE_Doction(ProcessInstanceID, WorkListId, actionerID, senderID, idea, fromAddress, formID, "1", titles, _strAttriubuteValue, noneName, activityID, FullName, SendActivityId, IdeaCreateDate, isSendMsg, msg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            var _iworkListid = new CrmMessageWorkBll().GetWorkListID(formID);
            if (!string.IsNullOrEmpty(_iworkListid))
            {
                _mWorkListIDs.Add(_iworkListid);//添加消息ID，用于回滚
            }


            #region 结束流程实例
            if (fromAddress.Contains("FE_End=true"))
            {
                IsNoneDisposeMannerVerify = false;
                new WfProcessInstanceBll().EndProcessInstance(WorkListId);
            }
            #endregion

            var _ActivityRow = new FeActivityBll().GetActivity(activityID)[0];//得到结点记录（接收结点）
            #region 校验结点处理方式，是否是[服务器处理]处理，如果是执行内部代码
            //为true表示系统实现自动发送
            if (IsNoneDisposeMannerVerify)
            {
                if (_ActivityRow.NoneDisposeManner.ToString().Equals("1"))
                {
                    if (!string.IsNullOrEmpty(_iworkListid))
                    {
                        _mWorkList = null;
                        //上一个消息的接收人，即为本条消息的发送人
                        string _strSenderID = new CrmMessageWorkBll().Get(_iworkListid).ActionerID;
                        if (_strSenderID == "")
                            _strSenderID = senderID;
                        //m_bIsVerifyRule = true;
                        bool _bSendProcessState = false;
                        if (!string.IsNullOrEmpty(WorkListId) && IsNoneDisposeManner)
                            new CrmMessageWorkBll().UpdateWorkListState(WorkListId, ExecuteDate);//修改消息的状态和处理时间
                        if (SendType == 2) //判断发送的方式，2为退回
                        {
                            ReturnProcess(_iworkListid, titles, _strSenderID, formID, idea, isSendMsg, msg);
                        }
                        else//为发送
                        {
                            SendProcess(_iworkListid, titles, _strSenderID, formID, idea, isSendMsg, msg);
                        }
                    }
                }
            }
            #endregion 校验结点处理方式，是否是[服务器处理]处理，如果是执行内部代码

            return true;
        }



        /// <summary>
        /// 回滚所有本次发送
        /// </summary>
        /// <returns></returns>
        private bool RollBackSendAll()
        {
            StringBuilder _strDeleteSql = new StringBuilder();
            if (!string.IsNullOrEmpty(ProcessInstanceID))//开启流程
            {
                _strDeleteSql.Append("DELETE FROM CrmMessageWork WHERE ProcessInstanceID = " + ProcessInstanceID + ";");
                _strDeleteSql.Append("DELETE FROM CrmIdeaList WHERE ProcessInstanceID = " + ProcessInstanceID + ";");
                _strDeleteSql.Append("DELETE FROM WF_ProcessInstance WHERE ProcessInstanceID = " + ProcessInstanceID + ";");
            }
            else//执行发送
            {
                string _strWorkListID = "";
                for (int i = 0; i < _mWorkListIDs.Count; i++)
                {
                    _strWorkListID += "'" + _mWorkListIDs[i].ToString() + "',";
                }
                if (_strWorkListID.Length > 0)
                {
                    _strWorkListID = _strWorkListID.Substring(0, _strWorkListID.Length - 1);
                    _strDeleteSql.Append("DELETE FROM CrmIdeaList WHERE WorkList IN( " + _strWorkListID + ");");
                    _strDeleteSql.Append("DELETE FROM CrmMessageWork WHERE Id IN( " + _strWorkListID + ");");
                }
            }
            if (_strDeleteSql.ToString().Equals(""))
                return true;
            if (new FeProcessDal().ExecuteNonQuery(_strDeleteSql.ToString()))
            {
                new FeProcessDal().ExecuteNonQuery("UPDATE CrmMessageWork SET State=0,FormData='',ExecuteDate='' WHERE Id=" + _mWorkListIDRollBack);
                _mWorkListIDs.Clear();
                ProcessInstanceID = "";


                return true;
            }
            return false;
        }



        /// <summary>
        /// 判断当前结点的下级结点是否已走到结束点
        /// </summary>
        /// <param name="workListID">消息ID</param>
        /// <returns>true:已走到结束点 false:没有</returns>
        public bool IsNextEndProcess(string workListID)
        {
            WorkListId = workListID;

            FeActivityEntity _ActivityDR = new FeActivityBll().GetActivity(WorkList.ActivityInstanceID)[0]; //得到结点记录（接收结点）

            #region 至发启人且结束流程
            if (bool.Parse(_ActivityDR.IsSendOnOpener.ToString()))
            {
                return true;
            }
            #endregion

            #region 匹配规则
            bool _bIsContrastRule = bool.Parse(_ActivityDR.IsContrastRule.ToString());//此结点是否要求匹配规则
            if (_bIsContrastRule)
            {
                DataTable _ruleCode = new FeRuleCodeBll().GetRuleCode(_ActivityDR.ActivityID, 1);//得到规则记录
                for (int i = 0; i < _ruleCode.Rows.Count; i++)
                {
                    #region 得到规则表达式
                    string _strRuleCode = _ruleCode.Rows[i]["RuleClauses"].ToString();
                    foreach (string item in RuleCode.Keys)
                    {
                        if (_strRuleCode.Contains(item))
                        {
                            _strRuleCode = _strRuleCode.Replace(item, "'" + RuleCode[item] + "'");
                        }
                    }
                    #endregion

                    #region 跟据规则进行发送
                    if (_strRuleCode != "")
                    {
                        DataTable _dtRuleCodeIF = new FeProcessDal().ExecuteDataTable("SELECT 1 WHERE 1=1 " + " and " + _strRuleCode);//执行规则表达式
                        if (_dtRuleCodeIF.Rows.Count > 0)//执行成功
                        {
                            if (_ruleCode.Rows[i]["RiolationRuleID"].ToString().Equals("2"))//至发启人并结束流程
                                return true;
                            else
                            {
                                //发给指定结点
                                FeActivityEntity _TempDR = new FeActivityBll().GetActivity(_ruleCode.Rows[i]["RiolationRuleID"].ToString())[0];
                                if (_TempDR.NoneID.Equals("EEnd") || bool.Parse(_TempDR.IsSendOnOpener.ToString()))
                                    return true;
                            }
                        }
                    }
                    #endregion
                }
            }
            #endregion

            #region 判断下级结点是否是结束结点
            if (_bIsContrastRule == false)
            {
                var _EndActionDT = new FeActionBll().GetFeAction(_ActivityDR.NoneID, "EEnd", _ActivityDR.ProcessID);
                if (_EndActionDT.Count > 0)
                    return true;
            }
            #endregion

            return false;
        }

        /// <summary>
        /// 判断流程是否已经开启
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="fullName">流程编号</param>
        /// <param name="formId">表单编号</param>
        /// <returns></returns>
        public bool IsStartProcess(string fullName,string formId)
        {
            return new WfProcessInstanceBll().IsStartProcess(fullName, formId);
        }


        #endregion

        #region 审批时辅助属性

        /// <summary>
        /// 流程名称
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 原始消息ID（传过来的最初ID），用于回滚
        /// </summary>
        private string _mWorkListIDRollBack = "";
        /// <summary>
        /// 流程消息ID（用于回滚）
        /// </summary>
        private readonly ArrayList _mWorkListIDs = new ArrayList();
        /// <summary>
        /// 是否进行结点处理方式校验，如果为[服务器处理]就不能发送。默认为true
        /// </summary>
        private bool IsNoneDisposeMannerVerify { get; set; }

        private CrmMessageWorkEntity _mWorkList;
        private CrmMessageWorkEntity WorkList
        {
            get
            {
                //if (_mWorkList == null)
                //{
                //    _mWorkList = new CrmMessageWorkBll().OpenWorkList(WorkListId);
                //}
                _mWorkList = new CrmMessageWorkBll().OpenWorkList(WorkListId);
                return _mWorkList;
            }
            set { _mWorkList = value; }
        }

        private Dictionary<string, string> _mRuleCode = new Dictionary<string, string>();

        /// <summary>
        /// 规则匹配符
        /// </summary>
        public Dictionary<string, string> RuleCode
        {
            get
            {
                return _mRuleCode;
            }
            set { _mRuleCode = value; }
        }

        private List<string> _mCommunity = new List<string>();
        /// <summary>
        /// 部门ID
        /// </summary>
        public List<string> Community
        {
            get
            {
                return _mCommunity;
            }
            set { _mCommunity = value; }
        }

        /// <summary>
        /// 发送结点ID
        /// </summary>
        private string SendActivityId { get; set; }

        /// <summary>
        /// 0：开启 1：发送 2：退回
        /// </summary>
        private int SendType { get; set; }

        /// <summary>
        /// 消息ID
        /// </summary>
        private string WorkListId { get; set; }

        /// <summary>
        /// 是否是服务器处理
        /// </summary>
        private bool IsNoneDisposeManner { get; set; }

        /// <summary>
        /// 是否校验消息状态，已发送就不继续发送，默认为true
        /// </summary>
        private bool IsJyWorkListState { get; set; }

        private DateTime _mExecuteDate = DateTime.Now;
        /// <summary>
        /// 消息处理时间，默认为系统当前时间
        /// </summary>
        private DateTime ExecuteDate
        {
            get { return _mExecuteDate; }
            set { _mExecuteDate = value; }
        }

        public string IdeaCreateDate { get; set; }

        /// <summary>
        /// 得到发送成功后，接收人员iD
        /// </summary>
        private List<string> _mActionerIDList = new List<string>();

        /// <summary>
        ///得到发送成功后，接收人员iD
        /// </summary>
        public List<string> ActionerIDList
        {
            get
            {
                return _mActionerIDList;
            }
        }

        /// <summary>
        /// 流程实例，与列部消息表关系用
        /// </summary>
        private string ProcessInstanceID { get; set; }

        #endregion

        /// <summary>
        /// 得到接收人员ID；不考虑规则
        /// </summary>
        /// <param name="activityId">结点ID</param>
        /// <param name="isContrastCommunity">是否匹配部门</param>
        /// <returns>人员ID</returns>
        private List<string> GetActionerId(string activityId, bool isContrastCommunity)
        {
            var strReturnValue = new List<string>();
            DataTable dt = new FeActionInstanceBll().GetActionInstance(activityId, 1);
            if (Community.Count > 0 && isContrastCommunity)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < Community.Count; j++)
                    {
                        if (Community[j].Equals(dt.Rows[i]["CommunityID"].ToString()))
                        {
                            strReturnValue.Add(dt.Rows[i]["UserID"].ToString());
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strReturnValue.Add(dt.Rows[i]["UserID"].ToString());
                }
            }
            return strReturnValue;
        }
    }
}
