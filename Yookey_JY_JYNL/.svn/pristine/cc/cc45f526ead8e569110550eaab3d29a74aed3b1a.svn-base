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
using Yookey.WisdomClassed.SIP.Business.TempDetain;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.TempDetain;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.WebService.Com
{
    /// <summary>
    /// TempDetain 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class TempDetain : System.Web.Services.WebService
    {
        private readonly TempDetainInfoBll _tempDetainInfoBll = new TempDetainInfoBll();
        private readonly TempDetainGoodsBll _tempDetainGoodsBll = new TempDetainGoodsBll();
        private readonly TempDetainAttachBll _tempDetainAttachBll = new TempDetainAttachBll();
        private readonly TempDetainNumBll _tempDetainNumBll = new TempDetainNumBll();
        private readonly ComNumberBll _comNumberBll = new ComNumberBll();

        private readonly object _obj = new object();

        private delegate int ChangeStatus(string Id, string UpdateId, string UpdateBy);


        /// <summary>
        /// 自动获取编号
        /// 添加人：周 鹏
        /// 添加时间：2015-05-05
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="context">The context.</param>
        /// <returns>System.String.</returns>
        [WebMethod]
        public string GetTempDatainNum(string context)
        {
            var num = "";  //编号
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
                        var numType = Regex.Match(context, @"(?<=""NumType""\:"").*?(?="",)").Value;      //编号类型
                        var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;        //用户Id
                        var userName = Regex.Match(context, @"(?<=""UserName""\:"").*?(?="",)").Value;    //用户姓名

                        if (!string.IsNullOrEmpty(numType))
                        {
                            switch (numType)
                            {
                                case "00470001":  //暂扣
                                    num = _comNumberBll.GetNumber(AppConst.NumTempZq, "", null);
                                    break;
                                case "00470002":  //先行
                                    num = _comNumberBll.GetNumber(AppConst.NumTempXx, "", null);
                                    break;
                            }

                            if (!string.IsNullOrEmpty(num))
                            {
                                var entity = new TempDetainNumEntity()
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Num = num,
                                    RowStatus = 1,
                                    CreatorId = userId,
                                    CreateBy = userName,
                                    CreateOn = DateTime.Now,
                                    UpdateId = userId,
                                    UpdateBy = userName,
                                    UpdateOn = DateTime.Now
                                };
                                _tempDetainNumBll.Add(entity);
                            }
                        }
                    }
                }
                //return JsonConvert.SerializeObject(new { Status = true, msg = num });
                Status = true;
                obj = num;
            }
            catch (Exception ex)
            {
                //return JsonConvert.SerializeObject(new { Status = false, msg = ex.Message });
                //return JsonConvert.SerializeObject(new { });
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
        ///创建或保存暂扣基本信息
        ///创建人：周庆
        ///创建日期：2015年5月5日
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string CreateOrUpdateTempDetainInfo(string context)
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
                    var id = Regex.Match(context, @"(?<=""Id""\:"").*?(?="",)").Value;              //Id
                    var tempNo = Regex.Match(context, @"(?<=""TempNo""\:"").*?(?="",)").Value;      //暂扣单据编号
                    var tempType = Regex.Match(context, @"(?<=""TempType""\:"").*?(?="",)").Value;  //暂扣类型
                    var deptId = Regex.Match(context, @"(?<=""DeptId""\:"").*?(?="",)").Value;      //部门Id
                    var rePersonelIdFist = Regex.Match(context, @"(?<=""RePersonelIdFist""\:"").*?(?="",)").Value;      //执法队员一（编号）
                    var rePersonelIdSecond = Regex.Match(context, @"(?<=""RePersonelIdSecond""\:"").*?(?="",)").Value;  //执法队员二（编号）
                    var isRefused = Regex.Match(context, @"(?<=""IsRefused""\:"").*?(?="",)").Value;            //是否拒绝表达身份
                    var targetType = Regex.Match(context, @"(?<=""TargetType""\:"").*?(?="",)").Value;          //当事人类型
                    var targetName = Regex.Match(context, @"(?<=""TargetName""\:"").*?(?="",)").Value;          //当事人姓名/负责人姓名
                    var targetAddress = Regex.Match(context, @"(?<=""TargetAddress""\:"").*?(?="",)").Value;    //当事人地址
                    var targetPaperType = Regex.Match(context, @"(?<=""TargetPaperType""\:"").*?(?="",)").Value;//证件类型
                    var targetPaperNum = Regex.Match(context, @"(?<=""TargetPaperNum""\:"").*?(?="",)").Value;  //证件号码
                    var targetGender = Regex.Match(context, @"(?<=""TargetGender""\:"").*?(?="",)").Value;      //当事人性别
                    var targetAge = Regex.Match(context, @"(?<=""TargetAge""\:"").*?(?="",)").Value;            //当事人年龄
                    var targetUnit = Regex.Match(context, @"(?<=""TargetUnit""\:"").*?(?="",)").Value;          //单位名称
                    var targetDuty = Regex.Match(context, @"(?<=""TargetDuty""\:"").*?(?="",)").Value;          //当事人职务
                    var targetPhone = Regex.Match(context, @"(?<=""TargetPhone""\:"").*?(?="",)").Value;        //当事人联系电话
                    var targetMobile = Regex.Match(context, @"(?<=""TargetMobile""\:"").*?(?="",)").Value;      //当事人手机号
                    var targetZipCode = Regex.Match(context, @"(?<=""TargetZipCode""\:"").*?(?="",)").Value;    //邮编
                    var targetEmail = Regex.Match(context, @"(?<=""TargetEmail""\:"").*?(?="",)").Value;        //电子邮件
                    var creatorId = Regex.Match(context, @"(?<=""CreatorId""\:"").*?(?="",)").Value;            //创建人Id

                    var roadNo = Regex.Match(context, @"(?<=""RoadNo""\:"").*?(?="",)").Value;           //案发路段编号
                    var roadName = Regex.Match(context, @"(?<=""RoadName""\:"").*?(?="",)").Value;       //案发路段名称
                    var tempAddress = Regex.Match(context, @"(?<=""TempAddress""\:"").*?(?="",)").Value;    //暂扣地址

                    var itemno = Regex.Match(context, @"(?<=""Itemno""\:"").*?(?="",)").Value;                                 //案由编号
                    var legislationId = Regex.Match(context, @"(?<=""LegislationId""\:"").*?(?="",)").Value;                   //违法行为
                    var legislationItemId = Regex.Match(context, @"(?<=""LegislationItemId""\:"").*?(?="",)").Value;           //适用案由
                    var legislationGistId = Regex.Match(context, @"(?<=""LegislationGistId""\:"").*?(?="",)").Value;           //法律条文

                    #endregion

                    #region 必要性验证
                    //部门编号
                    if (string.IsNullOrEmpty(deptId))
                    {
                        msg += "部门编号不能为空；";
                    }
                    if (string.IsNullOrEmpty(rePersonelIdFist) && string.IsNullOrEmpty(rePersonelIdSecond))
                    {
                        msg += "执法人员不能为空；";
                    }
                    if (string.IsNullOrEmpty(creatorId))
                    {
                        msg += "当前用户Id不能为空；";
                    }
                    //选择证件类型但是没有输入证件号码
                    if (!string.IsNullOrEmpty(targetPaperType) && string.IsNullOrEmpty(targetPaperNum))
                    {
                        msg += "证件号码不能为空；";
                    }
                    if (!string.IsNullOrEmpty(msg))
                    {
                        //return JsonConvert.SerializeObject(new
                        //{
                        //    Status = false,
                        //    Id = "",
                        //    msg = msg
                        //});
                        Status = false;
                    }
                    #endregion

                    var entity = new TempDetainInfoEntity();

                    #region 正确性验证
                    //验证部门
                    var dept = new BaseDepartmentBll().Get(deptId);
                    if (dept == null)
                    {
                        msg += "部门不存在；";
                    }
                    else
                    {
                        entity.DepartmentId = dept.DepartmentId;
                        entity.DepartmentName = dept.FullName;
                    }
                    var baseUserBll = new BaseUserBll();
                    //验证用户
                    var first = baseUserBll.Get(rePersonelIdFist);
                    if (first == null)
                    {
                        msg += "执法人一不存在；";
                    }
                    else
                    {
                        entity.RePersonelIdFist = first.Id;
                        entity.RePersonelNameFist = first.UserName;
                    }
                    var second = baseUserBll.Get(rePersonelIdSecond);
                    if (second == null)
                    {
                        msg += "执法人二不存在；";
                    }
                    else
                    {
                        entity.RePersonelIdSecond = second.Id;
                        entity.RePersonelNameSecond = second.UserName;
                    }
                    var createUser = baseUserBll.Get(creatorId);
                    if (createUser == null)
                    {
                        msg += "当前用户不存在；";
                    }
                    else
                    {
                        entity.CreatorId = createUser.Id;
                        entity.CreateBy = createUser.UserName;
                        entity.CreateOn = DateTime.Now;
                        entity.UpdateId = createUser.Id;
                        entity.UpdateBy = createUser.UserName;
                        entity.UpdateOn = DateTime.Now;
                    }

                    int age;
                    targetAge = string.IsNullOrEmpty(targetAge) ? "0" : targetAge;
                    if (!int.TryParse(targetAge, out age))
                    {
                        msg += "当事人年龄格式不正确；";
                    }
                    else
                    {
                        entity.TargetAge = age;
                    }
                    int iIsRefused;
                    isRefused = string.IsNullOrEmpty(isRefused) ? "0" : isRefused;
                    if (!int.TryParse(isRefused, out iIsRefused))
                    {
                        msg += "是否拒绝表达身份格式不正确；";
                    }
                    else
                    {
                        entity.IsRefused = iIsRefused;
                    }
                    if (!string.IsNullOrEmpty(msg))
                    {
                        //return JsonConvert.SerializeObject(new
                        //{
                        //    Status = false,
                        //    Id = "",
                        //    msg = msg
                        //});
                        Status = false;
                    }
                    #endregion

                    #region 实体赋值

                    var departmentEntity = new CrmDepartmentBll().Get(deptId);
                    var companyEntity = new CrmCompanyBll().Get(departmentEntity.CompanyId);

                    entity.CompanyId = companyEntity.Id;
                    entity.CompanyName = companyEntity.FullName;
                    entity.DepartmentId = departmentEntity.Id;
                    entity.DepartmentName = departmentEntity.FullName;

                    entity.Id = id;
                    entity.TempNo = tempNo;
                    entity.TempType = tempType;
                    entity.TargetType = targetType;
                    entity.TargetName = targetName;
                    entity.TargetAddress = targetAddress;
                    entity.TargetPaperType = targetPaperType;
                    entity.TargetPaperNum = targetPaperNum;
                    entity.TargetGender = targetGender;
                    entity.TargetUnit = targetUnit;
                    entity.TargetDuty = targetDuty;
                    entity.TargetPhone = targetPhone;
                    entity.TargetMobile = targetMobile;
                    entity.TargetZipCode = targetZipCode;
                    entity.TargetEmail = targetEmail;
                    entity.TempAddress = tempAddress;
                    entity.RoadNo = roadNo;
                    entity.RoadName = roadName;
                    entity.TempDateTime = DateTime.Now;

                    #endregion

                    var entityId = _tempDetainInfoBll.CreateOrUpdateTempDetainInfo(entity, legislationId, legislationItemId, legislationGistId);
                    //return JsonConvert.SerializeObject(new { Status = true, Id = entityId, msg = msg });
                    Status = true;
                    obj = entityId;
                }
                else
                {
                    //return JsonConvert.SerializeObject(new { Status = false, Id = "", msg = "空请求" });
                    Status = false;
                    msg = "空请求";
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
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 创建暂扣物品
        /// 创建人：周庆
        /// 创建日期：2015年5月5日
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string CreateTempDetainGoods(string context)
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
                    var tempId = Regex.Match(context, @"(?<=""TempId""\:"").*?(?="",)").Value; //暂扣物品Id
                    var classI = Regex.Match(context, @"(?<=""ClassI""\:"").*?(?="",)").Value; //大类
                    var classII = Regex.Match(context, @"(?<=""ClassII""\:"").*?(?="",)").Value; //小类
                    var goodsNo = Regex.Match(context, @"(?<=""GoodsNo""\:"").*?(?="",)").Value; //物品编号
                    var goodsName = Regex.Match(context, @"(?<=""GoodsName""\:"").*?(?="",)").Value; //物品名称
                    var goodsCount = Regex.Match(context, @"(?<=""GoodsCount""\:"").*?(?="",)").Value; //物品数量
                    var goodsUnit = Regex.Match(context, @"(?<=""GoodsUnit""\:"").*?(?="",)").Value; //计量单位编号
                    var goodsUnitName = Regex.Match(context, @"(?<=""GoodsUnitName""\:"").*?(?="",)").Value; //计量单位名称
                    var specification = Regex.Match(context, @"(?<=""Specification""\:"").*?(?="",)").Value; //规格型号
                    var remark = Regex.Match(context, @"(?<=""Remark""\:"").*?(?="",)").Value; //备注描述

                    var creatorId = Regex.Match(context, @"(?<=""CreatorId""\:"").*?(?="",)").Value; //创建人Id

                    #endregion

                    #region 字段校验

                    if (string.IsNullOrEmpty(creatorId))
                    {
                        msg += "创建人Id为空；";
                    }
                    if (remark.Length > 50)
                        msg += "备注字段不能超过50个字符；";

                    goodsCount = string.IsNullOrEmpty(goodsCount) ? "0" : goodsCount;
                    int iGoodsCount;
                    if (!int.TryParse(goodsCount, out iGoodsCount))
                        msg += "物品数量格式不正确；";

                    if (!string.IsNullOrEmpty(msg))
                    {
                        //return JsonConvert.SerializeObject(new
                        //    {
                        //        Status = false,
                        //        Id = "",
                        //        msg = msg
                        //    });
                        Status = false;
                    }
                    var user = new BaseUserBll().Get(creatorId);
                    if (user == null)
                    {
                        msg += "创建人不存在；";
                    }
                    if (!string.IsNullOrEmpty(msg))
                    {
                        //return JsonConvert.SerializeObject(new
                        //    {
                        //        Status = false,
                        //        Id = "",
                        //        msg = msg
                        //    });
                        Status = false;
                    }
                    #endregion

                    #region 赋值

                    var entity = new TempDetainGoodsEntity
                        {
                            TempId = tempId,
                            ClassI = classI,
                            ClassII = classII,
                            GoodsNo = goodsNo,
                            GoodsName = goodsName,
                            GoodsCount = iGoodsCount,
                            GoodsUnit = goodsUnit,
                            GoodsUnitName = goodsUnitName,
                            Specification = specification,
                            TransferDeptName = "",
                            Remark = remark,
                            CreatorId = user.Id,
                            CreateBy = user.UserName,
                            CreateOn = DateTime.Now,
                            UpdateId = user.Id,
                            UpdateBy = user.UserName
                        };

                    entity.UpdateOn = entity.CreateOn;

                    #endregion

                    var id = _tempDetainGoodsBll.CreateTempDetainGoods(entity);
                    //return JsonConvert.SerializeObject(new
                    //    {
                    //        Status = true,
                    //        Id = id,
                    //        msg = ""
                    //    });
                    Status = true;
                    obj = id;
                }
                else
                {
                    //return JsonConvert.SerializeObject(new
                    //{
                    //    Status = false,
                    //    Id = "",
                    //    msg = "空请求"
                    //});
                    Status = false;
                    msg = "空请求";
                }
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
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);
        }


        /// <summary>
        /// 创建暂扣附件
        /// 创建人：周庆
        /// 创建日期：2015年5月5日
        /// </summary>
        /// <param name="ResourceId">暂扣Id</param>
        /// <param name="ImageData">图片Base64</param>
        /// <param name="ImageName">图片名称</param>
        /// <param name="FileType">附件类型</param>
        /// <param name="FileTypeName">附件类型名称</param>
        /// <param name="FileRemark">附件备注</param>
        /// <param name="ShootTime">拍摄时间</param>
        /// <param name="ShootAddr">拍摄地点</param>
        /// <param name="ShootPersoneFirst">拍摄执法人一</param>
        /// <param name="ShootPersoneSecond">拍摄执法人二</param>
        /// <param name="CreatorId">创建人id</param>
        /// <returns></returns>
        [WebMethod]
        public string CreateTempDetainAttach(string context)
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
                {
                    //return JsonConvert.SerializeObject(new
                    //{
                    //    Status = false,
                    //    Id = "",
                    //    msg = msg
                    //});
                    Status = false;
                }
                #region 写入到本地硬盘（不用）

                //var bytes = Convert.FromBase64String(ImageData);
                //var time = DateTime.Now;        //照片时间
                //var urlPath = string.Format(@"/{0}/{1}/{2}/", "TempDetain", DateTime.Now.Year.ToString("d4"), DateTime.Now.Month.ToString("d2"));
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
                var filePath = new PictureService.PictureService(AppConfig.FileSaveServiceLink).WritePictureSecond("TempDetain",
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

                #region 赋值
                var entity = new TempDetainAttachEntity
                    {
                        ResourceId = ResourceId,
                        FileName = ImageName,
                        FileReName = filename,
                        FileAddress = filePath,
                        FileRemark = FileRemark,
                        FileType = "00320001",
                        FileTypeName = "现场照片",
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

                var id = _tempDetainAttachBll.CreateTempDetainInfo(entity);
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
                Status = Status,
                msg = msg,
                Content = obj
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
        public static string GetFileName(string filename)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
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
                //return JsonConvert.SerializeObject(new { });
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
        /// 获取暂扣数据
        /// 创建人：周庆
        /// 创建日期：2015年5月7日
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetAllTempDetain(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            var timeConverter = new IsoDateTimeConverter();
            try
            {
                int pageSize = 30;
                int pageIndex = 1;
                string deptId = null, startTime = null, endTime = null;
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    deptId = Regex.Match(context, @"(?<=""DeptId""\:"").*?(?="",)").Value;
                    startTime = Regex.Match(context, @"(?<=""StartTime""\:"").*?(?="",)").Value;
                    endTime = Regex.Match(context, @"(?<=""EndTime""\:"").*?(?="",)").Value;
                    string strPageSize = Regex.Match(context, @"(?<=""PageSize""\:"").*?(?="",)").Value;
                    string strPageIndex = Regex.Match(context, @"(?<=""PageIndex""\:"").*?(?="",)").Value;


                    if (!string.IsNullOrEmpty(strPageIndex))
                        int.TryParse(strPageIndex, out pageIndex);
                    if (!string.IsNullOrEmpty(strPageSize))
                        int.TryParse(strPageSize, out pageSize);
                }
                var data = _tempDetainInfoBll.GetAllTempDetainInfo("", deptId, startTime, endTime, "", pageSize, pageIndex);
                timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
                //return JsonConvert.SerializeObject(data.rows, timeConverter);
                Status = true;
                obj = data.rows;
            }
            catch (Exception e)
            {
                //return JsonConvert.SerializeObject(new { error = e.Message });
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
            return JsonConvert.SerializeObject(result, timeConverter);
        }
    }
}
