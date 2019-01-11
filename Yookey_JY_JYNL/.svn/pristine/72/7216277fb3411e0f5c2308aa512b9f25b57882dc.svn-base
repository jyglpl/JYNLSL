using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Business.LawPunishInformation;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.LawPunishInformation;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Admin.Controllers;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Model.Com;


namespace Yookey.WisdomClassed.SIP.Admin.Areas.SIP.Controllers
{
    public class LawPunishInformationController : BaseController
    {
        LegalPersonListBll _LegalBll = new LegalPersonListBll();
        NaturalPersonListBll _NaturalBLL = new NaturalPersonListBll();
        readonly ComResourceBll _comResourceBll = new ComResourceBll();    //数据字典
        //
        // GET: /ZFYWCL/LawPunishInformation/

        #region View
        public ActionResult LegalPersonIndex()
        {
            return View();
        }

        public ActionResult NaturalPersonIndex()
        {
            return View();
        }
        #endregion

        #region 删除方法
        ///// <summary>
        ///// 删除自然人
        ///// </summary>
        ///// <param name="Pk_Id"></param>
        ///// <returns></returns>
        //public JsonResult DeleNatural(string ids)
        //{
        //    var isOk = false;
        //    string[] id = ids.Split(',').ToArray();
        //    try
        //    {

        //        if (!string.IsNullOrEmpty(ids))
        //        {
        //            for (int i = 0; i < id.Length; i++)
        //            {
        //                isOk = _NaturalBLL.DeleNatural(id[i]);

        //            }

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        isOk = false;
        //    }
        //    var result = new StatusModel<DBNull>
        //    {
        //        rtState = isOk ? 1 : -1,
        //        rtData = null,
        //        rtObj = null,
        //        rtMsrg = "成功"
        //    };
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        ///// <summary>
        ///// 删除法人
        ///// </summary>
        ///// <param name="Pk_Id"></param>
        ///// <returns></returns>
        //public JsonResult DeleteLegalPer(string ids)
        //{
        //    var isOk = false;
        //    string[] id = ids.Split(',').ToArray();
        //    try
        //    {

        //        if (!string.IsNullOrEmpty(ids))
        //        {
        //            for (int i = 0; i < id.Length; i++)
        //            {
        //                isOk = _LegalBll.DeleteLegalPer(id[i]);
        //            }

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        isOk = false;
        //    }
        //    var result = new StatusModel<DBNull>
        //    {
        //        rtState = isOk ? 1 : -1,
        //        rtData = null,
        //        rtObj = null,
        //        rtMsrg = "成功"
        //    };
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        #endregion

        #region 自然人方法
        /// <summary>
        /// 自然人详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult NaturalPersonEdit(string id)
        {
            var entity = new NaturalPersonEntity();

            if (!string.IsNullOrEmpty(id))
            {
                var IndexdetailcCase = _NaturalBLL.GetSearchListForNaturalPerson(new NaturalPersonEntity { ID = id });
                if (IndexdetailcCase != null && IndexdetailcCase.Any())
                {

                    entity = IndexdetailcCase[0];
                }

            }

            #region 身份证
            var IdCardType = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0013" });
            IdCardType.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["IdCardTypes"] = new SelectList(IdCardType, "Id", "Rskey", entity.IdCardType);
            #endregion

            return View(entity);
        }

