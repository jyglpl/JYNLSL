using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// 文书打印数据源
    /// </summary>
    public class InfPunishDataSourceDalcs
    {
        /// <summary>
        /// 获取文书数据 
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="procedureName">存储过程</param>
        /// <param name="resourceId">办件编号</param>
        /// <returns>DataTable.</returns>
        public DataTable GetDataSource(string writIdentify, string resourceId)
        {
            try
            {
                DataTable dt = new DataTable();
                switch (writIdentify)
                {
                    #region 城市管理文书
                    case "Registration":    //立案审批表
                        dt = Registration(resourceId);
                        break;
                    case "Processration":   //处理审批表
                        dt = Processration(resourceId);
                        break;
                    case "Endration":   //结案审批表
                        dt = Endration(resourceId);
                        break;
                    case "CaceBackCard":            //送达回证(告知书)
                        dt = CaceBackCard(resourceId);
                        break;
                    case "CaceBackCardD":           //送达回证（决定书）
                        dt = CaceBackCardD(resourceId);
                        break;
                    case "CaseOrder":               //委托单（一般、简易）
                        dt = CaseOrder(resourceId);
                        break;
                    case "Inform":                  //告知书
                        dt = Inform(resourceId);
                        break;
                    case "SimpleCase":           //简易案件决定书
                        dt = SimpleCase(resourceId);
                        break;
                    case "SimpleCar":           //违章停车决定书
                        dt = SimpleCar(resourceId);
                        break;
                    case "CarOrder":            //违章停车委托单
                        dt = CarOrder(resourceId);
                        break;
                    case "Record":                  //一般案件调查   询问笔录
                        dt = Record(resourceId);
                        break;
                    case "CasePhoto":               //案件照片
                        dt = CasePhoto(resourceId);
                        break;
                    case "CarPhoto":                //违停案件照片
                        dt = CarPhoto(resourceId);
                        break;
                    case "CarBill":                 //违章停车罚没款票据
                        dt = CarBill(resourceId);
                        break;
                    case "CaseBill":                 //一般案件罚没款票据
                        dt = CaseBill(resourceId);
                        break;
                    case "Dossier":                 //卷宗
                        dt = Dossier(resourceId);
                        break;
                    case "Leave":                   //请假单
                        dt = Leave(resourceId);
                        break;
                    case "LegislationGist":         //责令改正通知书
                        dt = LegislationGist(resourceId);
                        break;
                    case "PunishAll":              //般案件全部（含整改）  
                        dt = PunishAll(resourceId);
                        break;
                    case "DZQRS":           //地址确认书
                        dt = DZQRS(resourceId);
                        break;
                    case "Notice":           //责令停止违反城市管理行为通知书
                        dt = Notice(resourceId);
                        break;
                    case "XXDJTZS":            //先行登记通知书
                        dt = XXDJTZS(resourceId);
                        break;
                    case "FieldInspectionRecord":       //现场检查/勘验笔录
                        dt = FieldInspectionRecord(resourceId);
                        break;
                    #endregion

                    #region 国土文书方法
                    case "LandAccepted":            //接受调查通知书
                        dt = LandAccepted(resourceId);
                        break;
                    case "LandActionDecide":       //违法案件处理决定审批表
                        dt = LandActionDecide(resourceId);
                        break;
                    case "LandCaceBack":            //送达回证
                        dt = LandCaceBack(resourceId);
                        break;
                    case "LandClueRegister":         //违法线索登记表
                        dt = LandClueRegister(resourceId);
                        break;
                    case "LandDesignation":         //人员指定书
                        dt = LandDesignation(resourceId);
                        break;
                    case "LandEndration":           //国土结案呈批表
                        dt = LandEndration(resourceId);
                        break;
                    case "LandFieldInspectionRecord":       //现场勘测笔录
                        dt = LandFieldInspectionRecord(resourceId);
                        break;
                    case "LandInform":               //行政处罚告知书
                        dt = LandInform(resourceId);
                        break;
                    case "LandMinutes":               //国土案情会商
                        dt = LandMinutes(resourceId);
                        break;
                    case "LandParkNotice":      //责令停止土地违法行为通知书
                        dt = LandParkNotice(resourceId);
                        break;
                    case "LandPollRecord":      //国土资源违法案件调查报告
                        dt = LandPollRecord(resourceId);
                        break;
                    case "LandPunishDecision":      //行政处罚决定书
                        dt = LandPunishDecision(resourceId);
                        break;
                    case "LandPunishHearing":      //行政处罚听证告知书
                        dt = LandPunishHearing(resourceId);
                        break;
                    case "LandRecord":      //询问笔录
                        dt = LandRecord(resourceId);
                        break;
                    case "LandRegistration":         //国土立案呈批表
                        dt = LandRegistration(resourceId);
                        break;
                    case "LandTrialRecord":         //违法案件审理(法制审核)记录
                        dt = LandTrialRecord(resourceId);
                        break;
                    case "LandVerificationRecord":         //关于查处对象名称涉嫌非法占地问题核查情况的报告
                        dt = LandVerificationRecord(resourceId);
                        break;

                    #endregion

                    #region 水利文书方法

                    case "WaterRegistration":           //立案审批表
                        dt = WaterRegistration(resourceId);
                        break;
                    case "WaterPollRecord":              //调查笔录
                        dt = WaterPollRecord(resourceId);
                        break;
                    case "WaterPunishInform":       //行政处罚告知书
                        dt = WaterPunishInform(resourceId);
                        break;
                    case "WaterPunishExamination":         //行政处罚决定审批表
                        dt = WaterPunishExamination(resourceId);
                        break;
                    case "WaterPunishDecisionSimple":         //行政处罚决定书（简易程序）
                        dt = WaterPunishDecisionSimple(resourceId);
                        break;
                    case "WaterPunishDecision":         //行政处罚决定书
                        dt = WaterPunishDecision(resourceId);
                        break;
                    case "WaterCaceBackCard":         //送达回证
                        dt = WaterCaceBackCard(resourceId);
                        break;


                    #region MyRegion

                    case "WaterPunishSearch":         //行政执法巡查记录
                        dt = WaterPunishSearch(resourceId);
                        break;
                    case "WaterReportRecord":                //举报记录
                        dt = WaterReportRecord(resourceId);
                        break;
                    case "WaterReportReview":           //举报核查记录
                        dt = WaterReportReview(resourceId);
                        break;
                    case "WaterPunishNotice":            //行政处罚指定管辖通知书
                        dt = WaterPunishNotice(resourceId);
                        break;
                    case "WaterTransfer":            //案件移送函
                        dt = WaterTransfer(resourceId);
                        break;
                    case "WaterPollNotice":            //调查通知书
                        dt = WaterPollNotice(resourceId);
                        break;
                    case "WaterHelpPoll":                //协助调查函
                        dt = WaterHelpPoll(resourceId);
                        break;
                    case "WaterFieldInspectionRecord":  //勘验（检查）笔录
                        dt = WaterFieldInspectionRecord(resourceId);
                        break;
                    case "WaterFieldInspectionImage":   //勘验图
                        dt = WaterFieldInspectionImage(resourceId);
                        break;
                    case "WaterProofNoteExamination":        //证据先行登记保存审批表
                        dt = WaterProofNoteExamination(resourceId);
                        break;
                    case "WaterProofNotice":        //证据先行登记保存通知书
                        dt = WaterProofNotice(resourceId);
                        break;
                    case "WaterProofAction":       //证据先行登记保存处理决定书
                        dt = WaterProofAction(resourceId);
                        break;
                    case "WaterSeizureExamination":       //采取扣押（暂扣）措施审批表
                        dt = WaterSeizureExamination(resourceId);
                        break;
                    case "WaterSeizureNotice":       //扣押（暂扣）通知书
                        dt = WaterSeizureNotice(resourceId);
                        break;
                    case "WaterReleaseSeizureExamination":       //解除扣押（暂扣）审批表
                        dt = WaterReleaseSeizureExamination(resourceId);
                        break;
                    case "WaterReleaseSeizureNotice":       //解除扣押（暂扣）通知书
                        dt = WaterReleaseSeizureNotice(resourceId);
                        break;
                    case "WaterPollEndRecord":       //调查终结报告
                        dt = WaterPollEndRecord(resourceId);
                        break;
                    case "WaterPollEndExamination":       //调查终结审批表
                        dt = WaterPollEndExamination(resourceId);
                        break;
                    case "WaterCollectiveRecord":       //负责人集体讨论记录
                        dt = WaterCollectiveRecord(resourceId);
                        break;
                    case "WaterPunishHearNotice":       //行政处罚听证通知书
                        dt = WaterPunishHearNotice(resourceId);
                        break;
                    case "WaterDelayHearRecord":       //延期（中止、终止）听证通知书
                        dt = WaterDelayHearRecord(resourceId);
                        break;
                    case "WaterPunishHear":         //行政处罚听证公告
                        dt = WaterPunishHear(resourceId);
                        break;
                    case "WaterHearRecord":         //听证笔录
                        dt = WaterHearRecord(resourceId);
                        break;
                    case "WaterHearIdea":           //听证意见书
                        dt = WaterHearIdea(resourceId);
                        break;
                    case "WaterPleadRecord":         //陈述、申辩笔录
                        dt = WaterPleadRecord(resourceId);
                        break;
                    case "WaterPleadReview":         //陈述、申辩或听证复核表
                        dt = WaterPleadReview(resourceId);
                        break;
                    case "WaterLevyNotice":         //征收通知书
                        dt = WaterLevyNotice(resourceId);
                        break;
                    case "WaterOrderNotice":         //责令限期缴费通知书
                        dt = WaterOrderNotice(resourceId);
                        break;
                    case "WaterDeadline":         //缓期（分期）缴费批准书
                        dt = WaterDeadline(resourceId);
                        break;
                    case "WaterForceExamination":         //行政强制执行审批表
                        dt = WaterPunishExamination(resourceId);
                        break;
                    case "WaterForceNotice":         //强制执行通知书
                        dt = WaterForceNotice(resourceId);
                        break;
                    case "WaterForceRecord":         //行政强制执行笔录
                        dt = WaterForceRecord(resourceId);
                        break;
                    case "WaterForceApply":         //强制执行申请书  
                        dt = WaterForceApply(resourceId);
                        break;
                    case "WaterTargetProve":         //法定代表人身份证明  
                        dt = WaterTargetProve(resourceId);
                        break;
                    case "WaterEntrustBook":         //授权委托书 
                        dt = WaterEntrustBook(resourceId);
                        break;
                    case "WaterEndRation":         //结案报告 
                        dt = WaterEndRation(resourceId);
                        break;
                    case "WaterPunishRecord":         //行政处罚案件备案报告
                        dt = WaterPunishRecord(resourceId);
                        break;
                    case "WaterSupervisionNotice":         //督办通知书 
                        dt = WaterSupervisionNotice(resourceId);
                        break;
                    case "WaterOrderDeadlineNotice":         //责令限期改正水事违法行为通知书 
                        dt = WaterOrderDeadlineNotice(resourceId);
                        break;
                    case "WaterOrderStopNotice":         //责令停止水事违法行为通知书
                        dt = WaterOrderStopNotice(resourceId);
                        break;
                    case "WaterDeadlineNotice":         //限期补办行政许可手续通知书
                        dt = WaterDeadlineNotice(resourceId);
                        break;
                    case "WaterList":         //卷内材料目录
                        dt = WaterList(resourceId);
                        break;
                    case "WaterPhoneRecord":         //水行政执法照片记录纸
                        dt = WaterPhoneRecord(resourceId);
                        break;
                    case "WaterCameraRecord":         //摄像证据记录纸
                        dt = WaterCameraRecord(resourceId);
                        break;
                    #endregion
                    #endregion

                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        #region 城管文书查询
        /// <summary>
        /// 立案审批表
        /// </summary>
        /// <param name="resourceId">案件编号</param>
        /// <returns></returns>
        public DataTable Registration(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            string TargetName = string.Empty;
            string UnitLeader = string.Empty;
            string UnitAddress = string.Empty;
            string UndertakerIdea = string.Empty;//承办人
            string UndertakerDate = string.Empty;
            string AcceptName = string.Empty; //受理人
            string AcceptDate = string.Empty;
            string AcceptIdea = string.Empty;
            string DeptName = string.Empty; //部门
            string DeptDate = string.Empty;
            string DeptIdea = string.Empty;
            string TargetGender = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));		 //立案字（年）
            dtAll.Columns.Add("Num", typeof(string)); 		 //立案字（号）	
            dtAll.Columns.Add("ItemName", typeof(string));    //案由名称
            dtAll.Columns.Add("AcceptTime", typeof(string));   //受案时间
            dtAll.Columns.Add("CaseDate", typeof(string));     //案发时间
            dtAll.Columns.Add("CaseAddress", typeof(string));     //案发地点
            dtAll.Columns.Add("TargetUnit", typeof(string));  	 //单位名称
            dtAll.Columns.Add("UnitLeader", typeof(string));  	 //负责人姓名
            dtAll.Columns.Add("TargetDuty", typeof(string));  	 //职务
            dtAll.Columns.Add("UnitAddress", typeof(string));     //单位地址
            dtAll.Columns.Add("TargetName", typeof(string));  	 //当事人姓名
            dtAll.Columns.Add("TargetGender", typeof(string));      //当事人性别
            dtAll.Columns.Add("TargetPaperNum", typeof(string));     //当事人身份证号码
            dtAll.Columns.Add("TargetPhone", typeof(string));  	 //当事人联系电话
            dtAll.Columns.Add("CaseFact", typeof(string));  		 //案情摘要
            dtAll.Columns.Add("CaseHurtInfo", typeof(string));    //危害情况
            dtAll.Columns.Add("UndertakerIdea", typeof(string));  //承办人意见
            dtAll.Columns.Add("UndertakerDate", typeof(string));   //承办人审批日期
            dtAll.Columns.Add("AcceptDate", typeof(string));  	 //受理人审批日期
            dtAll.Columns.Add("DeptDate", typeof(string));  		 //部门审批日期
            dtAll.Columns.Add("DeptIdea", typeof(string));  		 //部门意见
            dtAll.Columns.Add("CaseCreateDate", typeof(string));      //上报日期
            dtAll.Columns.Add("UndertakerFirstSignName", typeof(string));//承办人（一）签名
            dtAll.Columns.Add("UndertakerSecondSignName", typeof(string));//承办人（二）签名
            #endregion

            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];
            //承办人签字
            var strCrmUserSignFirst = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strCrmUserSignSecond = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());

            DataTable dtCrmUserSignFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignFirst).Tables[0];
            DataTable dtCrmUserSignSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignSecond).Tables[0];

            #region 承办人意见及审批日期 0/1,受理人签名、签字意见及审批日期1/2 ,部门签名、签字意见及审批日期 3/4
            var strWF_Process = string.Format("select * from WF_Process where FullName = '立案审批'");
            DataTable dtWF_Process = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strWF_Process).Tables[0];
            var strCrmIdeaList = string.Format("select * from CrmIdeaList where [Type] = 0 and ResourceID='{0}' and ProcessID='{1}'  order by CreateOn ", resourceId, dtWF_Process.Rows[0]["Id"].ToString());
            DataTable dtCrmIdeaList = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmIdeaList).Tables[0];
            if (dtCrmIdeaList.Rows.Count > 0)
            {
                for (int i = 0; i < dtCrmIdeaList.Rows.Count; i++)
                {
                    var strCrmUserSign = string.Format("select * from CrmUserSign where SignType = '00310001' AND UserId='{0}'", dtCrmIdeaList.Rows[i]["UserId"].ToString());
                    var strCrmUserSignIdea = string.Format("select * from CrmUserSign where SignType = '00310002' AND UserId='{0}'", dtCrmIdeaList.Rows[i]["UserId"].ToString());
                    DataTable dtCrmUserSign = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSign).Tables[0];
                    DataTable dtCrmUserSignIdea = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignIdea).Tables[0];
                    if (i == 0)
                    {
                        UndertakerIdea = dtCrmUserSign.Rows[0]["Idea"].ToString();
                        UndertakerDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                    else if (i == 1)
                    {
                        AcceptName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        AcceptIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        AcceptDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                    else if (i == 3)
                    {
                        DeptName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        DeptIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        UndertakerDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                }
            }

            #endregion

            #region 变量赋值
            if (dtCASEINFO.Rows.Count > 0)
            {
                //立案 年 号
                string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
                Year = _listCaseInfoNo[0];
                if (dtCASEINFO.Rows[0]["CompanyName"].ToString() == "唯亭街道综合执法大队")
                {
                    Num = _listCaseInfoNo[1].Substring(0, 7);
                }
                else
                {
                    Num = _listCaseInfoNo[1].Substring(0, 5);
                }
                //当事人类型
                if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120002")
                {
                    TargetName = "";
                    UnitLeader = dtCASEINFO.Rows[0]["TargetName"].ToString();
                }
                else
                {
                    UnitLeader = "";
                    UnitAddress = "";
                    TargetName = dtCASEINFO.Rows[0]["TargetName"].ToString();
                    if (dtCASEINFO.Rows[0]["TargetGender"].ToString() == "1")
                    {
                        TargetGender = "男";
                    }
                    else
                    {
                        TargetGender = "女";
                    }
                }
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["ItemName"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();
            }
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["AcceptTime"] = DateTime.Parse(dtCASEINFO.Rows[0]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                newRow["CaseDate"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).ToString("yyyy年MM月dd日");
                newRow["CaseAddress"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();
                newRow["TargetUnit"] = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
                newRow["TargetDuty"] = dtCASEINFO.Rows[0]["TargetDuty"].ToString();
                newRow["TargetGender"] = TargetGender;
                newRow["TargetPaperNum"] = dtCASEINFO.Rows[0]["TargetPaperNum"].ToString();
                newRow["TargetPhone"] = dtCASEINFO.Rows[0]["TargetPhone"].ToString();
                newRow["CaseFact"] = dtCASEINFO.Rows[0]["CaseFact"].ToString();
                newRow["CaseHurtInfo"] = dtCASEINFO.Rows[0]["CaseHurtInfo"].ToString();
                newRow["CaseCreateDate"] = DateTime.Parse(dtCASEINFO.Rows[0]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
            }
            newRow["UnitLeader"] = UnitLeader;
            newRow["UnitAddress"] = UnitAddress;
            newRow["TargetName"] = TargetName;
            newRow["UndertakerIdea"] = UndertakerIdea;
            newRow["UndertakerDate"] = UndertakerDate;
            newRow["AcceptDate"] = AcceptDate;
            newRow["DeptDate"] = DeptDate;
            newRow["DeptIdea"] = DeptIdea;
            if (dtCrmUserSignFirst.Rows.Count > 0)
            {
                newRow["UndertakerFirstSignName"] = dtCrmUserSignFirst.Rows[0]["SignAddress"].ToString();
            }
            if (dtCrmUserSignSecond.Rows.Count > 0)
            {
                newRow["UndertakerSecondSignName"] = dtCrmUserSignSecond.Rows[0]["SignAddress"].ToString();
            }
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 处理审批表
        /// </summary>
        /// <param name="resourceId">案件编号</param>
        /// <returns></returns>
        public DataTable Processration(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            string TargetName = string.Empty;
            string UnitLeader = string.Empty;
            string UnitAddress = string.Empty;
            string UndertakerIdea = string.Empty;//承办人意见及审批日期
            string UndertakerDate = string.Empty;
            string DeptSignName = string.Empty;//部门签名、签字意见及审批日期
            string DeptSignIdea = string.Empty;
            string DeptDate = string.Empty;
            string LegalSignName = string.Empty;//法制科签名、签字意见及审批日期
            string LegalSignIdea = string.Empty;
            string LegalDate = string.Empty;
            string LeaderSignName = string.Empty;//行政机关负责人签名、签字意见及审批日期
            string LeaderSignIdea = string.Empty;
            string LeaderDate = string.Empty;
            string LeaderTempDate = string.Empty;//领导审批日期
            string TargetGender = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string)); 		 //立案字（年）
            dtAll.Columns.Add("Num", typeof(string)); 			 //立案字（号）	
            dtAll.Columns.Add("ItemName", typeof(string));    //案由名称
            dtAll.Columns.Add("DeptName", typeof(string));   //承办部门
            dtAll.Columns.Add("AcceptTime", typeof(string));  //受案时间
            dtAll.Columns.Add("CaseDate", typeof(string));    //案发时间
            dtAll.Columns.Add("CaseAddress", typeof(string));    //案发地点
            dtAll.Columns.Add("TargetUnit", typeof(string)); 	 //单位名称
            dtAll.Columns.Add("UnitLeader", typeof(string)); 	 //负责人姓名
            dtAll.Columns.Add("TargetDuty", typeof(string)); 	 //职务
            dtAll.Columns.Add("UnitAddress", typeof(string));    //单位地址
            dtAll.Columns.Add("TargetName", typeof(string)); 	 //当事人姓名
            dtAll.Columns.Add("TargetGender", typeof(string));     //当事人性别
            dtAll.Columns.Add("TARGETAGE", typeof(string));        //年龄
            dtAll.Columns.Add("TargetPaperNum", typeof(string));   //当事人身份证号码
            dtAll.Columns.Add("TargetPhone", typeof(string)); 	 //当事人联系电话
            dtAll.Columns.Add("TargetPhone2", typeof(string));      //联系电话
            dtAll.Columns.Add("TargetAddress", typeof(string)); 	 //当事人地址
            dtAll.Columns.Add("CaseFact", typeof(string)); 		 //案情摘要
            dtAll.Columns.Add("CaseHurtInfo", typeof(string));   //危害情况

            dtAll.Columns.Add("UndertakerSign", typeof(string));  //承办人
            dtAll.Columns.Add("UndertakerIdea", typeof(string)); //承办人意见
            dtAll.Columns.Add("UndertakerDate", typeof(string));  //承办人审批日期

            dtAll.Columns.Add("DeptDate", typeof(string)); 		 //部门审批日期

            dtAll.Columns.Add("LegalDate", typeof(string)); 		 //法制科审批日期

            dtAll.Columns.Add("HearSign", typeof(string)); 		 //会审审批
            dtAll.Columns.Add("HearIdea", typeof(string)); 		 //会审审批意见
            dtAll.Columns.Add("HearDate", typeof(string)); 		 //会审审批日期

            dtAll.Columns.Add("LeaderDate", typeof(string)); 	 //领导审批日期

            dtAll.Columns.Add("LeaderTempDate", typeof(string));      //领导审批日期
            dtAll.Columns.Add("CaseCreateDate", typeof(string));      //上报日期

            dtAll.Columns.Add("UndertakerFirstSignName", typeof(string));    //承办人（一）签名
            dtAll.Columns.Add("UndertakerSecondSignName", typeof(string));   //承办人（二）签名

            dtAll.Columns.Add("DeptSignName", typeof(string));  		   //部门签名
            dtAll.Columns.Add("DeptSignIdea", typeof(string));  		   //部门签字

            dtAll.Columns.Add("LegalSignName", typeof(string));           //法制机构签名
            dtAll.Columns.Add("LegalSignIdea", typeof(string));            //法制机构签字	

            dtAll.Columns.Add("LeaderSignName", typeof(string)); 	           //行政机关负责人签名
            dtAll.Columns.Add("LeaderSignIdea", typeof(string)); 	           //行政机关负责人签字
            dtAll.Columns.Add("ReProof", typeof(string)); 	           //立案证据

            #endregion

            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];
            //承办人签字
            var strCrmUserSignFirst = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strCrmUserSignSecond = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());

            DataTable dtCrmUserSignFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignFirst).Tables[0];
            DataTable dtCrmUserSignSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignSecond).Tables[0];

            DataTable dt = new DataTable();
            #region 各个部门 签名、签字意见及审批日期
            //承办人意见及审批日期 1,部门签名、签字意见及审批日期 2，--法制科签名、签字意见及审批日期 4 
            //行政机关负责人签名、签字意见及审批日期5
            string SignType = string.Empty;
            string Account = string.Empty;
            string UserId = string.Empty;
            var strWF_Process = string.Format("select * from WF_Process where FullName = '处理审批'");
            DataTable dtWF_Process = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strWF_Process).Tables[0];
            var strCrmIdeaList = string.Format("select * from CrmIdeaList where [Type] = 0 and ResourceID='{0}' and ProcessID='{1}'  order by CreateOn ", resourceId, dtWF_Process.Rows[0]["Id"].ToString());
            DataTable dtCrmIdeaList = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmIdeaList).Tables[0];
            if (dtCrmIdeaList.Rows.Count > 0)
            {
                for (int i = 0; i < dtCrmIdeaList.Rows.Count; i++)
                {
                    if (i == 1)
                    {
                        SignType = "00310002";
                    }
                    else if (i == 2)
                    {
                        Account = "hongyuan";
                        SignType = "00310001";
                    }
                    else if (i == 3)
                    {
                        Account = "zas";
                        SignType = "00310003";
                    }
                    else
                    {
                        SignType = "00310003";
                    }
                    UserId = dtCrmIdeaList.Rows[i]["UserId"].ToString();
                    var strCrmUserSign = string.Format("select * from CrmUserSign where SignType = '00310001' AND UserId='{0}'", UserId);
                    var strCrmUserSignIdea = string.Format("select * from CrmUserSign where SignType = '{0}' AND UserId='{1}'", SignType, UserId);

                    DataTable dtCrmUserSign = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSign).Tables[0];
                    DataTable dtCrmUserSignIdea = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignIdea).Tables[0];
                    if (i == 0)//承办人意见及审批日期
                    {
                        UndertakerIdea = dtCrmUserSign.Rows[0]["Idea"].ToString();
                        UndertakerDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                    else if (i == 1)//部门签名、签字意见及审批日期 
                    {
                        DeptSignName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        DeptSignIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        DeptDate = dtCrmUserSign.Rows[i]["Idea"].ToString();
                    }
                    else if (i == 2 && dtCASEINFO.Rows[0]["CompanyName"].ToString() == "唯亭街道综合执法大队")
                    {
                        LegalSignName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        LegalSignIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        LegalDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                    else if (i == 3)//法制科签名、签字意见及审批日期图片
                    {
                        LegalSignName = dtCrmUserSign.Rows[i]["SignAddress"].ToString();
                        LegalSignIdea = dtCrmUserSignIdea.Rows[i]["SignAddress"].ToString();
                        LegalDate = dtCrmIdeaList.Rows[i]["CreateOn"].ToString();
                        if (dtCASEINFO.Rows[0]["CompanyName"].ToString() == "唯亭街道综合执法大队")//行政机关负责人签名、签字意见及审批日期
                        {
                            LeaderSignName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                            LeaderSignIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                            LeaderDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                        }
                    }
                    else if (i == 4)//行政机关负责人签名、签字意见及审批日期
                    {
                        LeaderSignName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        LeaderSignIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        LeaderDate = dtCrmIdeaList.Rows[i]["CreateOn"].ToString();
                        LeaderTempDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                }
            }
            #endregion

            #region 变量赋值
            if (dtCASEINFO.Rows.Count > 0)
            {
                //立案 年 号
                string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
                Year = _listCaseInfoNo[0];
                if (dtCASEINFO.Rows[0]["CompanyName"].ToString() == "唯亭街道综合执法大队")
                {
                    Num = _listCaseInfoNo[1].Substring(0, 7);
                }
                else
                {
                    Num = _listCaseInfoNo[1].Substring(0, 5);
                }
                //当事人类型
                if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120002")
                {
                    TargetName = "";
                    UnitLeader = dtCASEINFO.Rows[0]["TargetName"].ToString();
                }
                else
                {
                    UnitLeader = "";
                    UnitAddress = "";
                    TargetName = dtCASEINFO.Rows[0]["TargetName"].ToString();
                    if (dtCASEINFO.Rows[0]["TargetGender"].ToString() == "1")
                    {
                        TargetGender = "男";
                    }
                    else
                    {
                        TargetGender = "女";
                    }
                }
            }
            #endregion

            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["ItemName"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();
            }
            if (dtCASEINFO.Rows.Count > 0)
            {

                newRow["AcceptTime"] = DateTime.Parse(dtCASEINFO.Rows[0]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                newRow["CaseDate"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).ToString("yyyy年MM月dd日");
                newRow["CaseAddress"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();
                newRow["TargetUnit"] = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
                newRow["TargetDuty"] = dtCASEINFO.Rows[0]["TargetDuty"].ToString();
                newRow["TargetGender"] = TargetGender;
                newRow["TargetPaperNum"] = dtCASEINFO.Rows[0]["TargetPaperNum"].ToString();
                newRow["TargetPhone"] = dtCASEINFO.Rows[0]["TargetPhone"].ToString();
                newRow["CaseFact"] = dtCASEINFO.Rows[0]["CaseFact"].ToString();
                newRow["CaseHurtInfo"] = dtCASEINFO.Rows[0]["CaseHurtInfo"].ToString();
                newRow["CaseCreateDate"] = DateTime.Parse(dtCASEINFO.Rows[0]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");         //上报日期
                newRow["ReProof"] = dtCASEINFO.Rows[0]["ReProof"].ToString();   	           //立案证据
            }
            newRow["UnitLeader"] = UnitLeader;
            newRow["UnitAddress"] = UnitAddress;
            newRow["TargetName"] = TargetName;

            newRow["UndertakerIdea"] = UndertakerIdea; //承办人意见
            newRow["UndertakerDate"] = UndertakerDate;   //承办人审批日期

            newRow["DeptDate"] = DeptDate;  		 //部门审批日期

            newRow["LegalDate"] = LegalDate;  	 //法制科审批日期

            newRow["HearSign"] = "";  		 //会审审批
            newRow["HearIdea"] = "";  		 //会审审批意见
            newRow["HearDate"] = "";  		 //会审审批日期

            newRow["LeaderDate"] = LeaderDate;  	 //领导审批日期

            newRow["LeaderTempDate"] = LeaderTempDate;       //领导审批日期

            newRow["UndertakerFirstSignName"] = dtCrmUserSignFirst.Rows[0]["SignAddress"].ToString();
            newRow["UndertakerSecondSignName"] = dtCrmUserSignSecond.Rows[0]["SignAddress"].ToString();

            newRow["DeptSignName"] = DeptSignName;   		   //部门签名
            newRow["DeptSignIdea"] = DeptSignIdea;    		   //部门签字

            newRow["LegalSignName"] = LegalSignName;          //法制机构签名
            newRow["LegalSignIdea"] = LegalSignIdea;              //法制机构签字	

            newRow["LeaderSignName"] = LeaderSignName;   	           //行政机关负责人签名
            newRow["LeaderSignIdea"] = LeaderSignIdea;  	           //行政机关负责人签字
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 结案审批表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable Endration(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            string TargetName = string.Empty;
            string UnitLeader = string.Empty;
            string UnitAddress = string.Empty;
            string RegisterDate = string.Empty;//立案日期
            string UndertakerIdea = string.Empty;//承办人意见及审批日期
            string UndertakerDate = string.Empty;
            string DeptSignName = string.Empty;//部门签名、签字意见及审批日期
            string DeptSignIdea = string.Empty;
            string DeptDate = string.Empty;
            string LegalSignName = string.Empty;//法制科签名、签字意见及审批日期
            string LegalSignIdea = string.Empty;
            string LegalDate = string.Empty;
            string LeaderSignName = string.Empty;//行政机关负责人签名、签字意见及审批日期
            string LeaderSignIdea = string.Empty;
            string LeaderDate = string.Empty;
            string TargetGender = string.Empty;
            string SignType = string.Empty;
            string Account = string.Empty;
            string UserId = string.Empty;
            string FullName = string.Empty;
            DataTable dtAll = new DataTable();

            #region 添加列
            dtAll.Columns.Add("Year", typeof(string)); 		 //立案字（年）
            dtAll.Columns.Add("Num", typeof(string)); 			 //立案字（号）	
            dtAll.Columns.Add("ItemName", typeof(string));    //案由名称
            dtAll.Columns.Add("AcceptTime", typeof(string));  //受案时间
            dtAll.Columns.Add("CaseDate", typeof(string));    //案发时间
            dtAll.Columns.Add("CaseAddress", typeof(string));    //案发地点
            dtAll.Columns.Add("TargetUnit", typeof(string)); 	 //单位名称
            dtAll.Columns.Add("UnitLeader", typeof(string)); 	 //负责人姓名
            dtAll.Columns.Add("TargetDuty", typeof(string)); 	 //职务
            dtAll.Columns.Add("UnitAddress", typeof(string));    //单位地址
            dtAll.Columns.Add("TargetName", typeof(string)); 	 //当事人姓名
            dtAll.Columns.Add("TargetGender", typeof(string));     //当事人性别
            dtAll.Columns.Add("TargetPaperNum", typeof(string));   //当事人身份证号码
            dtAll.Columns.Add("TargetAge", typeof(string));        //年龄
            dtAll.Columns.Add("TargetAddress", typeof(string));  //当事人地址
            dtAll.Columns.Add("TargetPhone", typeof(string)); 	 //当事人联系电话
            dtAll.Columns.Add("TargetMobile", typeof(string));      //电话
            dtAll.Columns.Add("CaseFact", typeof(string)); 		 //案情摘要
            dtAll.Columns.Add("CaseHurtInfo", typeof(string));   //危害情况  

            dtAll.Columns.Add("ExecuteDesc", typeof(string)); 	 //执行情况
            dtAll.Columns.Add("PunishContent", typeof(string));  //处理情况
            dtAll.Columns.Add("LawsuitDesc", typeof(string));    //复议诉讼情况

            dtAll.Columns.Add("RegisterDate", typeof(string));    //立案日期
            dtAll.Columns.Add("EndDate", typeof(string));         //结案日期
            dtAll.Columns.Add("DeptDate", typeof(string)); 		 //部门审批日期
            dtAll.Columns.Add("LeaderDate", typeof(string)); 	 //领导审批日期
            dtAll.Columns.Add("UndertakerIdea", typeof(string)); //承办人意见
            dtAll.Columns.Add("UndertakerDate", typeof(string));  //承办人审批日期

            dtAll.Columns.Add("LegalSignName", typeof(string)); 	           //法制机构签名
            dtAll.Columns.Add("LegalSignIdea", typeof(string));             //法制机构签字

            dtAll.Columns.Add("LegalDate", typeof(string)); 	 //法制科审批日期

            dtAll.Columns.Add("UndertakerFirstSignName", typeof(string));    //承办人（一）签名
            dtAll.Columns.Add("UndertakerSecondSignName", typeof(string));   //承办人（二）签名

            dtAll.Columns.Add("LeaderSignName", typeof(string));  	        //行政机关负责人签名
            dtAll.Columns.Add("LeaderSignIdea", typeof(string));          //行政机关负责人签字

            dtAll.Columns.Add("DeptSignName", typeof(string)); 	   //部门签名
            dtAll.Columns.Add("DeptSignIdea", typeof(string)); 		   //部门签字
            dtAll.Columns.Add("CaseCreateDate", typeof(string));      //上报日期
            #endregion

            //案件基本信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);//案由
            //执行处理情况
            var strINF_PUNISH_FINISH = string.Format("select * from INF_PUNISH_FINISH where CaseInfoId='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];
            DataTable dtFINISH = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strINF_PUNISH_FINISH).Tables[0];
            //承办人签字
            var strCrmUserSignFirst = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strCrmUserSignSecond = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());

            DataTable dtCrmUserSignFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignFirst).Tables[0];
            DataTable dtCrmUserSignSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignSecond).Tables[0];
            #region 各个部门 签名、签字意见及审批日期
            //承办人意见及审批日期 1,部门签名、签字意见及审批日期 2，--法制科签名、签字意见及审批日期 4 
            //行政机关负责人签名、签字意见及审批日期5

            if (dtCASEINFO.Rows[0]["CompanyName"].ToString() == "唯亭街道综合执法大队") //CompanyName是唯亭街道综合执法大队
            {
                FullName = "处理审批";
            }
            else
            {
                FullName = "结案审批";
            }
            var strWF_Process = string.Format("select * from WF_Process where FullName = '{0}'", FullName);
            DataTable dtWF_Process = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strWF_Process).Tables[0];
            var strCrmIdeaList = string.Format("select * from CrmIdeaList where [Type] = 0 and ResourceID='{0}' and ProcessID='{1}'  order by CreateOn ", resourceId, dtWF_Process.Rows[0]["Id"].ToString());
            DataTable dtCrmIdeaList = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmIdeaList).Tables[0];
            if (dtCrmIdeaList.Rows.Count > 0)
            {
                for (int i = 0; i < dtCrmIdeaList.Rows.Count; i++)
                {
                    if (i == 1)
                    {
                        SignType = "00310002";
                    }
                    else if (i == 2)
                    {
                        Account = "hongyuan";
                        SignType = "00310001";
                    }
                    else if (i == 3)
                    {
                        Account = "zas";
                        SignType = "00310003";
                    }
                    else
                    {
                        SignType = "00310003";
                    }
                    UserId = dtCrmIdeaList.Rows[i]["UserId"].ToString();
                    var strCrmUserSign = string.Format("select * from CrmUserSign where SignType = '00310001' AND UserId='{0}'", UserId);
                    var strCrmUserSignIdea = string.Format("select * from CrmUserSign where SignType = '{0}' AND UserId='{1}'", SignType, UserId);

                    DataTable dtCrmUserSign = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSign).Tables[0];
                    DataTable dtCrmUserSignIdea = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignIdea).Tables[0];
                    if (i == 0)//承办人意见及审批日期
                    {
                        UndertakerIdea = dtCrmUserSign.Rows[0]["Idea"].ToString();
                        UndertakerDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                    else if (i == 1)//部门签名、签字意见及审批日期 
                    {
                        DeptSignName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        DeptSignIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        DeptDate = dtCrmUserSign.Rows[i]["Idea"].ToString();
                    }
                    else if (i == 2 && dtCASEINFO.Rows[0]["CompanyName"].ToString() == "唯亭街道综合执法大队")
                    {
                        LegalSignName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        LegalSignIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        LegalDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                    else if (i == 3)//法制科签名、签字意见及审批日期图片
                    {
                        LegalSignName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        LegalSignIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        LegalDate = dtCrmIdeaList.Rows[i]["CreateOn"].ToString();
                        if (dtCASEINFO.Rows[0]["CompanyName"].ToString() == "唯亭街道综合执法大队")//行政机关负责人签名、签字意见及审批日期
                        {
                            LeaderSignName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                            LeaderSignIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                            LeaderDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                        }
                    }
                    else if (i == 4)//行政机关负责人签名、签字意见及审批日期
                    {
                        LeaderSignName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        LeaderSignIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        LeaderDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                }
            }
            #endregion

            #region 立案日期
            var strWF_Processla = string.Format("select * from WF_Process where FullName = '立案审批'");
            DataTable dtWF_Processla = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strWF_Processla).Tables[0];
            var strCrmIdeaListla = string.Format("select * from CrmIdeaList where [Type] = 0 and ResourceID='{0}' and ProcessID='{1}'  order by CreateOn ", resourceId, dtWF_Processla.Rows[0]["Id"].ToString());
            DataTable dtCrmIdeaListla = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmIdeaListla).Tables[0];
            if (dtCrmIdeaListla.Rows.Count > 0)
            {
                for (int i = 0; i < dtCrmIdeaListla.Rows.Count; i++)
                {
                    if (i == 3)
                    {
                        RegisterDate = dtCrmIdeaListla.Rows[0]["CreateOn"].ToString();
                    }
                }
            }
            #endregion
            #region 变量赋值
            if (dtCASEINFO.Rows.Count > 0)
            {
                //立案 年 号
                string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
                Year = _listCaseInfoNo[0];
                Num = _listCaseInfoNo[1].Substring(0, 5);

                //当事人类型
                if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120002")
                {
                    TargetName = "";
                    UnitAddress = dtCASEINFO.Rows[0]["TargetAddress"].ToString();
                    UnitLeader = dtCASEINFO.Rows[0]["TargetName"].ToString();
                }
                else
                {
                    UnitLeader = "";
                    UnitAddress = "";
                    TargetName = dtCASEINFO.Rows[0]["TargetName"].ToString();
                }
                if (dtCASEINFO.Rows[0]["TargetGender"].ToString() == "1")
                {
                    TargetGender = "男";
                }
                else
                {
                    TargetGender = "女";
                }
            }
            #endregion
            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["ItemName"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();
            }
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["AcceptTime"] = DateTime.Parse(dtCASEINFO.Rows[0]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                newRow["CaseDate"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).ToString("yyyy年MM月dd日");
                newRow["CaseAddress"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();
                newRow["TargetUnit"] = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
                newRow["TargetDuty"] = dtCASEINFO.Rows[0]["TargetDuty"].ToString();
                newRow["TargetPaperNum"] = dtCASEINFO.Rows[0]["TargetPaperNum"].ToString();
                newRow["TargetAge"] = dtCASEINFO.Rows[0]["TargetAge"].ToString();
                newRow["TargetAddress"] = dtCASEINFO.Rows[0]["TargetAddress"].ToString();
                newRow["TargetPhone"] = dtCASEINFO.Rows[0]["TargetPhone"].ToString();
                newRow["TargetMobile"] = dtCASEINFO.Rows[0]["TargetMobile"].ToString();
                newRow["CaseFact"] = dtCASEINFO.Rows[0]["CaseFact"].ToString();
                newRow["CaseHurtInfo"] = dtCASEINFO.Rows[0]["CaseHurtInfo"].ToString();
            }
            newRow["TargetName"] = TargetName;
            newRow["UnitLeader"] = UnitLeader;
            newRow["UnitAddress"] = UnitAddress;
            newRow["TargetGender"] = TargetGender;
            if (dtFINISH.Rows.Count > 0)
            {
                newRow["ExecuteDesc"] = dtFINISH.Rows[0]["ExecuteDesc"].ToString();
                newRow["PunishContent"] = dtFINISH.Rows[0]["PunishContent"].ToString();
                newRow["LawsuitDesc"] = dtFINISH.Rows[0]["LawsuitDesc"].ToString();
                newRow["EndDate"] = DateTime.Parse(dtFINISH.Rows[0]["FINISHDATE"].ToString()).ToString("yyyy年MM月dd日");
            }
            newRow["RegisterDate"] = RegisterDate;
            newRow["DeptDate"] = DeptDate;
            newRow["LeaderDate"] = LeaderDate;
            newRow["UndertakerIdea"] = UndertakerIdea;
            newRow["UndertakerDate"] = UndertakerDate;

            newRow["LegalSignName"] = LegalSignName;
            newRow["LegalSignIdea"] = LegalSignIdea;
            newRow["LegalDate"] = LegalDate;

            newRow["UndertakerFirstSignName"] = dtCrmUserSignFirst.Rows[0]["SignAddress"].ToString();
            newRow["UndertakerSecondSignName"] = dtCrmUserSignSecond.Rows[0]["SignAddress"].ToString();

            newRow["LeaderSignName"] = LeaderSignName;
            newRow["LeaderSignIdea"] = LeaderSignIdea;
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 送达回证(告知书)
        /// </summary>
        /// <param name="resourceId">案件编号</param>
        /// <returns></returns>
        public DataTable CaceBackCard(string resourceId)
        {
            string ReceiptAddress = string.Empty;
            //整合数据
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("ItemName", typeof(string));
            dtAll.Columns.Add("ReceiptAddress", typeof(string));//送达地点
            dtAll.Columns.Add("SigninPerson", typeof(string));//受送达人
            dtAll.Columns.Add("SinginDate", typeof(string));//收到时间
            dtAll.Columns.Add("CaseInfoNo", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("CreateOn", typeof(string));
            dtAll.Columns.Add("UndertakerFirstSignName", typeof(string));    //承办人（一）签名
            dtAll.Columns.Add("UndertakerSecondSignName", typeof(string));   //承办人（二）签名

            #endregion
            //调查询问笔录
            var strRECORD = string.Format("SELECT  *  FROM  INF_PUNISH_RECORD    WHERE   CaseInfoId ='{0}'", resourceId);
            var strRECEIPT = string.Format("SELECT  * FROM  INF_PUNISH_RECEIPT WHERE ServiceType=1 and   CaseInfoId ='{0}'", resourceId);
            var strCASEINFO = string.Format("SELECT * FROM INF_PUNISH_CASEINFO WHERE    ID ='{0}'", resourceId);

            DataTable dtRECORD = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strRECORD).Tables[0];
            DataTable dtRECEIPT = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strRECEIPT).Tables[0];
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            //送达人签字
            var strCrmUserSignFirst = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strCrmUserSignSecond = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());

            DataTable dtCrmUserSignFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignFirst).Tables[0];
            DataTable dtCrmUserSignSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignSecond).Tables[0];
            string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
            string Year = _listCaseInfoNo[0];
            string Num = string.Empty;
            if (dtCASEINFO.Rows[0]["CompanyName"].ToString() == "唯亭街道综合执法大队")
            {
                Num = _listCaseInfoNo[1].Substring(0, 7);
            }
            else
            {
                Num = _listCaseInfoNo[1].Substring(0, 5);
            }
            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            if (dtRECORD.Rows.Count > 0)
            {
                newRow["ItemName"] = dtRECORD.Rows[0]["Address"];
                ReceiptAddress = dtRECORD.Rows[0]["Address"].ToString();
            }
            if (dtRECEIPT.Rows.Count > 0)
            {
                newRow["SigninPerson"] = dtRECEIPT.Rows[0]["SigninPerson"];
                newRow["SinginDate"] = DateTime.Parse(dtRECEIPT.Rows[0]["SinginDate"].ToString()).ToString("yyyy年MM月dd日");
            }
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["CaseInfoNo"] = dtCASEINFO.Rows[0]["CaseInfoNo"];
                newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"];
                if (!string.IsNullOrEmpty(ReceiptAddress))
                {
                    newRow["ReceiptAddress"] = ReceiptAddress;
                }
                else
                {
                    newRow["ReceiptAddress"] = "苏州姑苏区城市管理行政执法局" + dtCASEINFO.Rows[0]["CompanyName"] + dtCASEINFO.Rows[0]["DeptName"];
                }
                newRow["CreateOn"] = DateTime.Parse(dtCASEINFO.Rows[0]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
            }
            newRow["UndertakerFirstSignName"] = dtCrmUserSignFirst.Rows[0]["SignAddress"].ToString();
            newRow["UndertakerSecondSignName"] = dtCrmUserSignSecond.Rows[0]["SignAddress"].ToString();
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 送达回证(决定书)
        /// </summary>
        /// <param name="resourceId">案件编号</param>
        /// <returns></returns>
        public DataTable CaceBackCardD(string resourceId)
        {
            //整合数据
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));                //执法告字（年）
            dtAll.Columns.Add("Num", typeof(string));                 //执法告字（号）
            dtAll.Columns.Add("ItemName", typeof(string));            //案由名称
            dtAll.Columns.Add("Address", typeof(string));            //当事人类型
            dtAll.Columns.Add("SigninPerson", typeof(string));       //受送达人
            dtAll.Columns.Add("SinginDate", typeof(string));         //收到时间
            dtAll.Columns.Add("CaseInfoNo", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("CreateOn", typeof(string));
            dtAll.Columns.Add("UdPersonelIdFirst", typeof(string));
            dtAll.Columns.Add("UdPersonelIdSecond", typeof(string));
            #endregion

            //获取年，号
            var strRECORD = string.Format("SELECT  *   FROM  INF_PUNISH_RECORD    WHERE   CaseInfoId ='{0}'", resourceId);
            var strINF_PUNISH_RECEIPT = string.Format("SELECT  * FROM  INF_PUNISH_RECEIPT WHERE ServiceType=2 and   CaseInfoId ='{0}'", resourceId);
            var strCASEINFO = string.Format("SELECT  * FROM INF_PUNISH_CASEINFO WHERE    ID ='{0}'", resourceId);

            DataTable dtRECORD = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strRECORD).Tables[0];
            DataTable dtINF_PUNISH_RECEIPT = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strINF_PUNISH_RECEIPT).Tables[0];
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
            string Year = _listCaseInfoNo[0];
            string Num = string.Empty;
            if (dtCASEINFO.Rows[0]["CompanyName"].ToString() == "唯亭街道综合执法大队")
            {
                Num = _listCaseInfoNo[1].Substring(0, 7);
            }
            else
            {
                Num = _listCaseInfoNo[1].Substring(0, 5);
            }
            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            newRow["ItemName"] = dtRECORD.Rows[0]["Address"];
            newRow["Address"] = dtRECORD.Rows[0]["Address"];
            newRow["SigninPerson"] = dtINF_PUNISH_RECEIPT.Rows[0]["SigninPerson"];
            newRow["SinginDate"] = dtINF_PUNISH_RECEIPT.Rows[0]["SinginDate"];
            newRow["CaseInfoNo"] = dtCASEINFO.Rows[0]["CaseInfoNo"];
            newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"];
            newRow["CompanyName"] = dtCASEINFO.Rows[0]["CompanyName"];
            newRow["CreateOn"] = dtCASEINFO.Rows[0]["CreateOn"];
            newRow["UdPersonelIdFirst"] = dtCASEINFO.Rows[0]["UdPersonelIdFirst"];
            newRow["UdPersonelIdSecond"] = dtCASEINFO.Rows[0]["UdPersonelIdSecond"];
            dtAll.Rows.Add(newRow);

            #endregion
            return dtAll;
        }

        /// <summary>
        /// 委托单（一般、简易）
        /// </summary>
        /// <param name="resourceId">案件编号</param>
        /// <returns></returns>
        public DataTable CaseOrder(string resourceId)
        {
            //整合数据
            string CaseNo = string.Empty;            //编号
            string TargetType = string.Empty;       //当事人类型
            string Name = string.Empty;             //姓名

            #region 添加DataTable列
            DataTable dtAll = new DataTable();
            dtAll.Columns.Add("CaseNo", typeof(string));              //决定书号
            dtAll.Columns.Add("Name", typeof(string));              //姓名
            dtAll.Columns.Add("TargetType", typeof(string));        //当事人类型
            dtAll.Columns.Add("Address", typeof(string));            //当事人地址
            dtAll.Columns.Add("Phone", typeof(string));              //联系电话
            dtAll.Columns.Add("CardN", typeof(string));              //证件号码   
            dtAll.Columns.Add("PunishMoney", typeof(float));        //处罚金额
            dtAll.Columns.Add("TotalMoney", typeof(float));         //没收金额
            dtAll.Columns.Add("TotalMoneyUp", typeof(string));        //总金额
            dtAll.Columns.Add("NoMoney", typeof(string));            //总金额（大写）
            dtAll.Columns.Add("SDDate", typeof(string));             //送达日期
            #endregion

            #region 查询相关表数据

            var strINF_PUNISH_RECEIPT = string.Format("SELECT  * FROM INF_PUNISH_RECEIPT WHERE   ServiceType = 2 AND caseinfoid ='{0}'", resourceId);
            var strCASEINFO = string.Format("SELECT * FROM INF_PUNISH_CASEINFO WHERE ID ='{0}'", resourceId);
            var strLEGISLATION = string.Format("SELECT PunishAmount FROM INF_PUNISH_LEGISLATION	WHERE RowStatus=1  AND CaseInfoId='{0}' ", resourceId);
            var strDECISION = string.Format("SELECT PunishAmount FROM INF_PUNISH_DECISION WHERE CASEINFOID = '{0}'", resourceId);

            DataTable dtRECEIPT = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strINF_PUNISH_RECEIPT).Tables[0];
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];
            DataTable dtDECISION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strDECISION).Tables[0];

            #endregion

            #region 变量赋值
            if (dtCASEINFO.Rows[0]["PunishProcess"].ToString() == "00280001")
            {
                CaseNo = dtCASEINFO.Rows[0]["CompanyName"].ToString();
            }
            else
            {
                string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
                if (dtCASEINFO.Rows[0]["CompanyName"].ToString() == "唯亭街道综合执法大队")
                {
                    CaseNo = "苏园城法罚决字[" + _listCaseInfoNo[0] + "]第" + _listCaseInfoNo[1].Substring(0, 7) + "号";
                }
                else
                {
                    CaseNo = "苏园城法罚决字[" + _listCaseInfoNo[0] + "]第" + _listCaseInfoNo[1].Substring(0, 5) + "号";
                }
            }
            //根据当事人类型判断 名称
            if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120002")
            {
                Name = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
            }
            else
            {
                Name = dtCASEINFO.Rows[0]["TargetName"].ToString();
            }
            #endregion

            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["CaseNo"] = CaseNo;
            newRow["Name"] = Name;
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["TargetType"] = dtCASEINFO.Rows[0]["TargetType"];
                newRow["Address"] = dtCASEINFO.Rows[0]["TargetAddress"];
                newRow["Phone"] = dtCASEINFO.Rows[0]["ReportPhone"];
                newRow["CardN"] = dtCASEINFO.Rows[0]["TargetPaperNum"];
            }
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["PunishMoney"] = dtLEGISLATION.Rows[0]["PunishAmount"];
                newRow["TotalMoney"] = dtLEGISLATION.Rows[0]["PunishAmount"];
            }
            if (dtDECISION.Rows.Count > 0)
            {
                newRow["TotalMoneyUp"] = dtDECISION.Rows[0]["PunishAmount"];
                newRow["NoMoney"] = dtDECISION.Rows[0]["PunishAmount"];
            }
            if (dtRECEIPT.Rows.Count > 0)
            {
                newRow["SDDate"] = DateTime.Parse(dtRECEIPT.Rows[0]["SinginDate"].ToString()).ToString("yyyy年MM月dd日");
            }
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }
        /// <summary>
        /// 告知书 
        /// </summary>
        /// <param name="resourceId">案件编号</param>
        /// <returns></returns>
        public DataTable Inform(string resourceId)
        {
            string Year = string.Empty;  //执法告字（年）
            string Num = string.Empty;  //执法告字（年）
            string TargetName = string.Empty; //当事人名称
            string DecisionYear = string.Empty;  //决定书日期 年
            string DecisionMonth = string.Empty;  //决定书日期 月
            string DecisionDay = string.Empty;  //决定书日期 日
            string FileFact = string.Empty; //经查内容
            #region DataTable 添加列
            DataTable dtAll = new DataTable();
            dtAll.Columns.Add("Year", typeof(string));                //执法告字（年）
            dtAll.Columns.Add("Num", typeof(string));                 //执法告字（号）
            dtAll.Columns.Add("TargetName", typeof(string));            //当事人名称
            dtAll.Columns.Add("FileDate", typeof(string));            //经查日期
            dtAll.Columns.Add("FileFact", typeof(string));       //经查内容
            dtAll.Columns.Add("GistName", typeof(string));         //违反法规
            dtAll.Columns.Add("DutyName", typeof(string));           //处罚依据
            dtAll.Columns.Add("PunishContent", typeof(string));      //处罚内容
            dtAll.Columns.Add("FileDateCapital", typeof(string));    //告知书日期
            dtAll.Columns.Add("DECISIONYear", typeof(string));       //决定书日期 年
            dtAll.Columns.Add("DECISIONMonth", typeof(string));      //决定书日期 月
            dtAll.Columns.Add("DECISIONDay", typeof(string));        //决定书日期 日
            #endregion

            var strINFORM = string.Format("SELECT * FROM INF_PUNISH_INFORM  WHERE CaseInfoId ='{0}'", resourceId);
            var strCASEINFO = string.Format(" SELECT *  FROM INF_PUNISH_CASEINFO where ID='{0}'", resourceId);
            DataTable dtINFORM = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strINFORM).Tables[0];
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            #region 字段赋值
            //年，号赋值
            if (!string.IsNullOrEmpty(dtINFORM.Rows[0]["FileNumber"].ToString()))
            {
                string[] arrayFileNumber = dtINFORM.Rows[0]["FileNumber"].ToString().Split('-');
                if (arrayFileNumber.Length == 2)
                {
                    Year = arrayFileNumber[0];
                    Num = arrayFileNumber[1];
                }
            }
            //当事人类型判断
            if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120002")
            {
                TargetName = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
            }
            else
            {
                TargetName = dtCASEINFO.Rows[0]["TargetName"].ToString();
            }
            //决定书日期 年 月 日 赋值
            DateTime FileDateCapital = DateTime.Parse(dtINFORM.Rows[0]["FileDateCapital"].ToString());
            DecisionYear = FileDateCapital.Year.ToString();
            DecisionMonth = FileDateCapital.Month.ToString();
            DecisionDay = FileDateCapital.Day.ToString();
            FileFact = dtINFORM.Rows[0]["CaseAddr"].ToString() + dtINFORM.Rows[0]["ItemName"].ToString();
            #endregion

            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            newRow["TargetName"] = TargetName;
            newRow["FileFact"] = FileFact;
            if (dtINFORM.Rows.Count > 0)
            {
                newRow["FileDate"] = DateTime.Parse(dtINFORM.Rows[0]["CaseDate"].ToString()).ToString("yyyy年MM月dd日");
                newRow["GistName"] = dtINFORM.Rows[0]["GistName"];
                newRow["DutyName"] = dtINFORM.Rows[0]["DutyName"];
                newRow["PunishContent"] = dtINFORM.Rows[0]["PunishContent"];
                newRow["FileDateCapital"] = dtINFORM.Rows[0]["FileDateCapital"];
            }
            newRow["DECISIONYear"] = DecisionYear;
            newRow["DECISIONMonth"] = DecisionMonth;
            newRow["DECISIONDay"] = DecisionDay;
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 简易案件决定书
        /// </summary>
        /// <param name="resourceId">案件编号</param>
        /// <returns></returns>
        public DataTable SimpleCase(string resourceId)
        {
            string Year = string.Empty;     //处理日期（年） 
            string Month = string.Empty;    //处理日期（月）
            string Day = string.Empty;      //处理日期（日）
            string TargetUnit = string.Empty; //
            string TargetUnitAddress = string.Empty;
            string TargetUnitName = string.Empty;
            string TargetName = string.Empty;
            string Sex = string.Empty;//性别
            string Age = string.Empty;//年龄
            string Address = string.Empty;//住址或单位
            string PunishContent = string.Empty;
            #region DataTable 添加列
            DataTable dtAll = new DataTable();
            dtAll.Columns.Add("TargetType", typeof(string));	//当事人类型
            dtAll.Columns.Add("CaseInfoNo", typeof(string));	//案件编号
            dtAll.Columns.Add("TargetName", typeof(string));	//当事人名称
            dtAll.Columns.Add("Sex", typeof(Int32));		//性别
            dtAll.Columns.Add("Age", typeof(Int32));			//年龄
            dtAll.Columns.Add("Address", typeof(string));//住址或单位
            dtAll.Columns.Add("TargetUnit", typeof(string));	//法人或其它组织
            dtAll.Columns.Add("TargetUnitAddress", typeof(string));//法人或其它组织地址
            dtAll.Columns.Add("TargetUnitName", typeof(string));//负责人
            dtAll.Columns.Add("CheckDate", typeof(string));	//案发日期
            dtAll.Columns.Add("CheckSingAddress", typeof(string));	//案发地点
            dtAll.Columns.Add("ItemAct", typeof(string));			//违法行为
            dtAll.Columns.Add("GistName", typeof(string));			//违反法规
            dtAll.Columns.Add("DutyName", typeof(string));			//处罚依据
            dtAll.Columns.Add("PunishAmount", typeof(string));	//处罚金额
            dtAll.Columns.Add("PunishContent", typeof(string));	//处罚内容
            dtAll.Columns.Add("Year", typeof(string));		//处理日期（年）		
            dtAll.Columns.Add("Month", typeof(string));		//处理日期（月）
            dtAll.Columns.Add("Day", typeof(string));		//处理日期（日）
            #endregion

            var strCASEINFO = string.Format("SELECT CaseInfoNo,TargetType,TargetName,TargetGender,TargetAge,TargetAddress,TargetUnit,CaseDate,CaseAddress FROM  INF_PUNISH_CASEINFO WHERE  Id ='{0}'", resourceId);
            var strLEGISLATION = string.Format("SELECT ItemAct,GistName,DutyName, PunishAmount FROM  INF_PUNISH_LEGISLATION  WHERE CaseInfoId = '{0}'", resourceId);
            var strINF_PUNISH_FINISH = string.Format("SELECT FinishDate FROM  dbo.INF_PUNISH_FINISH WHERE CaseInfoId ='{0}'", resourceId);

            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];
            DataTable dtFINISH = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strINF_PUNISH_FINISH).Tables[0];
            #region 判断 赋值
            if (dtCASEINFO.Rows.Count > 0)
            {

                //当事人类型
                if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120001")//当事人为公民
                {
                    TargetUnit = string.Empty; //
                    TargetUnitAddress = string.Empty;
                    TargetUnitName = string.Empty;
                    TargetName = dtCASEINFO.Rows[0]["TargetName"].ToString();//姓名
                    Sex = dtCASEINFO.Rows[0]["TargetGender"].ToString();//性别
                    Age = dtCASEINFO.Rows[0]["TargetAge"].ToString();//年龄
                    Address = dtCASEINFO.Rows[0]["TargetAddress"].ToString();//住址或单位
                }
                else
                {
                    TargetUnit = dtCASEINFO.Rows[0]["TargetUnit"].ToString(); //
                    TargetUnitAddress = dtCASEINFO.Rows[0]["TargetAddress"].ToString();
                    TargetUnitName = dtCASEINFO.Rows[0]["TargetName"].ToString();
                    TargetName = string.Empty;
                    Sex = string.Empty;//性别
                    Age = string.Empty;//年龄
                    Address = string.Empty;//住址或单位
                }
            }
            if (dtLEGISLATION.Rows.Count > 0)
            {
                //惩罚内容
                if (dtLEGISLATION.Rows[0]["PunishAmount"].ToString() != "0")
                {
                    PunishContent = dtLEGISLATION.Rows[0]["PunishAmount"].ToString() + "罚款";
                }
                else
                {
                    PunishContent = "警告";
                }
            }
            //年月日
            DateTime FinishDate = DateTime.Parse(dtFINISH.Rows[0][0].ToString());

            Year = FinishDate.Year.ToString();
            Month = FinishDate.Month.ToString();
            Day = FinishDate.Day.ToString();
            #endregion

            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["TargetType"] = dtCASEINFO.Rows[0]["TargetType"];
                newRow["CaseInfoNo"] = dtCASEINFO.Rows[0]["CaseInfoNo"];
                newRow["CheckDate"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).ToString("yyyy年MM月dd日");
                newRow["CheckSingAddress"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();
            }
            newRow["TargetName"] = TargetName;
            newRow["Sex"] = Sex;
            newRow["Age"] = Age;
            newRow["Address"] = Address;
            newRow["TargetUnit"] = TargetUnit;
            newRow["TargetUnitAddress"] = TargetUnitAddress;
            newRow["TargetUnitName"] = TargetUnitName;
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["ItemAct"] = dtLEGISLATION.Rows[0]["ItemAct"].ToString();
                newRow["GistName"] = dtLEGISLATION.Rows[0]["GistName"].ToString();
                newRow["DutyName"] = dtLEGISLATION.Rows[0]["DutyName"].ToString();
                newRow["PunishAmount"] = dtLEGISLATION.Rows[0]["PunishAmount"].ToString();
            }
            newRow["PunishContent"] = PunishContent;
            newRow["Year"] = Year;
            newRow["Month"] = Month;
            newRow["Day"] = Day;
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 违章停车决定书
        /// </summary>
        /// <param name="resourceId">案件编号</param>
        /// <returns></returns>
        public DataTable SimpleCar(string resourceId)
        {
            string Year = string.Empty;     //处理日期（年） 
            string Month = string.Empty;    //处理日期（月）
            string Day = string.Empty;      //处理日期（日）
            string PunishContent = string.Empty;
            #region DataTable 添加列
            DataTable dtAll = new DataTable();
            dtAll.Columns.Add("CaseInfoNo", typeof(string));	//案件编号
            dtAll.Columns.Add("TargetName", typeof(string)); 	//当事人名称
            dtAll.Columns.Add("Sex", typeof(Int32));		    //性别
            dtAll.Columns.Add("Age", typeof(Int32));			//年龄
            dtAll.Columns.Add("Address", typeof(string));      //住址或单位
            dtAll.Columns.Add("TargetUnit", typeof(string));	//法人或其它组织
            dtAll.Columns.Add("TargetUnitAddress", typeof(string));  //法人或其它组织地址
            dtAll.Columns.Add("TargetUnitName", typeof(string));      //负责人
            dtAll.Columns.Add("CheckDate", typeof(string));			  //案发日期
            dtAll.Columns.Add("CheckSingAddress", typeof(string));	  //案发地点
            dtAll.Columns.Add("ItemAct", typeof(string));			//违法行为
            dtAll.Columns.Add("GistName", typeof(string));			//违反法规
            dtAll.Columns.Add("DutyName", typeof(string));			//处罚依据
            dtAll.Columns.Add("PunishAmount", typeof(string));	//处罚金额
            dtAll.Columns.Add("PunishContent", typeof(string));	//处罚内容    
            dtAll.Columns.Add("Year", typeof(string));		//处理日期（年） 		
            dtAll.Columns.Add("Month", typeof(string));		//处理日期（月）
            dtAll.Columns.Add("Day", typeof(string));		//处理日期（日）
            #endregion

            var strCHECKSIGN = string.Format(" SELECT  * FROM  INF_CAR_CHECKSIGN WHERE  Id ='{0}'", resourceId);
            DataTable dtCHECKSIGN = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCHECKSIGN).Tables[0];
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            #region 判断 赋值
            if (dtCHECKSIGN.Rows.Count > 0)
            {
                //惩罚内容
                PunishContent = "伍拾元整罚款";
                //年月日
                DateTime FinishDate = DateTime.Parse(dtCHECKSIGN.Rows[0]["CheckDate"].ToString());
                Year = FinishDate.Year.ToString();
                Month = FinishDate.Month.ToString();
                Day = FinishDate.Day.ToString();
            }
            #endregion

            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtCHECKSIGN.Rows.Count > 0)
            {
                newRow["CaseInfoNo"] = dtCHECKSIGN.Rows[0]["CfapproveNo"];
                newRow["TargetName"] = dtCHECKSIGN.Rows[0]["Name"];
                newRow["Sex"] = dtCHECKSIGN.Rows[0]["Sex"];
                newRow["Age"] = dtCHECKSIGN.Rows[0]["Age"];
                newRow["Address"] = dtCHECKSIGN.Rows[0]["Address"];
                newRow["CheckDate"] = DateTime.Parse(dtCHECKSIGN.Rows[0]["CheckDate"].ToString()).ToString("yyyy年MM月dd日");
                newRow["CheckSingAddress"] = dtCHECKSIGN.Rows[0]["CheckSignAddress"].ToString();
            }
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["TargetUnit"] = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
                newRow["TargetUnitAddress"] = dtCASEINFO.Rows[0]["TargetUnitAddress"].ToString();
                newRow["TargetUnitName"] = dtCASEINFO.Rows[0]["TargetUnitName"].ToString();
            }
            newRow["ItemAct"] = "不按照规定在城市人行道上停放机动车";
            newRow["GistName"] = "《中华人民共和国道路交通安全法》第五十六条";
            newRow["DutyName"] = "《中华人民共和国道路交通安全法》第九十条";
            newRow["PunishAmount"] = "50";
            newRow["PunishContent"] = PunishContent;
            newRow["Year"] = Year;
            newRow["Month"] = Month;
            newRow["Day"] = Day;
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 违章停车委托单
        /// </summary>
        /// <param name="resourceId">案件编号</param>
        /// <returns></returns>
        public DataTable CarOrder(string resourceId)
        {
            string Year = string.Empty;     //处理日期（年） 
            string Month = string.Empty;    //处理日期（月）
            string Day = string.Empty;      //处理日期（日）            
            #region 添加列
            DataTable dtAll = new DataTable();
            dtAll.Columns.Add("CaseNo", typeof(string));		//决定书号
            dtAll.Columns.Add("Name", typeof(string));//姓名	
            dtAll.Columns.Add("Address", typeof(string));		//当事人地址
            dtAll.Columns.Add("Phone", typeof(string));		//联系电话
            dtAll.Columns.Add("CardN", typeof(string));		//证件号码
            dtAll.Columns.Add("PunishMoney", typeof(string));	//处罚金额
            dtAll.Columns.Add("NoMoney", typeof(string));	//没收金额
            dtAll.Columns.Add("TotalMoney", typeof(string));	//总金额
            dtAll.Columns.Add("TotalMoneyUp", typeof(string));	//总金额（大写）
            dtAll.Columns.Add("SDDate", typeof(string));//送达日期

            #endregion
            var strINF_CAR_CHECKSIGN = string.Format("SELECT CfapproveNo,Name,Address,Telephone,PersonNo FROM  INF_CAR_CHECKSIGN WHERE  Id = '{0}'", resourceId);
            DataTable dtCHECKSIGN = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strINF_CAR_CHECKSIGN).Tables[0];

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["CaseNo"] = dtCHECKSIGN.Rows[0]["CfapproveNo"];
            newRow["Name"] = dtCHECKSIGN.Rows[0]["Name"];
            newRow["Address"] = dtCHECKSIGN.Rows[0]["Address"];
            newRow["Phone"] = dtCHECKSIGN.Rows[0]["Telephone"];
            newRow["CardN"] = dtCHECKSIGN.Rows[0]["PersonNo"];
            newRow["PunishMoney"] = "¥50.00";
            newRow["NoMoney"] = "";
            newRow["TotalMoney"] = "¥50.00";
            newRow["TotalMoneyUp"] = "伍拾元整";
            newRow["SDDate"] = DateTime.Now.ToLongDateString().ToString();
            dtAll.Rows.Add(newRow);
            #endregion
            return null;
        }

        /// <summary>
        /// 一般案件调查 询问笔录
        /// </summary>
        /// <param name="resourceId">案件编号</param>
        /// <returns></returns>
        public DataTable Record(string resourceId)
        {
            string StartDateYear = string.Empty;//询问开始时间
            string StartDateMonth = string.Empty;
            string StartDateDay = string.Empty;
            string StartDateHour = string.Empty;
            string StartDateMinute = string.Empty;
            string EndDateYear = string.Empty;	//询问截止时间
            string EndDateMonth = string.Empty;
            string EndDateDay = string.Empty;
            string EndDateHour = string.Empty;
            string EndDateMinute = string.Empty;
            string TargetGender = string.Empty;

            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("ItemName", typeof(string)); 		//案由名称
            dtAll.Columns.Add("TargetType", typeof(string));		        //当事人类型
            dtAll.Columns.Add("StartDateYear", typeof(string));	        //询问开始时间
            dtAll.Columns.Add("StartDateMonth", typeof(string));
            dtAll.Columns.Add("StartDateDay", typeof(string));
            dtAll.Columns.Add("StartDateHour", typeof(string));
            dtAll.Columns.Add("StartDateMinute", typeof(string));
            dtAll.Columns.Add("EndDateYear", typeof(string));        //询问截止时间
            dtAll.Columns.Add("EndDateMonth", typeof(string));
            dtAll.Columns.Add("EndDateDay", typeof(string));
            dtAll.Columns.Add("EndDateHour", typeof(string));
            dtAll.Columns.Add("EndDateMinute", typeof(string));
            dtAll.Columns.Add("Address", typeof(string));		    //询问地点   
            dtAll.Columns.Add("QuestionerFirstName", typeof(string));  //调查人一姓名
            dtAll.Columns.Add("QuestionerSecondName", typeof(string)); //调查人二姓名
            dtAll.Columns.Add("FirstUserId", typeof(string));
            dtAll.Columns.Add("SecondUserId", typeof(string));
            dtAll.Columns.Add("FirstCode", typeof(string));      //调查人一证件号
            dtAll.Columns.Add("SecondCode", typeof(string));     //调查人二证件号
            dtAll.Columns.Add("RecordsName", typeof(string));		   //记录人姓名    
            dtAll.Columns.Add("TargetName", typeof(string));	    //被调查人
            dtAll.Columns.Add("TargetAddress", typeof(string));   //被调查人地址
            dtAll.Columns.Add("TargetPaperNum", typeof(string)); //被调查人证件号码
            dtAll.Columns.Add("TargetGender", typeof(string));	 //性别
            dtAll.Columns.Add("BirthDate", typeof(string));	 //出生日期    
            dtAll.Columns.Add("TargetUnit", typeof(string));  //单位
            dtAll.Columns.Add("TargetDuty", typeof(string));   //职务
            dtAll.Columns.Add("TargetZipCode", typeof(string)); //邮编
            dtAll.Columns.Add("RecordInfo", typeof(string));  //询问内容
            dtAll.Columns.Add("UndertakerFirstSignName", typeof(string));
            dtAll.Columns.Add("UndertakerSecondSignName", typeof(string));//承办人（二）签名
            #endregion

            var strRECORD = string.Format("SELECT * FROM INF_PUNISH_RECORD where CaseInfoId ='{0}'", resourceId);
            var strCASEINFO = string.Format("SELECT *  FROM INF_PUNISH_CASEINFO where ID='{0}'", resourceId);
            DataTable dtRECORD = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strRECORD).Tables[0];
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            var strCrmUserSignFirst = string.Format("SELECT  *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strCrmUserSignSecond = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());

            var strBase_CertificateFirst = string.Format("SELECT * FROM Base_Certificate where UserId='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strBase_CertificateSecond = string.Format("SELECT * FROM Base_Certificate where UserId='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());
            DataTable dtCrmUserSignFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignFirst).Tables[0];
            DataTable dtCrmUserSignSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignSecond).Tables[0];
            DataTable dtBase_CertificateFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strBase_CertificateFirst).Tables[0];
            DataTable dtBase_CertificateSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strBase_CertificateSecond).Tables[0];
            #region 时间字段赋值
            if (dtRECORD.Rows.Count > 0)
            {
                DateTime StartDate = DateTime.Parse(dtRECORD.Rows[0][1].ToString());
                StartDateYear = StartDate.Year.ToString();
                StartDateMonth = StartDate.Month.ToString();
                StartDateDay = StartDate.Day.ToString();
                StartDateHour = StartDate.Hour.ToString();
                StartDateMinute = StartDate.Minute.ToString();
                DateTime EndDate = DateTime.Parse(dtRECORD.Rows[0][2].ToString());
                EndDateYear = EndDate.Year.ToString();
                EndDateMonth = EndDate.Month.ToString();
                EndDateDay = EndDate.Day.ToString();
                EndDateHour = EndDate.Hour.ToString();
                EndDateMinute = EndDate.Minute.ToString();
                if (dtRECORD.Rows[0]["TargetGender"].ToString() == "1")
                {
                    TargetGender = "男";
                }
                else
                {
                    TargetGender = "女";
                }
            }
            #endregion

            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtRECORD.Rows.Count > 0)
            {
                newRow["ItemName"] = dtRECORD.Rows[0]["ItemName"].ToString();
                newRow["Address"] = dtRECORD.Rows[0]["Address"].ToString();
                newRow["QuestionerFirstName"] = dtRECORD.Rows[0]["QuestionerFirstName"].ToString();
                newRow["QuestionerSecondName"] = dtRECORD.Rows[0]["QuestionerSecondName"].ToString();
                newRow["RecordsName"] = dtRECORD.Rows[0]["RecordsName"].ToString();
                newRow["TargetName"] = dtRECORD.Rows[0]["TargetName"].ToString();
                newRow["TargetAddress"] = dtRECORD.Rows[0]["TargetAddress"].ToString();
                newRow["TargetPaperNum"] = dtRECORD.Rows[0]["TargetPaperNum"].ToString();
                newRow["TargetGender"] = TargetGender;
                newRow["BirthDate"] = dtRECORD.Rows[0]["BirthDate"].ToString();
                newRow["TargetUnit"] = dtRECORD.Rows[0]["TargetUnit"].ToString();
                newRow["TargetDuty"] = dtRECORD.Rows[0]["TargetDuty"].ToString();
                newRow["TargetZipCode"] = dtRECORD.Rows[0]["TargetZipCode"].ToString();
                newRow["RecordInfo"] = dtRECORD.Rows[0]["RecordInfo"].ToString();

            }
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["TargetType"] = dtCASEINFO.Rows[0]["TargetType"].ToString();
                newRow["FirstUserId"] = dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString();
                newRow["SecondUserId"] = dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString();
            }
            newRow["StartDateYear"] = StartDateYear;
            newRow["StartDateMonth"] = StartDateMonth;
            newRow["StartDateDay"] = StartDateDay;
            newRow["StartDateHour"] = StartDateHour;
            newRow["StartDateMinute"] = StartDateMinute;
            newRow["EndDateYear"] = EndDateYear;
            newRow["EndDateMonth"] = EndDateMonth;
            newRow["EndDateDay"] = EndDateDay;
            newRow["EndDateHour"] = EndDateHour;
            newRow["EndDateMinute"] = EndDateMinute;
            newRow["FirstCode"] = dtBase_CertificateFirst.Rows[0]["CertificateNo"].ToString();
            newRow["SecondCode"] = dtBase_CertificateSecond.Rows[0]["CertificateNo"].ToString();
            newRow["UndertakerFirstSignName"] = dtCrmUserSignFirst.Rows[0]["SignAddress"].ToString();
            newRow["UndertakerSecondSignName"] = dtCrmUserSignSecond.Rows[0]["SignAddress"].ToString();
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 案件照片
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable CasePhoto(string resourceId)
        {
            DateTime ShootDate;
            string ShootTimeHour = string.Empty;
            string ShootTimeMinute = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("ItemName", typeof(string));
            dtAll.Columns.Add("ShootDate", typeof(string));
            dtAll.Columns.Add("ShootTimeHour", typeof(string));
            dtAll.Columns.Add("ShootTimeMinute", typeof(string));
            dtAll.Columns.Add("ShootAddress", typeof(string));
            dtAll.Columns.Add("ShootFist", typeof(string));
            dtAll.Columns.Add("ShootSecond", typeof(string));
            dtAll.Columns.Add("ImageAddress", typeof(string));
            #endregion

            var strINF_PUNISH_ATTACH = string.Format("select * from INF_PUNISH_ATTACH where ResourceId='{0}'", resourceId);
            DataTable dtINF_PUNISH_ATTACH = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strINF_PUNISH_ATTACH).Tables[0];
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where id='{0}'", dtINF_PUNISH_ATTACH.Rows[0]["ResourceId"].ToString());
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", dtINF_PUNISH_ATTACH.Rows[0]["ResourceId"].ToString());
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];
            #region 赋值判断
            if (!string.IsNullOrEmpty(dtINF_PUNISH_ATTACH.Rows[0]["ShootTime"].ToString()))
            {
                ShootDate = DateTime.Parse(dtINF_PUNISH_ATTACH.Rows[0]["ShootTime"].ToString());
            }
            else
            {
                ShootDate = DateTime.Parse(dtINF_PUNISH_ATTACH.Rows[0]["CreateOn"].ToString());
            }
            ShootTimeHour = ShootDate.Hour.ToString();
            ShootTimeMinute = ShootDate.Minute.ToString();
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["ItemName"] = dtLEGISLATION.Rows[0]["ItemName"];
            }
            newRow["ShootDate"] = ShootDate;
            newRow["ShootTimeHour"] = ShootTimeHour;
            newRow["ShootTimeMinute"] = ShootTimeMinute;
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["ShootAddress"] = dtCASEINFO.Rows[0]["CaseAddress"];
                newRow["ShootFist"] = dtCASEINFO.Rows[0]["RePersonelNameFist"];
                newRow["ShootSecond"] = dtCASEINFO.Rows[0]["RePersonelNameSecond"];
            }
            if (dtINF_PUNISH_ATTACH.Rows.Count > 0)
            {
                newRow["ImageAddress"] = dtINF_PUNISH_ATTACH.Rows[0]["FileAddress"];
            }
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 违停案件照片
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable CarPhoto(string resourceId)
        {
            DateTime ShootDate = DateTime.Now;//定义变量，获取当前时间
            string ShootTimeHour = string.Empty;
            string ShootTimeMinute = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("ItemName", typeof(string));
            dtAll.Columns.Add("ShootDate", typeof(string));
            dtAll.Columns.Add("ShootTimeHour", typeof(string));
            dtAll.Columns.Add("ShootTimeMinute", typeof(string));
            dtAll.Columns.Add("ShootAddress", typeof(string));
            dtAll.Columns.Add("ShootFist", typeof(string));
            dtAll.Columns.Add("ShootSecond", typeof(string));
            dtAll.Columns.Add("ImageAddress", typeof(string));
            #endregion

            var strATTACH = string.Format("select * from INF_PUNISH_ATTACH where Id='{0}'", resourceId);
            DataTable dtATTACH = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strATTACH).Tables[0];
            var strCHECKSIGN = string.Format("select * from INF_CAR_CHECKSIGN where id='{0}'", dtATTACH.Rows[0]["ResourceId"].ToString());
            DataTable dtCHECKSIGN = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCHECKSIGN).Tables[0];
            #region 赋值判断
            if (dtATTACH.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtATTACH.Rows[0]["ShootTime"].ToString()))
                {
                    ShootDate = DateTime.Parse(dtATTACH.Rows[0]["ShootTime"].ToString());
                }
                else
                {
                    ShootDate = DateTime.Parse(dtATTACH.Rows[0]["CreateOn"].ToString());
                }
                ShootTimeHour = ShootDate.Hour.ToString();
                ShootTimeMinute = ShootDate.Minute.ToString();
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["ItemName"] = "不按照规定在城市人行道上停放机动车";
            newRow["ShootDate"] = ShootDate;
            newRow["ShootTimeHour"] = ShootTimeHour;
            newRow["ShootTimeMinute"] = ShootTimeMinute;
            if (dtCHECKSIGN.Rows.Count > 0)
            {
                newRow["ShootAddress"] = dtCHECKSIGN.Rows[0]["CaseAddress"];
                newRow["ShootFist"] = dtCHECKSIGN.Rows[0]["RePersonelNameFist"];
                newRow["ShootSecond"] = dtCHECKSIGN.Rows[0]["RePersonelNameSecond"];
            }
            if (dtATTACH.Rows.Count > 0)
            {
                newRow["ImageAddress"] = dtATTACH.Rows[0]["FileAddress"];
            }
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 违章停车罚没款票据
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable CarBill(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseNo", typeof(string));		//决定书号
            dtAll.Columns.Add("Name", typeof(string));         //姓名	
            dtAll.Columns.Add("Address", typeof(string)); 		//当事人地址
            dtAll.Columns.Add("Phone", typeof(string)); 			//联系电话  
            dtAll.Columns.Add("CardN", typeof(string)); 			//证件号码
            dtAll.Columns.Add("PunishMoney", typeof(string)); 	//处罚金额
            dtAll.Columns.Add("NoMoney", typeof(string)); 		//没收金额 
            dtAll.Columns.Add("TotalMoney", typeof(string)); 	//总金额  
            dtAll.Columns.Add("TotalMoneyUp", typeof(string)); 	//总金额（大写）      
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Month", typeof(string));
            dtAll.Columns.Add("Day", typeof(string));
            dtAll.Columns.Add("PayeeSignName", typeof(string));//收款人,签字信息
            #endregion

            var strINF_CAR_CHECKSIGN = string.Format("select * from INF_CAR_CHECKSIGN where ID='{0}'", resourceId);
            var strINF_CAR_HANDLER = string.Format("select * from INF_CAR_HANDLER where HandType=511 and CheckSigniId='{0}'", resourceId);
            DataTable dtCHECKSIGN = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strINF_CAR_CHECKSIGN).Tables[0];
            DataTable dtHANDLER = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strINF_CAR_HANDLER).Tables[0];
            var strCrmUserSign = string.Format("select * from CrmUserSign where SignType='00310001' and UserId='{0}'", dtHANDLER.Rows[0]["CreatorId"].ToString());
            DataTable dtCrmUserSign = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSign).Tables[0];

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtCHECKSIGN.Rows.Count > 0)
            {
                newRow["CaseNo"] = dtCHECKSIGN.Rows[0]["CfapproveNo"].ToString();
                newRow["Name"] = dtCHECKSIGN.Rows[0]["Name"].ToString();
                newRow["Address"] = dtCHECKSIGN.Rows[0]["Address"].ToString();
                newRow["Phone"] = dtCHECKSIGN.Rows[0]["Telephone"].ToString();
                newRow["CardN"] = dtCHECKSIGN.Rows[0]["PersonNo"].ToString();
            }
            newRow["PunishMoney"] = "¥50";
            newRow["NoMoney"] = "";
            newRow["TotalMoney"] = "¥50";
            newRow["TotalMoneyUp"] = "伍拾元整";
            newRow["Year"] = DateTime.Now.Year.ToString();
            newRow["Month"] = DateTime.Now.Month.ToString();
            newRow["Day"] = DateTime.Now.Day.ToString();
            newRow["PayeeSignName"] = dtCrmUserSign.Rows[0]["SignAddress"].ToString();//收款人
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 一般案件罚没款票据
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable CaseBill(string resourceId)
        {
            string Name = string.Empty;
            string CaseNo = string.Empty;
            string CreatorId = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseNo", typeof(string));		//决定书号
            dtAll.Columns.Add("Name", typeof(string));         //姓名	
            dtAll.Columns.Add("Address", typeof(string)); 		//当事人地址
            dtAll.Columns.Add("Phone", typeof(string)); 			//联系电话  
            dtAll.Columns.Add("CardN", typeof(string)); 			//证件号码
            dtAll.Columns.Add("PunishMoney", typeof(string)); 	//处罚金额
            dtAll.Columns.Add("NoMoney", typeof(string)); 		//没收金额 
            dtAll.Columns.Add("TotalMoney", typeof(string)); 	//总金额  
            dtAll.Columns.Add("TotalMoneyUp", typeof(string)); 	//总金额（大写）      
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Month", typeof(string));
            dtAll.Columns.Add("Day", typeof(string));
            dtAll.Columns.Add("PayeeSignName", typeof(string));//收款人签名
            #endregion

            var strINF_CAR_CHECKSIGN = string.Format("select * from INF_CAR_CHECKSIGN where ID='{0}'", resourceId);

            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where ID='{0}'", resourceId);
            var strLEGISLATION = string.Format("select * FROM INF_PUNISH_LEGISLATION WHERE RowStatus=1 AND CaseInfoId='{0}'", resourceId);
            var strINF_PUNISH_DECISION = string.Format("select * from INF_PUNISH_DECISION where CASEINFOID='{0}'", resourceId);
            var strINF_CAR_HANDLER = string.Format("select * from INF_CAR_HANDLER where HandType=511 and CheckSigniId='{0}'", resourceId);
            DataTable dtCHECKSIGN = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strINF_CAR_CHECKSIGN).Tables[0];
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];
            DataTable dtHANDLER = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strINF_CAR_HANDLER).Tables[0];
            if (dtHANDLER.Rows.Count > 0)
            {
                CreatorId = dtHANDLER.Rows[0]["CreatorId"].ToString();
            }
            var strCrmUserSign = string.Format("select * from CrmUserSign where SignType='00310001' and UserId='{0}'", CreatorId);
            DataTable dtCrmUserSign = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSign).Tables[0];
            #region
            //当事人为公民
            if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120001")
            {
                Name = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
            }
            else
            {
                Name = dtCASEINFO.Rows[0]["TargetName"].ToString();
            }
            //编号赋值
            if (dtCASEINFO.Rows[0]["PunishProcess"].ToString() == "00280001")
            {
                CaseNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();
            }
            else
            {
                string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
                if (dtCASEINFO.Rows[0]["CompanyName"].ToString() == "唯亭街道综合执法大队")
                {
                    CaseNo = "苏园城法罚决字[" + _listCaseInfoNo[0] + "]第" + _listCaseInfoNo[1].Substring(0, 7) + "号";
                }
                else
                {
                    CaseNo = "苏园城法罚决字[" + _listCaseInfoNo[0] + "]第" + _listCaseInfoNo[1].Substring(0, 5) + "号";
                }
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["CaseNo"] = CaseNo;
            newRow["Name"] = Name;
            if (dtCHECKSIGN.Rows.Count > 0)
            {
                newRow["Address"] = dtCHECKSIGN.Rows[0]["Address"].ToString();
                newRow["Phone"] = dtCHECKSIGN.Rows[0]["Telephone"].ToString();
                newRow["CardN"] = dtCHECKSIGN.Rows[0]["PersonNo"].ToString();
            }
            newRow["NoMoney"] = "";
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["PunishMoney"] = dtLEGISLATION.Rows[0]["PunishAmount"].ToString();
                newRow["TotalMoney"] = dtLEGISLATION.Rows[0]["PunishAmount"].ToString();
                newRow["TotalMoneyUp"] = dtLEGISLATION.Rows[0]["PunishAmount"].ToString();
            }
            newRow["Year"] = DateTime.Now.Year.ToString();
            newRow["Month"] = DateTime.Now.Month.ToString();
            newRow["Day"] = DateTime.Now.Day.ToString();
            newRow["PayeeSignName"] = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 卷宗
        /// </summary>
        /// <param name="resourceId">案件编号</param>
        /// <returns></returns>
        public DataTable Dossier(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            string Name = string.Empty;
            string GDNO = string.Empty;//归档号
            string CaseDate = string.Empty;//立案时间
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string)); 		 	//执法告字（年）
            dtAll.Columns.Add("Num", typeof(string)); 			//执法告字（号）	
            dtAll.Columns.Add("ItemName", typeof(string));  		//案由名称
            dtAll.Columns.Add("AcceptTime", typeof(string));     //受案时间
            dtAll.Columns.Add("CaseDate", typeof(string));       //立案日期
            dtAll.Columns.Add("EndCaseDate", typeof(string));    //结案日期
            dtAll.Columns.Add("Name", typeof(string));            //姓名	
            dtAll.Columns.Add("DealInfo", typeof(string));       //处理情况
            dtAll.Columns.Add("PersonName", typeof(string));    //办案人员
            dtAll.Columns.Add("PersonName2", typeof(string));    //办案人员2
            dtAll.Columns.Add("NoteName", typeof(string));      //记录人员
            dtAll.Columns.Add("GDTime", typeof(string));        //归档时间
            dtAll.Columns.Add("GDNO", typeof(string));           //归档号　
            #endregion

            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where id='{0}'", resourceId);
            var strRECORD = string.Format("select * from INF_PUNISH_RECORD where CaseInfoId='{0}'", resourceId);
            var strINF_PUNISH_FINISH = string.Format("select * from INF_PUNISH_FINISH where CaseInfoId='{0}'", resourceId);//结案时间
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strRECORD).Tables[0];
            DataTable dtRECORD = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            DataTable dtFINISH = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strINF_PUNISH_FINISH).Tables[0];

            #region 立案时间获取
            var strWF_Process = string.Format("select * from WF_Process where FullName='立案审批'");
            DataTable dtWF_Process = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strINF_PUNISH_FINISH).Tables[0];
            var strCrmIdeaList = string.Format(@"select Duty,[Type],Idea,CreateOn from CrmIdeaList where Type='0'and ProcessId='{0}' and ResourceID='{1}' 
                                    group by Duty,[Type] ,Idea,CreateOn order by CreateOn ", dtWF_Process.Rows[0]["Id"].ToString(), resourceId);
            DataTable dtCrmIdeaList = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmIdeaList).Tables[0];
            if (dtCrmIdeaList.Rows.Count > 0)
            {
                for (int i = 0; i < dtCrmIdeaList.Rows.Count; i++)
                {
                    if (i == 1)
                    {
                        CaseDate = dtCrmIdeaList.Rows[0]["CreateOn"].ToString();
                    }
                }
            }
            #endregion

            #region 变量判断
            if (dtCASEINFO.Rows.Count > 0)
            {
                string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
                Year = _listCaseInfoNo[0];
                if (dtCASEINFO.Rows[0]["CompanyName"].ToString() == "唯亭街道综合执法大队")
                {
                    Num = _listCaseInfoNo[1].Substring(0, 7);
                }
                else
                {
                    Num = _listCaseInfoNo[1].Substring(0, 5);
                }
                //归档号赋值
                if (!string.IsNullOrEmpty(Year) && !string.IsNullOrEmpty(Num))
                {
                    GDNO = Year + Num;
                }
                //当事人为公民
                if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120001")
                {
                    Name = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
                }
                else
                {
                    Name = dtCASEINFO.Rows[0]["TargetName"].ToString();
                }
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            if (dtRECORD.Rows.Count > 0)
            {
                newRow["ItemName"] = dtRECORD.Rows[0]["ItemName"].ToString();
            }
            newRow["CaseDate"] = CaseDate;
            if (dtFINISH.Rows.Count > 0)
            {
                newRow["EndCaseDate"] = dtFINISH.Rows[0]["FinishDate"].ToString();
                newRow["DealInfo"] = dtFINISH.Rows[0]["PunishContent"].ToString();
            }
            newRow["Name"] = Name;
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["AcceptTime"] = dtCASEINFO.Rows[0]["CASEDATE"].ToString();
                newRow["PersonName"] = dtCASEINFO.Rows[0]["RePersonelNameFist"].ToString();
                newRow["PersonName2"] = dtCASEINFO.Rows[0]["RePersonelNameSecond"].ToString();
                newRow["NoteName"] = dtCASEINFO.Rows[0]["RePersonelNameSecond"].ToString();
                newRow["GDTime"] = dtCASEINFO.Rows[0]["GDDate"].ToString();
            }
            newRow["GDNO"] = GDNO;
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 请假单
        /// </summary>
        /// <param name="resourceId">案件编号</param>
        /// <returns></returns>
        public DataTable Leave(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("UserName", typeof(string));
            dtAll.Columns.Add("DeptName", typeof(string));
            dtAll.Columns.Add("StartTime", typeof(string));
            dtAll.Columns.Add("EndTime", typeof(string));
            dtAll.Columns.Add("LeaveType", typeof(string));
            dtAll.Columns.Add("Day", typeof(string));
            dtAll.Columns.Add("Reason", typeof(string));
            dtAll.Columns.Add("Remark", typeof(string));
            #endregion

            var strAttendanceLeave = string.Format("select * from AttendanceLeave where Id='{0}'", resourceId);
            DataTable dtAttendanceLeave = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strAttendanceLeave).Tables[0];

            #region 添加数据
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtAttendanceLeave.Rows.Count > 0)
            {
                newRow["UserName"] = dtAttendanceLeave.Rows[0]["UserName"].ToString();
                newRow["DeptName"] = dtAttendanceLeave.Rows[0]["DeptName"].ToString();
                newRow["StartTime"] = dtAttendanceLeave.Rows[0]["BeginTime"].ToString();
                newRow["EndTime"] = dtAttendanceLeave.Rows[0]["EndTime"].ToString();
                newRow["LeaveType"] = dtAttendanceLeave.Rows[0]["LeaveTypeName"].ToString();
                newRow["Day"] = dtAttendanceLeave.Rows[0]["LeaveTime"].ToString();
                newRow["Reason"] = dtAttendanceLeave.Rows[0]["LeaveReason"].ToString();
                newRow["Remark"] = dtAttendanceLeave.Rows[0]["Remark"].ToString();
            }
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 责令改正通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LegislationGist(string resourceId)
        {
            string Name = string.Empty;
            string CaseInfoNo = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseInfoNo1", typeof(string));        //通知书编号1
            dtAll.Columns.Add("CaseInfoNo2", typeof(string));        //通知书编号2
            dtAll.Columns.Add("TargetName1", typeof(string));  		//当事人1
            dtAll.Columns.Add("TargetName2", typeof(string));  		//当事人2	

            dtAll.Columns.Add("CaseYear1", typeof(string));        //案发时间年1
            dtAll.Columns.Add("CaseYear2", typeof(string));        //案发时间年2
            dtAll.Columns.Add("CaseMonth1", typeof(string));       //案发时间月1
            dtAll.Columns.Add("CaseMonth2", typeof(string));       //案发时间月2
            dtAll.Columns.Add("CaseDay1", typeof(string));         //案发时间日1
            dtAll.Columns.Add("CaseDay2", typeof(string));         //案发时间日2

            dtAll.Columns.Add("CaseAddress1", typeof(string));     //案发地点1
            dtAll.Columns.Add("CaseAddress2", typeof(string));     //案发地点2
            dtAll.Columns.Add("FileFact1", typeof(string));  		 //违法行为1
            dtAll.Columns.Add("FileFact2", typeof(string));  		 //违法行为2

            dtAll.Columns.Add("GistName1", typeof(string));  	    //违反法规
            dtAll.Columns.Add("GistStrip1", typeof(string));  		//违反法规条
            dtAll.Columns.Add("GistClause1", typeof(string));  		//违反法规款
            dtAll.Columns.Add("GistItem1", typeof(string));  	    //违反法规项

            dtAll.Columns.Add("GistName2", typeof(string));  		//违反法规
            dtAll.Columns.Add("GistStrip2", typeof(string)); 		//违反法规条
            dtAll.Columns.Add("GistClause2", typeof(string));  		//违反法规款
            dtAll.Columns.Add("GistItem2", typeof(string));     	//违反法规项

            dtAll.Columns.Add("UndertakerIdFirst", typeof(string));   	//承办人（一）编号
            dtAll.Columns.Add("UndertakerIdSecond", typeof(string)); 	//承办人（二）编号

            dtAll.Columns.Add("UndertakerFirstSignName", typeof(string));  	//承办人（一）签名
            dtAll.Columns.Add("UndertakerSecondSignName", typeof(string));	//承办人（二）签名

            #endregion

            //案件信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            //部门
            var strCrmDepartment = string.Format("select * from CrmDepartment where id='{0}'", dtCASEINFO.Rows[0]["DeptId"].ToString());
            DataTable dtCrmDepartment = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmDepartment).Tables[0];
            //案由
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where RowStatus=1 and CaseInfoId='{0}'", resourceId);
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];

            var strLegislationGist = string.Format("select * from LegislationGist where RowStatus=1 and Id='{0}'", dtLEGISLATION.Rows[0]["LegislationGistId"].ToString());
            DataTable dtLegislationGist = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLegislationGist).Tables[0];

            //承办人签字
            var strCrmUserSignFirst = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strCrmUserSignSecond = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());

            DataTable dtCrmUserSignFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignFirst).Tables[0];
            DataTable dtCrmUserSignSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignSecond).Tables[0];

            #region 变量赋值
            //当事人为公民
            if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120001")
            {
                Name = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
            }
            else
            {
                Name = dtCASEINFO.Rows[0]["TargetName"].ToString();
            }
            if (!string.IsNullOrEmpty(dtCASEINFO.Rows[0]["CaseInfoNo"].ToString()))
            {
                CaseInfoNo = "苏吴城法改字〔" + dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Substring(3, 4) + "〕第 " + dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Substring(8, 5) + " 号";
            }
            #endregion

            #region 列 赋值
            if (dtCrmDepartment != null && dtCrmDepartment.Rows.Count > 0)
            {
                DataRow newRow;
                newRow = dtAll.NewRow();
                newRow["CaseInfoNo1"] = CaseInfoNo;         //通知书编号1
                newRow["CaseInfoNo2"] = CaseInfoNo;         //通知书编号2
                newRow["TargetName1"] = Name;   		//当事人1
                newRow["TargetName2"] = Name;   		//当事人2	

                newRow["CaseYear1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Year.ToString().Trim();         //案发时间年1
                newRow["CaseYear2"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Year.ToString().Trim();          //案发时间年2
                newRow["CaseMonth1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Month.ToString().Trim();        //案发时间月1
                newRow["CaseMonth2"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Month.ToString().Trim();        //案发时间月2
                newRow["CaseDay1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Day.ToString().Trim();          //案发时间日1
                newRow["CaseDay2"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Day.ToString().Trim();          //案发时间日2

                newRow["CaseAddress1"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();      //案发地点1
                newRow["CaseAddress2"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();      //案发地点2
                newRow["FileFact1"] = dtCASEINFO.Rows[0]["ItemName"].ToString();    		 //违法行为1
                newRow["FileFact2"] = dtCASEINFO.Rows[0]["ItemName"].ToString();    		 //违法行为2

                newRow["GistName1"] = dtLegislationGist.Rows[0]["ItemName"].ToString();    	    //违反法规
                newRow["GistStrip1"] = dtLegislationGist.Rows[0]["GistStrip"].ToString();    		//违反法规条
                newRow["GistClause1"] = dtLegislationGist.Rows[0]["GistClause"].ToString();    		//违反法规款
                newRow["GistItem1"] = dtLegislationGist.Rows[0]["GistItem"].ToString();    	    //违反法规项

                newRow["GistName2"] = dtLegislationGist.Rows[0]["ItemName"].ToString();   		//违反法规
                newRow["GistStrip2"] = dtLegislationGist.Rows[0]["GistStrip"].ToString();  		//违反法规条
                newRow["GistClause2"] = dtLegislationGist.Rows[0]["GistClause"].ToString();   		//违反法规款
                newRow["GistItem2"] = dtLegislationGist.Rows[0]["GistItem"].ToString();        	    //违反法规项

                newRow["UndertakerIdFirst"] = dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString();    //承办人（一）编号
                newRow["UndertakerIdSecond"] = dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString();  //承办人（二）编号
                newRow["UndertakerFirstSignName"] = dtCrmUserSignFirst.Rows[0]["SignAddress"].ToString();       //承办人（一）签名
                newRow["UndertakerSecondSignName"] = dtCrmUserSignSecond.Rows[0]["SignAddress"].ToString();     //承办人（二）签名
                dtAll.Rows.Add(newRow);
            }
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 一般案件全部
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable PunishAll(string resourceId)
        {
            //获取随机数
            Random ran = new Random();
            Double i = ran.Next(10, 15);
            Double Result = Math.Round(((15 - 10 - 1) * i), 0);
            string Name = string.Empty;
            string ZGCaseInfoNo1 = string.Empty;
            string TargetUnit = string.Empty;
            string UnitLeader = string.Empty;
            string TargetZDM = string.Empty;
            string TargetDuty = string.Empty;
            string UnitAddress = string.Empty;
            string TargetMobile = string.Empty;
            string TargetName3 = string.Empty;
            string TargetGender = string.Empty;
            string TargetAge = string.Empty;
            string TargetAddress = string.Empty;
            string targetPaperNumber = string.Empty;
            string TargetPhone = string.Empty;

            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseInfoNo1", typeof(string));       //通知书编号1
            dtAll.Columns.Add("CaseInfoNo2", typeof(string));       //通知书编号2
            dtAll.Columns.Add("CaseInfoNo3", typeof(string));       //通知书编号3
            dtAll.Columns.Add("TargetName1", typeof(string)); 		//当事人1
            dtAll.Columns.Add("TargetName2", typeof(string)); 		//当事人2
            dtAll.Columns.Add("TargetName3", typeof(string)); 		//当事人3
            dtAll.Columns.Add("TargetName4", typeof(string)); 		//当事人4   

            dtAll.Columns.Add("TargetUnit", typeof(string));    //单位地址
            dtAll.Columns.Add("UnitLeader", typeof(string)); 	//负责人姓名
            dtAll.Columns.Add("TargetZDM", typeof(string));      //组织机构代码证
            dtAll.Columns.Add("TargetDuty", typeof(string)); 	//职务
            dtAll.Columns.Add("UnitAddress", typeof(string));   //单位地址
            dtAll.Columns.Add("TargetMobile", typeof(string));   //联系电话

            dtAll.Columns.Add("TargetAddress", typeof(string));  		//当事人地址
            dtAll.Columns.Add("TargetPhone", typeof(string));   		//当事人手机（联系电话）	
            dtAll.Columns.Add("targetPaperNumber", typeof(string)); 		//当事身份证号	    
            dtAll.Columns.Add("TargetGender", typeof(string)); 		//性别
            dtAll.Columns.Add("TargetAge", typeof(string));     //年龄

            dtAll.Columns.Add("CaseYear1", typeof(string));       //案发时间年1
            dtAll.Columns.Add("CaseYear2", typeof(string));       //案发时间年2
            dtAll.Columns.Add("CaseYear3", typeof(string));       //案发时间年3
            dtAll.Columns.Add("CaseMonth1", typeof(string));      //案发时间月1
            dtAll.Columns.Add("CaseMonth2", typeof(string));      //案发时间月2
            dtAll.Columns.Add("CaseMonth3", typeof(string));      //案发时间月3
            dtAll.Columns.Add("CaseDay1", typeof(string));        //案发时间日1
            dtAll.Columns.Add("CaseDay2", typeof(string));        //案发时间日2
            dtAll.Columns.Add("CaseDay3", typeof(string));        //案发时间日3

            dtAll.Columns.Add("CaseHourS", typeof(string));        //案发时间(起)小时
            dtAll.Columns.Add("CaseMinS", typeof(string));        //案发时间(起)分钟

            dtAll.Columns.Add("CaseHourE", typeof(string));        //案发时间(起)小时
            dtAll.Columns.Add("CaseMinE", typeof(string));        //案发时间(起)分钟
            dtAll.Columns.Add("CaseAddress1", typeof(string));    //案发地点1
            dtAll.Columns.Add("CaseAddress2", typeof(string));    //案发地点2
            dtAll.Columns.Add("CaseAddress3", typeof(string));       //案发地点3
            dtAll.Columns.Add("CaseAddress4", typeof(string));       //案发地点4

            dtAll.Columns.Add("FileFact1", typeof(string)); 		 //违法行为1
            dtAll.Columns.Add("FileFact2", typeof(string)); 		 //违法行为2

            dtAll.Columns.Add("HYear1", typeof(string));       //处理时间年1
            dtAll.Columns.Add("HYear2", typeof(string));       //处理时间年2
            dtAll.Columns.Add("HMonth1", typeof(string));      //处理时间月1
            dtAll.Columns.Add("HMonth2", typeof(string));      //处理时间月2
            dtAll.Columns.Add("HDay1", typeof(string));        //处理时间日1
            dtAll.Columns.Add("HDay2", typeof(string));        //处理时间日2
            dtAll.Columns.Add("DeptName1", typeof(string)); 	 //执法部门名称1
            dtAll.Columns.Add("DeptName2", typeof(string)); 	 //执法部门名称2
            dtAll.Columns.Add("DeptAddress1", typeof(string)); 	 //执法部门地点1
            dtAll.Columns.Add("DeptAddress2", typeof(string)); 	 //执法部门地点2
            dtAll.Columns.Add("DeptPhone1", typeof(string)); 	 //执法部门电话1
            dtAll.Columns.Add("DeptPhone2", typeof(string)); 	 //执法部门电话2    
            dtAll.Columns.Add("CheckPerson", typeof(string)); 	 //检查人员
            dtAll.Columns.Add("Person", typeof(string)); 	 //记录人员    

            dtAll.Columns.Add("SendType", typeof(string));  //送达方式
            dtAll.Columns.Add("FileFact3", typeof(string));   //事由
            dtAll.Columns.Add("License", typeof(string));  //营业执照  

            dtAll.Columns.Add("RecordInfo", typeof(string));  //现场检查笔录内容
            dtAll.Columns.Add("DrawDate", typeof(string));      //绘制时间
            dtAll.Columns.Add("DrawPerson", typeof(string));    //绘制人
            dtAll.Columns.Add("Reference1", typeof(string));   //参照物1
            dtAll.Columns.Add("Reference2", typeof(string));    //参照物2	
            dtAll.Columns.Add("FileFact4", typeof(string));   //事由	
            /***********************************责令整改文书返回值**********************************/

            dtAll.Columns.Add("ZGCaseInfoNo1", typeof(string));       //通知书编号1
            dtAll.Columns.Add("ZGCaseInfoNo2", typeof(string));       //通知书编号2
            dtAll.Columns.Add("ZGTargetName1", typeof(string)); 		//当事人1
            dtAll.Columns.Add("ZGTargetName2", typeof(string)); 		//当事人2
            dtAll.Columns.Add("ZGCaseYear1", typeof(string));       //案发时间年1
            dtAll.Columns.Add("ZGCaseYear2", typeof(string));       //案发时间年2
            dtAll.Columns.Add("ZGCaseMonth1", typeof(string));      //案发时间月1
            dtAll.Columns.Add("ZGCaseMonth2", typeof(string));      //案发时间月2
            dtAll.Columns.Add("ZGCaseDay1", typeof(string));        //案发时间日1
            dtAll.Columns.Add("ZGCaseDay2", typeof(string));        //案发时间日2
            dtAll.Columns.Add("ZGCaseAddress1", typeof(string));    //案发地点1
            dtAll.Columns.Add("ZGCaseAddress2", typeof(string));    //案发地点2
            dtAll.Columns.Add("ZGFileFact1", typeof(string)); 		 //违法行为1
            dtAll.Columns.Add("ZGFileFact2", typeof(string)); 		 //违法行为2

            dtAll.Columns.Add("GistName1", typeof(string)); 	    //违反法规
            dtAll.Columns.Add("GistStrip1", typeof(string)); 		//违反法规条
            dtAll.Columns.Add("GistClause1", typeof(string)); 		//违反法规款
            dtAll.Columns.Add("GistItem1", typeof(string)); 	    //违反法规项

            dtAll.Columns.Add("GistName2", typeof(string)); 		//违反法规
            dtAll.Columns.Add("GistStrip2", typeof(string)); 		//违反法规条
            dtAll.Columns.Add("GistClause2", typeof(string)); 		//违反法规款

            #endregion

            //案件信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            //部门
            var strCrmDepartment = string.Format("select * from CrmDepartment where id='{0}'", dtCASEINFO.Rows[0]["DeptId"].ToString());
            DataTable dtCrmDepartment = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmDepartment).Tables[0];
            //案由
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where RowStatus=1 and CaseInfoId='{0}'", resourceId);
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];

            var strLegislationGist = string.Format("select * from LegislationGist where RowStatus=1 and Id='{0}'", dtLEGISLATION.Rows[0]["LegislationGistId"].ToString());
            DataTable dtLegislationGist = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLegislationGist).Tables[0];

            //承办人签字
            var strCrmUserSignFirst = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strCrmUserSignSecond = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());

            DataTable dtCrmUserSignFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignFirst).Tables[0];
            DataTable dtCrmUserSignSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignSecond).Tables[0];

            #region 变量赋值
            if (dtCASEINFO.Rows.Count > 0)
            {
                //当事人为公民
                if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120001") //自然人
                {
                    Name = dtCASEINFO.Rows[0]["TargetName"].ToString();
                    UnitLeader = "";
                    TargetUnit = "";
                    UnitLeader = "";
                    TargetZDM = "";
                    TargetDuty = "";
                    UnitAddress = "";
                    TargetMobile = "";
                    TargetName3 = dtCASEINFO.Rows[0]["TargetName3"].ToString();
                    if (dtCASEINFO.Rows[0]["TargetGender"].ToString() == "1")
                    {
                        TargetGender = "男";
                    }
                    else
                    {
                        TargetGender = "女";
                    }
                    TargetAge = dtCASEINFO.Rows[0]["TargetAge"].ToString();
                    TargetAddress = dtCASEINFO.Rows[0]["TargetAddress"].ToString();
                    targetPaperNumber = dtCASEINFO.Rows[0]["targetPaperNumber"].ToString();
                    TargetPhone = dtCASEINFO.Rows[0]["TargetPhone"].ToString();
                }
                else if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120002") //法人
                {
                    Name = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
                    UnitLeader = dtCASEINFO.Rows[0]["TargetName"].ToString();
                    TargetUnit = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
                    TargetZDM = dtCASEINFO.Rows[0]["TargetZDM"].ToString();
                    TargetDuty = dtCASEINFO.Rows[0]["TargetDuty"].ToString();
                    UnitAddress = dtCASEINFO.Rows[0]["UnitAddress"].ToString();
                    TargetMobile = dtCASEINFO.Rows[0]["TargetMobile"].ToString();
                    TargetName3 = "";
                    TargetGender = "";
                    TargetAge = "";
                    TargetAddress = "";
                    targetPaperNumber = "";
                    TargetPhone = "";
                }
                if (!string.IsNullOrEmpty(dtCASEINFO.Rows[0]["CaseInfoNo"].ToString()))
                {
                    ZGCaseInfoNo1 = "苏吴城法改字〔" + dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Substring(3, 4) + "〕第 " + dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Substring(8, 5) + " 号";
                }
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["CaseInfoNo1"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();        //通知书编号1
                newRow["CaseInfoNo2"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();        //通知书编号2
                newRow["CaseInfoNo3"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();        //通知书编号3
                newRow["TargetName1"] = Name;  		//当事人1
                newRow["TargetName2"] = Name;  		//当事人2
                newRow["TargetName3"] = Name;  		//当事人3
                newRow["TargetName4"] = Name;  		//当事人4   

                newRow["TargetUnit"] = dtCASEINFO.Rows[0]["TargetUnit"].ToString();     //单位地址
                newRow["UnitLeader"] = UnitLeader;  	//负责人姓名
                newRow["TargetZDM"] = TargetZDM;       //组织机构代码证
                newRow["TargetDuty"] = TargetDuty;  	//职务
                newRow["UnitAddress"] = UnitAddress;    //单位地址
                newRow["TargetMobile"] = TargetMobile;    //联系电话

                newRow["TargetAddress"] = TargetAddress;   		//当事人地址
                newRow["TargetPhone"] = TargetPhone;    		//当事人手机（联系电话）	
                newRow["targetPaperNumber"] = targetPaperNumber;  		//当事身份证号	    
                newRow["TargetGender"] = TargetGender;  		//性别
                newRow["TargetAge"] = TargetAge;      //年龄

                newRow["CaseYear1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Year.ToString().Trim();        //案发时间年1
                newRow["CaseYear2"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Year.ToString().Trim();         //案发时间年2
                newRow["CaseYear3"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Year.ToString().Trim();         //案发时间年3
                newRow["CaseMonth1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Month.ToString().Trim();        //案发时间月1
                newRow["CaseMonth2"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Month.ToString().Trim();        //案发时间月2
                newRow["CaseMonth3"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Month.ToString().Trim();        //案发时间月3
                newRow["CaseDay1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Day.ToString().Trim();          //案发时间日1
                newRow["CaseDay2"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Day.ToString().Trim();          //案发时间日2
                newRow["CaseDay3"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Day.ToString().Trim();          //案发时间日3
                newRow["CaseHourS"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Hour.ToString().Trim();        //案发时间(起)小时
                newRow["CaseMinS"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Minute.ToString().Trim();         //案发时间(起)分钟
                newRow["CaseHourE"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Hour.ToString().Trim();         //案发时间(起)小时
                newRow["CaseMinE"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).AddHours(Result).ToString().Trim();          //案发时间(起)分钟    
                newRow["CaseAddress1"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();     //案发地点1
                newRow["CaseAddress2"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();     //案发地点2
                newRow["CaseAddress3"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();        //案发地点3
                newRow["CaseAddress4"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();        //案发地点4


                newRow["HYear1"] = DateTime.Parse(dtCASEINFO.Rows[0]["AcceptInvestigationDate"].ToString()).Year.ToString().Trim();        //处理时间年1
                newRow["HYear2"] = DateTime.Parse(dtCASEINFO.Rows[0]["AcceptInvestigationDate"].ToString()).Year.ToString().Trim();        //处理时间年2
                newRow["HMonth1"] = DateTime.Parse(dtCASEINFO.Rows[0]["AcceptInvestigationDate"].ToString()).Month.ToString().Trim();       //处理时间月1
                newRow["HMonth2"] = DateTime.Parse(dtCASEINFO.Rows[0]["AcceptInvestigationDate"].ToString()).Month.ToString().Trim();       //处理时间月2
                newRow["HDay1"] = DateTime.Parse(dtCASEINFO.Rows[0]["AcceptInvestigationDate"].ToString()).Day.ToString().Trim();        //处理时间日1
                newRow["HDay2"] = DateTime.Parse(dtCASEINFO.Rows[0]["AcceptInvestigationDate"].ToString()).Day.ToString().Trim();         //处理时间日2
                newRow["DeptName1"] = "吴中东路145号案件审理室";  	 //执法部门名称1
                newRow["DeptName2"] = "吴中东路145号案件审理室";  	 //执法部门名称2
                newRow["DeptAddress1"] = "";  	 //执法部门地点1
                newRow["DeptAddress2"] = "";  	 //执法部门地点2
                newRow["DeptPhone1"] = "";  	 //执法部门电话1
                newRow["DeptPhone2"] = "";  	 //执法部门电话2    
                newRow["CheckPerson"] = dtCASEINFO.Rows[0]["RePersonelNameFist"].ToString() + "、" + dtCASEINFO.Rows[0]["RePersonelNameSecond"].ToString();  	 //检查人员
                newRow["Person"] = dtCASEINFO.Rows[0]["RePersonelNameFist"].ToString();  	 //记录人员    


                newRow["SendType"] = "";   //送达方式
                newRow["License"] = "";   //营业执照  
                newRow["RecordInfo"] = "";   //现场检查笔录内容
                newRow["DrawDate"] = "";       //绘制时间
                newRow["DrawPerson"] = "";     //绘制人
                newRow["Reference1"] = "";    //参照物1
                newRow["Reference2"] = "";     //参照物2	
                /***********************************责令整改文书返回值**********************************/

                newRow["ZGCaseInfoNo1"] = ZGCaseInfoNo1;        //通知书编号1
                newRow["ZGCaseInfoNo2"] = ZGCaseInfoNo1;        //通知书编号2
                newRow["ZGTargetName1"] = Name;  		//当事人1
                newRow["ZGTargetName2"] = Name;  		//当事人2
                newRow["ZGCaseYear1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Year.ToString().Trim();        //案发时间年1
                newRow["ZGCaseYear2"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Year.ToString().Trim();        //案发时间年2
                newRow["ZGCaseMonth1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Month.ToString().Trim();       //案发时间月1
                newRow["ZGCaseMonth2"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Month.ToString().Trim();       //案发时间月2
                newRow["ZGCaseDay1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Day.ToString().Trim();         //案发时间日1
                newRow["ZGCaseDay2"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Day.ToString().Trim();         //案发时间日2
                newRow["ZGCaseAddress1"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();     //案发地点1
                newRow["ZGCaseAddress2"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();     //案发地点2
            }
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["FileFact1"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();  		 //违法行为1
                newRow["FileFact2"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();  		 //违法行为2
                newRow["FileFact3"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();    //事由
                newRow["FileFact4"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();    //事由	

                newRow["ZGFileFact1"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();  		 //违法行为1
                newRow["ZGFileFact2"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();  		 //违法行为2

                newRow["GistName1"] = dtLEGISLATION.Rows[0]["GistName"].ToString();  	    //违反法规
                newRow["GistStrip1"] = dtLEGISLATION.Rows[0]["GistStrip"].ToString();  		//违反法规条
                newRow["GistClause1"] = dtLEGISLATION.Rows[0]["GistClause"].ToString();  		//违反法规款
                newRow["GistItem1"] = dtLEGISLATION.Rows[0]["GistItem"].ToString();  	    //违反法规项

                newRow["GistName2"] = dtLEGISLATION.Rows[0]["GistName"].ToString();  		//违反法规
                newRow["GistStrip2"] = dtLEGISLATION.Rows[0]["GistStrip"].ToString();  		//违反法规条
                newRow["GistClause2"] = dtLEGISLATION.Rows[0]["GistClause"].ToString();  		//违反法规款
            }
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 地址确认书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable DZQRS(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("UndertakerFirstSignName", typeof(string));//承办人（一）签名
            dtAll.Columns.Add("UndertakerSecondSignName", typeof(string));//承办人（二）签名
            #endregion
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            //承办人签字
            var strCrmUserSignFirst = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strCrmUserSignSecond = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());

            DataTable dtCrmUserSignFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignFirst).Tables[0];
            DataTable dtCrmUserSignSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignSecond).Tables[0];
            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["UndertakerIdFirst"] = dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString();
            newRow["UndertakerIdSecond"] = dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString();
            newRow["UndertakerFirstSignName"] = dtCrmUserSignFirst.Rows[0]["SignAddress"].ToString();
            newRow["UndertakerSecondSignName"] = dtCrmUserSignSecond.Rows[0]["SignAddress"].ToString();
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 责令停止违反城市管理行为通知书  
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable Notice(string resourceId)
        {
            //获取随机数
            Random ran = new Random();
            Double i = ran.Next(10, 15);
            Double Result = Math.Round(((15 - 10 - 1) * i), 0);
            string Name = string.Empty;
            string TargetName = string.Empty;
            DataTable dtAll = new DataTable();

            #region 添加 列
            dtAll.Columns.Add("CaseInfoNo1", typeof(string));       //通知书编号1
            dtAll.Columns.Add("CaseInfoNo2", typeof(string));       //通知书编号2
            dtAll.Columns.Add("TargetName1", typeof(string)); 		//当事人1
            dtAll.Columns.Add("TargetName2", typeof(string)); 		//当事人2
            dtAll.Columns.Add("TargetAddress", typeof(string));  		//当事人地址
            dtAll.Columns.Add("TargetPhone", typeof(string));   		//当事人手机
            dtAll.Columns.Add("targetPaperNumber", typeof(string)); 		//当事身份证号
            dtAll.Columns.Add("LegalPerson", typeof(string));       		//法人
            dtAll.Columns.Add("Gender", typeof(string));            		//性别
            dtAll.Columns.Add("TargetDuty", typeof(string));        		//职务

            dtAll.Columns.Add("CaseYear1", typeof(string));       //案发时间年1
            dtAll.Columns.Add("CaseYear2", typeof(string));       //案发时间年2
            dtAll.Columns.Add("CaseMonth1", typeof(string));      //案发时间月1
            dtAll.Columns.Add("CaseMonth2", typeof(string));      //案发时间月2
            dtAll.Columns.Add("CaseDay1", typeof(string));        //案发时间日1
            dtAll.Columns.Add("CaseDay2", typeof(string));        //案发时间日2

            dtAll.Columns.Add("CaseHourS", typeof(string));        //案发时间(起)小时
            dtAll.Columns.Add("CaseMinS", typeof(string));        //案发时间(起)分钟

            dtAll.Columns.Add("CaseHourE", typeof(string));        //案发时间(起)小时
            dtAll.Columns.Add("CaseMinE", typeof(string));        //案发时间(起)分钟    

            dtAll.Columns.Add("CaseAddress1", typeof(string));    //案发地点1
            dtAll.Columns.Add("CaseAddress2", typeof(string));    //案发地点2
            dtAll.Columns.Add("FileFact1", typeof(string)); 		 //违法行为1
            dtAll.Columns.Add("FileFact2", typeof(string)); 		 //违法行为2

            dtAll.Columns.Add("HYear1", typeof(string));       //处理时间年1
            dtAll.Columns.Add("HYear2", typeof(string));       //处理时间年2
            dtAll.Columns.Add("HMonth1", typeof(string));      //处理时间月1
            dtAll.Columns.Add("HMonth2", typeof(string));      //处理时间月2
            dtAll.Columns.Add("HDay1", typeof(string));        //处理时间日1
            dtAll.Columns.Add("HDay2", typeof(string));        //处理时间日2    

            dtAll.Columns.Add("DeptName1", typeof(string)); 	 //执法部门名称1
            dtAll.Columns.Add("DeptName2", typeof(string)); 	 //执法部门名称2
            dtAll.Columns.Add("DeptAddress1", typeof(string)); 	 //执法部门地点1
            dtAll.Columns.Add("DeptAddress2", typeof(string)); 	 //执法部门地点2
            dtAll.Columns.Add("DeptPhone1", typeof(string)); 	 //执法部门电话1
            dtAll.Columns.Add("DeptPhone2", typeof(string)); 	 //执法部门电话2

            dtAll.Columns.Add("CheckPerson", typeof(string)); 	 //检查人员
            dtAll.Columns.Add("Person", typeof(string)); 	     //记录人员    
            dtAll.Columns.Add("UndertakerFirstSignName", typeof(string));		 //承办人（一）签名
            dtAll.Columns.Add("UndertakerSecondSignName", typeof(string)); 	 //承办人（二）签名
            #endregion

            //案件信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            //部门
            var strCrmDepartment = string.Format("select * from CrmDepartment where id='{0}'", dtCASEINFO.Rows[0]["DeptId"].ToString());
            DataTable dtCrmDepartment = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmDepartment).Tables[0];
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];
            //承办人签字
            var strCrmUserSignFirst = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strCrmUserSignSecond = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());

            DataTable dtCrmUserSignFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignFirst).Tables[0];
            DataTable dtCrmUserSignSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignSecond).Tables[0];

            #region 变量赋值
            //当事人为公民
            if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120001")
            {
                Name = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
                TargetName = "";
            }
            else
            {
                TargetName = dtCASEINFO.Rows[0]["TargetName"].ToString();
                Name = dtCASEINFO.Rows[0]["TargetName"].ToString();
            }
            #endregion

            #region 列赋值
            if (dtCrmDepartment != null && dtCrmDepartment.Rows.Count > 0)
            {
                DataRow newRow;
                newRow = dtAll.NewRow();
                newRow["CaseInfoNo1"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();
                newRow["CaseInfoNo2"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();
                newRow["TargetName1"] = Name;
                newRow["TargetName2"] = Name;
                newRow["TargetAddress"] = dtCASEINFO.Rows[0]["TargetAddress"].ToString();
                newRow["TargetPhone"] = dtCASEINFO.Rows[0]["TargetPhone"].ToString();
                newRow["targetPaperNumber"] = dtCASEINFO.Rows[0]["TargetPhone"].ToString();
                newRow["LegalPerson"] = dtCASEINFO.Rows[0]["TargetPaperNum"].ToString();
                newRow["Gender"] = "男";
                newRow["TargetDuty"] = dtCASEINFO.Rows[0]["TargetDuty"].ToString();

                newRow["CaseYear1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Year.ToString().Trim();        //案发时间年1
                newRow["CaseYear2"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Year.ToString().Trim();         //案发时间年2
                newRow["CaseYear3"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Year.ToString().Trim();         //案发时间年3
                newRow["CaseMonth1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Month.ToString().Trim();        //案发时间月1
                newRow["CaseMonth2"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Month.ToString().Trim();        //案发时间月2
                newRow["CaseMonth3"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Month.ToString().Trim();        //案发时间月3
                newRow["CaseDay1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Day.ToString().Trim();          //案发时间日1
                newRow["CaseDay2"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Day.ToString().Trim();          //案发时间日2
                newRow["CaseDay3"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Day.ToString().Trim();          //案发时间日3
                newRow["CaseHourS"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Hour.ToString().Trim();        //案发时间(起)小时
                newRow["CaseMinS"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Minute.ToString().Trim();         //案发时间(起)分钟
                newRow["CaseHourE"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Hour.ToString().Trim();         //案发时间(起)小时
                newRow["CaseMinE"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).AddHours(Result).ToString().Trim();          //案发时间(起)分钟    

                newRow["CaseAddress1"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();     //案发地点1
                newRow["CaseAddress2"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();     //案发地点2
                if (dtLEGISLATION.Rows.Count > 0)
                {
                    newRow["FileFact1"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();  		 //违法行为1
                    newRow["FileFact2"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();  		 //违法行为2
                }
                newRow["HYear1"] = DateTime.Parse(dtCASEINFO.Rows[0]["AcceptInvestigationDate"].ToString()).Year.ToString().Trim();
                newRow["HYear2"] = DateTime.Parse(dtCASEINFO.Rows[0]["AcceptInvestigationDate"].ToString()).Year.ToString().Trim();
                newRow["HMonth1"] = DateTime.Parse(dtCASEINFO.Rows[0]["AcceptInvestigationDate"].ToString()).Month.ToString().Trim();
                newRow["HMonth2"] = DateTime.Parse(dtCASEINFO.Rows[0]["AcceptInvestigationDate"].ToString()).Month.ToString().Trim();
                newRow["HDay1"] = DateTime.Parse(dtCASEINFO.Rows[0]["AcceptInvestigationDate"].ToString()).Day.ToString().Trim();
                newRow["HDay2"] = DateTime.Parse(dtCASEINFO.Rows[0]["AcceptInvestigationDate"].ToString()).Day.ToString().Trim();
                newRow["DeptName2"] = "吴中东路145号案件审理室";
                newRow["DeptAddress1"] = "";
                newRow["DeptAddress2"] = "";
                newRow["DeptPhone1"] = "";
                newRow["DeptPhone2"] = "";
                newRow["CheckPerson"] = dtCASEINFO.Rows[0]["RePersonelNameFist"].ToString() + "、" + dtCASEINFO.Rows[0]["RePersonelNameSecond"].ToString();
                newRow["Person"] = dtCASEINFO.Rows[0]["RePersonelNameFist"].ToString();
                newRow["UndertakerFirstSignName"] = dtCrmUserSignFirst.Rows[0]["SignAddress"].ToString();
                newRow["UndertakerSecondSignName"] = dtCrmUserSignSecond.Rows[0]["SignAddress"].ToString();
                dtAll.Rows.Add(newRow);
            }
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 先行登记通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable XXDJTZS(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加 列
            dtAll.Columns.Add("CaseInfoNo1", typeof(string));       //通知书编号1
            dtAll.Columns.Add("CaseInfoNo2", typeof(string));       //通知书编号2
            dtAll.Columns.Add("TargetName1", typeof(string)); 	    //当事人1
            dtAll.Columns.Add("TargetName2", typeof(string)); 		//当事人2	

            dtAll.Columns.Add("CaseYear1", typeof(string));       //案发时间年1
            dtAll.Columns.Add("CaseYear2", typeof(string));       //案发时间年2
            dtAll.Columns.Add("CaseMonth1", typeof(string));      //案发时间月1
            dtAll.Columns.Add("CaseMonth2", typeof(string));      //案发时间月2
            dtAll.Columns.Add("CaseDay1", typeof(string));       //案发时间日1
            dtAll.Columns.Add("CaseDay2", typeof(string));       //案发时间日2

            dtAll.Columns.Add("CaseAddress1", typeof(string));    //案发地点1
            dtAll.Columns.Add("CaseAddress2", typeof(string));    //案发地点2
            dtAll.Columns.Add("FileFact1", typeof(string));      //违法行为1
            dtAll.Columns.Add("FileFact2", typeof(string));	     //违法行为2
            #endregion
            //案件信息
            var strTempDetainInfo = string.Format("select * from TempDetainInfo where id='{0}'", resourceId);
            DataTable dtTempDetainInfo = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strTempDetainInfo).Tables[0];
            //部门
            var strCrmDepartment = string.Format("select * from CrmDepartment where id='{0}'", dtTempDetainInfo.Rows[0]["DeptId"].ToString());
            DataTable dtCrmDepartment = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmDepartment).Tables[0];
            var strLegislation = string.Format("select * from TempDetainInfo_Legislation where CaseInfoId='{0}'", resourceId);
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLegislation).Tables[0];

            #region 列赋值
            if (dtCrmDepartment != null && dtCrmDepartment.Rows.Count > 0)
            {
                DataRow newRow;
                newRow = dtAll.NewRow();
                newRow["CaseInfoNo1"] = dtTempDetainInfo.Rows[0]["TempNo"].ToString();       //通知书编号1
                newRow["CaseInfoNo2"] = dtTempDetainInfo.Rows[0]["TempNo"].ToString();        //通知书编号2
                newRow["TargetName1"] = dtTempDetainInfo.Rows[0]["TempNo"].ToString(); 	    //当事人1
                newRow["TargetName2"] = dtTempDetainInfo.Rows[0]["TempNo"].ToString(); 		//当事人2	

                newRow["CaseYear1"] = DateTime.Parse(dtTempDetainInfo.Rows[0]["TempDateTime"].ToString()).Year.ToString().Trim();        //案发时间年1
                newRow["CaseYear2"] = DateTime.Parse(dtTempDetainInfo.Rows[0]["TempDateTime"].ToString()).Year.ToString().Trim();         //案发时间年2
                newRow["CaseMonth1"] = DateTime.Parse(dtTempDetainInfo.Rows[0]["TempDateTime"].ToString()).Month.ToString().Trim();        //案发时间月1
                newRow["CaseMonth2"] = DateTime.Parse(dtTempDetainInfo.Rows[0]["TempDateTime"].ToString()).Month.ToString().Trim();        //案发时间月2
                newRow["CaseDay1"] = DateTime.Parse(dtTempDetainInfo.Rows[0]["TempDateTime"].ToString()).Day.ToString().Trim();          //案发时间日1
                newRow["CaseDay2"] = DateTime.Parse(dtTempDetainInfo.Rows[0]["TempDateTime"].ToString()).Day.ToString().Trim();          //案发时间日2

                newRow["CaseAddress1"] = dtTempDetainInfo.Rows[0]["TempAddress"].ToString(); 	  //案发地点1
                newRow["CaseAddress2"] = dtTempDetainInfo.Rows[0]["TempAddress"].ToString(); 	    //案发地点2
                if (dtLEGISLATION.Rows.Count > 0)
                {
                    newRow["FileFact1"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();      //违法行为1
                    newRow["FileFact2"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();	     //违法行为2
                }
                dtAll.Rows.Add(newRow);
            }
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 现场检查/勘验笔录 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable FieldInspectionRecord(string resourceId)
        {
            //获取随机数
            Random ran = new Random();
            Double i = ran.Next(10, 15);
            Double Result = Math.Round(((15 - 10 - 1) * i), 0);

            string Name = string.Empty;
            string TargetName = string.Empty;
            string TargetUnit = string.Empty;
            string UnitLeader = string.Empty;
            string TargetZDM = string.Empty;
            string TargetDuty = string.Empty;
            string UnitAddress = string.Empty;
            string TargetMobile = string.Empty;
            string TargetName3 = string.Empty;
            string TargetGender = string.Empty;
            string TargetAge = string.Empty;
            string TargetAddress = string.Empty;
            string targetPaperNumber = string.Empty;
            string TargetPhone = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseInfoNo1", typeof(string));       //通知书编号1
            dtAll.Columns.Add("TargetName1", typeof(string)); 		//当事人1

            dtAll.Columns.Add("TargetUnit", typeof(string));    //单位地址
            dtAll.Columns.Add("UnitLeader", typeof(string)); 	//负责人姓名
            dtAll.Columns.Add("TargetZDM", typeof(string));      //组织机构代码证
            dtAll.Columns.Add("TargetDuty", typeof(string)); 	//职务
            dtAll.Columns.Add("UnitAddress", typeof(string));   //单位地址
            dtAll.Columns.Add("TargetMobile", typeof(string));   //联系电话

            dtAll.Columns.Add("TargetAddress", typeof(string));  		//当事人地址
            dtAll.Columns.Add("TargetPhone", typeof(string));   		//当事人手机（联系电话）

            dtAll.Columns.Add("targetPaperNumber", typeof(string)); 		//当事身份证号

            dtAll.Columns.Add("TargetGender", typeof(string)); 		//性别
            dtAll.Columns.Add("TargetAge", typeof(string));     //年龄

            dtAll.Columns.Add("CaseYear1", typeof(string));       //案发时间年1
            dtAll.Columns.Add("CaseMonth1", typeof(string));      //案发时间月1
            dtAll.Columns.Add("CaseDay1", typeof(string));        //案发时间日1

            dtAll.Columns.Add("CaseHourS", typeof(string));        //案发时间(起)小时
            dtAll.Columns.Add("CaseMinS", typeof(string));         //案发时间(起)分钟

            dtAll.Columns.Add("CaseHourE", typeof(string));        //案发时间(起)小时
            dtAll.Columns.Add("CaseMinE", typeof(string));         //案发时间(起)分钟    

            dtAll.Columns.Add("CaseAddress1", typeof(string));       //案发地点1
            dtAll.Columns.Add("FileFact1", typeof(string)); 		 //违法行为1

            dtAll.Columns.Add("CheckPerson", typeof(string)); 	 //检查人员
            dtAll.Columns.Add("Person", typeof(string)); 	     //记录人员

            dtAll.Columns.Add("DrawDate", typeof(string));      //绘制时间
            dtAll.Columns.Add("DrawPerson", typeof(string));    //绘制人

            dtAll.Columns.Add("CheckPerson1", typeof(string));   //现场执法人员（用于证据）
            dtAll.Columns.Add("CheckPerson2", typeof(string));   //现场执法人员（用于证据）

            dtAll.Columns.Add("Person1", typeof(string)); 	 //拍摄人（用于证据）
            dtAll.Columns.Add("Person2", typeof(string));     //拍摄人（用于证据）

            dtAll.Columns.Add("CaseAddress2", typeof(string));    //拍摄地点（用于证据）
            dtAll.Columns.Add("CaseAddress3", typeof(string));    //拍摄地点（用于证据）

            dtAll.Columns.Add("TakePhotoDate1", typeof(string));    //拍摄日期1（用于证据）
            dtAll.Columns.Add("TakePhotoDate2", typeof(string));    //拍摄日期2（用于证据）

            dtAll.Columns.Add("RecordInfo", typeof(string));  //现场检查笔录内容
            dtAll.Columns.Add("Reference1", typeof(string));   //参照物1
            dtAll.Columns.Add("Reference2", typeof(string));    //参照物2

            dtAll.Columns.Add("FileFact2", typeof(string));   //事由
            dtAll.Columns.Add("FileFact3", typeof(string));   //事由

            dtAll.Columns.Add("Photo1", typeof(string));   //证据照片名称1
            dtAll.Columns.Add("Photo2", typeof(string));   //证据照片名称1
            dtAll.Columns.Add("DeptName", typeof(string)); 	 //执法部门名称
            dtAll.Columns.Add("License", typeof(string));  //营业执照
            dtAll.Columns.Add("TypeNum", typeof(string));  //号码类型

            dtAll.Columns.Add("UndertakerFirstSignName", typeof(string));   //承办人（一）签名
            dtAll.Columns.Add("UndertakerSecondSignName", typeof(string));  //承办人（二）签名
            #endregion

            //案件信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            //部门
            var strCrmDepartment = string.Format("select * from CrmDepartment where id='{0}'", dtCASEINFO.Rows[0]["DeptId"].ToString());
            DataTable dtCrmDepartment = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmDepartment).Tables[0];
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];
            //承办人签字
            var strCrmUserSignFirst = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strCrmUserSignSecond = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());

            DataTable dtCrmUserSignFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignFirst).Tables[0];
            DataTable dtCrmUserSignSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignSecond).Tables[0];
            var strComResource = string.Format("SELECT * FROM ComResource WHERE ParentId='0013' AND RsValue='{0}'", dtCASEINFO.Rows[0]["TargetPaperType"].ToString());
            DataTable dtComResource = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcRead, CommandType.Text, strComResource).Tables[0];
            #region 变量赋值
            if (dtCASEINFO.Rows.Count > 0)
            {
                //当事人为公民
                if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120001") //自然人
                {
                    Name = dtCASEINFO.Rows[0]["TargetName"].ToString();
                    UnitLeader = "";
                    TargetUnit = "";
                    UnitLeader = "";
                    TargetZDM = "";
                    TargetDuty = "";
                    UnitAddress = "";
                    TargetMobile = "";
                    if (dtCASEINFO.Rows[0]["TargetGender"].ToString() == "1")
                    {
                        TargetGender = "男";
                    }
                    else
                    {
                        TargetGender = "女";
                    }
                    TargetAge = dtCASEINFO.Rows[0]["TargetAge"].ToString();
                    TargetAddress = dtCASEINFO.Rows[0]["TargetAddress"].ToString();
                    targetPaperNumber = dtCASEINFO.Rows[0]["targetPaperNumber"].ToString();
                    TargetPhone = dtCASEINFO.Rows[0]["TargetPhone"].ToString();
                }
                else if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120002") //法人
                {
                    Name = "";
                    UnitLeader = dtCASEINFO.Rows[0]["TargetName"].ToString();
                    TargetUnit = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
                    TargetZDM = dtCASEINFO.Rows[0]["TargetZDM"].ToString();
                    TargetDuty = dtCASEINFO.Rows[0]["TargetDuty"].ToString();
                    UnitAddress = dtCASEINFO.Rows[0]["UnitAddress"].ToString();
                    TargetMobile = dtCASEINFO.Rows[0]["TargetMobile"].ToString();
                    TargetGender = "";
                    TargetAge = "";
                    TargetAddress = "";
                    targetPaperNumber = "";
                    TargetPhone = "";
                }
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["CaseInfoNo1"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();       //通知书编号1
                newRow["targetPaperNumber"] = dtCASEINFO.Rows[0]["TargetPaperNum"].ToString(); 		//当事身份证号

                newRow["CaseYear1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Year.ToString().Trim();        //案发时间年1
                newRow["CaseMonth1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Month.ToString().Trim();        //案发时间月1
                newRow["CaseDay1"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Day.ToString().Trim();          //案发时间日1

                newRow["CaseHourS"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Hour.ToString().Trim();        //案发时间(起)小时
                newRow["CaseMinS"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Minute.ToString().Trim();         //案发时间(起)分钟

                newRow["CaseHourE"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).Hour.ToString().Trim();         //案发时间(起)小时
                newRow["CaseMinE"] = DateTime.Parse(dtCASEINFO.Rows[0]["CaseDate"].ToString()).AddHours(Result).ToString().Trim();          //案发时间(起)分钟 
                newRow["CaseAddress1"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();       //案发地点1   
                newRow["CheckPerson"] = dtCASEINFO.Rows[0]["RePersonelNameFist"].ToString() + "、" + dtCASEINFO.Rows[0]["RePersonelNameSecond"].ToString(); ; 	 //检查人员
                newRow["Person"] = dtCASEINFO.Rows[0]["RePersonelNameFist"].ToString(); 	     //记录人员

                newRow["RecordInfo"] = dtCASEINFO.Rows[0]["RePersonelNameFist"].ToString();  //现场检查笔录内容
                newRow["Reference1"] = dtCASEINFO.Rows[0]["Reference1"].ToString();   //参照物1
                newRow["Reference2"] = dtCASEINFO.Rows[0]["Reference2"].ToString();    //参照物2
            }
            newRow["TargetName1"] = Name; 		//当事人1
            newRow["TargetUnit"] = TargetUnit;    //单位地址
            newRow["UnitLeader"] = UnitLeader; 	//负责人姓名
            newRow["TargetZDM"] = TargetZDM;      //组织机构代码证
            newRow["TargetDuty"] = TargetDuty; 	//职务
            newRow["UnitAddress"] = UnitAddress;   //单位地址
            newRow["TargetMobile"] = TargetMobile;   //联系电话

            newRow["TargetAddress"] = TargetAddress;  		//当事人地址
            newRow["TargetPhone"] = TargetPhone;   		//当事人手机（联系电话）

            newRow["TargetGender"] = TargetGender; 		//性别
            newRow["TargetAge"] = TargetAge;     //年龄
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["FileFact1"] = dtLEGISLATION.Rows[0]["ItemName"].ToString(); 		 //违法行为1
                newRow["FileFact2"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();    //事由
                newRow["FileFact3"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();    //事由
            }
            newRow["DrawDate"] = "";      //绘制时间
            newRow["DrawPerson"] = "";    //绘制人

            newRow["CheckPerson1"] = "";   //现场执法人员（用于证据）
            newRow["CheckPerson2"] = "";   //现场执法人员（用于证据）

            newRow["Person1"] = ""; 	 //拍摄人（用于证据）
            newRow["Person2"] = "";     //拍摄人（用于证据）

            newRow["CaseAddress2"] = "";    //拍摄地点（用于证据）
            newRow["CaseAddress3"] = "";    //拍摄地点（用于证据）

            newRow["TakePhotoDate1"] = "";    //拍摄日期1（用于证据）
            newRow["TakePhotoDate2"] = "";    //拍摄日期2（用于证据）
            newRow["Photo1"] = "";   //证据照片名称1
            newRow["Photo2"] = "";   //证据照片名称1
            newRow["DeptName"] = dtCrmDepartment.Rows[0]["FullName"].ToString(); 	 //执法部门名称          
            newRow["License"] = "";  //营业执照
            newRow["TypeNum"] = dtComResource.Rows[0]["RsKey"].ToString() + "号码";  //号码类型
            newRow["UndertakerFirstSignName"] = dtCrmUserSignFirst.Rows[0]["SignAddress"].ToString();
            newRow["UndertakerSecondSignName"] = dtCrmUserSignSecond.Rows[0]["SignAddress"].ToString();
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        #endregion


        #region 国土文书查询

        /// <summary>
        /// 接受调查通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandAccepted(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            string SevenDate = string.Empty; ;//当前日期7日后
            string LeaderDate = string.Empty; //局领导最后审批日期
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string)); //查处对象名称
            dtAll.Columns.Add("SevenDate", typeof(string)); //当前日期7日后
            dtAll.Columns.Add("ItemAct", typeof(string));
            dtAll.Columns.Add("GistName", typeof(string)); //违反法规
            dtAll.Columns.Add("UndertakerFirstName", typeof(string)); //办案人
            dtAll.Columns.Add("UndertakerMobile", typeof(string)); //办案人联系电话
            dtAll.Columns.Add("LeaderDate", typeof(string)); //局领导最后审批日期
            #endregion
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];

            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcRead, CommandType.Text, strLEGISLATION).Tables[0];
            //根据承办人id，查询姓名，联系方式
            var strCrmUser = string.Format("select * from CrmUser where id='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            DataTable dtCrmUser = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcRead, CommandType.Text, strCrmUser).Tables[0];

            #region 获取局领导最后审批时间
            //查询文书类型
            var strWF_Process = string.Format("select * from WF_Process where FullName = '国土立案审批'");
            DataTable dtWF_Process = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strWF_Process).Tables[0];
            //意见表
            var strCrmIdeaList = string.Format("select * from CrmIdeaList where [Type] = 0 and ResourceID='{0}' and ProcessID='{1}'  order by CreateOn ", resourceId, dtWF_Process.Rows[0]["Id"].ToString());
            DataTable dtCrmIdeaList = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmIdeaList).Tables[0];
            if (dtCrmIdeaList.Rows.Count > 0)
            {
                //遍历意见表数据
                for (int i = 0; i < dtCrmIdeaList.Rows.Count; i++)
                {
                    if (i == 3)
                    {
                        LeaderDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                }
            }
            #endregion

            #region 变量赋值
            if (dtCASEINFO.Rows.Count > 0)
            {
                //当前时间后7天
                SevenDate = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss");
                string[] array = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
                if (array.Length > 1)
                {
                    Year = array[0];
                    Num = array[1].Substring(0, 5);
                }
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
            }
            newRow["SevenDate"] = SevenDate;
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["ItemAct"] = dtLEGISLATION.Rows[0]["ItemAct"].ToString();
                newRow["GistName"] = dtLEGISLATION.Rows[0]["GistName"].ToString();
            }
            if (dtCrmUser.Rows.Count > 0)
            {
                newRow["UndertakerFirstName"] = dtCrmUser.Rows[0]["RealName"].ToString();
                newRow["UndertakerMobile"] = dtCrmUser.Rows[0]["Mobile"].ToString();
            }
            newRow["LeaderDate"] = LeaderDate;
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 违法案件处理决定呈批表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandActionDecide(string resourceId)
        {
            string AcceptDate = string.Empty;//立案日期
            string UndertakerIdea = string.Empty;
            string UndertakerDate = string.Empty;
            string LegalSignIdea = string.Empty;
            string LegalSignName = string.Empty;
            string LegalSignDate = string.Empty;
            string ChargeIdea = string.Empty;
            string ChargeName = string.Empty;
            string ChargeDate = string.Empty;
            string LeaderIdea = string.Empty;
            string LeaderName = string.Empty;
            string LeaderDate = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseInfoNo", typeof(string));
            dtAll.Columns.Add("AcceptCode", typeof(string)); //立案编号
            dtAll.Columns.Add("ItemName", typeof(string));    //案由名称
            dtAll.Columns.Add("TargetName", typeof(string)); 	 //当事人姓名
            dtAll.Columns.Add("TargetAddress", typeof(string));  //当事人地址
            dtAll.Columns.Add("TargetPhone", typeof(string)); 	 //当事人联系电话
            dtAll.Columns.Add("CaseFact", typeof(string)); 		 //案情摘要

            dtAll.Columns.Add("AcceptDate", typeof(string));    //立案日期
            dtAll.Columns.Add("UndertakerIdea", typeof(string));    //承办人意见，时间
            dtAll.Columns.Add("UndertakerDate", typeof(string));

            dtAll.Columns.Add("LegalSignIdea", typeof(string));  	 //执法监察工作机构意见，签名，时间
            dtAll.Columns.Add("LegalSignName", typeof(string));
            dtAll.Columns.Add("LegalSignDate", typeof(string));

            dtAll.Columns.Add("ChargeIdea", typeof(string));  	 //分管领导意见，签名，时间
            dtAll.Columns.Add("ChargeName", typeof(string));
            dtAll.Columns.Add("ChargeDate", typeof(string));

            dtAll.Columns.Add("LeaderIdea", typeof(string));  	 //局审批意见，签名，时间
            dtAll.Columns.Add("LeaderName", typeof(string));
            dtAll.Columns.Add("LeaderDate", typeof(string));

            dtAll.Columns.Add("UndertakerFirstSignName", typeof(string));    //承办人（一）签名
            dtAll.Columns.Add("UndertakerSecondSignName", typeof(string));   //承办人（二）签名
            #endregion

            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcRead, CommandType.Text, strLEGISLATION).Tables[0];
            //承办人签字
            var strCrmUserSignFirst = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strCrmUserSignSecond = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());

            DataTable dtCrmUserSignFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignFirst).Tables[0];
            DataTable dtCrmUserSignSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignSecond).Tables[0];
            #region 各个部门意见，签字，时间
            var strWF_Process = string.Format("select * from WF_Process where FullName = '处理审批'");
            DataTable dtWF_Process = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strWF_Process).Tables[0];
            var strCrmIdeaList = string.Format("select * from CrmIdeaList where [Type] = 0 and ResourceID='{0}' and ProcessID='{1}'  order by CreateOn ", resourceId, dtWF_Process.Rows[0]["Id"].ToString());
            DataTable dtCrmIdeaList = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmIdeaList).Tables[0];
            string SignType = string.Empty;
            if (dtCrmIdeaList.Rows.Count > 0)
            {
                if (dtCrmIdeaList.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCrmIdeaList.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            SignType = "00310002";
                        }
                        else
                        {
                            SignType = "00310003";
                        }
                        var strCrmUserSign = string.Format("select * from CrmUserSign where SignType = '00310001' AND UserId='{0}'", dtCrmIdeaList.Rows[i]["UserId"].ToString());
                        var strCrmUserSignIdea = string.Format("select * from CrmUserSign where SignType = '{0}' AND UserId='{1}'", SignType, dtCrmIdeaList.Rows[i]["UserId"].ToString());

                        DataTable dtCrmUserSign = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSign).Tables[0];
                        DataTable dtCrmUserSignIdea = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignIdea).Tables[0];
                        if (i == 0)
                        {
                            UndertakerIdea = dtCrmUserSign.Rows[0]["Idea"].ToString();
                            UndertakerDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                        }
                        else if (i == 1)
                        {
                            LegalSignName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                            LegalSignIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                            LegalSignDate = dtCrmUserSign.Rows[i]["Idea"].ToString();
                        }
                        else if (i == 2)
                        {
                            ChargeName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                            ChargeIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                            ChargeDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");

                        }
                        else if (i == 3)
                        {
                            LeaderName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                            LeaderIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                            LeaderDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                        }
                    }
                }
            }
            #endregion
            #region 立案日期
            var strWF_Processla = string.Format("select * from WF_Process where FullName = '立案审批'");
            DataTable dtWF_Processla = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strWF_Processla).Tables[0];
            var strCrmIdeaListla = string.Format("select * from CrmIdeaList where [Type] = 0 and ResourceID='{0}' and ProcessID='{1}'  order by CreateOn ", resourceId, dtWF_Processla.Rows[0]["Id"].ToString());
            DataTable dtCrmIdeaListla = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmIdeaListla).Tables[0];

            if (dtCrmIdeaListla.Rows.Count > 0)
            {
                for (int i = 0; i < dtCrmIdeaListla.Rows.Count; i++)
                {
                    if (i == 3)
                    {
                        AcceptDate = DateTime.Parse(dtCrmIdeaListla.Rows[0]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                }
            }
            #endregion
            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["CaseInfoNo"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();
                newRow["AcceptCode"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();
                newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
                newRow["TargetAddress"] = dtCASEINFO.Rows[0]["TargetAddress"].ToString();
                newRow["TargetPhone"] = dtCASEINFO.Rows[0]["TargetPhone"].ToString();
                newRow["CaseFact"] = dtCASEINFO.Rows[0]["CaseFact"].ToString();
            }
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["ItemName"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();
            }
            newRow["AcceptDate"] = AcceptDate;
            newRow["UndertakerIdea"] = UndertakerIdea;
            newRow["UndertakerDate"] = UndertakerDate;
            newRow["LegalSignIdea"] = LegalSignIdea;
            newRow["LegalSignName"] = LegalSignName;
            newRow["LegalSignDate"] = LegalSignDate;
            newRow["ChargeIdea"] = ChargeIdea;
            newRow["ChargeName"] = ChargeName;
            newRow["ChargeDate"] = ChargeDate;
            newRow["LeaderIdea"] = LeaderIdea;
            newRow["LeaderName"] = LeaderName;
            newRow["LeaderDate"] = LeaderDate;
            newRow["UndertakerFirstSignName"] = dtCrmUserSignFirst.Rows[0]["SignAddress"].ToString();
            newRow["UndertakerSecondSignName"] = dtCrmUserSignSecond.Rows[0]["SignAddress"].ToString();
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 送达回证**********
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandCaceBack(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("ReceiptAddress", typeof(string));
            dtAll.Columns.Add("SigninPerson", typeof(string));
            dtAll.Columns.Add("ReceiptType", typeof(string));
            dtAll.Columns.Add("SinginDate", typeof(string));
            dtAll.Columns.Add("ReceiptSignName", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            #endregion
            var strRECORD = string.Format("SELECT  *  FROM  INF_PUNISH_RECORD  WHERE CaseInfoId ='{0}'", resourceId);
            var strRECEIPT = string.Format("SELECT  * FROM  INF_PUNISH_RECEIPT WHERE ServiceType=1 and   CaseInfoId ='{0}'", resourceId);
            var strCASEINFO = string.Format("SELECT * FROM INF_PUNISH_CASEINFO WHERE ID ='{0}'", resourceId);

            DataTable dtRECORD = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strRECORD).Tables[0];
            DataTable dtRECEIPT = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strRECEIPT).Tables[0];
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            #region 变量赋值
            //年，号
            if (dtCASEINFO.Rows.Count > 0)
            {
                string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
                Year = _listCaseInfoNo[0];
                Num = _listCaseInfoNo[1].Substring(0, 5);
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
                newRow["ReceiptAddress"] = dtRECORD.Rows[0]["Address"];
                newRow["ReceiptSignName"] = dtCASEINFO.Rows[0]["UdPersonelNameFirst"];
            }
            if (dtRECEIPT.Rows.Count > 0)
            {
                newRow["SigninPerson"] = dtRECEIPT.Rows[0]["SigninPerson"];
                newRow["SinginDate"] = dtRECEIPT.Rows[0]["SinginDate"];
                newRow["ReceiptType"] = dtRECEIPT.Rows[0]["ReceiptType"];
            }
            newRow[""] = "";
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }


        /// <summary>
        /// 违法线索登记表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandClueRegister(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            string UndertakerIdea = string.Empty;
            string UndertakerDate = string.Empty;
            string LegalSignIdea = string.Empty;
            string LegalSignName = string.Empty;
            string LegalSignDate = string.Empty;

            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));         //查处对象名称
            dtAll.Columns.Add("TargetPhone", typeof(string));       //联系电话
            dtAll.Columns.Add("TargetAddress", typeof(string));     //地址
            dtAll.Columns.Add("CaseAddress", typeof(string));       //案发地址
            dtAll.Columns.Add("ItemAct", typeof(string));           //违法行为
            dtAll.Columns.Add("GistName", typeof(string));          //违反法规
            dtAll.Columns.Add("Resource", typeof(string));          //线索来源
            dtAll.Columns.Add("UndertakerIdea", typeof(string));    //经办人员意见
            dtAll.Columns.Add("UndertakerName", typeof(string));
            dtAll.Columns.Add("UndertakerDate", typeof(string));
            dtAll.Columns.Add("LegalSignIdea", typeof(string));     //执法监察工作机构负责人
            dtAll.Columns.Add("LegalSignName", typeof(string));
            dtAll.Columns.Add("LegalSignDate", typeof(string));
            #endregion

            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where id='{0}'", resourceId);
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];

            var strComResource = string.Format("SELECT * FROM ComResource WHERE ParentId='0010' and id='{0}'", dtCASEINFO.Rows[0]["ReSource"].ToString());
            DataTable dtComResource = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strComResource).Tables[0];
            #region 部门意见，签字

            #endregion
            //年。号
            if (dtCASEINFO.Rows.Count > 0)
            {
                string[] array = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
                if (array.Length > 1)
                {
                    Year = array[0];
                    Num = array[1].Substring(0, 5);
                }
            }
            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();          //查处对象名称
                newRow["TargetPhone"] = dtCASEINFO.Rows[0]["TargetPhone"].ToString();        //联系电话
                newRow["TargetAddress"] = dtCASEINFO.Rows[0]["TargetAddress"].ToString();      //地址
                newRow["CaseAddress"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();        //案发地址
                newRow["UndertakerName"] = dtCASEINFO.Rows[0]["UdPersonelNameFirst"].ToString();
            }
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["ItemAct"] = dtLEGISLATION.Rows[0]["ItemAct"].ToString();            //违法行为
                newRow["GistName"] = dtLEGISLATION.Rows[0]["GistName"].ToString();             //违反法规
            }
            newRow["Resource"] = dtComResource.Rows[0]["RsKey"].ToString();             //线索来源
            newRow["UndertakerIdea"] = UndertakerIdea;     //经办人员
            newRow["UndertakerDate"] = UndertakerDate;
            newRow["LegalSignIdea"] = LegalSignIdea;      //执法监察工作机构负责人
            newRow["LegalSignName"] = LegalSignName;
            newRow["LegalSignDate"] = LegalSignDate;
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 案件人员指定书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandDesignation(string resourceId)
        {
            DataTable dtAll = new DataTable();

            #region 添加列
            dtAll.Columns.Add("CaseInfoNo", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("CreateDate", typeof(string));

            dtAll.Columns.Add("RePersonelNameFist", typeof(string));    //执法人员（一）
            dtAll.Columns.Add("RePersonelNameSecond", typeof(string));   //执法人员（二）
            #endregion
            //案件信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["CaseInfoNo"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();
                newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
                newRow["CreateDate"] = DateTime.Parse(dtCASEINFO.Rows[0]["CreateDate"].ToString()).ToString("yyyy年MM月dd日");
                newRow["RePersonelNameFist"] = dtCASEINFO.Rows[0]["RePersonelNameFist"].ToString();
                newRow["RePersonelNameSecond"] = dtCASEINFO.Rows[0]["RePersonelNameSecond"].ToString();
            }
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;

        }

        /// <summary>
        /// 国土结案审批表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandEndration(string resourceId)
        {
            string AcceptDate = string.Empty;//立案日期
            string UndertakerIdea = string.Empty;
            string UndertakerDate = string.Empty;
            string LegalSignIdea = string.Empty;
            string LegalSignName = string.Empty;
            string LegalSignDate = string.Empty;
            string ChargeIdea = string.Empty;
            string ChargeName = string.Empty;
            string ChargeDate = string.Empty;
            string LeaderIdea = string.Empty;
            string LeaderName = string.Empty;
            string LeaderDate = string.Empty;

            string FullName = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseInfoNo", typeof(string));
            dtAll.Columns.Add("AcceptCode", typeof(string)); //立案编号
            dtAll.Columns.Add("ItemName", typeof(string));    //案由名称
            dtAll.Columns.Add("TargetName", typeof(string)); 	 //当事人姓名
            dtAll.Columns.Add("TargetAddress", typeof(string));  //当事人地址
            dtAll.Columns.Add("TargetPhone", typeof(string)); 	 //当事人联系电话
            dtAll.Columns.Add("CaseFact", typeof(string)); 		 //案情摘要

            dtAll.Columns.Add("ExecuteDesc", typeof(string)); 	 //执行情况
            dtAll.Columns.Add("PunishContent", typeof(string));  //处理情况

            dtAll.Columns.Add("AcceptDate", typeof(string));    //立案日期
            dtAll.Columns.Add("EndDate", typeof(string));         //结案日期  
            dtAll.Columns.Add("UndertakerIdea", typeof(string));    //经办人意见，时间
            dtAll.Columns.Add("UndertakerDate", typeof(string));

            dtAll.Columns.Add("LegalSignIdea", typeof(string));  	 //执法监察工作机构意见，签名，时间
            dtAll.Columns.Add("LegalSignName", typeof(string));
            dtAll.Columns.Add("LegalSignDate", typeof(string));

            dtAll.Columns.Add("ChargeIdea", typeof(string));  	 //分管领导意见，签名，时间
            dtAll.Columns.Add("ChargeName", typeof(string));
            dtAll.Columns.Add("ChargeDate", typeof(string));

            dtAll.Columns.Add("LeaderIdea", typeof(string));  	 //局审批意见，签名，时间
            dtAll.Columns.Add("LeaderName", typeof(string));
            dtAll.Columns.Add("LeaderDate", typeof(string));

            dtAll.Columns.Add("UndertakerFirstSignName", typeof(string));    //承办人（一）签名
            dtAll.Columns.Add("UndertakerSecondSignName", typeof(string));   //承办人（二）签名

            #endregion

            //案件基本信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);//案由
            //执行处理情况
            var strINF_PUNISH_FINISH = string.Format("select * from INF_PUNISH_FINISH where CaseInfoId='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];
            DataTable dtFINISH = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strINF_PUNISH_FINISH).Tables[0];
            //承办人签字
            var strCrmUserSignFirst = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001' AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strCrmUserSignSecond = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001' AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());

            DataTable dtCrmUserSignFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignFirst).Tables[0];
            DataTable dtCrmUserSignSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignSecond).Tables[0];
            #region 各个部门 签名、签字意见及审批日期
            if (dtCASEINFO.Rows[0]["CompanyName"].ToString() == "唯亭街道综合执法大队") //CompanyName是唯亭街道综合执法大队
            {
                FullName = "处理审批";
            }
            else
            {
                FullName = "结案审批";
            }
            var strWF_Process = string.Format("select * from WF_Process where FullName = '{0}'", FullName);
            DataTable dtWF_Process = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strWF_Process).Tables[0];
            var strCrmIdeaList = string.Format("select * from CrmIdeaList where [Type] = 0 and ResourceID='{0}' and ProcessID='{1}'  order by CreateOn ", resourceId, dtWF_Process.Rows[0]["Id"].ToString());
            DataTable dtCrmIdeaList = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmIdeaList).Tables[0];
            string SignType = string.Empty;
            if (dtCrmIdeaList.Rows.Count > 0)
            {
                for (int i = 0; i < dtCrmIdeaList.Rows.Count; i++)
                {
                    if (i == 1)
                    {
                        SignType = "00310002";
                    }
                    else
                    {
                        SignType = "00310003";
                    }
                    var strCrmUserSign = string.Format("select * from CrmUserSign where SignType = '00310001' AND UserId='{0}'", dtCrmIdeaList.Rows[i]["UserId"].ToString());
                    var strCrmUserSignIdea = string.Format("select * from CrmUserSign where SignType = '{0}' AND UserId='{1}'", SignType, dtCrmIdeaList.Rows[i]["UserId"].ToString());

                    DataTable dtCrmUserSign = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSign).Tables[0];
                    DataTable dtCrmUserSignIdea = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignIdea).Tables[0];
                    if (i == 0)
                    {
                        UndertakerIdea = dtCrmUserSign.Rows[0]["Idea"].ToString();
                        UndertakerDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                    else if (i == 1)
                    {
                        LegalSignName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        LegalSignIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        LegalSignDate = dtCrmUserSign.Rows[i]["Idea"].ToString();
                    }
                    else if (i == 2)
                    {
                        ChargeName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        ChargeIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        ChargeDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");

                    }
                    else if (i == 3)
                    {
                        LeaderName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        LeaderIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        LeaderDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                }
            }

            #endregion

            #region 立案日期
            var strWF_Processla = string.Format("select * from WF_Process where FullName = '立案审批'");
            DataTable dtWF_Processla = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strWF_Processla).Tables[0];
            var strCrmIdeaListla = string.Format("select * from CrmIdeaList where [Type] = 0 and ResourceID='{0}' and ProcessID='{1}'  order by CreateOn ", resourceId, dtWF_Processla.Rows[0]["Id"].ToString());
            DataTable dtCrmIdeaListla = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmIdeaListla).Tables[0];
            if (dtCrmIdeaListla.Rows.Count > 0)
            {
                for (int i = 0; i < dtCrmIdeaListla.Rows.Count; i++)
                {
                    if (i == 3)
                    {
                        AcceptDate = DateTime.Parse(dtCrmIdeaListla.Rows[0]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                }
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["CaseInfoNo"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();
                newRow["AcceptCode"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();
                newRow["CaseDate"] = dtCASEINFO.Rows[0]["CaseDate"].ToString();
                newRow["TargetAddress"] = dtCASEINFO.Rows[0]["TargetAddress"].ToString();
                newRow["TargetPhone"] = dtCASEINFO.Rows[0]["TargetPhone"].ToString();
                newRow["CaseFact"] = dtCASEINFO.Rows[0]["CaseFact"].ToString();
            }
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["ItemName"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();
            }
            if (dtFINISH.Rows.Count > 0)
            {
                newRow["ExecuteDesc"] = dtFINISH.Rows[0]["ExecuteDesc"].ToString();
                newRow["PunishContent"] = dtFINISH.Rows[0]["PunishContent"].ToString();
                newRow["EndDate"] = dtFINISH.Rows[0]["FINISHDATE"].ToString();
            }
            newRow["AcceptDate"] = AcceptDate;
            newRow["UndertakerIdea"] = UndertakerIdea;    //经办人意见，时间
            newRow["UndertakerDate"] = UndertakerDate;

            newRow["LegalSignIdea"] = LegalSignIdea;  	 //执法监察工作机构意见，签名，时间
            newRow["LegalSignName"] = LegalSignName;
            newRow["LegalSignDate"] = LegalSignDate;

            newRow["ChargeIdea"] = ChargeIdea;  	 //分管领导意见，签名，时间
            newRow["ChargeName"] = ChargeName;
            newRow["ChargeDate"] = ChargeDate;

            newRow["LeaderIdea"] = LeaderIdea;  	 //局审批意见，签名，时间
            newRow["LeaderName"] = LeaderName;
            newRow["LeaderDate"] = LeaderDate;

            newRow["UndertakerFirstSignName"] = dtCrmUserSignFirst.Rows[0]["SignAddress"].ToString();
            newRow["UndertakerSecondSignName"] = dtCrmUserSignSecond.Rows[0]["SignAddress"].ToString();

            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 现场勘测笔录*******************************
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandFieldInspectionRecord(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseInfoNo", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("GetDate", typeof(string)); //当前时间
            dtAll.Columns.Add("CaseAddress", typeof(string));//勘测地点
            dtAll.Columns.Add("", typeof(string));  //勘 测 人签字
            dtAll.Columns.Add("", typeof(string));  // 办案人员签字
            dtAll.Columns.Add("", typeof(string));  //当 事 人签字  
            dtAll.Columns.Add("", typeof(string));  // 见 证 人签字
            #endregion

            //案件基本信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["CaseInfoNo"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();
                newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
                newRow["CaseAddress"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();
            }
            newRow["GetDate"] = DateTime.Now.ToString();
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 行政处罚告知书*******
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandInform(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            string LeaderDate = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("", typeof(string));//引用A（面积替换为测绘后面积）
            dtAll.Columns.Add("", typeof(string));//引用C

            dtAll.Columns.Add("UndertakerFirstName", typeof(string)); //办案人
            dtAll.Columns.Add("UndertakerMobile", typeof(string)); //办案人联系电话
            dtAll.Columns.Add("LeaderDate", typeof(string)); //局领导最后审批日期
            #endregion

            //案件基本信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            //根据承办人id，查询姓名，联系方式
            var strCrmUser = string.Format("select * from CrmUser where id='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            DataTable dtCrmUser = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcRead, CommandType.Text, strCrmUser).Tables[0];

            #region 获取局领导最后审批时间
            //查询文书类型
            var strWF_Process = string.Format("select * from WF_Process where FullName = '国土处罚决定审批'");
            DataTable dtWF_Process = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strWF_Process).Tables[0];
            //意见表
            var strCrmIdeaList = string.Format("select * from CrmIdeaList where [Type] = 0 and ResourceID='{0}' and ProcessID='{1}'  order by CreateOn ", resourceId, dtWF_Process.Rows[0]["Id"].ToString());
            DataTable dtCrmIdeaList = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmIdeaList).Tables[0];
            if (dtCrmIdeaList.Rows.Count > 0)
            {
                //遍历意见表数据
                for (int i = 0; i < dtCrmIdeaList.Rows.Count; i++)
                {
                    if (i == 3)
                    {
                        LeaderDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                }
            }
            #endregion

            #region 变量赋值
            if (dtCASEINFO.Rows.Count > 0)
            {
                //立案 年 号
                string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
                Year = _listCaseInfoNo[0];
                Num = _listCaseInfoNo[1].Substring(0, 5);
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
            }
            if (dtCrmUser.Rows.Count > 0)
            {
                newRow["UndertakerFirstName"] = dtCrmUser.Rows[0]["RealName"].ToString();
                newRow["UndertakerMobile"] = dtCrmUser.Rows[0]["Mobile"].ToString();
            }
            newRow["LeaderDate"] = LeaderDate;
            newRow[""] = "";
            newRow[""] = "";
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 国土案情会商
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandMinutes(string resourceId)
        {
            string GetDateWeek = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("TargetName", typeof(string));            //对象名称
            dtAll.Columns.Add("CaseInfoNo", typeof(string));            //案件编号
            dtAll.Columns.Add("GetDateWeek", typeof(string));            //会商时间 星期几
            dtAll.Columns.Add("ItemAct", typeof(string));            //违法行为
            dtAll.Columns.Add("GistName", typeof(string));            //违反法规
            dtAll.Columns.Add("", typeof(string));            //
            dtAll.Columns.Add("", typeof(string));            //
            dtAll.Columns.Add("", typeof(string));            //
            dtAll.Columns.Add("", typeof(string));            //
            #endregion

            //案件基本信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            //执行处理情况
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);//案由
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];

            #region 变量赋值
            //获取当前时间星期几
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"))].ToString();
            GetDateWeek = DateTime.Now.ToString("yyyy年MM月dd日") + week;

            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
                newRow["CaseInfoNo"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();
            }
            newRow["GetDateWeek"] = GetDateWeek;
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["ItemAct"] = dtLEGISLATION.Rows[0]["ItemAct"].ToString();
                newRow["GistName"] = dtLEGISLATION.Rows[0]["GistName"].ToString();
            }
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 责令停止土地违法行为通知书*********
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandParkNotice(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseInfoNo", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("ItemAct", typeof(string));
            dtAll.Columns.Add("GistName", typeof(string));//违返法规
            dtAll.Columns.Add("DutyName", typeof(string));//处罚依据
            dtAll.Columns.Add("UndertakerFirstName", typeof(string));
            dtAll.Columns.Add("UndertakerMobile", typeof(string));
            dtAll.Columns.Add("", typeof(string));//机构负责人审批日期
            dtAll.Columns.Add("", typeof(string));//案件发生地所属功能区或街道
            #endregion

            //案件基本信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];

            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcRead, CommandType.Text, strLEGISLATION).Tables[0];
            //根据承办人id，查询姓名，联系方式
            var strCrmUser = string.Format("select * from CrmUser where id='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            DataTable dtCrmUser = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcRead, CommandType.Text, strCrmUser).Tables[0];

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["CaseInfoNo"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();
                newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
            }
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["ItemAct"] = dtLEGISLATION.Rows[0]["ItemAct"].ToString();
                newRow["GistName"] = dtLEGISLATION.Rows[0]["GistName"].ToString();
                newRow["DutyName"] = dtLEGISLATION.Rows[0]["DutyName"].ToString();
            }
            if (dtCrmUser.Rows.Count > 0)
            {
                newRow["UndertakerFirstName"] = dtCrmUser.Rows[0]["RealName"].ToString();
                newRow["UndertakerMobile"] = dtCrmUser.Rows[0]["Mobile"].ToString();
            }
            newRow[""] = "";
            newRow[""] = "";
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 国土资源违法案件调查报告
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandPollRecord(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("TargetName", typeof(string));            //对象名称
            dtAll.Columns.Add("AcceptDate", typeof(string));            //立案时间
            dtAll.Columns.Add("GetDate", typeof(string));            //当前时间
            dtAll.Columns.Add("AcceptCode", typeof(string));            //立案编号
            dtAll.Columns.Add("TargetUnit", typeof(string));            //单位名称
            dtAll.Columns.Add("TargetAddress", typeof(string));            //地址
            dtAll.Columns.Add("CaseAddress", typeof(string));            //案发地址
            dtAll.Columns.Add("", typeof(string));            //
            dtAll.Columns.Add("", typeof(string));            //
            dtAll.Columns.Add("", typeof(string));            //
            dtAll.Columns.Add("", typeof(string));            //
            dtAll.Columns.Add("", typeof(string));            //

            dtAll.Columns.Add("UndertakerSecondName", typeof(string));            //办案人员一
            dtAll.Columns.Add("UndertakerFirstName", typeof(string));            //办案人员二

            #endregion
            //案件基本信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];

            #region 列赋值

            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
            newRow["AcceptDate"] = "";//立案时间
            newRow["AcceptCode"] = "";//立案编号
            newRow["TargetUnit"] = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
            newRow["TargetAddress"] = dtCASEINFO.Rows[0]["TargetAddress"].ToString();
            newRow["CaseAddress"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();
            newRow["GetDate"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 行政处罚决定书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandPunishDecision(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("TargetAddress", typeof(string));
            dtAll.Columns.Add("AcceptTime", typeof(string));  //立案时间
            dtAll.Columns.Add("ItemAct", typeof(string));
            dtAll.Columns.Add("GistName", typeof(string));
            dtAll.Columns.Add("DutyName", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));

            #endregion

            //案件基本信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];

            #region 变量赋值
            if (dtCASEINFO.Rows.Count > 0)
            {
                //立案 年 号
                string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
                Year = _listCaseInfoNo[0];
                Num = _listCaseInfoNo[1].Substring(0, 5);
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
                newRow["TargetAddress"] = dtCASEINFO.Rows[0]["TargetAddress"].ToString();
            }
            newRow["AcceptTime"] = "";
            newRow["ItemAct"] = "";
            newRow["GistName"] = "";
            newRow["DutyName"] = "";

            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 行政处罚听证告知书******
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandPunishHearing(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            string LeaderDate = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("", typeof(string));//引用A（面积替换为测绘后面积）
            dtAll.Columns.Add("", typeof(string));//引用C

            dtAll.Columns.Add("UndertakerFirstName", typeof(string)); //办案人
            dtAll.Columns.Add("UndertakerMobile", typeof(string)); //办案人联系电话
            dtAll.Columns.Add("LeaderDate", typeof(string)); //局领导最后审批日期
            #endregion

            //案件基本信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            //根据承办人id，查询姓名，联系方式
            var strCrmUser = string.Format("select * from CrmUser where id='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            DataTable dtCrmUser = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringDsfxcRead, CommandType.Text, strCrmUser).Tables[0];
            //立案 年 号
            string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
            Year = _listCaseInfoNo[0];
            Num = _listCaseInfoNo[1].Substring(0, 5);
            #region 获取局领导最后审批时间
            //查询文书类型
            var strWF_Process = string.Format("select * from WF_Process where FullName = '国土处罚决定审批'");
            DataTable dtWF_Process = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strWF_Process).Tables[0];
            //意见表
            var strCrmIdeaList = string.Format("select * from CrmIdeaList where [Type] = 0 and ResourceID='{0}' and ProcessID='{1}'  order by CreateOn ", resourceId, dtWF_Process.Rows[0]["Id"].ToString());
            DataTable dtCrmIdeaList = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmIdeaList).Tables[0];
            if (dtCrmIdeaList.Rows.Count > 0)
            {
                //遍历意见表数据
                for (int i = 0; i < dtCrmIdeaList.Rows.Count; i++)
                {
                    if (i == 3)
                    {
                        LeaderDate = dtCrmIdeaList.Rows[i]["CreateOn"].ToString();
                    }
                }
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
            newRow[""] = "";
            newRow[""] = "";
            if (dtCrmUser.Rows.Count > 0)
            {
                newRow["UndertakerFirstName"] = dtCrmUser.Rows[0]["RealName"].ToString();
                newRow["UndertakerMobile"] = dtCrmUser.Rows[0]["Mobile"].ToString();
            }
            newRow["LeaderDate"] = LeaderDate;
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 询问笔录*********
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandRecord(string resourceId)
        {

            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseInfoNo", typeof(string));        //案件编号
            dtAll.Columns.Add("ItemName", typeof(string)); 		//案由名称
            dtAll.Columns.Add("TargetType", typeof(string));		        //当事人类型           
            dtAll.Columns.Add("Address", typeof(string));		    //询问地点 
            dtAll.Columns.Add("StartDate", typeof(string));//开始时间
            dtAll.Columns.Add("EndDate", typeof(string));//结束时间
            dtAll.Columns.Add("QuestionerFirstName", typeof(string));  //调查人一姓名
            dtAll.Columns.Add("QuestionerSecondName", typeof(string)); //调查人二姓名
            dtAll.Columns.Add("FirstCode", typeof(string));      //调查人一证件号
            dtAll.Columns.Add("SecondCode", typeof(string));     //调查人二证件号
            dtAll.Columns.Add("RecordsName", typeof(string));		   //记录人姓名    
            dtAll.Columns.Add("TargetName", typeof(string));	    //被调查人
            dtAll.Columns.Add("TargetAddress", typeof(string));   //被调查人地址
            dtAll.Columns.Add("TargetPaperNum", typeof(string)); //被调查人证件号码
            dtAll.Columns.Add("TargetPhone", typeof(string));  //电话
            dtAll.Columns.Add("", typeof(string));   //与本案关系
            dtAll.Columns.Add("RecordInfo", typeof(string));  //询问内容
            dtAll.Columns.Add("UndertakerFirstSignName", typeof(string));
            dtAll.Columns.Add("UndertakerSecondSignName", typeof(string));//承办人（二）签名
            #endregion

            var strRECORD = string.Format("SELECT * FROM INF_PUNISH_RECORD where CaseInfoId ='{0}'", resourceId);
            DataTable dtRECORD = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strRECORD).Tables[0];
            var strCASEINFO = string.Format("SELECT *  FROM INF_PUNISH_CASEINFO where ID='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            var strCrmUserSignFirst = string.Format("SELECT  *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strCrmUserSignSecond = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());

            var strBase_CertificateFirst = string.Format("SELECT * FROM Base_Certificate where UserId='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strBase_CertificateSecond = string.Format("SELECT * FROM Base_Certificate where UserId='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());
            DataTable dtCrmUserSignFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignFirst).Tables[0];
            DataTable dtCrmUserSignSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignSecond).Tables[0];
            DataTable dtBase_CertificateFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strBase_CertificateFirst).Tables[0];
            DataTable dtBase_CertificateSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strBase_CertificateSecond).Tables[0];

            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["CaseInfoNo"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();
                newRow["TargetType"] = dtCASEINFO.Rows[0]["TargetType"].ToString();
            }
            if (dtRECORD.Rows.Count > 0)
            {
                newRow["ItemName"] = dtRECORD.Rows[0]["ItemName"].ToString();
                newRow["StartDate"] = dtRECORD.Rows[0]["StartDate"].ToString();
                newRow["EndDate"] = dtRECORD.Rows[0]["EndDate"].ToString();
                newRow["Address"] = dtRECORD.Rows[0]["Address"].ToString();
                newRow["QuestionerFirstName"] = dtRECORD.Rows[0]["QuestionerFirstName"].ToString();
                newRow["QuestionerSecondName"] = dtRECORD.Rows[0]["QuestionerSecondName"].ToString();
                newRow["TargetAddress"] = dtRECORD.Rows[0]["TargetAddress"].ToString();
                newRow["TargetPaperNum"] = dtRECORD.Rows[0]["TargetPaperNum"].ToString();
                newRow["RecordsName"] = dtRECORD.Rows[0]["RecordsName"].ToString();
                newRow["TargetName"] = dtRECORD.Rows[0]["TargetName"].ToString();
                newRow["TargetPhone"] = dtRECORD.Rows[0]["TargetPhone"].ToString();
                newRow["RecordInfo"] = dtRECORD.Rows[0]["RecordInfo"].ToString();
            }
            newRow["FirstCode"] = dtBase_CertificateFirst.Rows[0]["CertificateNo"].ToString();
            newRow["SecondCode"] = dtBase_CertificateSecond.Rows[0]["CertificateNo"].ToString();
            newRow["UndertakerFirstSignName"] = dtCrmUserSignFirst.Rows[0]["SignAddress"].ToString();
            newRow["UndertakerSecondSignName"] = dtCrmUserSignSecond.Rows[0]["SignAddress"].ToString();
            newRow[""] = "";//与本案关系
            dtAll.Rows.Add(newRow);

            #endregion
            return dtAll;
        }

        /// <summary>
        /// 国土立案呈批表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandRegistration(string resourceId)
        {
            string UndertakerIdea = string.Empty;
            string UndertakerDate = string.Empty;
            string LegalSignIdea = string.Empty;
            string LegalSignName = string.Empty;
            string LegalSignDate = string.Empty;
            string ChargeIdea = string.Empty;
            string ChargeName = string.Empty;
            string ChargeDate = string.Empty;
            string LeaderIdea = string.Empty;
            string LeaderName = string.Empty;
            string LeaderDate = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseInfoNo", typeof(string));
            dtAll.Columns.Add("ItemName", typeof(string));    //案由名称
            dtAll.Columns.Add("TargetName", typeof(string));  	 //姓名
            dtAll.Columns.Add("TargetPhone", typeof(string));  	 //联系电话
            dtAll.Columns.Add("CaseFact", typeof(string));  		 //案情摘要
            dtAll.Columns.Add("UndertakerIdea", typeof(string));    //经办人意见，时间
            dtAll.Columns.Add("UndertakerDate", typeof(string));

            dtAll.Columns.Add("LegalSignIdea", typeof(string));  	 //执法监察工作机构意见，签名，时间
            dtAll.Columns.Add("LegalSignName", typeof(string));
            dtAll.Columns.Add("LegalSignDate", typeof(string));

            dtAll.Columns.Add("ChargeIdea", typeof(string));  	 //分管领导意见，签名，时间
            dtAll.Columns.Add("ChargeName", typeof(string));
            dtAll.Columns.Add("ChargeDate", typeof(string));

            dtAll.Columns.Add("LeaderIdea", typeof(string));  	 //局审批意见，签名，时间
            dtAll.Columns.Add("LeaderName", typeof(string));
            dtAll.Columns.Add("LeaderDate", typeof(string));

            dtAll.Columns.Add("UndertakerFirstSignName", typeof(string));//经办人（一）签名
            dtAll.Columns.Add("UndertakerSecondSignName", typeof(string));//经办人（二）签名
            #endregion
            //案件基本信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];
            //经办人签字
            var strCrmUserSignFirst = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            var strCrmUserSignSecond = string.Format("SELECT *  FROM CrmUserSign  where SignType = '00310001'AND UserId ='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdSecond"].ToString());

            DataTable dtCrmUserSignFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignFirst).Tables[0];
            DataTable dtCrmUserSignSecond = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignSecond).Tables[0];


            #region 各个部门 签名、签字意见及审批日期
            //查询文书类型
            var strWF_Process = string.Format("select * from WF_Process where FullName = '国土立案审批'");
            DataTable dtWF_Process = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strWF_Process).Tables[0];
            //意见表
            var strCrmIdeaList = string.Format("select * from CrmIdeaList where [Type] = 0 and ResourceID='{0}' and ProcessID='{1}'  order by CreateOn ", resourceId, dtWF_Process.Rows[0]["Id"].ToString());
            DataTable dtCrmIdeaList = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmIdeaList).Tables[0];
            if (dtCrmIdeaList.Rows.Count > 0)
            {
                //遍历意见表数据
                for (int i = 0; i < dtCrmIdeaList.Rows.Count; i++)
                {
                    var strCrmUserSign = string.Format("select * from CrmUserSign where SignType = '00310001' AND UserId='{0}'", dtCrmIdeaList.Rows[i]["UserId"].ToString());
                    var strCrmUserSignIdea = string.Format("select * from CrmUserSign where SignType = '00310002' AND UserId='{0}'", dtCrmIdeaList.Rows[i]["UserId"].ToString());
                    DataTable dtCrmUserSign = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSign).Tables[0];
                    DataTable dtCrmUserSignIdea = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUserSignIdea).Tables[0];
                    if (i == 0)
                    {
                        UndertakerIdea = dtCrmUserSign.Rows[0]["Idea"].ToString();
                        UndertakerDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日");
                    }
                    else if (i == 1)
                    {
                        LegalSignName = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        LegalSignIdea = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        LegalSignDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日"); ;
                    }
                    else if (i == 2)
                    {
                        ChargeIdea = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        ChargeName = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        ChargeDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日"); ;
                    }
                    else if (i == 3)
                    {
                        LeaderIdea = dtCrmUserSign.Rows[0]["SignAddress"].ToString();
                        LeaderName = dtCrmUserSignIdea.Rows[0]["SignAddress"].ToString();
                        LeaderDate = DateTime.Parse(dtCrmIdeaList.Rows[i]["CreateOn"].ToString()).ToString("yyyy年MM月dd日"); ;
                    }
                }
            }

            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["CaseInfoNo"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();     //编码
                newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();  	 //姓名
                newRow["TargetPhone"] = dtCASEINFO.Rows[0]["TargetPhone"].ToString();  	 //联系电话
                newRow["CaseFact"] = dtCASEINFO.Rows[0]["CaseFact"].ToString();  		 //案情摘要
            }
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["ItemName"] = dtLEGISLATION.Rows[0]["ItemName"].ToString();      //案由
            }
            newRow["UndertakerIdea"] = UndertakerIdea;    //经办人意见，时间
            newRow["UndertakerDate"] = UndertakerDate;

            newRow["LegalSignIdea"] = LegalSignIdea;  	 //执法监察工作机构意见，签名，时间
            newRow["LegalSignName"] = LegalSignName;
            newRow["LegalSignDate"] = LegalSignDate;

            newRow["ChargeIdea"] = ChargeIdea;  	 //分管领导意见，签名，时间
            newRow["ChargeName"] = ChargeName;
            newRow["ChargeDate"] = ChargeDate;

            newRow["LeaderIdea"] = LeaderIdea;  	 //局审批意见，签名，时间
            newRow["LeaderName"] = LeaderName;
            newRow["LeaderDate"] = LeaderDate;

            newRow["UndertakerFirstSignName"] = dtCrmUserSignFirst.Rows[0]["SignAddress"].ToString();
            newRow["UndertakerSecondSignName"] = dtCrmUserSignSecond.Rows[0]["SignAddress"].ToString();
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }


        /// <summary>
        /// 违法案件审理(法制审核)记录
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandTrialRecord(string resourceId)
        {
            string GetDateWeek = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseInfoNo", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("GetDateWeek", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));

            #endregion
            //案件基本信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];

            #region 变量赋值
            //获取当前时间 星期几
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"))].ToString();
            GetDateWeek = DateTime.Now.ToString("yyyy年MM月dd日") + week;

            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["CaseInfoNo"] = dtCASEINFO.Rows[0]["CaseInfoNo"];
            newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"];
            newRow["GetDateWeek"] = GetDateWeek;
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";

            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 关于查处对象名称涉嫌非法占地问题核查情况的报告
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable LandVerificationRecord(string resourceId)
        {
            string AcceptDate = string.Empty; //立案时间
            string AcceptName = string.Empty;//立案报告人员

            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("TargetName", typeof(string));  	 //姓名
            dtAll.Columns.Add("AcceptDate", typeof(string));  	 //立案日期
            dtAll.Columns.Add("AcceptName", typeof(string));  	 //立案人员
            dtAll.Columns.Add("ItemAct", typeof(string));  	 //违法行为
            dtAll.Columns.Add("GistName", typeof(string));  	 //违反法规
            #endregion
            //案件基本信息
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];

            #region 立案日期
            var strWF_Processla = string.Format("select * from WF_Process where FullName = '立案审批'");
            DataTable dtWF_Processla = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strWF_Processla).Tables[0];
            var strCrmIdeaListla = string.Format("select * from CrmIdeaList where [Type] = 0 and ResourceID='{0}' and ProcessID='{1}'  order by CreateOn ", resourceId, dtWF_Processla.Rows[0]["Id"].ToString());
            DataTable dtCrmIdeaListla = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmIdeaListla).Tables[0];
            for (int i = 0; i < dtCrmIdeaListla.Rows.Count; i++)
            {
                var strCrmUser = string.Format("select * from CrmUser  where id='{0}'", dtCrmIdeaListla.Rows[i]["UserId"].ToString());
                DataTable dtCrmUser = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCrmUser).Tables[0];
                if (i == 0)
                {
                    AcceptDate = dtCrmIdeaListla.Rows[i]["CreateOn"].ToString();
                    AcceptName = dtCrmUser.Rows[0]["RealName"].ToString();
                }
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
            newRow["AcceptDate"] = AcceptDate;
            newRow["AcceptName"] = AcceptName;
            if (dtLEGISLATION.Rows.Count > 0)
            {
                newRow["ItemAct"] = dtLEGISLATION.Rows[0]["ItemAct"].ToString();
                newRow["GistName"] = dtLEGISLATION.Rows[0]["GistName"].ToString();
            }
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        #endregion


        #region 水利文书查询

        /// <summary>
        /// 立案审批表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterRegistration(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            string TargetName = string.Empty;//个人
            string TargetGender = string.Empty;
            string TargetAddress = string.Empty;
            string UnitLeader = string.Empty; //公司
            string TargetUnit = string.Empty;
            string UnitAddress = string.Empty;
            string TargetDuty = string.Empty;
            string TargetZipCode = string.Empty;
            string Mobile = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("ItemName", typeof(string));       //案件来源
            dtAll.Columns.Add("CaseAddress", typeof(string));    //案发地址
            dtAll.Columns.Add("CaseDate", typeof(string));       //案发时间
            dtAll.Columns.Add("TargetName", typeof(string));     //当事人姓名
            dtAll.Columns.Add("TargetGender", typeof(string));   //性别
            dtAll.Columns.Add("TargetMobile", typeof(string));    //个人电话
            dtAll.Columns.Add("TargetAddress", typeof(string));    //住址
            dtAll.Columns.Add("UnitMobile", typeof(string));    //电话
            dtAll.Columns.Add("UnitLeader", typeof(string));    //单位名称
            dtAll.Columns.Add("TargetUnit", typeof(string));    //法定代表人
            dtAll.Columns.Add("TargetDuty", typeof(string));    //职务
            dtAll.Columns.Add("UnitAddress", typeof(string));    //住址
            dtAll.Columns.Add("TargetZipCode", typeof(string));    //邮编
            dtAll.Columns.Add("CaseFact", typeof(string));    //案情简介
            dtAll.Columns.Add("", typeof(string));    //执法机构负责人
            dtAll.Columns.Add("", typeof(string));    //执法机关负责人
            dtAll.Columns.Add("", typeof(string));    //备注

            #endregion
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];

            #region 变量赋值
            if (dtCASEINFO.Rows.Count > 0)
            {
                //立案 年 号
                string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
                Year = _listCaseInfoNo[0];
                Num = _listCaseInfoNo[1];

                //当事人类型
                if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120002")
                {
                    UnitLeader = dtCASEINFO.Rows[0]["TargetName"].ToString();//公司
                    TargetUnit = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
                    UnitAddress = dtCASEINFO.Rows[0]["UnitAddress"].ToString();
                    TargetDuty = dtCASEINFO.Rows[0]["TargetDuty"].ToString();
                    TargetZipCode = dtCASEINFO.Rows[0]["TargetZipCode"].ToString();
                    TargetName = string.Empty;//个人
                    TargetGender = string.Empty;
                    TargetAddress = string.Empty;
                    Mobile = dtCASEINFO.Rows[0]["TargetMobile"].ToString();
                }
                else
                {
                    TargetName = dtCASEINFO.Rows[0]["TargetName"].ToString();//个人
                    if (dtCASEINFO.Rows[0]["TargetGender"].ToString() == "1")
                    {
                        TargetGender = "男";
                    }
                    else
                    {
                        TargetGender = "女";
                    }
                    TargetAddress = dtCASEINFO.Rows[0]["TargetAddress"].ToString();
                    TargetZipCode = dtCASEINFO.Rows[0]["TargetZipCode"].ToString();
                    UnitLeader = string.Empty;//公司 
                    TargetUnit = string.Empty;
                    UnitAddress = string.Empty;
                    TargetDuty = string.Empty;
                    Mobile = dtCASEINFO.Rows[0]["TargetMobile"].ToString();
                }
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            newRow["ItemName"] = dtCASEINFO.Rows[0]["ItemName"].ToString();       //案件来源
            newRow["CaseAddress"] = dtCASEINFO.Rows[0]["CaseAddress"].ToString();   //案发地址
            newRow["CaseDate"] = dtCASEINFO.Rows[0]["CaseDate"].ToString();     //案发时间
            newRow["TargetName"] = TargetName;     //当事人姓名
            newRow["TargetGender"] = TargetGender;   //性别
            newRow["TargetMobile"] = Mobile;    //个人电话
            newRow["TargetAddress"] = TargetAddress;    //住址
            newRow["UnitLeader"] = UnitLeader;    //单位名称
            newRow["TargetUnit"] = TargetUnit;    //法定代表人
            newRow["TargetDuty"] = TargetDuty;    //职务
            newRow["UnitAddress"] = UnitAddress;    //住址
            newRow["TargetZipCode"] = TargetZipCode;    //邮编 CaseFact
            newRow["CaseFact"] = dtCASEINFO.Rows[0]["CaseFact"].ToString();     //案情摘要
            newRow[""] = "";    //
            newRow[""] = "";    //
            newRow[""] = "";    //

            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 调查笔录
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPollRecord(string resourceId)
        {
            string StartDate = string.Empty;
            string EndDate = string.Empty;
            string TargetGender = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("StartDate", typeof(string));       //开始时间
            dtAll.Columns.Add("EndDate", typeof(string));         //结束时间
            dtAll.Columns.Add("TargetName", typeof(string));        //被调查人
            dtAll.Columns.Add("TargetGender", typeof(string));      //性别
            dtAll.Columns.Add("TargetAge", typeof(string));         //年龄
            dtAll.Columns.Add("TargetPaperNum", typeof(string));  //身份证 
            dtAll.Columns.Add("TagetAddrerss", typeof(string));    //住址
            dtAll.Columns.Add("TargetUnit", typeof(string));         //单位
            dtAll.Columns.Add("TargetDuty", typeof(string));          //职务
            dtAll.Columns.Add("TargetPhone", typeof(string));    //电话
            dtAll.Columns.Add("FirstCode", typeof(string));        //调查人
            dtAll.Columns.Add("RecordsName", typeof(string));     //记录人
            dtAll.Columns.Add("RecordInfo", typeof(string));     //调查内容

            #endregion
            //案件基本信息查询
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];

            var strRECORD = string.Format("SELECT * FROM INF_PUNISH_RECORD where CaseInfoId ='{0}'", resourceId);
            DataTable dtRECORD = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strRECORD).Tables[0];

            var strBase_CertificateFirst = string.Format("SELECT * FROM Base_Certificate where UserId='{0}'", dtCASEINFO.Rows[0]["UdPersonelIdFirst"].ToString());
            DataTable dtBase_CertificateFirst = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strBase_CertificateFirst).Tables[0];
            #region 变量赋值
            if (dtCASEINFO.Rows.Count > 0)
            {
                if (dtCASEINFO.Rows[0]["TargetGender"].ToString() == "1")
                {
                    TargetGender = "男";
                }
                else
                {
                    TargetGender = "女";
                }
            }

            #endregion

            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["StartDate"] = StartDate;
            newRow["EndDate"] = EndDate;
            newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
            newRow["TargetGender"] = TargetGender;
            newRow["TargetAge"] = dtCASEINFO.Rows[0]["TargetAge"].ToString();
            newRow["TargetPaperNum"] = dtCASEINFO.Rows[0]["TargetPaperNum"].ToString();
            newRow["TagetAddrerss"] = dtCASEINFO.Rows[0]["TagetAddrerss"].ToString();
            newRow["TargetUnit"] = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
            newRow["TargetDuty"] = dtCASEINFO.Rows[0]["TargetDuty"].ToString();
            newRow["TargetPhone"] = dtCASEINFO.Rows[0]["TargetPhone"].ToString();
            newRow["FirstCode"] = dtBase_CertificateFirst.Rows[0]["CertificateNo"].ToString(); //调查人员
            newRow["RecordsName"] = dtRECORD.Rows[0]["RecordsName"].ToString();     //记录人员
            newRow["RecordInfo"] = dtCASEINFO.Rows[0]["RecordInfo"].ToString();
            newRow[""] = "";

            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }


        /// <summary>
        /// 行政处罚告知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPunishInform(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));        //姓名
            dtAll.Columns.Add("ItemAct", typeof(string));        //违法行为
            dtAll.Columns.Add("GistName", typeof(string));        //违反法规
            dtAll.Columns.Add("DutyName", typeof(string));        //处罚依据
            dtAll.Columns.Add("StipulateFirst", typeof(string));        //处罚内容1
            dtAll.Columns.Add("StipulateSecond", typeof(string));        //处罚内容2
            dtAll.Columns.Add("StipulateThree", typeof(string));        //处罚内容3
            dtAll.Columns.Add("", typeof(string));        //
            dtAll.Columns.Add("", typeof(string));        //
            dtAll.Columns.Add("", typeof(string));        //

            #endregion
            //案件基本信息查询
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            //处罚决定书
            var strDECISION = string.Format("SELECT * FROM INF_PUNISH_DECISION  WHERE CaseInfoId='{0}'", resourceId);
            DataTable dtDECISION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strDECISION).Tables[0];

            #region 变量赋值
            //年，号
            string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
            Year = _listCaseInfoNo[0];
            Num = _listCaseInfoNo[1];
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
            newRow["ItemAct"] = dtDECISION.Rows[0]["ItemAct"].ToString();
            newRow["GistName"] = dtDECISION.Rows[0]["GistName"].ToString();
            newRow["DutyName"] = dtDECISION.Rows[0]["DutyName"].ToString();
            newRow["StipulateFirst"] = "";
            newRow["StipulateSecond"] = "";
            newRow["StipulateThree"] = "";
            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }

        /// <summary>
        ///  行政处罚决定审批表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPunishExamination(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("ItemName", typeof(string));  //案由
            dtAll.Columns.Add("PartiesInfo", typeof(string)); //当事人情况
            dtAll.Columns.Add("PunishContent", typeof(string)); //处罚告知或听证告知情况
            dtAll.Columns.Add("HearContent", typeof(string));   //陈述、申辩或听证情况
            dtAll.Columns.Add("UndertakerIdea", typeof(string));   //处罚意见

            dtAll.Columns.Add("", typeof(string));    //执法机构负责人
            dtAll.Columns.Add("", typeof(string));    //执法机关负责人
            dtAll.Columns.Add("", typeof(string));    //法机关负责人意见

            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";

            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        ///  行政处罚决定书（简易程序）
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPunishDecisionSimple(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            string TargetName = string.Empty;
            string TargetGender = string.Empty;

            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));        //被处罚人（单位）
            dtAll.Columns.Add("TargetUnit", typeof(string));        //法人代表
            dtAll.Columns.Add("TargetGender", typeof(string));      //性别
            dtAll.Columns.Add("TargetAge", typeof(string));         //年龄
            dtAll.Columns.Add("TargetDuty", typeof(string));        //职务
            dtAll.Columns.Add("TagetAddrerss", typeof(string));     //住所地
            dtAll.Columns.Add("ItemAct", typeof(string));           //违法行为
            dtAll.Columns.Add("GistName", typeof(string));          //违反法规
            dtAll.Columns.Add("DutyName", typeof(string));          //处罚依据
            dtAll.Columns.Add("PunishContent", typeof(string));     //处罚内容
            dtAll.Columns.Add("PunishAmount", typeof(string));      //处罚金额
            dtAll.Columns.Add("CaseDate", typeof(string));          //时间
            dtAll.Columns.Add("CaseAddr", typeof(string));          //地址
            #endregion
            //案件基本信息查询
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            //处罚决定书
            var strDECISION = string.Format("select * from INF_PUNISH_DECISION where CaseInfoId='{0}'", resourceId);
            DataTable dtDECISION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strDECISION).Tables[0];

            #region 变量赋值
            //立案 年 号
            if (dtCASEINFO.Rows.Count > 0)
            {

                string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
                Year = _listCaseInfoNo[0];
                Num = _listCaseInfoNo[1];
                //当事人类型
                if (dtCASEINFO.Rows[0]["TargetType"].ToString() == "00120002")//法人
                {
                    TargetName = dtCASEINFO.Rows[0]["TargetUnit"].ToString();//个人
                }
                else
                {
                    TargetName = dtCASEINFO.Rows[0]["TargetName"].ToString();//个人
                }
                if (dtCASEINFO.Rows[0]["TargetGender"].ToString() == "1")
                {
                    TargetGender = "男";
                }
                else
                {
                    TargetGender = "女";
                }
            }
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            newRow["TargetName"] = TargetName;
            newRow["TargetUnit"] = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
            newRow["TargetGender"] = TargetGender;
            newRow["TargetAge"] = dtCASEINFO.Rows[0]["TargetAge"].ToString();
            newRow["TargetDuty"] = dtCASEINFO.Rows[0]["TargetDuty"].ToString();
            newRow["TagetAddrerss"] = dtCASEINFO.Rows[0]["TagetAddrerss"].ToString();
            newRow["ItemAct"] = dtDECISION.Rows[0]["ItemAct"].ToString();
            newRow["GistName"] = dtDECISION.Rows[0]["GistName"].ToString();
            newRow["DutyName"] = dtDECISION.Rows[0]["DutyName"].ToString();
            newRow["PunishContent"] = dtDECISION.Rows[0]["PunishContent"].ToString();
            newRow["PunishAmount"] = dtDECISION.Rows[0]["PunishAmount"].ToString();
            newRow["CaseDate"] = dtDECISION.Rows[0]["CaseDate"].ToString();
            newRow["CaseAddr"] = dtDECISION.Rows[0]["CaseAddr"].ToString();

            dtAll.Rows.Add(newRow);

            #endregion
            return dtAll;
        }

        /// <summary>
        ///  行政处罚决定书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPunishDecision(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            string TargetGender = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));        //被处罚人（单位）
            dtAll.Columns.Add("TargetPaperNum", typeof(string));      //身份证号/营业执照
            dtAll.Columns.Add("TargetUnit", typeof(string));        //法人代表
            dtAll.Columns.Add("TargetGender", typeof(string));      //性别
            dtAll.Columns.Add("TargetDuty", typeof(string));      //职务
            dtAll.Columns.Add("TagetAddrerss", typeof(string));      //住所地
            dtAll.Columns.Add("TargetZipCode", typeof(string));      //邮编
            dtAll.Columns.Add("TargetMobile", typeof(string));      //电话
            dtAll.Columns.Add("ResourceDate", typeof(string));      //来源时间
            dtAll.Columns.Add("Resource", typeof(string));      //案件来源
            dtAll.Columns.Add("", typeof(string));      //
            dtAll.Columns.Add("", typeof(string));      //
            dtAll.Columns.Add("", typeof(string));      //
            dtAll.Columns.Add("", typeof(string));      //
            dtAll.Columns.Add("", typeof(string));      //

            #endregion
            //案件基本信息查询
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            //处罚决定书
            var strDECISION = string.Format("select * from INF_PUNISH_DECISION where CaseInfoId='{0}'", resourceId);
            DataTable dtDECISION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strDECISION).Tables[0];

            #region 变量赋值
            if (dtCASEINFO.Rows.Count > 0)
            {

                //立案 年 号
                string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
                Year = _listCaseInfoNo[0];
                Num = _listCaseInfoNo[1];
                if (dtCASEINFO.Rows[0]["TargetGender"].ToString() == "1")
                {
                    TargetGender = "男";
                }
                else
                {
                    TargetGender = "女";
                }
            }

            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
            newRow["TargetPaperNum"] = dtCASEINFO.Rows[0]["TargetPaperNum"].ToString();
            newRow["TargetUnit"] = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
            newRow["TargetGender"] = TargetGender;
            newRow["TargetDuty"] = dtCASEINFO.Rows[0]["TargetDuty"].ToString();
            newRow["TagetAddrerss"] = dtCASEINFO.Rows[0]["TagetAddrerss"].ToString();
            newRow["TargetZipCode"] = dtCASEINFO.Rows[0]["TargetZipCode"].ToString();
            newRow["ResourceDate"] = "";
            newRow["Resource"] = "";
            newRow[""] = "";
            newRow[""] = "";

            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }


        /// <summary>
        ///  送达回证
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterCaceBackCard(string resourceId)
        { //整合数据
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("ItemName", typeof(string));
            dtAll.Columns.Add("ReceiptAddress", typeof(string));//送达地点
            dtAll.Columns.Add("SigninPerson", typeof(string));//受送达人
            dtAll.Columns.Add("SinginDate", typeof(string));//收到时间
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("ReceiptSignName", typeof(string));
            dtAll.Columns.Add("ReceiptType", typeof(string));
            #endregion
            //调查询问笔录
            var strRECORD = string.Format("SELECT  *  FROM  INF_PUNISH_RECORD    WHERE   CaseInfoId ='{0}'", resourceId);
            var strRECEIPT = string.Format("SELECT  * FROM  INF_PUNISH_RECEIPT WHERE ServiceType=1 and   CaseInfoId ='{0}'", resourceId);
            var strCASEINFO = string.Format("SELECT * FROM INF_PUNISH_CASEINFO WHERE    ID ='{0}'", resourceId);

            DataTable dtRECORD = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strRECORD).Tables[0];
            DataTable dtRECEIPT = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strRECEIPT).Tables[0];
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];

            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["ItemName"] = dtCASEINFO.Rows[0]["ItemName"];
            newRow["ReceiptAddress"] = dtRECEIPT.Rows[0]["ReceiptAddress"];
            newRow["SigninPerson"] = dtRECEIPT.Rows[0]["SigninPerson"];
            newRow["SinginDate"] = dtRECEIPT.Rows[0]["SinginDate"];
            newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"];
            newRow["ReceiptType"] = dtRECEIPT.Rows[0]["ReceiptType"];
            newRow["ReceiptSignName"] = dtRECEIPT.Rows[0]["ReceiptSignName"];
            newRow[""] = "";
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }







        /// <summary>
        /// 行政执法巡查记录
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPunishSearch(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseInfoNo", typeof(string));       //编号

            #endregion

            #region 列赋值

            #endregion

            return dtAll;
        }

        /// <summary>
        /// 举报记录
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterReportRecord(string resourceId)
        {
            string ReportYear = string.Empty;
            string ReportMonth = string.Empty;
            string ReportDay = string.Empty;
            string ReportHour = string.Empty;
            string ReportMinute = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseInfoNo", typeof(string));       //编号
            dtAll.Columns.Add("ReportData", typeof(string));       //举报时间
            dtAll.Columns.Add("ReportName", typeof(string));       //姓名
            dtAll.Columns.Add("ReportMobile", typeof(string));       //联系电话
            dtAll.Columns.Add("ReportAddress", typeof(string));       //举报人地址
            dtAll.Columns.Add("Name", typeof(string));       //被举报人 姓名
            dtAll.Columns.Add("Address", typeof(string));       //被举报人 地址
            dtAll.Columns.Add("CaseFact", typeof(string));       //举报内容
            dtAll.Columns.Add("", typeof(string));       //
            dtAll.Columns.Add("", typeof(string));       //
            dtAll.Columns.Add("", typeof(string));       //
            dtAll.Columns.Add("", typeof(string));       //
            dtAll.Columns.Add("", typeof(string));       //

            #endregion
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];

            #region 变量赋值

            //获取举报时间
            ReportYear = DateTime.Parse(dtCASEINFO.Rows[0]["ReportData"].ToString()).Year.ToString();
            ReportMonth = DateTime.Parse(dtCASEINFO.Rows[0]["ReportData"].ToString()).Month.ToString();
            ReportDay = DateTime.Parse(dtCASEINFO.Rows[0]["ReportData"].ToString()).Day.ToString();
            ReportHour = DateTime.Parse(dtCASEINFO.Rows[0]["ReportData"].ToString()).Hour.ToString();
            ReportMinute = DateTime.Parse(dtCASEINFO.Rows[0]["ReportData"].ToString()).Minute.ToString();
            #endregion

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["CaseInfoNo"] = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString();
            newRow["ReportData"] = ReportYear + "年" + ReportMonth + "月" + ReportDay + "日" + ReportHour + "时" + ReportMinute + "分";
            newRow["ReportName"] = dtCASEINFO.Rows[0]["ReportName"].ToString();
            newRow["ReportMobile"] = dtCASEINFO.Rows[0]["ReportMobile"].ToString();
            newRow["ReportAddress"] = dtCASEINFO.Rows[0]["ReportAddress"].ToString();
            newRow["Name"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
            newRow["Address"] = dtCASEINFO.Rows[0]["TargetAddress"].ToString();
            newRow["CaseFact"] = dtCASEINFO.Rows[0]["CaseFact"].ToString();
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 举报核查记录
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterReportReview(string resourceId)
        {

            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("CaseInfoNo", typeof(string));       //编号

            #endregion

            return dtAll;
        }


        /// <summary>
        /// 行政处罚指定管辖通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPunishNotice(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));

            #endregion


            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 案件移送函
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterTransfer(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));

            #endregion

            return dtAll;
        }


        /// <summary>
        /// 调查通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPollNotice(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("ItemAct", typeof(string));
            dtAll.Columns.Add("SevenDate", typeof(string));
            dtAll.Columns.Add("UndertakerAddress", typeof(string));
            dtAll.Columns.Add("UndertakerFirstName", typeof(string));
            dtAll.Columns.Add("UndertakerAddress", typeof(string));
            dtAll.Columns.Add("UndertakerMobile", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            #endregion
            //案件基本信息查询
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];

            #region 变量赋值
            string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
            Year = _listCaseInfoNo[0];
            Num = _listCaseInfoNo[1];

            #endregion

            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
            newRow["ItemAct"] = dtLEGISLATION.Rows[0]["ItemAct"].ToString();
            newRow["SevenDate"] = "";
            newRow["UndertakerAddress"] = "";
            newRow["UndertakerFirstName"] = "";
            newRow["UndertakerAddress"] = "";
            newRow["UndertakerMobile"] = "";
            newRow[""] = "";

            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 协助调查函
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterHelpPoll(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion


            return dtAll;
        }



        /// <summary>
        /// 勘验（检查）笔录
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterFieldInspectionRecord(string resourceId)
        {
            string StartDate = string.Empty;
            string EndDate = string.Empty;
            string TargetGender = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("StartDate", typeof(string));       //开始时间
            dtAll.Columns.Add("EndDate", typeof(string));         //结束时间
            dtAll.Columns.Add("TargetName", typeof(string));        //被调查人
            dtAll.Columns.Add("TargetGender", typeof(string));      //性别
            dtAll.Columns.Add("TargetAge", typeof(string));         //年龄
            dtAll.Columns.Add("TargetPaperNum", typeof(string));  //身份证 
            dtAll.Columns.Add("TagetAddrerss", typeof(string));    //住址
            dtAll.Columns.Add("TargetUnit", typeof(string));         //单位
            dtAll.Columns.Add("TargetDuty", typeof(string));          //职务
            #endregion
            //案件基本信息查询
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];

            #region 变量赋值
            if (dtCASEINFO.Rows.Count > 0)
            {
                if (dtCASEINFO.Rows[0]["TargetGender"].ToString() == "1")
                {
                    TargetGender = "男";
                }
                else
                {
                    TargetGender = "女";
                }
            }
            #endregion

            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["StartDate"] = StartDate;
            newRow["EndDate"] = EndDate;
            if (dtCASEINFO.Rows.Count > 0)
            {
                newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
                newRow["TargetGender"] = TargetGender;
                newRow["TargetAge"] = dtCASEINFO.Rows[0]["TargetAge"].ToString();
                newRow["TargetPaperNum"] = dtCASEINFO.Rows[0]["TargetPaperNum"].ToString();
                newRow["TagetAddrerss"] = dtCASEINFO.Rows[0]["TagetAddrerss"].ToString();
                newRow["TargetUnit"] = dtCASEINFO.Rows[0]["TargetUnit"].ToString();
                newRow["TargetDuty"] = dtCASEINFO.Rows[0]["TargetDuty"].ToString();
                newRow["TargetPhone"] = dtCASEINFO.Rows[0]["TargetPhone"].ToString();
            }
            dtAll.Rows.Add(dtAll);
            #endregion
            return dtAll;
        }

        /// <summary>
        /// 勘验图
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterFieldInspectionImage(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        /// 证据先行登记保存审批表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterProofNoteExamination(string resourceId)
        {

            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        /// 证据先行登记保存通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterProofNotice(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("TagetAddrerss", typeof(string));
            dtAll.Columns.Add("ItemAct", typeof(string));
            dtAll.Columns.Add("GistName", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));

            #endregion
            //案件基本信息查询
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];
            #region 变量赋值
            //年，号
            string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
            Year = _listCaseInfoNo[0];
            Num = _listCaseInfoNo[1];
            #endregion

            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
            newRow["TagetAddrerss"] = dtCASEINFO.Rows[0]["TagetAddrerss"].ToString();
            newRow["ItemAct"] = dtLEGISLATION.Rows[0]["ItemAct"].ToString();
            newRow["GistName"] = dtLEGISLATION.Rows[0]["GistName"].ToString();
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";

            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }


        /// <summary>
        /// 证据先行登记保存处理决定审批表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterProofActionExamination(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        /// 证据先行登记保存处理决定书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterProofAction(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("TagetAddrerss", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));

            #endregion
            //案件基本信息查询
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];

            #region 变量赋值
            //年，号
            string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
            Year = _listCaseInfoNo[0];
            Num = _listCaseInfoNo[1];
            #endregion

            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
            newRow["TagetAddrerss"] = dtCASEINFO.Rows[0]["TagetAddrerss"].ToString();
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";

            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }


        /// <summary>
        /// 采取扣押（暂扣）措施审批表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterSeizureExamination(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }
        /// <summary>
        /// 扣押（暂扣）通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterSeizureNotice(string resourceId)
        {
            string Year = string.Empty;
            string Num = string.Empty;
            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("Year", typeof(string));
            dtAll.Columns.Add("Num", typeof(string));
            dtAll.Columns.Add("TargetName", typeof(string));
            dtAll.Columns.Add("TagetAddrerss", typeof(string));
            dtAll.Columns.Add("ItemAct", typeof(string));
            dtAll.Columns.Add("GistName", typeof(string));
            dtAll.Columns.Add("DutyName", typeof(string));
            dtAll.Columns.Add("", typeof(string));

            #endregion
            //案件基本信息查询
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];
            var strLEGISLATION = string.Format("select * from INF_PUNISH_LEGISLATION where CaseInfoId='{0}'", resourceId);
            DataTable dtLEGISLATION = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strLEGISLATION).Tables[0];

            #region 变量赋值
            //年，号
            string[] _listCaseInfoNo = dtCASEINFO.Rows[0]["CaseInfoNo"].ToString().Split('-');
            Year = _listCaseInfoNo[0];
            Num = _listCaseInfoNo[1];
            #endregion

            #region 列 赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["Year"] = Year;
            newRow["Num"] = Num;
            newRow["TargetName"] = dtCASEINFO.Rows[0]["TargetName"].ToString();
            newRow["TagetAddrerss"] = dtCASEINFO.Rows[0]["TagetAddrerss"].ToString();
            newRow["ItemAct"] = dtLEGISLATION.Rows[0]["ItemAct"].ToString();
            newRow["GistName"] = dtLEGISLATION.Rows[0]["GistName"].ToString();
            newRow["DutyName"] = dtLEGISLATION.Rows[0]["DutyName"].ToString();
            newRow[""] = "";
            newRow[""] = "";
            newRow[""] = "";

            dtAll.Rows.Add(newRow);
            #endregion
            return dtAll;
        }
        /// <summary>
        /// 解除扣押（暂扣）审批表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterReleaseSeizureExamination(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }
        /// <summary>
        /// 解除扣押（暂扣）通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterReleaseSeizureNotice(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        /// 调查终结报告
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPollEndRecord(string resourceId)
        {
            string StartDate = string.Empty;
            string EndDate = string.Empty;
            string PartiesInfo = string.Empty;
            string CasesInfo = string.Empty;

            DataTable dtAll = new DataTable();
            #region 添加列
            dtAll.Columns.Add("ItemName", typeof(string));        //案由
            dtAll.Columns.Add("StartDate", typeof(string));       //开始时间
            dtAll.Columns.Add("EndDate", typeof(string));         //结束时间
            dtAll.Columns.Add("PartiesInfo", typeof(string));     //当事人情况
            dtAll.Columns.Add("CasesInfo", typeof(string));       //案件的由来及调查经过
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            dtAll.Columns.Add("", typeof(string));
            #endregion
            //案件基本信息查询
            var strCASEINFO = string.Format("select * from INF_PUNISH_CASEINFO where Id='{0}'", resourceId);
            DataTable dtCASEINFO = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strCASEINFO).Tables[0];

            #region 列赋值
            DataRow newRow;
            newRow = dtAll.NewRow();
            newRow["ItemName"] = "";
            newRow["StartDate"] = "";
            newRow["EndDate"] = "";
            newRow["PartiesInfo"] = "";
            newRow["CasesInfo"] = "";
            newRow[""] = "";
            newRow[""] = "";
            dtAll.Rows.Add(newRow);
            #endregion

            return dtAll;
        }

        /// <summary>
        /// 调查终结审批表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPollEndExamination(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        /// 负责人集体讨论记录
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterCollectiveRecord(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }


        /// <summary>
        /// 行政处罚听证通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPunishHearNotice(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }
        /// <summary>
        /// 延期（中止、终止）听证通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterDelayHearRecord(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }
        /// <summary>
        /// 行政处罚听证公告
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPunishHear(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }
        /// <summary>
        /// 听证笔录
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterHearRecord(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        /// 听证意见书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterHearIdea(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }
        /// <summary>
        /// 陈述、申辩笔录
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPleadRecord(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        ///  陈述、申辩或听证复核表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPleadReview(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }


        /// <summary>
        ///  征收通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterLevyNotice(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        ///  责令限期缴费通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterOrderNotice(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        ///  缓期（分期）缴费批准书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterDeadline(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        ///  行政强制执行审批表
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterForceExamination(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        ///  强制执行通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterForceNotice(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        ///  行政强制执行笔录
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterForceRecord(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }
        /// <summary>
        ///  强制执行申请书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterForceApply(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }
        /// <summary>
        ///  法定代表人身份证明
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterTargetProve(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }
        /// <summary>
        ///  授权委托书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterEntrustBook(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        ///  结案报告
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterEndRation(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        ///  行政处罚案件备案报告
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPunishRecord(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }
        /// <summary>
        ///  督办通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterSupervisionNotice(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }
        /// <summary>
        ///  责令限期改正水事违法行为通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterOrderDeadlineNotice(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }
        /// <summary>
        ///  责令停止水事违法行为通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterOrderStopNotice(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        ///  限期补办行政许可手续通知书
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterDeadlineNotice(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }


        /// <summary>
        ///  卷内材料目录
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterList(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        ///  水行政执法照片记录纸
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterPhoneRecord(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }

        /// <summary>
        ///  摄像证据记录纸
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public DataTable WaterCameraRecord(string resourceId)
        {
            DataTable dtAll = new DataTable();
            #region 添加列

            #endregion

            return dtAll;
        }
        #endregion

    }

}
