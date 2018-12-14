using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Yookey.WisdomClassed.SIP.Business.Consent;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.WebService.Com
{
    /// <summary>
    /// 行政许可 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class License : System.Web.Services.WebService
    {
        private readonly AdvertisingBll _advertisingBll = new AdvertisingBll();   //户外广告
        private readonly ActivityBll _activityBll = new ActivityBll();            //举办活动
        private readonly TemporaryBll _temporaryBll = new TemporaryBll();         //占道经营
        private readonly ExcavationBll _excavationBll = new ExcavationBll();      //绿地挖掘
        private readonly Consent_AttachBll _consentAttachBll = new Consent_AttachBll();   //请求附件地址

        /// <summary>
        /// 许可数据查询
        /// 添加人：周 鹏
        /// 添加时间：2015-09-22
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
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var companyId = Regex.Match(context, @"(?<=""CompanyId""\:"").*?(?="",)").Value;    //所属大队
                    var queryType = Regex.Match(context, @"(?<=""QueryType""\:"").*?(?="",)").Value;    //查询类型：户外广告 Advertisement,举办活动 Activity,绿地挖掘 Excavation,占道经营 Temporary
                    var keyWord = Regex.Match(context, @"(?<=""KeyWord""\:"").*?(?="",)").Value;        //查询关键字
                    var pageIndex = Regex.Match(context, @"(?<=""PageIndex""\:"").*?(?="",)").Value;    //分页索引
                    var pageSize = Regex.Match(context, @"(?<=""PageSize""\:"").*?(?="",)").Value;      //每页条数

                    var permissionData = new DataTable();

                    if (!string.IsNullOrEmpty(queryType))
                    {
                        switch (queryType)
                        {
                            case "Advertisement":
                                permissionData = _advertisingBll.MobileQueryAdvertingList(companyId, keyWord, int.Parse(pageSize), int.Parse(pageIndex));
                                break;
                            case "Activity":
                                permissionData = _activityBll.MobileQueryActivityList(keyWord, int.Parse(pageSize), int.Parse(pageIndex));
                                break;
                            case "Temporary":
                                permissionData = _temporaryBll.MobileQueryTemporaryList(companyId, keyWord, int.Parse(pageSize), int.Parse(pageIndex));
                                break;
                            case "Excavation":
                                permissionData = _excavationBll.MobileQueryExcavationList(companyId, keyWord, int.Parse(pageSize), int.Parse(pageIndex));
                                break;
                        }
                    }
                    timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
                    //转Json
                    //result = JsonConvert.SerializeObject(permissionData, timeConverter);
                    Status = true;
                    obj = permissionData;
                }
            }
            catch (Exception ex)
            {
                //result = "[]";
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status=Status,
                msg=msg,
                Content=obj
            };
            //return result;
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
        /// <param name="context">{QueryType:请求类型,KeyWord:查询关键字,PageIndex当前页,PageSize:每页请求条数}</param>
        /// <returns></returns>
        [WebMethod]
        public string GetPermissionDetails(string context)
        {
            //var result = "";
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
                    var queryType = Regex.Match(context, @"(?<=""QueryType""\:"").*?(?="",)").Value;  //查询类型
                    var id = Regex.Match(context, @"(?<=""PermissionId""\:"").*?(?="",)").Value; //许可主键编号

                    var permissionObj = new object();
                    if (!string.IsNullOrEmpty(queryType))
                    {
                        switch (queryType)
                        {
                            case "Advertisement":
                                permissionObj = _advertisingBll.GetDetail(id);
                                break;
                            case "Activity":
                                permissionObj = _activityBll.GetDetail(id);
                                break;
                            case "Temporary":
                                permissionObj = _temporaryBll.GetDetail(id);
                                break;
                            case "Excavation":
                                permissionObj = _excavationBll.GetDetail(id);
                                break;
                        }
                    }

                    timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
                    //转Json
                    //result = JsonConvert.SerializeObject(permissionObj, timeConverter);
                    Status = true;
                    obj = permissionObj;
                }
            }
            catch (Exception ex)
            {
                //result = "[]";
                Status = false;
                msg = ex.Message;
            }
            //return result;
            var result = new StatusModel()
            {
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(result, timeConverter);
        }


        /// <summary>
        /// 获取许可附件
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,caseInfoId:办件编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string GetPermissionFile(string context)
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
                    var id = Regex.Match(context, @"(?<=""PermissionId""\:"").*?(?="",)").Value; //许可主键编号

                    var netWork = CommonMethod.GetNetWork(); //获取当前网络请求的段
                    var files = _consentAttachBll.GetFiles(id, netWork);
                    List<string> adressList = new List<string>();

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
                            adressList.Add(AppConfig.FileViewLink + row["FileAddress"].ToString());
                        }
                    }
                    //FileAddress

                    //result = JsonConvert.SerializeObject(adressList);
                    Status = true;
                    obj = adressList;
                }
            }
            catch (Exception ex)
            {
                //result = "[]";
                Status = false;
                msg = ex.Message;
            }
            //return result;
            var result = new StatusModel()
            {
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(result);
        }
    }
}
