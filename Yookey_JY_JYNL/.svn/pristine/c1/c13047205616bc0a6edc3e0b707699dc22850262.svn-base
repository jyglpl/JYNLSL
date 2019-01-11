using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Evidence;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Evidence;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Evidence
{
    public class EvidenceController : BaseController
    {
        //
        // GET: /Evidence/
        readonly CrmDepartmentBll _crmDeptBll = new CrmDepartmentBll();//部门信息
        readonly CrmUserBll _crmUserBll = new CrmUserBll();//人员信息
        readonly ProofAttachBll _proofAttachBll = new ProofAttachBll();//执法记录附件
        readonly ComResourceBll _comresourceBll = new ComResourceBll();//字典

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexPage()
        {
            return View();
        }

        /// <summary>
        /// 视频播放
        /// </summary>
        /// <returns></returns>
        public ActionResult VideoPlay(string sid, string height, string width)
        {
            ViewBag.sid = sid;
            ViewData["height"] = height;
            ViewData["width"] = width;
            return View();
        }

        /// <summary>
        /// 音频播放
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public ActionResult VoicePlay(string sid)
        {
            ViewBag.sid = sid;
            return View();
        }

        /// <summary>
        /// 图片播放
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public ActionResult ShowPic(string sid)
        {
            ViewBag.sid = sid;
            return View();
        }

        /// <summary>
        /// 左边树信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string QueryTreeviewDept()
        {
            try
            {
                var user = "";
                //strb.Append("<ul>");
                //if (data.Any())
                //{
                //    //var attachUsers = _proofAttachBll.GetSearchResult(new ProofAttachEntity() { USERID = "", ISUPFISNISH = "1" });
                //    for (int i = 0; i < data.Count; i++)
                //    {
                //        var deptid = data[i].Id.ToString();
                //        var appendhtml = "<li><a style=\"padding-right: 28px;\"href=\"javascript:$.Evidence.leftTree('" + 1 + "','" + deptid + "')\">" + data[i].Name.ToString() + "</a>";

                //        if (data[i].Name.ToString().IndexOf("局", System.StringComparison.Ordinal) >= 0)
                //        {
                //            //中队
                //            var detachment = _sysDeptBll.GetSearchResult(new SysDeptEntity() { ParentId = deptid });
                //            if (detachment.Any())
                //            {
                //                appendhtml += "<ul style=\"top: 0px; display: none; visibility: visible;\">";
                //                foreach (var childItem in detachment)
                //                {
                //                    deptid = childItem.Id;

                //                    appendhtml += "<li><a href=\"javascript:$.Evidence.leftTree('" + 2 + "','" + deptid + "')\">" + childItem.Name + "</a>";

                //                    //用户
                //                    var udt = _sysUserBll.GetSearchResult(new SysUserEntity() { MainOrganizationId = deptid });  //中队下面的所有用户信息
                //                    if (udt.Any())
                //                    {
                //                        appendhtml += "<ul style=\"top: 0px; display: none; visibility: visible;\">";
                //                        foreach (var udtItem in udt)
                //                        {
                //                            var uid = udtItem.Id;

                //                            var uname = udtItem.Name;
                //                            uname = uname.PadRight(8, '　');
                //                            //采集证据条数
                //                            var ccount = _proofAttachBll.GetSearchResult(new ProofAttachEntity() { USERID = uid, ISUPFISNISH = "1" }).Count;
                //                            uname = uname + (ccount > 0 ? "（" + ccount + "）" : "");

                //                            appendhtml += "<li><a href=\"javascript:$.Evidence.leftTree('" + 3 + "','" + uid + "')\">" + uname + "</a>";

                //                            if (ccount > 0)
                //                            {
                //                                appendhtml += AppendUploadUsers(uid);
                //                            }

                //                            appendhtml += "</li>";
                //                        }
                //                        appendhtml += "</ul>";
                //                    }
                //                    appendhtml += "</li>";
                //                }
                //                appendhtml += "</ul>";
                //            }
                //        }
                //        appendhtml += "</li>";
                //        strb.Append(appendhtml);
                //    }
                //}
                //strb.Append("</ul>");
                //var data = _sysDeptBll.GetSearchResult(new SysDeptEntity() { Id = "ce59011a-1289-40ca-a398-79da6c1fccb6" });
                //var companys = new CrmCompanyBll().GetAllCompany();
                //var dataAll = companys.Where(x => x.ParentId == "0").ToList();
                var strb = new StringBuilder("");

                var udtList = new CrmUserBll().GetAllUsers(new CrmUserEntity());
                var proofList = _proofAttachBll.GetSearchResult(new ProofAttachEntity());

                //if (dataAll.Any())
                //{
                //strb.Append("<li>");
                //strb.Append("<div class=\"teamName\"><img src=\"/Librarys/evidence/image/bumen.png\" alt=''><p>" + dataAll[0].FullName + "</p></div>");

                var data = new CrmCompanyBll().GetAllEnforcementUnit();


                if (data.Any())
                {
                    strb.Append("<ul class=\"teamList\">");
                    for (int i = 0; i < data.Count; i++)
                    {
                        strb.Append("<li class='List_li'>");

                        var deptid = data[i].Id.ToString();
                        var appendhtml = "<div class='teamName' onclick=\"javascript:$.Evidence.leftTree('" + 1 + "','" + deptid + "')\"><img src='/Librarys/evidence/image/bumen.png' alt=''><p>" + data[i].ShortName.ToString() + "</p></div>";

                        //部门
                        var detachment = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity() { CompanyId = deptid });
                        if (detachment.Any())
                        {
                            appendhtml += "<ul class='none'>";
                            foreach (var childItem in detachment)
                            {
                                deptid = childItem.Id;

                                appendhtml += "<li class='Name_li'><div class='teamName' onclick=\"javascript:$.Evidence.leftTree('" + 2 + "','" + deptid + "')\"><img src='/Librarys/evidence/image/xiaji1.png' alt=''><p>" + childItem.FullName + "</p></div>";

                                //人员
                                //var udt = udtList.Where(p => p.DepartmentId == deptid).ToList();
                                //if (udt.Any())
                                //{
                                //    appendhtml += "<ul class='name none'>";
                                //    foreach (var udtItem in udt)
                                //    {
                                //        var uid = udtItem.Id;

                                //        var uname = udtItem.RealName;
                                //        uname = uname.PadRight(8, '　');
                                //        //采集证据条数
                                //        //var ccount = _proofAttachBll.GetSearchResult(new ProofAttachEntity() { USERID = uid, ISUPFISNISH = "1" }).Count;
                                //        var ccount = proofList.Where(p => p.USERID == uid && p.ISUPFISNISH == "1").Count();
                                //        uname = uname + (ccount > 0 ? "（" + ccount + "）" : "");

                                //        appendhtml += "<li onclick=\"javascript:$.Evidence.leftTree('" + 3 + "','" + uid + "')\">" + uname + "";
                                //        appendhtml += "</li>";
                                //    }
                                //    appendhtml += "</ul>";
                                //}
                                appendhtml += "</li>";
                            }
                            appendhtml += "</ul>";
                        }
                        strb.Append(appendhtml);

                        strb.Append("</li>");
                    }
                    strb.Append("</ul>");
                }


                //strb.Append("</li>");
                //}
                return strb.ToString();

            }
            catch (Exception ex)
            {
                //return "加载数据出现异常...";
                return ex.Message;
            }
        }

        /// <summary>
        /// 根据采集人ID获取上传人姓名及上传数量
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string AppendUploadUsers(string userId)
        {
            var users = _proofAttachBll.GetSearchResult(new ProofAttachEntity() { USERID = userId, ISUPFISNISH = "1" });

            var appendhtml = new StringBuilder("");
            if (users.Any())
            {
                appendhtml.Append("<ul style=\"top: 0px; display: none; visibility: visible;\">");
                foreach (var row in users)
                {
                    var uid = row.USERID;
                    //var user = _sysUserBll.GetSearchResult(new SysUserEntity() { Id = uid });
                    var user = "";
                    var userName = "";
                    if (user.Any())
                    {
                        //userName = user[0].Name;
                        userName = userName.PadRight(8, '　');
                        userName = userName + "（" + users.Count + "）";
                    }
                    appendhtml.Append("<li><a href=\"javascript:$.Evidence.leftTree('" + 4 + "','" + uid + "')\">" + userName + "</a></li>");
                }
                appendhtml.Append("</ul>");
            }
            return appendhtml.ToString();
        }

        /// <summary>
        /// 电子证据信息查询
        /// </summary>
        /// <param name="context"></param>
        /// <return>json 格式数据</return>
        public string QueryEvidence(string keyvalue, string filename, string uname, string uid, string deceiveno, string deptid,
                    string detachment, string deptidsecond, string detachmentsecond, string filetype, string classno, string starttime,
                    string endtime, string cuid, string pagetype, int pageindex = 0, int pagesize = 0)
        {
            try
            {
                const string json = "\"sysid\":\"{0}\",\"uname\":\"{1}\",\"filename\":\"{2}\",\"update\":\"{3}\",\"filetype\":\"{4}\",\"datasource\":\"{5}\",\"haddress\":\"{6}\",\"filethumbnail\":\"{7}\",\"isnew\":\"{8}\",\"CTime\":\"{9}\",\"CUname\":\"{10}\",\"CRemark\":\"{11}\",\"CAddress\":\"{12}\"";

                var fileViewAddress = ConfigurationManager.AppSettings["FileViewAddress"];

                var totalrecords = 0;  //总条数
                var evidencedt = _proofAttachBll.GetSearchResult(new ProofAttachEntity() { ISUPFISNISH = "1", KeyWords = keyvalue, FILENAME = filename, USERID = uid, DEVICENO = deceiveno, FILETYPE = filetype, StartDate = starttime, EndDate = endtime });
                totalrecords = evidencedt.Count;
                if (pageindex != 0 && pagesize != 0)
                {
                    List<ProofAttachEntity> lst = new List<ProofAttachEntity>();
                    int AllCount = pageindex * pagesize;
                    if (AllCount > totalrecords)
                    {
                        AllCount = totalrecords;
                    }
                    for (int i = (pageindex * pagesize - pagesize); i < AllCount; i++)
                    {
                        lst.Add(evidencedt[i]);
                    }
                    evidencedt = lst;
                }
                //根据机构筛选
                if (!string.IsNullOrEmpty(deptidsecond))
                {
                    if (evidencedt.Any())
                    {
                        for (int i = evidencedt.Count - 1; i >= 0; i--)
                        {
                            if (!string.IsNullOrEmpty(evidencedt[i].USERID))
                            {
                                var userList = new CrmUserBll().GetAllUsers(new CrmUserEntity() { Id = evidencedt[i].USERID });
                                if (userList.Any())
                                {
                                    if (userList[0].CompanyId != deptidsecond)
                                    {
                                        evidencedt.RemoveAt(i);
                                    }
                                }
                                else
                                {
                                    evidencedt.RemoveAt(i);
                                }
                            }
                            else
                            {
                                evidencedt.RemoveAt(i);
                            }
                        }
                    }
                }
                //根据部门筛选
                if (!string.IsNullOrEmpty(detachmentsecond))
                {
                    if (evidencedt.Any())
                    {
                        for (int i = evidencedt.Count - 1; i >= 0; i--)
                        {
                            if (!string.IsNullOrEmpty(evidencedt[i].USERID))
                            {
                                var userList = new CrmUserBll().GetAllUsers(new CrmUserEntity() { Id = evidencedt[i].USERID });
                                if (userList.Any())
                                {
                                    if (userList[0].DepartmentId != detachmentsecond)
                                    {
                                        evidencedt.RemoveAt(i);
                                    }
                                }
                                else
                                {
                                    evidencedt.RemoveAt(i);
                                }
                            }
                            else
                            {
                                evidencedt.RemoveAt(i);
                            }
                        }
                    }
                }
                var sb = new StringBuilder();

                var Now = DateTime.Now.ToString("yyyy-MM-dd");
                sb.Append("{\"rowscount\":" + totalrecords + ",\"rows\":[");
                var list = new List<string>();  //存放数据集合
                if (evidencedt.Any())
                {
                    list.AddRange(from row in evidencedt
                                  let sysId = row.SYS_ID
                                  let dtUname = new CrmUserBll().GetAllUsers(new CrmUserEntity() { Id = row.USERID }).Count > 0 ? new CrmUserBll().GetAllUsers(new CrmUserEntity() { Id = row.USERID })[0].RealName : ""
                                  let dtFilename =
                                      row.FILENAME.Length > 12
                                          ? row.FILENAME.Substring(0, 6) + "..." +
                                            row.FILENAME.Substring(row.FILENAME.Length - 6)
                                          : row.FILENAME
                                  let updata = Convert.ToDateTime(row.CREATEDATE).ToString("yyyy-MM-dd")
                                  let dtFiletype = row.FILETYPE
                                  let datasource = row.DATASOURCE
                                  let haddress = fileViewAddress + row.FILEADDRESS
                                  let filethumbnail = row.FILETHUMBNAIL
                                  let isnew = Convert.ToDateTime(row.CREATEDATE).ToString("yyyy-MM-dd").CompareTo(Now) == 0 ? 1 : 0 //0,1
                                  let ctime = row.CTIME
                                  let cuname = new CrmUserBll().GetAllUsers(new CrmUserEntity() { Id = row.USERID }).Count > 0 ? new CrmUserBll().GetAllUsers(new CrmUserEntity() { Id = row.USERID })[0].RealName : ""
                                  //let remark = row.REMARK.Length > 11
                                  //        ? row.REMARK.Substring(0, 6) + "..." +
                                  //          row.REMARK.Substring(row.REMARK.Length - 6)
                                  //        : row.REMARK
                                  let remark = row.REMARK
                                  //let address = row.ADDRESS.Length > 12
                                  //        ? row.ADDRESS.Substring(0, 6) + "..." +
                                  //          row.ADDRESS.Substring(row.ADDRESS.Length - 6)
                                  //        : row.ADDRESS.ToString()
                                  let address = row.ADDRESS.ToString()
                                  select
                                      "{" +
                                      string.Format(json, sysId, dtUname, dtFilename, updata, dtFiletype, datasource,
                                                    haddress, filethumbnail, isnew, ctime, cuname, remark, address) + "}");
                }
                sb.Append(string.Format("{0}", string.Join(",", list.ToArray())));
                sb.Append("]}");
                return sb.ToString();
            }
            catch
            {
                return "{\"total\":0,\"rows\":[]}";
            }
        }


        /// <summary>
        /// 删除电子证据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string DeleteEvidence(string type, string sid)
        {
            try
            {
                if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(sid))
                {
                    return "error";
                }
                else
                {
                    if (type == "1" || type == "2")   //执行删除电子证据
                    {
                        var isOk = _proofAttachBll.DeleteEvidence(sid, type);
                        //if (type == "2" && isOk)
                        //{
                        //    //执行删除本地文件（需要调用FTP进行跨服务器删除文件）
                        //    var evidenceInfoDt = _infPunish.GetEvidenceInfo(sid);
                        //    if (evidenceInfoDt != null && evidenceInfoDt.Rows.Count > 0)
                        //    {
                        //        //电子证据基础信息
                        //        var ftpip = evidenceInfoDt.Rows[0]["ftpip"].ToString();  //ftp ip
                        //        var ftpusername = evidenceInfoDt.Rows[0]["ftpusername"].ToString();    //ftp name  
                        //        var ftpuserpwd = evidenceInfoDt.Rows[0]["ftpuserpwd"].ToString();      //ftp pwd
                        //        var filetype = evidenceInfoDt.Rows[0]["filetype"].ToString();          //电子证据类型
                        //        var fileaddress = evidenceInfoDt.Rows[0]["fileaddress"].ToString();    //文件夹相对路径
                        //        var filethumbnail = evidenceInfoDt.Rows[0]["filethumbnail"].ToString();//缩略图、音频转换成文件名称
                        //        var filerename = evidenceInfoDt.Rows[0]["filerename"].ToString();      //原始文件名称

                        //        var filelog = filerename + ".log";  //日志文件

                        //        //调用FTP删除（原始文件、缩略图（转换后）文件、log文件）

                        //        var ftp = new FtpUpload.FtpUpDown(ftpip + "/" + fileaddress, ftpusername, ftpuserpwd);
                        //        ftp.DeleteFileName(filethumbnail);  //删除缩略文件
                        //        ftp.DeleteFileName(filelog);        //删除上传日志文件
                        //        ftp.DeleteFileName(filerename);     //删除原文件

                        //        return "true";
                        //    }

                        //    return "error";
                        //}
                        return isOk ? "true" : "false";
                    }
                    else
                    {
                        //撤销删除电子证据
                        //return _infPunish.RevocationEvidence(sid) ? "true" : "false";
                        return "";
                    }
                }
            }
            catch
            {
                return "error";
            }
        }


        /// <summary>
        /// 查看视频详细信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string VideoInfo(string sid, string type)
        {
            const string json = "\"playurl\":\"{0}\",\"filename\":\"{1}\",\"filelength\":\"{2}\",\"uname\":\"{3}\",\"update\":\"{4}\",\"classno\":\"{5}\",\"deptname\":\"{6}\",\"fbreak\":\"{7}\",\"address\":\"{8}\"";
            try
            {
                if (!string.IsNullOrEmpty(sid))
                {
                    var infodt = _proofAttachBll.GetSearchResult(new ProofAttachEntity() { SYS_ID = sid });
                    var sb = new StringBuilder("");
                    var list = new List<string>();
                    if (infodt.Any())
                    {
                        var fileViewAddress = ConfigurationManager.AppSettings["FileViewAddress"];

                        foreach (var row in infodt)
                        {
                            var sourcename = row.FILETYPE == "2" ? row.FILETHUMBNAIL : row.FILERENAME;
                            var playurl = fileViewAddress + "/" + row.FILEADDRESS + "/" + sourcename;  //播放地址
                            var filename = row.FILENAME;
                            var filelength = Math.Round(float.Parse(row.FILELENGTH.ToString()) / 1024 / 1024, 2) + "M";
                            var uname = "";
                            var update = row.CREATEDATE;
                            var classno = "";
                            var deptname = "";
                            var detachment = "";
                            if (detachment.ToString() != "")
                            {
                                deptname += "|" + detachment;
                            }
                            var cbreak = row.REMARK;
                            var address = row.ADDRESS;

                            list.Add("{" + string.Format(json, playurl, filename, filelength, uname, update, classno, deptname, cbreak, address) + "}");
                        }
                    }
                    sb.Append(type == "3"
                                  ? string.Format("[{0}]", string.Join(",", list.ToArray()))
                                  : string.Format("{0}", string.Join(",", list.ToArray())));

                    return sb.ToString();
                }
            }
            catch
            {
                return "{}";
            }
            return "{}";
        }

        /// <summary>
        /// 请求分页脚本
        /// </summary>
        /// <param name="totalRecords"></param>
        /// <param name="pagesize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public string EvidenceQuery(int totalRecords, int pageIndex, int pageSize)
        {
            #region 拼接分页
            var tableHtml = new StringBuilder("");
            var pagecount = (int)Math.Ceiling((double)totalRecords / pageSize);  //总页数
            if (pagecount > 1)
            {
                tableHtml.Append(" <button class=\"btn-primary btn\" type=\"button\" style=\"position: absolute; top: 20px; left: 20px\" onclick=\"javascript:$.Evidence.DeleteAll();\">批量删除</button>");
                tableHtml.Append("<div class=\"pagesDown\">");
                tableHtml.Append("<ul>");

                int pIndex = pageIndex;

                if (pIndex == 1 && pagecount > 1) //如果是第一页，“下一页”
                {
                    if (pagecount <= 6)
                    {
                        int i = 1;
                        while (i <= pagecount)
                        {
                            //分页页码处
                            tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{2}')\"{0}>{1}</a></li>",
                                                   i == pIndex ? "class=current" : "", i, i);
                            i++;
                        }
                    }
                    else
                    {
                        int i = 1;
                        while (i <= 5)
                        {
                            //分页页码处
                            tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{2}')\"{0}>{1}</a></li>",
                                                   i == pIndex ? "class=current" : "", i, i);
                            i++;
                        }

                        tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{0}')\">...</a></li>", 6);
                        tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{1}')\">{0}</a></li>", pagecount,
                                               pagecount);
                    }

                    //下一页跳转以及指定页面
                    tableHtml.AppendFormat(
                        "<li class=\"pagesDown-pos\"><a href=\"javascript:$.Evidence.gotopage('{0}')\" class=\"next-page\">下一页</a> <a href=\"javascript:void(0);\" onclick=\"$.Evidence.shownextpagego()\" class=\"nextpagego\"><em>一</em></a>",
                        pIndex + 1);
                    tableHtml.Append("<div class=\"nextpagego-box\">");
                    tableHtml.Append(
                        "去<input type=\"text\" name=\"goto\"");
                    tableHtml.Append("onchange=\"\" onkeypress=\"\" />页");
                    tableHtml.AppendFormat(
                        "<button type=\"button\" class=\"nextpagego-btn\" name=\"go\" onclick=\"javascript:$.Evidence.gotopageN({0})\"></button></div></li>",
                        pagecount);
                }
                else if (pIndex == pagecount) //如果是最后一页，“首页”、“上一页”
                {
                    tableHtml.Append("<li><a class=\"pre-page\" href=\"javascript:$.Evidence.gotopage('1')\">首  页</a></li>");
                    tableHtml.AppendFormat(
                        "<li><a class=\"pre-page\" href=\"javascript:$.Evidence.gotopage('{0}')\">上一页</a></li>", pagecount - 1);
                    if (pagecount > 6)
                    {
                        int i = pagecount - 6;
                        while (i < pagecount - 1)
                        {
                            //分页页码处
                            tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{2}')\"{0}>{1}</a></li>",
                                                   i == pIndex ? "class=current" : "", i, i);
                            i++;
                        }
                        tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{0}')\">...</a></li>", pagecount - 1);

                        tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{2}')\"{0}>{1}</a></li>",
                                               pagecount == pIndex ? "class=current" : "", pagecount, pIndex);
                    }
                    else
                    {
                        int i = 1;
                        while (i <= pagecount)
                        {
                            //分页页码处
                            tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{2}')\"{0}>{1}</a></li>",
                                                   i == pIndex ? "class=current" : "", i, i);
                            i++;
                        }
                    }
                }
                else if (pIndex == pagecount - 1) //如果是倒数第二页
                {
                    //上一页
                    tableHtml.AppendFormat(
                        "<li><a class=\"pre-page\" href=\"javascript:$.Evidence.gotopage('{0}')\">上一页</a></li>", pIndex - 1);
                    if (pagecount <= 6)
                    {
                        int i = 1;
                        while (i <= pagecount)
                        {
                            //分页页码处
                            tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{2}')\"{0}>{1}</a></li>",
                                                   i == pIndex ? "class=current" : "", i, i);
                            i++;
                        }
                    }
                    else
                    {
                        int i = pIndex - 4;
                        while (i <= pIndex)
                        {
                            //分页页码处
                            tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{2}')\"{0}>{1}</a></li>",
                                                   i == pIndex ? "class=current" : "", i, i);
                            i++;
                        }
                        tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{1}')\">{0}</a></li>", pagecount,
                                               pagecount);
                    }
                    //下一页跳转以及指定页面
                    tableHtml.AppendFormat(
                        "<li class=\"pagesDown-pos\"><a href=\"javascript:$.Evidence.gotopage('{0}')\" class=\"next-page\">下一页</a> <a href=\"javascript:void(0);\" onclick=\"$.Evidence.shownextpagego()\" class=\"nextpagego\"><em>一</em></a>",
                        pIndex + 1);
                    tableHtml.Append("<div class=\"nextpagego-box\">");
                    tableHtml.Append(
                        "去<input type=\"text\" name=\"goto\"");
                    tableHtml.Append("onchange=\"\" onkeypress=\"\" />页");
                    tableHtml.AppendFormat(
                        "<button type=\"button\" class=\"nextpagego-btn\" name=\"go\" onclick=\"javascript:$.Evidence.gotopageN({0})\"></button></div></li>",
                        pagecount);
                }

                else if (pIndex < pagecount) //如果不是最后一页，“上一页”、“下一页”
                {
                    //上一页
                    tableHtml.AppendFormat(
                        "<li><a class=\"pre-page\" href=\"javascript:$.Evidence.gotopage('{0}')\">上一页</a></li>", pIndex - 1);
                    if (pagecount <= 6)
                    {
                        int i = 1;
                        while (i <= pagecount)
                        {
                            //分页页码处
                            tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{2}')\"{0}>{1}</a></li>",
                                                   i == pIndex ? "class=current" : "", i, i);
                            i++;
                        }
                    }
                    else
                    {
                        if (pIndex < 6)
                        {
                            int i = 1;
                            while (i <= 5)
                            {
                                //分页页码处
                                tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{2}')\"{0}>{1}</a></li>",
                                                       i == pIndex ? "class=current" : "", i, i);
                                i++;
                            }
                            tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{0}')\">...</a></li>", 6);
                        }
                        else
                        {
                            int i = pIndex - 4;
                            while (i <= pIndex)
                            {
                                //分页页码处
                                tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{2}')\"{0}>{1}</a></li>",
                                                       i == pIndex ? "class=current" : "", i, i);
                                i++;
                            }

                            tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{0}')\">...</a></li>", pIndex + 1);
                        }
                        tableHtml.AppendFormat("<li><a href=\"javascript:$.Evidence.gotopage('{0}')\">{0}</a></li>", pagecount);
                    }
                    //下一页跳转以及指定页面
                    tableHtml.AppendFormat(
                        "<li class=\"pagesDown-pos\"><a href=\"javascript:$.Evidence.gotopage('{0}')\" class=\"next-page\">下一页</a> <a href=\"javascript:void(0);\" onclick=\"$.Evidence.shownextpagego()\" class=\"nextpagego\"><em>一</em></a>",
                        pIndex + 1);
                    tableHtml.Append("<div class=\"nextpagego-box\">");
                    tableHtml.Append(
                        "去<input type=\"text\" name=\"goto\"");
                    tableHtml.Append("onchange=\"\" onkeypress=\"\" />页");
                    tableHtml.AppendFormat(
                        "<button type=\"button\" class=\"nextpagego-btn\" name=\"go\" onclick=\"javascript:$.Evidence.gotopageN({0})\"></button></div></li>",
                        pagecount);
                }

                tableHtml.Append("<li class=\"clearfix\"></li>");
                tableHtml.Append("</ul> ");
                tableHtml.Append("</div>");
                //tableHtml.Append("<div class=\"clearfix\"></div>");
                //tableHtml.Append("</div>");
            }
            else  //如果没有页数
            {
                //tableHtml.Append("<div class=\"applay-select\"><div class=\"pagesDown\"><ul><li class=\"clearfix\"></li></ul> </div><div class=\"clearfix\"></div>");
            }
            return tableHtml.ToString();

            #endregion 拼接分页

        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(string Id)
        {
            var users = _crmUserBll.GetUserEntity(CurrentUser.CrmUser.Id);
            List<CrmUserEntity> userList = _crmUserBll.GetUsersByDepartment(users.DepartmentId);
            userList.Insert(0, new CrmUserEntity { Id = "", RealName = "--请选择--" });
            ViewData["Users"] = new SelectList(userList, "Id", "RealName", "");

            ViewData["oneLevel"] = _comresourceBll.GetSearchResult(new ComResourceEntity() { ParentId = "0096" });
            ViewData["twoLevel"] = _comresourceBll.GetSearchResult(new ComResourceEntity() { ParentId = "0097" });

            var entity = new ProofAttachEntity();
            if (!string.IsNullOrEmpty(Id))
            {
                var infodt = _proofAttachBll.GetSearchResult(new ProofAttachEntity() { SYS_ID = Id });
                if (infodt.Any())
                {
                    entity = infodt[0];
                }
            }
            return View(entity);
        }

        /// <summary>
        /// 更新电子证据信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public JsonResult UpdateData(ProofAttachEntity entity, FormCollection collection)
        {
            var isOk = false;
            try
            {
                if (!string.IsNullOrEmpty(entity.SYS_ID)) //新增
                {
                    isOk = _proofAttachBll.UpdateEvidence(entity);
                }
                else
                {
                    isOk = false;
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<object>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
