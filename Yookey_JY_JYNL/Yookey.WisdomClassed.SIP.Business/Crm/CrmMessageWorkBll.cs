//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComMessageWorkBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：胡耀锋
//  创建日期：2014/4/8 8:53:41
//  功能描述：ComMessageWork业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.WorkFlow;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model;
using System.Data;
using Yookey.WisdomClassed.SIP.Model.WorkFlow;
using Yookey.WisdomClassed.SIP.Business.FlowEditor;
using System.Linq;
namespace Yookey.WisdomClassed.SIP.Business.Crm
{
    /// <summary>
    /// ComMessageWork业务逻辑
    /// </summary>
    public class CrmMessageWorkBll : BaseBll<CrmMessageWorkEntity>
    {
        public CrmMessageWorkBll()
        {
            BaseDal = new CrmMessageWorkDal();
        }

        /// <summary>
        /// 新增待办事宜
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Insert(CrmMessageWorkEntity entity)
        {
            return new CrmMessageWorkDal().Insert(entity);
        }

        #region 流程相关操作


        /// <summary>
        /// 获取当前表单最后处理的一条消息记录
        /// 添加人：周 鹏
        /// 添加时间：2014-08-05
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public string GetWorkListID(string formID)
        {
            return new CrmMessageWorkDal().GetWorkListID(formID);
        }

        /// <summary>
        /// 获取当前表单最后处理的一条消息记录
        /// 添加人：周 鹏
        /// 添加时间：2015-01-19
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// </summary>
        /// <param name="formID"></param>
        /// <returns></returns>
        public string GetLastWorkListID(string formID)
        {
            return new CrmMessageWorkDal().GetLastWorkListID(formID);
        }


        /// <summary>
        /// 打开流程方法
        /// </summary>
        /// <param name="worklistId">流程实例Id</param>
        /// <returns></returns>
        public CrmMessageWorkEntity OpenWorkList(string worklistId)
        {
            var entity = Get(worklistId);
            entity.ProcessInstance = new WfProcessInstanceBll().Get(entity.ProcessInstanceID);
            return entity;
        }

