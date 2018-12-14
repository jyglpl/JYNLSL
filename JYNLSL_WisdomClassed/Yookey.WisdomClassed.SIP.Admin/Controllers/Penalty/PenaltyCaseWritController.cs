using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Case;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Penalty
{
    public class PenaltyCaseWritController : BaseController
    {
        readonly InfWritBll _infWritBll = new InfWritBll();

        public object Obj = new object();

        /// <summary>
        /// 请求文书
        /// 添加人：周 鹏
        /// 添加时间：2015-01-07
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述        /// </history>
        /// <param name="writIdentify">文书标识</param>
        /// <param name="resourceId">外键编号</param>
        /// <returns></returns>
        public string GetCaseWrit(string writIdentify, string resourceId)
        {
            try
            {
                lock (Obj)
                {
                    return _infWritBll.GetWrit(writIdentify, resourceId.Trim());
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
