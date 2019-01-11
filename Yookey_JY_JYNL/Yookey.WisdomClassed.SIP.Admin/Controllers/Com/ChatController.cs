using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Chat;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Com
{
    public class ChatController : BaseController
    {
        //
        // GET: /Chat/

        private CrmUserBll cubll = new CrmUserBll();

        public ActionResult ChatForm(string id)
        {


            ViewBag.ChatMessage = new ChatMessageBll().getLastMessage(10, CurrentUser.CrmUser.Id, id);
            CrmUserEntity user = cubll.Get(id);
            if (user.Portrait != "")
            {
                var fileEntity = new ComAttachmentBll().Get(user.Portrait);
                ViewBag.UserAvatar = !string.IsNullOrEmpty(fileEntity.FilePath)
                                         ? "/User/images/" + fileEntity.FilePath
                                         : "/User/images/avatar.png";
            }
            else
            {
                ViewBag.UserAvatar = "/User/images/avatar.png";
            }
            if (CurrentUser.CrmUser.Portrait != "")
            {
              var  user2 = CurrentUser.CrmUser;
                var fileEntity = new ComAttachmentBll().Get(user2.Portrait);
                ViewBag.ToUserAvatar = !string.IsNullOrEmpty(fileEntity.FilePath)
                                         ? "/User/images/" + fileEntity.FilePath
                                         : "/User/images/avatar.png";
            }
            else 
            {
                ViewBag.ToUserAvatar = "/User/images/avatar.png";
            }
            ViewData["Me"] = CurrentUser.CrmUser;
            if (user != null)
            {
                return View(user);
            }
            
            return View(new CrmUserEntity());
        }

    }
}
