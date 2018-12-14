using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Business.Com;
using System.Globalization;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Penalty
{
    public class PenaltyParkingController : BaseController
    {
        private readonly InfCarChecksignBll _carBll = new InfCarChecksignBll();
        private readonly InfCarChecksignmiddleBll _carMiddleBll = new InfCarChecksignmiddleBll();
        private readonly InfCarAttachBll _carAttachBll = new InfCarAttachBll();
        private readonly BaseDepartmentBll _crmDeptBll = new BaseDepartmentBll();
        private readonly ComResourceBll _comResourceBll = new ComResourceBll();
        private readonly ComNumberBll _comNumberBll = new ComNumberBll();
        private readonly BaseUserBll _crmUserBll = new BaseUserBll();

        /// <summary>
        /// 违法停车
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        #region 视图
        /// <summary>
        /// 违停登记
        /// </summary>
        /// <returns></returns>
        public ActionResult ParkingEntity()
        {
            var user = CurrentUser.CrmUser;
            //车辆类型
            var carCarType = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0023" });
            carCarType.Insert(0, new ComResourceEntity { Id = "", RsKey = "请选择" });
            ViewData["CarCarType"] = new SelectList(carCarType, "Id", "RsKey", "00230002");

            //省份
            var carNoProviences = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0025" });
            carNoProviences.Insert(0, new ComResourceEntity { Id = "", RsKey = "请选择" });
            ViewData["CarCarNoProvience"] = new SelectList(carNoProviences, "RsKey", "RsKey");

            //26个市字母
            var carCarNoWord = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0026" });
            carCarNoWord.Insert(0, new ComResourceEntity { Id = "", RsKey = "请选择" });
            ViewData["CarCarNoWord"] = new SelectList(carCarNoWord, "RsKey", "RsKey");

            //执法部门
            var depts = _crmDeptBll.GetAllDetachment();
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "请选择" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName", user.DeptId);


            //两个执法人员
            var users = _crmUserBll.GetDeptsUsers(new BaseUserEntity { DeptId = user.DeptId }).ToList();
            users.Insert(0, new BaseUserEntity { Id = "", UserName = "==请选择==" });
            ViewData["Users"] = new SelectList(users, "Id", "UserName");

            return View();
        }

        /// <summary>
        /// 违停案件查询
        /// </summary>
        /// <returns></returns>
        public ActionResult ParkingQuery()
        {
            var types = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0021" });
            types.Insert(0, new ComResourceEntity { Id = "", RsKey = "==全部==" });
            ViewData["Types"] = new SelectList(types, "RsValue", "RsKey", 1);

            return View();
        }

        /// <summary>
        /// 违章一级审核
        /// </summary>
        /// <returns></returns>
        public ActionResult ParkingAuditViolationFirst()
        {
            //执法部门
            var depts = _crmDeptBll.GetAllDetachment();
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==全部==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName");

            var types = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0023" });
            types.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["Types"] = new SelectList(types, "Id", "RsKey", 1);

            return View();
        }

        /// <summary>
        /// 违章二级审核
        /// </summary>
        /// <returns></returns>
        public ActionResult ParkingAuditViolationSecond()
        {
            //执法部门
            var depts = _crmDeptBll.GetAllDetachment();
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==全部==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName");

            return View();
        }

        /// <summary>
        /// 违停作废审批
        /// </summary>
        /// <returns></returns>
        public ActionResult ParkingInvalid()
        {
            //执法部门
            var depts = _crmDeptBll.GetAllDetachment();
            depts.Insert(0, new BaseDepartmentEntity { DepartmentId = "", FullName = "==全部==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName");
            return View();
        }

        /// <summary>
        /// 违停处理明细
        /// </summary>
        /// <returns></returns>
        public ActionResult ParkingProcesDetails()
        {
            var date = DateTime.Now;
            var startTime = date.AddDays(1 - date.Day);
            var endTime = startTime.AddMonths(1).AddDays(-1);

            ViewBag.StartTime = startTime.ToString(AppConst.DateFormat);
            ViewBag.EndTime = endTime.ToString(AppConst.DateFormat);

            return View();
        }

        /// <summary>
        /// 违停作废界面
        /// </summary>
        /// <param name="con"></param>
        /// <param name="checkid"></param>
        /// <returns></returns>
        public ActionResult TransactLog(string con, string checkid)
        {
            var hand = new InfCarHandlerEntity
            {
                CheckSigniId = checkid,
                HandContent = con,
                HandleIp = CommonMethod.ClientIP(),
                HandPersonId = CurrentUser.CrmUser.UserName
            };
            return View(hand);
        }

        /// <summary>
        /// 违停详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ParkingDetail(string id)
        {
            var entity = new InfCarChecksignEntity();
            if (!string.IsNullOrEmpty(id))
            {
                entity = _carBll.Get(id);
            }

            var detailEntity = ConverInf(entity);    //查看合成照片
            entity.BigPicAddress = detailEntity.BigPicAddress;
            entity.BigPicName = detailEntity.BigPicName;
            entity.BigPicId = detailEntity.BigPicId;

            //缴款方式
            var paymentTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0022" });
            paymentTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["PaymentTypes"] = new SelectList(paymentTypes, "Id", "RsKey");

            //证件类型
            var targetPaperTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0013" });
            targetPaperTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TargetPaperTypes"] = new SelectList(targetPaperTypes, "Id", "Rskey");

            //车辆类型
            var carCarType = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0023" });

            var carType = carCarType.Where(x => x.Id == entity.CarType).ToList();
            ViewBag.CarType = carType.Any() ? carType[0].RsKey : "";

            return View(entity);
        }

        /// <summary>
        /// 违停处理界面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult TransactEntry(string id)
        {
            //证件类型 
            var types = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0013" });
            types.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["Types"] = new SelectList(types, "Id", "RsKey", "00130002");

            //性别
            var sexs = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0014" });
            sexs.Insert(0, new ComResourceEntity { RsValue = "", RsKey = "==请选择==" });
            ViewData["Sexs"] = new SelectList(sexs, "RsValue", "RsKey", "");

            //缴款方式
            var paymentTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0022" }).ToList();
            paymentTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["PaymentTypes"] = new SelectList(paymentTypes, "Id", "RsKey", "00220002");

            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                var hand = new InfCarHandlerEntity()
                {
                    HandleIp = CommonMethod.ClientIP(),
                    HandDate = DateTime.Now,
                    HandContent = "罚款处理",
                    HandType = "511",
                    HandPersonId = CurrentUser.CrmUser.UserName
                };
                ViewBag.CheckId = id;
                return View(hand);
            }
            return View(new InfCarHandlerEntity());
        }


        /// <summary>
        /// 打印预览照片
        /// 添加人：周 鹏
        /// 添加时间：2015-04-10
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="fileId">照片ID</param>
        /// <returns>ActionResult.</returns>
        public ActionResult FilePrintView(string fileId)
        {
            var dt = _carBll.QueryPhotoDetails(fileId);
            var fileView = "";
            var itemName = "";
            var shootAddress = "";
            var shootTime = "";
            var shootPersoneNameFirst = "";
            var shootPersoneNameSecond = "";
            if (dt != null)
            {
                itemName = "不按照规定在城市人行道上停放机动车";
                shootAddress = dt.Rows[0]["CaseAddress"].ToString();
                shootPersoneNameFirst = dt.Rows[0]["RePersonelNameFist"].ToString();
                shootPersoneNameSecond = dt.Rows[0]["RePersonelNameSecond"].ToString();
                shootTime = Convert.ToDateTime(dt.Rows[0]["ShootTime"].ToString()).ToString("yyyy-MM-dd HH:mm");
                fileView = AppConfig.FileViewLink + dt.Rows[0]["ImgAddress"];
            }
            ViewBag.FileView = fileView;
            ViewBag.FileId = fileId;
            ViewBag.ItemName = itemName;
            ViewBag.ShootAddress = shootAddress;
            ViewBag.ShootTime = shootTime;
            ViewBag.ShootPersoneNameFirst = shootPersoneNameFirst;
            ViewBag.ShootPersoneNameSecond = shootPersoneNameSecond;
            return View();
        }

        #endregion

        #region Ajax

        /// <summary>
        /// 请求违停Json数据（一级审核）
        /// 添加人：
        /// </summary>
        /// 添加时间：2014-12-22
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2014-12-30 周 鹏 修改为JsonConvert进行转换
        ///           2015-04-03 周 鹏 修改数据源的查询方式
        /// </history>
        /// <param name="noticeNo">通知书编号</param>
        /// <param name="carNo">车牌号码</param>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">部门ID</param>
        /// <returns></returns>
        public string QueryListJsonFirst(string companyId, string deptId, string noticeNo, string carNo, string state)
        {
            var data = _carMiddleBll.GetSearchResult(new CarList()
                    {
                        CompanyId = companyId,
                        NoticeNo = noticeNo,
                        CarNo = carNo,
                        DeptId = deptId,
                        State = state
                    });

            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss" };
            return JsonConvert.SerializeObject(data, timeConverter);
        }

        /// <summary>
        /// 请求违停Json数据详情（一级审核）
        /// 添加人：周 鹏
        /// 添加时间：2014-12-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult CheckMiddleDetails(string id)
        {
            var entity = _carMiddleBll.Get(id);
            //附件信息
            var picitems = new InfCarAttachBll().Query(Model.QueryCondition.Instance.AddEqual(InfCarAttachEntity.Parm_INF_CAR_ATTACH_ResourceId, entity.Id).AddEqual(InfCarAttachEntity.Parm_INF_CAR_ATTACH_FileType, "1"));
            var pics = picitems.Select(item => AppConfig.FileViewLink + item.ImgAddress).ToList();
            var result = new CheckMiddleDetails()
            {
                Id = entity.Id,
                NoticeNo = entity.NoticeNo,
                CarNo = entity.CarNo,
                CarType = entity.CarType,
                Address = entity.CheckSignAddress,
                CheckDate = entity.CheckDate.ToString("yyyy-MM-dd HH:mm"),
                DeptId = entity.DeptId,
                DeptName = entity.DeptName,
                PersonFirst = entity.PersonName1,
                PersonSecond = entity.PersonName2,
                State = entity.State,
                PicItems = pics
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 验证是否重复贴单
        /// </summary>
        /// <param name="carNo">车牌号码</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public JsonResult CheckRepeat(string carNo, string type)
        {
            var rtState = 0;
            try
            {
                if (!string.IsNullOrEmpty(carNo) && !string.IsNullOrEmpty(type))
                {
                    var ck = new InfCarChecksignBll().CheckRepeat(carNo, type);
                    rtState = !ck ? 0 : 2;
                }
                else
                {
                    rtState = 1;
                }
            }
            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 一级审核数据保存
        /// 添加人：周 鹏
        /// 添加时间：2015-04-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">主键编号</param>
        /// <param name="carNo">车牌号</param>
        /// <param name="carType">车辆类型</param>
        /// <param name="noticeNo">通知书编号</param>
        /// <param name="address">地址</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveMiddle(string id, string carNo, string carType, string noticeNo, string address)
        {
            var rtState = 0;
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var entity = new InfCarChecksignmiddleBll().Get(id);
                    entity.CarNo = carNo;
                    entity.CarType = carType;
                    entity.NoticeNo = noticeNo;
                    entity.CheckSignAddress = address;
                    new InfCarChecksignmiddleBll().Update(entity);
                }
                else
                {
                    rtState = 1;
                }
            }
            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 一级审核 审批
        /// 添加人：周 鹏
        /// 添加时间：2015-04-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">主键编号</param>
        /// <param name="handle">处理类型</param>
        /// <returns></returns>
        public JsonResult MiddleHandle(string id, string handle)
        {
            var rtState = 0;
            try
            {
                if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(handle))
                {
                    var entity = new InfCarChecksignmiddleBll().Get(id);
                    if (handle.Equals("pass"))
                    {
                        entity.State = "1";
                        var checkSignEntity = MiddleConvert(entity);
                        _carBll.Add(checkSignEntity);
                        //记录操作日志
                        var hand = new InfCarHandlerEntity()
                        {
                            Id = Guid.NewGuid().ToString(),
                            HandPersonId = CurrentUser.CrmUser.Id,
                            CheckSigniId = id,
                            HandType = "1",
                            HandContent = "一级审核",
                            HandleIp = CommonMethod.ClientIP(),
                            HandDate = DateTime.Now,
                            HandReason = ""
                        };
                        new InfCarHandlerBll().Add(hand);
                    }
                    _carMiddleBll.Update(entity);
                }
            }
            catch (Exception ex)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 请求违停Json数据（二级审批、作废审批）
        /// 添加人：张晖
        /// 添加时间：2014-12-22
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        ///           2014-12-30 周 鹏 修改为JsonConvert进行转换
        ///           2015-04-03 周 鹏 修改数据源
        /// </hisotry>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="carNo">车牌号码</param>
        /// <param name="qType">查询类型：未审批、作废审批</param>
        /// <param name="sTime">违章开始日期</param>
        /// <param name="eTime">违章截止日期</param>
        /// <returns></returns>
        public string QueryListJson(string companyId, string deptId, string carNo, string qType, string sTime, string eTime, string audit)
        {
            var data =
                _carBll.GetSearchResult(
                    new CarList()
                        {
                            CompanyId = companyId,
                            DeptId = deptId,
                            CarNo = carNo,
                            StartDate = sTime,
                            EndDate = eTime,
                            State = audit
                        },
                    qType);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss" };
            return JsonConvert.SerializeObject(data, timeConverter);
        }

        /// <summary>
        /// 根据违停ID获取违停数据
        /// 添加人：张晖
        /// 添加时间：2014-12-22
        /// </summary>
        /// <param name="id">主键编号</param>
        /// <returns></returns>
        public JsonResult CheckSignDetails(string id)
        {
            //合成照片
            var result = ConverInf(_carBll.Get(id));
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 二级、作废审批
        /// 添加人：张晖
        /// 添加时间：2014-12-24
        /// </summary>
        /// <param name="id">数据主键</param>
        /// <param name="handle">处理步骤：审批通过 Agree, 同意作废 AgreeInvalid,不同意作废DisAgreeInvalid </param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveCheck(string id, string handle)
        {
            var rtState = 0;
            try
            {
                if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(handle))
                {
                    var result = _carBll.Get(id);
                    switch (handle)
                    {
                        case "Agree":
                            {
                                result.Isaudit = 1;
                                //记录操作日志
                                var hand = new InfCarHandlerEntity()
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    HandPersonId = CurrentUser.CrmUser.Id,
                                    CheckSigniId = id,
                                    HandType = "2",
                                    HandContent = "二级审核",
                                    HandleIp = CommonMethod.ClientIP(),
                                    HandDate = DateTime.Now,
                                    HandReason = ""
                                };
                                new InfCarHandlerBll().Add(hand);
                            }
                            break;
                        case "AgreeInvalid":     //二级审批同意作废
                            {
                                result.Isaudit = -1;
                                result.State = 404;
                                var user = CurrentUser.CrmUser;
                                var hand = new InfCarHandlerEntity
                                    {
                                        CheckSigniId = id,
                                        HandleIp = CommonMethod.ClientIP(),
                                        HandDate = DateTime.Now,
                                        HandPersonId = CurrentUser.CrmUser.Id,
                                        RowStatus = 1,
                                        HandContent = "二级作废审核",
                                        CreatorId = user.Id,
                                        CreateBy = user.UserName,
                                        CreateOn = DateTime.Now,
                                        UpdateId = user.Id,
                                        UpdateBy = user.UserName,
                                        UpdateOn = DateTime.Now,
                                        HandType = "2"
                                    };
                                new InfCarHandlerBll().Add(hand);

                            }
                            break;
                        case "DisAgreeInvalid":
                            {
                                //记录操作日志
                                var hand = new InfCarHandlerEntity()
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    HandPersonId = CurrentUser.CrmUser.Id,
                                    CheckSigniId = id,
                                    HandType = "2",
                                    HandContent = "二级作废审核",
                                    HandleIp = CommonMethod.ClientIP(),
                                    HandDate = DateTime.Now,
                                    HandReason = ""
                                };
                                new InfCarHandlerBll().Add(hand);

                                result.Isaudit = 3;
                            }
                            break;
                    }
                    _carBll.Update(result);
                }
                else
                {
                    rtState = 1;
                }
            }
            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 违章停车数据查询
        /// 添加人：周 鹏
        /// 添加时间：2015-04-07
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="carNo">车牌号码</param>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">所属部门</param>
        /// <param name="state">查询状态</param>
        /// <param name="startDate">查询开始时间</param>
        /// <param name="endDate">查询截止时间</param>
        /// <param name="noticeNo">通知书编号</param>
        /// <param name="caseinfoNo">案件编号</param>
        /// <param name="address">地点</param>
        /// <param name="rows">每页显示条数</param>
        /// <param name="page">当前索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <returns>System.String.</returns>
        public string ParkingQueryGridJson(string carNo, string companyId, string deptId, string state, string startDate, string endDate, string noticeNo, string caseinfoNo,string address, int rows, int page, string sidx, string sord)
        {
            var data = _carBll.GetSearchResult(carNo, companyId, deptId, state, startDate, endDate, noticeNo, caseinfoNo,address, page, rows, sidx, sord);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
            return JsonConvert.SerializeObject(data, timeConverter);
        }


        /// <summary>
        /// 获取操作日志
        /// </summary>
        /// <param name="id">外键ID</param>
        /// <returns></returns>
        public string QueryListJsonHandle(string id)
        {
            var data = new InfCarHandlerBll().GetSearchResult(id);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
            return JsonConvert.SerializeObject(data, timeConverter);
        }


        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Add(InfCarChecksignEntity check, string picStr)
        {
            var rtState = 0;
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            try
            {
                var user = CurrentUser.CrmUser;
                if (true)
                {
                    //查询车牌号是否在白名单内
                    var whiteList = new ComWhiteListBll().GetSearchResult(new ComWhiteListEntity { PlateNumber = "" });
                    for (int i = 0; i < whiteList.Count; i++)
                    {
                        if (whiteList[i].PlateNumber.Contains(check.CarNo))
                        {
                            rtState = -1;
                            rtEntity = new StatusModel<DBNull>
                            {
                                rtData = null,
                                rtMsrg = "成功",
                                rtState = rtState
                            };
                            return Json(rtEntity, JsonRequestBehavior.AllowGet);
                        }
                    }

                    check.RowStatus = 1;
                    check.CreateBy = user.UserName;
                    check.CreateOn = DateTime.Now;
                    check.CreatorId = user.Id;
                    check.UpdateBy = user.UserName;
                    check.UpdateId = user.Id;
                    check.UpdateOn = DateTime.Now;
                    check.DeptId = user.DeptId;
                    check.DeptName = _crmDeptBll.Get(check.DeptId).FullName;
                    check.PersonName1 = _crmUserBll.Get(check.PersonId1).UserName;
                    check.PersonName2 = _crmUserBll.Get(check.PersonId2).UserName;
                    check.TypeNo = "00090005";
                    check.ReSourceId = "00100001";
                    check.DataSource = 0;
                    check.NoticeNo = _comNumberBll.GetNumber(AppConst.NumWt, "", null); //生成案件的编号

                    //保存生成的案件编号
                    new InfSimpleNumberBll().Add(check.NoticeNo, user.Id, user.UserName);
                    //案件概况
                    check.SimpleInfo = Convert.ToDateTime(check.CheckDate).ToString("yyyy年MM月dd日", DateTimeFormatInfo.InvariantInfo) + "，" +
                                            check.DeptName + "执法队员巡查时，发现一辆车牌号码为" + check.CarNo + "的" + new ComResourceBll().Get(check.CarType).RsKey
                                           + "车辆停放在" + check.CheckSignAddress + check.Address + "，该车在城市道路上不按规定停放。";
                    check.Whqk = "妨碍其他车辆、行人通行"; //危害情况
                    check.State = 0;         //状态  未处理
                    check.RowStatus = 1;      //默认未删除
                    var attchs = new List<InfCarAttachEntity>();
                    if (check.Id.Equals("") || check.Id.Equals("0"))
                    {
                        check.Id = Guid.NewGuid().ToString();
                        if (picStr != "")
                        {
                            var pics = picStr.Split(',');
                            foreach (var item in pics)
                            {
                                if (item == "") continue;
                                var picitems = item.Split('|');
                                var att = new InfCarAttachEntity
                                    {
                                        ResourceId = check.Id,
                                        FileType = "1",
                                        FileName = picitems[0],
                                        ImgAddress = picitems[2],
                                        FileDesc = picitems[1],
                                        RowStatus = 1,
                                        CreateBy = check.CreateBy,
                                        CreateOn = DateTime.Now,
                                        CreatorId = CurrentUser.CrmUser.Id,
                                        UpdateBy = CurrentUser.CrmUser.UserName,
                                        UpdateId = CurrentUser.CrmUser.Id,
                                        UpdateOn = DateTime.Now
                                    };
                                attchs.Add(att);
                            }
                        }
                        if (attchs.Count > 0)
                        {
                            foreach (var item in attchs)
                            {
                                new InfCarAttachBll().Add(item);
                            }
                        }
                        _carBll.Add(check);
                    }
                    else
                    {
                        int result = _carBll.Update(check);
                    }
                    rtState = 0;
                }
            }
            catch (Exception)
            {
                rtState = 1;
            }
            rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        #region CheckSignMiddle 转 CheckSign
        private InfCarChecksignEntity MiddleConvert(InfCarChecksignmiddleEntity result)
        {
            try
            {
                var carEity = new InfCarChecksignEntity()
                {
                    Id = result.Id,
                    CheckSignNo = result.CheckSignNo,
                    TypeNo = result.TypeNo,
                    ReSourceId = result.ResourceId,
                    DataSource = 1,
                    DeptId = result.DeptId,
                    DeptName = result.DeptName,
                    CheckDate = result.CheckDate,
                    PersonId1 = result.PersonId1,
                    PersonId2 = result.PersonId2,
                    PersonName1 = result.PersonName1,
                    PersonName2 = result.PersonName2,
                    Name = result.Name,
                    Sex = result.Sex,
                    PersonNo = result.Personno,
                    Address = result.Address,
                    Telephone = result.Telephone,
                    CarNo = result.CarNo,
                    CarType = result.CarType,
                    Road = result.Road,
                    Toward = result.Toward,
                    CheckSignAddress = result.CheckSignAddress,
                    SimpleInfo = result.Simpleinfo,
                    NoticeNo = result.NoticeNo,
                    Whqk = result.Whqk,
                    CfapproveNo = result.Cfapproveno,
                    PostNo = result.PostNo,
                    Job = result.Job,
                    CreateOn = result.CreateOn,
                    CreateBy = result.CreateBy,
                    UpdateBy = result.UpdateBy,
                    UpdateOn = result.UpdateOn,
                    Money = result.Money,
                    State = 0,  //状态默认为0
                    RowStatus = 1,
                    PdaNo = result.PDANo,
                    Isaudit = 0, //大队是否审核
                    Printtzs = result.Printtzs,
                    Isgq = 0,
                    IsAutoaudit = 0   //是否是自动审核
                };
                return carEity;
            }
            catch (Exception)
            {
                return new InfCarChecksignEntity();
            }
        }
        #endregion

        #region 案件作废、教育、建议作废、恢复处理

        public object Obj = new object();

        /// <summary>
        /// 作废、教育处理保存
        /// </summary>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult UpdateState(InfCarHandlerEntity hand)
        {
            var rtState = 1;
            try
            {
                var user = CurrentUser.CrmUser;
                hand.HandleIp = CommonMethod.ClientIP();
                hand.HandDate = DateTime.Now;
                hand.HandPersonId = CurrentUser.CrmUser.Id;
                hand.RowStatus = 1;
                hand.CreatorId = user.Id;
                hand.CreateBy = user.UserName;
                hand.CreateOn = DateTime.Now;
                hand.UpdateId = user.Id;
                hand.UpdateBy = user.UserName;
                hand.UpdateOn = DateTime.Now;

                if (hand.HandContent != null && hand.HandContent == "教育处理")
                {
                    var check = _carBll.Get(hand.CheckSigniId);
                    check.State = 777;
                    check.Remark = hand.HandReason;
                    _carBll.Update(check);

                    //记录至案件操作日志中
                    hand.HandType = "777";
                    new InfCarHandlerBll().Add(hand);

                }
                else if (hand.HandContent == "一级审核作废") //PDA 上传的案件作废处理 
                {
                    MiddleCar_Invalid(hand);
                }
                else if (hand.HandContent == "建议作废")
                {
                    //记录至案件操作日志中
                    hand.HandType = "3";
                    new InfCarHandlerBll().Add(hand);

                    var check = _carBll.Get(hand.CheckSigniId);
                    check.Isaudit = 2;//建议作废状态
                    _carBll.Update(check);
                }
                else if (hand.HandContent == "恢复处理")
                {
                    var check = _carBll.Get(hand.CheckSigniId);
                    check.State = 0;//恢复状态
                    _carBll.Update(check);

                    hand.HandType = "1";
                    new InfCarHandlerBll().Add(hand);
                }
            }
            catch
            {
                rtState = 0;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// PDA 案件作废
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public bool MiddleCar_Invalid(InfCarHandlerEntity hand)
        {
            try
            {
                var checkSignId = hand.CheckSigniId;
                if (!string.IsNullOrEmpty(checkSignId))
                {
                    var checkSignMiddleModel = _carMiddleBll.Get(checkSignId);
                    if (checkSignMiddleModel != null)
                    {
                        var user = CurrentUser.CrmUser;
                        hand.HandPersonId = CurrentUser.CrmUser.Id;
                        hand.HandType = "404";
                        hand.HandContent = "作废处理";
                        hand.HandleIp = CommonMethod.ClientIP();
                        hand.HandDate = DateTime.Now;
                        hand.CreatorId = user.Id;
                        hand.CreateBy = user.UserName;
                        hand.CreateOn = DateTime.Now;
                        hand.UpdateId = user.Id;
                        hand.UpdateBy = user.UserName;
                        hand.UpdateOn = DateTime.Now;

                        //添加至日志
                        new InfCarHandlerBll().Add(hand);
                        checkSignMiddleModel.State = "404";

                        //更改状态
                        _carMiddleBll.Update(checkSignMiddleModel);

                        ////同时将信息插入到主表里面
                        //var checkSignEntity = MiddleConvert(checkSignMiddleModel);
                        //checkSignEntity.State = 404;
                        //_carBll.Add(checkSignEntity);

                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        #endregion

        #region 案件罚款处理方法

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult CarHandle(InfCarChecksignEntity check)
        {
            var rtState = 0;
            try
            {
                var entity = _carBll.Get(check.Id);
                var handReason = Request["HandReason"];
                if (entity != null)
                {
                    entity.Address = check.Address;
                    entity.Age = check.Age;
                    entity.CbrDate = DateTime.Now;
                    entity.State = 511;
                    entity.Name = check.Name;
                    entity.Money = check.Money;
                    entity.ZjType = check.ZjType;
                    entity.Sex = check.Sex;
                    entity.Telephone = check.Telephone;
                    entity.Job = check.Job;
                    entity.PersonNo = check.PersonNo;
                    entity.PaymentNum = check.PaymentNum;
                    entity.CfapproveNo = _comNumberBll.GetNumber(AppConst.NumSimpleDecision, "", null); //生成案件的处罚决定书编号

                    var user = CurrentUser.CrmUser;

                    //保存生成的案件编号
                    new InfSimpleNumberBll().Add(entity.CfapproveNo, user.Id, user.UserName);
                    var hand = new InfCarHandlerEntity
                    {
                        Id = Guid.NewGuid().ToString(),
                        CheckSigniId = check.Id,
                        HandPersonId = user.Id,
                        HandType = "511",
                        HandContent = "罚款处理",
                        HandleIp = CommonMethod.ClientIP(),
                        HandDate = DateTime.Now,
                        HandReason = handReason,
                        CreatorId = user.Id,
                        CreateBy = user.UserName,
                        CreateOn = DateTime.Now,
                        UpdateId = user.Id,
                        UpdateBy = user.UserName,
                        UpdateOn = DateTime.Now
                    };
                    new InfCarHandlerBll().Add(hand);
                    _carBll.Update(entity);
                    rtState = 0;
                }
            }

            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 照片合成
        /// <summary>
        /// 照片合成
        /// 添加人：周 鹏
        /// 添加时间：2015-04-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search"></param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        private CheckSignDetails ConverInf(InfCarChecksignEntity search)
        {
            try
            {
                var resultEntity = new CheckSignDetails();

                var listWt = new InfCarAttachBll().Query(Model.QueryCondition.Instance.AddEqual(InfCarAttachEntity.Parm_INF_CAR_ATTACH_ResourceId, search.Id).
                        AddEqual(InfCarAttachEntity.Parm_INF_CAR_ATTACH_FileType, "2"));
                string picCompleteAddr = "";  //合成后的照片

                //如果该条案件没有合成照片，合成案件照片，有的话，则直接取
                if (listWt.Count <= 0)
                {
                    #region 合成照片
                    //设备编号
                    var sbCode = AppConfig.SBCode;
                    ////公路等级
                    //违法行为
                    var wfxw = AppConfig.WFXW;
                    //发现机关
                    var fxjg = AppConfig.FXJG;
                    //执勤民警
                    var zqmj = AppConfig.ZQMJ;
                    //实测值
                    var scValue = AppConfig.SCValue;
                    //标准值
                    var bzValue = AppConfig.BZValue;
                    //通知书编号
                    var tzsbh = AppConfig.TZSBH;
                    //采集方式
                    var cjfs = AppConfig.CJFS;
                    //识别用户
                    var sbyh = AppConfig.SBYH;
                    //总数
                    var total = AppConfig.Total;
                    //序号
                    var sn = AppConfig.SN;
                    //备注
                    var remark = AppConfig.Remark;
                    //版本
                    var ver = AppConfig.Ver;

                    //取得案件的单张照片
                    listWt = new InfCarAttachBll().Query(Model.QueryCondition.Instance.AddEqual(InfCarAttachEntity.Parm_INF_CAR_ATTACH_ResourceId, search.Id).
                        AddEqual(InfCarAttachEntity.Parm_INF_CAR_ATTACH_FileType, "1"));
                    if (listWt != null && listWt.Count > 0)
                    {
                        var filename = "";

                        #region 构造附件名称
                        filename = sbCode + "_"; //设备编号
                        var road = search.Road;

                        string _GLDJ = "9999";
                        filename += road + "_";//主干道地点代码
                        filename += _GLDJ + "_";//公路等级
                        filename += search.CheckSignAddress + "_";//违章地点
                        filename += "9_"; //方向

                        var checkDate = search.CheckDate;

                        var ctime = checkDate.ToString("yyyyMMddHHmmss");

                        filename += ctime + "_";//违章时间
                        filename += scValue + "_";//实测值
                        filename += bzValue + "_";//标准值
                        filename += new ComResourceBll().Get(search.CarType).RsValue + "_"; //号牌种类
                        var carno = search.CarNo;
                        if (carno.Substring(carno.Length - 1, 1) == "学" || carno.Substring(carno.Length - 1, 1) == "挂" || carno.Substring(carno.Length - 1, 1) == "警")//判断车牌号码后面是否带学或挂等字
                        {//如果包含学或挂字，去掉
                            carno = carno.Substring(0, carno.Length - 1);
                        }
                        filename += carno + "_";//车牌号码
                        filename += wfxw + "_";//违法行为
                        filename += fxjg + "_";//发现机关
                        filename += zqmj + "_";//执勤民警
                        filename += tzsbh + "_";//通知书编号
                        filename += cjfs + "_";//采集方式
                        filename += sbyh + "_";//识别用户
                        filename += total + "_";//总数
                        filename += sn + "_";//序号
                        filename += remark + "_";//备注
                        filename += ver;//版本
                        #endregion

                        var fjFileName = filename + ".JPG";//合并的照片名称

                        #region 创建合成文件
                        string filePath1 = "", filePath2 = "", filePath3 = "";
                        for (var i = 0; i < listWt.Count; i++)
                        {
                            var imgAddr = "";
                            if (listWt[i].ImgAddress != null)
                                imgAddr = listWt[i].ImgAddress;  //单张照片的路径
                            switch (i)
                            {
                                case 0:
                                    filePath1 = imgAddr;
                                    break;
                                case 1:
                                    filePath2 = imgAddr;
                                    break;
                                case 2:
                                    filePath3 = imgAddr;
                                    break;
                            }
                        }
                        var pwh = AppConfig.Pwh;
                        var w = int.Parse(pwh.Split('|')[0]);//获得指定宽度
                        var h = int.Parse(pwh.Split('|')[1]);//获得指定高度

                        if (filePath1 != "" && filePath2 != "")  //判断如果本地照片数量大于2张的话，则调用合成方法
                        {
                            //调用服务执行合并生成违章停车照片方法
                            var pictureService = new PictureService.PictureService(AppConfig.FileSaveServiceLink);
                            picCompleteAddr = pictureService.MakewatermarkNew(filePath1, filePath2, filePath3, fjFileName, "", w, h, "HW", "1");
                        }
                        else if (filePath1 != "" && filePath2 == "" && filePath3 == "") //如果只有一张单张片,复制一张添加进去。
                        {
                            //调用服务执行复制重命名图片
                            var pictureService = new PictureService.PictureService(AppConfig.FileSaveServiceLink);
                            picCompleteAddr = pictureService.CopNewPic(filePath1, fjFileName);
                        }

                        //将新的合成图片保存附件至数据库中
                        if (picCompleteAddr != "")
                        {
                            var pic = new InfCarAttachEntity()
                            {
                                ImgAddress = picCompleteAddr,
                                FileType = "2",
                                FileName = fjFileName,
                                CreateBy = CurrentUser.CrmUser.Id,
                                CreateDate = DateTime.Now,
                                RowStatus = 1,
                                ResourceId = search.Id
                            };
                            new InfCarAttachBll().Add(pic);
                        }
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    listWt[0].ImgAddress.Trim();
                }

                //合成照片路径赋值

                var sigPic = new InfCarAttachBll().Query(Model.QueryCondition.Instance.AddEqual(InfCarAttachEntity.Parm_INF_CAR_ATTACH_FileType, "2").AddEqual(InfCarAttachEntity.Parm_INF_CAR_ATTACH_ResourceId, search.Id));
                if (sigPic.Count > 0)
                {
                    resultEntity.BigPicAddress = AppConfig.FileViewLink + sigPic[0].ImgAddress;
                    resultEntity.BigPicName = sigPic[0].FileName;
                    resultEntity.BigPicId = sigPic[0].Id;
                }
                var ss = new InfCarHandlerBll().Query(Model.QueryCondition.Instance.AddEqual(InfCarHandlerEntity.Parm_INF_CAR_HANDLER_CheckSigniId, search.Id).AddEqual(InfCarHandlerEntity.Parm_INF_CAR_HANDLER_HandType, "3"));
                if (ss.Count > 0)
                {
                    resultEntity.Reason = ss[0].HandReason;
                }
                resultEntity.CarNo = search.CarNo;
                resultEntity.CheckDate = search.CheckDate.ToString("yyyy-MM-dd HH:mm");
                resultEntity.Id = search.Id;
                resultEntity.Andit = search.Isaudit;
                return resultEntity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion


        /// <summary>
        /// 保存证据信息
        /// 添加人：周 鹏
        /// 添加时间：2015-04-10
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="fileId">图片ID</param>
        /// <param name="shootTime">拍摄时间</param>
        /// <returns>JsonResult.</returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SavePhotoDetails(string fileId, string shootTime)
        {
            var isOk = false;
            try
            {
                if (!string.IsNullOrEmpty(fileId) && !string.IsNullOrEmpty(shootTime))
                {
                    var user = CurrentUser.CrmUser;
                    var entity = _carAttachBll.Get(fileId);
                    entity.UpdateBy = user.UserName;
                    entity.UpdateId = user.Id;
                    entity.UpdateOn = DateTime.Now;
                    entity.ShootTime = Convert.ToDateTime(shootTime);
                    isOk = _carAttachBll.Update(entity) > 0;
                }
            }
            catch (Exception)
            {
                isOk = false;
            }

            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查询违停处理数据
        /// 添加人：周 鹏
        /// 添加时间：2015-06-15
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="handleType">查询类型</param>
        /// <param name="rows">每页请求条数</param>
        /// <param name="page">当前索引页</param>
        /// <returns>System.String.</returns>
        public string QueryHandleGrid(string startTime, string endTime, string handleType, int rows, int page)
        {
            var data = _carBll.QueryHandleGrid(startTime, endTime, handleType, page, rows);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }


        /// <summary>
        /// Ajax 加载路段
        /// 添加人：周 鹏
        /// 添加时间：2015-03-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="selectId">路段控件ID</param>
        /// <param name="word">字母</param>
        /// <returns></returns>
        public string AjLoadRoads(string selectId, string word)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("document.getElementById('{0}').options.length = 1;", selectId);
            if (!string.IsNullOrEmpty(word))
            {
                var items = new RoadManagerBll().GetSearchResult(new RoadManagerEntity { RoadName = word });
                if (items.Any())
                {
                    var i = 0;
                    foreach (var t in items.Where(t => !string.IsNullOrEmpty(t.RoadName)))
                    {
                        sb.Append("document.getElementById('" + selectId + "').options[" + i + "] = new Option('" + t.RoadName + "', '" + t.RoadNo + "', false,false);");
                        i++;
                    }
                }
            }
            return sb.ToString();
        }
        #endregion
    }
}