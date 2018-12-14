using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Yookey.WisdomClassed.SIP.Admin.Controllers.Com;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Common.Security;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Membership;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/LogOn
        public ActionResult LoginOn()
        {
            if (User.Identity.IsAuthenticated)
            {
                //return RedirectToAction("Index", "Home");
            }

            var model = new LogOnModel
                {
                    UserName = HttpUtility.UrlDecode(CookieUtil.GetCookie(AppConst.LoginUserNameCookieName)),
                    Password = HttpUtility.UrlDecode(CookieUtil.GetCookie(AppConst.LoginUserCookiePwd)),
                };

            if (!string.IsNullOrEmpty(model.Password))
            {
                model.Password = DESHelper.ToDESDecrypt(model.Password, AppConst.EncryptKey);
                model.RememberMe = true;
            }

            return View(model);
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                //return RedirectToAction("Index", "Home");
            }
            var model = new LogOnModel
            {
                UserName = HttpUtility.UrlDecode(CookieUtil.GetCookie(AppConst.LoginUserNameCookieName)),
                Password = HttpUtility.UrlDecode(CookieUtil.GetCookie(AppConst.LoginUserCookiePwd)),
            };
            if (!string.IsNullOrEmpty(model.Password))
            {
                model.Password = DESHelper.ToDESDecrypt(model.Password, AppConst.EncryptKey);
                model.RememberMe = true;
            }
            return View(model);
        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public FileContentResult CreateCode()
        {
            string strcode = ImageHelper.VerificationCodeHelper.GenerateCheckCode();
            Session["CheckCode"] = strcode;
            return ImageHelper.VerificationCodeHelper.CreateCheckCodeImage(strcode);
        }

        //
        // POST: /Account/LoginOn
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="remberPwd">记录密码</param>
        /// <returns></returns>
        [HttpPost]
        public int LogOn(string account, string password, string remberPwd)
        {
            try
            {
                password = HttpUtility.UrlDecode(password);
                LogHelper.UserNo = account;
                var status = new MembershipManager().UserLogin(HttpUtility.UrlDecode(account), password, remberPwd, true, true);
                LogHelper.LoginState = (int)status;
                //var status = new MembershipManager().UserLogin(HttpUtility.UrlDecode(account), CommonMethod.Encrypt(password, AppConst.EncryptKey), true);
                return (int)status;
            }
            catch (Exception)
            {
                LogHelper.LoginState = (int)UserLoginStatus.Error;
                return (int)UserLoginStatus.Error;
            }
            finally
            {
                if (LogHelper.LoginState != (int)UserLoginStatus.TemporaryLocked)   //账号没有被临时锁定
                {
                    new SystemLogController().AddLoginLog();
                }
            }
        }

        public ActionResult IE6update()
        {
            return View();
        }

        //
        // GET: /Account/LogOff
        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public void LogOff()
        {
            try
            {
                LogHelper.LoginState = (int)UserLoginStatus.Leave;
                new SystemLogController().AddLoginLog();
                System.Web.HttpContext.Current.Session.Abandon();//取消当前会话
                new MembershipManager().SignOut();
            }
            catch (Exception)
            {
            }
        }

        //
        // GET: /Account/ChangePassword
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="oldpwd">旧密码</param>
        /// <param name="newpwd">新密码</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ChangePassword(string oldpwd, string newpwd)
        {
            var isOk = false;
            try
            {
                var currentUser = new MembershipManager().GetCurrentAccount(User.Identity.Name);
                if (currentUser != null && currentUser.CrmUser != null)
                {
                    var user = currentUser.CrmUser;
                    if (!string.IsNullOrEmpty(user.Id))
                    {
                        isOk = new MembershipManager().ChangePassword(user.Id, oldpwd, newpwd);
                    }
                }
            }
            catch (Exception ex)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = isOk ? "密码修改成功！" : "修改失败，请确认旧密码是否正确！"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
