using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.License;
using Yookey.WisdomClassed.SIP.Business.Mobile;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.License;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Consent;
using Yookey.WisdomClassed.SIP.Business.FlowEditor;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.WebService.License
{
    /// <summary>
    /// License 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class License : System.Web.Services.WebService
    {
        readonly ComResourceBll _comResourceBll = new ComResourceBll();
        readonly ApproveBll _approveBll = new ApproveBll();

        /// <summary>
        /// 许可数据查询
        /// 添加人：周 鹏
        /// 添加时间：2018-02-05
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">{QueryType:请求类型,KeyWord:查询关键字,PageIndex当前页,PageSize:每页请求条数}</param>
        /// <returns></returns>
        [WebMethod]
        public string GetPermissionList(string context)
        {
            //var result = "";
            bool Status = false;
            var msg = "";
            object obj = null;
            var timeConverter = new IsoDateTimeConverter();
            try
            {
                var checkResult = CommonMethod.ProcessSqlStr(context);
                if (!checkResult)
                {
                    //return "有SQL攻击嫌疑！";
                    Status = false;
                    msg = "有SQL攻击嫌疑！";
                }

                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var companyId = Regex.Match(context, @"(?<=""CompanyId""\:"").*?(?="",)").Value;    //所属大队
                    var queryType = Regex.Match(context, @"(?<=""QueryType""\:"").*?(?="",)").Value;    //查询类型：店招标牌、临时占道堆物、阵地广告
                    var queryState = Regex.Match(context, @"(?<=""QueryState""\:"").*?(?="",)").Value;   //查询状态
                    var keyWord = Regex.Match(context, @"(?<=""KeyWord""\:"").*?(?="",)").Value;        //查询关键字
                    var pageIndex = Regex.Match(context, @"(?<=""PageIndex""\:"").*?(?="",)").Value;    //分页索引
                    var pageSize = Regex.Match(context, @"(?<=""PageSize""\:"").*?(?="",)").Value;      //每页条数
                    var startTime = Regex.Match(context, @"(?<=""StartTime""\:"").*?(?="",)").Value;      //开始时间
                    var endTime = Regex.Match(context, @"(?<=""EndTime""\:"").*?(?="",)").Value;      //结束时间
                    var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;      //查询人员ID
                    var dataSource = Regex.Match(context, @"(?<=""DataSource""\:"").*?(?="",)").Value;      //数据来源（1.窗口 2.历史数据 3.直属大队历史数据）
                    var seeAll = false;
                    if (!string.IsNullOrEmpty(userId))
                    {
                        var userMenus = new ComMenuBll().GetUserMenus(userId);
                        var isAll = userMenus.FindIndex(x => x.Controller != null && x.Controller.Equals("LicenseList") && x.Action != null && x.Action.Equals("All"));   //获取功能
                        if (isAll != -1)
                        {
                            seeAll = true;
                            companyId = string.Empty;
                        }
                        else
                            queryState = LicenseStateType.HaveDone.ToString();
                    }
                    var permissionData = new DataTable();
                    if (dataSource == "0")
                    {
                        dataSource = string.Empty;
                    }
                    permissionData = new LicenseMainBll().MobileQueryLicenseList(queryState, queryType, string.Empty, keyWord, startTime, endTime, dataSource, string.Empty, int.Parse(pageSize), int.Parse(pageIndex));

                    timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
                    //转Json
                    //result = JsonConvert.SerializeObject(permissionData, timeConverter);
                    Status = true;
                    obj = permissionData;
                }
            }
            catch (Exception)
            {
                //result = "[]";
                Status = false;
            }
            //return result;
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result, timeConverter);
        }

        /// <summary>
        /// 许可数据查询
        /// 添加人：周 鹏
        /// 添加时间：2015-09-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetPermissionDetails(string context)
        {
            // var result = "";
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var checkResult = CommonMethod.ProcessSqlStr(context);
                if (!checkResult)
                {
                    //return "有SQL攻击嫌疑！";
                    Status = false;
                    msg = "有SQL攻击嫌疑！";
                }

                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var licenseId = Regex.Match(context, @"(?<=""LicenseId""\:"").*?(?="",)").Value;    //许可主键                    
                    if (string.IsNullOrEmpty(licenseId)) return "";

                    //许可主键
                    var entity = new LicenseMainBll().Get(licenseId);

                    var mainEntity = GetLiceseMainModel(entity);
                    if (mainEntity == null)
                        return "[]";

                    var itemcode = entity.ItemCode;
                    if (itemcode.Equals("JS050800ZJ-XK-0090") || itemcode.Equals("JS050800ZJ-XK-0190"))    //户外广告设置审批\大型户外广告审批
                    {
                        var outdoorEntity = new LicenseOutDoorBll().GetEntityByLicenseId(licenseId);
                        var licenseInquestSize = new LicenseInquestSizeBll().GetSearchResult(new LicenseInquestSizeEntity() { LicenseId = licenseId });
                        mainEntity.IsInquest = outdoorEntity.IsInquest;
                        mainEntity.IsCheck = outdoorEntity.IsCheck;
                        #region 广告实体赋值

                        #region
                        string checkLeftHeight = outdoorEntity.CheckLeftHeight;
                        string checkRightHeight = outdoorEntity.CheckRightHeight;
                        string checkLeftLogn = outdoorEntity.CheckLeftLogn;
                        string checkRightLogn = outdoorEntity.CheckRightLogn;

                        if (licenseInquestSize != null && licenseInquestSize.Count > 0)
                        {
                            checkLeftHeight = licenseInquestSize[0].CheckLeftHeight;
                            checkRightHeight = licenseInquestSize[0].CheckRightHeight;
                            checkLeftLogn = licenseInquestSize[0].CheckLeftLogn;
                            checkRightLogn = licenseInquestSize[0].CheckRightLogn;
                        }

                        #endregion



                        var responseEntity = new ResponseOutDoor()
                            {
                                //主信息
                                MainEntity = mainEntity,
                                Content = outdoorEntity.Content, //广告内容
                                Numbers = outdoorEntity.Numbers, //设置数量
                                OutdoorType = "", //广告类型
                                Nature = "", //广告性质
                                AcceptType = outdoorEntity.AcceptType,
                                InstallStartDate = outdoorEntity.InstallStartDate.Year > 1900 ? outdoorEntity.InstallStartDate.ToString(AppConst.DateFormat) : string.Empty, //安装开始日期
                                InstallEndDate = outdoorEntity.InstallEndDate.Year > 1900 ? outdoorEntity.InstallEndDate.ToString(AppConst.DateFormat) : string.Empty, //安装截止日期
                                CheckLeftHeight = checkLeftHeight, //勘验左领高度
                                CheckRightHeight = checkRightHeight, //勘验右领高度
                                CheckLeftLogn = checkLeftLogn, //勘验左领外挑
                                CheckRightLogn = checkRightLogn, //勘验右领外挑
                                CheckNumbers = outdoorEntity.CheckNumbers.ToString(), //勘验检查数量
                                AcceptanceCheckNumbers = outdoorEntity.AcceptanceCheckNumbers.ToString() //验收检查数量
                            };


                        if (!string.IsNullOrEmpty(outdoorEntity.OutdoorType))
                        {
                            responseEntity.OutdoorType = _comResourceBll.Get(outdoorEntity.OutdoorType).RsKey;
                        }
                        if (!string.IsNullOrEmpty(outdoorEntity.Nature))
                        {
                            responseEntity.Nature = _comResourceBll.Get(outdoorEntity.Nature).RsKey;
                        }


                        //申请填报的规格信息
                        var applicantSpecs = new LicenseSpecBll().GetSearchResult(new LicenseSpecEntity() { LicenseId = licenseId });

                        if (applicantSpecs.Any())
                        {
                            foreach (var specEntity in applicantSpecs)
                            {
                                if (!string.IsNullOrEmpty(specEntity.Width) && !string.IsNullOrEmpty(specEntity.Height))
                                {
                                    var facilityType = "";
                                    if (string.IsNullOrEmpty(specEntity.FacilityType) || specEntity.FacilityType.Equals("00570010") || specEntity.FacilityType.Equals("00660005"))
                                    {
                                        facilityType = specEntity.OtherType;
                                    }
                                    else
                                    {
                                        facilityType = _comResourceBll.Get(specEntity.FacilityType).RsKey;
                                    }
                                    mainEntity.Specs.Add(string.Format("{0} 宽{1}m X高{2}m X{3}{4}m", facilityType, specEntity.Width,
                                        specEntity.Height, itemcode.Equals("JS050800ZJ-XK-0090") ? "外挑" : "架空", specEntity.Long));
                                    mainEntity.InquestSpecs.Add(new LicenseOutDoorCheckSpec { Width = specEntity.Width, Height = specEntity.Height, Long = specEntity.Long });
                                }
                            }
                        }

                        #endregion

                        //result = JsonConvert.SerializeObject(responseEntity);
                        Status = true;
                        obj = responseEntity;
                    }
                    else
                    {
                        //result = "[]";
                        Status = false;
                    }
                }
            }
            catch (Exception)
            {
                //result = "[]";
                Status = false;
            }
            //return result;
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 许可占道数据详情
        /// 添加人：周 鹏
        /// 添加时间：2015-09-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetJeevesDetails(string context)
        {
            //var result = "";
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var checkResult = CommonMethod.ProcessSqlStr(context);
                if (!checkResult)
                {
                    //return "有SQL攻击嫌疑！";
                    Status = false;
                    msg = "有SQL攻击嫌疑！";
                }
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var licenseId = Regex.Match(context, @"(?<=""LicenseId""\:"").*?(?="",)").Value;    //许可主键                    
                    if (string.IsNullOrEmpty(licenseId)) return "";

                    //许可主键
                    var entity = new LicenseMainBll().Get(licenseId);

                    var mainEntity = GetLiceseMainModel(entity);
                    if (mainEntity == null)
                        return "[]";

                    var itemcode = entity.ItemCode;
                    if (itemcode.Equals("JS050800ZJ-XK-0020"))  //临时占道堆物
                    {
                        var licenseJeevesEntity = new LicenseJeevesBll().GetEntityByLicenseId(licenseId);
                        mainEntity.IsInquest = licenseJeevesEntity.IsInquest;
                        mainEntity.IsCheck = licenseJeevesEntity.IsCheck;
                        var responseJeeves = new ResponseJeeves()
                        {
                            MainEntity = mainEntity,
                            Content = licenseJeevesEntity.Content,
                            JeevesWidth = licenseJeevesEntity.JeevesWidth,
                            JeevesLength = licenseJeevesEntity.JeevesLength,
                            JeevesAdress = licenseJeevesEntity.JeevesAdress,
                            JeevesArea = licenseJeevesEntity.JeevesArea,
                            JeevesStartTime = licenseJeevesEntity.JeevesStartTime.Year > 1900 ? licenseJeevesEntity.JeevesStartTime.ToShortDateString() : string.Empty,
                            JeevesEndTime = licenseJeevesEntity.JeevesEndTime.Year > 1900 ? licenseJeevesEntity.JeevesEndTime.ToShortDateString() : string.Empty,
                            SetUpCycleDetails = licenseJeevesEntity.SetUpCycleDetails,
                            SetUpCycleOther = licenseJeevesEntity.SetUpCycleOther,
                            InquestAdress = licenseJeevesEntity.InquestAdress,
                            InquestWidth = licenseJeevesEntity.JeevesWidth,
                            InquestLength = licenseJeevesEntity.JeevesLength,
                            CheckWidth = licenseJeevesEntity.CheckWidth,
                            CheckLength = licenseJeevesEntity.CheckLength
                        };
                        //result = JsonConvert.SerializeObject(responseJeeves);
                        Status = true;
                        obj = responseJeeves;
                    }
                    else
                    {
                        //return "[]";
                        Status = false;
                    }
                }
            }
            catch (Exception)
            {
                //result = "[]";
                Status = false;
            }
            //return result;
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取基本信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private LiceseMainModel GetLiceseMainModel(LicenseMainEntity entity)
        {
            try
            {
                if (entity == null)
                    return new LiceseMainModel();
                //许可申请基本信息
                var mainEntity = new LiceseMainModel()
                {
                    ItemCode = entity.ItemCode,//审批事项编号
                    ApplicantTypeCode = entity.ApplicantType, // 申请人代码
                    ApplicantType = "", // 申请人类型
                    PaperType = "", // 证件类型
                    PaperCode = entity.PaperCode, // 申请人证照编号
                    ApplicantName = entity.ApplicantName,  //申请人
                    CompanyAddress = entity.CompanyAddress, // 单位地址
                    LegalPersonName = entity.LegalPersonName, // 法人代表姓名
                    LegalPersonId = entity.LegalPersonId, // 法人代表身份证
                    LinkMan = entity.LinkMan, // 联系人
                    LinkMobile = entity.LinkTel, // 联系人手机
                    SetUpStartDate = entity.SetUpStartDate.Year > 1900 ? entity.SetUpStartDate.ToString(AppConst.DateFormat) : string.Empty, // 设置开始日期
                    SetUpEndDate = entity.SetUpEndDate.Year > 1900 ? entity.SetUpEndDate.ToString(AppConst.DateFormat) : string.Empty, // 设置截个日期
                    SetUpAddress = entity.SetUpAddress, // 设置地址
                    State = entity.State, //许可状态                
                    Specs = new List<string>(), // 许可规则信息
                    ClosedIdea = entity.ClosedIdea,//办结意见回显
                    InquestSpecs = new List<LicenseOutDoorCheckSpec>(), //现场勘验信息
                    AcceptanceSpecs = new List<LicenseOutDoorCheckSpec>(), //现场验收规格信息

                    InquestNearPhotos = new List<ImageViewerModel>(), //现场勘验近景照
                    InquestFarPhotos = new List<ImageViewerModel>(), //现场勘验远景照
                    InquestSidePhotos = new List<ImageViewerModel>(), //现场勘验侧景照

                    AcceptanceNearPhotos = new List<ImageViewerModel>(), //现场验收近景照
                    AcceptanceFarPhotos = new List<ImageViewerModel>(), //现场验收远景照
                    AcceptanceSidePhotos = new List<ImageViewerModel>() //现场验收侧景照
                };
                var licesePoint = new LicensePointPositionBll();
                var licsePointEntityInquest = licesePoint.GetSearchResult(new LicensePointPositionEntity() { LicenseId = entity.Id, PointType = "00700001" });
                var licsePointEntityCheck = licesePoint.GetSearchResult(new LicensePointPositionEntity() { LicenseId = entity.Id, PointType = "00700002" });
                if (licsePointEntityInquest != null && licsePointEntityInquest.Count > 0)//踏勘
                {
                    var model = licsePointEntityInquest[0];
                    mainEntity.InquestLatitude = new Latitude { BaiDuLat = model.BaiduLat, BaiDuLng = model.BaiduLng, GpsLat = model.GPSLat, GpsLng = model.GPSLng };
                }
                if (licsePointEntityCheck != null && licsePointEntityCheck.Count > 0)//踏勘
                {
                    var model = licsePointEntityCheck[0];
                    mainEntity.CheckLatitude = new Latitude { BaiDuLat = model.BaiduLat, BaiDuLng = model.BaiduLng, GpsLat = model.GPSLat, GpsLng = model.GPSLng };
                }
                if (!string.IsNullOrEmpty(entity.ApplicantType))
                {
                    var comResourceEntity = _comResourceBll.Get(entity.ApplicantType);
                    mainEntity.ApplicantType = comResourceEntity == null ? string.Empty : comResourceEntity.RsKey;
                }
                if (!string.IsNullOrEmpty(entity.PaperType))
                {
                    var comResourceEntity = _comResourceBll.Get(entity.ApplicantType);
                    mainEntity.PaperType = comResourceEntity == null ? string.Empty : comResourceEntity.RsKey;
                }

                //获取现场勘验规格信息
                var inquestSpecs = new LicenseCheckSpecBll().GetSearchResult(new LicenseCheckSpecEntity() { LicenseId = entity.Id, CheckType = 1 });
                if (inquestSpecs.Any())
                {
                    foreach (var checkSpecEntity in inquestSpecs)
                    {
                        mainEntity.InquestSpecs.Add(new LicenseOutDoorCheckSpec()
                        {
                            Width = checkSpecEntity.Width,
                            Height = checkSpecEntity.Height,
                            Long = checkSpecEntity.Long
                        });
                    }
                }

                //获取现场验收规格信息
                var acceptancepecs = new LicenseCheckSpecBll().GetSearchResult(new LicenseCheckSpecEntity() { LicenseId = entity.Id, CheckType = 2 });
                if (acceptancepecs.Any())
                {
                    foreach (var checkSpecEntity in acceptancepecs)
                    {
                        mainEntity.AcceptanceSpecs.Add(new LicenseOutDoorCheckSpec()
                        {
                            Width = checkSpecEntity.Width,
                            Height = checkSpecEntity.Height,
                            Long = checkSpecEntity.Long
                        });
                    }
                }

                mainEntity.InquestNearPhotos = GetLicenseCheckFile(entity.Id, "00630001");
                mainEntity.InquestFarPhotos = GetLicenseCheckFile(entity.Id, "00630002");
                mainEntity.InquestSidePhotos = GetLicenseCheckFile(entity.Id, "00630003");


                mainEntity.AcceptanceNearPhotos = GetLicenseCheckFile(entity.Id, "00640001");
                mainEntity.AcceptanceFarPhotos = GetLicenseCheckFile(entity.Id, "00640002");
                mainEntity.AcceptanceSidePhotos = GetLicenseCheckFile(entity.Id, "00640003");

                return mainEntity;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #region 图片上传

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="licenseId">案件编号</param>
        /// <param name="fileType">图片的材料类型字典表0064</param>
        /// <param name="imageDate">图片的 Base64String 字符串</param>
        /// <param name="imageName">图片名称</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        [WebMethod]
        public string SaveImage(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var licenseId = Regex.Match(context, @"(?<=""licenseId""\:"").*?(?="",)").Value;
                var fileType = Regex.Match(context, @"(?<=""fileType""\:"").*?(?="",)").Value;
                var imageDate = Regex.Match(context, @"(?<=""imageDate""\:"").*?(?="",)").Value;
                var imageName = Regex.Match(context, @"(?<=""imageName""\:"").*?(?="",)").Value;
                var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;

                if (string.IsNullOrEmpty(licenseId) || string.IsNullOrEmpty(fileType) || string.IsNullOrEmpty(imageDate) || string.IsNullOrEmpty(imageName))
                {
                    //return "false";
                    Status = false;
                }
                var isOk = true;
                try
                {
                    var bytes = Convert.FromBase64String(imageDate);
                    var time = DateTime.Now;        //照片时间
                    #region 调用服务存储照片
                    var imageData = Convert.FromBase64String(imageDate);
                    var filename = GetFileName(imageName.ToLower());   //重新生成命称

                    //调用WebService进行文件存储.FileExt(postedFile.FileName)
                    var filePath = new PictureService.PictureService(AppConfig.FileSaveServiceLink).WritePictureSecond("License", CommonMethod.FileExt(imageName), filename, imageData);
                    #endregion
                    //保存至数据库
                    var licenseAttachEntity = new LicenseAttachEntity
                    {
                        Id = Guid.NewGuid().ToString(),
                        FileName = filename,
                        FileReName = imageName,
                        FileAddress = filePath,
                        FileSize = bytes.Length.ToString(),
                        FileTypeName = ".jpg",
                        ResourceId = licenseId,
                        FileType = fileType,
                        RowStatus = 1,
                        CreatorId = userId
                    };
                    new LicenseAttachBll().Add(licenseAttachEntity);
                }
                catch (Exception ex)
                {
                    //isOk = false;
                    Status = false;
                }
                //return isOk ? "true" : "false";
                Status = true;
                obj = "true";
            }
            catch (Exception)
            {
                //return JsonConvert.SerializeObject(new { });
                Status = false;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 生成文件名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        private static string GetFileName(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var filename = Regex.Match(context, @"(?<=""filename""\:"").*?(?="",)").Value;
                var random = new Random();
                var extension = ".jpg";
                if (filename.Contains("."))
                {
                    extension = filename.Substring(filename.IndexOf('.')).Length > 0
                                    ? filename.Substring(filename.IndexOf('.'))
                                    : ".jpg";
                }
                //return DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond + random.Next(10, 99) + extension;
                Status = true;
                obj = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond + random.Next(10, 99) + extension;
            }
            catch (Exception)
            {
                //return JsonConvert.SerializeObject(new { });
                Status = false;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }


        #endregion

        #region //占道 现场勘察/
        [WebMethod]
        public string SaveJeevesInquest(string context)
        {
            //var result = "";
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var checkResult = CommonMethod.ProcessSqlStr(context);
                if (!checkResult)
                {
                    //return "有SQL攻击嫌疑！";
                    Status = false;
                    msg = "有SQL攻击嫌疑！";
                }
                var entity = JsonConvert.DeserializeObject<RequestJeevesInquest>(context);
                if (string.IsNullOrEmpty(entity.LicenseId))
                {
                    //return "请传入主键ID";
                    Status = false;
                    msg = "请传入主键ID";
                }
                var isOk = new LicenseJeevesBll().SaveJeevesInquest(entity);
                //result = isOk ? "true" : "false";
                Status = true;
                obj = isOk;
            }
            catch (Exception ex)
            {
                //result = ex.Message;
                //result = "";
                Status = false;
                msg = ex.Message;
            }
            //return result;
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 现场验收
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string SaveJeevesCheck(string context)
        {
            //var result = "";
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var checkResult = CommonMethod.ProcessSqlStr(context);
                if (!checkResult)
                {
                    //return "有SQL攻击嫌疑！";
                    Status = false;
                    msg = "有SQL攻击嫌疑！";
                }
                var entity = JsonConvert.DeserializeObject<RequestJeevesCheck>(context);
                if (string.IsNullOrEmpty(entity.LicenseId))
                {
                    //return "请传入主键ID";
                    Status = false;
                    msg = "请传入主键ID";
                }
                var isOk = new LicenseJeevesBll().SaveJeevesCheck(entity);
                //result = isOk ? "true" : "false";
                Status = true;
                obj = isOk;
            }
            catch (Exception ex)
            {
                //result = ex.Message;
                //result = "";
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }



        #endregion


        #region 户外广告保存现场勘验、现场验收信息

        /// <summary>
        /// 户外广告现场勘验
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string SaveOutDoorInquestCheckSpec(string context)
        {
            //var result = "";
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var checkResult = CommonMethod.ProcessSqlStr(context);
                if (!checkResult)
                {
                    //return "有SQL攻击嫌疑！";
                    Status = false;
                    msg = "有SQL攻击嫌疑！";
                }

                var entity = JsonConvert.DeserializeObject<RequestOutDoorInquestCheckSpec>(context);
                if (string.IsNullOrEmpty(entity.LicenseId))
                {
                    //return "请传入主键ID";
                    Status = false;
                    msg = "请传入主键ID！";
                }
                var isOk = new LicenseOutDoorBll().SaveOutDoorInquestCheckSpec(entity);
                //result = isOk ? "true" : "false";
                Status = true;
                obj = isOk;
            }
            catch (Exception ex)
            {
                //result = ex.Message;
                //result = "";
                Status = false;
                msg = ex.Message;
            }
            //return result;
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 户外广告现场验收
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string SaveOutDoorAcceptanceCheckSpec(string context)
        {
            //var result = "";
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var checkResult = CommonMethod.ProcessSqlStr(context);
                if (!checkResult)
                {
                    //return "有SQL攻击嫌疑！";
                    Status = false;
                    msg = "有SQL攻击嫌疑！";
                }
                var entity = JsonConvert.DeserializeObject<RequestOutDoorAcceptanceCheckSpec>(context);
                if (string.IsNullOrEmpty(entity.LicenseId))
                {
                    //return "请传入主键ID";
                    Status = false;
                    msg = "请传入主键ID！";
                }
                var isOk = new LicenseOutDoorBll().SaveOutDoorAcceptanceCheckSpec(entity);
                //result = isOk ? "true" : "false";
                Status = true;
                obj = isOk;
            }
            catch (Exception ex)
            {
                //result = ex.Message;
                //result = "";
                Status = false;
                msg = ex.Message;
            }
            //return result;
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 保存打点坐标
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string SaveCoordinate(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var checkResult = CommonMethod.ProcessSqlStr(context);
                if (!checkResult)
                {
                    //return "有SQL攻击嫌疑！";
                    Status = false;
                    msg = "有SQL攻击嫌疑！";
                }

                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var licenseId = Regex.Match(context, @"(?<=""LicenseId""\:"").*?(?="",)").Value; //经度
                    var gpslat = Regex.Match(context, @"(?<=""Lat""\:"").*?(?="",)").Value; //经度
                    var gpslng = Regex.Match(context, @"(?<=""Lng""\:"").*?(?="",)").Value; //纬度


                    var entity = new LicenseMainBll().Get(licenseId);
                    entity.BaiduLat = Convert.ToDecimal(gpslat);
                    entity.BaiduLng = Convert.ToDecimal(gpslng);
                    //更新
                    new LicenseMainBll().Update(entity);
                }

                //return "false";
                Status = false;
                obj = "false";
            }
            catch (Exception ex)
            {
                //return ex.Message;
                //return "";
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        #endregion

        #region 删除图片

        /// <summary>
        /// 删除照片
        /// 添加人：周 鹏
        /// 添加时间：2018-02-06
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string DeleteFile(string context)
        {
            //var result = "";
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var fileId = Regex.Match(context, @"(?<=""FileId""\:"").*?(?="",)").Value;
                    var isOk = new LicenseAttachBll().LicenseAttachDelete(fileId);
                    //result = isOk ? "true" : "false";
                    Status = true;
                    obj = isOk;
                }
            }
            catch (Exception ex)
            {
                //result = ex.Message;
                //result = "";
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        #endregion


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
        [WebMethod]
        public string LicenseApprove(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var checkResult = CommonMethod.ProcessSqlStr(context);
                if (!checkResult)
                {
                    //return "有SQL攻击嫌疑！";
                    Status = false;
                    msg = "有SQL攻击嫌疑！";
                }

                var isOk = _approveBll.LicenseApprove(context);
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var closedIdea = Regex.Match(context, @"(?<=""ClosedIdea""\:"").*?(?="",)").Value;
                var formId = Regex.Match(context, @"(?<=""formId""\:"").*?(?="",)").Value;
                var bll = new LicenseMainBll();
                var licenseMainEntity = new LicenseMainBll().Get(formId);
                if (licenseMainEntity != null && isOk)
                {
                    licenseMainEntity.ClosedIdea = closedIdea;
                    bll.Update(licenseMainEntity);
                }
                //return "[{\"result\":\"" + (isOk ? "true" : "false") + "\"}]";
                Status = true;
                obj = isOk;
            }
            catch (Exception)
            {
                //return JsonConvert.SerializeObject(new { });
                Status = false;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取办件申请时上报附件
        /// </summary>
        /// <param name="licenseId"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetFileForMaterial(string licenseId)
        {
            var checkResult = CommonMethod.ProcessSqlStr(licenseId);
            bool Status = false;
            var msg = "";
            object obj = null;
            if (!checkResult)
            {
                //return "有SQL攻击嫌疑！";
                Status = false;
                msg = "有SQL攻击嫌疑！";
            }
            if (string.IsNullOrEmpty(licenseId))
            {
                //return "[]";
                Status = false;
            }
            try
            {
                var fileList = new LicenseAttachBll().GetLicenseAttachList(licenseId, string.Empty);//案件的所有材料配置目录附件
                var adressList = new List<string>();
                foreach (var item in fileList)
                {
                    var saveAddr = AppConfig.FileSaveAddr + item.FileAddress;
                    if (!File.Exists(saveAddr))
                    {
                        //执行文件下载存储到本地
                        CommonMethod.HttpDownload(AppConfig.FileSaveServiceViewLink + item.FileAddress, saveAddr);
                    }
                    adressList.Add(AppConfig.FileViewLink + item.FileAddress);
                }
                //return JsonConvert.SerializeObject(adressList);
                Status = true;
                obj = adressList;
            }
            catch (Exception)
            {
                //return "[]";
                Status = false;
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }


        /// <summary>
        /// 获取办件勘验、验收的现场照片
        /// 添加人：周 鹏
        /// 添加时间：2018-02-05
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<ImageViewerModel> GetLicenseCheckFile(string resourceId, string fileType)
        {
            var checkResult = CommonMethod.ProcessSqlStr(resourceId);
            var checkResult2 = CommonMethod.ProcessSqlStr(fileType);
            if (!checkResult || !checkResult2)
            {
                return new List<ImageViewerModel>();
            }

            try
            {
                var files = new LicenseAttachBll().GetLicenseAttachList(resourceId, fileType, LicenseAttachType.CheckSpec);
                var list = new List<ImageViewerModel>();
                if (files != null && files.Any())
                {
                    foreach (var licenseAttachEntity in files)
                    {
                        try
                        {
                            var virtualAddr = licenseAttachEntity.FileAddress;
                            var saveAddr = AppConfig.FileSaveAddr + virtualAddr;
                            if (!File.Exists(saveAddr))
                            {
                                //执行文件下载存储到本地
                                CommonMethod.HttpDownload(AppConfig.FileSaveServiceViewLink + virtualAddr, saveAddr);
                            }
                            list.Add(new ImageViewerModel()
                                {
                                    Id = licenseAttachEntity.Id,
                                    Url = AppConfig.FileViewOutNetLink + virtualAddr
                                });
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                return new List<ImageViewerModel>();
            }
        }

        //#region  派发相关

        ////返回片区所有人员
        //[WebMethod]
        //public string GetCompanysUsers(string context)
        //{
        //    bool Status = false;
        //    var msg = "";
        //    object obj = null;
        //    try
        //    {
        //        context = Regex.Replace(context, @"[\{\}]", "");
        //        context += ",";
        //        var companyId = Regex.Match(context, @"(?<=""companyId""\:"").*?(?="",)").Value;
        //        var WorkListId = Regex.Match(context, @"(?<=""WorkListId""\:"").*?(?="",)").Value;
        //        var checkResult = CommonMethod.ProcessSqlStr(companyId);
        //        var checkResult2 = CommonMethod.ProcessSqlStr(WorkListId);
        //        if (!checkResult || !checkResult2)
        //        {
        //            //return "有SQL攻击嫌疑！";
        //            Status = false;
        //            msg = "有SQL攻击嫌疑！";
        //        }

        //        var search = new CrmUserEntity() { CompanyId = companyId };
        //        var companysUsers = new CrmUserBll().GetCompanysUsers(search);
        //        CrmMessageWorkEntity messageWork = null;
        //        var processId = string.Empty;
        //        var userIds = new List<string>();
        //        if (!string.IsNullOrEmpty(WorkListId))
        //        {
        //            var crmMessageWorkBll = new CrmMessageWorkBll();
        //            messageWork = crmMessageWorkBll.Get(WorkListId);
        //            if (messageWork != null && !string.IsNullOrEmpty(messageWork.ProcessInstanceID))
        //            {
        //                var flowName = crmMessageWorkBll.GetFlowName(messageWork.Id);//流程名称
        //                if (!string.IsNullOrEmpty(flowName))
        //                    userIds = new FeActionInstanceBll().GetProcessUser(flowName);
        //            }
        //        }
        //        if (userIds.Count > 0)
        //        {
        //            companysUsers = companysUsers.Where(i => userIds.FindIndex(z => i.Id == z) == -1).ToList();//在流程人员名单里面没有找到
        //        }
        //        //return JsonConvert.SerializeObject(companysUsers.Select(i => new { Id = i.Id, Name = i.RealName }));
        //        Status = true;
        //        obj = companysUsers.Select(i => new { Id = i.Id, Name = i.RealName });
        //    }
        //    catch (Exception)
        //    {
        //        //return JsonConvert.SerializeObject(new { });
        //        Status = false;
        //    }
        //    var result = new StatusModel()
        //    {
        //        Status=Status,
        //        msg=msg,
        //        Content=obj
        //    };
        //    return JsonConvert.SerializeObject(result);
        //}

        ///// <summary>
        ///// 获取已选派送人员
        ///// </summary>
        ///// <param name="licenseId">案件编号</param>
        ///// <param name="handType">处理类型（1.踏勘 2.验收）</param>
        ///// <returns></returns>
        //[WebMethod]
        //public string GetLicenseHandUserIds(string licenseId, int handType)
        //{
        //    try
        //    {
        //        var checkResult = CommonMethod.ProcessSqlStr(licenseId);
        //        if (!checkResult)
        //        {
        //            return "有SQL攻击嫌疑！";
        //        }

        //        if (string.IsNullOrEmpty(licenseId) || handType == 0)
        //            return "[]";
        //        return JsonConvert.SerializeObject(new LicenseHandUsersBll().GetLicenseHandUserIds(licenseId, handType));
        //    }
        //    catch (Exception)
        //    {
        //        return JsonConvert.SerializeObject(new { });
        //    }
        //}


        ///// <summary>
        ///// 设置派送人员
        ///// </summary>
        ///// <param name="context">请求JSON</param>       
        ///// <returns></returns>
        //[WebMethod]
        //public string SetLicenseHandUserIds(string context)
        //{
        //    bool Status = false;
        //    var msg = "";
        //    object obj = null;
        //    try
        //    {
        //        var checkResult = CommonMethod.ProcessSqlStr(context);
        //        if (!checkResult)
        //        {
        //            //return "有SQL攻击嫌疑！";
        //            Status = false;
        //            msg = "有SQL攻击嫌疑！";
        //        }

        //        if (string.IsNullOrEmpty(context))
        //        {
        //            //return false.ToString().ToLower();
        //            Status = false;
        //            obj = false.ToString().ToLower();
        //        }
        //        var entity = JsonConvert.DeserializeObject<LicenseHandUserIdRequest>(context);
        //        //return new LicenseHandUsersBll().SetLicenseHandUserIds(entity).ToString().ToLower();
        //        Status = true;
        //        obj = new LicenseHandUsersBll().SetLicenseHandUserIds(entity).ToString().ToLower();
        //    }
        //    catch (Exception ex)
        //    {
        //        //return "[]";
        //        Status = false;
        //        msg = ex.Message;
        //    }
        //    var result = new StatusModel()
        //    {
        //        Status=Status,
        //        msg=msg,
        //        Content=obj
        //    };
        //    return JsonConvert.SerializeObject(result);
        //}

        ///// <summary>
        ///// 获取是否有转派的操作权限
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <returns></returns>
        //[WebMethod]
        //public string GetLicenseHandLimits(string context)
        //{
        //    bool Status = false;
        //    var msg = "";
        //    object obj = null;
        //    try
        //    {
        //        var checkResult = CommonMethod.ProcessSqlStr(context);
        //        if (!checkResult)
        //        {
        //            //return "有SQL攻击嫌疑！";
        //            Status = false;
        //            msg = "有SQL攻击嫌疑！";
        //        }
        //        if (string.IsNullOrEmpty(context))
        //        {
        //            //return false.ToString().ToLower();
        //            Status = false;
        //            obj = false.ToString().ToLower();
        //        }
        //        var entity = JsonConvert.DeserializeObject<LicenseHandLimitsRequest>(context);
        //        //return new LicenseHandUsersBll().GetLicenseHandLimits(entity).ToString().ToLower();
        //        Status = true;
        //        obj = new LicenseHandUsersBll().GetLicenseHandLimits(entity).ToString().ToLower();
        //    }
        //    catch (Exception)
        //    {
        //        //return JsonConvert.SerializeObject(new { });
        //        Status = false;
        //    }
        //    var result = new StatusModel()
        //    {
        //        Status=Status,
        //        msg=msg,
        //        Content=obj
        //    };
        //    return JsonConvert.SerializeObject(result);
        //}

        ///// <summary>
        ///// 获取处理权限
        ///// </summary>
        ///// <param name="userId">人员ID</param>
        ///// <param name="licenseId">案件编号</param>
        ///// <returns></returns>
        //[WebMethod]
        //public string GetUnHandleMessageId(string context)
        //{
        //    context = Regex.Replace(context, @"[\{\}]", "");
        //    context += ",";
        //    var licenseId = Regex.Match(context, @"(?<=""licenseId""\:"").*?(?="",)").Value;
        //    var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;
        //    var checkResult = CommonMethod.ProcessSqlStr(userId);
        //    var checkResult2 = CommonMethod.ProcessSqlStr(licenseId);
        //    bool Status = false;
        //    var msg = "";
        //    object obj = null;
        //    if (!checkResult || !checkResult2)
        //    {
        //        //return "有SQL攻击嫌疑！";
        //        Status = false;
        //        msg = "有SQL攻击嫌疑！";
        //    }

        //    try
        //    {
        //        var user = new CrmUserBll().Get(userId);
        //        if (user != null && !string.IsNullOrEmpty(user.Id))
        //        {
        //            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(licenseId))
        //            {
        //                //return false.ToString().ToLower();
        //                Status = false;
        //                obj = false.ToString().ToLower();
        //            }
        //            var worklistId = new CrmMessageWorkBll().GetUnHandleMessageId(userId, licenseId);
        //            //return string.IsNullOrEmpty(worklistId).ToString().ToLower();
        //            Status = true;
        //            obj = string.IsNullOrEmpty(worklistId).ToString().ToLower();
        //        }
        //        else
        //        {
        //            //return "用户ID不正确";
        //            msg = "用户ID不正确";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        //return "[]";
        //        Status = false;
        //    }
        //    var result = new StatusModel()
        //    {
        //        Status=Status,
        //        msg=msg,
        //        Content=obj
        //    };
        //    return JsonConvert.SerializeObject(result);
        //}

        //#endregion

        //#region 判断许可领导

        ///// <summary>
        ///// 判断许可领导
        ///// </summary>
        ///// <param name="userId">人员ID</param>
        ///// <returns></returns>
        //[WebMethod]
        //public string GetIsLicenseDirector(string context)
        //{
        //    bool Status = false;
        //    var msg = "";
        //    object obj = null;
        //    try
        //    {
        //        context = Regex.Replace(context, @"[\{\}]", "");
        //        context += ",";
        //        var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;
        //        var checkResult = CommonMethod.ProcessSqlStr(userId);
        //        if (!checkResult)
        //        {
        //            //return "有SQL攻击嫌疑！";
        //            Status = false;
        //            msg = "有SQL攻击嫌疑！";
        //        }

        //        if (string.IsNullOrEmpty(userId))
        //        {
        //            //return false.ToString().ToLower();
        //            Status = false;
        //            obj = false.ToString().ToLower();
        //        }
        //        //return new CrmUserBll().GetIsLicenseDirector(userId).ToString().ToLower();
        //        Status = true;
        //        obj = new CrmUserBll().GetIsLicenseDirector(userId).ToString().ToLower();
        //    }
        //    catch (Exception)
        //    {
        //        //return JsonConvert.SerializeObject(new { });
        //        Status = false;
        //    }
        //    var result = new StatusModel()
        //    {
        //        Status=Status,
        //        msg=msg,
        //        Content=obj
        //    };
        //    return JsonConvert.SerializeObject(result);
        //}

        //#endregion
    }

    #region  附件返回信息

    public class ResponseMaterialFile
    {
        public string Id { get; set; }

        public string MaterialName { get; set; }

        /// <summary>
        /// 附件信息集合
        /// </summary>
        public List<FileInfor> FileInforList { get; set; }
    }

    public class FileInfor
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 附件地址
        /// </summary>
        public string FileAdress { get; set; }
    }

    public class ImageViewerModel
    {
        /// <summary>
        /// 照片ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 照片路径
        /// </summary>
        public string Url { get; set; }
    }
    #endregion

    #region 许可信息（通用）

    /// <summary>
    /// 许可申请信息
    /// </summary>
    public class LiceseMainModel
    {
        /// <summary>
        /// 审批事项编号
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// 办件来源（1.窗口 2.历史数据 3.直属大队历史数据）
        /// </summary>
        public string DateSource { get; set; }

        /// <summary>
        /// 申请人代码
        /// </summary>
        public string ApplicantTypeCode { get; set; }

        /// <summary>
        /// 申请人类型
        /// </summary>
        public string ApplicantType { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string PaperType { get; set; }

        /// <summary>
        /// 申请人证照编号
        /// </summary>
        public string PaperCode { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string ApplicantName { get; set; }

        /// <summary>
        /// 单位地址
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// 法人代表姓名
        /// </summary>
        public string LegalPersonName { get; set; }

        /// <summary>
        /// 法人代表身份证
        /// </summary>
        public string LegalPersonId { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan { get; set; }

        /// <summary>
        /// 联系人手机
        /// </summary>
        public string LinkMobile { get; set; }

        /// <summary>
        /// 设置开始日期
        /// </summary>
        public string SetUpStartDate { get; set; }

        /// <summary>
        /// 设置截个日期
        /// </summary>
        public string SetUpEndDate { get; set; }

        /// <summary>
        /// 设置地址
        /// </summary>
        public string SetUpAddress { get; set; }

        /// <summary>
        /// 许可状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 勘验经纬度信息
        /// </summary>
        public Latitude InquestLatitude { get; set; }

        /// <summary>
        /// 验收经纬度信息
        /// </summary>
        public Latitude CheckLatitude { get; set; }

        /// <summary>
        /// 许可规则信息
        /// </summary>
        public List<string> Specs { get; set; }

        /// <summary>
        /// 办结意见
        /// </summary>
        public string ClosedIdea { get; set; }

        /// <summary>
        /// 勘验状态
        /// </summary>
        public string IsInquest { get; set; }

        /// <summary>
        /// 验收状态
        /// </summary>
        public string IsCheck { get; set; }

        /// <summary>
        /// 现场勘验信息
        /// </summary>
        public List<LicenseOutDoorCheckSpec> InquestSpecs { get; set; }


        /// <summary>
        /// 现场验收规格信息
        /// </summary>
        public List<LicenseOutDoorCheckSpec> AcceptanceSpecs { get; set; }


        /// <summary>
        /// 现场勘验近景照
        /// </summary>
        public List<ImageViewerModel> InquestNearPhotos { get; set; }

        /// <summary>
        /// 现场勘验远景照
        /// </summary>
        public List<ImageViewerModel> InquestFarPhotos { get; set; }

        /// <summary>
        /// 现场勘验侧景照
        /// </summary>
        public List<ImageViewerModel> InquestSidePhotos { get; set; }

        /// <summary>
        /// 现场验收近景照
        /// </summary>
        public List<ImageViewerModel> AcceptanceNearPhotos { get; set; }

        /// <summary>
        /// 现场验收远景照
        /// </summary>
        public List<ImageViewerModel> AcceptanceFarPhotos { get; set; }

        /// <summary>
        /// 现场验收侧景照
        /// </summary>
        public List<ImageViewerModel> AcceptanceSidePhotos { get; set; }
    }

    #endregion

    #region 许可规格信息

    /// <summary>
    /// 许可规格
    /// </summary>
    public class ResponseLicenseSpecModel
    {


    }

    #endregion

    #region 户外广告详情

    /// <summary>
    /// 户外广告详情
    /// </summary>
    public class ResponseOutDoor
    {
        /// <summary>
        /// 申请信息
        /// </summary>
        public LiceseMainModel MainEntity { get; set; }

        /// <summary>
        /// 广告内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 设置数量
        /// </summary>
        public int Numbers { get; set; }

        /// <summary>
        /// 广告类型
        /// </summary>
        public string OutdoorType { get; set; }

        /// <summary>
        /// 广告受理类型
        /// </summary>
        public string AcceptType { get; set; }

        /// <summary>
        /// 广告性质
        /// </summary>
        public string Nature { get; set; }

        /// <summary>
        /// 安装开始日期
        /// </summary>
        public string InstallStartDate { get; set; }

        /// <summary>
        /// 安装截止日期
        /// </summary>
        public string InstallEndDate { get; set; }

        /// <summary>
        /// 勘验左领高度
        /// </summary>
        public string CheckLeftHeight { get; set; }

        /// <summary>
        /// 勘验右领高度
        /// </summary>
        public string CheckRightHeight { get; set; }

        /// <summary>
        /// 勘验左领外挑
        /// </summary>
        public string CheckLeftLogn { get; set; }

        /// <summary>
        /// 勘验右领外挑
        /// </summary>
        public string CheckRightLogn { get; set; }

        /// <summary>
        /// 勘验检查数量
        /// </summary>
        public string CheckNumbers { get; set; }

        /// <summary>
        /// 验收检查数量
        /// </summary>
        public string AcceptanceCheckNumbers { get; set; }
    }

    /// <summary>
    /// 临时占道详情
    /// </summary>
    public class ResponseJeeves
    {

        /// <summary>
        /// 申请信息
        /// </summary>
        public LiceseMainModel MainEntity { get; set; }

        /// <summary>
        /// 占道原因
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 占道宽
        /// </summary>
        public double JeevesWidth { get; set; }

        /// <summary>
        /// 占道长
        /// </summary>
        public double JeevesLength { get; set; }

        /// <summary>
        /// 占道面积
        /// </summary>
        public string JeevesArea { get; set; }

        /// <summary>
        /// 占道地址
        /// </summary>
        public string JeevesAdress { get; set; }

        /// <summary>
        /// 占道开始时间
        /// </summary>
        public string JeevesStartTime { get; set; }

        /// <summary>
        /// 占道结束时间
        /// </summary>
        public string JeevesEndTime { get; set; }

        /// <summary>
        /// 设置周期：0060
        /// </summary>
        public string SetUpCycleDetails { get; set; }

        /// <summary>
        /// 其它
        /// </summary>
        public string SetUpCycleOther { get; set; }

        /// <summary>
        /// 现场勘验地址门牌号
        /// </summary>
        public string InquestAdress { get; set; }

        /// <summary>
        /// 勘验宽
        /// </summary>
        public double InquestWidth { get; set; }

        /// <summary>
        /// 勘验长度
        /// </summary>
        public double InquestLength { get; set; }

        /// <summary>
        /// 现场验收宽度
        /// </summary>
        public double CheckWidth { get; set; }

        /// <summary>
        /// 现场验收长度
        /// </summary>
        public double CheckLength { get; set; }
    }

    #endregion
}
