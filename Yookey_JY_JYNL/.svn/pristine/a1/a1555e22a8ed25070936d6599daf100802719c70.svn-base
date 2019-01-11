using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Evidence;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Evidence;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Video
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/
        readonly ProofAttachCaseBll _proofAttachCaseBll = new ProofAttachCaseBll();//执法记录附件
        readonly ProofAttachBll _proofAttachBll = new ProofAttachBll();//执法记录附件
        readonly CrmUserBll _crmUserBll = new CrmUserBll();//人员信息

        public ActionResult HtmlPage1()
        {
            return View();
        }

        public ActionResult VideoIndex()
        {
            return View();
        }

        public ActionResult Index(string userId, string ajdate, string startTime, string endTime, string address, string caseId, string penaltyCase, string penalty)
        {
            string FilePath = ConfigurationManager.AppSettings["FileViewAddress"];
            List<ProofAttachEntity> attachList = new List<ProofAttachEntity>();

            if (!string.IsNullOrEmpty(startTime))
            {
                ViewData["stratTime"] = startTime;
                ViewData["endTime"] = endTime;
                attachList = _proofAttachBll.GetSearchResult(new ProofAttachEntity() { StartDate = startTime, EndDate = endTime, ADDRESS = address }, userId);
            }
            else
            {
                string afsj = ajdate;
                if (!string.IsNullOrEmpty(ajdate))
                {
                    ViewData["stratTime"] = Convert.ToDateTime(afsj).AddHours(-1).ToString("yyyy-MM-dd");
                    ViewData["endTime"] = Convert.ToDateTime(afsj).AddHours(1).ToString("yyyy-MM-dd");
                }

                attachList = _proofAttachBll.GetSearchResult(new ProofAttachEntity() { CTIME = ajdate, ADDRESS = address }, userId);
            }




            for (int i = 0; i < attachList.Count; i++)
            {
                attachList[i].FILETHUMBNAIL = FilePath + "/" + attachList[i].FILEADDRESS + "/" + attachList[i].FILETHUMBNAIL;
                attachList[i].USERID = _crmUserBll.GetAllUsers(new CrmUserEntity() { Id = attachList[i].USERID })[0].RealName;
            }
            ViewData["attList"] = attachList;
            ViewData["userId"] = userId;
            ViewData["caseId"] = caseId;
            ViewData["penaltyCase"] = penaltyCase;
            ViewData["penalty"] = penalty;

            return View();
        }

        public string Submit(string videoIds, string caseId, string penaltyCase, string penalty)
        {
            string[] lst = videoIds.Split(',');
            for (int i = 0; i < lst.Length; i++)
            {
                if (lst[i] != "")
                {
                    _proofAttachCaseBll.Insert(new ProofAttachCaseEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CaseId = caseId,
                        Penalty = penalty,
                        PenaltyCase = penaltyCase,
                        ProofAttachId = lst[i]
                    });
                }
            }
            return "";
        }
    }
}
