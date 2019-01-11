using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Business.Mobile;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.WebService.IllegalConstruction
{
    /// <summary>
    /// Illegal 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Illegal : System.Web.Services.WebService
    {
        /// <summary>
        /// 获取违建拆除详情
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetIllegalDetails(string context)
        {
            bool Status = false;
            var msg = "";
            object obje = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;
                    var worklistId = Regex.Match(context, @"(?<=""WorklistId""\:"").*?(?="",)").Value;    //待办事宜ID
                    var entity = new IllegalConstructionBll().Get(id);
                    var commResource = new ComResourceBll();

                    //是否有指定拆除公司按钮权限
                    var isShowCompany = false;

                    if (!string.IsNullOrEmpty(worklistId))
                    {
                        var messageEntity = new CrmMessageWorkBll().Get(worklistId);

                        if (messageEntity.ActionerID.Equals("021361ca-b0af-416f-8fae-111211139") && messageEntity.State != 2 && (entity.State >= 3 && entity.State < 10))
                        {
                            isShowCompany = true;
                        }

                        //处理待办事宜
                        if (messageEntity != null && (messageEntity.FormAddress.IndexOf("FE_End=true", System.StringComparison.Ordinal) > 0 || entity.State == 20))
                        {
                            new CrmMessageWorkBll().UpdateWorkListState(messageEntity.Id, DateTime.Now);
                        }
                    }

                    var obj = new
                    {
                        Id = entity.Id,    //ID
                        //执法部门
                        Company = entity.CompanyName + "-" + entity.DeptName,
                        //体量
                        BodyVolume = "长：" + entity.Length + " 宽：" + entity.Widht + " 高：" + entity.Height,
                        //状态（违建状态）
                        UnbuiltState = !string.IsNullOrEmpty(entity.UnbuiltState) ? commResource.Get(entity.UnbuiltState).RsKey : "",
                        //当事人
                        TargetName = entity.TargetName,
                        //违建日期
                        UnbuiltDate = entity.UnbuiltDate,
                        //房屋结构
                        HousStructure = !string.IsNullOrEmpty(entity.HousStructure) ? commResource.Get(entity.HousStructure).RsKey : "",
                        //占地面积
                        FloorSpace = entity.FloorSpace,
                        //建筑面积
                        AreaOfStructure = entity.AreaOfStructure,
                        //集合时间
                        LetterOfPresentationSetTime = entity.LetterOfPresentationSetTime.Year > 1900 ? entity.LetterOfPresentationSetTime.ToString(AppConst.DateFormatLong) : "",
                        //集合地点
                        LetterOfPresentationCollectionPlace = entity.LetterOfPresentationCollectionPlace,
                        //情况说明 备注
                        LetterOfPresentation = entity.LetterOfPresentation,
                        //地点
                        Address = entity.TargetAddress,
                        //拆除公司
                        DismantleCompany = !string.IsNullOrEmpty(entity.DismantleCompanyId) ? commResource.Get(entity.DismantleCompanyId).RsKey : "",
                        //审批状态（数字,不显示）
                        State = entity.State,
                        //State>10 的情况下显示以下三个字段
                        DismantleArea = entity.DismantleArea,   //实际拆除面积
                        //清运垃圾（吨）
                        GarbageTon = entity.GarbageTon,
                        //清运垃圾（车）
                        GarbageCar = entity.GarbageCar,
                        //是否有指定拆除公司按钮
                        IsShowCompany = isShowCompany
                    };


                    //return JsonConvert.SerializeObject(obj);
                    Status = true;
                    obje = obj;
                }
                //return "[]";
                Status = false;
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
                Content = obje
            };
            return JsonConvert.SerializeObject(result);
        }


        /// <summary>
        /// 获取办件的附件
        /// 添加人：周 鹏
        /// 添加时间：2018-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,caseInfoId:办件编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string GetIllegalFile(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var netWork = CommonMethod.GetNetWork();    //获取当前网络请求的段


                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var caseInfoId = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;      //案件编号

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
                var files = new IllegalConstructionAttachBll().GetFileList(caseInfoId, fileViewLink);
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
                //return JsonConvert.SerializeObject(files);
                Status = true;
                obj = files;
            }
            catch (Exception ex)
            {
                //return "[]";
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(result);
        }


        /// <summary>
        /// 办件审批
        /// 添加人：周 鹏
        /// 添加时间：2018-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">请求参数{type:办件类型,handleType:处理类型（apply:开启流程,agree:同意,disAgree:不同意）,
        ///                                userId:处理人,handleInfo:意见内容, formId:办件编号,processId:所属审批流程,flowName:流程名称,
        ///                                worklistId:消息编号}</param>
        /// <returns></returns>
        [WebMethod]
        public string IllegalApprove(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var isOk = new ApproveBll().IllegalConstructionApprove(context);
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
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 指定公司
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string AppointCompany(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var caseInfoId = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;      //ID
                var companyId = Regex.Match(context, @"(?<=""CompanyId""\:"").*?(?="",)").Value;      //单位ID
                var isOk = new IllegalConstructionBll().SaveDismantleCompany(caseInfoId, companyId);
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
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 获取局领导
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetDirector()
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                //局领导
                var users = new CrmUserBll().GetDeptsUsers(new CrmUserEntity() { DepartmentId = AppConst.DirectorDeptId }).ToList();

                var deputyDirectorEntity = new CrmUserBll().Get(AppConfig.DeputyDirector);
                users.Add(deputyDirectorEntity);

                var list = new List<Director>();

                if (users.Any())
                {
                    list.AddRange(users.Select(entity => new Director()
                        {
                            UserId = entity.Id,
                            UsreName = entity.RealName
                        }));
                }
                //return JsonConvert.SerializeObject(list);
                Status = true;
                obj = list;
            }
            catch (Exception ex)
            {
                //return "[]";
                Status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(result);
        }
    }

    /// <summary>
    /// 局领导实体类
    /// </summary>
    public class Director
    {
        public string UserId { get; set; }

        public string UsreName { get; set; }
    }
}
