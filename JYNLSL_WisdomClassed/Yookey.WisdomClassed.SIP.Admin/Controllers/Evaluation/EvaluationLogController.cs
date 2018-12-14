using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Evaluation;
using Yookey.WisdomClassed.SIP.Common.PetaPoco;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Evaluation;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Evaluation
{
    public class EvaluationLogController : BaseController
    {
        readonly ComResourceBll _comResourceBll = new ComResourceBll();                     //数据字典
        readonly EvaluationProcBll _evaluationProcBll = new EvaluationProcBll();            //考核项
        readonly EvaluationBasisBll _evaluationBasisBll = new EvaluationBasisBll();         //考核细则
        readonly EvaluationLogBll _evaluationLogBll = new EvaluationLogBll();               //考核记录

        public ActionResult Index(string startTime, string endTime, string quarter)
        {
            startTime = string.IsNullOrEmpty(startTime) ? DateTime.Now.ToString() : startTime;
            int year = Convert.ToDateTime(startTime).Year;
            int month = Convert.ToDateTime(startTime).Month;
            if (!string.IsNullOrEmpty(quarter))
            {
                switch (quarter)
                {
                    case "00920001":

                        startTime = new DateTime(year, 01, 1).ToString("yyyy-MM-dd") + " 00:00:00.000";
                        endTime = new DateTime(year, 04, 1).AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59.997";
                        break;
                    case "00920002":
                        startTime = new DateTime(year, 04, 1).ToString("yyyy-MM-dd") + " 00:00:00.000";
                        endTime = new DateTime(year, 07, 1).AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59.997";
                        break;
                    case "00920003":
                        startTime = new DateTime(year, 07, 1).ToString("yyyy-MM-dd") + " 00:00:00.000";
                        endTime = new DateTime(year, 10, 1).AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59.997";
                        break;
                    default:
                        startTime = new DateTime(year, 10, 1).ToString("yyyy-MM-dd") + " 00:00:00.000";
                        endTime = new DateTime(year + 1, 01, 1).AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59.997";
                        break;
                }
            }
            //考核对象列表
            //var teamList = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity()).ToList();
            //var objList = teamList.Where(p => p.ParentId != "0" && p.FullName.Contains("社工委") || p.FullName.Contains("街道")).ToList();

            var objList = new CrmCompanyBll().GetAllEnforcementUnit();

            //最终数据列表
            List<ObjLogEntity> objLogList = new List<ObjLogEntity>();
            //考核模块列表
            var administrationMod = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0086" }).ToList();

            foreach (var item in objList)  //循环遍历考核对象列表
            {
                //考核对象对应4个模块得分集合
                List<LogStatisticsEntity> logList = new List<LogStatisticsEntity>();
                ObjLogEntity objEntity = new ObjLogEntity();
                objEntity.ObjId = item.Id;
                objEntity.ObjName = item.ShortName;
                //objEntity.ObjId = "1";
                //objEntity.ObjName = "1";
                foreach (var evalMod in administrationMod)
                {
                    var getPoints = _evaluationLogBll.GetLogInfo(item.Id, evalMod.Id, startTime, endTime);
                    logList.Add(getPoints);
                }
                objEntity.EvalModFirstId = logList[0].EvalModId;
                objEntity.EvalModFirstName = logList[0].EvalModName;
                objEntity.PunishmentFirst = logList[0].Punishment;
                objEntity.RewardFirst = logList[0].Reward;
                objEntity.EvalModSecondId = logList[1].EvalModId;
                objEntity.EvalModSecondName = logList[1].EvalModName;
                objEntity.PunishmentSecond = logList[1].Punishment;
                objEntity.RewardSecond = logList[1].Reward;
                objEntity.EvalModThirdId = logList[2].EvalModId;
                objEntity.EvalModThirdName = logList[2].EvalModName;
                objEntity.PunishmentThird = logList[2].Punishment;
                objEntity.RewardThird = logList[2].Reward;
                objEntity.EvalModFourthId = logList[3].EvalModId;
                objEntity.EvalModFourthName = logList[3].EvalModName;
                objEntity.PunishmentFourth = logList[3].Punishment;
                objEntity.RewardFourth = logList[3].Reward;
                objEntity.Total = 100 - objEntity.PunishmentFirst - objEntity.PunishmentSecond - objEntity.PunishmentThird - objEntity.PunishmentFourth + objEntity.RewardFirst + objEntity.RewardSecond + objEntity.RewardThird + objEntity.PunishmentFourth;
                objEntity.Ranking = 1;
                objLogList.Add(objEntity);
            }
            //设定排名
            var obj1 = new ObjLogEntity();
            if (objLogList.Count > 1)
            {
                for (int i = 0; i < objLogList.Count; i++)
                {
                    int count = 1;
                    for (int j = 0; j < objLogList.Count; j++)
                    {
                        if (objLogList[i].Total < objLogList[j].Total)
                        {
                            count += 1;
                            objLogList[i].Ranking = count;
                        }
                    }
                }
            }
            ViewBag.ObjLogList = objLogList;
            if (string.IsNullOrEmpty(startTime))
            {
                BindDate(DateTime.Now.Year, DateTime.Now.Month);
            }
            else
            {
                BindDate(year, month);
            }
            //考核季度
            var quarterList = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0092" }).ToList();
            quarterList.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["QuarterList"] = new SelectList(quarterList, "Id", "RsKey", "");

            ViewBag.StartTime = startTime;
            ViewBag.EndTime = endTime;
            return View();
        }


        public ActionResult GetDetailIndex(string objId, string modId, string isRewards, string startTime, string endTime)
        {
            //考核对象
            var teamList = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity()).ToList();
            teamList = teamList.Where(p => p.ParentId != "0" && p.FullName.Contains("社工委") || p.FullName.Contains("街道")).ToList();
            teamList.Insert(0, new CrmDepartmentEntity { Id = "", FullName = "==请选择==" });
            ViewData["TeamList"] = new SelectList(teamList, "Id", "FullName", objId);
            //行政执法考核模块
            var administrationMod = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0086" }).ToList();
            administrationMod.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["AdministrationMod"] = new SelectList(administrationMod, "Id", "RsKey", modId);
            //奖惩
            var readList = EnumOperate.ConvertEnumToListItems(typeof(IsReward), "0");
            ViewData["IsRewards"] = readList;
            return View();
        }

        public ActionResult Report(string year, string month)
        {
            BindDate(DateTime.Now.Year, DateTime.Now.Month);
            if (string.IsNullOrEmpty(year))
            {
                year = DateTime.Now.Year.ToString();
                month = DateTime.Now.Month.ToString();
            }
            if (Convert.ToInt32(month) < 10)
            {
                month = "0" + month;
            }
            DateTime nowTime = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 01);

            var startTime = nowTime.AddDays(1 - nowTime.Day).ToString("yyyy-MM-dd") + " 00:00:00.000";
            var endTime = nowTime.AddDays(1 - nowTime.Day).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59.997";

            //var logList = new EvaluationLogBll().GetLogList("","","",startTime,endTime);
            //考核对象列表
            var teamList = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity()).ToList();
            var objList = teamList.Where(p => p.ParentId != "0" && p.FullName.Contains("社工委") || p.FullName.Contains("街道")).ToList();
            //考核模块列表
            var administrationMod = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0086" }).ToList();
            //最终数据列表
            List<ObjLogEntity> objLogList = new List<ObjLogEntity>();
            foreach (var item in objList)  //循环遍历考核对象列表
            {
                //考核对象对应4个模块得分集合
                List<LogStatisticsEntity> logList = new List<LogStatisticsEntity>();
                ObjLogEntity objEntity = new ObjLogEntity();
                objEntity.ObjId = item.Id;
                objEntity.ObjName = item.FullName;
                //objEntity.ObjId = "1";
                //objEntity.ObjName = "1";
                foreach (var evalMod in administrationMod)
                {

                    var getPoints = _evaluationLogBll.GetLogInfo(item.Id, evalMod.Id, startTime, endTime);

                    var detailedList = _evaluationLogBll.GetLogList(item.Id, evalMod.Id, "", startTime, endTime);
                    if (detailedList != null && detailedList.Count > 0)
                    {
                        foreach (var det in detailedList)
                        {
                            getPoints.Detailed += det.Remark + "★";
                        }
                        getPoints.Detailed = getPoints.Detailed.Trim('★');
                    }
                    logList.Add(getPoints);
                }
                objEntity.EvalModFirstId = logList[0].EvalModId;
                objEntity.EvalModFirstName = logList[0].EvalModName;
                objEntity.PunishmentFirst = logList[0].Punishment;
                objEntity.RewardFirst = logList[0].Reward;
                objEntity.DetailedFirst = logList[0].Detailed;
                objEntity.EvalModSecondId = logList[1].EvalModId;
                objEntity.EvalModSecondName = logList[1].EvalModName;
                objEntity.PunishmentSecond = logList[1].Punishment;
                objEntity.RewardSecond = logList[1].Reward;
                objEntity.DetailedSecond = logList[1].Detailed;
                objEntity.EvalModThirdId = logList[2].EvalModId;
                objEntity.EvalModThirdName = logList[2].EvalModName;
                objEntity.PunishmentThird = logList[2].Punishment;
                objEntity.RewardThird = logList[2].Reward;
                objEntity.DetailedThird = logList[2].Detailed;
                objEntity.EvalModFourthId = logList[3].EvalModId;
                objEntity.EvalModFourthName = logList[3].EvalModName;
                objEntity.PunishmentFourth = logList[3].Punishment;
                objEntity.RewardFourth = logList[3].Reward;
                objEntity.DetailedFourth = logList[3].Detailed;
                objEntity.Total = 100 - objEntity.PunishmentFirst - objEntity.PunishmentSecond - objEntity.PunishmentThird - objEntity.PunishmentFourth + objEntity.RewardFirst + objEntity.RewardSecond + objEntity.RewardThird + objEntity.PunishmentFourth;

                objLogList.Add(objEntity);
            }
            ViewData["FinalList"] = objLogList;

            return View();
        }

        /// <summary>
        /// 获取考核信息分页
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetEvaluationLogData(string objId, string modId, string procId, string isRewards, string startTime, string endTime, int rows = 30, int page = 1)
        {
            int isRe = 3;
            if (objId == "all")
            {
                objId = "1";
            }
            if (!string.IsNullOrEmpty(isRewards))
            {
                isRe = Convert.ToInt32(isRewards);
            }
            if (!string.IsNullOrEmpty(startTime))
            {
                startTime = Convert.ToDateTime(startTime).ToString("yyyy-MM-dd");
                startTime = startTime + " 00:00:00.000";
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                endTime = Convert.ToDateTime(endTime).ToString("yyyy-MM-dd");
                endTime = endTime + " 23:59:59.997";
            }
            var data = _evaluationLogBll.GetEvaluationLogInfo(objId, modId, procId, isRe, startTime, endTime, rows, page);
            var result = CommonMethod.PageToJson(CommonMethod.PageToJqGridPage(data));
            return result;
        }

        #region 数据绑定下拉列表
        /// <summary>
        /// 根据Id获取当前考核模块中的考核依据
        /// </summary>
        /// <param name="procId"></param>
        /// <returns></returns>
        public JsonResult GetProc(string procId)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(procId))
            {
                var proc = _evaluationProcBll.GetSearchResult(new EvaluationProcEntity() { ParentId = procId });
                foreach (EvaluationProcEntity c in proc)
                {
                    items.Add(new SelectListItem()
                    {
                        Text = c.EvaluationName.ToString(),
                        Value = c.Id.ToString()
                    });
                }
                if (!items.Count.Equals(0))
                {
                    items.Insert(0, new SelectListItem() { Text = "==请选择==", Value = "" });
                }
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据Id获取当前考核依据大类获取考核依据小类
        /// </summary>
        /// <param name="basisId"></param>
        /// <returns></returns>
        public JsonResult GetBasis(string basisId)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(basisId))
            {
                var proc = _evaluationBasisBll.GetSearchResult(new EvaluationBasisEntity() { EvaluationProcId = basisId });
                foreach (EvaluationBasisEntity c in proc)
                {
                    items.Add(new SelectListItem()
                    {
                        Text = c.EvaluationDetail.ToString(),
                        Value = c.Id.ToString()
                    });
                }
                if (!items.Count.Equals(0))
                {
                    items.Insert(0, new SelectListItem() { Text = "==请选择==", Value = "" });
                }
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        #endregion
        /// <summary>
        /// 新增考核记录
        /// </summary>
        /// <returns></returns>
        public ActionResult AddEvaluationLog(string Id)
        {
            var model = new EvaluationLogEntity();
            model.Id = Guid.NewGuid().ToString();
            if (!string.IsNullOrEmpty(Id))
            {
                model = new EvaluationLogBll().Get(Id);
            }
            ViewBag.Id = model.Id;

            //行政执法考核方式
            var administrationMethod = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0085" }).ToList();
            administrationMethod.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["Administrationethod"] = new SelectList(administrationMethod, "Id", "RsKey", model.EvaluationMethodId);

            //行政执法考核模块
            var administrationMod = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0086" }).ToList();
            administrationMod.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["AdministrationMod"] = new SelectList(administrationMod, "Id", "RsKey");

            //获取考核细则列表
            List<EvaluationBasisEntity> evaluationBasisList =
                _evaluationBasisBll.GetSearchResult(new EvaluationBasisEntity() { EvaluationProcId = model.EvaluationBasisId });
            ViewData["EvaluationBasisList"] = evaluationBasisList;

            //考核对象
            var evalObjList = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity()).ToList();
            evalObjList = evalObjList.Where(p => p.ParentId != "0" && p.FullName.Contains("社工委") || p.FullName.Contains("街道")).ToList();
            evalObjList.Insert(0, new CrmDepartmentEntity { Id = "", FullName = "==请选择==" });
            ViewData["EvalObjList"] = new SelectList(evalObjList, "Id", "FullName", model.EvaluationObjId);

            //奖惩
            var readList = EnumOperate.ConvertEnumToListItems(typeof(IsReward), "0");
            ViewData["IsRewards"] = readList;

            return View(model);
        }

        /// <summary>
        /// 保存考核记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ActionResult SavaEvalutionLog(string Id, string objId, string objName, string parentId, string parentname, string procId, string procname, string basisId, string basisname, string methodId, string methodname, string checkDate, string remark, int IsRewards, int Points)
        {
            var user = CurrentUser.CrmUser;
            var isOk = false;
            try
            {
                var EntEntityList = _evaluationLogBll.Get(Id);

                if (EntEntityList != null)
                {
                    EntEntityList.Id = Id;
                    EntEntityList.EvaluationObjId = objId;
                    EntEntityList.ObjName = objName;
                    EntEntityList.EvaluationModId = parentId;
                    EntEntityList.ModName = parentname;
                    EntEntityList.EvaluationProcId = procId;
                    EntEntityList.ProcName = procname;
                    EntEntityList.EvaluationBasisId = basisId;
                    EntEntityList.BasisName = basisname;
                    EntEntityList.EvaluationMethodId = methodId;
                    EntEntityList.MethodName = methodname;
                    EntEntityList.CheckDate = Convert.ToDateTime(checkDate);
                    EntEntityList.IsRewards = IsRewards;
                    EntEntityList.Points = Points;
                    EntEntityList.Remark = remark;
                    EntEntityList.UpdateId = user.Id;
                    EntEntityList.UpdateBy = user.UserName;
                    EntEntityList.UpdateOn = DateTime.Now;
                    isOk = _evaluationLogBll.Update(EntEntityList);
                }
                else
                {
                    var EntEntity = new EvaluationLogEntity();
                    EntEntity.Id = Id;
                    EntEntity.EvaluationObjId = objId;
                    EntEntity.ObjName = objName;
                    EntEntity.EvaluationModId = parentId;
                    EntEntity.ModName = parentname;
                    EntEntity.EvaluationProcId = procId;
                    EntEntity.ProcName = procname;
                    EntEntity.EvaluationBasisId = basisId;
                    EntEntity.BasisName = basisname;
                    EntEntity.EvaluationMethodId = methodId;
                    EntEntity.MethodName = methodname;
                    EntEntityList.CheckDate = Convert.ToDateTime(checkDate);
                    EntEntity.IsRewards = IsRewards;
                    EntEntityList.Points = Points;
                    EntEntity.Remark = remark;
                    EntEntity.RowStatus = 1;
                    EntEntity.CreatorId = user.Id;
                    EntEntity.CreateBy = user.UserName;
                    EntEntity.CreateOn = DateTime.Now;
                    EntEntity.UpdateId = "";
                    EntEntity.UpdateBy = "";
                    EntEntity.UpdateOn = DateTime.Now;
                    isOk = _evaluationLogBll.Insert(EntEntity);
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 绑定年、月
        /// 添加人：周 鹏
        /// 添加时间：2015-05-19
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="defaultYear">The default year.</param>
        /// <param name="defaultMonth">The default month.</param>
        public void BindDate(int? defaultYear, int? defaultMonth)
        {
            //绑定年（当前时间的前后十年）
            var yearList = new List<int>();
            var year = DateTime.Now.Year - 10;
            for (var i = 0; i < 20; i++)
            {
                var years = year + i;
                yearList.Add(years);
            }

            //绑定月份
            var monthList = new List<int>();
            for (var i = 1; i <= 12; i++)
            {
                monthList.Add(i);
            }
            //monthList.Add(0);
            ViewData["Months"] = new SelectList(monthList, defaultMonth);
            ViewData["Years"] = new SelectList(yearList, defaultYear);
        }

        /// <summary>
        /// 动态加载会计月的时间区间
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="firstControlId"></param>
        /// <param name="secondControlId"></param>
        /// <returns>System.String.</returns>
        public string AjaxLoadDateRange(int year, int month, string firstControlId, string secondControlId)
        {
            var sb = new StringBuilder();
            if (month == 0)
            {
                sb.AppendFormat("$('#" + firstControlId + "').val(" + ");");
                sb.AppendFormat("$('#" + secondControlId + "').val(" + ");");
            }
            else
            {
                DateTime FirstDay = new DateTime(year, month, 1);
                DateTime LastDay = FirstDay.AddMonths(1).AddDays(-1);

                sb.AppendFormat("$('#" + firstControlId + "').val('" + FirstDay.ToString("yyyy-MM-dd") + " 00:00:00.000');");
                sb.AppendFormat("$('#" + secondControlId + "').val('" + LastDay.ToString("yyyy-MM-dd") + " 23:59:59.997');");
            }
            return sb.ToString();
        }

        #region 附件材料
        /// <summary>
        /// 证据材料
        /// </summary>
        /// <param name="resourceId">外键编号</param>
        /// <param name="evtache">证据环节</param>
        /// <param name="isupload">是否允许上传</param>
        /// <param name="isdeleted">是否允许删除</param>
        /// <returns></returns>
        public ActionResult FilesTab(string resourceId, string evtache, string isupload, string isdeleted)
        {
            IList<ComResourceEntity> evidences = new List<ComResourceEntity>();
            if (!string.IsNullOrEmpty(evtache))
            {
                if (evtache.Equals("tempdetain"))    //暂扣物品
                {
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0032" });
                    ViewData["Evidences"] = new SelectList(evidences, "Id", "Rskey");
                }
            }

            //查询材料对应的材料
            if (!string.IsNullOrEmpty(resourceId) && evidences.Any())
            {
                var filetypelist = (from type in evidences where !string.IsNullOrEmpty(type.Id) select type.Id).ToList();
                var files = new EvaluationAttachBll().GetSearchResult(new EvaluationAttachEntity() { ResourceId = resourceId }, filetypelist);
                ViewData["Files"] = files;
            }


            ViewBag.Evtache = evtache;         //证据类型
            ViewBag.ResourceId = resourceId;   //外键编号
            ViewBag.Isupload = isupload;       //是否可上传
            ViewBag.IsDeleted = isdeleted;     //是否可删除

            return View("FilesTab");
        }
        /// <summary>
        /// 附件放大预览列表
        /// <param name="resourceId">外键编号</param>
        /// <param name="defaultPicId">默认显示图片ID</param>
        /// </summary>
        /// <returns></returns>
        public ActionResult FilesView(string resourceId, string defaultPicId)
        {
            if (!string.IsNullOrEmpty(resourceId))
            {
                var files = new EvaluationAttachBll().GetSearchResult(new EvaluationAttachEntity() { ResourceId = resourceId });

                ViewData["Files"] = files;
            }
            ViewBag.DefaultPicId = defaultPicId;

            return View();
        }

        /// <summary>
        /// 请求附件详情
        /// </summary>
        /// <param name="fileId">附件编号</param>
        /// <returns></returns>
        public JsonResult FileDetails(string fileId)
        {
            var entity = new EvaluationAttachEntity();
            if (!string.IsNullOrEmpty(fileId))
            {
                entity = new EvaluationAttachBll().Get(fileId);
            }
            var result = new StatusModel<object>
            {
                rtState = 1,
                rtData = null,
                rtObj = entity,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 附件上传保存附件信息
        /// </summary>
        /// <param name="resourceId">外键编号</param>
        /// <param name="fileAddress">附件保存地址</param>
        /// <param name="fileType">附件类型</param>
        /// <param name="fileTypeName">附件类型名称</param>
        /// <param name="remark">附件描述</param>
        /// <param name="fileName">上传时名称</param>
        /// <param name="fileReName">上传后重命名名称</param>
        /// <returns></returns>
        public string UpSaveImage(string resourceId, string fileAddress, string fileType, string fileTypeName, string remark, string fileName, string fileReName)
        {
            try
            {
                var user = CurrentUser.CrmUser;
                var result = Guid.NewGuid().ToString();
                var entity = new EvaluationAttachEntity()
                {
                    Id = result,
                    ResourceId = resourceId,
                    FileType = fileType,
                    FileTypeName = fileTypeName,
                    FileAddress = fileAddress,
                    FileName = fileName,
                    FileReName = fileReName,
                    FileRemark = remark,
                    RowStatus = 1,
                    IsCompleted = 1,
                    CreatorId = user.Id,
                    CreateBy = user.UserName,
                    CreateOn = DateTime.Now,
                    UpdateId = user.Id,
                    UpdateBy = user.UserName,
                    UpdateOn = DateTime.Now
                };
                new EvaluationAttachBll().Insert(entity);
                return result;
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// 删除附件
        /// </summary>
        /// <param name="fileId">附件编号</param>
        /// <returns></returns>
        public JsonResult DeleteFile(string fileId)
        {
            var isOk = 0;
            var user = CurrentUser.CrmUser;
            if (!string.IsNullOrEmpty(fileId))
            {
                var entity = new EvaluationAttachBll().Get(fileId);
                entity.RowStatus = 0;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;

                isOk = new EvaluationAttachBll().Update(entity);
            }
            var result = new StatusModel<object>
            {
                rtState = isOk,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存附件
        /// </summary>
        /// <param name="fileId">附件编号</param>
        /// <param name="remark">附件备注</param>
        /// <returns></returns>
        public JsonResult SaveFileDetails(string fileId, string remark)
        {
            var isOk = 0;
            var user = CurrentUser.CrmUser;
            if (!string.IsNullOrEmpty(fileId))
            {
                var entity = new EvaluationAttachBll().Get(fileId);
                entity.FileRemark = remark;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;
                isOk = new EvaluationAttachBll().Update(entity);  //更新
            }

            var result = new StatusModel<object>
            {
                rtState = isOk,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 附件缩略图预览,用于案件首页右侧
        /// </summary>
        /// <returns></returns>
        public ActionResult FileBreviaryView(string resourceId, string evtache)
        {
            if (!string.IsNullOrEmpty(resourceId))
            {
                var files = new EvaluationAttachBll().GetSearchResult(new EvaluationAttachEntity() { ResourceId = resourceId });
                ViewData["Files"] = files;
            }
            return View("FileBreviaryView");
        }
        #endregion
    }
}