        /// <summary>
        /// 发送消息
        /// 添加人：周 鹏
        /// 添加时间：2014-08-05
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// </summary>
        /// <param name="processInstance">流程实例Id</param>
        /// <param name="senderUser">发送人</param>
        /// <param name="formID">页面表单Id</param>
        /// <param name="formAddress">页面地址</param>
        /// <param name="actioner">接收人集合</param>
        /// <param name="formData">意见</param>
        /// <param name="actionName">操作类型0:表示通过1:表示退回</param>
        /// <param name="title">标题</param>
        /// <param name="level">级别</param>
        /// <param name="sendActivityID">发送节点</param>
        /// <param name="activityInstanceID">接收节点</param>
        /// <param name="isSendMsg">是否发送短信</param>
        /// <param name="msg">短信内容</param>
        /// <returns></returns>
        public bool SendWorkList(string processInstance, string senderUser, string formID,
            string formAddress, string actioner, string formData, string actionName, string title, string level, string activityInstanceID, string sendActivityID, bool isSendMsg = false, string msg = "")
        {
            try
            {
                var useListId = actioner.Split(',');
                var pentity = new WfProcessEntity();
                if (!string.IsNullOrEmpty(processInstance))
                {
                    var ientity = new WfProcessInstanceBll().Get(processInstance);
                    pentity = new WfProcessBll().Get(ientity.ProcessID);
                }

                #region 批量发送消息
                foreach (var action in useListId)
                {
                    if (action == "")
                        continue;
                    var entity = new CrmMessageWorkEntity
                        {
                            Id = Guid.NewGuid().ToString(),
                            ProcessInstanceID = processInstance,
                            SenderID = senderUser,
                            StartDate = DateTime.Now,
                            FormID = formID,
                            FormData = formData,
                            ActionerID = action,
                            Titles = title,
                            State = 0,
                            RowStatus = 1,
                            ContentTypeID = pentity.MessageType,
                            SendActivityID = sendActivityID,
                            ActivityInstanceID = activityInstanceID,
                            CreateOn = DateTime.Now,
                            UpdateOn = DateTime.Now
                        };
                    if (formAddress != "")
                    {
                        if (formAddress.IndexOf("?", System.StringComparison.Ordinal) != -1)
                        {
                            entity.FormAddress = formAddress + "&worklistid=" + entity.Id;
                        }
                        else
                        {
                            entity.FormAddress = formAddress + "?worklistid=" + entity.Id;
                        }
                    }
                    else
                    {
                        if (pentity.Description != "")
                        {
                            if (pentity.Description.IndexOf("?", System.StringComparison.Ordinal) != -1)
                            {
                                entity.FormAddress = pentity.Description + "&worklistid=" + entity.Id;
                            }
                            else
                            {
                                entity.FormAddress = pentity.Description + "?worklistid=" + entity.Id; ;
                            }
                        }
                    }
                    Add(entity);

                    //执行发送短信
                    if (isSendMsg)
                    {
                        new ComNoteBll().SendNote(action, msg);
                    }
                }
                #endregion

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 消息查询
        /// 添加人：周 鹏
        /// 添加时间：2014-08-07
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<CrmMessageWorkEntity> GetSearchResult(CrmMessageWorkEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(CrmMessageWorkEntity.Parm_CrmMessageWork_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.FormID))
            {
                queryCondition.AddEqual(CrmMessageWorkEntity.Parm_CrmMessageWork_FormID, search.FormID);
            }
            else if (search.State != -1)
            {
                //状态条件是不等"AddNotEqual"
                queryCondition.AddNotEqual(CrmMessageWorkEntity.Parm_CrmMessageWork_State, search.State.ToString());
            }
            else if (!string.IsNullOrEmpty(search.ActionerID))
            {
                queryCondition.AddEqual(CrmMessageWorkEntity.Parm_CrmMessageWork_ActionerID, search.ActionerID);
            }
            if (search.Note == "Asc")
            {
                queryCondition.AddOrderBy(CrmMessageWorkEntity.Parm_CrmMessageWork_StartDate, true);
            }
            else
            {
                queryCondition.AddOrderBy(CrmMessageWorkEntity.Parm_CrmMessageWork_StartDate, false);  //以倒序进行排序
            }
            return Query(queryCondition) as List<CrmMessageWorkEntity>;
        }


        /// <summary>
        /// 消息查询
        /// 添加人：周 鹏
        /// 添加时间：2014-08-07
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<CrmMessageWorkEntity> GetSearchResultByEnd(CrmMessageWorkEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(CrmMessageWorkEntity.Parm_CrmMessageWork_RowStatus, "1");
            queryCondition.AddEqual(CrmMessageWorkEntity.Parm_CrmMessageWork_State, search.State.ToString()); //处理状态     
            if (!string.IsNullOrEmpty(search.FormID))
            {
                queryCondition.AddEqual(CrmMessageWorkEntity.Parm_CrmMessageWork_FormID, search.FormID);
            }
            if (!string.IsNullOrEmpty(search.ActivityInstanceID))
            {
                queryCondition.AddIn(CrmMessageWorkEntity.Parm_CrmMessageWork_ActivityInstanceID, search.ActivityInstanceID);
            }
            queryCondition.AddOrderBy(CrmMessageWorkEntity.Parm_CrmMessageWork_CreateOn, false);
            return Query(queryCondition) as List<CrmMessageWorkEntity>;
        }
        #endregion

        /// <summary>
        /// 查询消息列表
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="worktype">查询类型</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable GetSearchWork(string userId, string worktype, int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                var qtype = (WorkListType)Enum.Parse(typeof(WorkListType), worktype);
                var data = new CrmMessageWorkDal().GetSearchWork(userId, qtype, pageIndex, pageSize, out totalRecords);
                data.TableName = "WorklistDT";
                return data;
            }
            catch (Exception ex)
            {
                totalRecords = 0;
                return null;
            }
        }

        /// <summary>
        /// 查询消息数
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <returns></returns>
        public DataTable WorkListCount(string userId)
        {
            return new CrmMessageWorkDal().WorkListCount(userId);
        }

        /// <summary>
        /// 修改消息状态
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="workListId">消息编号</param>
        /// <param name="executeDate">消息处理时间</param>
        /// <param name="state">消息状态,0:待处理,1:已阅读,2:已处理</param>
        /// <returns></returns>
        public bool UpdateWorkListState(string workListId, DateTime executeDate, int state = 2)
        {
            return new CrmMessageWorkDal().UpdateWorkListState(workListId, executeDate, state);
        }

        /// <summary>
        /// 请求消息明细
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">消息编号</param>
        /// <returns></returns>
        public DataTable GetWorkListDetails(string id)
        {
            return new CrmMessageWorkDal().GetWorkListDetails(id);
        }

