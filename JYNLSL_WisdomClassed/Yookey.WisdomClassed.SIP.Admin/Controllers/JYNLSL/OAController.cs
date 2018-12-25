using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.OA;
using Yookey.WisdomClassed.SIP.DataAccess.OA;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.OA;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.JYNLSL
{
    public class OAController :BaseController
    {
        readonly CrmUserBll _crmUserBll = new CrmUserBll();//人员信息
        //
        // GET: /OA/

        public ActionResult Index()
        {
            var usersId = _crmUserBll.GetUserEntity(CurrentUser.CrmUser.Id);

            //领导权限
            var userrole = new CrmUserRoleEntity()
            {
                UserId = usersId.Id,
                RoleId = "96518d03-85c3-4ec3-a42c-ad56b9501099"
            };
            var list = new CrmUserRoleBll().GetSearchResult(userrole);

            //管理员权限
            var adminrole = new CrmUserRoleEntity()
            {
                UserId = usersId.Id,
                RoleId = "09c19ef1-77ef-4483-b7db-c09284d0deff"
            };
            var list2 = new CrmUserRoleBll().GetSearchResult(adminrole);
            ViewBag.admin = 0;
            ViewBag.leader = 0;
            if (list.Count > 0)
            {
                ViewBag.leader = 1;
            }
            if (list2.Count > 0)
            {
                ViewBag.admin = 1;
                ViewBag.leader = 1;
            }

            return View();
        }


        [ValidateInput(false)]
        public ActionResult DocAdd()
        {
            return View();
        }


        public ActionResult ChoosePerson()
        {

            return View();
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadFile()
        {
            try
            {
                var file = Request.Files[0]; //获取选中文件  
                var filecombin = file.FileName.Split('.');
                if (file == null || String.IsNullOrEmpty(file.FileName) || file.ContentLength == 0 || filecombin.Length < 2)
                {
                    return Json(new
                    {
                        fileid = 0,
                        src = "",
                        name = "",
                        msg = "上传出错 请检查文件名 或 文件内容"
                    });
                }
                //定义本地路径位置
                string local = "Upload\\Contract";
                string filePathName = string.Empty;
                string localPath = Path.Combine(HttpRuntime.AppDomainAppPath, local);

                var tmpName = Server.MapPath("~/Upload/Contract/");
                var tmp = file.FileName;
                var tmpIndex = 0;
                //判断是否存在相同文件名的文件 相同累加1继续判断
                while (System.IO.File.Exists(tmpName + tmp))
                {
                    tmp = filecombin[0] + "_" + ++tmpIndex + "." + filecombin[1];
                }

                //不带路径的最终文件名
                filePathName = tmp;

                if (!System.IO.Directory.Exists(localPath))
                    System.IO.Directory.CreateDirectory(localPath);
                string localURL = Path.Combine(local, filePathName);
                file.SaveAs(Path.Combine(localPath, filePathName));   //保存图片（文件夹）
                return Json(new
                {
                    code = 0,
                    src = localURL.Trim().Replace("\\", "|"),
                    name = Path.GetFileNameWithoutExtension(file.FileName),   // 获取文件名不含后缀名
                    msg = "上传成功"
                });
            }
            catch { }
            return Json(new
            {
               
                src = "",
                name = "",   // 获取文件名不含后缀名
                msg = "上传出错"
            });
        }

        /// <summary>
        /// 公告详情
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ContentId"></param>
        /// <returns></returns>
        public ActionResult GongGaoDetial(string Id,string ContentId)
        {
            var entity = new DocumentNotificationEntity();
            if (!string.IsNullOrEmpty(Id) && Id != "undefined")
            {
                entity.Id = Id;
            }
            else
            {
                entity.Id = ContentId;
            }


            
            var data = new DocumentNotificationBll().GetAllResult(entity);

            

            if (data.Count > 0 && ContentId != "undefined" && !string.IsNullOrEmpty(ContentId))
            {
                var users = _crmUserBll.GetUserEntity(CurrentUser.CrmUser.Id);
                //未读状态
                if (!new DocNotfPersonBall().IsRead(ContentId, users.Id))
                {
                    //执行事务
                    new DocNotfPersonBall().UpdateDocState(ContentId, users.Id);
                }

            }

            return View(data[0]);
        }


        public ActionResult JieShouDetial()
        {
            return View();
        }

        /// <summary>
        /// 获取公告通知表数据
        /// add by lpl
        /// 2018-12-14
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public string GetAllDoc(string limit,string page,string Title,string datafw,string Gglx)
        {
            #region 根据当前用户ID,取出属于当前用户的通告列表
            ////取当前用户
            //var usersId = _crmUserBll.GetUserEntity(CurrentUser.CrmUser.Id);

            ////搜索当前用户接受到的所有通知
            //var personentity = new DocNotfPersonEntity()
            //{
            //    Pid = usersId.Id
            //};
            //var person = new DocNotfPersonBall().search(personentity);

            ////拼接字符串，用来通知公告表筛选
            //string jieshouGuid = "";
            //foreach (DocNotfPersonEntity doc in person)
            //{

            //    jieshouGuid +=  "'" + doc.ContentId + "',";
            //}

            //jieshouGuid = jieshouGuid.TrimEnd(',');
            ////jieshouGuid = jieshouGuid.TrimEnd('\'');
            #endregion


            var usersId = _crmUserBll.GetUserEntity(CurrentUser.CrmUser.Id);
            var entity = new DocumentNotificationEntity()
            {
                Title=Title,
                Category = Gglx
                
            };

            var personentity = new DocNotfPersonEntity()
            {
                Title = Title,
                Category = Gglx,
                Pid = usersId.Id
            };

            var data = new List<DocumentNotificationEntity>();
            var data2 = new List<DocNotfPersonEntity>();
            //领导权限
            var userrole = new CrmUserRoleEntity()
            {
                UserId = usersId.Id,
                RoleId = "96518d03-85c3-4ec3-a42c-ad56b9501099"
            };
            var list = new CrmUserRoleBll().GetSearchResult(userrole);

            //管理员权限
            var adminrole = new CrmUserRoleEntity()
            {
                UserId = usersId.Id,
                RoleId = "09c19ef1-77ef-4483-b7db-c09284d0deff"
            };
            var list2 = new CrmUserRoleBll().GetSearchResult(adminrole);
            //搜索条件

            //是管理员或者领导
            if (list.Count > 0 || list2.Count > 0)
            {
                //不查询接受人，全部可以看到
                data = new DocumentNotificationBll().SearchQuery(entity, datafw);
                var pagecount = data.Count;

                //分页有空重写，linq实现的数据量过大效率会出现瓶颈
                data = data.Skip((Convert.ToInt32(page) - 1) * Convert.ToInt32(limit)).Take(Convert.ToInt32(limit)).ToList();

                var result = new LayTableModel<DocumentNotificationEntity>
                {
                    code = 0,
                    msg = "成功",
                    count = pagecount,
                    data = data
                };

                return JsonConvert.SerializeObject(result);
            }
            else
            {


                //如果不是领导，而是接收人，则需要重新绑定数据源

                data2 = new DocNotfPersonBall().search(personentity, datafw);
                //分页有空重写，linq实现的数据量过大效率会出现瓶颈
                data2 = data2.Skip((Convert.ToInt32(page) - 1) * Convert.ToInt32(limit)).Take(Convert.ToInt32(limit)).ToList();
                var pagecount = data2.Count;
                var result = new LayTableModel<DocNotfPersonEntity>
                {
                    code = 0,
                    msg = "成功",
                    count = pagecount,
                    data = data2
                };
                string temp = JsonConvert.SerializeObject(result);
                return JsonConvert.SerializeObject(result);
            }

          




 

        }


        public string GetJieShouQk(string Id, string limit, string page)
        {
            var entity = new DocNotfPersonEntity()
            {
                ContentId = Id
            };

            var data = new DocNotfPersonBall().search(entity);
            var pagecount = data.Count;
            //分页有空重写，linq实现的数据量过大效率会出现瓶颈
            data = data.Skip((Convert.ToInt32(page) - 1) * Convert.ToInt32(limit)).Take(Convert.ToInt32(limit)).ToList();

            var result = new LayTableModel<DocNotfPersonEntity>
            {
                code = 0,
                msg = "成功",
                count = pagecount,
                data = data
            };

            return JsonConvert.SerializeObject(result);
        }


        /// <summary>
        /// 绑定通告类型
        /// </summary>
        /// <returns></returns>
        public string BindTGLX()
        {
            var data = new ComResourceBll().GetResourcesByParentId("0057");
            return JsonConvert.SerializeObject(data);
        }


        /// <summary>
        /// 添加通告
        /// add by lpl
        /// 2018-12-17
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="sendname">接收人</param>
        /// <param name="iszd">是否置顶</param>
        /// <param name="filepath">附件路径</param>
        /// <param name="tglx">通告类型</param>
        /// <returns></returns>
        
        [ValidateInput(false)]
        public string AddDoc(string title,string content, string sendname,string iszd,string filepath,string tglx)
        {
            string[] sendArray = sendname.Split(',');
            string Id = Guid.NewGuid().ToString();
            DocumentNotificationEntity entity = new DocumentNotificationEntity()
            {
                Id = Id,
                Title = title,
                Publisher = CurrentUser.CrmUser.UserName,
                ReleaseTime = NowDate,
                Iszd = iszd,
                GGContent = content,
                Sendname = sendname,
                FilePath = filepath,
                Category = tglx,
                JieShouAllCount = sendArray.Length,
                JieShouCount = 0,

                //公共字段
                CreateBy = CurrentUser.CrmUser.UserName,
                CreateOn = NowDate,
                CreatorId = CurrentUser.CrmUser.Id,
                UpdateBy = CurrentUser.CrmUser.UserName,
                UpdateOn = NowDate,
                UpdateId = CurrentUser.CrmUser.Id

            };

            if (new DocumentNotificationBll().Insert(entity))
            {
            

                List<DocNotfPersonEntity> list = new List<DocNotfPersonEntity>();

                for (int i = 0; i < sendArray.Length; i++)
                {
                    DocNotfPersonEntity docNotfPerson = new DocNotfPersonEntity()
                    {
                        Pid = sendArray[i],
                        IsJS = "0",//默认不接受
                        Title = entity.Title,
                        Publisher = entity.Publisher,
                        ReleaseTime = entity.ReleaseTime,
                        Category = entity.Category,
                        //公共字段
                        RowStatus = 1,
                        CreateBy = CurrentUser.CrmUser.UserName,
                        CreateOn = NowDate,
                        CreatorId = CurrentUser.CrmUser.Id,
                        UpdateBy = CurrentUser.CrmUser.UserName,
                        UpdateOn = NowDate,
                        UpdateId = CurrentUser.CrmUser.Id,
                        ContentId = Id



                        
                        
                    };
                    list.Add(docNotfPerson);
                }

                //批量插入人员,后期把所有内容都写入都事务中去处理，防止插入数据失败，方便回滚
                new DocNotfPersonBall().InsertNotfPerson(list);

                return "1";
            }
            else
            {
                return "0";
            }




        }

        /// <summary>
        /// 绑定接收人，MiNiUi版本，为了兼容IE8
        /// </summary>
        /// <returns></returns>
        public string BindUser2()
        {
            List<CrmUserEntity> user = new CrmUserBll().GetUser();
            List<CrmDepartmentEntity> department = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity()
            {
                CompanyId = user[0].CompanyId,
            });

            string josn = "[";
            for (int i = 0; i < department.Count; i++)
            {
                var userjosn = from u in user where u.DepartmentId == department[i].Id select u;
   
                josn += "{ id: \""+ department[i].Id + "\", text: \""+ department[i].FullName + "\"},";
                foreach (var groupuser in userjosn)
                {


                    josn += "{ id: \"" + groupuser.Id + "\", text: \"" + groupuser.RealName + "\", pid: \""+ department[i].Id + "\"},";
                }

            }
            josn = josn.TrimEnd(',');
            josn += "]";

    
            return josn;
        }

        /// <summary>
        /// 绑定接收人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string BindUser(string id)
        {
            List<CrmUserEntity> user = new CrmUserBll().GetUser();


            List<CrmDepartmentEntity> department = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity()
            {
                CompanyId = user[0].CompanyId,
            });

            string josn = "[";
        
            for (int i = 0; i < department.Count; i++)
            {
                var userjosn = from u in user where u.DepartmentId == department[i].Id select u;
                josn += "{ \"name\": \"" + department[i].FullName + "\", \"type\": \"optgroup\"},";
             
                foreach (var groupuser in userjosn)
                {
                
                    josn += "{ \"name\":\"" + groupuser.RealName + "\",\"value\":\"" + groupuser.Id + "\",\"selected\":\"\",\"disabled\":\"\"},";
                }

            }

            josn = josn.TrimEnd(',');
            josn += "]"; 

            return josn;
        }

    }
}
