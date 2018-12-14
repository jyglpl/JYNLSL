using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Yookey.WisdomClassed.SIP.Business.Mobile;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.WebService.Com
{
    /// <summary>
    /// Bill 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Bill : System.Web.Services.WebService
    {
        readonly WSAllNumberBll _wsallnumberBll = new WSAllNumberBll();
        /// <summary>
        /// 获取所有票据号
        /// </summary>
        /// <param name="context">UseID   用户ID  LastDate 领用时间</param>
        /// <returns></returns>
        [WebMethod]
        public string GetWSAllNumber(string context)
        {
            //string result = "";
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var WSAllNumberDt = _wsallnumberBll.GetWSAllNumber(context);
                //return JsonConvert.SerializeObject(WSAllNumberDt);
                Status = true;
                obj = WSAllNumberDt;
            }
            catch (Exception ex)
            {
                Status = false;
                msg = ex.Message;
                //result = "";
            }
            //return result;
            var result = new StatusModel() 
            {
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 验证票据号是否正确
        /// </summary>
        /// <param name="context">UseID 用户ID WSType 文书类型 WSNO 文书编号</param>
        /// <returns></returns>
        [WebMethod]
        public string CheckJYFMK(string context)
        {
            //string result = "";
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
                var isOkCheckJYFMK = _wsallnumberBll.CheckJYFMK(context);
               // return isOkCheckJYFMK; //JsonConvert.SerializeObject(isOkCheckJYFMK);
                Status = true;
                obj = isOkCheckJYFMK;
            }
            catch (Exception ex)
            {
                Status = false;
                msg = ex.Message;
                //return "";
            }
           // return "";
            var result = new StatusModel()
            {
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 更新文书编号的使用状态
        /// </summary>
        /// <param name="DeptID">部门编号</param>
        /// <param name="WSNO">文书编号</param>
        /// <param name="UserId">用户ID</param>
        [WebMethod]
        public string UpdateJYFMK(string context)
        {
            //bool result;
            bool Status = false;
            var msg = "";
            object obj = null;
            try
            {
               // result = _wsallnumberBll.UpdateJYFMK(context);
                var UpdateJYFMK = _wsallnumberBll.UpdateJYFMK(context);
                Status = true;
                obj = UpdateJYFMK;
            }
            catch (Exception ex)
            {
                //result = false;
                Status = false;
                msg = ex.Message;
            }
           // return result;
            var result = new StatusModel()
            {
                Status=Status,
                msg=msg,
                Content=obj
            };
            return JsonConvert.SerializeObject(result);
        }

    }
}
