using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Mobile;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.WebService.Com
{
    /// <summary>
    /// PunishCase 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PunishCase : System.Web.Services.WebService
    {
        private readonly ApproveBll _approveBll = new ApproveBll();
        private readonly ComResourceBll _comResourceBll = new ComResourceBll(); //字典
        private readonly InfPunishAttachBll _infPunishAttachBll = new InfPunishAttachBll(); //附件材料
        readonly InfPunishCaseinfoBll _infPunishCaseinfoBll = new InfPunishCaseinfoBll();
        readonly InfWritBll _infWritBll = new InfWritBll();


        /// <summary>
        /// 案件上报（保存）
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string SaveCase(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                _approveBll.SavePunishCase(context);
                Status = true;
                obj = "true";
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
        /// 案件上传图片
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string SaveCaseImage(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;

            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    JObject jo = (JObject)JsonConvert.DeserializeObject(context);

                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    //案件ID
                    string caseID = Regex.Match(context, @"(?<=""caseID""\:"").*?(?="",)").Value;
                    //图片的 Base64String 字符串
                    byte[] imageDate = Convert.FromBase64String(jo["ImageDate"].ToString());
                    //图片名称
                    string imageName = Regex.Match(context, @"(?<=""ImageName""\:"").*?(?="",)").Value;
                    //案件类型 1:违停,2:简易,3:一般
                    int caseType = int.Parse(Regex.Match(context, @"(?<=""caseType""\:"").*?(?="",)").Value);
                    //用户ID
                    string userID = Regex.Match(context, @"(?<=""userID""\:"").*?(?="",)").Value;
                    //图片类型 1:证据,2:笔录,3:通知书
                    string imageType = Regex.Match(context, @"(?<=""imageType""\:"").*?(?="",)").Value;
                    //待办事宜编号
                    string worklistId = Regex.Match(context, @"(?<=""worklistId""\:"").*?(?="",)").Value;

                    #region 调用服务存储照片

                    var filename = GetFileName(imageName.ToLower());   //重新生成命称
                    //调用WebService进行文件存储.FileExt(postedFile.FileName)
                    var filePath = new PictureService.PictureService(AppConfig.FileSaveServiceLink).WritePictureSecond("PunishCase", CommonMethod.FileExt(imageName), filename, imageDate);

                    #endregion

                    #region 实体信息赋值

                    var fileType = "";
                    var fileTypeName = "";
                    if (imageType.Equals("1"))
                    {
                        fileType = "00150002";
                    }
                    else if (imageType.Equals("3"))
                    {
                        fileType = "00150001";
                    }
                    else if (imageType.Equals("2"))
                    {
                        fileType = "00150007";
                    }
                    else if (imageType.Equals("4"))
                    {
                        fileType = "00160001";
                    }

                    fileTypeName = _comResourceBll.GetSearchResult(new ComResourceEntity() { Id = fileType })[0].RsKey;

                    //执行数据库保存
                    var entity = new InfPunishAttachEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ResourceId = caseID,
                        FileType = fileType,
                        FileTypeName = fileTypeName,
                        FileAddress = filePath,
                        FileName = imageName,
                        FileReName = filename,
                        FileRemark = "注释",
                        RowStatus = 1,
                        IsCompleted = 1,
                        CreatorId = userID,
                        CreateOn = DateTime.Now,
                        UpdateId = userID,
                        UpdateOn = DateTime.Now
                    };
                    _infPunishAttachBll.Add(entity);
                    Status = true;
                    #endregion
                }
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
        /// 案件管理,获取案件列表
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">{userId:用户编号,pageIndex当前页,pageSize:每页请求条数}</param>
        /// <returns></returns>
        [WebMethod]
        public string GetCaseList(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var netWork = CommonMethod.GetNetWork();    //获取当前网络请求的段
                var caseDt = _approveBll.GetCaseList(context, netWork);
                if (caseDt != null && caseDt.Rows.Count > 0)
                {
                    foreach (DataRow row in caseDt.Rows)
                    {
                        try
                        {
                            var virtualAddr = row["FileAddress"];
                            if (!string.IsNullOrEmpty(virtualAddr.ToString()))
                            {
                                var saveAddr = AppConfig.FileSaveAddr + virtualAddr;
                                if (!File.Exists(saveAddr))
                                {
                                    //执行文件下载存储到本地
                                    CommonMethod.HttpDownload(AppConfig.FileSaveServiceViewLink + virtualAddr, saveAddr);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Status = false;
                            msg = ex.Message;
                        }
                    }
                }
                Status = true;
                obj = JsonConvert.SerializeObject(caseDt);
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
        /// 获取案件详情（内容）
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,caseInfoId:办件编号,WorklistId:消息编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string GetCaseDetails(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var detailsDt = _approveBll.GetCaseDetails(context);
                Status = true;
                obj = JsonConvert.SerializeObject(detailsDt);
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
        /// 获取办件的附件
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,caseInfoId:办件编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string GetCaseFile(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var netWork = CommonMethod.GetNetWork();    //获取当前网络请求的段
                var files = _approveBll.GetFileList(context, netWork);

                if (files != null && files.Rows.Count > 0)
                {
                    foreach (DataRow row in files.Rows)
                    {
                        try
                        {
                            var virtualAddr = row["FileAddress"];
                            var saveAddr = AppConfig.FileSaveAddr + virtualAddr;
                            if (!File.Exists(saveAddr))
                            {
                                //执行文件下载存储到本地
                                CommonMethod.HttpDownload(AppConfig.FileSaveServiceViewLink + virtualAddr, saveAddr);
                            }
                        }
                        catch (Exception ex)
                        {
                            Status = false;
                            msg = ex.Message;
                        }
                    }
                }
                Status = true;
                obj = JsonConvert.SerializeObject(files);
            }
            catch (Exception ex)
            {
                //return "[]";
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
        /// 查询待审批、已审批数据列表
        /// 添加人：周 鹏
        /// 时间：2017-03-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">{"userId用户编号":"xxxx",
        ///                       "sourceType数据类型 （0:未处理,1已阅读,2已处理,3:已删除）":"xxxx",
        ///                       "pageIndex当前页索引":"xxxx","pageSize每页请求的条数":"xxxx"}
        /// </param>
        /// <returns></returns>
        [WebMethod]
        public string GetApproveCount(string context)
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
                    var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;          //用户编号
                    var sourceType = Regex.Match(context, @"(?<=""sourceType""\:"").*?(?="",)").Value;  //类型（未处理、已处理）
                    var approveType = Regex.Match(context, @"(?<=""approveType""\:"").*?(?="",)").Value;//事项类型（全部、案件处理、请假）

                    Status = true;
                    obj = new ApproveBll().GetApproveCount(userId, sourceType, approveType, 1, 1).ToString();
                }
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
        /// 查询待审批、已审批数据列表
        /// 添加人：周 鹏
        /// 时间：2014-12-28
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">{"userId用户编号":"xxxx",
        ///                       "sourceType数据类型 （0:未处理,1已阅读,2已处理,3:已删除）":"xxxx",
        ///                       "pageIndex当前页索引":"xxxx","pageSize每页请求的条数":"xxxx"}
        /// </param>
        /// <returns></returns>
        [WebMethod]
        public string GetApproveList(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            var timeConverter = new IsoDateTimeConverter();
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var userId = Regex.Match(context, @"(?<=""userId""\:"").*?(?="",)").Value;          //用户编号
                    var sourceType = Regex.Match(context, @"(?<=""sourceType""\:"").*?(?="",)").Value;  //类型（未处理、已处理）
                    var pageIndex = Regex.Match(context, @"(?<=""pageIndex""\:"").*?(?="",)").Value;    //分页索引
                    var pageSize = Regex.Match(context, @"(?<=""pageSize""\:"").*?(?="",)").Value;      //每页条数
                    var approveType = Regex.Match(context, @"(?<=""approveType""\:"").*?(?="",)").Value;//事项类型（全部、案件处理、请假）

                    //查询数据
                    var sdt = new ApproveBll().GetApproveList(userId, sourceType, approveType, int.Parse(pageIndex), int.Parse(pageSize));
                    timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
                    Status = true;
                    obj = sdt;
                }
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
            return JsonConvert.SerializeObject(result, timeConverter);
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
        [WebMethod]
        public string WorkMsgHandle(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var isOk = _approveBll.WorkMsgHandle(context);
                Status = true;
                obj = isOk;
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
        /// 办件流程
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,caseInfoId:办件编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string GetCaseFlow(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            var timeConverter = new IsoDateTimeConverter();
            try
            {
                var data = _approveBll.GetCaseFlow(context);
                timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
                Status = true;
                obj = JsonConvert.SerializeObject(data);
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
            return JsonConvert.SerializeObject(result, timeConverter);
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
        [WebMethod]
        public string GetDefaultIdea(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var data = _approveBll.GetDefaultIdea(context);
                Status = true;
                obj = data;
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
        [WebMethod]
        public string CaseApprove(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var isOk = _approveBll.CaseApprove(context);
                Status = true;
                obj = isOk;
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
        /// 案件预审
        /// 添加人：周 鹏
        /// 添加时间：2015-07-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">The context.</param>
        [WebMethod]
        public string CaseFirstTrial(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var isOk = _approveBll.CaseFirstTrial(context);
                Status = true;
                obj = isOk;
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
        /// 上报调查
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{ formId:办件编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string SaveSurvey(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var isOk = _approveBll.SaveSurvey(context);
                Status = true;
                obj = isOk;
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
        /// 删除照片
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{ imgs:附件编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string DeleteCaseImage(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var isOk = _approveBll.DeleteCaseImage(context);
                Status = true;
                obj = isOk;
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
        /// 验证通知书编号是否可以被使用
        /// 添加人：周 鹏
        /// 添加时间：2015-04-16
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{Id:案件主键编号,NoticeNo:通知书编号,CheckType:验证类型}</param>
        /// <returns></returns>
        [WebMethod]
        public string CheckNoticeNo(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var isOk = _approveBll.CheckNoticeNo(context);
                Status = true;
                obj = isOk;
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
        /// 生成文件名
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        private static string GetFileName(string context)
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
            return DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond + random.Next(10, 99) + extension;

        }


        /// <summary>
        /// 根据案由编号获取案情摘要模板
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetCaseFactModel(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;

            try
            {
                #region  解析context

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var caseInfoId = Regex.Match(context, @"(?<=""CaseInfoId""\:"").*?(?="")").Value;

                #endregion

                #region 校验

                if (string.IsNullOrEmpty(caseInfoId))
                {
                    return "请传入参数：CaseInfoId";
                }

                #endregion

                var caseEntity = new InfPunishCaseinfoBll().Get(caseInfoId);
                //生成/获取现场检查笔录
                var record = _approveBll.GetCheckRecord(caseInfoId);

                #region 请求示意图

                var sketchMapUrl = "";
                const string imageReName = "SketchMap" + ".jpg";
                var fileFullName = AppConfig.FileViewOutNetLink + "/PunishCase/" + caseInfoId + "/" + imageReName;
                if (File.Exists(fileFullName)) //如果示意图存在则删除
                {
                    sketchMapUrl = AppConfig.FileViewOutNetLink + "/PunishCase/" + caseInfoId + "/" + imageReName;
                }

                #endregion

                Status = true;
                obj = JsonConvert.SerializeObject(new
                    {
                        Record = record,
                        SketchMap = sketchMapUrl,
                        SendDate = caseEntity.AcceptInvestigationDate.ToString(AppConst.DateFormat)
                    });
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
        /// 保存案件摘要信息
        /// </summary>
        /// <param name="context">JSON参数</param>
        /// <returns></returns>
        [WebMethod]
        public string SaveCaseFact(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;

            try
            {
                #region  解析context

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var caseInfoId = Regex.Match(context, @"(?<=""CaseInfoId""\:"").*?(?="",)").Value; //案件ID
                var fact = Regex.Match(context, @"(?<=""Fact""\:"").*?(?="",)").Value;             //案情摘要内容
                var roadName1 = Regex.Match(context, @"(?<=""RoadName1""\:"").*?(?="",)").Value;   //路名1
                var roadName2 = Regex.Match(context, @"(?<=""RoadName2""\:"").*?(?="",)").Value;   //路名2
                var reference1 = Regex.Match(context, @"(?<=""Reference1""\:"").*?(?="",)").Value; //参照物1
                var reference2 = Regex.Match(context, @"(?<=""Reference2""\:"").*?(?="")").Value;  //参照物2

                var sendDate = Regex.Match(context, @"(?<=""SendDate""\:"").*?(?="")").Value;//接受调查日期

                #endregion

                #region 校验

                if (string.IsNullOrEmpty(caseInfoId))
                {
                    return "请传入参数：CaseInfoId";
                }
                if (string.IsNullOrEmpty(fact))
                {
                    return "请传入参数：Fact";
                }

                #endregion

                //执行数据保存
                Status = _approveBll.UpdataCaseFact(caseInfoId, fact, roadName1, roadName2, reference1, reference2, sendDate);
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
        /// 保存案件现场笔录示意图
        /// </summary>
        /// <param name="context">JSON参数</param>
        /// <returns></returns>
        [WebMethod]
        public string SaveCaseSketchMap(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(context);

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var resourceId = Regex.Match(context, @"(?<=""resourceId""\:"").*?(?="",)").Value; //案件ID

                var imageData = Convert.FromBase64String(jo["fileDate"].ToString());
                var uploadPath = AppConfig.FileSaveAddr;
                if (!Directory.Exists(uploadPath + "/PunishCase/" + resourceId))
                {
                    Directory.CreateDirectory(uploadPath + "/PunishCase/" + resourceId);
                }
                const string imageReName = "SketchMap" + ".jpg";
                var fileFullName = uploadPath + "/PunishCase/" + resourceId + "/" + imageReName;
                if (File.Exists(fileFullName))   //如果示意图存在则删除
                {
                    File.Delete(fileFullName);
                }
                //将图片写到硬盘
                var fs = new FileStream(fileFullName, FileMode.CreateNew, FileAccess.Write, FileShare.None, imageData.Length, false);
                fs.Write(imageData, 0, imageData.Length);
                fs.Close();
                fs.Dispose();

                Status = true;
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
        /// 获取一般案件打印文书
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetPunsihCaseDocument(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;

            try
            {
                #region  解析context

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var caseInfoId = Regex.Match(context, @"(?<=""CaseInfoId""\:"").*?(?="",)").Value;  //案件主键ID
                var documentType = Regex.Match(context, @"(?<=""DocumentType""\:"").*?(?="")").Value;  //文书类型


                #endregion

                #region 校验

                if (string.IsNullOrEmpty(caseInfoId))
                {
                    return "请传入参数：CaseInfoId";
                }

                if (string.IsNullOrEmpty(documentType))
                {
                    return "请传入参数：DocumentType";
                }
                #endregion

                if (documentType.Equals("CaseAllDocument"))   //一般案件打印全部文书
                {
                    var caseEntity = _infPunishCaseinfoBll.Get(caseInfoId);
                    if (caseEntity.IsRectification == 1)
                    {
                        documentType = "CaseAllDocumentZG";
                    }
                }
                Status = true;
                obj = _infWritBll.GetWrit(documentType, caseInfoId, true);
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
        /// 案件预审
        /// </summary>
        /// <param name="context">JSON参数</param>
        /// <returns></returns>
        [WebMethod]
        public string CasePretrial(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;

            try
            {
                #region  解析context

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var caseInfoId = Regex.Match(context, @"(?<=""CaseInfoId""\:"").*?(?="",)").Value; //案件ID
                var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;           //案情摘要内容

                #endregion

                //执行案件预审
                Status = _approveBll.CasePretrial(caseInfoId, userId);
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
        /// 获取案件详情接口
        /// </summary>
        /// <param name="context">JSON参数</param>
        /// <returns></returns>
        [WebMethod]
        public string GetPunishCaseDetails(string context)
        {
            bool status = false;
            var msg = "";
            var res = new ResponsePunishCaseDetails();
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    //案件ID
                    var id = Regex.Match(context, @"(?<=""CaseInfoId""\:"").*?(?="",)").Value;

                    var entity = _infPunishCaseinfoBll.Get(id);

                    //获取案件详情
                    var legislationEntity = new InfPunishLegislationEntity();
                    //获取案件法律法规信息
                    var punishLegislations = new InfPunishLegislatioinBll().GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });

                    //是否当前选择的法律法规与之前是否一样,不一样则需要进行变更,否则不执行操作
                    if (punishLegislations != null && punishLegislations.Count > 0)
                    {
                        legislationEntity = punishLegislations[0];
                    }

                    #region 案件基本信息实体赋值

                    res.Process = entity.PunishProcess; //案件流程（简易、一般、重大）
                    res.CaseInfoId = entity.Id; //案件唯一编号
                    res.UserId = entity.CreatorId; //用户编号
                    res.DeptId = entity.DeptId; //部门编号
                    res.FirstPerson = entity.RePersonelIdFist; //第一个搭档
                    res.SecondPerson = entity.RePersonelIdSecond; //第二个搭档
                    res.TargetType = entity.TargetType; //当事人类型
                    res.TargetName = entity.TargetName; //当事人名称（当事人为法人时,为负责人姓名）
                    res.TargetUnit = entity.TargetUnit; //单位名称
                    res.RoadNo = entity.RoadNo; //案发路段编号
                    res.RoadName = entity.RoadName; //案发路段名称
                    res.AjAddr = entity.CaseAddress; //案发地址
                    res.Noticeno = entity.NoticeNo; //通知书编号
                    res.Itemno = legislationEntity.ItemNo; //案由编号
                    res.LegislationId = legislationEntity.LegislationId; //违法行为
                    res.LegislationItemId = legislationEntity.LegislationItemId; //适用案由
                    res.LegislationGistId = legislationEntity.LegislationGistId; //法律条文
                    res.Checkdate = entity.CaseDate.ToString("yyyy-MM-dd HH:mm:ss");//案发时间
                    res.IdType = entity.TargetPaperType; //证件类型
                    res.IdNum = entity.TargetPaperNum; //证件号码
                    res.Sex = entity.TargetGender; //性别
                    res.Age = entity.TargetAge.ToString(); //年龄
                    res.TargetAddress = entity.TargetAddress; //当事人地址

                    if (entity.PunishProcess == "00280001")  //简易案件
                    {
                        //查询结案信息
                        var finshEntity = new InfPunishFinishBll().GetSearchResult(new InfPunishFinishEntity() { CaseInfoId = entity.Id });

                        //res.PunishType = "";    //处罚类型（1:上报、2:警告、3:罚款）
                        res.PunishAmount = legislationEntity.PunishAmount.ToString();  //处罚金额
                        res.PaymentNum = finshEntity.Any() ? finshEntity[0].PaymentNum : "";    //票据号
                    }

                    res.Lng = entity.Lng; //GPS坐标：经度
                    res.Lat = entity.Lat; //GPS坐标：纬度
                    res.IsRectification = entity.IsRectification.ToString(); //是否开具整改通知书（1：开具 0：未开具）
                    res.IsTempDetainInfo = entity.IsTempDetainInfo.ToString(); //是否开具暂扣单（1：开具 0：未开具）
                    res.TempId = entity.TempId; //暂扣主键ID
                    res.TempNo = entity.TempNo; //暂扣单号
                    res.ZDM = entity.TargetZDM; //组织机构代码证号


                    #endregion

                    #region 案件附件材料信息赋值

                    res.CaseFiles = new List<CaseFileEntity>(); //案件附件
                    var netWork = CommonMethod.GetNetWork();    //获取当前网络请求的段
                    //查询附件材料（书证）
                    var files = _approveBll.GetFileList(entity.Id, "00150002", netWork);
                    if (files != null && files.Rows.Count > 0)
                    {
                        foreach (DataRow row in files.Rows)
                        {
                            try
                            {
                                var virtualAddr = row["FileAddress"];
                                var saveAddr = AppConfig.FileSaveAddr + virtualAddr;
                                if (!File.Exists(saveAddr))
                                {
                                    //执行文件下载存储到本地
                                    CommonMethod.HttpDownload(AppConfig.FileSaveServiceViewLink + virtualAddr, saveAddr);
                                }

                                res.CaseFiles.Add(new CaseFileEntity()
                                    {
                                        Id = row["Id"].ToString(),
                                        Path = row["FileView"] + virtualAddr.ToString()
                                    });
                            }
                            catch (Exception ex)
                            {
                                status = false;
                                msg = ex.Message;
                            }
                        }
                    }
                    #endregion

                    res.Idea = ""; //退回意见
                    res.Status = entity.State; //状态

                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = status,
                msg = msg,
                Content = JsonConvert.SerializeObject(res)
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取现场检查笔录接口
        /// </summary>
        /// <param name="context">JSON参数</param>
        /// <returns></returns>
        [WebMethod]
        public string GetPunishCaseCheckRecords(string context)
        {
            var status = false;
            var msg = "";
            var res = new object();
            try
            {
                #region  解析context

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var caseInfoId = Regex.Match(context, @"(?<=""CaseInfoId""\:"").*?(?="")").Value;

                #endregion

                #region 校验

                if (string.IsNullOrEmpty(caseInfoId))
                {
                    return "请传入参数：CaseInfoId";
                }

                #endregion

                var caseEntity = new InfPunishCaseinfoBll().Get(caseInfoId);
                //生成/获取现场检查笔录
                var record = _approveBll.GetCheckRecord(caseInfoId);

                #region 请求示意图

                var sketchMapUrl = "";
                const string imageReName = "SketchMap" + ".jpg";
                var fileFullName = AppConfig.FileViewOutNetLink + "/PunishCase/" + caseInfoId + "/" + imageReName;
                if (File.Exists(fileFullName))
                {
                    sketchMapUrl = AppConfig.FileViewOutNetLink + "/PunishCase/" + caseInfoId + "/" + imageReName;
                }

                #endregion

                res = new
                {
                    CaseInfoId = caseInfoId,
                    Fact = record,
                    RoadName1 = caseEntity.RoadName1,
                    RoadName2 = caseEntity.RoadName2,
                    Reference1 = caseEntity.Reference1,
                    Reference2 = caseEntity.Reference2,
                    SendDate = caseEntity.AcceptInvestigationDate.ToString("yyyy-MM-dd"),
                    Ask = "",
                    Path = sketchMapUrl
                };
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = status,
                msg = msg,
                Content = JsonConvert.SerializeObject(res)
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取调查询问笔录接口
        /// </summary>
        /// <param name="context">JSON参数</param>
        /// <returns></returns>
        [WebMethod]
        public string GetPunishCaseRecords(string context)
        {
            return "";
        }

        /// <summary>
        /// 保存调查询问笔录接口
        /// </summary>
        /// <param name="context">JSON参数</param>
        /// <returns></returns>
        [WebMethod]
        public string SavePunishCaseRecords(string context)
        {
            return "";
        }

        /// <summary>
        /// 获取通知书、现场检查笔录附件材料接口
        /// </summary>
        /// <param name="context">JSON参数</param>
        /// <returns></returns>
        [WebMethod]
        public string GetPunishNoticeFiles(string context)
        {
            var status = false;
            var msg = "";
            var res = new object();
            try
            {
                #region  解析context

                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var caseInfoId = Regex.Match(context, @"(?<=""CaseInfoId""\:"").*?(?="")").Value;

                #endregion

                #region 校验

                if (string.IsNullOrEmpty(caseInfoId))
                {
                    return "请传入参数：CaseInfoId";
                }

                #endregion

                #region 附件材料信息赋值

                var noticeFiles = new List<CaseFileEntity>(); //通知书附件
                var recordFiles = new List<CaseFileEntity>(); //笔录照片

                var netWork = CommonMethod.GetNetWork();    //获取当前网络请求的段
                //查询通知书附件材料（书证）
                var files = _approveBll.GetFileList(caseInfoId, "00150001", netWork);
                if (files != null && files.Rows.Count > 0)
                {
                    foreach (DataRow row in files.Rows)
                    {
                        try
                        {
                            var virtualAddr = row["FileAddress"];
                            var saveAddr = AppConfig.FileSaveAddr + virtualAddr;
                            if (!File.Exists(saveAddr))
                            {
                                //执行文件下载存储到本地
                                CommonMethod.HttpDownload(AppConfig.FileSaveServiceViewLink + virtualAddr, saveAddr);
                            }

                            noticeFiles.Add(new CaseFileEntity()
                            {
                                Id = row["Id"].ToString(),
                                Path = row["FileView"] + virtualAddr.ToString()
                            });
                        }
                        catch (Exception ex)
                        {
                            status = false;
                            msg = ex.Message;
                        }
                    }
                }

                //查询笔录附件材料（书证）
                files = _approveBll.GetFileList(caseInfoId, "00150007", netWork);
                if (files != null && files.Rows.Count > 0)
                {
                    foreach (DataRow row in files.Rows)
                    {
                        try
                        {
                            var virtualAddr = row["FileAddress"];
                            var saveAddr = AppConfig.FileSaveAddr + virtualAddr;
                            if (!File.Exists(saveAddr))
                            {
                                //执行文件下载存储到本地
                                CommonMethod.HttpDownload(AppConfig.FileSaveServiceViewLink + virtualAddr, saveAddr);
                            }

                            recordFiles.Add(new CaseFileEntity()
                            {
                                Id = row["Id"].ToString(),
                                Path = row["FileView"] + virtualAddr.ToString()
                            });
                        }
                        catch (Exception ex)
                        {
                            status = false;
                            msg = ex.Message;
                        }
                    }
                }

                #endregion

                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status = status,
                msg = msg,
                Content = JsonConvert.SerializeObject(res)
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 删除附件材料接口
        /// </summary>
        /// <param name="context">JSON参数</param>
        /// <returns></returns>
        [WebMethod]
        public string DeletePunishCaseFile(string context)
        {
            return "";
        }
    }

    /// <summary>
    /// 响应案件详情
    /// </summary>
    public class ResponsePunishCaseDetails
    {
        public string Process { get; set; } //案件流程（简易、一般、重大）
        public string CaseInfoId { get; set; } //案件唯一编号
        public string UserId { get; set; } //用户编号
        public string DeptId { get; set; } //部门编号
        public string FirstPerson { get; set; } //第一个搭档
        public string SecondPerson { get; set; } //第二个搭档
        public string TargetType { get; set; } //当事人类型
        public string TargetName { get; set; } //当事人名称（当事人为法人时,为负责人姓名）
        public string TargetUnit { get; set; } //单位名称
        public string RoadNo { get; set; } //案发路段编号
        public string RoadName { get; set; } //案发路段名称
        public string AjAddr { get; set; } //案发地址
        public string Noticeno { get; set; } //通知书编号
        public string Itemno { get; set; } //案由编号
        public string LegislationId { get; set; } //违法行为
        public string LegislationItemId { get; set; } //适用案由
        public string LegislationGistId { get; set; } //法律条文
        public string Checkdate { get; set; } //案发时间
        public string IdType { get; set; } //证件类型
        public string IdNum { get; set; } //证件号码
        public string Sex { get; set; } //性别
        public string Age { get; set; } //年龄
        public string TargetAddress { get; set; } //当事人地址
        public string PunishType { get; set; } //处罚类型（1:上报、2:警告、3:罚款）
        public string PunishAmount { get; set; } //处罚金额
        public string PaymentNum { get; set; } //票据号
        public string Lng { get; set; } //GPS坐标：经度
        public string Lat { get; set; } //GPS坐标：纬度
        public string WorklistId { get; set; } //待办事宜编号
        public string IsRectification { get; set; } //是否开具整改通知书（1：开具 0：未开具）
        public string IsTempDetainInfo { get; set; } //是否开具暂扣单（1：开具 0：未开具）
        public string TempId { get; set; } //暂扣主键ID
        public string TempNo { get; set; } //暂扣单号
        public string ZDM { get; set; } //组织机构代码证号
        public List<CaseFileEntity> CaseFiles { get; set; } //案件附件
        public string Idea { get; set; } //退回意见
        public int Status { get; set; } //状态
    }

    /// <summary>
    /// 案件附件材料实体
    /// </summary>
    public class CaseFileEntity
    {
        public string Id { get; set; }

        public string Path { get; set; }
    }
}
