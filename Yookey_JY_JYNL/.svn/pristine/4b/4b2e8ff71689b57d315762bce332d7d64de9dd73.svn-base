using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.FlowEditor;
using Yookey.WisdomClassed.SIP.Model.FlowEditor;
using Newtonsoft.Json;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Crm
{
    public class FlowEditorController : Controller
    {

        /// <summary>
        /// 流程
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 设计
        /// </summary>
        /// <returns></returns>
        public ActionResult Paint()
        {
            return View();
        }

        /// <summary>
        /// 对象编辑器
        /// 修改人：张西琼
        /// 时间：2014-07-28
        /// </summary>
        /// <returns></returns>
        public ActionResult ObjectAttribute(string noneID, string processID, string noneName)
        {
            var dt = new FeActivityBll().GetActivityByProcessId(processID);
            if (dt.Count == 0)
            {
                var feAc = new FeActivityEntity();
                dt.Add(feAc);
            }

            ViewData["processID"] = processID;
            //绑定接收及退回下拉框对象
            ViewData["SendORWithdrawalActivity"] = dt;
            ViewData["noneID"] = ReplaceStr(noneID);
            ViewData["noneName"] = noneName;
            //初始化基本信息
            var note = new FeActivityBll().GetActivityByPIdNone(processID, noneName);
            if (note.Count == 0)
            {
                var feAc = new FeActivityEntity();
                note.Add(feAc);
            }
            ViewData["note"] = note;
            return View();
        }

        private string ReplaceStr(string str)
        {
            return str.Replace("\"", "");
        }

        /// <summary>
        /// 保存流程
        /// </summary>
        /// <param name="xml">XML字符</param>
        /// <param name="processId">流程编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="version">版本号</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveProcess(string xml, string processId, string flowName, string version)
        {
            try
            {
                var filePath = Request.PhysicalApplicationPath;
                var isOk = new FeProcessBll().SaveProcess(xml, filePath, processId, "", version, flowName, false, false);
                var rtEntity = new StatusModel<DBNull>
                {
                    rtData = null,
                    rtMsrg = isOk ? "成功" : "失败",
                    rtState = isOk ? 0 : 1
                };
                return Json(rtEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 读取流程
        /// </summary>
        /// <param name="flowName">流程名称</param>
        /// <returns></returns>
        public JsonResult ReadProcess(string flowName)
        {
            var list = new FeProcessBll().QueryByFlowName(flowName);
            var rtEntity = new StatusModel<FeProcessEntity>();
            if (list.Count > 0)
            {
                rtEntity.rtData = list;
                rtEntity.rtMsrg = "成功";
                rtEntity.rtState = 0;
            }
            else if (list.Count > 1)
            {
                rtEntity.rtData = null;
                rtEntity.rtMsrg = "未找到流程[" + flowName + "]对应的流程记录……";
                rtEntity.rtState = 1;
            }
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 读取节点信息
        /// 添加人：张西琼
        /// 时间：2014/7/29
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="isUnlock"></param>
        /// <returns></returns>

        public string ReadFeActionInstance(string activityId, int isUnlock)
        {
            var feActionInstance = new FeActionInstanceBll().GetActionEntity(activityId, isUnlock);
            return JsonConvert.SerializeObject(feActionInstance);
        }

        /// <summary>
        /// Ajax 读取规则
        /// 添加人：张西琼
        /// 时间：2014-07-29
        /// </summary>
        /// <param name="actityId"></param>
        /// <returns></returns>
        public string ReadRule(string actityId)
        {
            var rule = new FeRuleCodeBll().RuleCodeEntity(actityId);
            return JsonConvert.SerializeObject(rule);
        }

        /// <summary>
        /// 流程发布
        /// 添加人：周 鹏
        /// 添加时间：2014-07-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="xml">XML字符</param>
        /// <param name="processId">流程编号</param>
        /// <param name="flowName">流程名称</param>
        /// <param name="version">版本号</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Issuance(string xml, string processId, string flowName, string version)
        {
            //如果没有版本号，就执行保存而不发布
            var bisIssuance = false;
            //是否是第一次发布
            var isFirstIssuance = true;
            if (!string.IsNullOrEmpty(version))
            {
                bisIssuance = true;
                isFirstIssuance = false;
            }
            var filePath = Request.PhysicalApplicationPath;
            var nversion = new FeProcessBll().GetVersion(flowName.Trim());//得到发布版本
            var isOk = new FeProcessBll().SaveProcess(xml, filePath, "", processId, nversion, flowName, bisIssuance, isFirstIssuance);
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = isOk ? "您成功发布了流程[" + flowName + "]，版本号:" + nversion + "……" : "失败",
                rtState = isOk ? 0 : 1
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除流程
        /// 添加人：周 鹏
        /// 添加时间：2014-07-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="procesId">流程编号</param>
        /// <returns></returns>
        public JsonResult Delete(string procesId)
        {
            var rtEntity = new StatusModel<DBNull>();
            if (!string.IsNullOrEmpty(procesId))
            {
                var isOk = new FeProcessBll().DeleteProcess(procesId);
                rtEntity.rtData = null;
                rtEntity.rtMsrg = "";
                rtEntity.rtState = isOk ? 0 : 1;
            }
            else
            {
                rtEntity.rtData = null;
                rtEntity.rtMsrg = "未获得可用于删除的流程……";
                rtEntity.rtState = 3;
            }
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存节点对象
        /// </summary>
        /// <param name="activity">节点基本属性</param>
        /// <param name="note">接收对象Json数据</param>
        /// <param name="rules">规则Json数据</param>
        /// <param name="activityId">节点编号</param>
        /// <param name="processId">流程编号</param>
        /// <param name="oldNoneName">节点名称</param>
        /// <returns></returns>
        public JsonResult SaveActivity(string activity, string note, string rules, string activityId, string processId, string oldNoneName)
        {
            var rtEntity = new StatusModel<DBNull> { rtData = null, rtMsrg = "", rtState = 1 };
            var strArry = activity.Split('|');
            var noneName = strArry[1].Trim();

            #region 保存流程
            var feOldProcess = new FeProcessBll().QueryByFlowId(processId);
            if (feOldProcess.Count > 0)
            {
                if (!string.IsNullOrEmpty(oldNoneName))
                {
                    feOldProcess[0].FlowChart = feOldProcess[0].FlowChart.Replace(oldNoneName, noneName);
                }

                feOldProcess[0].Id = Guid.NewGuid().ToString();

                if (!new FeProcessBll().SaveProcess(feOldProcess[0]))
                {
                    rtEntity.rtData = null;
                    rtEntity.rtMsrg = "主流程保存失败！";
                    rtEntity.rtState = 1;
                }
            }
            else
            {
                rtEntity.rtData = null;
                rtEntity.rtMsrg = "未查到流程！";
                rtEntity.rtState = 1;
                return Json(rtEntity, JsonRequestBehavior.AllowGet);
            }

            #endregion

            #region 保存节点属性

            var feActivityEntity = new FeActivityEntity();
            if (string.IsNullOrEmpty(activityId))
            {
                activityId = Guid.NewGuid().ToString();
            }
            feActivityEntity.ActivityID = activityId;
            feActivityEntity.ProcessID = processId;
            feActivityEntity.NoneID = strArry[0].Trim();
            feActivityEntity.NoneName = strArry[1].Trim();
            feActivityEntity.SendORWithdrawalActivityID = strArry[2].Trim();
            feActivityEntity.FormAddress = strArry[3].Trim();
            if (strArry[4].Trim() == "1")
            {
                feActivityEntity.IsContrastCommunity = true;
            }

            if (strArry[5].Trim() == "1")
            {
                feActivityEntity.IsContrastRule = true;

            }
            if (strArry[6].Trim() == "1")
            {
                feActivityEntity.IsSendOnOpener = true;
            }
            feActivityEntity.NoneDisposeManner = Convert.ToInt32(strArry[7].Trim());
            feActivityEntity.FulfillAssemblyName = strArry[8].Trim();
            feActivityEntity.FulfillClassFullName = strArry[9].Trim();
            feActivityEntity.OverdueAssemblyName = strArry[10].Trim();
            feActivityEntity.OverdueClassFullName = strArry[11].Trim();
            feActivityEntity.OverdueHour = Convert.ToInt32(strArry[12].Trim());
            feActivityEntity.Remark = strArry[13].Trim();
            var istrue = new FeActivityBll().ExitstActivityId(feActivityEntity.ActivityID);
            if (istrue)
            {
                if (new FeActivityBll().DeleActivity(feActivityEntity.ActivityID))
                {
                    new FeActivityBll().Save(feActivityEntity);
                }
            }
            else
            {
                if (!new FeActivityBll().Save(feActivityEntity))
                {
                    rtEntity.rtData = null;
                    rtEntity.rtMsrg = "当前节点不存在！";
                    rtEntity.rtState = 1;
                    return Json(rtEntity, JsonRequestBehavior.AllowGet);
                }
            }

            #endregion

            #region 保存接收对象

            var listActionInstance = JsonConvert.DeserializeObject<List<FeActionInstanceEntity>>(note);            //序列化Json
            var saveActionInstance = new FeActionInstanceBll().SaveActionInstance(listActionInstance, activityId); //保存接收对象
            if (!saveActionInstance)
            {
                rtEntity.rtData = null;
                rtEntity.rtMsrg = "保存对象失败！";
                rtEntity.rtState = 1;
                return Json(rtEntity, JsonRequestBehavior.AllowGet);
            }

            #endregion

            #region 保存规则
            if (!string.IsNullOrEmpty(rules))
            {
                var ruleList = JsonConvert.DeserializeObject<List<FeRuleCodeEntity>>(rules);
                var saveRule = new FeRuleCodeBll().SaveRule(ruleList, activityId); //保存规则
                if (!saveRule)
                {
                    rtEntity.rtData = null;
                    rtEntity.rtMsrg = "保存规则失败！";
                    rtEntity.rtState = 1;
                }
            }
            #endregion

            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddRule(string rules)
        {
            var rtEntity = new StatusModel<DBNull>();
            if (new FeRuleCodeBll().AddRuleCode(RuleCode(rules)))
            {
                rtEntity.rtData = null;
                rtEntity.rtMsrg = "新增成功！";
                rtEntity.rtState = 1;
            }
            else
            {
                rtEntity.rtData = null;
                rtEntity.rtMsrg = "新增失败！";
                rtEntity.rtState = 1;
            }
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取RuleCode实体，用于新增和修改
        /// 添加人：张西琼
        /// 时间：2014/8/1
        /// </summary>
        /// <param name="ruleCode"></param>
        /// <returns></returns>
        public FeRuleCodeEntity RuleCode(string ruleCode)
        {
            string[] rule = ruleCode.Split('|');
            FeRuleCodeEntity feRuleCodeEntity = new FeRuleCodeEntity();
            feRuleCodeEntity.RuleClauses = rule[0].Trim();
            feRuleCodeEntity.RiolationRuleID = rule[1].Trim();
            if (rule[2].Trim() == "false")
            {
                feRuleCodeEntity.IsUnlock = false;
            }
            else feRuleCodeEntity.IsUnlock = true;
            //feRuleCodeEntity.IsUnlock =Convert.ToBoolean（rule[2].Trim()）;
            feRuleCodeEntity.Remark = rule[3].Trim();
            feRuleCodeEntity.FulfillAssemblyName = rule[4].Trim();
            feRuleCodeEntity.FulfillClassFullName = rule[5].Trim();
            //feRuleCodeEntity.RuleCodeID = rule[6].Trim();
            feRuleCodeEntity.ActivityID = rule[7].Trim();
            if (string.IsNullOrEmpty(rule[8].Trim()))
            {
                feRuleCodeEntity.RuleCodeID = Guid.NewGuid().ToString();
            }
            else
                feRuleCodeEntity.RuleCodeID = rule[8].Trim();
            if (!string.IsNullOrEmpty(rule[9].Trim()))
            {
                feRuleCodeEntity.Id = rule[9].Trim();
            }
            //feRuleCodeEntity.RuleCodeID = rule[8].Trim();
            //if (!string.IsNullOrEmpty(rule[10].Trim()))
            //{
            //    feRuleCodeEntity.Version = rule[10].Trim();
            //}
            feRuleCodeEntity.CreateDate = DateTime.Now;
            return feRuleCodeEntity;
        }

        /// <summary>
        /// 删除规则、
        /// 添加人：张西琼
        /// 时间：2014/8/1
        /// </summary>
        /// <param name="ruleCode"></param>
        /// <returns></returns>
        public string RuleCodeDelete(string ruleCodeID)
        {

            if (new FeRuleCodeBll().DelRuleCode(ruleCodeID.Remove(ruleCodeID.Length - 1, 1)))
            {
                return "0k";

            }
            else return "error";
        }

        /// <summary>
        /// 删除规则、
        /// 添加人：张西琼
        /// 时间：2014/8/1
        /// </summary>
        /// <param name="ruleCode"></param>
        /// <returns></returns>
        public string DelActionInstance(string ActionInstanceId)
        {
            if (new FeActionInstanceBll().DelActionInstance(ActionInstanceId.Remove(ActionInstanceId.Length - 1, 1)))
            {
                return "0k";

            }
            else return "error";
        }
        public string ReadRuleById(string ruleId)
        {
            var rule = new FeRuleCodeBll().ReadRuleById(ruleId);
            return JsonConvert.SerializeObject(rule);
        }

        /// <summary>
        /// 初始化流程列表
        /// 添加人;张西琼
        /// 时间：2014/8/5
        /// </summary>
        /// <param name="_flowName">流程名</param>
        /// <returns></returns>
        public ActionResult List(string _flowName)
        {
            int _iIsUnlock = -1;
            bool _bisMaxVersion = false;

            List<FeProcessEntity> flowList = new FeProcessBll().GetProcess(_flowName, _iIsUnlock, _bisMaxVersion);
            ViewData["flowName"] = _flowName;
            return View();
        }

        /// <summary>
        /// 读取流程
        /// 添加人;张西琼
        /// 时间：2014/8/5
        /// </summary>
        /// <returns></returns>
        public string Prcoess(string flowName, int isUnlock, bool isMaxVersion)
        {
            ViewData["flowName"] = flowName;
            var list = new FeProcessBll().GetProcess2(flowName, isUnlock, isMaxVersion);
            return JsonConvert.SerializeObject(list);
        }

        /// <summary>
        /// 删除流程组
        /// 添加人：张西琼
        /// 时间：2014/8/5
        /// </summary>
        /// <param name="processIdArry">流程Id组</param>
        /// <returns></returns>
        public JsonResult DelProcessArry(string processIdArry)
        {
            var rtEntity = new StatusModel<DBNull>();
            if (!string.IsNullOrEmpty(processIdArry))
            {
                string[] strArry = processIdArry.Remove(processIdArry.Length - 1, 1).Split(',');
                for (int i = 0; i < strArry.Length; i++)
                {
                    if (!new FeProcessBll().DelProcess(strArry[i]))
                    {
                        rtEntity.rtData = null;
                        rtEntity.rtMsrg = "流程删除失败！请联系管理员.......";
                        rtEntity.rtState = 0;
                        return Json(rtEntity, JsonRequestBehavior.AllowGet);
                    }
                }
                rtEntity.rtData = null;
                rtEntity.rtMsrg = "流程删除成功！";
                rtEntity.rtState = 1;
            }
            else
            {
                rtEntity.rtData = null;
                rtEntity.rtMsrg = "未获得相应流程！";
                rtEntity.rtState = 1;
            }


            return Json(rtEntity, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 启用流程
        /// 添加人：张西琼
        /// 时间：2014/8/5
        /// </summary>
        /// <param name="ProcessIdArry">流程Id组</param>
        /// <param name="ProcessNameArry">流程名数组</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UnlockProcess(string processIdArry, string processNameArry)
        {
            var rtEntity = new StatusModel<DBNull>();
            if (!string.IsNullOrEmpty(processIdArry) && !string.IsNullOrEmpty(processNameArry))
            {
                string[] idArry = processIdArry.Remove(processIdArry.Length - 1, 1).Split(',');
                string[] nameArry = processNameArry.Remove(processNameArry.Length - 1, 1).Split(',');
                for (int i = 0; i < idArry.Length; i++)
                {
                    if (!new FeProcessBll().OpenUnlock(idArry[i], nameArry[i]))
                    {
                        rtEntity.rtData = null;
                        rtEntity.rtMsrg = "流程启用失败！请联系管理员.......";
                        rtEntity.rtState = 0;
                        return Json(rtEntity, JsonRequestBehavior.AllowGet);
                    }
                }
                rtEntity.rtData = null;
                rtEntity.rtMsrg = "您成功启用了流程……！";
                rtEntity.rtState = 1;
            }
            else
            {
                rtEntity.rtData = null;
                rtEntity.rtMsrg = "未获得相应流程！";
                rtEntity.rtState = 1;
            }
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult ReshProcess(string flowName, int isUnlock, bool isMaxVersion)
        //{
        //    var list = new FeProcessBll().GetProcess(flowName, isUnlock, isMaxVersion);
        //    var rtEntity = new StatusModel<DBNull>();
        //    return Json(rtEntity, JsonRequestBehavior.AllowGet);
        //}


    }

}


