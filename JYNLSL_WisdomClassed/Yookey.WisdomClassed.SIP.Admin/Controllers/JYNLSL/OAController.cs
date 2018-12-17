using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.OA;
using Yookey.WisdomClassed.SIP.DataAccess.OA;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.OA;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.JYNLSL
{
    public class OAController : Controller
    {
        //
        // GET: /OA/

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult DocAdd()
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
        /// 获取公告通知表数据
        /// add by lpl
        /// 2018-12-14
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public string GetAllDoc(string limit,string page)
        {
            var entity = new DocumentNotificationEntity();


            var data = new DocumentNotificationBll().GetAllResult(entity);

            var pagecount = data.Count;

            //分页重写，linq实现的数据量过大效率会出现瓶颈
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



        /// <summary>
        /// 添加通告
        /// add by lpl
        /// 2018-12-17
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="sendname">发送人</param>
        /// <param name="iszd">是否置顶</param>
        /// <param name="filepath">附件路径</param>
        /// <param name="tglx">通告类型</param>
        /// <returns></returns>
        public string AddDoc(string title,string content, string sendname,string iszd,string filepath,string tglx)
        {
            DocumentNotificationEntity entity = new DocumentNotificationEntity()
            {
                Id=Guid.NewGuid().ToString(),
                Title = title,

            

                
            };

            if (new DocumentNotificationBll().Insert(entity))
            {
                return "1";
            }
            else
            {
                return "0";
            }


        }

        /// <summary>
        /// 绑定接收人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult BindUser(string id)
        {
            List<CrmUserEntity> department = new CrmUserBll().GetAllUsers();
            return Json(department, JsonRequestBehavior.AllowGet);
        }

    }
}
