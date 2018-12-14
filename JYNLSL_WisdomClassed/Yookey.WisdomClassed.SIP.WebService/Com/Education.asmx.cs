using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Education;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Education;

namespace Yookey.WisdomClassed.SIP.WebService.Com
{
    /// <summary>
    /// Education 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Education : System.Web.Services.WebService
    {

        private readonly EducationBll _educationBll = new EducationBll();
        private readonly EducationAttachBll _educationAttachBll = new EducationAttachBll();

        #region 获取列表

        #endregion

        #region 获取纠处详情


        #endregion

        #region 数据上报
        /// <summary>
        /// 创建或保存教育纠处信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string CreateOrUpdateEducationInfo(string context)
        {
            var msg = "";
            bool Status = false;
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    #region 字段
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;                              //Id
                    var departmentId = Regex.Match(context, @"(?<=""DepartmentId""\:"").*?(?="",)").Value;          //部门编号
                    var departmentName = Regex.Match(context, @"(?<=""DepartmentName""\:"").*?(?="",)").Value;      //部门名称
                    var firstUserId = Regex.Match(context, @"(?<=""FirstUserId""\:"").*?(?="",)").Value;            //执法队员一（编号）
                    var firstUserName = Regex.Match(context, @"(?<=""FirstUserName""\:"").*?(?="",)").Value;        //执法队员一（姓名）    
                    var secondUserId = Regex.Match(context, @"(?<=""SecondUserId""\:"").*?(?="",)").Value;          //执法队员二（编号）
                    var secondUserName = Regex.Match(context, @"(?<=""SecondUserName""\:"").*?(?="",)").Value;      //执法队员二（姓名）
                    var legislationId = Regex.Match(context, @"(?<=""LegislationId""\:"").*?(?="",)").Value;        //违法行为编号
                    var itemNo = Regex.Match(context, @"(?<=""ItemNo""\:"").*?(?="",)").Value;                      //案由编码
                    var itemName = Regex.Match(context, @"(?<=""ItemName""\:"").*?(?="",)").Value;                  //纠处行为
                    var educationTime = Regex.Match(context, @"(?<=""EducationTime""\:"").*?(?="",)").Value;        //纠处时间
                    var educationAddress = Regex.Match(context, @"(?<=""EducationAddress""\:"").*?(?="",)").Value;  //纠处地点
                    var roadId = Regex.Match(context, @"(?<=""RoadId""\:"").*?(?="",)").Value;                    //路段编号
                    var roadName = Regex.Match(context, @"(?<=""RoadName""\:"").*?(?="",)").Value;                //路段名称
                    var partyFeatures = Regex.Match(context, @"(?<=""PartyFeatures""\:"").*?(?="",)").Value;      //当事人特征，用逗号分隔开
                    var isRefused = Regex.Match(context, @"(?<=""IsRefused""\:"").*?(?="",)").Value;              //当事人是否拒绝表达身份
                    var targetName = Regex.Match(context, @"(?<=""TargetName""\:"").*?(?="",)").Value;            //当事人姓名
                    var targetAddress = Regex.Match(context, @"(?<=""TargetAddress""\:"").*?(?="",)").Value;      //当事人地址
                    var targetPaperType = Regex.Match(context, @"(?<=""TargetPaperType""\:"").*?(?="",)").Value;  //证件类型
                    var targetPaperNum = Regex.Match(context, @"(?<=""TargetPaperNum""\:"").*?(?="",)").Value;    //证件号码
                    var targetAge = Regex.Match(context, @"(?<=""TargetAge""\:"").*?(?="",)").Value;              //当事人年龄
                    var remark = Regex.Match(context, @"(?<=""Remark""\:"").*?(?="",)").Value;                    //备注
                    var creatorId = Regex.Match(context, @"(?<=""CreatorId""\:"").*?(?="",)").Value;              //创建人Id

                    #endregion

                    #region 必要性验证
                    //部门编号
                    if (string.IsNullOrEmpty(departmentId))
                    {
                        msg += "部门编号不能为空；";
                    }
                    if (string.IsNullOrEmpty(firstUserId) && string.IsNullOrEmpty(secondUserId))
                    {
                        msg += "执法人员不能为空；";
                    }
                    if (string.IsNullOrEmpty(creatorId))
                    {
                        msg += "当前用户Id不能为空；";
                    }
                    if (!string.IsNullOrEmpty(msg))
                        return JsonConvert.SerializeObject(new
                        {
                            Status = false,
                            Id = "",
                            msg = msg
                        });
                    #endregion

                    var entity = new EducationEntity();

                    #region 正确性验证
                    //验证部门
                    var dept = new CrmDepartmentBll().Get(departmentId);
                    if (dept == null)
                    {
                        msg += "部门不存在；";
                    }
                    //验证用户
                    var first = new CrmUserBll().Get(firstUserId);
                    if (first == null)
                    {
                        msg += "执法人一不存在；";
                    }
                    var second = new CrmUserBll().Get(secondUserId);
                    if (second == null)
                    {
                        msg += "执法人二不存在；";
                    }
                    var createUser = new CrmUserBll().Get(creatorId);
                    if (createUser == null)
                    {
                        msg += "当前用户不存在；";
                    }

                    int age;
                    targetAge = string.IsNullOrEmpty(targetAge) ? "0" : targetAge;
                    if (!int.TryParse(targetAge, out age))
                    {
                        msg += "当事人年龄格式不正确；";
                    }
                    int iIsRefused;
                    isRefused = string.IsNullOrEmpty(isRefused) ? "0" : isRefused;
                    if (!int.TryParse(isRefused, out iIsRefused))
                    {
                        msg += "是否拒绝表达身份格式不正确；";
                    }
                    if (!string.IsNullOrEmpty(msg))
                        return JsonConvert.SerializeObject(new
                        {
                            Status = false,
                            Id = "",
                            msg = msg
                        });
                    #endregion

                    if (!string.IsNullOrEmpty(id))
                    {
                        entity = _educationBll.Get(id);
                    }
                    if (entity == null || string.IsNullOrEmpty(entity.Id))
                    {
                        #region 实体赋值

                        entity = new EducationEntity
                            {
                                Id = id,
                                DepartmentId = departmentId,
                                DepartmentName = departmentName,
                                FirstUserId = firstUserId,
                                FirstUserName = firstUserName,
                                SecondUserId = secondUserId,
                                SecondUserName = secondUserName,
                                LegislationId = legislationId,
                                ItemNo = itemNo,
                                ItemName = itemName,
                                EducationTime = Convert.ToDateTime(educationTime),
                                EducationAddress = educationAddress,
                                RoadId = roadId,
                                RoadName = roadName,
                                PartyFeatures = partyFeatures,
                                IsRefused = string.IsNullOrEmpty(isRefused) ? 0 : isRefused.ToInt32(),
                                TargetName = targetName,
                                TargetAddress = targetAddress,
                                TargetPaperType = targetPaperType,
                                TargetPaperNum = targetPaperNum,
                                TargetAge = targetAge.ToInt32(),
                                Remark = remark,
                                Sync = 0,
                                RowStatus = 1,
                                CreatorId = createUser.Id,
                                CreateBy = createUser.RealName,
                                CreateOn = DateTime.Now,
                                UpdateId = createUser.Id,
                                UpdateBy = createUser.RealName,
                                UpdateOn = DateTime.Now
                            };



                        #endregion

                        _educationBll.Add(entity);
                    }
                    else
                    {
                        #region 实体赋值

                        entity.Id = id;
                        entity.DepartmentId = departmentId;
                        entity.DepartmentName = departmentName;
                        entity.FirstUserId = firstUserId;
                        entity.FirstUserName = firstUserName;
                        entity.SecondUserId = secondUserId;
                        entity.SecondUserName = secondUserName;
                        entity.LegislationId = legislationId;
                        entity.ItemNo = itemNo;
                        entity.ItemName = itemName;
                        entity.EducationTime = Convert.ToDateTime(educationTime);
                        entity.EducationAddress = educationAddress;
                        entity.RoadId = roadId;
                        entity.RoadName = roadName;
                        entity.PartyFeatures = partyFeatures;
                        entity.IsRefused = string.IsNullOrEmpty(isRefused) ? 0 : isRefused.ToInt32();
                        entity.TargetName = targetName;
                        entity.TargetAddress = targetAddress;
                        entity.TargetPaperType = targetPaperType;
                        entity.TargetPaperNum = targetPaperNum;
                        entity.TargetAge = targetAge.ToInt32();
                        entity.Remark = remark;
                        entity.Sync = 0;
                        entity.RowStatus = 1;
                        entity.UpdateId = createUser.Id;
                        entity.UpdateBy = createUser.RealName;
                        entity.UpdateOn = DateTime.Now;

                        #endregion

                        _educationBll.Update(entity);
                    }

                    // return JsonConvert.SerializeObject(new { Status = true, Id = id, msg = msg });
                    Status = true;
                    obj = id;
                }
                else
                {
                    //return JsonConvert.SerializeObject(new { Status = false, Id = "", msg = "空请求" });
                    Status = false;
                    obj = "";
                }
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new { Status = false, Id = "", msg = ex.Message });
                //return JsonConvert.SerializeObject(new { });
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
        #endregion