        /// <summary>
        /// 删除消息
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="worklistis">待删除的消息集</param>
        /// <param name="htype">操作方式</param>
        /// <returns></returns>
        public bool DeleteWorkList(string worklistis, string htype)
        {
            var list = new List<string>();
            if (!string.IsNullOrEmpty(worklistis))
            {
                var worklistsplit = worklistis.Split(',');
                list.AddRange(worklistsplit);
                return new CrmMessageWorkDal().DeleteWorkList(list, htype);
            }
            return false;
        }

        /// <summary>
        /// 获取未处理的消息数
        /// 添加人：周 鹏
        /// 添加时间：2014-12-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userid">用户编号</param>
        /// <returns></returns>
        public int GetUntreatedCount(string userid)
        {
            return new CrmMessageWorkDal().GetUntreatedCount(userid);
        }

        /// <summary>
        /// 获取案件的流程（走到哪儿）
        /// 添加人：周 鹏
        /// 添加时间：2014-12-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="formId">案件编号</param>
        /// <returns></returns>
        public DataTable GetCaseFlow(string formId)
        {
            return new CrmMessageWorkDal().GetCaseFlow(formId);
        }

        /// <summary>
        /// 获取案件的流程（用于手机端）
        /// 添加人：周 鹏
        /// 添加时间：2018-02-07
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-03-02 周 鹏 将人员表更改为基础数据平台人员表
        /// </history>
        /// <param name="formId">案件编号</param>
        /// <returns></returns>
        public DataTable GetCaseFlowForMobile(string formId)
        {
            return new CrmMessageWorkDal().GetCaseFlowForMobile(formId);
        }

        /// <summary>
        /// 查询消息列表
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-06-15 周 鹏 增加事项类型条件过滤
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="worktype">查询类型</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="approveType">事项类型</param>
        /// <returns></returns>
        public DataTable GetMobileSearchWork(string userId, string worktype, int pageIndex, int pageSize, string approveType)
        {
            var qtype = (WorkListType)Enum.Parse(typeof(WorkListType), worktype);
            int totalRecords;
            var data = new CrmMessageWorkDal().GetMobileSearchWork(userId, qtype, pageIndex, pageSize, out totalRecords, approveType);
            return data;
        }

        /// <summary>
        /// 查询待办事宜列表
        /// 添加人：周 鹏
        /// 添加时间：2017-03-20
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="worktype">查询类型</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="approveType">事项类型</param>
        /// <returns></returns>
        public int GetMobileSerchWorkCount(string userId, string worktype, int pageIndex, int pageSize, string approveType)
        {
            var qtype = (WorkListType)Enum.Parse(typeof(WorkListType), worktype);
            int totalRecords;
            var data = new CrmMessageWorkDal().GetMobileSearchWork(userId, qtype, pageIndex, pageSize, out totalRecords, approveType);
            return totalRecords;
        }

        /// <summary>
        /// 根据用户编号、表单号查询未处理的待办事宜
        /// 添加人：周 鹏
        /// 添加时间：2015-03-30
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="formId">表单号</param>
        /// <returns></returns>
        public DataTable GetUnHandleMessage(string userId, string formId)
        {
            return new CrmMessageWorkDal().GetUnHandleMessage(userId, formId);
        }

        /// <summary>
        /// 根据用户编号、表单号查询未处理的待办事宜编号
        /// 添加人：周 鹏
        /// 添加时间：2015-03-30
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="formId">表单号</param>
        /// <returns></returns>
        public string GetUnHandleMessageId(string userId, string formId)
        {
            var dt = GetUnHandleMessage(userId, formId);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Id"].ToString();
            }
            return "";
        }

        /// <summary>
        /// 批量更改未处理的消息
        /// 添加人：周 鹏
        /// 添加时间：2015-07-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="formID">表单号</param>
        public bool UpdateUnHandleMessage(string formID)
        {
            return new CrmMessageWorkDal().UpdateUnHandleMessage(formID);
        }


        /// <summary>
        /// 获取待办事宜的状态
        /// </summary>
        /// <param name="worklistId">消息ID</param>
        /// <returns></returns>
        public int GetWorkListStatus(string worklistId)
        {
            return new CrmMessageWorkDal().GetWorkListStatus(worklistId);
        }


        /// <summary>
        /// 获取流程的2个节点的代办
        /// </summary>
        /// <param name="FlowName">流程名称</param>
        /// <param name="beginActivity">开始节点名称</param>
        /// <param name="endActivity">结束节点名称</param>
        /// <returns></returns>
        public List<CrmMessageWorkEntity> GetWorkListByHandTime(HandTimeSearch searchModel)
        {
            return new CrmMessageWorkDal().GetWorkListByHandTime(searchModel);
        }

