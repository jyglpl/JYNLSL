using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Mobile;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.WebService.Com
{
    /// <summary>
    /// PDAPortService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PdaPortService : System.Web.Services.WebService
    {

        readonly ComResourceBll _comResourceBll = new ComResourceBll();
        readonly RoadManagerBll _roadManagerBll = new RoadManagerBll();
        private readonly ComNumberBll _comNumberBll = new ComNumberBll();

        public object Obj = new object();

        #region 上传违章停车信息2014-12-24


        /// <summary>
        /// 上传违章停车基础数据
        /// 添加人：周 鹏
        /// 添加时间：2015-04-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">The context.</param>
        /// <returns>System.String.</returns>
        [WebMethod]
        public string SaveCheckSign(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";

                var autoId = Regex.Match(context, @"(?<=""AutoID""\:"").*?(?="",)").Value;             //案件编号
                var noticeNo = Regex.Match(context, @"(?<=""NoticeNO""\:"").*?(?="",)").Value;         //贴单号
                var carNo = Regex.Match(context, @"(?<=""CarNo""\:"").*?(?="",)").Value;               //车牌号
                var checkDate = Regex.Match(context, @"(?<=""CheckDate""\:"").*?(?="",)").Value;       //检查日期
                var streetId = Regex.Match(context, @"(?<=""StreetID""\:"").*?(?="",)").Value;         //路段
                var streetName = Regex.Match(context, @"(?<=""StreetName""\:"").*?(?="",)").Value;     //路段名称
                var address = Regex.Match(context, @"(?<=""Address""\:"").*?(?="",)").Value;           //地址
                var carType = Regex.Match(context, @"(?<=""CarType""\:"").*?(?="",)").Value;           //车辆类型
                var carTypeName = Regex.Match(context, @"(?<=""CarTypeName""\:"").*?(?="",)").Value;   //车辆类型名称
                var printTzs = Regex.Match(context, @"(?<=""PrintTZS""\:"").*?(?="",)").Value;         //是否打印通知书
                var deptName = Regex.Match(context, @"(?<=""DeptName""\:"").*?(?="",)").Value;         //部门名称
                var deptId = Regex.Match(context, @"(?<=""DeptID""\:"").*?(?="",)").Value;             //部门ID
                var person1 = Regex.Match(context, @"(?<=""Person1""\:"").*?(?="",)").Value;           //执法队员一ID
                var person2 = Regex.Match(context, @"(?<=""Person2""\:"").*?(?="",)").Value;           //执法队员二ID
                var personName1 = Regex.Match(context, @"(?<=""PersonName1""\:"").*?(?="",)").Value;           //执法队员一ID
                var personName2 = Regex.Match(context, @"(?<=""PersonName2""\:"").*?(?="",)").Value;           //执法队员二ID
                var createBy = Regex.Match(context, @"(?<=""CreateBy""\:"").*?(?="",)").Value;         //当前用户
                var createDate = Regex.Match(context, @"(?<=""CreateDate""\:"").*?(?="",)").Value;     //创建时间
                var latitude = Regex.Match(context, @"(?<=""Latitude""\:"").*?(?="",)").Value;         //纬度
                var longitude = Regex.Match(context, @"(?<=""Longitude""\:"").*?(?="",)").Value;       //经度
                var pdaNo = Regex.Match(context, @"(?<=""PdaNo""\:"").*?(?="",)").Value;               //PDA编号
                var dataBytes = Regex.Match(context, @"(?<=""DataBytes""\:"").*?(?="",)").Value;       //数据大小
                var remark = Regex.Match(context, @"(?<=""Remark""\:"").*?(?="",)").Value;             //备注 说明照片的张数

                #region  案件基本信息
                var checkSignMiddle = new InfCarChecksignmiddleEntity
                    {
                        Id = autoId,
                        CheckDate = Convert.ToDateTime(createDate),
                        CarNo = carNo,
                        CarType = carType,
                        CheckSignAddress = address.Contains(streetName) ? address : streetName + address,
                        NoticeNo = noticeNo,
                        DataBytes = 0,
                        Road = streetId.Equals("99999") ? _roadManagerBll.GetRoadNoByRoadName(streetName) : streetId,
                        Toward = "",
                        Latitude = latitude,
                        Longitude = longitude,
                        CreateOn = DateTime.Now,
                        PDANo = pdaNo,
                        Printtzs = Convert.ToInt32(printTzs),
                        Name = "",
                        Age = 0,
                        Sex = 0,
                        Zjtype = "",
                        Personno = "",
                        Address = "",
                        Telephone = "",
                        Cfapproveno = "",
                        PostNo = "",
                        Job = "",
                        Money = 0,
                        CfAddress = "",
                        Realman = "",
                        DeptId = deptId,
                        DeptName = deptName,
                        Cbrdate = DateTime.Now,
                        PersonId1 = person1,
                        PersonId2 = person2,
                        PersonName1 = personName1,
                        PersonName2 = personName2,
                        Remark = remark,
                        TypeNo = "00090005",
                        ResourceId = "00100001",
                        DataSource = 1,
                        CreateBy = createBy
                    };
                checkSignMiddle.CreateOn = DateTime.Now;    //创建时间
                checkSignMiddle.UpdateId = createBy;
                checkSignMiddle.UpdateOn = DateTime.Now;

                //案件概况
                checkSignMiddle.Simpleinfo = Convert.ToDateTime(createDate).ToString("yyyy年MM月dd日", DateTimeFormatInfo.InvariantInfo) + "，" +
                                        deptName + "执法队员巡查时，发现一辆车牌号码为" + carNo + "的" + carTypeName
                                       + "车辆停放在" + streetName + address + "，该车在城市道路上不按规定停放。";
                checkSignMiddle.Whqk = "妨碍其他车辆、行人通行"; //危害情况
                checkSignMiddle.State = "0";
                checkSignMiddle.RowStatus = 1;
                #endregion

                new InfCarChecksignmiddleBll().Add(checkSignMiddle);
                Status = true;
            }
            catch (Exception ex)
            {
                Status = false;
                msg = ex.Message;
                return JsonConvert.SerializeObject(new { });
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


        private readonly object _obj = new object();

        /// <summary>
        /// 自动生成单据编号
        /// </summary>
        /// <param name="context">请求参数</param>
        /// <returns></returns>
        [WebMethod]
        public string GetNum(string context)
        {
            var num = ""; //编号
            var success = false;
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    lock (_obj)
                    {
                        context = Regex.Replace(context, @"[\{\}]", "");
                        context += ",";
                        var numType = Regex.Match(context, @"(?<=""NumType""\:"").*?(?="",)").Value; //编号类型
                        var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;   //用户Id

                        var user = new CrmUserBll().GetUserEntity(userId);
                        if (user != null && string.IsNullOrEmpty(user.Id))
                        {
                            if (!string.IsNullOrEmpty(numType))
                            {
                                switch (numType)
                                {
                                    case "00300002": //简易案件
                                        num = _comNumberBll.GetNumber(AppConst.NumSimpleDecision, "", null);
                                        break;
                                    case "00300006": //违法停车
                                        num = _comNumberBll.GetNumber(AppConst.NumWt, "", null);
                                        break;
                                }
                                if (!string.IsNullOrEmpty(num))
                                {
                                    new InfSimpleNumberBll().Add(num, user.Id, user.RealName);
                                    success = true;
                                }
                            }
                            else
                            {
                                num = "请传入编号类型";
                            }
                        }
                        else
                        {
                            num = "当前传递的用户不存在";
                        }
                    }
                }
                Status = true;
                obj = num;
            }
            catch (Exception ex)
            {
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

        #region 上传图片

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string SaveImage(string context)
        {
            var isOk = true;
            var msg = "";
            object obj = null;
            try
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(context);

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var caseID = Regex.Match(context, @"(?<=""caseID""\:"").*?(?="",)").Value; //案件ID
                var imageDate = jo["imageDate"].ToString();
                var imageName = Regex.Match(context, @"(?<=""imageName""\:"").*?(?="",)").Value;   //图片名称
                var userID = Regex.Match(context, @"(?<=""userID""\:"").*?(?="",)").Value;   //用户ID


                var bytes = Convert.FromBase64String(imageDate);
                var time = DateTime.Now;        //照片时间

                #region 写入到本地硬盘（不用）

                //var dirPath = AppConfig.FileSaveAddr + urlPath;
                //if (!Directory.Exists(dirPath))
                //{
                //    Directory.CreateDirectory(dirPath);
                //}
                //var filename = GetFileName(imageName.ToLower());   //重新生成命称
                ////将图片写到硬盘
                //var fs = new FileStream(dirPath + filename, FileMode.CreateNew, FileAccess.Write, FileShare.None, bytes.Length, false);
                //fs.Write(bytes, 0, bytes.Length);
                //fs.Close();
                //fs.Dispose();

                #endregion

                #region 调用服务存储照片

                var imageData = Convert.FromBase64String(imageDate);
                var filename = GetFileName(imageName.ToLower());   //重新生成命称

                //调用WebService进行文件存储.FileExt(postedFile.FileName)
                var filePath = new PictureService.PictureService(AppConfig.FileSaveServiceLink).WritePictureSecond("Car",
                    CommonMethod.FileExt(imageName), filename, imageData);

                #endregion

                //保存至数据库
                var infCar = new InfCarAttachEntity
                    {
                        Id = Guid.NewGuid().ToString(),
                        FileName = imageName,
                        ImgAddress = filePath,
                        RowStatus = 1,
                        ResourceId = caseID,
                        ClassNo = "",
                        FileType = "1",
                        CreateBy = userID,
                        CreateOn = time,
                        CreatorId = userID,
                        UpdateBy = userID,
                        UpdateOn = time,
                        Version = 1,
                        UpdateId = userID,
                        CreateDate = time,
                        FileDesc = "",
                        FilereMark = ""
                    };
                new InfCarAttachBll().Add(infCar);
                obj = "true";
            }
            catch (Exception ex)
            {
                isOk = false;
                msg = ex.Message;
            }
            //return isOk;
            var result = new StatusModel()
            {
                Status = isOk,
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
                Status = true;
                obj = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond + random.Next(10, 99) + extension;
            }
            catch (Exception ex)
            {
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
        /// 违停查询
        /// 添加人：周 鹏
        /// 添加时间：2015-05-15
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string CarSearch(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var carNo = Regex.Match(context, @"(?<=""CarNo""\:"").*?(?="",)").Value; //车牌号码
                var netWork = CommonMethod.GetNetWork();    //获取当前网络请求的段
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
                var caseDt = new InfCarChecksignBll().MobileGetSearchResult(fileViewLink, carNo);

                if (caseDt != null && caseDt.Rows.Count > 0)
                {
                    foreach (DataRow row in caseDt.Rows)
                    {
                        var virtualAddr = row["FileAddress"];
                        var saveAddr = AppConfig.FileSaveAddr + virtualAddr;
                        if (!File.Exists(saveAddr))
                        {
                            //执行文件下载存储到本地
                            CommonMethod.HttpDownload(AppConfig.FileSaveServiceViewLink + virtualAddr, saveAddr);
                        }
                    }
                }
                Status = true;
                obj = caseDt;
            }
            catch (Exception ex)
            {
                Status = false;
                msg = ex.Message;
                //return "[]";
            }
            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = JsonConvert.SerializeObject(obj).ToString()
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 违章停车详情
        /// 添加人：周 鹏
        /// 添加时间：2015-05-15
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string CarDetails(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;

            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;    //主键编号
                var detailsDt = new InfCarChecksignBll().MobileGetCarDetails(id);
                Status = true;
                obj = detailsDt;
            }
            catch (Exception ex)
            {
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

        /// <summary>
        /// 根据车牌号查询违章停车详情
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string QueryCheckCar(string context)
        {
            var carNo = "";
            var allCount = 0;
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                carNo = Regex.Match(context, @"(?<=""CarNo""\:"").*?(?="",)").Value; //车牌号
                var detailsDt = new InfCarChecksignBll().GetCarDetails(carNo);
                List<string> str = new List<string>();
                if (detailsDt.Any())
                {
                    foreach (var item in detailsDt)
                    {
                        var resourceList = new ComResourceBll().GetSearchResult(new ComResourceEntity() { ParentId = "0021", RsValue = item.State.ToString() });
                        if (resourceList.Any())
                        {
                            item.RsState = resourceList[0].RsKey;
                        }
                        else
                        {
                            item.RsState = "未处理";
                        }
                        var sourceList = new ComResourceBll().GetSearchResult(new ComResourceEntity() { Id = item.CarType });
                        if (sourceList.Any())
                        {
                            item.CarType = sourceList[0].RsValue;
                        }
                        else
                        {
                            item.CarType = "无";
                        }
                        //附件
                        var attach = new InfCarAttachBll().GetSearchResult(new InfCarAttachEntity() { ResourceId = item.Id });
                        if (attach.Any())
                        {
                            foreach (var att in attach)
                            {
                                str.Add(AppConfig.FileViewLink + att.ImgAddress);
                            }
                            item.FileList = str;
                        }
                    }
                    allCount = detailsDt.Count;
                }
                obj = detailsDt;
            }
            catch (Exception ex)
            {
            }
            var result = new ResultModel()
            {
                request_id = carNo,
                response = new RsModel() { totalCount = allCount, result = obj }
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取办件的附件
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{CaseInfoId:办件编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string GetCaseFile(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var id = Regex.Match(context, @"(?<=""CaseInfoId""\:"").*?(?="",)").Value;    //主键编号
                var files = new InfCarChecksignBll().GetFileList(id, AppConfig.FileViewLink);
                if (files != null && files.Rows.Count > 0)
                {
                    foreach (DataRow row in files.Rows)
                    {
                        var virtualAddr = row["FileAddress"];
                        var saveAddr = AppConfig.FileSaveAddr + virtualAddr;
                        if (!File.Exists(saveAddr))
                        {
                            //执行文件下载存储到本地
                            CommonMethod.HttpDownload(AppConfig.FileSaveServiceViewLink + virtualAddr, saveAddr);
                        }
                    }
                }
                Status = true;
                obj = files;
            }
            catch (Exception ex)
            {
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
    }
}
