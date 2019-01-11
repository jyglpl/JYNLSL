using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.WebService.Com
{
    /// <summary>
    /// Image 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Image : System.Web.Services.WebService
    {

        [WebMethod]
        public string RotateImg(string context)
        {
            var msg = "";
            var status = false;
            object obj = null;
            try
            {
                if (!string.IsNullOrEmpty(context))
                {
                    context = Regex.Replace(context, @"[\{\}]", "");
                    context += ",";
                    var imgUrl = Regex.Match(context, @"(?<=""ImgUrl""\:"").*?(?="",)").Value;   //图片访问地址
                    var angle = Regex.Match(context, @"(?<=""Angle""\:"").*?(?="",)").Value;     //旋转角度

                    if (!string.IsNullOrEmpty(imgUrl) && !string.IsNullOrEmpty(angle))
                    {
                        imgUrl = imgUrl.Replace(AppConfig.FileViewLink, AppConfig.FileSaveAddr);
                        if (File.Exists(imgUrl))
                        {
                            status = ImageHelper.RotateImg(imgUrl, int.Parse(angle));
                            msg = status ? "Success" : "Error";
                        }
                        else
                        {
                            msg = "404";
                        }
                    }
                    else
                    {
                        msg = "参数传入不正确";
                    }
                }
                else
                {
                    msg = "请传入参数";
                }
            }
            catch (Exception ex)
            {
                //msg = ex.Message;
                //msg = "";
                status = false;
                msg = ex.Message;
            }
            var result = new StatusModel()
            {
                Status=status,
                msg=msg,
                Content=obj
            };
            //return JsonConvert.SerializeObject(new { Status = status, msg = msg });
            return JsonConvert.SerializeObject(result);
        }
    }
}
