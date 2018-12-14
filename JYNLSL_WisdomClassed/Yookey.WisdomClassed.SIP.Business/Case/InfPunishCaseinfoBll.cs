//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_CASEINFOBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/13 13:58:26
//  功能描述：INF_PUNISH_CASEINFO业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.TempDetain;
using Yookey.WisdomClassed.SIP.Business.WorkFlow;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.TempDetain;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// 案件基本信息业务逻辑
    /// </summary>
    public class InfPunishCaseinfoBll : BaseBll<InfPunishCaseinfoEntity>
    {

        //readonly InfPunishItemBll _infPunishItemBll = new InfPunishItemBll();       //案件法律法规
        readonly InfPunishLegislatioinBll _infPunishLegislatioinBll = new InfPunishLegislatioinBll();   //案件法律法规
        readonly CrmMessageWorkBll _crmMessageWorkBll = new CrmMessageWorkBll();                        //消息（待办事宜）
        readonly WfProcessInstanceBll _wfProcessInstanceBll = new WfProcessInstanceBll();               //案件流程
        readonly InfPunishFinishBll _infPunishFinishBll = new InfPunishFinishBll();   //案件结案审批
        readonly TempDetainInfoBll _tempDetainInfoBll = new TempDetainInfoBll();


        public InfPunishCaseinfoBll()
        {
            BaseDal = new InfPunishCaseinfoDal();
        }

        /// <summary>
        /// 查询案件的状态
        /// 添加人：周 鹏
        /// 添加时间：2014-12-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-02-28 周 鹏 添加预审
        /// </history>
        /// <param name="userDeptId">当前登录部门的Id</param>
        /// <param name="deptId">部门编号,查询指定部门的数据,不传则查所有</param>
        /// <returns>DataTable Columns->FirstTrial:预审,Untreated:待处理,Untreated:处理中,Processed:已处理,StayClose:待结案,CloseJugee:已结案,Archived:已归档,All:全部</returns>
        public DataTable GetCaseStateCount(string companyId, string deptId, string userDeptId, string caseType = "00950001")
        {
            return new InfPunishCaseinfoDal().GetCaseStateCount(companyId, deptId, userDeptId, caseType);
        }

        /// <summary>
        /// 获取案件列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<InfPunishCaseinfoEntity> GetSearchResult(InfPunishCaseinfoEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(InfPunishCaseinfoEntity.Parm_INF_PUNISH_CASEINFO_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.KeyWords))
            {
                OrCondition orCondition = OrCondition.Instance.AddLike(InfPunishCaseinfoEntity.Parm_INF_PUNISH_CASEINFO_TargetName, search.KeyWords);
                orCondition.AddLike(InfPunishCaseinfoEntity.Parm_INF_PUNISH_CASEINFO_TargetUnit, search.KeyWords);
                queryCondition.AddOr(orCondition);
            }
            if (!string.IsNullOrEmpty(search.Id))
            {
                queryCondition.AddEqual(InfPunishCaseinfoEntity.Parm_INF_PUNISH_CASEINFO_Id, search.Id);
            }
            if (!string.IsNullOrEmpty(search.CaseType))
            {
                queryCondition.AddEqual(InfPunishCaseinfoEntity.Parm_INF_PUNISH_CASEINFO_CaseType, search.CaseType);
            }
            queryCondition.AddOrderBy(InfPunishCaseinfoEntity.Parm_INF_PUNISH_CASEINFO_CaseDate, false);
            var list = Query(queryCondition) as List<InfPunishCaseinfoEntity>;
            return list;
        }

        /// <summary>
        /// 获取案件列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public DataTable GetCaseList(string keywords, int pageIndex, int pageSize)
        {
            int totalRecords;
            var data = new InfPunishCaseinfoDal().GetCaseList(keywords, pageIndex, pageSize, out totalRecords);
            return data;
        }

        /// <summary>
        /// 案件查询
        /// 添加人：周 鹏
        /// 添加时间：2014-12-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseStateType">案件状态分类</param>
        /// <param name="queryType">查询类型</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="deptId">查询部门编号</param>
        /// <param name="userDeptId">当前登录部门的ID</param>
        /// <param name="caseType">案件类型</param>
        /// <param name="pageSzie">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryCaseList(string caseStateType, string queryType, string companyId, string deptId, string userDeptId, string keyword, string sidx, string sord, int pageSzie = 15,
                                                                int pageIndex = 1, string caseType = "00950001")
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;

            var stype = (CaseStateType)Enum.Parse(typeof(CaseStateType), caseStateType);
            var qtype = (CaseQueryType)Enum.Parse(typeof(CaseQueryType), queryType);

            var data = new InfPunishCaseinfoDal().QueryCaseList(stype, qtype, companyId, deptId, userDeptId, keyword, pageSzie, pageIndex, sidx, sord, caseType, out totalRecords);

            data.TableName = "CaseDT";
            stopwatch.Stop();
            int totalPage = (totalRecords + pageSzie - 1) / pageSzie;   //计算页数
            return new PageJqDatagrid<DataTable>
            {
                page = pageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        /// <summary>
        /// 保存案件
        /// 添加人：周 鹏
        /// 添加时间：2014-12-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-03-30 周 鹏 修改保存法律法规
        /// </history>
        /// <param name="entity">案件实体</param>
        /// <param name="legislationId">违法行为主键</param>
        /// <param name="legislationItemId">适用案由主键</param>
        /// <param name="legislationGistId">法律条文主键</param>
        /// <returns></returns>
        public bool SaveCase(InfPunishCaseinfoEntity entity, string legislationId, string legislationItemId, string legislationGistId)
        {
            try
            {
                var caseEntity = Get(entity.Id);   //验证该案件是否已经存在
                if (caseEntity != null)
                {
                    entity.CaseInfoNo = caseEntity.CaseInfoNo;
                    entity.RowStatus = 1;
                    entity.CreatorId = caseEntity.CreatorId;
                    entity.CreateBy = caseEntity.CreateBy;
                    entity.CreateOn = caseEntity.CreateOn;
                    entity.FirstTrialPersonelIdFirst = caseEntity.FirstTrialPersonelIdFirst;
                    entity.FirstTrialPersonelIdSecond = caseEntity.FirstTrialPersonelIdSecond;
                    entity.FirstTrialPersonelNameFirst = caseEntity.FirstTrialPersonelNameFirst;
                    entity.FirstTrialPersonelNameSecond = caseEntity.FirstTrialPersonelNameSecond;
                    entity.TempId = caseEntity.TempId;
                    entity.TempNo = caseEntity.TempNo;

                    entity.State = caseEntity.State > 0 ? caseEntity.State : entity.State;       //修改案件不更改案件的状态

                    //保存法律法规信息
                    var isOk = _infPunishLegislatioinBll.SavePunishLegislation(entity.Id, legislationId, legislationItemId, legislationGistId);
                    if (isOk)
                    {
                        //判断是否关联暂扣
                        if (!string.IsNullOrEmpty(entity.TempId))
                        {
                            TempDetainInfoEntity tempMode = _tempDetainInfoBll.Get(caseEntity.TempId);
                            if (tempMode != null)
                            {
                                tempMode.NoticeNo = entity.NoticeNo;
                                tempMode.CaseId = entity.Id;

                                _tempDetainInfoBll.Update(tempMode);
                            }

                        }

                        return Update(entity) > 0;  //修改案件
                    }
                }
                else
                {
                    entity.RowStatus = 1;

                    //保存法律法规信息
                    var isOk = _infPunishLegislatioinBll.SavePunishLegislation(entity.Id, legislationId, legislationItemId, legislationGistId);
                    if (isOk)
                    {
                        var legislationEntity = new LegislationBll().Get(legislationId);

                        var caseinfoId = entity.Id;
                        var firstperson = entity.RePersonelIdFist;
                        var secondperson = entity.RePersonelIdSecond;
                        var punishProcess = entity.PunishProcess;
                        Add(entity);    //新增案件
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询案件详细信息
        /// 添加人：周 鹏
        /// 添加时间：2014-12-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public DataTable GetCaseDetails(string id)
        {
            return new InfPunishCaseinfoDal().GetCaseDetails(id);
        }


        /// <summary>
        /// 查询案件详细信息
        /// 添加人：周 鹏
        /// 添加时间：2015-03-31
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public DataTable GetMobileCaseDetails(string id)
        {
            try
            {
                return new InfPunishCaseinfoDal().GetMobileCaseDetails(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 更改案件的状态，在当前状态上面加1
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public bool UpdateCaseState(string id)
        {
            return new InfPunishCaseinfoDal().UpdateCaseState(id);
        }

        /// <summary>
        /// 更改案件的状态
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public bool UpdateCaseState(string id, int state)
        {
            try
            {
                return new InfPunishCaseinfoDal().UpdateCaseState(id, state);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 叶念
        /// </summary>
        /// <param name="id">更新归档日期</param>
        /// <returns></returns>
        public bool UpdateCaseGdd(string id)
        {
            try
            {
                return new InfPunishCaseinfoDal().UpdateCaseGdd(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// 审批成功后,执行相应操作
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">当前登录用户编号</param>
        /// <param name="id">案件编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="islastFlow">是否为最后一步审批流程</param>
        /// <param name="worklistId">消息编号</param>
        /// <param name="approveDate">审批日期</param>
        /// <returns></returns>
        public bool CaseApproveReturn(string userId, string id, string flowName, bool islastFlow, string worklistId, DateTime approveDate, string eType)
        {
            var isOk = false;
            try
            {
                var state = 0;
                //验证当前流程环节为最后一步,需将案件状态更改为当前有流程最大值,如果不是最后一步流程,直接在原有状态的基本上面+1
                if (!string.IsNullOrEmpty(flowName) && !string.IsNullOrEmpty(id) && islastFlow)
                {
                    switch (flowName)
                    {
                        case "案件预审":
                        case "国土违法线索登记审批":
                            state = 10;
                            break;
                        case "立案审批":
                        case "国土立案审批":
                            state = 30;
                            break;
                        case "处理审批":
                        case "国土呈批审批":
                            state = 50;
                            break;
                        case "陈述申辩与听证":
                            state = 70;
                            break;
                        case "结案审批":
                        case "国土结案审批":
                            {
                                state = 90;   //将案件状态直接更改为归档
                                //更改案件的结案日期
                                _infPunishFinishBll.UpdateFinishDate(id, approveDate);
                                UpdateCaseGdd(id); //更新归档日期
                                _crmMessageWorkBll.UpdateUnHandleMessage(id);
                            }
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(worklistId))
                {
                    if (eType == "disAgree" || eType == "disagree")
                    {
                        switch (flowName)
                        {
                            case "案件预审":
                            case "国土违法线索登记审批":
                                {
                                    state = 0;
                                }
                                break;
                            case "立案审批":
                            case "国土立案审批":
                                {
                                    state = 10;
                                }
                                break;
                            case "处理审批":
                            case "国土呈批审批":
                                {
                                    state = 40;
                                }
                                break;
                            case "陈述申辩与听证":
                                {
                                    state = 60;
                                }
                                break;
                            case "结案审批":
                            case "国土结案审批":
                                {
                                    state = 80;
                                }
                                break;
                        }
                        new CrmIdeaListBll().DeleteIdea(id, flowName);
                        new WfProcessInstanceBll().UpProcessInstance(flowName, id);
                    }
                }
                if (!string.IsNullOrEmpty(worklistId))
                {
                    new CrmMessageWorkBll().UpdateWorkListState(worklistId, DateTime.Now);  //更改消息的状态为已处理
                }
                if (eType == "disAgree" || eType == "disagree")
                {
                    isOk = UpdateCaseState(id, state);
                }
                else if (eType == "Agree" || eType == "agree")
                {
                    if (!islastFlow) //不是最后节点 保证状态不是最后
                    {
                        var caseEntity = Get(id); //获取案件详情
                        if ((flowName == "处理审批" || flowName == "国土呈批审批") && caseEntity.State >= 49)
                        {
                            state = 49;
                            isOk = UpdateCaseState(id, state);
                        }
                        else if ((flowName == "结案审批" || flowName == "国土结案审批") && caseEntity.State >= 89)
                        {
                            state = 89;
                            isOk = UpdateCaseState(id, state);
                        }
                        else
                        {
                            isOk = UpdateCaseState(id);   //更改案件状态+1
                        }
                    }
                    else
                    {
                        isOk = UpdateCaseState(id, state);
                    }
                    //isOk = !islastFlow ? UpdateCaseState(id) : UpdateCaseState(id, state);
                }
                else
                {
                    isOk = !islastFlow ? UpdateCaseState(id) : UpdateCaseState(id, state);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return isOk;
        }

        /// <summary>
        /// 查询照片的详细信息
        /// 添加人：周 鹏
        /// 添加时间：2015-04-10
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="fileId">照片ID信息</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable QueryPhotoDetails(string fileId)
        {
            try
            {
                return new InfPunishCaseinfoDal().QueryPhotoDetails(fileId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 验证通知书编号是否可用
        /// 添加人：周 鹏
        /// 添加时间：2015-04-16
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseinfoId">案件编号</param>
        /// <param name="noticeNo">通知书编号</param>
        /// <returns></returns>
        public bool CheckNoticeNo(string caseinfoId, string noticeNo)
        {
            try
            {
                return new InfPunishCaseinfoDal().CheckNoticeNo(caseinfoId, noticeNo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 通通知书编号查询案件信息
        /// </summary>
        /// <param name="noticeNo"></param>
        /// <returns></returns>
        public InfPunishCaseinfoEntity GetCaseInfoByNoticeNo(string noticeNo)
        {
            return new InfPunishCaseinfoDal().GetCaseInfoByNoticeNo(noticeNo);
        }

        /// <summary>
        /// 案件查询
        /// 添加人：周 鹏
        /// 添加时间：2015-05-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门编号</param>
        /// <param name="caseStartTime">案发开始时间</param>
        /// <param name="caseEndTime">案发截止时间</param>
        /// <param name="classI">大类</param>
        /// <param name="classIi">小类</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <returns></returns>
        public DataTable QueryQueryCaseList(string deptId, string caseStartTime, string caseEndTime, string classI, string classIi, int pageSize,
                                                                int pageIndex)
        {
            try
            {
                int totalRecords;
                return new InfPunishCaseinfoDal().QueryQueryCaseList(deptId, caseStartTime, caseEndTime, classI, classIi, pageSize, pageIndex, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 案件初审
        /// 添加人：周 鹏
        /// 添加时间：2015-07-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="formId">表单编号</param>
        /// <param name="state">状态值</param>
        /// <param name="firstTrialType">初审类型</param>
        /// <param name="personId">初审人员Id</param>
        /// <param name="personName">初审人员姓名</param>
        /// <returns></returns>
        public bool UpdateFirstTrial(string formId, int state, string firstTrialType, string personId, string personName)
        {
            return new InfPunishCaseinfoDal().UpdateFirstTrial(formId, state, firstTrialType, personId, personName);
        }



        /// <summary>
        /// 将案件恢复成未处理
        /// 添加人：周 鹏
        /// 添加时间：2015-09-15
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseInfoId">案件主键编号</param>
        /// <returns></returns>
        public bool CancelHandle(string caseInfoId)
        {
            try
            {
                return new InfPunishCaseinfoDal().CancelHandle(caseInfoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 案件删除
        /// 添加人：周 鹏
        /// 添加时间：2017-01-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseInfoId">案件主键编号</param>
        /// <returns></returns>
        public bool CaseDelete(string caseInfoId)
        {
            try
            {
                return new InfPunishCaseinfoDal().CaseDelete(caseInfoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询人的工作量化
        /// 添加人：周 鹏
        /// 添加时间：2017-03-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable Columns->A:教育纠处 B:违法停车 C:简易程序 D:一般程序 E:现场考核 F:暂扣物品</returns>
        public DataTable GetInteralDetailsByUserId(string userId, string startTime, string endTime)
        {
            try
            {
                return new InfPunishCaseinfoDal().GetInteralDetailsByUserId(userId, startTime, endTime);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询人的工作量化 明细
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="caseType">A:教育纠处 B:违法停车 C:简易程序 D:一般程序 E:现场考核 F:暂扣物品</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable GetInteralDetails(string userId, string caseType, string startTime, string endTime, int pageSize,
                                                                int pageIndex, out int totalRecords)
        {
            try
            {
                return new InfPunishCaseinfoDal().GetInteralDetails(userId, caseType, startTime, endTime, pageSize, pageIndex, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