        /// <summary>
        /// 获取某流程的的两个节点的直接的相差时间的数量
        /// </summary>
        /// <param name="FlowName">流程名称</param>
        /// <param name="beginActivity">开始节点</param>
        /// <param name="endActivity">结束节点</param>
        /// <param name="days">相差天数</param>
        /// <param name="isMore">是否大于</param>
        /// <returns>数量</returns>
        public List<HandTimeArea> GetWorkListByHandTimeSub(HandTimeSearch searchModel)
        {
            var companyList = new CrmCompanyBll().GetAllCompany(new CrmCompanyEntity() { });
            var handTimeAreaList = new List<HandTimeArea>();
            foreach (var item in companyList)//循环片区
            {
                handTimeAreaList.Add(new HandTimeArea()
                {
                    CompanyId = item.Id,
                    AreaName = item.FullName,
                    CaseCount = 0
                });
            }

            var crmMessageWork = this.GetWorkListByHandTime(searchModel);
            if (crmMessageWork == null || crmMessageWork.Count <= 0)
                return handTimeAreaList;
            var crmMessageWork_item = crmMessageWork.GroupBy(i => i.FormID);
            foreach (var item in crmMessageWork_item)
            {
                var comHolidayBll = new ComHolidaysBll();
                var itemList = item.ToList();
                if (itemList.Count == 2)
                {
                    var beginTime = itemList[0].StartDate;//第一个节点消息的接收时间
                    var endTime = itemList[1].ExecuteDate;//第二个节点处理时间
                    if (searchModel.IsMore)
                    {
                        var subDays = comHolidayBll.HolidaySpan(beginTime, endTime, searchModel.Days);
                        if (!subDays)//大于多少天的(工作日)
                        {
                            var areaModel = handTimeAreaList.Find(i => i.CompanyId == itemList[0].CompanyId);
                            if (areaModel != null)
                                areaModel.CaseCount++;
                        }
                    }
                    else
                    {
                        var subDays = comHolidayBll.HolidaySpan(beginTime, endTime, searchModel.Days);
                        if (subDays)//多少天以内的
                        {
                            var areaModel = handTimeAreaList.Find(i => i.CompanyId == itemList[0].CompanyId);
                            if (areaModel != null)
                                areaModel.CaseCount++;
                        }
                    }
                }
            }
            return handTimeAreaList;
        }

        /// <summary>
        /// 通过待办主键获取流程名称
        /// </summary>
        /// <param name="workListId">待办主键</param>
        /// <returns></returns>
        public string GetFlowName(string workListId)
        {
            if (string.IsNullOrEmpty(workListId))
                return string.Empty;
            return new CrmMessageWorkDal().GetFlowName(workListId);
        }


        /// <summary>
        /// 获取所有许可待办
        /// </summary>
        /// <returns></returns>
        public List<CrmMessageWorkEntity> GetWorkListByLicense()
        {
            return new CrmMessageWorkDal().GetWorkListByLicense();
        }


        public List<CrmMessageWorkEntity> SearchDeptListCount(CrmMessageWorkEntity pe)
        {
            return new CrmMessageWorkDal().SearchDeptListCount(pe);
        }

        public bool IsCB(CrmMessageWorkEntity pe)
        {
            return new CrmMessageWorkDal().IsCB(pe);
        }

        public List<CrmMessageWorkEntity> MessworkList(string FormId, string SendActivityID)
        {
            return new CrmMessageWorkDal().MessworkList(FormId, SendActivityID);
        }

        /// <summary>
        /// 获取最大Note值
        /// </summary>
        /// <param name="NoteCount"></param>
        /// <returns></returns>
        public int GetMaxNoteCount(string FormId)
        {
            return new CrmMessageWorkDal().GetMaxNoteCount(FormId);
        }

        /// <summary>
        /// 获取发送人
        /// </summary>
        /// <param name="Note"></param>
        /// <returns></returns>
        public string GetMaxNoteSendId(string Note)
        {
            return new CrmMessageWorkDal().GetMaxNoteSendId(Note);
        }

        /// <summary>
        /// 变更所有Note
        /// </summary>
        /// <param name="FormId"></param>
        /// <returns></returns>
        public void UpdateNote(string FormId)
        {
            new CrmMessageWorkDal().UpdateNote(FormId);
        }

        /// <summary>
        /// 判断一个案件的第几个流程是否开启
        /// </summary>
        /// <param name="FormId">案件主键</param>
        /// <returns></returns>
        public bool GetIsOpen(string FormId, int index)
        {
            if (string.IsNullOrEmpty(FormId))
                return false;
            return new CrmMessageWorkDal().GetIsOpen(FormId) >= index;
        }
    }
}
