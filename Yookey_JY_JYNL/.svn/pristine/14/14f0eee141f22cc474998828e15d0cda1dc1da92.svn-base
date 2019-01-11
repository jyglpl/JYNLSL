using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Penalty
{
    /// <summary>
    /// 行政处罚->案件查询
    /// </summary>
    public class PenaltyQueryController : Controller
    {
        private readonly InfPunishCaseinfoBll punbll = new InfPunishCaseinfoBll();

        /// <summary>
        /// 综合查询
        /// </summary>
        /// <returns></returns>
        public ActionResult GeneralQuery()
        {
            return View();
        }





        public JsonResult JsonList(string bigType = "-999", string smallType = "-999", string ajbh = "", string dept = "-999", string timeStart = "", string timeEnd = "", string carNo = "", string keyword = "", int rows = 15, int page = 1)
        {
            StringBuilder Casesb=new StringBuilder();
            StringBuilder Carsb = new StringBuilder();
            Casesb.Append(" where 1=1 ");
            Carsb.Append(" where 1=1 ");
            if (bigType != "-999")
            {
                Casesb.Append(" and Id in (select CaseInfoId from INF_PUNISH_ITEM where ClassNo='" + bigType + "') ");
                Carsb.Append(" and TypeNo='"+bigType+"' ");
            }
            if (smallType != "-999")
            {
                Casesb.Append(" and Id in (select CaseInfoId from INF_PUNISH_ITEM where ItemNo='" + smallType + "') ");
                Carsb.Append("");
            }
            if (ajbh.Trim() != "")
            {
                Casesb.Append("  and CaseInfoNo like'%"+ajbh+"%' ");
                Carsb.Append(" and CheckSignNo like '%"+ajbh+"%' ");
            }
            if (dept!= "-999")
            {
                Casesb.Append(" and DeptId='"+dept+"' ");
                Carsb.Append(" and DeptId='" + dept + "' ");
            }
            if (timeStart.Trim() != "")
            {
                Casesb.Append("  and CaseDate >'"+timeStart+"' ");
                Carsb.Append("  and CheckDate >'"+timeStart+"' ");
            }
            if (timeEnd.Trim() != "")
            {
                Casesb.Append("  and CaseDate <'" + timeEnd + "' ");
                Carsb.Append("  and CheckDate <'" + timeEnd + "' ");
            }
            if (carNo.Trim() != "")
            {
                Casesb.Append(" and TargetName like '%"+carNo.Trim()+"%' ");
                Carsb.Append(" and CarNo like '%" + carNo.Trim() + "%' ");
            }

            if (keyword.Trim() != "")
            {
                Casesb.Append(" and CaseFact+CaseAddress+RePersonelNameFist+RePersonelNameSecond+DeptName like '%" + keyword.Trim() + "%' ");
                Carsb.Append(" and SimpleInfo+Address like '%" + keyword.Trim() + "%' ");
            }
            

            var result = new InfCarChecksignBll().GetQuery(Casesb.ToString(),Carsb.ToString(), rows, page);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