        //自然人信息展示
        public string GetCompany(string Name, int rows, int page, string sidx, string sord)
        {
            var data = _NaturalBLL.GetSearchResult(Name, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }


        /// <summary>
        /// 自然人新增修改
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public string SaveCorporation(NaturalPersonEntity entity, string Id)
        {
            string RtMsrg;
            int RtState;
            try
            {
                bool flag;
                var EntEntityList = _NaturalBLL.GetSearchListForNaturalPerson(new NaturalPersonEntity { ID = entity.ID });
                if (Id == "")
                {
                    var EntEntity = new NaturalPersonEntity();
                    EntEntity.ID = Guid.NewGuid().ToString();
                    EntEntity.NaturalName = entity.NaturalName;
                    EntEntity.IdCardType = entity.IdCardType;
                    EntEntity.IdCard = entity.IdCard;
                    EntEntity.IllegalName = entity.IllegalName;
                    EntEntity.DocumentNumber = entity.DocumentNumber;
                    EntEntity.PunishmentBasis = entity.PunishmentBasis;
                    EntEntity.PunishmentResults = entity.PunishmentResults;
                    EntEntity.FineMoney = entity.FineMoney;
                    EntEntity.DishonestSeverity = entity.DishonestSeverity;
                    EntEntity.DishonestValidity = entity.DishonestValidity;
                    EntEntity.OtherName = entity.OtherName;
                    EntEntity.DecidedTime = entity.DecidedTime;
                    EntEntity.InformationName = entity.InformationName;
                    EntEntity.Note = entity.Note;
                    EntEntity.MainDishonest = entity.MainDishonest;
                    EntEntity.PublicDeadline = entity.PublicDeadline;
                    EntEntity.IsPush = 1;
                    EntEntity.ROWSTATUS = 1;
                    EntEntity.CREATOR_ID = "";
                    EntEntity.CREATE_BY = "";
                    EntEntity.CREATE_ON = DateTime.Now;
                    EntEntity.UPDATE_ID = "";
                    EntEntity.UPDATE_BY = "";
                    EntEntity.UPDATE_ON = DateTime.Now;
                    flag = _NaturalBLL.InsertCorpora(EntEntity);
                }
                else
                {
                    var EntEntity = new NaturalPersonEntity();
                    EntEntity.ID = entity.ID;
                    EntEntity.NaturalName = entity.NaturalName;
                    EntEntity.IdCardType = entity.IdCardType;
                    EntEntity.IdCard = entity.IdCard;
                    EntEntity.IllegalName = entity.IllegalName;
                    EntEntity.DocumentNumber = entity.DocumentNumber;
                    EntEntity.PunishmentBasis = entity.PunishmentBasis;
                    EntEntity.PunishmentResults = entity.PunishmentResults;
                    EntEntity.FineMoney = entity.FineMoney;
                    EntEntity.DishonestSeverity = entity.DishonestSeverity;
                    EntEntity.DishonestValidity = entity.DishonestValidity;
                    EntEntity.OtherName = entity.OtherName;
                    EntEntity.DecidedTime = entity.DecidedTime;
                    EntEntity.InformationName = entity.InformationName;
                    EntEntity.Note = entity.Note;
                    EntEntity.MainDishonest = entity.MainDishonest;
                    EntEntity.PublicDeadline = entity.PublicDeadline;
                    EntEntity.IsPush = entity.IsPush;
                    EntEntity.ROWSTATUS = 1;
                    EntEntity.CREATOR_ID = "";
                    EntEntity.CREATE_BY = "";
                    EntEntity.CREATE_ON = DateTime.Now;
                    EntEntity.UPDATE_ID = "";
                    EntEntity.UPDATE_BY = "";
                    EntEntity.UPDATE_ON = DateTime.Now;
                    flag = _NaturalBLL.UpdateNatural(EntEntity);
                }
                RtMsrg = flag ? "保存成功" : "保存失败";
                RtState = flag ? (int)OperationState.Success : (int)OperationState.Failure;

            }
            catch (Exception ex)
            {
                RtState = (int)OperationState.Error;
                RtMsrg = ex.Message;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = RtMsrg,
                rtState = RtState
            };
            return CommonMethod.ToJson(rtEntity);
        }
        #endregion


        #region 法人方法
        /// <summary>
        /// 法人详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult LegalPersonEdit(string id)
        {
            var entity = new LegalPersonEntity();
            if (!string.IsNullOrEmpty(id))
            {
                var IndexdetailcCase = _LegalBll.GetSearchListForPerson(new LegalPersonEntity { ID = id });
                if (IndexdetailcCase != null && IndexdetailcCase.Any())
                {
                    entity = IndexdetailcCase[0];
                }
            }
            #region 身份证
            var LegalCardTypes = _comResourceBll.GetSearchResult(new ComResourceEntity { ParentId = "0013" });
            LegalCardTypes.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["LegalCardTypes"] = new SelectList(LegalCardTypes, "Id", "Rskey", entity.LegalCardType);
            #endregion
            return View(entity);
        }


        /// <summary>
        /// 查询法人列表
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string GetLw(string Name, int rows, int page, string sidx, string sord)
        {
            var data = _LegalBll.GetSearchResult(Name, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 法人新增修改
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public string SaveLw(LegalPersonEntity entity, string Id)
        {
            string RtMsrg;
            int RtState;
            try
            {
                bool flag;
                var EntEntityList = _LegalBll.GetSearchListForPerson(new LegalPersonEntity { ID = entity.ID });
                if (Id == "")
                {
                    var EntEntity = new LegalPersonEntity();
                    EntEntity.ID = Guid.NewGuid().ToString();
                    EntEntity.RegistraNumber = entity.RegistraNumber;
                    EntEntity.OrganizationCode = entity.OrganizationCode;
                    EntEntity.PunishmentName = entity.PunishmentName;
                    EntEntity.PunishmentCod = entity.PunishmentCod;
                    EntEntity.DocumentNumber = entity.DocumentNumber;
                    EntEntity.CategoryOne = entity.CategoryOne;
                    EntEntity.CategoryTwo = entity.CategoryTwo;
                    EntEntity.FineMoney = entity.FineMoney;
                    EntEntity.ConfiscateMoney = entity.ConfiscateMoney;
                    EntEntity.PunishmentReason = entity.PunishmentReason;
                    EntEntity.PunishmentBasis = entity.PunishmentBasis;
                    EntEntity.PunishmentVerdict = entity.PunishmentVerdict;
                    EntEntity.DishonestSeverity = entity.DishonestSeverity;
                    EntEntity.DishonestValidity = entity.DishonestValidity;
                    EntEntity.DecidedName = entity.DecidedName;
                    EntEntity.DecidedTime = entity.DecidedTime;
                    EntEntity.LegalName = entity.LegalName;
                    EntEntity.LegalCardType = entity.LegalCardType;
                    EntEntity.LegalCard = entity.LegalCard;
                    EntEntity.PunishmentDeadline = entity.PunishmentDeadline;
                    EntEntity.Implementation = entity.Implementation;
                    EntEntity.State = entity.State;
                    EntEntity.Scope = entity.Scope;
                    EntEntity.PublicDeadline = entity.PublicDeadline;
                    EntEntity.InformationName = entity.InformationName;
                    EntEntity.Note = entity.Note;
                    EntEntity.IsPush = 1;
                    EntEntity.ROWSTATUS = 1;
                    EntEntity.CREATOR_ID = "";
                    EntEntity.CREATE_BY = "";
                    EntEntity.CREATE_ON = DateTime.Now;
                    EntEntity.UPDATE_ID = "";
                    EntEntity.UPDATE_BY = "";
                    EntEntity.UPDATE_ON = DateTime.Now;
                    flag = _LegalBll.InsertLw(EntEntity);
                }
                else
                {
                    var EntEntity = new LegalPersonEntity();
                    EntEntity.ID = entity.ID;
                    EntEntity.RegistraNumber = entity.RegistraNumber;
                    EntEntity.OrganizationCode = entity.OrganizationCode;
                    EntEntity.PunishmentName = entity.PunishmentName;
                    EntEntity.PunishmentCod = entity.PunishmentCod;
                    EntEntity.DocumentNumber = entity.DocumentNumber;
                    EntEntity.CategoryOne = entity.CategoryOne;
                    EntEntity.CategoryTwo = entity.CategoryTwo;
                    EntEntity.FineMoney = entity.FineMoney;
                    EntEntity.ConfiscateMoney = entity.ConfiscateMoney;
                    EntEntity.PunishmentReason = entity.PunishmentReason;
                    EntEntity.PunishmentBasis = entity.PunishmentBasis;
                    EntEntity.PunishmentVerdict = entity.PunishmentVerdict;
                    EntEntity.DishonestSeverity = entity.DishonestSeverity;
                    EntEntity.DishonestValidity = entity.DishonestValidity;
                    EntEntity.DecidedName = entity.DecidedName;
                    EntEntity.DecidedTime = entity.DecidedTime;
                    EntEntity.LegalName = entity.LegalName;
                    EntEntity.LegalCardType = entity.LegalCardType;
                    EntEntity.LegalCard = entity.LegalCard;
                    EntEntity.PunishmentDeadline = entity.PunishmentDeadline;
                    EntEntity.Implementation = entity.Implementation;
                    EntEntity.State = entity.State;
                    EntEntity.Scope = entity.Scope;
                    EntEntity.PublicDeadline = entity.PublicDeadline;
                    EntEntity.InformationName = entity.InformationName;
                    EntEntity.Note = entity.Note;
                    EntEntity.IsPush = entity.IsPush;
                    EntEntity.ROWSTATUS = 1;
                    EntEntity.CREATOR_ID = "";
                    EntEntity.CREATE_BY = "";
                    EntEntity.CREATE_ON = DateTime.Now;
                    EntEntity.UPDATE_ID = "";
                    EntEntity.UPDATE_BY = "";
                    EntEntity.UPDATE_ON = DateTime.Now;
                    flag = _LegalBll.UpdateLw(EntEntity);
                }
                RtMsrg = flag ? "保存成功" : "保存失败";
                RtState = flag ? (int)OperationState.Success : (int)OperationState.Failure;

            }
            catch (Exception ex)
            {
                RtState = (int)OperationState.Error;
                RtMsrg = ex.Message;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = RtMsrg,
                rtState = RtState
            };
            return CommonMethod.ToJson(rtEntity);
        }
        #endregion

    }
}
