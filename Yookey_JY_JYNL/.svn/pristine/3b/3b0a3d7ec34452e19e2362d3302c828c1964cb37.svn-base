using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.FlowEditor;
using Yookey.WisdomClassed.SIP.Business.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Business.License;
using Yookey.WisdomClassed.SIP.Business.Petition;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Mobile;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Business.Mobile
{

    public class ApproveBll
    {
        readonly BaseDepartmentBll _crmDeptBll = new BaseDepartmentBll();
        readonly BaseUserBll _crmUserBll = new BaseUserBll();
        readonly ComResourceBll _comResourceBll = new ComResourceBll();      //字典

        readonly LegislationBll _legislationBll = new LegislationBll();             //法律法规-违法行为
        readonly LegislationItemBll _legislationItemBll = new LegislationItemBll(); //法律法规-适用案由
        readonly LegislationGistBll _legislationGistBll = new LegislationGistBll(); //法律法规-法律条文

        readonly InfPunishCaseinfoBll _infPunishCaseinfoBll = new InfPunishCaseinfoBll();         //一般案件基本信息
        readonly InfPunishFinishBll _infPunishFinishBll = new InfPunishFinishBll();               //一般案件结案信息
        readonly InfPunishAttachBll _infPunishAttachBll = new InfPunishAttachBll();               //附件材料
        readonly InfPunishDecisionBll _infPunishDecisionBll = new InfPunishDecisionBll();
        private readonly InfPunishDocumentBll _infPunishDocumentBll = new InfPunishDocumentBll();

        readonly InfCarChecksignmiddleBll _infCarChecksignmiddleBll = new InfCarChecksignmiddleBll();   //违法停车

        readonly InfPunishLegislatioinBll _infPunishLegislatioinBll = new InfPunishLegislatioinBll();   //案件法律法规

        readonly ApproveDal _approveDal = new ApproveDal();                  //数据
        readonly CrmMessageWorkBll _crmMessageWorkBll = new CrmMessageWorkBll();                //消息（待办）
        readonly CrmIdeaListBll _crmIdeaListBll = new CrmIdeaListBll();

        readonly FeProcessBll _feProcessBll = new FeProcessBll();            //流程
        readonly InfPunishSurveyBll _infPunishSurveyBll = new InfPunishSurveyBll();             //调查
        readonly ComNumberBll _comNumberBll = new ComNumberBll();          //编号



        /// <summary>
        /// 保存案件（案件上报）
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-02-27 周 鹏 上传时增加GPS、单位名称
        /// </history>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool SavePunishCase(string context)
        {
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";

                var caseinfoId = Regex.Match(context, @"(?<=""CaseInfoId""\:"").*?(?="",)").Value; //案件唯一编号
                var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;         //用户编号
                var deptId = Regex.Match(context, @"(?<=""DeptId""\:"").*?(?="",)").Value;         //部门编号
                var firstperson = Regex.Match(context, @"(?<=""FirstPerson""\:"").*?(?="",)").Value;     //第一个搭档
                var secondperson = Regex.Match(context, @"(?<=""SecondPerson""\:"").*?(?="",)").Value;   //第二个搭档
                var targetype = Regex.Match(context, @"(?<=""TargetType""\:"").*?(?="",)").Value;        //当事人类型
                var targename = Regex.Match(context, @"(?<=""TargetName""\:"").*?(?="",)").Value;        //当事人名称（当事人为法人时,为负责人姓名）
                var targeUnit = Regex.Match(context, @"(?<=""TargetUnit""\:"").*?(?="",)").Value;        //单位名称
                var roadNo = Regex.Match(context, @"(?<=""RoadNo""\:"").*?(?="",)").Value;           //案发路段编号
                var roadName = Regex.Match(context, @"(?<=""RoadName""\:"").*?(?="",)").Value;       //案发路段名称
                var ajaddr = Regex.Match(context, @"(?<=""AjAddr""\:"").*?(?="",)").Value;           //案发地址
                var noticeno = Regex.Match(context, @"(?<=""Noticeno""\:"").*?(?="",)").Value;       //通知书编号

                var itemno = Regex.Match(context, @"(?<=""Itemno""\:"").*?(?="",)").Value;           //案由编号
                var legislationId = Regex.Match(context, @"(?<=""LegislationId""\:"").*?(?="",)").Value;                   //违法行为
                var legislationItemId = Regex.Match(context, @"(?<=""LegislationItemId""\:"").*?(?="",)").Value;           //适用案由
                var legislationGistId = Regex.Match(context, @"(?<=""LegislationGistId""\:"").*?(?="",)").Value;           //法律条文


                var checkdate = Regex.Match(context, @"(?<=""Checkdate""\:"").*?(?="",)").Value; //案发时间
                var idType = Regex.Match(context, @"(?<=""IdType""\:"").*?(?="",)").Value;       //证件类型
                var idNum = Regex.Match(context, @"(?<=""IdNum""\:"").*?(?="",)").Value;         //证件号码
                var sex = Regex.Match(context, @"(?<=""Sex""\:"").*?(?="",)").Value;             //性别
                var age = Regex.Match(context, @"(?<=""Age""\:"").*?(?="",)").Value;             //年龄
                var address = Regex.Match(context, @"(?<=""TargetAddress""\:"").*?(?="",)").Value;  //当事人地址
                var process = Regex.Match(context, @"(?<=""Process""\:"").*?(?="",)").Value;        //案件流程（简易、一般、重大）

                var punishType = Regex.Match(context, @"(?<=""PunishType""\:"").*?(?="",)").Value;      //处罚类型（1:上报、2:警告、3:罚款）
                var punishAmount = Regex.Match(context, @"(?<=""PunishAmount""\:"").*?(?="",)").Value;  //处罚金额
                var paymentNum = Regex.Match(context, @"(?<=""PaymentNum""\:"").*?(?="",)").Value;      //票据号

                var files = Regex.Match(context, @"(?<=""Files""\:"").*?(?="",)").Value;         //附件 1:证据,2:笔录,3:通知书
                var lng = Regex.Match(context, @"(?<=""Lng""\:"").*?(?="",)").Value;             //GPS坐标：经度
                var lat = Regex.Match(context, @"(?<=""Lat""\:"").*?(?="",)").Value;             //GPS坐标：纬度

                var worklistId = Regex.Match(context, @"(?<=""WorklistId""\:"").*?(?="",)").Value;   //待办事宜编号


                var isRectification = Regex.Match(context, @"(?<=""IsRectification""\:"").*?(?="",)").Value; //是否开具整改通知书（1：开具 0：未开具）
                var isTempDetainInfo = Regex.Match(context, @"(?<=""IsTempDetainInfo""\:"").*?(?="",)").Value; //是否开具暂扣单（1：开具 0：未开具）

                var tempId = Regex.Match(context, @"(?<=""TempId""\:"").*?(?="",)").Value;   //暂扣主键ID
                var tempNo = Regex.Match(context, @"(?<=""TempNo""\:"").*?(?="",)").Value;   //暂扣单号

                var zdm = Regex.Match(context, @"(?<=""ZDM""\:"").*?(?="",)").Value;   //组织机构代码证号

                if (!string.IsNullOrEmpty(worklistId))
                {
                    _crmMessageWorkBll.UpdateWorkListState(worklistId, DateTime.Now);
                }

                var caseFact = "";        //生成案情摘要
                var caseInfoNo = "";      //案件编号
                var caseState = 0;        //案件状态                 
                //执法人员姓名一
                var rePersonelNameFist = _crmUserBll.Get(firstperson).UserName;
                //法律法规信息
                var legislationEntity = _legislationBll.Get(legislationId);

                if (legislationEntity != null && !string.IsNullOrEmpty(legislationEntity.Id))
                {
                    caseFact = Convert.ToDateTime(checkdate).ToString("yyyy年MM月dd日 HH:mm") + "，执法队员在巡查过程中发现" + targename + "在" + ajaddr + legislationEntity.ItemAct + "。";
                }
                var repoors = "";
                if (files.Contains("1"))
                {
                    repoors += "00150002,";
                }
                if (files.Contains("2") || files.Contains("3"))
                {
                    repoors += "00150001,";
                }
                if (files != "")
                {
                    repoors = repoors.Substring(0, repoors.Length - 1);
                }


                var departmentEntity = new CrmDepartmentBll().Get(deptId);
                var companyEntity = new CrmCompanyBll().Get(departmentEntity.CompanyId);

                //验证该案件是否是已处理的简易案件
                if (!string.IsNullOrEmpty(process) && process.Equals("00280001") && !string.IsNullOrEmpty(punishType) &&
                    !punishType.Equals("1"))
                {
                    caseState = 90; //简易案件的状态
                    caseInfoNo = _comNumberBll.GetNumber(AppConst.NumSimpleDecision, "", null); //生成简易案件的编号
                    //caseInfoNo = noticeno;
                    noticeno = "";
                    new InfSimpleNumberBll().Add(caseInfoNo, firstperson, rePersonelNameFist);  //保存生成的编号
                }
                else if (string.IsNullOrEmpty(noticeno))
                {
                    var ht = new Hashtable { { "DeptNo", companyEntity.Remark } };
                    caseInfoNo = _comNumberBll.GetNumber(AppConst.NumPunishCase, "", ht);   //处理时生成案件编号
                    noticeno = caseInfoNo;
                }


                #region 保存案件基本信息



                var caseType = "00950001";
                //国土的执法案件生成对应的类型
                if (legislationEntity != null && legislationEntity.ClassNo == "00090013")
                {
                    caseType = "00950002";
                }


                var caseEntity = new InfPunishCaseinfoEntity
                {
                    Id = caseinfoId,
                    CaseType = caseType,
                    CaseInfoNo = caseInfoNo,                                       //案件编号
                    CompanyId = companyEntity.Id,
                    CompanyName = companyEntity.FullName,
                    DeptId = departmentEntity.Id,
                    DeptName = departmentEntity.FullName,                          //部门名称
                    ReSource = "00100001",                                         //案件来源：默认是巡查
                    ReSourceName = "巡查",
                    RePersonelIdFist = firstperson,
                    RePersonelIdSecond = secondperson,
                    RePersonelNameFist = rePersonelNameFist,                       //执法人员姓名一
                    RePersonelNameSecond = _crmUserBll.Get(secondperson).UserName, //执法人员姓名二
                    TargetType = targetype,
                    TargetName = targename,
                    TargetUnit = targeUnit,
                    RoadNo = roadNo,
                    RoadName = roadName,
                    CaseAddress = ajaddr.Contains(roadName) ? ajaddr : roadName + ajaddr,
                    NoticeNo = noticeno,
                    CaseDate = Convert.ToDateTime(checkdate),
                    PunishProcess = process,
                    TargetPaperType = idType,
                    TargetPaperNum = idNum,
                    TargetGender = sex,
                    TargetAge = !string.IsNullOrEmpty(age) ? int.Parse(age) : 0,
                    TargetAddress = address,
                    CaseFact = caseFact,
                    ReProof = repoors,
                    HaProof = repoors,
                    State = caseState,       //案件状态
                    Lng = lng,
                    Lat = lat,
                    IsTempDetainInfo = int.Parse(isTempDetainInfo),
                    IsRectification = int.Parse(isRectification),
                    TempId = tempId,
                    TempNo = tempNo,
                    CreatorId = userId,
                    CreateOn = DateTime.Now,
                    UpdateId = userId,
                    UpdateOn = DateTime.Now
                };

                //案件保存
                _infPunishCaseinfoBll.SaveCase(caseEntity, legislationId, legislationItemId, legislationGistId);
                _crmMessageWorkBll.UpdateUnHandleMessage(caseEntity.Id);    //重新上报案件,把当前表单所有未处理的更改为已处理
                _infPunishDocumentBll.DeleteDocument(caseEntity.Id);  //重新上报案件，将原有已生成的文书全部删除

                #endregion

                #region 保存案件结案信息 【简易类案件】

                //验证该案件是否是已处理的简易案件
                if (!string.IsNullOrEmpty(process) && process.Equals("00280001") && !string.IsNullOrEmpty(punishType) &&
                    !punishType.Equals("1"))
                {
                    var punishTypeId = "";
                    if (punishType.Equals("1"))   //上报
                    {
                        punishTypeId = "00170001";
                    }
                    else if (punishType.Equals("2"))   //警告
                    {
                        punishTypeId = "00170001";
                    }
                    else if (punishType.Equals("2"))   //罚款
                    {
                        punishTypeId = "00170002";
                    }

                    //保存处罚金额
                    //_infPunishItemBll.SaveSimpleCaseItem(caseinfoId, punishTypeId, punishAmount, "");
                    _infPunishLegislatioinBll.SaveSimpleCaseItem(caseinfoId, punishTypeId, punishAmount, "");

                    //保存处罚决定信息
                    var descsionEntity = new InfPunishDecisionBll().GetDescsion(caseinfoId);
                    descsionEntity.CreatorId = firstperson;
                    descsionEntity.CreateBy = rePersonelNameFist;
                    descsionEntity.CreateOn = DateTime.Now;
                    descsionEntity.UpdateId = firstperson;
                    descsionEntity.UpdateBy = rePersonelNameFist;
                    descsionEntity.UpdateOn = DateTime.Now;
                    new InfPunishDecisionBll().SaveDecision(descsionEntity);

                    //保存结案信息
                    var finshEntity = new InfPunishFinishEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CaseInfoId = caseinfoId,
                        PunishContent = "",
                        ExecuteDesc = "",
                        PaymentType = "00220003",    //当场缴款
                        PaymentNum = paymentNum,
                        ReformDesc = "",
                        Remark = "",
                        RowStatus = 1,
                        CreatorId = firstperson,
                        CreateBy = rePersonelNameFist,
                        CreateOn = DateTime.Now
                    };
                    _infPunishFinishBll.Save(finshEntity);
                }

                #endregion

                #region 验证是否需要发送待办给队员 【进行补充证据】

                //var kickItemNo = AppConfig.KickItemNo;

                //if (!process.Equals("00280001"))
                //{
                //    //情况1：证据,笔录,通知书 必须上传
                //    //情况2：指定的自由裁量 证据、通知书必须上传
                //    if ((!files.Contains("1") || !files.Contains("2") || !files.Contains("3")) && !itemno.Contains(kickItemNo))
                //    {
                //        SendMessage(caseinfoId, userId, targename);
                //    }
                //    else if (itemno.Contains(kickItemNo) && (!files.Contains("1") || !files.Contains("3")))
                //    {
                //        SendMessage(caseinfoId, userId, targename);
                //    }
                //}

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 发送消息
        /// 添加人：周 鹏
        /// 添加时间：2015-04-02
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseinfoId">案件主键</param>
        /// <param name="userId">用户编号</param>
        /// <param name="targetName">当事人姓名</param>
        private void SendMessage(string caseinfoId, string userId, string targetName)
        {
            const string processInstance = "";                 //流程实例
            const string senderUser = "";                      //发送人（默认管理员）
            var formID = caseinfoId;                           //表单编号
            const string formAddress = "";                     //打开页面地址
            var actioner = userId;                             //接收人集合
            const string formData = "证据材料不齐全请补充。";  //意见
            const string actionName = "";
            var title = "【" + targetName + "】" + "补充材料"; //标题
            const string level = "";                           //级别
            const string activityInstanceID = "";              //发送节点
            const string sendActivityID = "";                  //接收节点
            var msg = "【" + targetName + "】" + "证据材料不齐全请补充";
            _crmMessageWorkBll.SendWorkList(processInstance, senderUser, formID, formAddress, actioner, formData, actionName, title, level, activityInstanceID, sendActivityID, true, msg);
        }

        /// <summary>
        /// 案件管理,获取案件列表
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">{userId:用户编号,pageIndex当前页,pageSize:每页请求条数}</param>
        /// <param name="netWork">请求网络的段（内、外网）</param>
        /// <returns></returns>
        public DataTable GetCaseList(string context, CommonMethod.NetWorkEnum netWork)
        {
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";

                var deptId = Regex.Match(context, @"(?<=""deptId""\:"").*?(?="",)").Value;        //部门ID
                var pageIndex = Regex.Match(context, @"(?<=""pageIndex""\:"").*?(?="",)").Value;  //当前页
                var pageSize = Regex.Match(context, @"(?<=""pageSize""\:"").*?(?="",)").Value;    //每页请求条数
                var keyWords = Regex.Match(context, @"(?<=""keyWords""\:"").*?(?="",)").Value;    //查询关键字

                int totalRecords;   //总条数

                var fileViewLink = AppConfig.FileViewLink;
                switch (netWork)
                {
                    case CommonMethod.NetWorkEnum.Intranet:   //内网
                        fileViewLink = AppConfig.FileViewLink;
                        break;
                    case CommonMethod.NetWorkEnum.OutNet:     //外网
                        fileViewLink = AppConfig.FileViewOutNetLink;
                        break;
                }

                return _approveDal.GetCaseList(deptId, fileViewLink, !string.IsNullOrEmpty(pageIndex) ? int.Parse(pageIndex) : 1,
                                               !string.IsNullOrEmpty(pageSize) ? int.Parse(pageSize) : 15, out totalRecords, keyWords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询待审批、已审批数据列表
        /// 添加人：周 鹏
        /// 添加时间：2017-03-20
        /// </summary>
        /// <history>
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="sourceType">数据类型 （0:未处理）</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">每页请求的条数</param>
        /// <param name="approveType">事项类型</param>
        /// <returns></returns>
        public int GetApproveCount(string userId, string sourceType, string approveType, int pageIndex = 1, int pageSize = 15)
        {
            try
            {
                var ct = _crmMessageWorkBll.GetMobileSerchWorkCount(userId, sourceType, pageIndex, pageSize, approveType);
                return ct;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询待审批、已审批数据列表
        /// 添加人：周 鹏
        /// 添加时间：2014-12-28
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-06-15 周 鹏 增加事项类型条件过滤
        /// </history>
        /// <param name="userId">用户编号</param>
        /// <param name="sourceType">数据类型 （0:未处理,1已阅读,2已处理,3:已删除）</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">每页请求的条数</param>
        /// <param name="approveType">事项类型</param>
        /// <returns></returns>
        public DataTable GetApproveList(string userId, string sourceType, string approveType, int pageIndex = 1, int pageSize = 15)
        {
            try
            {
                var data = _crmMessageWorkBll.GetMobileSearchWork(userId, sourceType, pageIndex, pageSize, approveType);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 待办事宜消息处理
        /// 添加人：周 鹏
        /// 添加时间：2014-12-28
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{workListId:消息编号}</param>
        /// <returns></returns>
        public bool WorkMsgHandle(string context)
        {
            context = Regex.Replace(context, @"[\{\}]", "");
            context += ",";
            var workListId = Regex.Match(context, @"(?<=""workListId""\:"").*?(?="",)").Value; //消息编号
            return _crmMessageWorkBll.UpdateWorkListState(workListId, DateTime.Now);
        }

        /// <summary>
        /// 获取案件详情
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,caseInfoId:办件编号,WorklistId:消息编号}</param>
        /// <returns></returns>
        public DataTable GetCaseDetails(string context)
        {
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var type = Regex.Match(context, @"(?<=""type""\:"").*?(?="",)").Value;              //案件类型
                var caseInfoId = Regex.Match(context, @"(?<=""caseInfoId""\:"").*?(?="",)").Value;  //案件编号
                var workListId = Regex.Match(context, @"(?<=""WorkListId""\:"").*?(?="",)").Value;  //消息编号

                var data = _infPunishCaseinfoBll.GetMobileCaseDetails(caseInfoId);
                data.Columns.Add("Idea", typeof(string));
                data.Columns.Add("IsApprove", typeof(int));    //是否可以审批

                var isApprove = false;

                if (data.Rows.Count > 0 && !string.IsNullOrEmpty(workListId))
                {
                    var workEntity = _crmMessageWorkBll.Get(workListId);
                    data.Rows[0]["Idea"] = workEntity.FormData;

                    var caseState = int.Parse(data.Rows[0]["StataNum"].ToString()); //案件状态

                    if (caseState > 0 && caseState < 10)           //立案
                    {
                        isApprove = true;
                    }
                    if (caseState > 10 && caseState < 30)           //立案
                    {
                        isApprove = true;
                    }
                    else if (caseState > 40 && caseState < 50)   //处理审批
                    {
                        isApprove = true;
                    }
                    else if (caseState > 50 && caseState < 70)    //陈述申辩与听证
                    {
                        isApprove = true;
                    }
                    else if (caseState > 70 && caseState < 80)    //行政处罚决定书
                    {
                        isApprove = true;
                    }
                    else if (caseState > 80 && caseState < 90)    //结案审批
                    {
                        isApprove = true;
                    }
                    data.Rows[0]["IsApprove"] = isApprove ? 1 : 0;
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取案件附件
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{caseInfoId:办件编号}</param>
        /// <param name="netWork">请求网络的段（内、外网）</param>
        /// <returns></returns>
        public DataTable GetFileList(string context, CommonMethod.NetWorkEnum netWork)
        {
            context = Regex.Replace(context, @"[\{\}]", "");
            context += ",";
            var caseInfoId = Regex.Match(context, @"(?<=""caseInfoId""\:"").*?(?="",)").Value;      //案件编号

            var fileViewLink = AppConfig.FileViewLink;
            switch (netWork)
            {
                case CommonMethod.NetWorkEnum.Intranet:   //内网
                    fileViewLink = AppConfig.FileViewLink;
                    break;
                case CommonMethod.NetWorkEnum.OutNet:     //外网
                    fileViewLink = AppConfig.FileViewOutNetLink;
                    break;
            }

            return _approveDal.GetFileList(caseInfoId, fileViewLink);
        }


        /// <summary>
        /// 获取案件附件
        /// 添加人：周 鹏
        /// 添加时间：2018-11-26
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseInfoId">案件主键ID</param>
        /// <param name="fileType">附件类型</param>
        /// <param name="netWork">请求网络的段（内、外网）</param>
        /// <returns></returns>
        public DataTable GetFileList(string caseInfoId, string fileType, CommonMethod.NetWorkEnum netWork)
        {
            var fileViewLink = AppConfig.FileViewLink;
            switch (netWork)
            {
                case CommonMethod.NetWorkEnum.Intranet:   //内网
                    fileViewLink = AppConfig.FileViewLink;
                    break;
                case CommonMethod.NetWorkEnum.OutNet:     //外网
                    fileViewLink = AppConfig.FileViewOutNetLink;
                    break;
            }

            return _approveDal.GetFileList(caseInfoId, fileType, fileViewLink);
        }

        /// <summary>
        /// 获取案件的流程（案件走到哪儿）
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{caseInfoId:办件编号}</param>
        /// <returns></returns>
        public DataTable GetCaseFlow(string context)
        {

            context = Regex.Replace(context, @"[\{\}]", "");
            context += ",";
            var caseInfoId = Regex.Match(context, @"(?<=""caseInfoId""\:"").*?(?="",)").Value;      //案件编号
            var data = _crmMessageWorkBll.GetCaseFlowForMobile(caseInfoId);
            return data;
        }

        /// <summary>
        /// 获取案件默认意见（用于开启流程时,加载默认消息）
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{caseInfoId:办件编号,flowName:流程名称}</param>
        /// <returns></returns>
        public string GetDefaultIdea(string context)
        {
            context = Regex.Replace(context, @"[\{\}]", "");
            context += ",";
            var caseInfoId = Regex.Match(context, @"(?<=""caseInfoId""\:"").*?(?="",)").Value;      //案件编号
            var flowName = Regex.Match(context, @"(?<=""flowName""\:"").*?(?="",)").Value;          //流程名称
            if (!string.IsNullOrEmpty(caseInfoId) && !string.IsNullOrEmpty(flowName))
            {
                return _legislationGistBll.GetDefaultIdeal(caseInfoId, flowName, caseInfoId);
            }
            return "";
        }

        /// <summary>
        /// 案件审批
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,handleType:处理类型（apply:开启流程,agree:同意,disAgree:不同意）,
        ///                                userId:处理人,handleInfo:意见内容, formId:办件编号,processId:所属审批流程,flowName:流程名称,
        ///                                worklistId:消息编号}</param>
        /// <returns></returns>
        public bool CaseApprove(string context)
        {
            var isOk = false;
            try
            {
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
                    var workState = _crmMessageWorkBll.GetWorkListStatus(worklistId);
                    if (!string.IsNullOrEmpty(worklistId) && (workState == 2 || workState == -1))
                    {
                        return false;
                    }

                    var user = _crmUserBll.Get(userId);
                    var entity = _infPunishCaseinfoBll.Get(formId);                //案件实体

                    _feProcessBll.RuleCode.Add("@DeptName", entity.CompanyName);
                    _feProcessBll.Community.Add(entity.DeptId);
                    _feProcessBll.FullName = flowName;
                    _feProcessBll.IdeaCreateDate = DateTime.Now.ToString(AppConst.DateFormatLong);

                    //处理审批时，增加当事人类型、处罚金额变量
                    if (flowName.Equals("处理审批"))
                    {
                        var legislations = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = formId });
                        if (legislations.Any())
                        {
                            _feProcessBll.RuleCode.Add("@TargetType", entity.TargetType);                           //设置当事人类型
                            _feProcessBll.RuleCode.Add("@PunishAmount", legislations[0].PunishAmount.ToString());   //设置处罚金额   
                        }
                    }

                    if (flowName.Equals("结案审批"))
                    {
                        //日期为决定书日期加6个月时间
                        var descisionDate = _infPunishDecisionBll.GetDescsion(formId).FileDate.AddMonths(6).AddDays(1);
                        _feProcessBll.IdeaCreateDate = descisionDate.ToString(AppConst.DateFormat);
                    }

                    //案件预审时，增加案由变量
                    if (flowName.Equals("案件预审"))
                    {
                        var legislations = _infPunishLegislatioinBll.GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = formId });
                        if (legislations.Any())
                        {
                            _feProcessBll.RuleCode.Add("@ItemNo", legislations[0].ItemNo);                           //设置当事人类型  
                        }
                    }

                    var ideaTitle = "";
                    if (string.IsNullOrEmpty(entity.CaseInfoNo))
                    {
                        if (entity.TargetPaperType.Equals("00120002"))
                        {
                            ideaTitle = "【" + entity.TargetUnit + "】" + flowName; //待办事事宜标题
                        }
                        else
                        {
                            ideaTitle = "【" + entity.TargetName + "】" + flowName; //待办事事宜标题
                        }
                    }
                    else
                    {
                        ideaTitle = "【" + entity.CaseInfoNo + "】" + flowName; //待办事事宜标题
                    }

                    var note = "";      //短信内容
                    if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                    {
                        note = string.Format("{0},{1},请尽快查阅", user.UserName, ideaTitle);
                        //第一次进入
                        flag = _feProcessBll.StarProcess(flowName, ideaTitle, userId, formId, idea, true, note);
                    }
                    else
                    {
                        if (eType.Equals("agree")) //同意
                        {
                            if (_feProcessBll.IsNextEndProcess(worklistId))
                            {
                                isLastFlow = true;
                                note = string.Format("{0}{1}通过", user.UserName, ideaTitle);
                            }
                            else
                            {
                                note = string.Format("{0}{1},请尽快查阅", user.UserName, ideaTitle);
                            }
                            flag = _feProcessBll.SendProcess(worklistId, ideaTitle, userId, formId, idea, true, note);
                        }
                        else if (eType.Equals("disAgree") || eType.Equals("disagree"))  //不同意
                        {
                            note = string.Format("{0}{1}未通过,请尽快查阅", user.UserName, ideaTitle);
                            flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, userId, formId, idea, true, note);
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
                    flag = _infPunishCaseinfoBll.CaseApproveReturn("", formId, flowName, isLastFlow, worklistId, DateTime.Now, eType);
                }
                isOk = flag;
            }
            catch (Exception ex)
            {
                isOk = false;
            }
            return isOk;
        }

        /// <summary>
        /// 案件预审（执法处）
        /// 添加人：周 鹏
        /// 添加时间：2015-07-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool CaseFirstTrial(string context)
        {
            var isOk = false;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var formId = Regex.Match(context, @"(?<=""formId""\:"").*?(?="",)").Value;   //表单Id
                var eType = Regex.Match(context, @"(?<=""handleType""\:"").*?(?="",)").Value;//审批类型
                var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;   //审批人员
                var idea = Regex.Match(context, @"(?<=""handleInfo""\:"").*?(?="",)").Value; //审批意见

                isOk = _crmMessageWorkBll.UpdateUnHandleMessage(formId);    //把当前表单所有未处理的更改为已处理
                if (eType.Equals("agree"))
                {
                    //更改案件状态并记录审核人
                    isOk = _infPunishCaseinfoBll.UpdateFirstTrial(formId, 10, "Second", userId, _crmUserBll.Get(userId).UserName);

                    #region 保存审批意见
                    _crmIdeaListBll.SaveList("0", userId, formId, "预审通过", "0", "0", "", "0", "执法处",
                        DateTime.Now.ToString(AppConst.DateFormatLong));

                    #endregion
                }
                else if (eType.Equals("disAgree"))
                {
                    isOk = _infPunishCaseinfoBll.UpdateCaseState(formId, -1);
                    var caseEntity = _infPunishCaseinfoBll.Get(formId);

                    var targetName = (caseEntity.TargetType.Equals("00120001")
                                                  ? caseEntity.TargetName
                                                  : caseEntity.TargetUnit);

                    #region 发送消息
                    const string processInstance = "";            //流程实例
                    var senderUser = userId;      //发送人（默认管理员）
                    var formID = formId;                              //表单编号
                    const string formAddress = "";                //打开页面地址
                    var actioner = caseEntity.RePersonelIdFist;   //接收人（做案件的队员）
                    var formData = idea;                          //意见
                    const string actionName = "";
                    var title = "【" + targetName + "】预审退回";       //标题
                    const string level = "";                                      //级别
                    const string activityInstanceID = "";                         //发送节点
                    const string sendActivityID = "";                             //接收节点
                    var msg = "【" + targetName + "】预审退回,请尽快查阅";
                    isOk = _crmMessageWorkBll.SendWorkList(processInstance, senderUser, formID, formAddress, actioner, formData, actionName, title, level, activityInstanceID, sendActivityID, true, msg);

                    #endregion

                    #region 保存审批意见

                    _crmIdeaListBll.SaveList("0", userId, formID, "预审退回,理由如下：" + idea, "0", "0", "", "0", "执法处", DateTime.Now.ToString(AppConst.DateFormatLong));

                    #endregion
                }
            }
            catch (Exception ex)
            {
                isOk = false;
            }
            return isOk;
        }

        /// <summary>
        /// 上报调查
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{formId:办件编号,registerDate:调查日期,surveyOjbect:调查对象,surveyDesc:调查情况,userId:用户编号}</param>
        /// <returns></returns>
        public bool SaveSurvey(string context)
        {
            var isOk = false;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var formId = Regex.Match(context, @"(?<=""formId""\:"").*?(?="",)").Value;
                var registerDate = Regex.Match(context, @"(?<=""registerDate""\:"").*?(?="",)").Value;
                var surveyOjbect = Regex.Match(context, @"(?<=""surveyOjbect""\:"").*?(?="",)").Value;
                var surveyDesc = Regex.Match(context, @"(?<=""surveyDesc""\:"").*?(?="",)").Value;
                var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;

                var userEntity = _crmUserBll.Get(userId);
                var entity = new InfPunishSurveyEntity
                {
                    Id = Guid.NewGuid().ToString(),
                    CaseInfoId = formId,
                    RegisterDate = registerDate,
                    SurveyOjbect = surveyOjbect,
                    SurveyDesc = surveyDesc,
                    RowStatus = 1,
                    CreatorId = userEntity.Id,
                    CreateBy = userEntity.UserName,
                    CreateOn = DateTime.Now,
                    UpdateId = userEntity.Id,
                    UpdateBy = userEntity.UserName,
                    UpdateOn = DateTime.Now
                };
                isOk = _infPunishSurveyBll.SaveSurvey(entity);
            }
            catch (Exception ex)
            {
                isOk = false;
            }
            return isOk;
        }


        /// <summary>
        /// 删除照片
        /// 添加人：周 鹏
        /// 添加时间：2015-03-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{ imgs:附件编号}</param>
        /// <returns></returns>
        public bool DeleteCaseImage(string context)
        {
            var isOk = true;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var imgs = Regex.Match(context, @"(?<=""imgs""\:"").*?(?="",)").Value;
                if (!string.IsNullOrEmpty(imgs))
                {
                    isOk = _infPunishAttachBll.DeleteAttach(imgs);
                }
            }
            catch (Exception ex)
            {
                isOk = false;
            }
            return isOk;
        }

        /// <summary>
        /// 验证通知书编号是否可以被使用
        /// 添加人：周 鹏
        /// 添加时间：2015-04-16
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{Id:案件主键编号,NoticeNo:通知书编号,CheckType:验证类型}</param>
        /// <returns></returns>
        public bool CheckNoticeNo(string context)
        {
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;      //案件主键编号
                var noticeNo = Regex.Match(context, @"(?<=""NoticeNo""\:"").*?(?="",)").Value;      //通知书编号
                var checkType = Regex.Match(context, @"(?<=""CheckType""\:"").*?(?="",)").Value;    //验证类型：Case 简易、一般，WT 违停
                var result = false;
                switch (checkType)
                {
                    case "Case":
                        result = _infPunishCaseinfoBll.CheckNoticeNo(id, noticeNo);
                        break;
                    case "WT":
                        result = _infCarChecksignmiddleBll.CheckNoticeNo(noticeNo);
                        break;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 办件审批
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,handleType:处理类型（apply:开启流程,agree:同意,disAgree:不同意）,
        ///                                userId:处理人,handleInfo:意见内容, formId:办件编号,processId:所属审批流程,flowName:流程名称,
        ///                                worklistId:消息编号}</param>
        /// <returns></returns>
        public bool LicenseApprove(string context)
        {
            var isOk = false;
            try
            {
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

                var entity = new LicenseMainBll().Get(formId);         //办件实体
                var ideaTitle = "【" + entity.ApplicantName + "】" + flowName + "审批";     //待办事事宜标题
                var isSenderNote = entity.IsTest == 0;
                var user = _crmUserBll.Get(userId);
                try
                {
                    var workState = _crmMessageWorkBll.GetWorkListStatus(worklistId);
                    if (workState == 2 || workState == -1)
                    {
                        return false;
                    }

                    //审核通过后,调用方法进行相应的处理
                    switch (flowName)
                    {
                        case "店招标牌批文":
                        case "店招标牌发证":
                        case "大型户外广告批文":
                        case "大型户外广告发证":
                        case "临时占道批文":
                        case "临时占道验收":
                            {
                                _feProcessBll.Community.Add(entity.Area);         //所属片区
                            }
                            break;
                    }

                    _feProcessBll.FullName = flowName;
                    _feProcessBll.IdeaCreateDate = DateTime.Now.ToString(AppConst.DateFormatLong);

                    _crmMessageWorkBll.UpdateUnHandleMessage(formId);    //把当前表单所有未处理的更改为已处理

                    var note = "";      //短信内容
                    if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                    {
                        note = string.Format("{0},{1},请尽快查阅", user.UserName, ideaTitle);
                        //第一次进入
                        flag = _feProcessBll.StarProcess(flowName, ideaTitle, userId, formId, idea, isSenderNote, note);
                    }
                    else
                    {
                        if (eType.Equals("agree")) //同意
                        {
                            if (_feProcessBll.IsNextEndProcess(worklistId))
                            {
                                isLastFlow = true;
                                note = string.Format("{0}{1}通过", user.UserName, ideaTitle);
                            }
                            else
                            {
                                note = string.Format("{0}{1},请尽快查阅", user.UserName, ideaTitle);
                            }
                            flag = _feProcessBll.SendProcess(worklistId, ideaTitle, userId, formId, idea, isSenderNote, note);
                        }
                        else if (eType.Equals("disAgree") || eType.Equals("disagree"))  //不同意
                        {
                            note = string.Format("{0}{1}未通过,请尽快查阅", user.UserName, ideaTitle);
                            flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, userId, formId, idea, isSenderNote, note);
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
                    switch (flowName)
                    {
                        case "店招标牌批文":
                        case "店招标牌发证":
                        case "大型户外广告批文":
                        case "大型户外广告发证":
                        case "临时占道批文":
                        case "临时占道验收":
                            flag = new LicenseMainBll().LicenseApproveReturn("", formId, flowName, isLastFlow, worklistId, DateTime.Now, eType);
                            break;
                    }
                }

                if (isSenderNote)
                {
                    new ComNoteBll().SendNoteByArea(entity, string.Format("{0}{1},快到三天期限了确认是否处理", user.UserName, ideaTitle));
                }
                isOk = flag;
            }
            catch (Exception ex)
            {
                isOk = false;
            }
            return isOk;
        }


        /// <summary>
        /// 违建拆除审批
        /// </summary>
        public bool IllegalConstructionApprove(string context)
        {
            var isOk = false;
            try
            {

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
                var directorids = Regex.Match(context, @"(?<=""directorids""\:"").*?(?="",)").Value;   //局领导（ID使用逗号分隔）

                var flag = false;          //审批状态
                var rtMsg = "审批发送成功！";    //返回内容
                var isLastFlow = false;    //当前流程是否为最后一步流程
                var user = _crmUserBll.Get(userId);
                var entity = new IllegalConstructionBll().Get(formId);         //办件实体
                var ideaTitle = string.Empty;
                ideaTitle = "【" + entity.CompanyName + "】" + flowName + "审批";     //待办事事宜标题

                try
                {
                    //审核通过后,调用方法进行相应的处理
                    switch (flowName)
                    {
                        case "违法建设拆除申请":
                        case "违法建设拆除结果":
                            {
                                _feProcessBll.Community.Add(entity.CompanyId);         //所属片区
                            }
                            break;
                    }

                    _feProcessBll.FullName = flowName;
                    _feProcessBll.IdeaCreateDate = DateTime.Now.ToString(AppConst.DateFormatLong);

                    _crmMessageWorkBll.UpdateUnHandleMessage(formId);    //把当前表单所有未处理的更改为已处理

                    var note = "";      //短信内容
                    if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                    {
                        var isStartProcess = _feProcessBll.IsStartProcess(flowName, formId);
                        if (!isStartProcess)
                        {
                            rtMsg = "【" + flowName + "】流程发启成功！";
                            note = string.Format("{0}{1},请尽快查阅", user.UserName, ideaTitle);
                            //第一次进入
                            flag = _feProcessBll.StarProcess(flowName, ideaTitle, user.Id, formId, idea, true, note);
                        }
                        else
                        {
                            rtMsg = "【" + flowName + "】已发启，请关闭当前界面！";
                        }
                    }
                    else
                    {
                        if (eType.Equals("agree")) //同意
                        {
                            if (_feProcessBll.IsNextEndProcess(worklistId))
                            {
                                isLastFlow = true;
                                note = string.Format("{0}{1}通过", user.UserName, ideaTitle);
                            }
                            else
                            {
                                note = string.Format("{0}{1},请尽快查阅", user.UserName, ideaTitle);
                            }
                            flag = _feProcessBll.SendProcess(worklistId, ideaTitle, user.Id, formId, idea, true, note);

                        }
                        else if (eType.Equals("disAgree") || eType.Equals("disagree"))  //不同意
                        {
                            note = string.Format("{0}{1}未通过,请尽快查阅", user.UserName, ideaTitle);
                            flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, user.Id, formId, idea, true, note);
                        }
                    }

                    #region 抄送局领导

                    if (!string.IsNullOrEmpty(directorids))
                    {
                        var userSplit = directorids.Split(',');
                        if (userSplit.Length > 0)
                        {
                            foreach (var userIds in userSplit)
                            {
                                const string formAddress = "/IllegalConstruction/Entity";

                                var messageWorkentity = new CrmMessageWorkEntity
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    ProcessInstanceID = "",
                                    SenderID = user.Id,
                                    StartDate = DateTime.Now,
                                    FormID = formId,
                                    FormData = "",
                                    ActionerID = userIds,
                                    Titles = "【" + entity.CompanyName + "】违法建设审批抄送",
                                    State = 0,
                                    RowStatus = 1,
                                    ContentTypeID = "00050015",
                                    SendActivityID = "",
                                    ActivityInstanceID = "",
                                    CreateOn = DateTime.Now,
                                    UpdateOn = DateTime.Now
                                };

                                if (formAddress != "")
                                {
                                    if (formAddress.IndexOf("?", System.StringComparison.Ordinal) != -1)
                                    {
                                        messageWorkentity.FormAddress = formAddress + "&worklistid=" + messageWorkentity.Id;
                                    }
                                    else
                                    {
                                        messageWorkentity.FormAddress = formAddress + "?worklistid=" + messageWorkentity.Id;
                                    }
                                }
                                new CrmMessageWorkBll().Add(messageWorkentity);
                                //执行发送短信
                                if (true)
                                {
                                    var msg = string.Format("您有一条来自【" + entity.CompanyName + "】违法建设审批抄送！");
                                    new ComNoteBll().SendNote(userIds, msg);
                                }
                            }
                        }
                    }

                    #endregion

                }
                catch (Exception ex)
                {
                    rtMsg = ex.Message;
                    flag = false;
                }
                if (flag)
                {
                    //审核通过后,调用方法进行相应的处理
                    switch (flowName)
                    {
                        case "违法建设拆除申请":
                        case "违法建设拆除结果":
                            new IllegalConstructionBll().IllegalConstructionApproveReturn(user.Id, formId, flowName, isLastFlow, worklistId, DateTime.Now, eType);
                            break;
                    }
                }
                isOk = flag;
            }
            catch (Exception ex)
            {
                isOk = false;
            }
            return isOk;
        }


        /// <summary>
        /// 信访审批
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public bool PetitionApprove(string context)
        {
            var isOk = false;

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
            var directorids = Regex.Match(context, @"(?<=""directorids""\:"").*?(?="",)").Value;   //局领导（ID使用逗号分隔）
            var user = _crmUserBll.Get(userId);
            var flag = false;          //审批状态
            var rtMsg = "审批发送成功！";    //返回内容
            var isLastFlow = false;    //当前流程是否为最后一步流程                
            var entity = new PetitionBll().Get(formId);         //信访实体
            var ideaTitle = string.Empty;
            var isSend = false;//是否发送短信
            try
            {
                //审核通过后,调用方法进行相应的处理
                switch (flowName)
                {
                    case "信访审批":
                        {
                            _feProcessBll.RuleCode.Add("@IsLastProcess", entity.IsLastProcess.ToString());   //是否走终审
                            _feProcessBll.Community.Add(entity.PetitionCompany);
                            ideaTitle = "【" + entity.PetitionCompanyName + "】" + flowName;     //待办事事宜标题
                        }
                        break;
                }

                _feProcessBll.FullName = flowName;
                _feProcessBll.IdeaCreateDate = DateTime.Now.ToString(AppConst.DateFormatLong);

                _crmMessageWorkBll.UpdateUnHandleMessage(formId);    //把当前表单所有未处理的更改为已处理

                var note = "";
                if (eType.Equals("apply") || string.IsNullOrEmpty(worklistId))
                {
                    rtMsg = "【" + flowName + "】流程发启成功！";
                    note = string.Format("您有一条来自【{0}】【{1}】的信访审批！", user.UserName, entity.PetitionCompanyName);
                    //第一次进入
                    flag = _feProcessBll.StarProcess(flowName, ideaTitle, user.Id, formId, idea, isSend, note);
                }
                else
                {
                    if (eType.Equals("agree")) //同意
                    {
                        if (_feProcessBll.IsNextEndProcess(worklistId))
                        {
                            isLastFlow = true;
                            note = string.Format("您的信访已审批通过！");
                        }
                        else
                        {
                            note = string.Format("您有一条来自【{0}】【{1}】的信访审批！", user.UserName, entity.PetitionCompanyName);
                        }
                        flag = _feProcessBll.SendProcess(worklistId, ideaTitle, user.Id, formId, idea, isSend, note);
                    }
                    else if (eType.Equals("disAgree"))  //不同意
                    {
                        note = string.Format("您的信访未审批通过！");
                        flag = _feProcessBll.ReturnProcess(worklistId, ideaTitle, user.Id, formId, idea, isSend, note);
                    }
                }
                if (flag)
                {
                    //审批成功后,调用该方法进行相应的数据处理
                    flag = new PetitionBll().SealUpApproveReturn(eType, user.Id, formId, flowName, isLastFlow, worklistId, DateTime.Now);
                }
                isOk = flag;
            }
            catch (Exception ex)
            {
                isOk = false;
            }
            return isOk;
        }


        /// <summary>
        /// 根据案件ID生成现场检查笔录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetCheckRecord(string id)
        {
            try
            {
                var caseEntity = _infPunishCaseinfoBll.Get(id);  //获取案件基本信息

                if (!string.IsNullOrEmpty(caseEntity.CheckRecord))
                {
                    return caseEntity.CheckRecord;
                }
                var casePunishEntity = new InfPunishLegislationEntity();
                var punishItems = new InfPunishLegislatioinBll().GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });

                if (punishItems != null && punishItems.Count > 0)
                {
                    casePunishEntity = punishItems[0];
                }
                var legislationGistEntity = new LegislationGistBll().Get(casePunishEntity.LegislationGistId);   //请求的法律条文 
                //现场检查记录模板内容
                var checkRecord = "";
                if (legislationGistEntity != null)
                {
                    checkRecord = legislationGistEntity.CheckRecords;
                }
                var firstUserEntity = new CrmUserBll().Get(caseEntity.RePersonelIdFist);
                var secondUserEntity = new CrmUserBll().Get(caseEntity.RePersonelIdSecond);

                if (!string.IsNullOrEmpty(checkRecord))
                {
                    checkRecord = checkRecord.Replace("${CaseDate}", caseEntity.CaseDate.ToString("yyyy年MM月dd日HH时mm分"));
                    checkRecord = checkRecord.Replace("${DeptName}", caseEntity.DeptName);
                    checkRecord = checkRecord.Replace("${FirstUser}", caseEntity.RePersonelNameFist);
                    checkRecord = checkRecord.Replace("${SecondUser}", caseEntity.RePersonelNameSecond);
                    checkRecord = checkRecord.Replace("${FirstUserCode}", firstUserEntity.Code);
                    checkRecord = checkRecord.Replace("${SecondUserCode}", secondUserEntity.Code);
                    checkRecord = checkRecord.Replace("${Address}", caseEntity.CaseAddress);
                    checkRecord = checkRecord.Replace("${ItemAct}", casePunishEntity.ItemAct);
                    checkRecord = checkRecord.Replace("${NoticeNo}", caseEntity.CaseInfoNo);
                    checkRecord = checkRecord.Replace("${TargetName}", caseEntity.TargetType.Equals("00120001") ? caseEntity.TargetName : caseEntity.TargetUnit);
                }
                return checkRecord;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 更新案件案情摘要信息
        /// </summary>
        /// <param name="caseInfoId">案件主键ID</param>
        /// <param name="fact">检查记录</param>
        /// <param name="roadName1">路段1</param>
        /// <param name="roadName2">路段2</param>
        /// <param name="reference1">参照物1</param>
        /// <param name="reference2">参照物2</param>
        /// <param name="sendDate">接受调查日期</param>
        /// <returns></returns>
        public bool UpdataCaseFact(string caseInfoId, string fact, string roadName1, string roadName2, string reference1, string reference2, string sendDate)
        {
            try
            {
                var caseEntity = _infPunishCaseinfoBll.Get(caseInfoId);
                caseEntity.CheckRecord = fact;
                caseEntity.RoadName1 = roadName1;
                caseEntity.RoadName2 = roadName2;
                caseEntity.Reference1 = reference1;
                caseEntity.Reference2 = reference2;
                caseEntity.AcceptInvestigationDate = Convert.ToDateTime(sendDate);

                return _infPunishCaseinfoBll.Update(caseEntity) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 案件审批预审
        /// </summary>
        /// <param name="caseinfoId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool CasePretrial(string caseinfoId, string userId)
        {
            //{type:办件类型,handleType:处理类型（apply:开启流程,agree:同意,disAgree:不同意）,userId:处理人,handleInfo:意见内容, formId:办件编号,processId:所属审批流程,flowName:流程名称,worklistId:消息编号}
            var approveObj = new
            {
                formId = caseinfoId,
                type = "",
                handleType = "apply",
                userId = userId,
                handleInfo = "申请预审",
                processId = "7",
                flowName = "案件预审",
                worklistId = ""
            };
            var approveContext = JsonConvert.SerializeObject(approveObj);
            return CaseApprove(approveContext);
        }
    }
}