//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="IllegalConstructionBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/4/14 14:05:55
//  功能描述：IllegalConstruction业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.WorkFlow;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.DataAccess.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;

namespace Yookey.WisdomClassed.SIP.Business.IllegalConstruction
{
    /// <summary>
    /// IllegalConstruction业务逻辑
    /// </summary>
    public class IllegalConstructionBll : BaseBll<IllegalConstructionEntity>
    {
        public IllegalConstructionBll()
        {
            BaseDal = new IllegalConstructionDal();
        }


        /// <summary>
        /// 保存违法建设拆除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool SaveIllegalConstruction(IllegalConstructionEntity entity)
        {
            try
            {
                var oldEntity = Get(entity.Id);   //验证该是否已经存在
                if (oldEntity != null)
                {
                    entity.CaseInfoNo = oldEntity.CaseInfoNo;
                    entity.State = oldEntity.State;
                    entity.DismantleCompanyId = oldEntity.DismantleCompanyId;
                    entity.RowStatus = 1;
                    entity.CreatorId = oldEntity.CreatorId;
                    entity.CreateBy = oldEntity.CreateBy;
                    entity.CreateOn = oldEntity.CreateOn;


                    return Update(entity) > 0; //修改案件
                }
                else
                {
                    entity.RowStatus = 1;
                    Add(entity);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 案件查询
        /// 添加人：周 鹏
        /// 添加时间：2014-12-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">所属部门</param>
        /// <param name="dismantlingType">拆除类型</param>
        /// <param name="unbuiltState">违建状态</param>
        /// <param name="unbuiltStartDate">违建日期（开始）</param>
        /// <param name="unbuiltEndDate">违建日期（截止）</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageSzie">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryIllegalConstructionList(string caseStateType, string companyId, string dismantlingType, string unbuiltState, string unbuiltStartDate,
                                                   string unbuiltEndDate, string keyword, string sidx, string sord, int pageSzie = 15,
                                                                int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;
            var stype = (IllegalConstructionStateType)Enum.Parse(typeof(IllegalConstructionStateType), caseStateType);
            var data = new IllegalConstructionDal().QueryIllegalConstructionList(stype, companyId, dismantlingType, unbuiltState,
                                                                                 unbuiltStartDate, unbuiltEndDate,
                                                                                 keyword, pageSzie, pageIndex, sidx,
                                                                                 sord, out totalRecords);
            data.TableName = "IllegalConstruction";
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
        /// 结算统计
        /// </summary>
        /// <param name="drpCompany">所属片区</param>
        /// <param name="dismantleCompanyId">所属拆除公司</param>
        /// <param name="settlementStartDate">结算日期始</param>
        /// <param name="settlementEndDate">结算日期止</param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        public PageJqDatagrid<DataTable> GetIllegalConstructionStatisticList(int rows, int page, string sidx, string sord, string dismantleCompanyId, string settlementStartDate, string settlementEndDate, string drpCompany)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;
            var data = new IllegalConstructionDal().GetIllegalConstructionStatisticList(rows, page, sidx, sord, out totalRecords, dismantleCompanyId, settlementStartDate, settlementEndDate, drpCompany);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string s = data.Rows[i]["FloorSpace"].ToString();
                //取出字符串的数字或小数
                s = Regex.Replace(s, @"[^\d.\d]", "");
                //占地面积
                data.Rows[i]["FloorSpace"] = string.IsNullOrEmpty(s) ? "0" : s;
                //系数
                data.Rows[i]["Factor"] = string.IsNullOrEmpty(data.Rows[i]["Factor"].ToString()) ? "0" : data.Rows[i]["Factor"].ToString();
                //人工数
                data.Rows[i]["Manpower"] = string.IsNullOrEmpty(data.Rows[i]["Manpower"].ToString()) ? "0" : data.Rows[i]["Manpower"].ToString();
                //拆窗数
                data.Rows[i]["SecurityWindow"] = string.IsNullOrEmpty(data.Rows[i]["SecurityWindow"].ToString()) ? "0" : data.Rows[i]["SecurityWindow"].ToString();
                //整体拆除价
                data.Rows[i]["WholeReason"] = string.IsNullOrEmpty(data.Rows[i]["WholeReason"].ToString()) ? "0" : data.Rows[i]["WholeReason"].ToString();
                //封墙面积
                data.Rows[i]["FqArea"] = string.IsNullOrEmpty(data.Rows[i]["FqArea"].ToString()) ? "0" : data.Rows[i]["FqArea"].ToString();
                //运车垃圾数
                data.Rows[i]["GarbageCar"] = string.IsNullOrEmpty(data.Rows[i]["GarbageCar"].ToString()) ? "0" : data.Rows[i]["GarbageCar"].ToString();
                //其他价
                data.Rows[i]["OtherPrice"] = string.IsNullOrEmpty(data.Rows[i]["OtherPrice"].ToString()) ? "0" : data.Rows[i]["OtherPrice"].ToString();
                //拆除面积
                data.Rows[i]["DismantleArea"] = string.IsNullOrEmpty(data.Rows[i]["DismantleArea"].ToString()) ? "0" : data.Rows[i]["DismantleArea"].ToString();



                //拆除价
                data.Rows[i]["DismantlePrice"] = decimal.Parse(data.Rows[i]["DismantleArea"].ToString()) * int.Parse(data.Rows[i]["DismantleOnPrice"].ToString());
                //人工价
                data.Rows[i]["ManpowerPrice"] = int.Parse(data.Rows[i]["Manpower"].ToString()) * int.Parse(data.Rows[i]["ManpowerOnPrice"].ToString());
                //拆窗价
                data.Rows[i]["SecurityWindowPrice"] = int.Parse(data.Rows[i]["SecurityWindow"].ToString()) * int.Parse(data.Rows[i]["SecurityWindowOnPrice"].ToString());
                //封墙价
                data.Rows[i]["FqPrice"] = decimal.Parse(data.Rows[i]["FqArea"].ToString()) * int.Parse(data.Rows[i]["WailOnPrice"].ToString());
                //清运垃圾价
                data.Rows[i]["GarbagePrice"] = decimal.Parse(data.Rows[i]["GarbageCar"].ToString()) *
                                               int.Parse(data.Rows[i]["GarbageCarOnPrice"].ToString());
                //总价
                data.Rows[i]["CountPrice"] = decimal.Parse(data.Rows[i]["DismantlePrice"].ToString()) +
                                             decimal.Parse(data.Rows[i]["ManpowerPrice"].ToString()) +
                                             decimal.Parse(data.Rows[i]["SecurityWindowPrice"].ToString()) +
                                             decimal.Parse(data.Rows[i]["FqPrice"].ToString()) +
                                             decimal.Parse(data.Rows[i]["GarbagePrice"].ToString());
            }

            data.TableName = "IllegalConstruction";
            stopwatch.Stop();
            int totalPage = (totalRecords + rows - 1) / rows;   //计算页数
            return new PageJqDatagrid<DataTable>
            {
                page = page,
                rows = data,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        //导出
        public DataTable Export(string DismantleCompanyId, string SetTime, string drpCompany)
        {
            var data = new IllegalConstructionDal().Export(DismantleCompanyId, SetTime, drpCompany);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                string s = data.Rows[i]["FloorSpace"].ToString();
                //取出字符串的数字或小数
                s = Regex.Replace(s, @"[^\d.\d]", "");
                //占地面积
                data.Rows[i]["FloorSpace"] = string.IsNullOrEmpty(s) ? "0" : s;
                //系数
                data.Rows[i]["Factor"] = string.IsNullOrEmpty(data.Rows[i]["Factor"].ToString()) ? "0" : data.Rows[i]["Factor"].ToString();
                //人工数
                data.Rows[i]["Manpower"] = string.IsNullOrEmpty(data.Rows[i]["Manpower"].ToString()) ? "0" : data.Rows[i]["Manpower"].ToString();
                //拆窗数
                data.Rows[i]["SecurityWindow"] = string.IsNullOrEmpty(data.Rows[i]["SecurityWindow"].ToString()) ? "0" : data.Rows[i]["SecurityWindow"].ToString();
                //整体拆除价
                data.Rows[i]["WholeReason"] = string.IsNullOrEmpty(data.Rows[i]["WholeReason"].ToString()) ? "0" : data.Rows[i]["WholeReason"].ToString();
                //封墙面积
                data.Rows[i]["FqArea"] = string.IsNullOrEmpty(data.Rows[i]["FqArea"].ToString()) ? "0" : data.Rows[i]["FqArea"].ToString();
                //运车垃圾数
                data.Rows[i]["GarbageCar"] = string.IsNullOrEmpty(data.Rows[i]["GarbageCar"].ToString()) ? "0" : data.Rows[i]["GarbageCar"].ToString();
                //其他价
                data.Rows[i]["OtherPrice"] = string.IsNullOrEmpty(data.Rows[i]["OtherPrice"].ToString()) ? "0" : data.Rows[i]["OtherPrice"].ToString();
                //拆除面积
                data.Rows[i]["DismantleArea"] = string.IsNullOrEmpty(data.Rows[i]["DismantleArea"].ToString()) ? "0" : data.Rows[i]["DismantleArea"].ToString();



                //拆除价
                data.Rows[i]["DismantlePrice"] = decimal.Parse(data.Rows[i]["DismantleArea"].ToString()) * int.Parse(data.Rows[i]["DismantleOnPrice"].ToString());
                //人工价
                data.Rows[i]["ManpowerPrice"] = int.Parse(data.Rows[i]["Manpower"].ToString()) * int.Parse(data.Rows[i]["ManpowerOnPrice"].ToString());
                //拆窗价
                data.Rows[i]["SecurityWindowPrice"] = int.Parse(data.Rows[i]["SecurityWindow"].ToString()) * int.Parse(data.Rows[i]["SecurityWindowOnPrice"].ToString());
                //封墙价
                data.Rows[i]["FqPrice"] = decimal.Parse(data.Rows[i]["FqArea"].ToString()) * int.Parse(data.Rows[i]["WailOnPrice"].ToString());
                //清运垃圾价
                data.Rows[i]["GarbagePrice"] = decimal.Parse(data.Rows[i]["GarbageCar"].ToString()) * int.Parse(data.Rows[i]["GarbageCarOnPrice"].ToString());
                //总价
                data.Rows[i]["CountPrice"] = decimal.Parse(data.Rows[i]["DismantlePrice"].ToString()) + decimal.Parse(data.Rows[i]["ManpowerPrice"].ToString()) +
                                             decimal.Parse(data.Rows[i]["SecurityWindowPrice"].ToString()) + decimal.Parse(data.Rows[i]["FqPrice"].ToString()) +
                                             decimal.Parse(data.Rows[i]["GarbagePrice"].ToString());
            }

            data.TableName = "IllegalConstruction";
            return data;
        }
        /// <summary>
        /// 更改办件的状态，在当前状态上面加1
        /// 添加人：周 鹏
        /// 添加时间：2018-04-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public bool UpdateState(string id)
        {
            return new IllegalConstructionDal().UpdateState(id);
        }

        /// <summary>
        /// 更改办件的状态
        /// 添加人：周 鹏
        /// 添加时间：2018-04-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public bool UpdateState(string id, int state)
        {
            return new IllegalConstructionDal().UpdateState(id, state);
        }

        /// <summary>
        /// 审批成功后,执行相应操作
        /// 添加人：周 鹏
        /// 添加时间：2018-04-20
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
        public bool IllegalConstructionApproveReturn(string userId, string id, string flowName, bool islastFlow, string worklistId, DateTime approveDate, string eType)
        {
            var isOk = false;
            try
            {
                var entity = Get(id);

                var state = 0;
                //验证当前流程环节为最后一步,需将案件状态更改为当前有流程最大值,如果不是最后一步流程,直接在原有状态的基本上面+1
                if (!string.IsNullOrEmpty(flowName) && !string.IsNullOrEmpty(id) && islastFlow)
                {
                    switch (flowName)
                    {
                        case "违法建设拆除申请":
                            state = 10;
                            break;
                        case "违法建设拆除结果":
                            state = 20;
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(worklistId))
                {
                    if (eType == "disAgree" || eType == "disagree")
                    {
                        if (entity.State >= 10)
                        {
                            state = 10;
                        }
                        else if (entity.State >= 0 && entity.State < 10)
                        {
                            state = 0;
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
                    isOk = UpdateState(id, state);
                }
                else if (eType == "apply")
                {
                    switch (flowName)
                    {
                        case "违法建设拆除申请":
                            state = 1;
                            break;
                        case "违法建设拆除结果":
                            state = 11;
                            break;
                    }
                    isOk = UpdateState(id, state);
                }
                else
                {
                    isOk = !islastFlow ? UpdateState(id) : UpdateState(id, state);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return isOk;
        }


        /// <summary>
        /// 保存违建拆除公司
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="illegalId">ID</param>
        /// <param name="companys">用户编号集,使用逗号分隔</param>
        /// <returns></returns>
        public bool SaveDismantleCompany(string illegalId, string companys)
        {

            var companySplit = companys.Split(',');
            if (companySplit.Length > 0)
            {
                var entity = Get(illegalId);
                entity.DismantleCompanyId = companySplit[0];

                var companyEntity = new ComResourceBll().Get(entity.DismantleCompanyId);

                //发送短信给拆除公司
                var msg = string.Format("{0}，现有{1}有违法建设需拆除，集合时间：{2}，集合地点：{3}，设备要求：{4}，具体事宜请立即与{5}联系，电话：{6}",
                    companyEntity.RsKey, entity.TargetAddress,
                    entity.LetterOfPresentationSetTime.ToString("yyyy年MM月dd日HH时mm分"),
                    entity.LetterOfPresentationCollectionPlace,
                    entity.EquipmentRequirements,
                    entity.ApplicationUserName, entity.ApplicationMobile);

                var noteEntity = new ComNoteEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    ResourcesId = "",
                    ReceivePhone = companyEntity.RsValue,
                    MistakeInfo = msg,
                    ReceiveTime = DateTime.Now,
                    Status = 0,
                    RowStatus = 1
                };
                new ComNoteBll().Add(noteEntity);


                //发送短信给联络人

                var msgs = string.Format("{0}违法建筑已审批通过，拆除公司为：{1}，联系号码：{2}", entity.TargetAddress, companyEntity.RsKey,
                                         companyEntity.RsValue);

                var noteEntitys = new ComNoteEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    ResourcesId = "",
                    ReceivePhone = entity.ApplicationMobile,
                    MistakeInfo = msgs,
                    ReceiveTime = DateTime.Now,
                    Status = 0,
                    RowStatus = 1
                };
                new ComNoteBll().Add(noteEntitys);


                return Update(entity) > 0;
            }
            return false;
        }

        /// <summary>
        /// 获取状态数量
        /// </summary>
        /// <returns></returns>
        public DataTable GetIllegalConstructionCount(string companyId, string dismantlingType, string unbuiltState, string unbuiltStartDate,
                                                   string unbuiltEndDate, string keyword)
        {
            return new IllegalConstructionDal().GetIllegalConstructionCount(companyId, dismantlingType, unbuiltState, unbuiltStartDate,
                                                    unbuiltEndDate, keyword);
        }

        /// <summary>
        /// 获取统计报表数据
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public DataTable IllegalConstructionStatistics(string beginTime, string endTime)
        {
            return new IllegalConstructionDal().IllegalConstructionStatistics(beginTime, endTime);
        }
    }
}
