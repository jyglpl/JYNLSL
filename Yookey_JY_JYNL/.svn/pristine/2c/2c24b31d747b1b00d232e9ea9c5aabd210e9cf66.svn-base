using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.OnlineClass;
using Yookey.WisdomClassed.SIP.Common.PetaPoco;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Membership;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.OnlineClass;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.OnlineClass
{
    public class SystemController : BaseController
    {
        private readonly OnlineClassCourseBll _onlineClassCourseBll = new OnlineClassCourseBll();//考试
        /// <summary>
        /// 管理中心
        /// </summary>
        /// <returns></returns>
        public ActionResult CourseManager()
        {
            return View();
        }

        /// <summary>
        /// 课程列表
        /// 添加人：周 鹏
        /// 添加时间：2014-11-16
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="courseTypeId">课程类型</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <returns></returns>
        //public ActionResult CourseList(string courseTypeId, string keyword, int? pageIndex)
        //{
        //    const int pageSize = 20; //分页大小

        //    PageObject<DataTable> models;
        //    if (!string.IsNullOrEmpty(courseTypeId))
        //    {
        //        models = new OnlineClassCourseBll().GetCourseManager((CourseType)Enum.Parse(typeof(CourseType), courseTypeId),
        //                                                     pageIndex ?? 1, pageSize, keyword);
        //    }
        //    else
        //    {
        //        models = new OnlineClassCourseBll().GetCourseManager(null, pageIndex ?? 1, pageSize, keyword);
        //    }
        //    return View("CourseList", models);
        //}

        /// <summary>
        /// 课程列表
        /// </summary>
        /// <param name="courseTypeId">课程类型</param>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <returns></returns>
        public string GetCourseList(string courseTypeId, string keyword, int rows = 30, int page = 1)
        {
            //const int pageSize = 20; //分页大小
            var data = _onlineClassCourseBll.GetCourseManager(courseTypeId, page, rows, keyword);
            var result = CommonMethod.PageToJson(CommonMethod.PageToJqGridPage(data));
            return result;
        }


        /// <summary>
        /// GET System/AddCourse
        /// 新增课件
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCourse()
        {
            var model = new OnlineClassCourseEntity();
            model.Id = Guid.NewGuid().ToString();
            //验证管理员权限
            var permission = new MembershipManager().GetUserMenus(CurrentUser.CrmUser.Id, string.Format("'{0}'", "System"));
            var isAdmin = permission.Split('_')[2];
            if (isAdmin.Contains("1"))
            //if (true)
            {
                //课程类型
                var courseType = EnumOperate.ConvertEnumToList(typeof(CourseType), "1");
                ViewData["CourseType"] = courseType;
                //课程分类
                var courseClassify = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0007" });
                ViewData["Classify"] = new SelectList(courseClassify, "Id", "RsKey");

                //分值
                var score = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0084" });
                ViewData["Score"] = new SelectList(score, "RsKey", "RsValue");
                return View(model);
            }
            Response.Redirect("/HomeIndex/OfficeIndex?type=" + "pxgl");
            return View();
        }

        /// <summary>
        /// 编辑课件
        /// </summary>
        /// <returns></returns>
        public ActionResult EditCourse(string courseId)
        {
            //验证管理员权限
            var permission = new MembershipManager().GetUserMenus(CurrentUser.CrmUser.Id, string.Format("'{0}'", "System"));
            var isAdmin = permission.Split('_')[2];
            if (isAdmin.Contains("1"))
            //if (true)
            {
                var model = _onlineClassCourseBll.Get(courseId);
                //课程类型
                var courseType = EnumOperate.ConvertEnumToList(typeof(CourseType), "1");
                ViewData["CourseType"] = courseType;
                //课程分类
                var courseClassify = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0007" });
                ViewData["Classify"] = new SelectList(courseClassify, "Id", "RsKey", model.CategoryId);

                //分值
                var score = new ComResourceBll().GetSearchResult(new ComResourceEntity { ParentId = "0084" });
                ViewData["Score"] = new SelectList(score, "RsKey", "RsValue", model.Score);

                var actionUsers = _onlineClassCourseBll.GetReceiveUsers(courseId);
                if (actionUsers != null && actionUsers.Rows.Count > 0)
                {
                    var userids = actionUsers.Rows[0]["UserIds"].ToString();
                    var userNames = actionUsers.Rows[0]["UserNames"].ToString();
                    ViewBag.UserIds = !string.IsNullOrEmpty(userids) ? userids : "";
                    ViewBag.UserNames = !string.IsNullOrEmpty(userNames) ? userNames : "";

                    model.Receives = userids ?? "";
                }
                return View(model);
            }
            Response.Redirect("/HomeIndex/OfficeIndex?type=" + "pxgl");
            return View();
        }

        /// <summary>
        /// 选择接收对象
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectPerson(string receives)
        {
            ViewData["receives"] = "k";
            if (!string.IsNullOrEmpty(receives))
            {
                ViewData["receives"] = receives;
            }


            return View();
        }

        public JsonResult GetGroupUser()
        {
            var search = new CrmCompanyEntity();
            var groups = new CrmCompanyBll().GetAllCompany(search);  //查询所有部门
            //var groups=new CrmDepartmentBll()
            var zTreeList = groups.Select(comGroupsEntity => new ZTreeNode
            {
                id = comGroupsEntity.Id,
                pId = comGroupsEntity.ParentId,
                name = comGroupsEntity.FullName,
                icon = string.IsNullOrEmpty(comGroupsEntity.ParentId).Equals(0) ? "/Content/Images/treesystem.gif" : "/Content/Images/node_dept.gif",
                type = "0"
            }).ToList();
            CrmDepartmentEntity deptEntity = new CrmDepartmentEntity();
            var depts = new CrmDepartmentBll().GetAllDepartment(deptEntity);
            List<CrmDepartmentEntity> deptGroup = new List<CrmDepartmentEntity>();
            var ztreeD = depts.Select(comDept => new ZTreeNode
            {
                id = comDept.Id,
                pId = comDept.CompanyId,
                name = comDept.FullName,
                icon = "/Content/Images/node_dept.gif",
                type = "1"
            }).ToList();
            zTreeList.AddRange(ztreeD);

            var userGroup = new CrmUserBll().GetAllUsers();
            var ztreeU = userGroup.Select(comUser => new ZTreeNode
            {
                id = comUser.Id,
                pId = comUser.DepartmentId,
                name = comUser.RealName,
                icon = "/Content/Images/user.gif",
                type = "2"
            }).ToList();
            zTreeList.AddRange(ztreeU);
            var rtEntity = new StatusModel<ZTreeNode>
            {
                rtData = zTreeList,
                rtMsrg = "成功",
                rtState = 0
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存课件
        /// 添加人：周 鹏
        /// 添加时间：2014-11-15
        /// </summary>
        /// <param name="entity">课件实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveCourse(OnlineClassCourseEntity entity)
        {
            //var Jsonstr = System.Web.HttpUtility.UrlDecode(entity.Files).TrimEnd(',');
            var strUnion = "";
            string[] stb = entity.Files.TrimEnd(',').Split(',');
            for (int i = 0; i < stb.Length; i++)
            {
                var str = System.Web.HttpUtility.UrlDecode(stb[i]);
                var Obj = JsonConvert.DeserializeObject<Data>(str);
                strUnion += Obj.AttachmentId + ",";
            }
            entity.Files = strUnion;
            var user = CurrentUser.CrmUser;
            int rtState;
            try
            {
                //entity.Id = Guid.NewGuid().ToString();
                entity.RowStatus = 1;
                entity.CreatorId = user.Id;
                entity.CreateBy = user.UserName;
                entity.CreateOn = DateTime.Now;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;

                var isOk = _onlineClassCourseBll.SaveCourse(entity);
                rtState = isOk ? 0 : 1;
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


        public class Data
        {
            public string RtMsrg { get; set; }

            public string RtState { get; set; }

            public string AttachmentId { get; set; }

            public string FileAddress { get; set; }

            public string FileViewLink { get; set; }

            public string FileName { get; set; }

            public string FileReName { get; set; }

            public string FileLength { get; set; }

            public string ExtenName { get; set; }
        }

        ///// <summary>
        ///// 保存编辑课件   非事务
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //[ValidateInput(false)]
        //public JsonResult EditSaveCourse(OnlineClassCourseEntity entity)
        //{
        //    var user = CurrentUser.CrmUser;
        //    int rtState;
        //    try
        //    {
        //        var oldEntity = _onlineClassCourseBll.Get(entity.Id);
        //        oldEntity.CategoryId = entity.CategoryId;
        //        oldEntity.Title = entity.Title;
        //        oldEntity.Score = entity.Score;
        //        oldEntity.Duration = entity.Duration;
        //        oldEntity.Describle = entity.Describle;
        //        oldEntity.Contents = entity.Contents;
        //        oldEntity.Receives = entity.Receives;  //
        //        oldEntity.StartTime = entity.StartTime;
        //        oldEntity.EndTime = entity.EndTime;
        //        oldEntity.UpdateId = user.Id;
        //        oldEntity.UpdateBy = user.UserName;
        //        oldEntity.UpdateOn = DateTime.Now;
        //        //本次修改保存的人员
        //        var recevicesList = new List<string>();
        //        var receivesplit = entity.Receives.Split(',');
        //        recevicesList.AddRange(receivesplit.Where(receive => !string.IsNullOrEmpty(receive)));
        //        var oldRecevices = new OnlineClassReceiveBll().GetSearchResult(new OnlineClassReceiveEntity() { CourseId = entity.Id });
        //        var isOk = false;
        //        //循环遍历当前课程所有人员
        //        foreach (var recevice in recevicesList)
        //        {
        //            //验证当前保存人员是否已经保存,没有保存进行新增,否则将其类型更改为必修
        //            var isExist = oldRecevices.Where(x => x.UserId == recevice).ToList();
        //            if (isExist.Count <= 0)
        //            {
        //                //新增接收人
        //                OnlineClassReceiveEntity reciveEntity = new OnlineClassReceiveEntity();
        //                reciveEntity.Id = Guid.NewGuid().ToString();
        //                reciveEntity.CourseId = entity.Id;
        //                reciveEntity.UserId = recevice;
        //                reciveEntity.ReceiveType = (int)CourseQueryType.Required;
        //                reciveEntity.RowStatus = 1;
        //                isOk = new OnlineClassReceiveBll().Insert(reciveEntity);
        //                if (isOk)
        //                {
        //                    OnlineClassProgressEntity progressEntity = new OnlineClassProgressEntity();
        //                    progressEntity.Id = Guid.NewGuid().ToString();
        //                    progressEntity.CourseId = entity.Id;
        //                    progressEntity.UserId = recevice;
        //                    progressEntity.LastStudyTime = DateTime.Now;
        //                    isOk = new OnlineClassProgressBll().Insert(progressEntity);
        //                }
        //                else
        //                {
        //                    rtState = 1;
        //                    break;
        //                }
        //            }
        //            else
        //            {
        //                //必修
        //                //isTrue = new OnlineClassReceiveBll().UpdateBy(entity.Id, recevice);
        //            }
        //        }
        //        if (isOk)
        //        {
        //            isOk = _onlineClassCourseBll.EditCourse(oldEntity);
        //        }
        //        rtState = isOk ? 0 : 1;
        //    }
        //    catch (Exception)
        //    {
        //        rtState = 1;
        //    }
        //    var rtEntity = new StatusModel<DBNull>
        //    {
        //        rtData = null,
        //        rtMsrg = "成功",
        //        rtState = rtState
        //    };
        //    return Json(rtEntity, JsonRequestBehavior.AllowGet);
        //}

        /// <summary>
        /// 保存编辑课件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult EditSaveCourse(OnlineClassCourseEntity entity)
        {
            var user = CurrentUser.CrmUser;
            int rtState;
            try
            {
                var oldEntity = new OnlineClassCourseBll().Get(entity.Id);
                oldEntity.CategoryId = entity.CategoryId;
                oldEntity.Title = entity.Title;
                oldEntity.Score = entity.Score;
                oldEntity.Duration = entity.Duration;
                oldEntity.Describle = entity.Describle;
                oldEntity.Contents = entity.Contents;
                oldEntity.Receives = entity.Receives;
                oldEntity.StartTime = entity.StartTime;
                oldEntity.EndTime = entity.EndTime;
                oldEntity.UpdateId = user.Id;
                oldEntity.UpdateBy = user.UserName;
                oldEntity.UpdateOn = DateTime.Now;
                var isOk = new OnlineClassCourseBll().EditCourse(oldEntity);
                rtState = isOk ? 0 : 1;
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
        /// 公告通知管理
        /// </summary>
        /// <returns></returns>
        public ActionResult NoticeManager()
        {
            //课件学习排行
            var topCourse = _onlineClassCourseBll.StudyCount();
            //动态数据
            var dynamic = new OnlineClassStatisticBll().DynamicData();

            ViewData["TopCourse"] = topCourse;
            ViewData["Dynamic"] = dynamic;

            //ViewBag.OnLine = GetOnlineUserCount();

            return View();
        }



        /// <summary>
        /// 公告列表
        /// 添加人：周 鹏
        /// 添加时间：2014-11-16
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <returns></returns>
        public ActionResult NoticeList(string keyword, int? pageIndex)
        {
            const int pageSize = 20; //分页大小
            var models = new ComNoticeBll().GetSearchResult(new ComNoticeEntity { Title = keyword }, pageIndex ?? 1, pageSize);

            ViewBag.Kewword = keyword;
            return View("NoticeList", models);
        }

        /// <summary>
        /// 新增公告
        /// 添加人：周 鹏
        /// 添加时间：2014-11-16
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public ActionResult AddNotice()
        {
            var model = new ComNoticeEntity();
            return View(model);
        }

        /// <summary>
        /// 保存公告通知
        /// 添加人：周 鹏
        /// 添加时间：2014-11-16
        /// </summary>
        /// <param name="entity">通知实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddNotice(ComNoticeEntity entity)
        {
            var user = CurrentUser.CrmUser;
            int rtState;
            try
            {
                entity.Id = Guid.NewGuid().ToString();
                entity.IsTop = 0;
                entity.Astatus = 0;
                entity.AType = 2;
                entity.RowStatus = 1;
                entity.CreatorId = user.Id;
                entity.CreateBy = user.UserName;
                entity.CreateOn = DateTime.Now;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;

                var isOk = new ComNoticeBll().SaveNotice(entity);
                rtState = isOk ? 0 : 1;
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
        /// 帮助管理
        /// </summary>
        /// <returns></returns>
        public ActionResult HelperManager()
        {
            //课件学习排行
            var topCourse = _onlineClassCourseBll.StudyCount();
            //动态数据
            var dynamic = new OnlineClassStatisticBll().DynamicData();

            ViewData["TopCourse"] = topCourse;
            ViewData["Dynamic"] = dynamic;

            //ViewBag.OnLine = GetOnlineUserCount();
            return View();
        }

        /// <summary>
        /// 帮助列表
        /// 添加人：周 鹏
        /// 添加时间：2014-11-16
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <returns></returns>
        public ActionResult HelperList(string keyword, int? pageIndex)
        {
            const int pageSize = 20; //分页大小
            var models = new ComArticleBll().GetSearchResult(new ComArticleEntity { Title = keyword }, pageIndex ?? 1, pageSize);

            ViewBag.Kewword = keyword;
            return View("HelperList", models);
        }

        /// <summary>
        /// 新增帮助
        /// 添加人：周 鹏
        /// 添加时间：2014-11-16
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public ActionResult AddHelper()
        {
            var model = new ComArticleEntity();
            return View(model);
        }

        /// <summary>
        /// 保存帮助
        /// 添加人：周 鹏
        /// 添加时间：2014-11-16
        /// </summary>
        /// <param name="entity">通知实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddHelper(ComArticleEntity entity)
        {
            var user = CurrentUser.CrmUser;
            int rtState;
            try
            {
                entity.Id = Guid.NewGuid().ToString();
                entity.Astatus = "0";
                entity.RowStatus = 1;
                entity.CreatorId = user.Id;
                entity.CreateBy = user.UserName;
                entity.CreateOn = DateTime.Now;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;

                new ComArticleBll().Add(entity);
                rtState = 0;
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
        /// 数据删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public string Delete(string id, string type)
        {
            try
            {
                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(type)) return "Error";

                if (type.Equals("Course"))
                {
                    var bll = new OnlineClassCourseBll();
                    var entity = bll.Get(id);
                    entity.RowStatus = 0;
                    // 删除接收人  添加人：张西琼 2014-12-1
                    new OnlineClassReceiveBll().DelRecieveByCourseId(entity.Id);
                    bll.Update(entity);
                }
                else if (type.Equals("Notice"))
                {
                    var bll = new ComNoticeBll();
                    var entity = bll.Get(id);
                    entity.RowStatus = 0;
                    bll.Update(entity);
                }
                else if (type.Equals("Helper"))
                {
                    var bll = new ComArticleBll();
                    var entity = bll.Get(id);
                    entity.RowStatus = 0;
                    bll.Update(entity);
                }
                return "Ok";
            }
            catch (Exception ex)
            {
                return "Ok";
            }
        }
    }
}
