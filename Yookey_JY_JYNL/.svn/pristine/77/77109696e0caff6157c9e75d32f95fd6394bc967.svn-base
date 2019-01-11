//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="MembershipManager.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-03 14:01:30
//  功能描述：请一定在此描述类用途
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Common.Security;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;


namespace Yookey.WisdomClassed.SIP.Membership
{
    public class MembershipManager
    {
        /// <summary>
        /// 用户登录
        /// 添加人：周 鹏
        /// 添加时间：2014-01-03
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="passWord">密码</param>
        /// <param name="remberPwd">保存登录账号密码</param>
        /// <param name="decodePassWord">是否对密码进行加密</param>
        /// <param name="createPersistentCookie">是否永久保存</param>
        /// <returns></returns>
        public UserLoginStatus UserLogin(string loginName, string passWord, string remberPwd, bool decodePassWord = true, bool createPersistentCookie = false)
        {
            var user = new CrmUserBll().GetUserEntity(loginName, "Account");
            var loginErrorCount = new ComLoginLogBll().GetLoginErrorCount(loginName);
            if (loginErrorCount >= 5)
            {
                return UserLoginStatus.TemporaryLocked;
            }
            if (user != null && !string.IsNullOrEmpty(user.Id))
            {
                passWord = DESHelper.ToDESEncrypt(passWord, AppConst.EncryptKey);  //将密码进行加密
                if (!user.Password.Equals(passWord)) return UserLoginStatus.PasswordError;

                if (!string.IsNullOrEmpty(remberPwd) && remberPwd.Equals("checked"))
                {
                    //验证通过,设置Cookie信息
                    CookieUtil.SetCookie(AppConst.LoginUserNameCookieName,
                                         createPersistentCookie ? HttpUtility.UrlEncode(user.Account) : "",
                                         DateTime.MaxValue);
                    //验证通过,设置Cookie信息
                    CookieUtil.SetCookie(AppConst.LoginUserCookiePwd,
                                         createPersistentCookie ? HttpUtility.UrlEncode(user.Password) : "",
                                         DateTime.MaxValue);
                }
                else
                {
                    CookieUtil.Remove(AppConst.LoginUserNameCookieName);
                    CookieUtil.Remove(AppConst.LoginUserCookiePwd);
                }

                var ticket = new FormsAuthenticationTicket(1, user.Id, DateTime.Now, DateTime.Now.AddDays(1), false, "");
                var strTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, strTicket);
                HttpContext.Current.Response.Cookies.Add(cookie);
                return UserLoginStatus.Sucess;
            }
            return UserLoginStatus.NotUser;
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// 获取当前账户信息
        /// </summary>
        /// <param name="userName">当前用户名(用户ID)</param>
        /// <returns></returns>
        public AccountInfo GetCurrentAccount(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return null;
            var accountInfo = new AccountInfo
                {
                    CrmUser = new BaseUserBll().Get(userName)
                };
            LogHelper.UserId = accountInfo.CrmUser.Id;
            LogHelper.UserName = accountInfo.CrmUser.UserName;
            return accountInfo;
        }

        /// <summary>
        /// 获取用户菜单
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public List<ComMenuEntity> GetUserMenus(string userId)
        {
            if (string.IsNullOrEmpty(userId)) return null;
            List<ComMenuEntity> userMenus = new ComMenuBll().GetUserMenus(userId);
            return userMenus ?? new List<ComMenuEntity>();
        }


        /// <summary>
        /// 获取用户所有菜单，以,分隔
        /// </summary>
        /// <param name="currentUserId">当前用户Id</param>
        /// <param name="controllername">Controller Name</param>
        /// <returns></returns>
        public string GetUserMenus(string currentUserId, string controllername)
        {
            return new ComMenuBll().GetUserMenus(currentUserId, controllername);
        }

        /// <summary>
        /// 获取用户菜单
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="menuType">菜单类型</param>
        /// <returns></returns>
        public List<ComMenuEntity> GetUserMenus(string userId, MenuType menuType)
        {
            var menus = GetUserMenus(userId);
            return menus != null
                       ? GetUserMenus(userId).Where(
                           t => t.IsMenu == (int)menuType).ToList()
                       : new List<ComMenuEntity>();
        }

        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="userName">用户名(用户ID)</param>
        /// <param name="controller">Controller</param>
        /// <param name="action">Action</param>
        /// <returns></returns>
        public bool ValidatePermissions(string userName, string controller, string action)
        {
            //return GetUserMenus(userName).Count(t => t.Controller.ToLower() == controller.ToLower() && t.Action.ToLower() == action.ToLower()) > 0;
            return true;
        }


        /// <summary>
        /// 权限验证
        /// </summary>
        /// <param name="userName">用户名(用户ID)</param>
        /// <param name="controller">Controller</param>
        /// <param name="action">Action</param>
        /// <returns></returns>
        public bool VerificationPermissions(string userName, string controller, string action)
        {
            return GetUserMenus(userName).Count(t => t.Controller.ToLower() == controller.ToLower() && t.Action.ToLower() == action.ToLower()) > 0;
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="oldpassword">旧密码</param>
        /// <param name="newpassword">新密码</param>
        /// <returns></returns>
        public bool ChangePassword(string userId, string oldpassword, string newpassword)
        {
            var isOk = false;
            try
            {
                var user = new BaseUserBll().Get(userId);
                if (user != null && !string.IsNullOrEmpty(user.Id))
                {
                    ////调用接口进行密码解密
                    //var passwordDecode = AppConfig.PasswordDecode;
                    //var responseWord = CommonMethod.SendRequestByGetMethod(string.Format(passwordDecode, user.Secretkey, oldpassword), System.Text.Encoding.UTF8);
                    var responseWord = DESHelper.ToDESEncrypt(oldpassword, AppConst.EncryptKey);  //将密码进行加密

                    //验证旧密码是否正确
                    if (user.PassWord.Equals(responseWord))
                    {
                        //responseWord = CommonMethod.SendRequestByGetMethod(string.Format(passwordDecode, user.Secretkey, newpassword), System.Text.Encoding.UTF8);

                        responseWord = DESHelper.ToDESEncrypt(newpassword, AppConst.EncryptKey);  //将密码进行加密
                        //修改密码
                        isOk = new BaseUserBll().UpdatePassWord(userId, responseWord);
                    }
                }
            }
            catch (Exception ex)
            {
                isOk = false;
            }
            return isOk;
        }


        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userName">用户登录名或真实姓名</param>
        /// <returns></returns>
        public CrmUserEntity GetUser(string userName)
        {
            return new CrmUserBll().GetUserByUserName(userName);
        }

        /// <summary>
        /// 系统在线人员登录情况
        /// </summary>
        public static readonly Dictionary<string, DateTime> LastLoginUsers = new Dictionary<string, DateTime>();
    }

    /// <summary>
    /// 账户信息
    /// </summary>
    public class AccountInfo
    {
        /// <summary>
        /// 当前用户信息
        /// </summary>
        public BaseUserEntity CrmUser { get; set; }

        public AccountInfo()
        {
            CrmUser = new BaseUserEntity();
        }

        public AccountInfo(BaseUserEntity crmUser)
        {
            CrmUser = crmUser;
        }

        ///// <summary>
        ///// 当前用户信息
        ///// </summary>
        //public CrmUserEntity CrmUser { get; set; }

        //public AccountInfo()
        //{
        //    CrmUser = new CrmUserEntity();
        //}

        //public AccountInfo(CrmUserEntity crmUser)
        //{
        //    CrmUser = crmUser;
        //}
    }
}
