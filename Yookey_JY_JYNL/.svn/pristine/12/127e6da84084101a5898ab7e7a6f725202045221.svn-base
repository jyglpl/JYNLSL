using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Yookey.WisdomClassed.SIP.Common
{
    /// <summary>
    /// Log帮助类
    /// </summary>
    public class LogHelper
    {
        static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");
        static readonly log4net.ILog logmonitor = log4net.LogManager.GetLogger("logmonitor");

        public static void Error(string ErrorMsg, Exception ex = null)
        {
            if (ex != null)
            {
                logerror.Error(ErrorMsg, ex);
            }
            else
            {
                logerror.Error(ErrorMsg);
            }
        }

        public static void Info(string Msg)
        {
            loginfo.Info(Msg);
        }

        public static void Monitor(string Msg)
        {
            logmonitor.Info(Msg);
        }

        /// <summary>
        /// 当前时间
        /// </summary>
        public static DateTime CurrentTime
        {
            get { return DateTime.Now; }
        }

        /// <summary>
        /// 用户编号
        /// </summary>
        public static string UserId { get; set; }

        /// <summary>
        /// 登录用户名
        /// </summary>
        public static string UserNo { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public static string UserName { get; set; }


        /// <summary>
        /// 随机生成的主键
        /// </summary>
        public static string Id
        {
            get { return Guid.NewGuid().ToString(); }
        }


        /// <summary>
        /// 操作日志类型
        /// </summary>
        public static List<string> LogTypeData
        {
            get
            {
                return new List<string>()
                {
                    "操作日志","错误日志"
                };
            }
        }

        /// <summary>
        /// 登录日志来源
        /// </summary>
        public static List<string> LogSource
        {
            get
            {
                return new List<string>()
                {
                    "网页","PDA"
                };
            }
        }

        /// <summary>
        /// 登录日志状态
        /// </summary>
        public static List<string> LogStatus
        {
            get
            {
                return new List<string>()
                {
                    "成功","失败"
                };
            }
        }

        /// <summary>
        /// 登录来源
        /// </summary>
        public static int Web
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// 登录状态
        /// </summary>
        public static int LoginState
        {
            get;
            set;
        }

        /// <summary>
        /// 登录日志
        /// </summary>
        public static string LoginNote
        {
            get
            {
                if (LoginState == -1) return "登陆账户不存在";
                if (LoginState == 2) return "登陆账户被系统锁定";
                if (LoginState == 4) return "登陆密码错误";
                if (LoginState == 3) return "登陆成功";
                if (LoginState == 0) return "登录异常";
                if (LoginState == 5) return "离开";
                return string.Empty;
            }
        }

        public static int LoginStateName
        {
            get
            {
                if (LoginState == 3)
                    return 1;
                return 0;
            }
        }

        /// <summary>
        /// 登录日志用户名称
        /// </summary>
        public static string LoginFullName
        {
            get
            {
                if (UserName != string.Empty)
                    return UserNo + "(" + UserName + ")";
                else
                    return UserNo;
            }
        }


        /// <summary>
        /// 获取客户端的IP地址
        /// </summary>
        public static string GetUserIp
        {
            get
            {
                var realRemoteIp = "";
                if (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    realRemoteIp = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Split(',')[0];
                }
                if (string.IsNullOrEmpty(realRemoteIp))
                {
                    realRemoteIp = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                if (string.IsNullOrEmpty(realRemoteIp))
                {
                    realRemoteIp = System.Web.HttpContext.Current.Request.UserHostAddress;
                }
                return realRemoteIp != null && realRemoteIp.Contains(@"::1") ? "127.0.0.1" : realRemoteIp;
            }
        }

        /// <summary>
        /// 对象释放
        /// </summary>
        public static void Dispose()
        {
            UserId = string.Empty;
            UserNo = string.Empty;
            UserName = string.Empty;
        }

        /// <summary>
        /// 获取日志类型名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetLogTypeName(LogType type)
        {
            switch (type)
            {
                case LogType.Error:
                    return "错误日志";
                case LogType.Operate:
                    return "操作日志";
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取操作日志类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int GetLogType(string type)
        {
            switch (type)
            {
                case "错误日志":
                    return 0;
                case "操作日志":
                    return 1;
            }
            return -1;
        }

        /// <summary>
        /// 获取登录日志来源
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int GetLogSource(string source)
        {
            switch (source)
            {
                case "PDA":
                    return 0;
                case "网页":
                    return 1;
            }
            return -1;
        }

        /// <summary>
        /// 获取登录日志状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static int GetLogStatus(string status)
        {
            switch (status)
            {
                case "失败":
                    return 0;
                case "成功":
                    return 1;
            }
            return -1;
        }

        /// <summary>
        /// 获取日志操作类型名称
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetHandleTypeName(HandleType type)
        {
            switch (type)
            {
                case HandleType.Visit:
                    return "访问";
                case HandleType.Leave:
                    return "离开";
                case HandleType.Add:
                    return "新增";
                case HandleType.Update:
                    return "修改(保存)";
                case HandleType.Delete:
                    return "删除";
                case HandleType.DownLoad:
                    return "下载";
            }
            return string.Empty;
        }
    }

    /// <summary>
    /// 监控日志对象
    /// </summary>
    public class MonitorLog
    {
        public string ControllerName
        {
            get;
            set;
        }
        public string ActionName
        {
            get;
            set;
        }

        public DateTime ExecuteStartTime
        {
            get;
            set;
        }
        public DateTime ExecuteEndTime
        {
            get;
            set;
        }
        /// <summary>
        /// Form 表单数据
        /// </summary>
        public NameValueCollection FormCollections
        {
            get;
            set;
        }
        /// <summary>
        /// URL 参数
        /// </summary>
        public NameValueCollection QueryCollections
        {
            get;
            set;
        }
        /// <summary>
        /// 监控类型
        /// </summary>
        public enum MonitorType
        {
            Action = 1,
            View = 2
        }
        /// <summary>
        /// 获取监控指标日志
        /// </summary>
        /// <param name="mtype"></param>
        /// <returns></returns>
        public string GetLoginfo(MonitorType mtype = MonitorType.Action)
        {
            string ActionView = "Action执行时间监控：";
            string Name = "Action";
            if (mtype == MonitorType.View)
            {
                ActionView = "View视图生成时间监控：";
                Name = "View";
            }
            string Msg = @"
            {0}
            ControllerName：{1}Controller
            {8}Name:{2}
            开始时间：{3}
            结束时间：{4}
            总 时 间：{5}秒
            Form表单数据：{6}
            URL参数：{7}
                    ";
            return string.Format(Msg,
                ActionView,
                ControllerName,
                ActionName,
                ExecuteStartTime,
                ExecuteEndTime,
                (ExecuteEndTime - ExecuteStartTime).TotalSeconds,
                GetCollections(FormCollections),
                GetCollections(QueryCollections),
                Name);
        }

        /// <summary>
        /// 获取Post 或Get 参数
        /// </summary>
        /// <param name="Collections"></param>
        /// <returns></returns>
        public string GetCollections(NameValueCollection Collections)
        {
            string Parameters = string.Empty;
            if (Collections == null || Collections.Count == 0)
            {
                return Parameters;
            }
            foreach (string key in Collections.Keys)
            {
                Parameters += string.Format("{0}={1}&", key, Collections[key]);
            }
            if (!string.IsNullOrWhiteSpace(Parameters) && Parameters.EndsWith("&"))
            {
                Parameters = Parameters.Substring(0, Parameters.Length - 1);
            }
            return Parameters;
        }

    }

    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogType
    {
        //错误
        Error = 0,
        //操作
        Operate = 1
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum HandleType
    {
        //访问
        Visit = 0,
        //离开
        Leave = 1,
        //新增
        Add = 2,
        //修改
        Update = 3,
        //删除
        Delete = 4,
        //下载
        DownLoad = 5

    }
}
