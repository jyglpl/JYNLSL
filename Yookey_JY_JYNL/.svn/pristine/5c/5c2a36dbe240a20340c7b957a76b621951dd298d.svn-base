using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.DoubleRandom;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;

namespace Yookey.WisdomClassed.SIP.WebService.DoubleRandom
{
    /// <summary>
    /// DoubleRandom 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class DoubleRandom : System.Web.Services.WebService
    {
        DoubleRandomAttachBll _doubleRandomAttachBll = new DoubleRandomAttachBll();

        /// <summary>
        /// 根据用户名称及
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetDoubleRandomList(string context)
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
                    var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;    //用户名
                    string typeId = Regex.Match(context, @"(?<=""TypeId""\:"").*?(?="",)").Value;    //类型 0：未处理，1：已处理
                    var randomTypeId = Regex.Match(context, @"(?<=""RandomTypeId""\:"").*?(?="",)").Value;    //随机类型 0：督察，1：抽查，2:全部

                    var spotCheckslst = new DoubleRandomSpotChecksBll().GetSearchList(new DoubleRandomSpotChecksEntity() { RandomType = (randomTypeId == "" ? "" : randomTypeId == "2" ? "" : randomTypeId) });
                    var doubleRandomLogList = new DoubleRandomObjLogBll().GetBy("");

                    if (typeId == "0")
                    {
                        var list = from left in doubleRandomLogList
                                   join right in spotCheckslst on left.ParentId equals right.Id into temp
                                   where left.InspectorIds.Contains(userId)
                                    && left.FinishBy == null
                                   select new
                                   {
                                       Id = left.Id,
                                       ObjName = left.ObjName,
                                       ParentId = left.ParentId,
                                       InspectorNames = left.InspectorNames,
                                       FinishTime = left.FinishTime,
                                       Remark = left.Remark,
                                       CreateOn = left.CreateOn,
                                       RadomType = left.FinishBy == null ? "0" : "1",
                                       TypeName = new ComResourceBll().GetListBy("", left.TypeId),
                                       DeptName = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity() { Id = left.TeamId})
                                   };

                        Status = true;
                        obj = list;
                    }
                    else if (typeId == "1")
                    {
                        var list = from left in doubleRandomLogList
                                   join right in spotCheckslst on left.ParentId equals right.Id into temp
                                   where left.InspectorIds.Contains(userId)
                                    && left.FinishBy != null
                                   select new
                                   {
                                       Id = left.Id,
                                       ObjName = left.ObjName,
                                       ParentId = left.ParentId,
                                       InspectorNames = left.InspectorNames,
                                       FinishTime = left.FinishTime,
                                       Remark = left.Remark,
                                       CreateOn = left.CreateOn,
                                       RadomType = left.FinishBy == null ? "0" : "1",
                                       TypeName = new ComResourceBll().GetListBy("", left.TypeId),
                                       DeptName = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity() { Id = left.TeamId})
                                   };
                        Status = true;
                        obj = list;
                    }
                    else
                    {
                        var list = from left in doubleRandomLogList
                                   join right in spotCheckslst on left.ParentId equals right.Id into temp
                                   where left.InspectorIds.Contains(userId)
                                   select new
                                   {
                                       Id = left.Id,
                                       ObjName = left.ObjName,
                                       ParentId = left.ParentId,
                                       InspectorNames = left.InspectorNames,
                                       FinishTime = left.FinishTime,
                                       Remark = left.Remark,
                                       CreateOn = left.CreateOn,
                                       RadomType = left.FinishBy == null ? "0" : "1",
                                       TypeName = new ComResourceBll().GetListBy("", left.TypeId),
                                       DeptName = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity() { Id = left.TeamId})
                                   };
                        Status = true;
                        obj = list;
                    }

                }

            }
            catch (Exception)
            {
                throw;
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
        /// 上报双随机信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string CompleteInspection(string context)
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
                    var Id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;    //Id
                    var FinishBy = Regex.Match(context, @"(?<=""FinishBy""\:"").*?(?="",)").Value;    //完成人Id
                    var FinishPerson = Regex.Match(context, @"(?<=""FinishPerson""\:"").*?(?="",)").Value;    //完成人员名称
                    var Remark = Regex.Match(context, @"(?<=""Remark""\:"").*?(?="",)").Value;    //备注

                    //var spotCheckslst = new DoubleRandomSpotChecksBll().GetSearchList(new DoubleRandomSpotChecksEntity() { RandomType = (randomTypeId == "" ? "" : randomTypeId == "2" ? "" : randomTypeId) });
                    var doubleRandomLogList = new DoubleRandomObjLogBll().GetBy("");
                    DoubleRandomObjLogEntity entity = doubleRandomLogList.Where(p => p.Id == Id).ToList()[0];

                    entity.FinishBy = FinishBy;
                    entity.FinishPerson = FinishPerson;
                    entity.FinishTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    entity.Remark = Remark;
                    entity.IsDispatch = 1;
                    new DoubleRandomObjLogBll().Update(entity);
                    Status = true;
                    obj = "";
                }

            }
            catch (Exception)
            {
                throw;
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
        /// 上传图片
        /// </summary>
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
                    //用户ID
                    string userID = Regex.Match(context, @"(?<=""userID""\:"").*?(?="",)").Value;
                    //图片类型 1:图片
                    string imageType = Regex.Match(context, @"(?<=""imageType""\:"").*?(?="",)").Value;

                    #region 调用服务存储照片

                    var filename = GetFileName(imageName.ToLower());   //重新生成命称
                    //调用WebService进行文件存储.FileExt(postedFile.FileName)
                    var filePath = new PictureService.PictureService(AppConfig.FileSaveServiceLink).WritePictureSecond("DoubleRandom", CommonMethod.FileExt(imageName), filename, imageDate);

                    #endregion

                    #region 实体信息赋值


                    var fileTypeName = "";
                    if (imageType.Equals("1"))
                    {
                        fileTypeName = "图片";
                    }
                    else
                    {
                        fileTypeName = "其他";
                    }

                    //执行数据库保存
                    var entity = new DoubleRandomAttachEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ResourceId = caseID,
                        FileType = imageType,
                        FileTypeName = fileTypeName,
                        FileAddress = filePath,
                        FileName = imageName,
                        FileReName = filename,
                        FileRemark = "注释",
                        RowStatus = 1,
                        IsCompleted = 1,
                        CreatorId = userID,
                        CreateOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        UpdateId = userID,
                        UpdateOn = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                    _doubleRandomAttachBll.Add(entity);
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
    }
}
