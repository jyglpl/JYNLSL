using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SQLConnStringRead;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.EnterpriseLibrary;
using Yookey.WisdomClassed.SIP.Model.EnterpriseLibrary;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers
{
    public class EnterpriseLibraryController : Controller
    {
        //
        // GET: /EnterpriseLibrary/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CompanyEdit()
        {
            return View();
        }


        /// <summary>
        /// 添加企业
        /// add by lpl
        /// 2019-1-10
        /// </summary>
        /// <param name="form">ajax数据集合</param>
        /// <returns></returns>
        public ActionResult CompanyAdd(FormCollection form)
        {
            if (new EnterpriseLibraryBll().PersistNewItem(new EnterpriseLibraryEntity()
            {
                Id = Guid.NewGuid().ToString(),
                CompanyType = form["companyType"],
                CompanyNature = form["companyNature"],
                CompanyLegalPerson = form["companyLegalPerson"],
                CompanySize = form["companySize"],
                CompanyName = form["companyName"],
                CompanyCardNum = form["companyCardNum"],
                CompanyPermitNum = form["companyPermitNum"],
                CompanyStreet = form["companyStreet"],
                CompanyAddress = form["companyAddress"],
                LegalPersonPhone = form["legalPersonPhone"],
                Phone = form["phone"],
                CompanyContacts = form["companyContacts"],
                IsImportant = form["isImportant"],
                ProductType = form["like"],
                Rowstatus = 1
            }))
            {

            }

            return Json("1", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// add by lpl
        /// 2019-1-10
        /// 绑定监管对象类型
        /// </summary>
        /// <returns></returns>
        public ActionResult BindCompantType()
        {
            var list =  new ComResourceBll().GetListByParentId("0002");
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// add by lpl
        /// 2019-1-10
        /// 绑定监管对象性质
        /// </summary>
        /// <returns></returns>
        public ActionResult BindCompantNature()
        {
            var list = new ComResourceBll().GetListByParentId("0003");
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// add by lpl
        /// 2019-1-10
        /// 绑定企业规模
        /// </summary>
        /// <returns></returns>
        public ActionResult BindCompanySize()
        {
            var list = new ComResourceBll().GetListByParentId("0005");
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// add by lpl
        /// 2019-1-10
        /// 绑定街道
        /// </summary>
        /// <returns></returns>
        public ActionResult BindCompanyStreet()
        {
            var list = new ComResourceBll().GetListByParentId("0006");
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// add by lpl
        /// 2019-1-10
        ///产品类型
        /// </summary>
        /// <returns></returns>
        public ActionResult BindProductType()
        {
            var list = new ComResourceBll().GetListByParentId("0004");
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
