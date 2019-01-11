using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Com
{
    public class MessagePhoneController : BaseController
    {
        //
        // GET: /MessagePhone/

        public ActionResult Index()
        {
            return View();
        }

        //绑定Grid视图
        public string GridJson(string person, string phoneNumber, string dateStart, string dateEnd, int rows, int page)
        {
            var data = new ComNoteBll().GetCommonQuryGetCommonQury(person, phoneNumber, dateStart, dateEnd, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 获取树
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public string AsyncGetNodes(string pId)
        {
           var lst=new ComNoteBll().GetNodeQury(pId);          
           var result = JsonConvert.SerializeObject(lst);
           return result;
        }

        public void NodeSort(List<Node> lst,ref  List<Node> lstAdd ,string pId)
        {
            var result = lst.Where(t => t.pId == pId) as List<Node>;
            foreach (var node in result )
            {
                lstAdd.Add(node);
                NodeSort(lst, ref lstAdd, node.id);
            }
        }

        /// <summary>
        /// 发送详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(string id)
        {
            var model = new ComNoteBll().QueryNoteContent(id);
            return View(model);
        }

        /// <summary>
        /// 新增短信
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            var json = new ComNoteContentEntity()
            {
                ReceiveTime = DateTime.Now
            };
            return View(json);
        }


        public string DeleteMessage(string id)
        {
            var result = new ComNoteBll().DeleteMessage(id);
            return result.ToString();
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <returns></returns>
        public string SendPhoneMessage(ComNoteContentEntity noteContent)
        {
            var result = false;
            noteContent.Id=Guid.NewGuid().ToString();
            noteContent.SendPerson = CurrentUser.CrmUser.UserName;
            result=new ComNoteBll().SaveMessage(noteContent);
            return result.ToString();
        }
    }
}
