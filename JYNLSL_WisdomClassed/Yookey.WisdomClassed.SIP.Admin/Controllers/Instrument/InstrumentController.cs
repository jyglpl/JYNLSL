using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Instrument;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Membership;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Instrument;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Instrument
{
    public class InstrumentController : BaseController
    {
        readonly ComResourceBll _comResourceBll = new ComResourceBll();    //数据字典
        readonly W_TYPETABLEBll _w_typeTABLEBll = new W_TYPETABLEBll();    //文书类型
        readonly WSTOCKRECORDBll _wstockrecordBll = new WSTOCKRECORDBll(); //文书入库
        readonly WSTOCKCRECORDBll _wstockcrecord = new WSTOCKCRECORDBll();//文书入库主表
        readonly WUNITSTORAGEBll _wunitstorageBll = new WUNITSTORAGEBll(); //入库表
        readonly WDEPTSTORAGEBll _wdeptstorageBll = new WDEPTSTORAGEBll(); //大队入库表
        readonly WZDSTORAGEBll _wzdstorageBll = new WZDSTORAGEBll(); //中队入库表
        readonly WSTOCKTABLEBll _wstocktableBll = new WSTOCKTABLEBll();
        readonly WBRIGADEBll _wbrigadeBll = new WBRIGADEBll();
        readonly WLYCRECORDBll _wlycrecordBll = new WLYCRECORDBll();//文书号个人总分配表
        readonly CrmUserBll _crmuserBll = new CrmUserBll();   //人员
        readonly CrmCompanyBll _crmcompanyBll = new CrmCompanyBll();//大队
        readonly CrmDepartmentBll _crmdepartmentBll = new CrmDepartmentBll(); //部门
        readonly W_TYPETABLEBll _wtypetableBll = new W_TYPETABLEBll();


        readonly WLYCRECORDEntity _wlycrecordEntity = new WLYCRECORDEntity();
        readonly WBRIGADEEntity _wbrigadeEntity = new WBRIGADEEntity();
        readonly CrmUserEntity _crmuserEntity = new CrmUserEntity(); //人员实体类
        readonly WSTOCKRECORDEntity _wstockrecordEntity = new WSTOCKRECORDEntity();//文书入库主表实体类
        readonly WSTOCKCRECORDEntity _wstockcrecordEntity = new WSTOCKCRECORDEntity();
        readonly WUNITSTORAGEEntity _wunitstorageEntity = new WUNITSTORAGEEntity();
        readonly WDEPTSTORAGEEntity _wdeptstorageEntity = new WDEPTSTORAGEEntity();//大队入库表
        readonly WZDSTORAGEEntity _wzdstorageEntity = new WZDSTORAGEEntity();
        readonly CrmDepartmentEntity _crmdepartmentEntity = new CrmDepartmentEntity();//部门
        readonly W_TYPETABLEEntity _wtypetableEntity = new W_TYPETABLEEntity();//文书类型

        readonly BaseDepartmentBll _crmDeptBll = new BaseDepartmentBll();
        readonly BaseCompanyBll _basecompanyBll = new BaseCompanyBll();
        //文书入库
        static DataTable dt;
        //文书领用
        static DataTable LYDt;
        //中队入库
        static DataTable ZDDt;
        //个人领用
        static DataTable UserDt;

        static int WID = 0;
        static string Index = "0";//文书编号与文书类别标号比较的索引开始值
        static string Length = "1";//文书编号与文书类别标号比较的索引长度
        /// <summary>
        /// 文书入库
        /// 添加日期：2017-03-13
        /// 添加人：叶念
        /// </summary>
        /// <returns></returns>
        public ActionResult InstrumentAdd()
        {
            var WsTypts = _w_typeTABLEBll.GetTypeTables();
            //文书类型
            WsTypts.Insert(0, new W_TYPETABLEEntity { WRSCODE = "", WRSKEY = "==请选择==" });
            ViewData["WsTypts"] = new SelectList(WsTypts, "WRSCODE", "WRSKEY");
            return View();
        }
        /// <summary>
        /// 文书领用
        /// </summary>
        /// <returns></returns>
        public ActionResult InstrumentGet()
        {
            var WsTypts = _w_typeTABLEBll.GetTypeTables();
            //文书类型
            WsTypts.Insert(0, new W_TYPETABLEEntity { WRSCODE = "", WRSKEY = "==请选择==" });
            ViewData["WsTypts"] = new SelectList(WsTypts, "WRSCODE", "WRSKEY");

            //执法部门
            var Companys = new CrmCompanyBll().GetAllEnforcementUnit();
            Companys.Insert(0, new CrmCompanyEntity { Id = "", FullName = "==请选择==" });
            ViewData["Companys"] = new SelectList(Companys, "Id", "FullName");
            return View();
        }

        /// <summary>
        /// 中队入库
        /// </summary>
        /// <returns></returns>
        public ActionResult InstrumentZDAdd()
        {
            var WsTypts = _w_typeTABLEBll.GetTypeTables();
            //文书类型
            WsTypts.Insert(0, new W_TYPETABLEEntity { WRSCODE = "", WRSKEY = "==请选择==" });
            ViewData["WsTypts"] = new SelectList(WsTypts, "WRSCODE", "WRSKEY");

            //执法部门
            //var Depts = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity { CompanyId = CurrentUser.CrmUser.CompanyId }).ToList();
            //Depts.Insert(0, new CrmDepartmentEntity { Id = "", FullName = "==请选择==" });
            //ViewData["Depts"] = new SelectList(Depts, "Id", "FullName");
            return View();
        }

        /// <summary>
        /// 个人领用
        /// </summary>
        /// <returns></returns>
        public ActionResult BrigadeGet()
        {
            var WsTypts = _w_typeTABLEBll.GetTypeTables();
            //文书类型
            WsTypts.Insert(0, new W_TYPETABLEEntity { WRSCODE = "", WRSKEY = "==请选择==" });
            ViewData["WsTypts"] = new SelectList(WsTypts, "WRSCODE", "WRSKEY");

            //人员
            var Users = _crmuserBll.GetUserList(new CrmUserEntity { DepartmentId = CurrentUser.CrmUser.DeptId }).ToList();
            Users.Insert(0, new CrmUserEntity { Id = "", RealName = "==请选择==" });
            ViewData["Users"] = new SelectList(Users, "Id", "RealName");
            return View();
        }

        /// <summary>
        /// 大队领用查询
        /// </summary>
        /// <returns></returns>
        public ActionResult InstrumentSelect()
        {
            var WsTypts = _w_typeTABLEBll.GetTypeTables();
            //文书类型
            WsTypts.Insert(0, new W_TYPETABLEEntity { WRSCODE = "", WRSKEY = "==请选择==" });
            ViewData["WsTypts"] = new SelectList(WsTypts, "WRSCODE", "WRSKEY");
            //大队
            var Companys = _crmcompanyBll.GetAllCompany();
            Companys.Insert(0, new CrmCompanyEntity { Id = "", FullName = "==请选择==" });
            ViewData["Companys"] = new SelectList(Companys, "Id", "FullName");
            return View();

        }


        public ActionResult InstrumentZDSelect()
        {
            var WsTypts = _w_typeTABLEBll.GetTypeTables();
            //文书类型
            WsTypts.Insert(0, new W_TYPETABLEEntity { WRSCODE = "", WRSKEY = "==请选择==" });
            ViewData["WsTypts"] = new SelectList(WsTypts, "WRSCODE", "WRSKEY");
            //大队
            //var Companys = _crmdepartmentBll.
            //Companys.Insert(0, new CrmCompanyEntity { Id = "", FullName = "==请选择==" });
            //ViewData["Companys"] = new SelectList(Companys, "Id", "FullName");
            return View();

        }
        public ActionResult InstrumentGRSelect()
        {
            var WsTypts = _w_typeTABLEBll.GetTypeTables();
            //文书类型
            WsTypts.Insert(0, new W_TYPETABLEEntity { WRSCODE = "", WRSKEY = "==请选择==" });
            ViewData["WsTypts"] = new SelectList(WsTypts, "WRSCODE", "WRSKEY");
            //大队
            var Companys = _crmcompanyBll.GetAllCompany();
            Companys.Insert(0, new CrmCompanyEntity { Id = "", FullName = "==请选择==" });
            ViewData["Companys"] = new SelectList(Companys, "Id", "FullName");
            return View();

        }

        public ActionResult InstrumentSearch()
        {
            var WsTypts = _w_typeTABLEBll.GetTypeTables();
            //文书类型
            WsTypts.Insert(0, new W_TYPETABLEEntity { WRSCODE = "", WRSKEY = "==请选择==" });
            ViewData["WsTypts"] = new SelectList(WsTypts, "WRSCODE", "WRSKEY");
            //大队
            var Companys = _crmcompanyBll.GetAllCompany();
            Companys.Insert(0, new CrmCompanyEntity { Id = "", FullName = "==请选择==" });
            ViewData["Companys"] = new SelectList(Companys, "Id", "FullName");
            return View();

        }
        /// <summary>
        /// 库存
        /// </summary>
        /// <returns></returns>
        public ActionResult StockSelect()
        {
            var WsTypts = _w_typeTABLEBll.GetTypeTables();
            //文书类型
            WsTypts.Insert(0, new W_TYPETABLEEntity { WRSCODE = "", WRSKEY = "==请选择==" });
            ViewData["WsTypts"] = new SelectList(WsTypts, "WRSCODE", "WRSKEY");
            //大队
            var Companys = _crmcompanyBll.GetAllCompany();
            Companys.Insert(0, new CrmCompanyEntity { Id = "", FullName = "==请选择==" });
            ViewData["Companys"] = new SelectList(Companys, "Id", "FullName");
            return View();

        }

        /// <summary>
        /// 文书种类配置
        /// </summary>
        /// <returns></returns>
        public ActionResult TypeTableIndex()
        {
            return View();
        }
        public ActionResult TypeEdit(string id)
        {
            W_TYPETABLEEntity Entity = new W_TYPETABLEEntity();
            Entity = _wtypetableBll.Get(id);
            return View(Entity);
        }

        /// <summary>
        /// 保存文书类型
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveTypeTable(W_TYPETABLEEntity entity)
        {
            var isOk = false;
            var rtMsg = "";
            var user = CurrentUser.CrmUser;
            try
            {
                entity.CreatorId = user.Id;
                entity.CreateBy = user.UserName;
                entity.CreateOn = DateTime.Now;
                entity.UpdateId = user.Id;
                entity.UpdateBy = user.UserName;
                entity.UpdateOn = DateTime.Now;
                isOk = _w_typeTABLEBll.SaveTypeTable(entity);
                if (isOk)
                {
                    rtMsg = "保存成功！";
                }
                else
                {
                    rtMsg = "保存异常，请联系管理员！";
                }
            }
            catch (Exception ex)
            {
                isOk = false;
                rtMsg = ex.Message;
            }
            var result = new StatusModel<object>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 删除文书类型
        /// </summary>
        /// <param name="TypeTableId"></param>
        /// <returns></returns>
        [HttpPost]
        public string DeleteTypeTable(string TypeTableId)
        {
            string rtMsrg;
            int rtState;
            try
            {
                var flag = _w_typeTABLEBll.BatchDelete(TypeTableId);
                rtMsrg = flag ? "删除成功" : "删除失败";
                rtState = flag ? (int)OperationState.Success : (int)OperationState.Failure;
            }
            catch (Exception ex)
            {
                rtState = (int)OperationState.Error;
                rtMsrg = ex.Message;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = rtMsrg,
                rtState = rtState
            };
            return CommonMethod.ToJson(rtEntity);
        }


        /// <summary>
        /// 领用查询 大队
        /// </summary>
        /// <param name="WsStart"></param>
        /// <param name="WsEnd"></param>
        /// <param name="Companyid"></param>
        /// <param name="WsTypts"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string QueryInstrumentList(string WsStart, string WsEnd, string Companyid, string WsTypts, int rows, int page, string sidx, string sord)
        {
            var data = _wunitstorageBll.GetInstrumentList(WsStart, WsEnd, Companyid, WsTypts, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WsStart"></param>
        /// <param name="WsEnd"></param>
        /// <param name="Companyid"></param>
        /// <param name="WsTypts"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string QueryZDInstrumentList(string WsStart, string WsEnd, string Departmentid, string WsTypts, int rows, int page, string sidx, string sord)
        {
            var data = _wunitstorageBll.QueryZDInstrumentList(WsStart, WsEnd, Departmentid, WsTypts, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }
        /// <summary>
        /// 个人查询
        /// </summary>
        /// <param name="WsStart"></param>
        /// <param name="WsEnd"></param>
        /// <param name="Companyid"></param>
        /// <param name="WsTypts"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string QueryGRInstrumentList(string WsStart, string WsEnd, string Departmentid, string userid, string WsTypts, int rows, int page, string sidx, string sord)
        {
            var data = _wunitstorageBll.QueryGRInstrumentList(WsStart, WsEnd, Departmentid, userid, WsTypts, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }


        /// <summary>
        /// 使用查询
        /// </summary>
        /// <param name="WsStart"></param>
        /// <param name="WsEnd"></param>
        /// <param name="Departmentid"></param>
        /// <param name="userid"></param>
        /// <param name="WsTypts"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string QueryInstrumentSearch(string WsStart, string WsEnd, string Departmentid, string userid, string WsTypts, string starttime, string endtime, string type, int rows, int page, string sidx, string sord)
        {


            var data = _wunitstorageBll.QueryInstrumentSearch(WsStart, WsEnd, Departmentid, userid, WsTypts, starttime, endtime, type, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 库存
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string QueryInstrumentSearchKC(string WsStart, string WsEnd, string WsTypts, int rows, int page, string sidx, string sord)
        {

            var data = _wunitstorageBll.QueryInstrumentSearchKC(WsStart, WsEnd, WsTypts, sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }

        /// <summary>
        /// 文书类型
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <returns></returns>
        public string QueryTypeTable(int rows, int page, string sidx, string sord)
        {

            var data = _wtypetableBll.QueryTypeTable(sidx, sord, rows, page);
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(data, timeConverter);
            return result;
        }



        /// <summary>
        /// 初始化dt
        /// </summary>
        void LoadDT()
        {
            if (dt == null)
            {
                dt = new DataTable();
            }
            if (dt.Rows.Count >= 1)
            {
                dt = new DataTable();
            }
            if (dt.Columns.Count > 0)
            {
            }
            else
            {
                DataColumn col0 = new DataColumn("Id");
                DataColumn col1 = new DataColumn("WRsCode");
                DataColumn col2 = new DataColumn("WRsKey");
                DataColumn col3 = new DataColumn("StarNo");
                DataColumn col4 = new DataColumn("EndNo");
                DataColumn col5 = new DataColumn("BCount");
                DataColumn col6 = new DataColumn("WCount");
                dt.Columns.Add(col0);
                dt.Columns.Add(col1);
                dt.Columns.Add(col2);
                dt.Columns.Add(col3);
                dt.Columns.Add(col4);
                dt.Columns.Add(col5);
                dt.Columns.Add(col6);
            }
        }
        /// <summary>
        /// 文书领用初始化
        /// </summary>
        void LoadLYDt()
        {
            if (LYDt == null)
            {
                LYDt = new DataTable();
            }
            if (LYDt.Rows.Count >= 1)
            {
                LYDt = new DataTable();
            }
            if (LYDt.Columns.Count > 0)
            {
            }
            else
            {
                DataColumn col0 = new DataColumn("Id");
                DataColumn col1 = new DataColumn("WRsCode");
                DataColumn col2 = new DataColumn("WRsKey");
                DataColumn col3 = new DataColumn("StarNo");
                DataColumn col4 = new DataColumn("EndNo");
                DataColumn col5 = new DataColumn("BCount");
                DataColumn col6 = new DataColumn("WCount");
                DataColumn col7 = new DataColumn("Dept");
                LYDt.Columns.Add(col0);
                LYDt.Columns.Add(col1);
                LYDt.Columns.Add(col2);
                LYDt.Columns.Add(col3);
                LYDt.Columns.Add(col4);
                LYDt.Columns.Add(col5);
                LYDt.Columns.Add(col6);
                LYDt.Columns.Add(col7);
            }
        }

        void LoadZDDt()
        {
            if (ZDDt == null)
            {
                ZDDt = new DataTable();
            }
            if (ZDDt.Rows.Count >= 1)
            {
                ZDDt = new DataTable();
            }
            if (ZDDt.Columns.Count > 0)
            {
            }
            else
            {
                DataColumn col0 = new DataColumn("Id");
                DataColumn col1 = new DataColumn("WRsCode");
                DataColumn col2 = new DataColumn("WRsKey");
                DataColumn col3 = new DataColumn("StarNo");
                DataColumn col4 = new DataColumn("EndNo");
                DataColumn col5 = new DataColumn("BCount");
                DataColumn col6 = new DataColumn("WCount");
                DataColumn col7 = new DataColumn("Dept");
                ZDDt.Columns.Add(col0);
                ZDDt.Columns.Add(col1);
                ZDDt.Columns.Add(col2);
                ZDDt.Columns.Add(col3);
                ZDDt.Columns.Add(col4);
                ZDDt.Columns.Add(col5);
                ZDDt.Columns.Add(col6);
                ZDDt.Columns.Add(col7);
            }
        }

        /// <summary>
        /// 个人领用
        /// </summary>
        void LoadUserDt()
        {
            if (UserDt == null)
            {
                UserDt = new DataTable();
            }
            if (UserDt.Rows.Count >= 1)
            {
                UserDt = new DataTable();
            }
            if (UserDt.Columns.Count > 0)
            {
            }
            else
            {
                DataColumn col0 = new DataColumn("Id");
                DataColumn col1 = new DataColumn("WRsCode");
                DataColumn col2 = new DataColumn("WRsKey");
                DataColumn col3 = new DataColumn("StarNo");
                DataColumn col4 = new DataColumn("EndNo");
                DataColumn col5 = new DataColumn("WCOUNT");
                DataColumn col6 = new DataColumn("UNAME");
                DataColumn col7 = new DataColumn("UserId");
                UserDt.Columns.Add(col0);
                UserDt.Columns.Add(col1);
                UserDt.Columns.Add(col2);
                UserDt.Columns.Add(col3);
                UserDt.Columns.Add(col4);
                UserDt.Columns.Add(col5);
                UserDt.Columns.Add(col6);
                UserDt.Columns.Add(col7);
            }
        }

        public string GetEndNo(string StartNo, int WCount)
        {
            if (StartNo == "")
            {
                return "";
            }
            else
            {
                string prefix = "";
                string No = StartNo;
                if (StartNo.Length >= 10)
                {
                    prefix = StartNo.Substring(0, StartNo.Length - 9);
                    No = StartNo.Remove(0, StartNo.Length - 9);
                }

                No = "1" + No;

                string EndNo = prefix + (Convert.ToInt32(No) + WCount - 1).ToString().Remove(0, 1);
                return EndNo;
            }
        }
        /// <summary>
        /// 验证文书输入内容是否正确
        /// </summary>
        /// <param name="WsTypts">文书类型</param>
        /// <param name="WsStart"></param>
        /// <param name="WsEnd"></param>
        /// <returns></returns>
        public string CheckWs(string WsTypts, string WsStart, string WsEnd)
        {
            LoadDT();
            var isOk = false;
            var rtMsg = "";
            var data = new DataTable();
            DataRow dr = dt.NewRow();
            if (!string.IsNullOrEmpty(WsTypts))
            {
                if (WsStart.Length <= Convert.ToInt32(Length) + 1 || WsEnd.Length <= Convert.ToInt32(Length) + 1)
                {
                    rtMsg = "请输入正确的文书编号！";

                }
                else
                {
                    DataTable WType = _w_typeTABLEBll.GetWTypeByWRsCode(WsTypts);//根据文书类别代码查询文书类别
                    int BCount = 0;
                    if (WType.Rows.Count == 0 || WType == null)//判断当前输入的文书名称是否存在
                    {
                        rtMsg = "当前文书类别不存在！";
                    }
                    else
                    {
                        int WCount = Convert.ToInt32(WsEnd) - Convert.ToInt32(WsStart) + Convert.ToInt32(WType.Rows[0]["WCount"]);//获得录入的文书的总张数
                        if (WCount % Convert.ToInt32(WType.Rows[0]["WCount"]) != 0)
                        {//判断最后组和第一组之间的文书不是整本
                            rtMsg = "请整本输入！";
                        }
                        else
                        {
                            string WEndNo = GetEndNo(WsStart, WCount);//获得文书的结束编号
                            dr[0] = WID;
                            dr[1] = WType.Rows[0]["WRsCode"];
                            dr[2] = WType.Rows[0]["WRsKey"];
                            dr[3] = WsStart;
                            dr[4] = WEndNo;
                            dr[5] = BCount;
                            dr[6] = WCount;
                            int sun = 0;//计数统计
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dr[3]) > Convert.ToInt32(dt.Rows[i]["EndNo"]) || Convert.ToInt32(dr[4]) < Convert.ToInt32(dt.Rows[i]["StarNo"]) || dr[1].ToString() != dt.Rows[i]["WRsCode"].ToString())
                                {//如果当前开始编号大于DT中的结束编号，或者当前结束编号小于DT中的开始编号


                                    sun++;
                                }
                            }

                            if (sun == dt.Rows.Count)
                            {
                                isOk = true;

                            }
                            else
                            {//如果小于dt的行数表示和dt中的文书编号有重复的数据
                                rtMsg = "添加的文书有重复";
                            }
                        }
                    }
                }
            }
            else
            {
                rtMsg = "请选择文书名称";
            }

            var result = new StatusModel<object>
            {
                rtState = 1,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsg
            };
            return JsonConvert.SerializeObject(result);
        }

        /// <summary>
        /// 个人领用验证
        /// </summary>
        /// <param name="WsTypts"></param>
        /// <param name="WsStart"></param>
        /// <param name="WsEnd"></param>
        /// <returns></returns>
        public string CheckGRWs(string WsTypts, string WsStart, string WsEnd, string UserId)
        {
            LoadUserDt();
            var isOk = false;
            var rtMsg = "";

            try
            {

                DataRow dr = UserDt.NewRow();
                if (!string.IsNullOrEmpty(WsTypts))
                {
                    if (WsStart.Length <= Convert.ToInt32(Length) + 1 || WsEnd.Length <= Convert.ToInt32(Length) + 1)
                    {
                        rtMsg = "请输入正确的文书编号";
                    }
                    if (Convert.ToInt32(WsStart) - Convert.ToInt32(WsEnd) > 0)
                    {
                        rtMsg = "开始编号不能大于结束编号";
                    }
                    if (Convert.ToInt32(WsStart) - Convert.ToInt32(WsEnd) == 0)
                    {
                        rtMsg = "开始编号不能等于结束编号";
                    }
                    else
                    {
                        DataTable WType = _w_typeTABLEBll.GetWTypeByWRsCode(WsTypts);//根据文书类别代码查询文书类别
                        //判断分配的文书号是否正确
                        DataTable DTIsGet = _wzdstorageBll.IsGet(WsStart, WsEnd, WType.Rows[0]["WRsCode"].ToString(), _crmuserBll.GetUserList(new CrmUserEntity { Id = UserId })[0].DepartmentId);
                        if (WType.Rows.Count == 0 || WType == null)//判断当前输入的文书名称是否存在
                        {
                            rtMsg = "当前文书类别不存在";
                        }
                        else if (DTIsGet.Rows[0]["num"].ToString ()!= Convert.ToString(Convert.ToInt32(WsEnd) - Convert.ToInt32(WsStart) + 1)) //(Convert.ToInt32(DTIsGet.Rows[0]["num"]) == Convert.ToInt32(UserDt.Rows[0]["WCOUNT"]))//
                        {
                            rtMsg = "请检查开始编号、结束编号是否正确";
                        }
                        else
                        {
                            dr[0] = WID;
                            dr[1] = WType.Rows[0]["WRsCode"];
                            dr[2] = WType.Rows[0]["WRsKey"];
                            dr[3] = WsStart;
                            dr[4] = WsEnd;
                            dr[5] = Convert.ToString(Convert.ToInt32(WsEnd) - Convert.ToInt32(WsStart) + 1);
                            dr[6] = _crmuserBll.GetUserList(new CrmUserEntity { Id = UserId })[0].RealName;
                            dr[7] = UserId;
                            int sun = 0;//计数统计
                            for (int i = 0; i < UserDt.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dr[3]) > Convert.ToInt32(UserDt.Rows[i]["EndNo"]) || Convert.ToInt32(dr[4]) < Convert.ToInt32(UserDt.Rows[i]["StarNo"]))
                                {
                                    //如果当前开始编号大于DT中的结束编号，或者当前结束编号小于DT中的开始编号
                                    sun++;
                                }
                            }
                            if (sun == UserDt.Rows.Count)
                            {
                                isOk = true;
                            }
                            else
                            {
                                //如果小于dt的行数表示和dt中的文书编号有重复的数据
                                rtMsg = "添加的文书有重复";
                            }

                        }
                    }

                }
                else
                {
                    rtMsg = "请选择文书名称";
                }
            }

            catch (Exception ex)
            {
                rtMsg = ex.ToString();
            }
            var result = new StatusModel<object>
        {
            rtState = 1,
            rtData = null,
            rtObj = null,
            rtMsrg = rtMsg
        };
            return JsonConvert.SerializeObject(result);
        }

        public string QueryWsTyptList(string WsTypts, string WsStart, string WsEnd)
        {
            System.Object ob = new object();
            lock (ob)
            {
                dt = InstrumentDT(WsTypts, WsStart, WsEnd);
                var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
                var result = JsonConvert.SerializeObject(dt, timeConverter);
                return result;
            }

        }


        public string QueryInstrumentGet(string WsTypts, string WsStart, string WsEnd, string Deptid)
        {
            System.Object ob = new object();
            lock (ob)
            {
                LYDt = InstrumentLYDT(WsTypts, WsStart, WsEnd, Deptid);
                var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
                var result = JsonConvert.SerializeObject(LYDt, timeConverter);
                return result;
            }
        }

        public string QueryInstrumentZD(string WsTypts, string WsStart, string WsEnd, string DeptId)
        {
            System.Object ob = new object();
            lock (ob)
            {
                ZDDt = InstrumentZDDT(WsTypts, WsStart, WsEnd, DeptId);
                var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
                var result = JsonConvert.SerializeObject(ZDDt, timeConverter);
                return result;
            }
        }

        /// <summary>
        /// 个人领用
        /// </summary>
        /// <param name="WsTypts"></param>
        /// <param name="WsStart"></param>
        /// <param name="WsEnd"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public string QueryInstrumentGR(string WsTypts, string WsStart, string WsEnd, string UserId)
        {

            System.Object ob = new object();
            lock (ob)
            {
                UserDt = InstrumentGRDT(WsTypts, WsStart, WsEnd, UserId);
                var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
                var result = JsonConvert.SerializeObject(UserDt, timeConverter);
                return result;
            }
        }




        /// <summary>
        /// 文书领用
        /// </summary>
        /// <param name="WsTypts"></param>
        /// <param name="WsStart"></param>
        /// <param name="WsEnd"></param>
        /// <returns></returns>
        public DataTable InstrumentLYDT(string WsTypts, string WsStart, string WsEnd, string Deptid)
        {
            LoadLYDt();
            var isOk = false;
            var data = new DataTable();

            DataRow dr = LYDt.NewRow();
            if (!string.IsNullOrEmpty(WsTypts))
            {

                DataTable WType = _w_typeTABLEBll.GetWTypeByWRsCode(WsTypts);//根据文书类别代码查询文书类别
                int BCount = 0;


                int WCount = Convert.ToInt32(WsEnd) - Convert.ToInt32(WsStart) + Convert.ToInt32(WType.Rows[0]["WCount"]);//获得录入的文书的总张数
                BCount = WCount / Convert.ToInt32(WType.Rows[0]["WCount"]);//获得文书本数
                string prefix = WsEnd.Substring(Convert.ToInt32(Index), Convert.ToInt32(Length));//获得文书前缀
                if (prefix != "0")
                {
                    prefix = "";
                }

                int postfix = Convert.ToInt32(WsEnd.Substring(Convert.ToInt32(Length) - 1)); ;//获得文书最后组编号后缀
                string WEndNo = GetEndNo(WsStart, WCount);//获得文书的结束编号

                dr[0] = WID;
                dr[1] = WType.Rows[0]["WRsCode"];
                dr[2] = WType.Rows[0]["WRsKey"];
                dr[3] = WsStart;
                dr[4] = WEndNo;
                dr[5] = BCount;
                dr[6] = WCount;
                dr[7] = _basecompanyBll.GetCompanyNameByID(Deptid)[0].FullName;

                int sun = 0;//计数统计
                for (int i = 0; i < LYDt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dr[3]) > Convert.ToInt32(LYDt.Rows[i]["EndNo"]) || Convert.ToInt32(dr[4]) < Convert.ToInt32(LYDt.Rows[i]["StarNo"]) || dr[1].ToString() != LYDt.Rows[i]["WRsCode"].ToString())
                    {//如果当前开始编号大于DT中的结束编号，或者当前结束编号小于DT中的开始编号

                        sun++;
                    }
                }
                LYDt.Rows.Add(dr);//将行加入到dt中
                WID++;
                data = LYDt;

            }
            return data;
        }

        public DataTable InstrumentZDDT(string WsTypts, string WsStart, string WsEnd, string Deptid)
        {

            LoadZDDt(); var isOk = false;
            var data = new DataTable();

            DataRow dr = ZDDt.NewRow();
            if (!string.IsNullOrEmpty(WsTypts))
            {

                DataTable WType = _w_typeTABLEBll.GetWTypeByWRsCode(WsTypts);//根据文书类别代码查询文书类别
                int BCount = 0;


                int WCount = Convert.ToInt32(WsEnd) - Convert.ToInt32(WsStart) + Convert.ToInt32(WType.Rows[0]["WCount"]);//获得录入的文书的总张数
                BCount = WCount / Convert.ToInt32(WType.Rows[0]["WCount"]);//获得文书本数
                string prefix = WsEnd.Substring(Convert.ToInt32(Index), Convert.ToInt32(Length));//获得文书前缀
                if (prefix != "0")
                {
                    prefix = "";
                }

                int postfix = Convert.ToInt32(WsEnd.Substring(Convert.ToInt32(Length) - 1)); ;//获得文书最后组编号后缀
                string WEndNo = GetEndNo(WsStart, WCount);//获得文书的结束编号

                dr[0] = WID;
                dr[1] = WType.Rows[0]["WRsCode"];
                dr[2] = WType.Rows[0]["WRsKey"];
                dr[3] = WsStart;
                dr[4] = WEndNo;
                dr[5] = BCount;
                dr[6] = WCount;
                dr[7] = _crmDeptBll.Get(Deptid).FullName;//中队

                int sun = 0;//计数统计
                for (int i = 0; i < ZDDt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dr[3]) > Convert.ToInt32(ZDDt.Rows[i]["EndNo"]) || Convert.ToInt32(dr[4]) < Convert.ToInt32(ZDDt.Rows[i]["StarNo"]) || dr[1].ToString() != ZDDt.Rows[i]["WRsCode"].ToString())
                    {//如果当前开始编号大于DT中的结束编号，或者当前结束编号小于DT中的开始编号

                        sun++;
                    }
                }
                ZDDt.Rows.Add(dr);//将行加入到dt中
                WID++;
                data = ZDDt;

            }
            return data;
        }

        public DataTable InstrumentGRDT(string WsTypts, string WsStart, string WsEnd, string UserId)
        {
            LoadUserDt(); var isOk = false;
            var data = new DataTable();

            DataRow dr = UserDt.NewRow();
            if (!string.IsNullOrEmpty(WsTypts))
            {

                DataTable WType = _w_typeTABLEBll.GetWTypeByWRsCode(WsTypts);//根据文书类别代码查询文书类别


                dr[0] = WID;
                dr[1] = WType.Rows[0]["WRsCode"];
                dr[2] = WType.Rows[0]["WRsKey"];
                dr[3] = WsStart;
                dr[4] = WsEnd;
                dr[5] = Convert.ToString(Convert.ToInt32(WsEnd) - Convert.ToInt32(WsStart) + 1);
                dr[6] = _crmuserBll.GetUserList(new CrmUserEntity { Id = UserId })[0].RealName;//用户姓名
                dr[7] = UserId;

                int sun = 0;//计数统计
                for (int i = 0; i < UserDt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dr[3]) > Convert.ToInt32(UserDt.Rows[i]["EndNo"]) || Convert.ToInt32(dr[4]) < Convert.ToInt32(UserDt.Rows[i]["StarNo"]) || dr[1].ToString() != UserDt.Rows[i]["WRsCode"].ToString())
                    {//如果当前开始编号大于DT中的结束编号，或者当前结束编号小于DT中的开始编号

                        sun++;
                    }
                }
                UserDt.Rows.Add(dr);//将行加入到dt中
                WID++;
                data = UserDt;

            }
            return data;
        }

        /// <summary>
        /// 文书入库
        /// </summary>
        /// <param name="WsTypts"></param>
        /// <param name="WsStart"></param>
        /// <param name="WsEnd"></param>
        /// <returns></returns>
        public DataTable InstrumentDT(string WsTypts, string WsStart, string WsEnd)
        {
            LoadDT();

            var isOk = false;

            var data = new DataTable();

            DataRow dr = dt.NewRow();
            if (!string.IsNullOrEmpty(WsTypts))
            {

                DataTable WType = _w_typeTABLEBll.GetWTypeByWRsCode(WsTypts);//根据文书类别代码查询文书类别
                int BCount = 0;


                int WCount = Convert.ToInt32(WsEnd) - Convert.ToInt32(WsStart) + Convert.ToInt32(WType.Rows[0]["WCount"]);//获得录入的文书的总张数
                BCount = WCount / Convert.ToInt32(WType.Rows[0]["WCount"]);//获得文书本数
                string prefix = WsEnd.Substring(Convert.ToInt32(Index), Convert.ToInt32(Length));//获得文书前缀
                if (prefix != "0")
                {
                    prefix = "";
                }

                int postfix = Convert.ToInt32(WsEnd.Substring(Convert.ToInt32(Length) - 1)); ;//获得文书最后组编号后缀
                string WEndNo = GetEndNo(WsStart, WCount);//获得文书的结束编号

                dr[0] = WID;
                dr[1] = WType.Rows[0]["WRsCode"];
                dr[2] = WType.Rows[0]["WRsKey"];
                dr[3] = WsStart;
                dr[4] = WEndNo;
                dr[5] = BCount;
                dr[6] = WCount;

                int sun = 0;//计数统计
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dr[3]) > Convert.ToInt32(dt.Rows[i]["EndNo"]) || Convert.ToInt32(dr[4]) < Convert.ToInt32(dt.Rows[i]["StarNo"]) || dr[1].ToString() != dt.Rows[i]["WRsCode"].ToString())
                    {//如果当前开始编号大于DT中的结束编号，或者当前结束编号小于DT中的开始编号

                        sun++;
                    }
                }
                dt.Rows.Add(dr);//将行加入到dt中
                WID++;
                data = dt;

            }
            return data;
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveInstrument(string WsTypts, string WsStart, string WsEnd)
        {
            dt = InstrumentDT(WsTypts, WsStart, WsEnd);
            bool IsAdd = true;
            bool IsSave = false;
            var rtMsg = "";
            var rtState = 1;
            try
            {

                List<string> strlist = new List<string>();

                if (dt.Rows.Count > 0 && dt != null)
                {
                    string RecordID = Guid.NewGuid().ToString();//生成入库主表编号
                    string Title = DateTime.Now.ToString() + dt.Rows[0]["WRsKey"].ToString() + CurrentUser.CrmUser.UserName + "入库";//生成入库主表的标题
                    string dept = CurrentUser.CrmUser.DeptId;
                    int IsUnit = -1;//是否为大队入库

                    _wstockrecordEntity.Id = Guid.NewGuid().ToString();//生成入库主表编号
                    _wstockrecordEntity.RECORDID = RecordID;
                    _wstockrecordEntity.TITLE = Title;
                    _wstockrecordEntity.DEPTID = dept;
                    _wstockrecordEntity.ISUNIT = IsUnit;
                    _wstockrecordEntity.CREATEBY = CurrentUser.CrmUser.UserName;
                    _wstockrecordEntity.CREATEDATE = DateTime.Now;
                    _wstockrecordEntity.CreateOn = DateTime.Now;

                    _wstockrecordEntity.UpdateBy = CurrentUser.CrmUser.UserName;
                    _wstockrecordEntity.UpdateOn = DateTime.Now;

                    string sql1 = _wstockrecordBll.SaveWSTOCKRECOR(_wstockrecordEntity);
                    strlist.Add(sql1);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {//循环GridView记录的的每一条信息
                        IsAdd = _wstockrecordBll.GetStockAdd(dt.Rows[i]["StarNo"].ToString(), dt.Rows[i]["EndNo"].ToString(), dt.Rows[i]["WRsCode"].ToString(), DateTime.Now.ToString("yyyy"));//判断录入的文书编号能不能添加到数据库中（true表示当前库存表没有该编号，false表示当前库存表有该编号）
                        if (IsAdd == true)
                        {
                            string ChildID = Guid.NewGuid().ToString();//生成入库子表编号
                            _wstockcrecordEntity.CHILDID = ChildID;
                            _wstockcrecordEntity.Id = Guid.NewGuid().ToString();
                            _wstockcrecordEntity.WSTYPE = dt.Rows[i]["WRsCode"].ToString();
                            _wstockcrecordEntity.BCOUNT = Convert.ToInt32(dt.Rows[i]["BCount"]);
                            _wstockcrecordEntity.WCOUNT = Convert.ToInt32(dt.Rows[i]["WCount"]);
                            _wstockcrecordEntity.WSTARTNO = dt.Rows[i]["StarNo"].ToString();
                            _wstockcrecordEntity.WENDNO = dt.Rows[i]["EndNo"].ToString();
                            _wstockcrecordEntity.RowStatus = 1;
                            _wstockcrecordEntity.CreatorId = CurrentUser.CrmUser.Id;
                            _wstockcrecordEntity.CreateOn = DateTime.Now;
                            _wstockcrecordEntity.UpdateId = CurrentUser.CrmUser.Id;
                            _wstockcrecordEntity.UpdateBy = CurrentUser.CrmUser.Id;
                            _wstockcrecordEntity.UpdateOn = DateTime.Now;
                            _wstockcrecordEntity.RECORDID = RecordID;


                            string str2 = _wstockcrecord.SaveWSTOCKCRECORD(_wstockcrecordEntity);//入库子表的添加语句
                            strlist.Add(str2);
                            int count = Convert.ToInt32(dt.Rows[i]["WCount"]);
                            string prefix = dt.Rows[i]["StarNo"].ToString().Substring(Convert.ToInt32(Index), Convert.ToInt32(Length));
                            int StarNo = Convert.ToInt32(dt.Rows[i]["StarNo"].ToString().Substring(Convert.ToInt32(Length) - 1));
                            string WsNo = dt.Rows[i]["StarNo"].ToString();
                            for (int j = 0; j < count; j++)
                            {//根据每行中中开始编号和结束编号循环每一个文书编号

                                string AutoID = Guid.NewGuid().ToString();//生成中队入库明细表编号
                                _wunitstorageEntity.AUTOID = AutoID;

                                _wunitstorageEntity.Id = Guid.NewGuid().ToString();
                                _wunitstorageEntity.WSTYPE = dt.Rows[i]["WRsCode"].ToString();
                                _wunitstorageEntity.RECORDID = RecordID;
                                _wunitstorageEntity.INVALID = "";
                                _wunitstorageEntity.DESID = "";
                                _wunitstorageEntity.LYPID = "";
                                _wunitstorageEntity.UNIT = dept;
                                _wunitstorageEntity.WSNO = WsNo;
                                _wunitstorageEntity.WSTATE = 0;
                                _wunitstorageEntity.RowStatus = 1;
                                _wunitstorageEntity.CreatorId = CurrentUser.CrmUser.Id;
                                _wunitstorageEntity.CreateOn = DateTime.Now;
                                _wunitstorageEntity.UpdateId = CurrentUser.CrmUser.Id;
                                _wunitstorageEntity.UpdateBy = CurrentUser.CrmUser.Id;
                                _wunitstorageEntity.UpdateOn = DateTime.Now;


                                string sql3 = _wunitstorageBll.InsertWUNITSTORAGE(_wunitstorageEntity);//大队入库明细表的添加语句
                                strlist.Add(sql3);
                                WsNo = GetEndNo(WsNo, 2);
                            }

                            string sql4 = _wstocktableBll.UpdateWSTOCKTABLE(count, count, dt.Rows[i]["WRsCode"].ToString());
                            strlist.Add(sql4);
                        }
                        else
                        {
                            rtMsg = "当前库存已有录入的文书";
                            IsSave = false;
                            rtState = -1;
                        }
                    }

                    if (IsAdd != false)
                    {
                        _wstockcrecord.InsertStock(strlist);//入库
                        IsSave = true;
                    }
                }

                else
                {
                    rtMsg = "请先录入数据";
                    IsSave = false;
                    rtState = -1;
                }


            }
            catch (Exception ex)
            {
                IsSave = false;
                rtMsg = ex.Message;
            }
            var result = new StatusModel<object>
            {
                rtState = rtState,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsg
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public bool SaveZD(string RecordID, string WsStart, string WsTypts, string WsEnd, string Deptid)
        {
            bool IsAdd = true;
            bool IsSave = true;
            try
            {

                string selectType = WsTypts;
                StringBuilder strb = new StringBuilder();
                List<string> strlist = new List<string>();
                ZDDt = InstrumentZDDT(WsTypts, WsStart, WsEnd, Deptid);
                if (ZDDt.Rows.Count > 0 && ZDDt != null)
                {
                    string Title = DateTime.Now.ToString() + ZDDt.Rows[0]["WRsKey"].ToString() + CurrentUser.CrmUser.UserName + "给" + _crmDeptBll.Get(Deptid).FullName + "领用入库";//生成入库主表的标题
                    string dept = Deptid;//CurrentUser.CrmUser.CompanyId;
                    int IsUnit = 0;//是否为支队入库
                    _wstockrecordEntity.Id = Guid.NewGuid().ToString();
                    _wstockrecordEntity.RECORDID = RecordID;
                    _wstockrecordEntity.TITLE = Title;
                    _wstockrecordEntity.DEPTID = dept;
                    _wstockrecordEntity.ISUNIT = IsUnit;
                    _wstockrecordEntity.CreateBy = CurrentUser.CrmUser.UserName;
                    _wstockrecordEntity.RowStatus = 1;
                    _wstockrecordEntity.CREATEBY = CurrentUser.CrmUser.UserName;
                    _wstockrecordEntity.CREATEDATE = DateTime.Now;
                    _wstockrecordEntity.CreateOn = DateTime.Now;
                    _wstockrecordEntity.CreatorId = CurrentUser.CrmUser.Id;
                    _wstockrecordEntity.UpdateBy = CurrentUser.CrmUser.UserName;
                    _wstockrecordEntity.UpdateId = CurrentUser.CrmUser.Id;
                    _wstockrecordEntity.UpdateOn = DateTime.Now;

                    string sql1 = _wstockrecordBll.SaveWSTOCKRECOR(_wstockrecordEntity);//入库主表的添加语句
                    strlist.Add(sql1);
                    for (int i = 0; i < ZDDt.Rows.Count; i++)
                    {//循环GridView记录的的每一条信息
                        //判断录入的文书编号能不能添加到数据库中（true表示当前库存表没有该编号，false表示当前库存表有该编号）
                        IsAdd = _wstockrecordBll.GetStockZDAdd(ZDDt.Rows[i]["StarNo"].ToString(), ZDDt.Rows[i]["EndNo"].ToString(), ZDDt.Rows[i]["WRsCode"].ToString(), DateTime.Now.ToString("yyyy"));
                        if (IsAdd == true)
                        {
                            string ChildID = Guid.NewGuid().ToString();//生成入库子表编号
                            //入库子表的实体类赋值
                            _wstockcrecordEntity.Id = Guid.NewGuid().ToString();
                            _wstockcrecordEntity.CHILDID = ChildID;
                            _wstockcrecordEntity.RECORDID = RecordID;
                            _wstockcrecordEntity.WSTYPE = ZDDt.Rows[i]["WRsCode"].ToString();
                            _wstockcrecordEntity.BCOUNT = Convert.ToInt32(ZDDt.Rows[i]["BCount"]);
                            _wstockcrecordEntity.WCOUNT = Convert.ToInt32(ZDDt.Rows[i]["WCount"]);
                            _wstockcrecordEntity.WSTARTNO = ZDDt.Rows[i]["StarNo"].ToString();
                            _wstockcrecordEntity.WENDNO = ZDDt.Rows[i]["EndNo"].ToString();
                            _wstockcrecordEntity.UpdateBy = CurrentUser.CrmUser.UserName;
                            _wstockcrecordEntity.UpdateId = CurrentUser.CrmUser.Id;
                            _wstockcrecordEntity.UpdateOn = DateTime.Now;
                            _wstockcrecordEntity.CreateOn = DateTime.Now;
                            _wstockcrecordEntity.RowStatus = 1;


                            string str2 = _wstockcrecord.SaveWSTOCKCRECORD(_wstockcrecordEntity);//入库子表的添加语句
                            strlist.Add(str2);
                            int count = Convert.ToInt32(ZDDt.Rows[i]["WCount"]);
                            string prefix = ZDDt.Rows[i]["StarNo"].ToString().Substring(Convert.ToInt32(Index), Convert.ToInt32(Length));
                            int StarNo = Convert.ToInt32(ZDDt.Rows[i]["StarNo"].ToString().Substring(Convert.ToInt32(Length) - 1));
                            string WsNo = ZDDt.Rows[i]["StarNo"].ToString();
                            for (int j = 0; j < count; j++)
                            {//根据每行中中开始编号和结束编号循环每一个文书编号
                                string AutoID = Guid.NewGuid().ToString();//生成中队入库明细表编号
                                //大队入库表中赋值
                                _wzdstorageEntity.Id = Guid.NewGuid().ToString();
                                _wzdstorageEntity.AUTOID = AutoID;
                                _wzdstorageEntity.WSTYPE = ZDDt.Rows[i]["WRsCode"].ToString();
                                _wzdstorageEntity.RECORDID = RecordID;
                                _wzdstorageEntity.INVALID = "";
                                _wzdstorageEntity.DESID = "";
                                _wzdstorageEntity.USEID = "";
                                _wzdstorageEntity.DEPTID = Deptid;
                                _wzdstorageEntity.WSNO = WsNo;
                                _wzdstorageEntity.WSTATE = 0;
                                _wzdstorageEntity.RowStatus = 1;
                                _wzdstorageEntity.CreateBy = CurrentUser.CrmUser.UserName;
                                _wzdstorageEntity.CreatorId = CurrentUser.CrmUser.Id;
                                _wzdstorageEntity.CreateOn = DateTime.Now;
                                _wzdstorageEntity.UpdateBy = CurrentUser.CrmUser.UserName;
                                _wzdstorageEntity.UpdateId = CurrentUser.CrmUser.Id;
                                _wzdstorageEntity.UpdateOn = DateTime.Now;
                                string sql3 = _wzdstorageBll.InsertWZDSTORAGE(_wzdstorageEntity);
                                strlist.Add(sql3);
                                WsNo = GetEndNo(WsNo, 2);

                            }

                        }
                        else
                        {

                            IsSave = false;
                        }
                    }

                    if (IsAdd != false)
                    {
                        _wstockcrecord.InsertStock(strlist);//入库
                    }


                }
            }
            catch (Exception ex)
            {

            }
            return IsSave;
        }

        public bool Save(string RecordID, string WsStart, string WsTypts, string WsEnd, string Deptid)
        {
            bool IsAdd = true;
            bool IsSave = true;
            try
            {

                string selectType = WsTypts;
                StringBuilder strb = new StringBuilder();
                List<string> strlist = new List<string>();
                LYDt = InstrumentLYDT(WsTypts, WsStart, WsEnd, Deptid);
                if (LYDt.Rows.Count > 0 && LYDt != null)
                {
                    string Title = DateTime.Now.ToString() + LYDt.Rows[0]["WRsKey"].ToString() + CurrentUser.CrmUser.UserName + "给" + _basecompanyBll.GetCompanyNameByID(Deptid)[0].FullName + "领用入库";//生成入库主表的标题
                    string dept = Deptid;  // CurrentUser.CrmUser.CompanyId;
                    int IsUnit = 1;//是否为大队入库
                    _wstockrecordEntity.Id = Guid.NewGuid().ToString();
                    _wstockrecordEntity.RECORDID = RecordID;
                    _wstockrecordEntity.TITLE = Title;
                    _wstockrecordEntity.DEPTID = dept;
                    _wstockrecordEntity.ISUNIT = IsUnit;
                    _wstockrecordEntity.CreateBy = CurrentUser.CrmUser.UserName;
                    _wstockrecordEntity.RowStatus = 1;
                    _wstockrecordEntity.CREATEBY = CurrentUser.CrmUser.UserName;
                    _wstockrecordEntity.CREATEDATE = DateTime.Now;
                    _wstockrecordEntity.CreateOn = DateTime.Now;
                    _wstockrecordEntity.CreatorId = CurrentUser.CrmUser.Id;
                    _wstockrecordEntity.UpdateBy = CurrentUser.CrmUser.UserName;
                    _wstockrecordEntity.UpdateId = CurrentUser.CrmUser.Id;
                    _wstockrecordEntity.UpdateOn = DateTime.Now;

                    string sql1 = _wstockrecordBll.SaveWSTOCKRECOR(_wstockrecordEntity);//入库主表的添加语句
                    strlist.Add(sql1);
                    for (int i = 0; i < LYDt.Rows.Count; i++)
                    {//循环GridView记录的的每一条信息
                        //判断录入的文书编号能不能添加到数据库中（true表示当前库存表没有该编号，false表示当前库存表有该编号）
                        IsAdd = _wstockrecordBll.GetStockZDAdd(LYDt.Rows[i]["StarNo"].ToString(), LYDt.Rows[i]["EndNo"].ToString(), LYDt.Rows[i]["WRsCode"].ToString(), DateTime.Now.ToString("yyyy"));
                        if (IsAdd == true)
                        {
                            string ChildID = Guid.NewGuid().ToString();//生成入库子表编号
                            //入库子表的实体类赋值
                            _wstockcrecordEntity.Id = Guid.NewGuid().ToString();
                            _wstockcrecordEntity.CHILDID = ChildID;
                            _wstockcrecordEntity.RECORDID = RecordID;
                            _wstockcrecordEntity.WSTYPE = LYDt.Rows[i]["WRsCode"].ToString();
                            _wstockcrecordEntity.BCOUNT = Convert.ToInt32(LYDt.Rows[i]["BCount"]);
                            _wstockcrecordEntity.WCOUNT = Convert.ToInt32(LYDt.Rows[i]["WCount"]);
                            _wstockcrecordEntity.WSTARTNO = LYDt.Rows[i]["StarNo"].ToString();
                            _wstockcrecordEntity.WENDNO = LYDt.Rows[i]["EndNo"].ToString();
                            _wstockcrecordEntity.UpdateBy = CurrentUser.CrmUser.UserName;
                            _wstockcrecordEntity.UpdateId = CurrentUser.CrmUser.Id;
                            _wstockcrecordEntity.UpdateOn = DateTime.Now;
                            _wstockcrecordEntity.CreateOn = DateTime.Now;
                            _wstockcrecordEntity.RowStatus = 1;


                            string str2 = _wstockcrecord.SaveWSTOCKCRECORD(_wstockcrecordEntity);//入库子表的添加语句
                            strlist.Add(str2);
                            int count = Convert.ToInt32(LYDt.Rows[i]["WCount"]);
                            string prefix = LYDt.Rows[i]["StarNo"].ToString().Substring(Convert.ToInt32(Index), Convert.ToInt32(Length));
                            int StarNo = Convert.ToInt32(LYDt.Rows[i]["StarNo"].ToString().Substring(Convert.ToInt32(Length) - 1));
                            string WsNo = LYDt.Rows[i]["StarNo"].ToString();
                            for (int j = 0; j < count; j++)
                            {//根据每行中中开始编号和结束编号循环每一个文书编号
                                string AutoID = Guid.NewGuid().ToString();//生成中队入库明细表编号
                                //大队入库表中赋值
                                _wdeptstorageEntity.Id = Guid.NewGuid().ToString();
                                _wdeptstorageEntity.AUTOID = AutoID;
                                _wdeptstorageEntity.WSTYPE = LYDt.Rows[i]["WRsCode"].ToString();
                                _wdeptstorageEntity.RECORDID = RecordID;
                                _wdeptstorageEntity.INVALID = "";
                                _wdeptstorageEntity.DESID = "";
                                _wdeptstorageEntity.USEID = "";
                                _wdeptstorageEntity.LYPID = "";
                                _wdeptstorageEntity.DEPTID = Deptid;
                                _wdeptstorageEntity.WSNO = WsNo;
                                _wdeptstorageEntity.WSTATE = 0;
                                _wdeptstorageEntity.RowStatus = 1;
                                _wdeptstorageEntity.CreateBy = CurrentUser.CrmUser.UserName;
                                _wdeptstorageEntity.CreatorId = CurrentUser.CrmUser.Id;
                                _wdeptstorageEntity.CreateOn = DateTime.Now;
                                _wdeptstorageEntity.UpdateBy = CurrentUser.CrmUser.UserName;
                                _wdeptstorageEntity.UpdateId = CurrentUser.CrmUser.Id;
                                _wdeptstorageEntity.UpdateOn = DateTime.Now;
                                string sql3 = _wdeptstorageBll.InsertWDpetSQL(_wdeptstorageEntity);
                                strlist.Add(sql3);
                                WsNo = GetEndNo(WsNo, 2);

                            }

                        }
                        else
                        {

                            IsSave = false;
                        }
                    }

                    if (IsAdd != false)
                    {
                        _wstockcrecord.InsertStock(strlist);//入库
                    }


                }
            }
            catch (Exception ex)
            {

            }
            return IsSave;
        }

        /// <summary>
        /// 个人领用
        /// </summary>
        /// <returns></returns>
        public bool SaveGR(string WsTypts, string WsStart, string WsEnd, string UserId)
        {
            bool IsAdd = true;
            bool IsSave = true;
            try
            {
                string selectType = WsTypts;
                StringBuilder strb = new StringBuilder();
                var strlist = new List<string>();
                UserDt = InstrumentGRDT(WsTypts, WsStart, WsEnd, UserId);
                if (UserDt.Rows.Count > 0 && UserDt != null)
                {
                    string AuotoID = "";
                    string Recordid = "";
                    string Wstype = "";
                    string User = "";
                    for (int i = 0; i < UserDt.Rows.Count; i++)
                    {
                        //判断分配的文书号是否正确

                        DataTable DTIsGet = _wzdstorageBll.IsGet(UserDt.Rows[i]["StarNo"].ToString(), UserDt.Rows[i]["EndNo"].ToString(), UserDt.Rows[i]["WRsCode"].ToString(), _crmuserBll.GetUserList(new CrmUserEntity { Id = UserId })[0].DepartmentId);
                        if (Convert.ToInt32(DTIsGet.Rows[0]["num"]) == Convert.ToInt32(UserDt.Rows[i]["WCOUNT"]))
                        {
                            DataTable DTInserWsno = _wzdstorageBll.InsertUseWsno(CurrentUser.CrmUser.DeptId, UserDt.Rows[i]["StarNo"].ToString(), UserDt.Rows[i]["EndNo"].ToString(), UserDt.Rows[i]["WRsCode"].ToString());
                            for (int j = 0; j < DTInserWsno.Rows.Count; j++)
                            {
                                AuotoID = Guid.NewGuid().ToString();
                                Recordid = DTInserWsno.Rows[j]["RECORDID"].ToString();
                                Wstype = DTInserWsno.Rows[j]["WSTYPE"].ToString();
                                User = UserDt.Rows[i]["USERID"].ToString();
                                _wbrigadeEntity.Id = Guid.NewGuid().ToString();
                                _wbrigadeEntity.AUTOID = AuotoID;
                                _wbrigadeEntity.RECORDID = Recordid;
                                _wbrigadeEntity.WSTYPE = Wstype;
                                _wbrigadeEntity.WSNO = DTInserWsno.Rows[j]["WSNO"].ToString();
                                _wbrigadeEntity.WSTATE = 0;
                                _wbrigadeEntity.USERS = User;
                                _wbrigadeEntity.WCREATEDATE = DateTime.Now;
                                _wbrigadeEntity.RowStatus = 1;
                                _wbrigadeEntity.CreateBy = CurrentUser.CrmUser.LoginName;
                                _wbrigadeEntity.CreatorId = CurrentUser.CrmUser.Id;
                                _wbrigadeEntity.CreateOn = DateTime.Now;
                                _wbrigadeEntity.UpdateBy = CurrentUser.CrmUser.LoginName;
                                _wbrigadeEntity.UpdateId = CurrentUser.CrmUser.Id;
                                _wbrigadeEntity.UpdateOn = DateTime.Now;

                                string sql1 = _wbrigadeBll.InsertWBRIGADE(_wbrigadeEntity);
                                strlist.Add(sql1);
                                string sql2 = _wbrigadeBll.UpdateWZDstorage(_wbrigadeEntity.RECORDID, _wbrigadeEntity.WSTYPE, _wbrigadeEntity.WSNO);
                                strlist.Add(sql2);
                            }
                        }
                        else
                        {
                            IsSave = false;
                            return IsSave;
                        }
                    }
                    //文书号个人总分配表实体类赋值
                    _wlycrecordEntity.Id = Guid.NewGuid().ToString();
                    _wlycrecordEntity.AUTOID = Guid.NewGuid().ToString();
                    _wlycrecordEntity.RECORDID = Recordid;
                    _wlycrecordEntity.WSTYPE = Wstype;
                    _wlycrecordEntity.WCREATEDATE = DateTime.Now;
                    _wlycrecordEntity.DEPTID = _crmuserBll.GetUserList(new CrmUserEntity { Id = UserId })[0].DepartmentId;//CurrentUser.CrmUser.DeptId;
                    _wlycrecordEntity.WCOUNT = Convert.ToInt32(UserDt.Rows[0]["WCOUNT"]);
                    _wlycrecordEntity.WSTARTNO = UserDt.Rows[0]["StarNo"].ToString();
                    _wlycrecordEntity.WENDNO = UserDt.Rows[0]["EndNo"].ToString();
                    _wlycrecordEntity.WUSER = User;
                    _wlycrecordEntity.RowStatus = 1;
                    _wlycrecordEntity.CreateBy = CurrentUser.CrmUser.LoginName;
                    _wlycrecordEntity.CreatorId = CurrentUser.CrmUser.Id;
                    _wlycrecordEntity.CreateOn = DateTime.Now;
                    _wlycrecordEntity.UpdateBy = CurrentUser.CrmUser.LoginName;
                    _wlycrecordEntity.UpdateId = CurrentUser.CrmUser.Id;
                    _wlycrecordEntity.UpdateOn = DateTime.Now;

                    string sql3 = _wlycrecordBll.InsertWLYCRECORD(_wlycrecordEntity);
                    strlist.Add(sql3);

                    if (IsAdd != false)
                    {
                        _wbrigadeBll.InsertAdd(strlist);//插入分配的文书编号
                    }

                }
                else
                {
                    IsSave = false;
                }


            }
            catch (Exception ex)
            {
                IsSave = false;

            }
            return IsSave;
        }


        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveInstrumentGet(string WsTypts, string WsStart, string WsEnd, string Deptid)
        {
            bool IsSave = false;
            var rtMsg = "";
            var rtState = 1;
            try
            {
                LYDt.Rows.Clear();
                DataRow dr = LYDt.NewRow();
                LYDt = InstrumentLYDT(WsTypts, WsStart, WsEnd, Deptid);
                System.Object ob = new object();
                lock (ob)
                {
                    if (LYDt != null)
                    {
                        string WStype = LYDt.Rows[0]["WRsCode"].ToString();
                        string WStartno = LYDt.Rows[0]["StarNo"].ToString();
                        string WEndno = LYDt.Rows[0]["EndNo"].ToString();
                        string WCount = LYDt.Rows[0]["WCount"].ToString();
                        string RecordID = Guid.NewGuid().ToString();//生成入库主表编号
                        DataTable dtData = _wunitstorageBll.IsExitWUNITSTORAGE(WStartno, WEndno, WStype);
                        string dtWcount = dtData.Rows[0]["num"].ToString();
                        if (WCount == dtWcount)
                        {
                            if (Save(RecordID, WsStart, WsTypts, WsEnd, Deptid) == true)
                            {
                                if (_wunitstorageBll.UpdateWUNITSTORAGE(WStartno, WEndno, WStype, RecordID))
                                {
                                    IsSave = true;
                                    rtMsg = "入库成功";
                                }
                                else
                                {
                                    rtMsg = "领用号码失败";
                                    rtState = -1;
                                }
                            }
                            else
                            {
                                rtMsg = "保存失败";
                                rtState = -1;
                            }
                        }
                        else
                        {
                            rtMsg = "请先录入数据";
                            rtState = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IsSave = false;
                rtMsg = ex.Message;
            }
            var result = new StatusModel<object>
            {
                rtState = rtState,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsg
            };

            return Json(result, JsonRequestBehavior.AllowGet);



        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveInstrumentZD(string WsTypts, string WsStart, string WsEnd, string DeptId)
        {
            bool IsSave = false;
            var rtMsg = "";
            var rtState = 1;
            try
            {
                ZDDt.Rows.Clear();
                DataRow dr = ZDDt.NewRow();
                ZDDt = InstrumentZDDT(WsTypts, WsStart, WsEnd, DeptId);
                System.Object ob = new object();
                lock (ob)
                {
                    if (ZDDt != null)
                    {
                        string WStype = ZDDt.Rows[0]["WRsCode"].ToString();
                        string WStartno = ZDDt.Rows[0]["StarNo"].ToString();
                        string WEndno = ZDDt.Rows[0]["EndNo"].ToString();
                        string WCount = ZDDt.Rows[0]["WCount"].ToString();
                        string RecordID = Guid.NewGuid().ToString();//生成入库主表编号
                        DataTable dtData = _wdeptstorageBll.IsExitWDEPTSTORAGE(WStartno, WEndno, WStype, _crmDeptBll.Get(DeptId).CompanyId);
                        string dtWcount = dtData.Rows[0]["num"].ToString();
                        if (WCount == dtWcount)
                        {
                            if (SaveZD(RecordID, WsStart, WsTypts, WsEnd, DeptId) == true)
                            {
                                if (_wdeptstorageBll.UpdateWDEPTSTORAGE(WStartno, WEndno, WStype, RecordID))
                                {
                                    IsSave = true;
                                    rtMsg = "入库成功";
                                }
                                else
                                {
                                    rtMsg = "领用号码失败";
                                    rtState = -1;
                                }
                            }
                            else
                            {
                                rtMsg = "保存失败";
                                rtState = -1;
                            }
                        }
                        else
                        {
                            rtMsg = "请先录入数据";
                            rtState = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IsSave = false;
                rtMsg = ex.Message;
            }
            var result = new StatusModel<object>
            {
                rtState = rtState,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsg
            };

            return Json(result, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveInstrumentGR(string WsTypts, string WsStart, string WsEnd, string UserId)
        {
            bool IsSave = false;
            var rtMsg = "";
            var rtState = 1;

            try
            {
                System.Object ob = new object();
                lock (ob) 
                {
                    if (UserDt != null)
                    {

                        if (SaveGR(WsTypts, WsStart, WsEnd, UserId) == true)
                        {
                            rtMsg = "入库成功";
                        }
                        else
                        {
                            rtMsg = "入库失败";
                            rtState = -1;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                IsSave = false;
                rtMsg = ex.Message;
            }
            var result = new StatusModel<object>
            {
                rtState = rtState,
                rtData = null,
                rtObj = null,
                rtMsrg = rtMsg
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取文书库存
        /// </summary>
        /// <param name="wsTypts">文书类型id</param>
        /// <param name="StorageType">WUNITSTORAGE 库存 WDEPTSTORAGE(中队库存) WZDSTORAGE(个人库存)</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult StorageSelect(string wsTypts, string StorageType, string daduiId)
        {
            string jsonRsult = string.Empty;
            if (!string.IsNullOrEmpty(wsTypts) && !string.IsNullOrEmpty(StorageType))
            {
                var user = CurrentUser.CrmUser;
                jsonRsult = JsonConvert.SerializeObject(_wunitstorageBll.GetStorageSelect(wsTypts, StorageType, user.DeptId, daduiId));
            }
            return View((object)jsonRsult);
        }


    }
}
