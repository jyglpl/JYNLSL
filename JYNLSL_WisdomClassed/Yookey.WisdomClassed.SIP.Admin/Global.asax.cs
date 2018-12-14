using System;
using System.Timers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Yookey.WisdomClassed.SIP.Admin.App_Start;
using log4net;

namespace Yookey.WisdomClassed.SIP.Admin
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //注册 log4net
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Config\\log4net.config"));

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //每30秒对在线人员进行下载待办事宜
            var t = new Timer(30000);
            t.Elapsed += DownData;
            t.AutoReset = true;
            t.Enabled = true;
        }


        /// <summary>
        /// 下载待办事宜数据到xml文件中
        /// </summary>
        private void DownData(object sender, ElapsedEventArgs e)
        {
            //var onLineUsers = MembershipManager.LastLoginUsers.Where(t => t.Value <= DateTime.Now.AddSeconds(30) && t.Value >= DateTime.Now.AddSeconds(-30));
            //var ulist = onLineUsers.Select(keyValuePair => keyValuePair.Key).ToList();
            //if (ulist.Count.Equals(0)) return;
            //var userList = new CrmUserBll().GetUser(ulist);
            //foreach (CrmUserEntity user in userList)
            //{
            //    try
            //    {
            //        new CrmMessageWorkBll().DownLoadXMLData(new CrmMessageWorkEntity() { ActionerID = user.Id, UserName = user.LoginName });
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            var objErr = Server.GetLastError().GetBaseException();
            var error = "发生异常页: " + Request.Url + "\r\n";
            error += "异常信息: " + objErr.Message;
            var log = LogManager.GetLogger("DailyRollingFile");
            log.Error(error);
            //Response.Redirect("~/Error/Exception");
        }
    }
}