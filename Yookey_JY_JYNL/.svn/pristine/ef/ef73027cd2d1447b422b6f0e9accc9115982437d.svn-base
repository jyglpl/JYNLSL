using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.WebService.Com
{
    /// <summary>
    /// CrmUser 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class CrmUser : System.Web.Services.WebService
    {

        private readonly  CrmUserBll _crmUserBll = new CrmUserBll();//用户列表

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetUserList(string context)
        {
            bool Status = false;
            var msg = "";
            object obj = null;
            string results = "";
            try
            {
                var user = new BaseUserBll().GetAllUserNew();

                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var userId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;
                    user = user.Where(p => p.UserName == userId).ToList();

                }
                results += "[";

                for (int i = 0; i < user.Count; i++)
                {
                    results += "{\"UserId\":\"" + user[i].Id + "\",\"UserName\":\"" + user[i].UserName + "\"},";
                }
                results = results.Substring(0, results.Length - 1);
                results += "]";


                Status = true;
                obj = results;
            }
            catch (Exception ex)
            {
                Status = false;
                msg = ex.Message;
            }

            var result = new StatusModel()
            {
                Status = Status,
                msg = msg,
                Content = obj
            };
            return JsonConvert.SerializeObject(result);

        }
    }
}
