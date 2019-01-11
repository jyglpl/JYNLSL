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
using Yookey.WisdomClassed.SIP.Business.Petition;
using Yookey.WisdomClassed.SIP.Business.Mobile;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.License;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Consent;
using Yookey.WisdomClassed.SIP.Business.FlowEditor;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Petition;
using Yookey.WisdomClassed.SIP.Membership;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.WebService.Petition
{
    /// <summary>
    /// Petition 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Petition : System.Web.Services.WebService
    {

        /// <summary>
        /// 详情接口
        /// </summary>
        /// <param name="PetitionId">信访编号</param>
        /// <returns></returns>
        [WebMethod]
        public string GetPetitionDetail(string context)
        {
            var result = string.Empty;
            bool Status = false;
            var msg = "";
            object obj = null;
            var timeConverter = new IsoDateTimeConverter();
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var PetitionId = Regex.Match(context, @"(?<=""PetitionId""\:"").*?(?="",)").Value;
                if (!string.IsNullOrEmpty(PetitionId))
                {
                    var entity = new PetitionBll().Get(PetitionId);
                    var comresour = new ComResourceBll().Get(entity.PetitionSource);
                    if (comresour != null)
                        entity.PetitionSource = comresour.RsKey;
                    if (entity != null)
                    {
                        timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
                        //result = JsonConvert.SerializeObject(entity, timeConverter);
                        Status = true;
                        obj = entity;
                    }
                }
            }
            catch (Exception)
            {
                //result = "{}";
                Status = false;
            }
            //return result;
            var results = new StatusModel()
            {
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(results, timeConverter);
        }

        /// <summary>
        /// 获取办件申请时上报附件
        /// </summary>
        /// <param name="licenseId"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetFileForMaterial(string context)
        {
            var comAttachmentBll = new ComAttachmentBll();
            bool Status = false;
            var msg = "";
            object obj = null;
            context = Regex.Replace(context, @"[\{\}]", "");
            context += ",";
            var PetitionId = Regex.Match(context, @"(?<=""PetitionId""\:"").*?(?="",)").Value;
            if (string.IsNullOrEmpty(PetitionId))
            {
                //return "[]";
                Status = false;
            }
            try
            {
                var fileList = comAttachmentBll.GetSearchResult(new ComAttachmentEntity() { ResourceId = PetitionId });
                var fileInforList = new List<FileInfor>();

                //验证是否已经终审
                var isFinalExamine = new PetitionBll().CheckIsFinalExamine(PetitionId);

                int tempIndex = 1;
                foreach (var item in fileList)
                {
                    var saveAddr = AppConfig.FileSaveAddr + item.FileAddress;
                    var fileAddress = item.FileAddress;

                    //如果通过终审并且是最后一个文件，调用签名的文件
                    if (isFinalExamine && tempIndex == fileList.Count && !string.IsNullOrEmpty(item.FileConvertAddress))
                    {
                        saveAddr = AppConfig.FileSaveAddr + item.FileConvertAddress;
                        fileAddress = item.FileConvertAddress;
                    }
                    tempIndex++;

                    if (!File.Exists(saveAddr))
                    {
                        //执行文件下载存储到本地
                        CommonMethod.HttpDownload(AppConfig.FileSaveServiceViewLink + fileAddress, saveAddr);
                    }
                    fileInforList.Add(new FileInfor() { Adress = AppConfig.FileViewLink + fileAddress, Type = item.FileType, FileName = item.FileName, UpUserName = item.CreateBy, UpFileTime = item.CreateOn.ToString() });
                }


                //return JsonConvert.SerializeObject(fileInforList);
                Status = true;
                obj = fileInforList;
            }
            catch (Exception)
            {
                //return "[]";
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
        /// 附件材料实体
        /// </summary>
        public class FileInfor
        {
            public string Adress { get; set; }//地址

            public string Type { get; set; }//附件类型

            public string FileName { get; set; }//附件名称

            public string UpUserName { get; set; }//上传人

            public string UpFileTime { get; set; }//上传时间
        }

        //<summary>
        //办件审批
        //添加人：周 鹏
        //添加时间：2014-12-25
        //</summary>
        //<history>
        //修改描述：时间+作者+描述
        //</history>
        //<param name="context">请求参数{type:办件类型,handleType:处理类型（apply:开启流程,agree:同意,disAgree:不同意）,
        //                               userId:处理人,handleInfo:意见内容, formId:办件编号,processId:所属审批流程,flowName:流程名称,
        //                               worklistId:消息编号}</param>
        //<returns></returns>
        [WebMethod]
        public string PetitionApprove(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var isOk = new ApproveBll().PetitionApprove(context);
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
        /// 信访查询
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string PetitionSearch(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            var timeConverter = new IsoDateTimeConverter();
            try
            {
                if (string.IsNullOrEmpty(context))
                    return string.Empty;
                PetitionBll _petitionbll = new PetitionBll();
                var searchModel = JsonConvert.DeserializeObject<PetitionSearchEntity>(context);
                var isAll = new MembershipManager().VerificationPermissions(searchModel.UserId, "Petition", "Index");
                var petitionEntity = new PetitionEntity();
                petitionEntity.Priority = searchModel.Priority;
                petitionEntity.PetitionSource = searchModel.PetitionSource;
                if (!isAll)//不能查看全部
                {
                    petitionEntity.PetitionCompany = searchModel.ComPanyId;
                }
                else
                {
                    petitionEntity.PetitionCompany = string.Empty;
                }

                var data = _petitionbll.QueryList(petitionEntity, searchModel.KeyWords, PetitionStateType.All.ToString(), "", "", searchModel.Rows, searchModel.Page, searchModel.StartTime, searchModel.EndTime);
               timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
                var result = JsonConvert.SerializeObject(data, timeConverter);
                //return result;
                Status = true;
                obj = result;
            }
            catch (Exception)
            {
                //return JsonConvert.SerializeObject(new { });
                Status = false;
            }
            var results=new StatusModel()
            {
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(results, timeConverter);
        }

        /// <summary>
        /// 信访附件上传
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string UpPetitionFile(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            UpPetitionInfor upInfor = JsonConvert.DeserializeObject<UpPetitionInfor>(context);
            if (string.IsNullOrEmpty(upInfor.PetitionId) || string.IsNullOrEmpty(upInfor.FileName) || string.IsNullOrEmpty(upInfor.FileData))
            {
                //return "false";
                Status = false;
            }
            try
            {
                var bytes = Convert.FromBase64String(upInfor.FileData);
                var filename = GetFileName(upInfor.FileName);   //重新生成命称
                //调用WebService进行文件存储.FileExt(postedFile.FileName)
                var filePath = new PictureService.PictureService(AppConfig.FileSaveServiceLink).WritePictureSecond("Petition", CommonMethod.FileExt(filename), filename, bytes);

                //保存实体
                var attachDal = new ComAttachmentBll();
                ComAttachmentEntity petitionInfo = new ComAttachmentEntity();
                petitionInfo.Id = Guid.NewGuid().ToString();
                petitionInfo.ResourceId = upInfor.PetitionId;
                petitionInfo.FileName = upInfor.FileName;
                petitionInfo.FileReName = filename;
                petitionInfo.FileAddress = filePath;
                petitionInfo.FileType = upInfor.FileType;
                petitionInfo.FileTypeName = upInfor.FileType == "1" ? "信访上报附件" : "信访流程附件";
                petitionInfo.RowStatus = 1;
                petitionInfo.CreateOn = DateTime.Now;
                petitionInfo.CreatorId = upInfor.UserId;
                attachDal.Add(petitionInfo);
            }
            catch (Exception)
            {
                //return "false";
                Status = false;
            }
            //return "true";
            Status = true;
            obj = "true";
            var result = new StatusModel()
            {
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(result);
        }

        public class UpPetitionInfor
        {
            /// <summary>
            /// 信访案件编号
            /// </summary>
            public string PetitionId { get; set; }

            /// <summary>
            /// 附件类型1.登记材料  2.历史恢复材料
            /// </summary>
            public string FileType { get; set; }

            /// <summary>
            /// 文件名（包含文件后缀）
            /// </summary>
            public string FileName { get; set; }

            /// <summary>
            /// 文件数据
            /// </summary>
            public string FileData { get; set; }

            /// <summary>
            /// 上传人
            /// </summary>
            public string UserId { get; set; }
        }

        /// <summary>
        /// 信访搜索条件
        /// </summary>
        private class PetitionSearchEntity
        {

            /// <summary>
            /// 片区编号
            /// </summary>
            public string ComPanyId { get; set; }

            /// <summary>
            /// 优先级
            /// </summary>
            public string Priority { get; set; }

            /// <summary>
            /// 投诉来源
            /// </summary>
            public string PetitionSource { get; set; }

            /// <summary>
            /// 关键字
            /// </summary>
            public string KeyWords { get; set; }

            /// <summary>
            /// 人员编号
            /// </summary>
            public string UserId { get; set; }

            /// <summary>
            /// 每页多少行
            /// </summary>
            public int Rows { get; set; }

            /// <summary>
            /// 第几页
            /// </summary>
            public int Page { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string StartTime { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string EndTime { get; set; }
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
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(result);
        }
    }
}
