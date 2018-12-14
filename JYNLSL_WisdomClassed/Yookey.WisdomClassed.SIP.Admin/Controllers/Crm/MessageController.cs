using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Admin.Models;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Crm
{
    public class MessageController : BaseController
    {

        /// <summary>
        /// 消息管理
        /// 添加人：胡 耀 锋
        /// 添加时间：2014-04-08
        /// </summary>
        /// <returns></returns>
        public ActionResult Bottom(string typeid, string titles, string state = "0", int page = 1, int pageSize = 15)
        {
            try
            {
                var search = new CrmMessageWorkEntity() { ActionerID = CurrentUser.CrmUser.Id, UserName = CurrentUser.CrmUser.LoginName, RsKey = typeid, Titles = titles };
                var messages = new CrmMessageWorkBll().GetSearchResult(search, pageSize, page);
                return View(messages);
            }
            catch (Exception)
            {
                return View();
            }
        }

        /// <summary>
        /// 获取消息状态数据
        /// 添加人：胡 耀 锋
        /// 添加时间：2014-04-08
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMessageState()
        {
            var lst = new List<string[]>()
                {                      
                    new string[2]{"0","未读"},
                    new string[2]{"1","已读"}
                };
            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取消息类型数据
        /// 添加人：胡 耀 锋
        /// 添加时间：2014-04-09
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMessageType()
        {
            var type = new ComResourceBll().GetSearchResult(new ComResourceEntity() { ParentId = "0005" });
            return Json(type, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取消息类型数据
        /// 添加人：胡 耀 锋
        /// 添加时间：2014-04-09
        /// </summary>
        /// <returns></returns>
        public JsonResult UpdateState(string id, int state)
        {
            var type = false;
            if (state == 0)
            {
                type = new CrmMessageWorkBll().UpdateState(id);

            }
            return Json(type, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取消息Json 数据
        /// 添加人：胡 耀 锋
        /// 添加时间：2014-04-08
        /// </summary>
        /// <returns></returns>
        public JsonResult GetLeftRole()
        {
            var search = new CrmMessageWorkEntity();
            var roles = new CrmMessageWorkBll().GetAllMessages();
            var roleList = roles.Select(crmRoleEntity => new ZTreeNode()
            {
                id = crmRoleEntity.Id,
            }).ToList();

            var rtEntity = new StatusModel<ZTreeNode>
            {
                rtData = roleList,
                rtMsrg = "成功",
                rtState = 0
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取消息类型数据
        /// 添加人：胡 耀 锋
        /// 添加时间：2014-04-14
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取消息类型数据
        /// 添加人：胡 耀 锋
        /// 添加时间：2014-04-14
        /// </summary>
        /// <returns></returns>
        public ActionResult Top()
        {
            return View();
        }

        /// <summary>
        /// 消息编辑
        /// 添加人：胡 耀 锋
        /// 添加时间：2014-04-08
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pid">父编号</param>
        /// <returns></returns>
        public ActionResult Edit(string id, string pid)
        {
            var comRole = new CrmMessageWorkEntity();
            if (!string.IsNullOrEmpty(id))
            {
                comRole = new CrmMessageWorkBll().Get(id.Trim());
            }
            if (!string.IsNullOrEmpty(pid))
            {
                var pRoleEntity = new CrmMessageWorkBll().Get(pid.Trim());
                ViewData["ParentName"] = pRoleEntity.ActionerID;
                comRole.Id = pRoleEntity.Id;
            }
            return View(comRole);
        }

        /// <summary>
        /// 保存消息
        /// 添加人：胡 耀 锋
        /// 添加时间：2014-04-08
        /// </summary>
        /// <param name="comMenu"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(CrmMessageWorkEntity crmMessage)
        {
            var rtState = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    crmMessage.RowStatus = 1;
                    crmMessage.CreateBy = crmMessage.Id.Equals("") ? CurrentUser.CrmUser.UserName : crmMessage.CreateBy;
                    crmMessage.CreateOn = crmMessage.Id.Equals("") ? DateTime.Now : crmMessage.CreateOn;
                    crmMessage.CreatorId = crmMessage.Id.Equals("") ? CurrentUser.CrmUser.Id : crmMessage.CreatorId;
                    crmMessage.UpdateBy = CurrentUser.CrmUser.UserName;
                    crmMessage.UpdateId = CurrentUser.CrmUser.Id;
                    crmMessage.UpdateOn = DateTime.Now;

                    if (crmMessage.Id.Equals(""))
                    {
                        new CrmMessageWorkBll().Add(crmMessage);
                    }
                    else
                    {
                        new CrmMessageWorkBll().Update(crmMessage);
                    }
                    rtState = 0;
                }
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
        /// 删除消息
        /// 添加人：胡 耀 锋
        /// 添加时间：2014-04-08
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Delete(string id)
        {
            var rtState = 1;
            if (!string.IsNullOrEmpty(id))
            {
                //rtState = new CrmMessageWorkBll().BatchDeleteMessage("'" + id + "'") ? 0 : 1;
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
        /// 根据第三方应用系统编号、链接地址请求单点登录（加密）的链接地址
        /// 添加人：胡 耀 锋
        /// 添加时间：2014-04-17
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="systemid">第三方应用系统编号</param>
        /// <param name="url">请求链接地址</param>
        /// <returns></returns>
        public JsonResult GetAppLinkUrl(string systemid, string url)
        {
            try
            {
                var linkUrl = url.Replace("&amp;", "&");
                if (!string.IsNullOrEmpty(systemid))
                {
                    var attrValues =
                        new ComAttributeValueBll().GetSearchResult(new ComAttributeValueEntity()
                        {
                            RsId = systemid,
                            AttributeId = systemid == "00010001" ? 2 : 1
                        });
                    var attrUserLogin = new CrmUserMapBll().GetAllUserMaps(CurrentUser.CrmUser.Id, systemid);
                    if (attrValues.Any() && attrUserLogin.Any())
                    {
                        var parameter = attrUserLogin[0].LoginName + "|" + DateTime.Now.ToString(AppConst.DateFormatLong);
                        var md5Parm = HttpUtility.UrlEncode(CommonMethod.Encrypt(parameter, AppConst.EncryptKey, AppConst.EncryptKey));
                        ////拼接URL
                        if (url.Contains("http://localhost"))
                            linkUrl = attrValues[0].Value + url.Substring(url.IndexOfAny(new char[] { '/' }, 0, 3));
                        else if (!url.Contains("http://") && systemid.Equals("00010001"))  //OA
                        {
                            linkUrl = attrValues[0].Value + url + "&uid=" + md5Parm;
                        }
                        else if (!url.Contains("http://") && systemid.Equals("00010003"))  //行政执法系统
                        {
                            linkUrl = attrValues[0].Value + url.Replace("../", "") + "&uid=" + md5Parm;
                        }
                    }
                }
                var rtEntity = new StatusModel<DBNull>
                {
                    rtData = null,
                    rtMsrg = linkUrl,
                    rtState = 0
                };
                return Json(rtEntity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
