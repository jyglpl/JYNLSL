using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Common;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Com
{
    public class SystemLogController :BaseController
    {
        //
        // GET: /SystemLog/

        private ComOperationLogBll _bllOper = new ComOperationLogBll();
        private ComLoginLogBll _bllLogin = new ComLoginLogBll();

        /// <summary>
        /// 操作日志
        /// </summary>
        /// <returns></returns>
        public ActionResult Operation()
        {
            ViewData["LogType"] = new SelectList(LogHelper.LogTypeData);
            return View();
        }

        /// <summary>
        /// 登录日志
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            ViewData["Source"] = new SelectList(LogHelper.LogSource);
            ViewData["Status"] = new SelectList(LogHelper.LogStatus);
            return View();
        }

        //绑定操作日志Grid视图
        public string GridJson(string logType , string startTime, string endTime, int rows, int page)
        {
            var data = _bllOper.GetCommonQuryGetCommonQury(LogHelper.GetLogType(logType), startTime, endTime, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 添加操作日志信息
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <param name="controller">控制器名称</param>
        /// <param name="modelName">模块名称</param>
        /// <param name="action">方法名</param>
        /// <param name="handleType">操作类型</param>
        /// <param name="note">日志类容</param>
        /// <returns></returns>
        public bool AddLog(LogType logType, string controller, string modelName, string action, HandleType handleType, string note="")
        {
            return _bllOper.AddLog(logType, controller, modelName, action, handleType, note, LogHelper.UserId, LogHelper.UserName);
        }


        /// <summary>
        /// 添加登录日志
        /// </summary>
        /// <returns></returns>
        public bool AddLoginLog()
        {
            return _bllLogin.AddLog(LogHelper.Web, LogHelper.GetUserIp, (int)LogHelper.LoginState, LogHelper.LoginNote,LogHelper.UserNo, LogHelper.LoginFullName);
        }

        //绑定登录日志Grid视图
        public string LogLoginGridJson(string source, string status, string startTime, string endTime, int rows, int page)
        {
            var data = _bllLogin.GetCommonQuryGetCommonQury(LogHelper.GetLogSource(source), LogHelper.GetLogStatus(status), startTime, endTime, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

    }

    /// <summary>
    /// 监控类
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class StatisticsTrackerAttribute : ActionFilterAttribute, IExceptionFilter
    {
        private readonly string Key = "_thisOnActionMonitorLog_";
        private readonly SystemLogController _log = new SystemLogController();

        #region Action时间监控
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            MonitorLog MonLog = new MonitorLog();
            MonLog.ExecuteStartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ffff", DateTimeFormatInfo.InvariantInfo));
            MonLog.ControllerName = filterContext.RouteData.Values["controller"] as string;
            MonLog.ActionName = filterContext.RouteData.Values["action"] as string;
            _log.AddLog(LogType.Operate, MonLog.ControllerName, "", MonLog.ActionName, HandleType.Visit);
            filterContext.Controller.ViewData[Key] = MonLog;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            MonitorLog MonLog = filterContext.Controller.ViewData[Key] as MonitorLog;
            MonLog.ExecuteEndTime = DateTime.Now;
            MonLog.FormCollections = filterContext.HttpContext.Request.Form;//form表单提交的数据
            MonLog.QueryCollections = filterContext.HttpContext.Request.QueryString;//Url 参数
            LogHelper.Monitor(MonLog.GetLoginfo());

        }
        #endregion

        #region View 视图生成时间监控
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            MonitorLog MonLog = filterContext.Controller.ViewData[Key] as MonitorLog;
            MonLog.ExecuteStartTime = DateTime.Now;

        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            MonitorLog MonLog = filterContext.Controller.ViewData[Key] as MonitorLog;
            MonLog.ExecuteEndTime = DateTime.Now;
            LogHelper.Monitor(MonLog.GetLoginfo(MonitorLog.MonitorType.View));
            _log.AddLog(LogType.Operate, MonLog.ControllerName, "", MonLog.ActionName, HandleType.Leave);
            filterContext.Controller.ViewData.Remove(Key);
        }

        #endregion

        #region 错误日志

        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                string ControllerName = string.Format("{0}Controller", filterContext.RouteData.Values["controller"] as string);
                string ActionName = filterContext.RouteData.Values["action"] as string;
                string ErrorMsg = string.Format("在执行 controller[{0}] 的 action[{1}] 时产生异常", ControllerName, ActionName);
                //错误日志
                _log.AddLog(LogType.Error, ControllerName, "", ActionName,HandleType.Visit, filterContext.Exception.ToString());
                LogHelper.Error(ErrorMsg, filterContext.Exception);
            }
        }
        #endregion

    }
}