        #region 附件

        /// <summary>
        /// 纠处附件
        /// </summary>
        /// <param name="ResourceId"></param>
        /// <param name="ImageData"></param>
        /// <param name="ImageName"></param>
        /// <param name="FileType"></param>
        /// <param name="FileTypeName"></param>
        /// <param name="FileRemark"></param>
        /// <param name="ShootTime"></param>
        /// <param name="ShootAddr"></param>
        /// <param name="ShootPersoneFirst"></param>
        /// <param name="ShootPersoneSecond"></param>
        /// <param name="CreatorId"></param>
        /// <returns></returns>
        //string ResourceId, string ImageData, string ImageName, string FileType, string FileTypeName, string FileRemark, string ShootTime, string ShootAddr, string ShootPersoneFirst, string ShootPersoneSecond, string CreatorId
        [WebMethod]
        public string CreateEducationAttach(string context)
        {
            var msg = "";
            bool Status = false;
            object obj = null;
            try
            {
                #region 字段
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var ResourceId = Regex.Match(context, @"(?<=""ResourceId""\:"").*?(?="",)").Value;
                var ImageData = Regex.Match(context, @"(?<=""ImageData""\:"").*?(?="",)").Value;
                var ImageName = Regex.Match(context, @"(?<=""ImageName""\:"").*?(?="",)").Value;
                var FileType = Regex.Match(context, @"(?<=""FileType""\:"").*?(?="",)").Value;
                var FileTypeName = Regex.Match(context, @"(?<=""FileTypeName""\:"").*?(?="",)").Value;
                var FileRemark = Regex.Match(context, @"(?<=""FileRemark""\:"").*?(?="",)").Value;
                var ShootTime = Regex.Match(context, @"(?<=""ShootTime""\:"").*?(?="",)").Value;
                var ShootAddr = Regex.Match(context, @"(?<=""ShootAddr""\:"").*?(?="",)").Value;
                var ShootPersoneFirst = Regex.Match(context, @"(?<=""ShootPersoneFirst""\:"").*?(?="",)").Value;
                var ShootPersoneSecond = Regex.Match(context, @"(?<=""ShootPersoneSecond""\:"").*?(?="",)").Value;
                var CreatorId = Regex.Match(context, @"(?<=""CreatorId""\:"").*?(?="",)").Value; 
                #endregion

                #region 字段校验
                if (string.IsNullOrEmpty(ResourceId))
                {
                    msg += "暂扣Id为空；";
                }
                if (string.IsNullOrEmpty(ImageData))
                {
                    msg += "图片数据为空；";
                }
                if (string.IsNullOrEmpty(ImageName))
                {
                    msg += "图片名称为空；";
                }
                if (string.IsNullOrEmpty(CreatorId))
                {
                    msg += "创建人Id为空；";
                }

                if (!string.IsNullOrEmpty(msg))
                    return JsonConvert.SerializeObject(new
                    {
                        Status = false,
                        Id = "",
                        msg = msg
                    });

                #region 写入到本地硬盘 （不用）

                //var bytes = Convert.FromBase64String(ImageData);
                //var time = DateTime.Now;        //照片时间
                //var urlPath = string.Format(@"/{0}/{1}/{2}/", "Education", DateTime.Now.Year.ToString("d4"), DateTime.Now.Month.ToString("d2"));
                //var dirPath = AppConfig.FileSaveAddr + urlPath;
                //if (!Directory.Exists(dirPath))
                //{
                //    Directory.CreateDirectory(dirPath);
                //}
                //var filename = GetFileName(ImageName.ToLower());   //重新生成命称
                ////将图片写到硬盘
                //var fs = new FileStream(dirPath + filename, FileMode.CreateNew, FileAccess.Write, FileShare.None, bytes.Length, false);
                //fs.Write(bytes, 0, bytes.Length);
                //fs.Close();
                //fs.Dispose();

                #endregion

                #region 调用服务存储照片

                var imageData = Convert.FromBase64String(ImageData);
                var filename = GetFileName(ImageName.ToLower());   //重新生成命称

                //调用WebService进行文件存储.FileExt(postedFile.FileName)
                var filePath = new PictureService.PictureService(AppConfig.FileSaveServiceLink).WritePictureSecond("Education",
                    CommonMethod.FileExt(ImageName), filename, imageData);


                #endregion

                var dateShootTime = new DateTime(1900, 01, 01);
                if (!string.IsNullOrEmpty(ShootTime))
                    if (!DateTime.TryParse(ShootTime, out dateShootTime))
                    {
                        msg += "拍摄时间格式不正确；";
                    }
                var baseUserBll = new BaseUserBll();
                string firtPersonId = "", firtPersonName = "";
                if (!string.IsNullOrEmpty(ShootPersoneFirst))
                {
                    var first = baseUserBll.Get(ShootPersoneFirst);
                    if (first == null)
                    {
                        msg += "拍摄执法人一不存在";
                    }
                    else
                    {
                        firtPersonId = first.Id;
                        firtPersonName = first.UserName;
                    }
                }
                string secondPersonId = "", secondPersonName = "";
                if (!string.IsNullOrEmpty(ShootPersoneFirst))
                {
                    var second = baseUserBll.Get(ShootPersoneSecond);
                    if (second == null)
                    {
                        msg += "拍摄执法人一不存在";
                    }
                    else
                    {
                        secondPersonId = second.Id;
                        secondPersonName = second.UserName;
                    }
                }

                var user = baseUserBll.Get(CreatorId);
                if (user == null)
                {
                    msg += "创建人不存在；";
                }
                if (!string.IsNullOrEmpty(msg))
                    return JsonConvert.SerializeObject(new
                    {
                        Status = false,
                        Id = "",
                        msg = msg
                    });
                #endregion

                #region 实体赋值

                var entity = new EducationAttachEntity
                    {
                        ResourceId = ResourceId,
                        FileName = ImageName,
                        FileReName = filename,
                        FileAddress = filePath,
                        FileRemark = FileRemark,
                        FileType = FileType,
                        FileTypeName = FileTypeName,
                        ShootTime = dateShootTime,
                        ShootPersoneFirst = firtPersonId,
                        ShootPersoneNameFirst = firtPersonName,
                        ShootPersoneSecond = secondPersonId,
                        ShootPersoneNameSecond = secondPersonName,
                        CreatorId = user.Id,
                        CreateBy = user.UserName,
                        CreateOn = DateTime.Now,
                        UpdateId = user.Id,
                        UpdateBy = user.UserName
                    };

                entity.UpdateOn = entity.CreateOn;
                #endregion

                var id = _educationAttachBll.CreateEducationAttachInfo(entity);
                //return JsonConvert.SerializeObject(new
                //{
                //    Status = true,
                //    Id = id,
                //    msg = ""
                //});
                Status = true;
                obj = id;
            }
            catch (Exception e)
            {
                //return JsonConvert.SerializeObject(new
                //{
                //    Status = "",
                //    Id = "",
                //    msg = e.Message
                //});
                //return JsonConvert.SerializeObject(new { });
                Status = false;
                msg = e.Message;
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
        /// 生成文件名
        /// 创建人：周庆
        /// 创建日期：2015年5月5日
        /// </summary>
        /// <param name="filename">文件名</param>
        /// <returns></returns>
        public static string GetFileName(string context)
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
            catch (Exception ex)
            {
                Status = false;
                msg = ex.Message;
                //return JsonConvert.SerializeObject(new { });
            }
            var result = new StatusModel()
            {
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(result);
        }
        #endregion
    }
}
