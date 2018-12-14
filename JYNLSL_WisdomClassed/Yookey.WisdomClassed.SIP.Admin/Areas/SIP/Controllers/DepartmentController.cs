using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Controllers;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Membership;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Admin.Areas.SIP.Controllers
{
    public class DepartmentController : BaseController
    {
        //
        // GET: /CommonModule/Deparment/

        public ActionResult Index()
        {
            return View();
        }

        #region Ajax 请求单位和部门树
        /// <summary>
        /// 部门TreeJson
        /// </summary>
        /// <returns></returns>
        public JsonResult DeparmentTreeJson(string companyId = "")
        {
            //加载个系统整个组织架构
            if (string.IsNullOrEmpty(companyId))
            {
                var companys = new CrmCompanyBll().GetAllCompany();
                var departments = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity());

                //企业
                var topCompany = companys.Where(x => x.ParentId == "0").ToList();
                var result = (from companyEntity in topCompany
                              let childs = ChildCompany(companys, departments, companyEntity.Id)
                              select new TreeNode()
                              {
                                  id = companyEntity.Id,
                                  text = companyEntity.FullName,
                                  value = "company",
                                  img = "/Content/Images/Icon16/molecule.png", //tree.js处理路径
                                  showcheck = false,
                                  isexpand = true,
                                  complete = true,
                                  hasChildren = childs.Count > 0,
                                  ChildNodes = childs
                              }).ToList();

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //加载单位下面的所有部门
                var departments = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity()).Where(x => x.CompanyId == companyId);
                var result = ChildDepartment(departments, companyId);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult DeparmentTreeJson2(string companyId = "")
        {
            //加载个系统整个组织架构
            if (string.IsNullOrEmpty(companyId))
            {
                var companys = new CrmCompanyBll().GetAllCompany();
                var departments = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity());

                //企业
                var topCompany = companys.Where(x => x.FullName == "行政执法支队").ToList();
                var result = (from companyEntity in topCompany
                              let childs = ChildCompany(companys, departments, companyEntity.Id)
                              select new TreeNode()
                              {
                                  id = companyEntity.Id,
                                  text = companyEntity.FullName,
                                  value = "company",
                                  img = "/Content/Images/Icon16/molecule.png", //tree.js处理路径
                                  showcheck = false,
                                  isexpand = true,
                                  complete = true,
                                  hasChildren = childs.Count > 0,
                                  ChildNodes = childs
                              }).ToList();

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //加载单位下面的所有部门
                var departments = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity()).Where(x => x.CompanyId == companyId);
                var result = ChildDepartment(departments, companyId);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 加载子公司信息
        /// 添加人：周 鹏
        /// 添加时间：2015-02-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companys">公司集</param>
        /// <param name="departments">部门集</param>
        /// <param name="parentId">公司父编号</param>
        /// <returns></returns>
        public List<TreeNode> ChildCompany(IEnumerable<CrmCompanyEntity> companys, IEnumerable<CrmDepartmentEntity> departments, string parentId)
        {
            var baseCompanyEntities = companys as CrmCompanyEntity[] ?? companys.ToArray();
            var childList = baseCompanyEntities.Where(t => t.ParentId == parentId).ToList();

            var list = new List<TreeNode>();
            foreach (var companyEntity in childList)
            {
                var childs = ChildCompany(baseCompanyEntities, departments, companyEntity.Id);
                var departmentList = ChildDepartment(departments, companyEntity.Id);
                if (departmentList.Any())
                {
                    childs.AddRange(departmentList);
                }
                list.Add(new TreeNode()
                {
                    id = companyEntity.Id,
                    text = companyEntity.FullName,
                    value = "company",
                    img = "/Content/Images/Icon16/hostname.png",//tree.js处理路径
                    showcheck = false,
                    isexpand = false,
                    complete = true,
                    hasChildren = childs.Count > 0,
                    ChildNodes = childs
                });
            }
            return list;
        }

        /// <summary>
        /// 添加部门
        /// 添加人：周 鹏
        /// 添加时间：2015-02-14
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="departments">部门集</param>
        /// <param name="companyId">公司ID</param>
        /// <returns></returns>
        public List<TreeNode> ChildDepartment(IEnumerable<CrmDepartmentEntity> departments, string companyId)
        {
            var baseDepartmentEntities = departments as CrmDepartmentEntity[] ?? departments.ToArray();
            var childList = baseDepartmentEntities.Where(t => t.CompanyId == companyId).ToList();
            return (from companyEntity in childList
                    select new TreeNode()
                    {
                        id = companyEntity.Id,
                        text = companyEntity.FullName,
                        value = "department",
                        img = "/Content/Images/Icon16/chart_organisation.png",
                        showcheck = false,
                        isexpand = true,
                        complete = true,
                        hasChildren = false,
                        ChildNodes = null
                    }).ToList();
        }



        #endregion

        /// <summary>
        /// 请求部门GridListJson
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位编号</param>
        /// <param name="rows">请求条数</param>
        /// <param name="page">请求页数</param>
        /// <returns></returns>
        public string GridListJson(string companyId, int rows, int page)
        {
            var departments = new CrmDepartmentBll().GetSearchResult(new CrmDepartmentEntity() { CompanyId = companyId, PageIndex = page, PageSize = rows });
            return CommonMethod.PageToJson(departments);
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="departmentId">部门主键编号</param>
        /// <returns>删除结果</returns>
        [HttpPost]
        public string DeleteDepartment(string departmentId)
        {
            string rtMsrg;
            int rtState;
            try
            {
                var flag = new CrmDepartmentBll().BatchDelete(departmentId);
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
        /// 新增/编辑
        /// </summary>
        /// <param name="companyId">父编号</param>
        /// <param name="departmentId">部门主键编号</param>
        /// <returns></returns>
        public ActionResult Edit(string companyId, string departmentId)
        {
            var entity = new CrmDepartmentEntity();
            if (!string.IsNullOrEmpty(departmentId))
            {
                entity = new CrmDepartmentBll().Get(departmentId);
            }
            else if (!string.IsNullOrEmpty(companyId))
            {
                entity.CompanyId = companyId;
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
        public string SubmitDepartmentForm(CrmDepartmentEntity entity)
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
                    flag = new CrmDepartmentBll().Add(entity) != null;
                }
                else
                {
                    entity.UpdateBy = CurrentUser.CrmUser.LoginName;
                    entity.UpdateId = CurrentUser.CrmUser.Id;
                    entity.UpdateOn = DateTime.Now;
                    flag = new CrmDepartmentBll().Update(entity) > 0;
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
            return CommonMethod.ToJson(rtEntity);
        }


        /// <summary>
        /// 请求部门下拉框数据                                                                
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位编号</param>
        /// <param name="selectId">控件编号</param>
        /// <returns></returns>
        public string DropList(string companyId, string selectId)
        {
            var str = new StringBuilder();
            try
            {
                str.AppendFormat("document.getElementById('{0}').options.length = 1;", selectId);
                if (!string.IsNullOrEmpty(companyId))
                {
                    var departments = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity() { CompanyId = companyId });

                    var i = 1;
                    foreach (var t in departments.Where(t => !string.IsNullOrEmpty(t.FullName)))
                    {
                        str.Append("document.getElementById('" + selectId + "').options[" + i + "] = new Option('" +
                                      t.FullName + "', '" + t.Id + "', false, false);");
                        i++;
                    }
                }
            }
            catch (Exception)
            {
                //ignored
            }

            return str.ToString();
        }

        /// <summary>
        /// 结合权限获取所有单位
        /// </summary>
        /// <param name="companyId">单位编号</param>
        /// <param name="controlId">下拉控件ID</param>
        /// <param name="defaultSelId">默认选中的ID</param>
        /// <param name="defaultSel">是否默认选中本部门</param>
        /// <returns></returns>
        public string GetDepartmentDropList(string companyId, string controlId, string defaultSelId, bool defaultSel = false)
        {
            var str = new StringBuilder();
            try
            {
                var user = CurrentUser.CrmUser;
                str.AppendFormat("document.getElementById('{0}').options.length = 1;", controlId);

                if (string.IsNullOrEmpty(companyId)) return str.ToString();

                var departments = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity() { CompanyId = companyId });

                //验证是有获取所有执法单位的权限，如没有只查本单位的权限
                var isAllEnforcementUnit = new MembershipManager().VerificationPermissions(user.Id, "Department", "Operation");
                departments = isAllEnforcementUnit
                               ? departments
                               : departments.Where(x => x.Id == user.DeptId).ToList();
                var i = 1;
                if (departments.Any() && departments.Count >= 1)
                {
                    str.Append("document.getElementById('" + controlId + "').options[" + 0 + "] = new Option('==请选择==', 'all', false, false);");
                }
                else if (departments.Any() && departments.Count == 1)
                {
                    i = 0;
                }
                foreach (var t in departments.Where(t => !string.IsNullOrEmpty(t.FullName)))
                {
                    str.Append("document.getElementById('" + controlId + "').options[" + i + "] = new Option('" + t.FullName + "', '" + t.Id + "',false, false);");

                    //默认选中本部门（多个部门,默认不要选中）
                    if ((defaultSel && user.DeptId == t.Id) || t.Id == defaultSelId)
                    {
                        str.Append("document.getElementById('" + controlId + "').options[" + i + "].selected=true;");
                    }
                    else if (departments.Count == 1 && (user.DeptId == t.Id || t.Id == defaultSelId))
                    {
                        str.Append("document.getElementById('" + controlId + "').options[" + i + "].selected=true;");
                    }

                    i++;
                }
            }
            catch (Exception)
            {
                //ignored
            }
            return str.ToString();
        }

        /// <summary>
        /// 结合权限获取所有单位
        /// </summary>
        /// <param name="companyId">单位编号</param>
        /// <param name="controlId">下拉控件ID</param>
        /// <param name="defaultSelId">默认选中的ID</param>
        /// <param name="defaultSel">是否默认选中本部门</param>
        /// <returns></returns>
        public string GetDepartmentDropListWorkFlow(string companyId, string controlId, string defaultSelId, bool defaultSel = false)
        {
            var str = new StringBuilder();
            try
            {
                var user = CurrentUser.CrmUser;
                str.AppendFormat("document.getElementById('{0}').options.length = 1;", controlId);

                if (string.IsNullOrEmpty(companyId)) return str.ToString();

                var departments = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity() { CompanyId = companyId });

                var i = 1;

                foreach (var t in departments.Where(t => !string.IsNullOrEmpty(t.FullName)))
                {
                    str.Append("document.getElementById('" + controlId + "').options[" + i + "] = new Option('" + t.FullName + "', '" + t.Id + "',false, false);");

                    //默认选中本部门（多个部门,默认不要选中）
                    if ((defaultSel && user.DeptId == t.Id) || t.Id == defaultSelId)
                    {
                        str.Append("document.getElementById('" + controlId + "').options[" + i + "].selected=true;");
                    }
                    else if (departments.Count == 1 && (user.DeptId == t.Id || t.Id == defaultSelId))
                    {
                        str.Append("document.getElementById('" + controlId + "').options[" + i + "].selected=true;");
                    }

                    i++;
                }
            }
            catch (Exception)
            {
                //ignored
            }
            return str.ToString();
        }
    }
}
