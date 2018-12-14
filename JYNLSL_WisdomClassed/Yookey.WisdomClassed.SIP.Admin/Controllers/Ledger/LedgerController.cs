using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Ledger
{
    public class LedgerController : BaseController
    {
        private readonly InfPunishCaseinfoBll _infPunishCaseinfoBll = new InfPunishCaseinfoBll();
        private readonly BaseDepartmentBll _departmentBll = new BaseDepartmentBll();
        private readonly InfPunishAttachBll _infPunishAttachBll = new InfPunishAttachBll();
        readonly ComResourceBll _comResourceBll = new ComResourceBll();                  //数据字典

        #region 视图
        //
        // GET: /Ledger/

        public ActionResult Index()
        {
            //执法大队下所有部门
            var depts = _departmentBll.GetAllDetachment("");
            depts.Insert(0, new BaseDepartmentEntity() { DepartmentId = "", FullName = "==请选择==" });
            ViewData["Depts"] = new SelectList(depts, "DepartmentId", "FullName");

            //案件类别
            var classNos = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0009" });
            classNos.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["ClassNos"] = new SelectList(classNos, "Id", "Rskey");

            return View();
        }


        public ActionResult Main(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        public ActionResult WordView(string writIdentify, string id)
        {
            ViewBag.WritIdentify = writIdentify;
            ViewBag.Id = id;
            return View();
        }

        public ActionResult PictureView(string id, string evtache)
        {
            IList<ComResourceEntity> evidences = new List<ComResourceEntity>();

            if (!string.IsNullOrEmpty(evtache))
            {
                #region 材料类型
                if (evtache.Equals("Case"))             //案件证据材料
                {
                    //证据类别
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0015" });
                }
                else if (evtache.Equals("Record"))      //调查询问笔录
                {
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0016" });
                    evidences = evidences.Where(x => x.Id == "00160001").ToList();
                }
                else if (evtache.Equals("Inform"))      //告知书
                {
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0016" });
                    evidences = evidences.Where(x => x.Id == "00160002" || x.Id == "00160003").ToList();
                }
                else if (evtache.Equals("Decision"))    //决定书
                {
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0016" });
                    evidences = evidences.Where(x => x.Id == "00160004" || x.Id == "00160005").ToList();
                }
                else if (evtache.Equals("CaceBackCard"))  //决定书送达回执
                {
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0016" });
                    evidences = evidences.Where(x => x.Id == "00160005").ToList();
                }
                else if (evtache.Equals("CaseOrder"))    //缴纳罚没款委托单
                {
                    evidences = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0016" });
                    evidences = evidences.Where(x => x.Id == "00160006").ToList();
                }

                #endregion
            }

            if (!string.IsNullOrEmpty(id))
            {
                var filetypelist = (from type in evidences where !string.IsNullOrEmpty(type.Id) select type.Id).ToList();
                var files = _infPunishAttachBll.GetSearchResult(new InfPunishAttachEntity() { ResourceId = id }, filetypelist);

                ViewData["Files"] = files;
            }

            return View();
        }


        public ActionResult Entity(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        public ActionResult Directory()
        {
            return View();
        }

        /// <summary>
        /// 台账封面
        /// 添加人：周 鹏
        /// 添加时间：2015-05-07
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Cover(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var entity = _infPunishCaseinfoBll.Get(id);

                var punishLegislations = new InfPunishLegislatioinBll().GetSearchResult(new InfPunishLegislationEntity() { CaseInfoId = id });
                if (punishLegislations != null && punishLegislations.Count > 0)
                {
                    ViewBag.ItemName = punishLegislations[0].ItemName;
                }
                ViewBag.CaseInfoNo = entity.CaseInfoNo;
                ViewBag.TargetName = entity.TargetType == "00120001" ? entity.TargetName : entity.TargetUnit;

                var finishs = new InfPunishFinishBll().GetSearchResult(new InfPunishFinishEntity { CaseInfoId = id });  //结案信息
                if (finishs != null && finishs.Count > 0)
                {
                    ViewBag.FinishDate = finishs[0].FinishDate.ToString("yyyy年MM月dd日");
                }
            }
            return View();
        }

        #endregion

        #region Ajax 数据请求

        /// <summary>
        /// 数据请求
        /// 添加人：周 鹏
        /// 添加时间：2015-05-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptId">部门ID</param>
        /// <param name="caseStartTime">案发开始时间</param>
        /// <param name="caseEndTime">案发截止时间</param>
        /// <param name="classI">查询大类</param>
        /// <param name="classIi">查询小类</param>
        /// <param name="pagesize">每页请求条数</param>
        /// <param name="pagenumber">当前索引页</param>
        /// <returns>System.String.</returns>
        public string GetData(string deptId, string caseStartTime, string caseEndTime, string classI, string classIi, int pagesize, int pagenumber)
        {
            var data = _infPunishCaseinfoBll.QueryQueryCaseList(deptId, caseStartTime, caseEndTime, classI, classIi, pagesize, pagenumber);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        #endregion
    }
}
