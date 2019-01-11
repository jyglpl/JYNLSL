using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.Hr;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Hr
{
    /// <summary>
    /// 部门班别设定
    /// </summary>
    public class FlightClassesOfDeptmentController : BaseController
    {

        private readonly FlightClassesOfDeptmentBll _flightClassesOfDeptment = new FlightClassesOfDeptmentBll();//部门班别设定
        private readonly CrmDepartmentBll _crmDepartmentBll = new CrmDepartmentBll(); //
        private readonly ComResourceBll _comResourceBll = new ComResourceBll();

        #region 列表页面
        /// <summary>
        /// 进入主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string deptId)
        {
            ViewBag.DeptId = deptId;
            return View();
        }

        /// <summary>
        /// 通过部门Id查询列表
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public string GetFlightClassesOfDeptmentListJson(string deptId)
        {
            _flightClassesOfDeptment.SetDefault(deptId);//设置默认班别
            List<FlightClassesOfDeptmentEntity> result = _flightClassesOfDeptment.GetFlightClassesOfDeptmentListByDeptId(deptId);
            return CommonMethod.PageToJson(new { rows = result });
        }

        #endregion

        #region 新增/编辑
        /// <summary>
        /// 新增/编辑
        /// </summary>
        /// <param name="companyId">父编号</param>
        /// <param name="departmentId">部门主键编号</param>
        /// <returns></returns>
        public ActionResult Edit(string id, string DeptId)
        {
            var entity = new FlightClassesOfDeptmentEntity();
            if (!string.IsNullOrEmpty(id))
            {
                entity = _flightClassesOfDeptment.Get(id);
            }

            if (entity != null)
            {
                CrmDepartmentEntity deptModel = _crmDepartmentBll.Get(entity.DeptId);
                entity.DepteName = deptModel != null ? deptModel.FullName : "";
            }
            if (string.IsNullOrEmpty(entity.DepteName) && !string.IsNullOrEmpty(DeptId))//新增的时候部门
            {
                entity.DeptId = DeptId;
                CrmDepartmentEntity deptModel = _crmDepartmentBll.Get(entity.DeptId);
                entity.DepteName = deptModel != null ? deptModel.FullName : "";
            }
            return View(entity);
        }

        /// <summary>
        /// 保存部门信息
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="entity">部门实体</param>
        /// <returns>保存信息结果</returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SubmitDepartmentForm(FlightClassesOfDeptmentEntity entity)
        {
            string rtMsrg;
            int rtState;
            try
            {
                var isAdd = string.IsNullOrEmpty(entity.Id);
                bool flag;
                if (isAdd)
                {
                    entity.Id = Guid.NewGuid().ToString();
                    entity.RowStatus = (int)RowStatus.Normal;
                    entity.CreateBy = CurrentUser.CrmUser.LoginName;
                    entity.CreatorId = CurrentUser.CrmUser.Id;
                    entity.CreateOn = DateTime.Now;
                    entity.UpdateBy = CurrentUser.CrmUser.LoginName;
                    entity.UpdateId = CurrentUser.CrmUser.Id;
                    entity.UpdateOn = DateTime.Now;
                    flag = _flightClassesOfDeptment.Add(entity) != null;
                }
                else
                {
                    entity.UpdateBy = CurrentUser.CrmUser.LoginName;
                    entity.UpdateId = CurrentUser.CrmUser.Id;
                    entity.UpdateOn = DateTime.Now;
                    entity.RowStatus = (int)RowStatus.Normal;
                    flag = _flightClassesOfDeptment.Update(entity) > 0;
                }
                rtMsrg = flag ? "保存成功" : "保存失败";
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
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        #endregion

        /// <summary>
        /// 删除部门班别
        /// </summary>
        /// <param name="id"></param>
        public JsonResult DeleteFlightClassesOfDeptment(string id)
        {
            var state = false;
            var message = string.Empty;
            FlightClassesOfDeptmentEntity entity = null;
            if (!string.IsNullOrEmpty(id))
            {
                entity = _flightClassesOfDeptment.Get(id);
            }
            if (entity != null)
            {
                if (entity.ClassesId != "休息")
                {
                    entity.RowStatus = 0;
                    if (_flightClassesOfDeptment.Update(entity) > 0)
                    {
                        state = true;
                        message = "删除成功！";
                    }
                    else
                    {
                        state = false;
                        message = "删除失败！";
                    }
                }
                else
                {
                    state = false;
                    message = "休息班别不能删除！";
                }
            }
            return Json(new { State = state, Message = message }, JsonRequestBehavior.AllowGet);
        }

    }
}
