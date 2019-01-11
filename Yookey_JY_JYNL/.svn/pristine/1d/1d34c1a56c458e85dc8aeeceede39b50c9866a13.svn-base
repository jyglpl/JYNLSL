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

namespace Yookey.WisdomClassed.SIP.Admin.Areas.CommonModule.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly static CrmCompanyBll CompanyBll = new CrmCompanyBll();

        private int _tempRgtNum = 100000;
        private int _tempLftNum = 1;

        //
        // GET: /CommonModule/Company/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增/编辑
        /// </summary>
        /// <param name="parentId">父编号</param>
        /// <param name="companyId">单位主键编号</param>
        /// <returns></returns>
        public ActionResult Edit(string parentId, string companyId)
        {
            var entity = new CrmCompanyEntity();
            if (!string.IsNullOrEmpty(companyId))
            {
                entity = new CrmCompanyBll().Get(companyId);
            }
            else if (!string.IsNullOrEmpty(parentId))
            {
                entity.ParentId = parentId;
            }
            return View(entity);
        }

        /// <summary>
        /// 单位结构树
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns>System.String.</returns>
        public string TreeGridListJson()
        {
            var companys = CompanyBll.GetAllCompany().ToList();
            //企业
            var topCompany = companys.Where(x => x.ParentId == "0").ToList();

            var result = new List<CompanyTree>();
            foreach (var companyEntity in topCompany)
            {
                //第一级
                result.Add(new CompanyTree()
                {
                    expanded = true,
                    isLeaf = false,
                    level = 0,
                    Id = companyEntity.Id,
                    ParentId = companyEntity.ParentId,
                    Code = companyEntity.Code,
                    FullName = companyEntity.FullName,
                    ShortName = companyEntity.ShortName,
                    Category = companyEntity.Category,
                    Contact = companyEntity.Contact,
                    Phone = companyEntity.Phone,
                    Fax = companyEntity.Fax,
                    Enabled = companyEntity.Enabled,
                    Remark = companyEntity.Remark
                });

                const int level = 0;
                var childList = ChildCompany(companys, companyEntity.Id, level);
                result.AddRange(childList);

                result = result.OrderBy(x => x.Code).ToList();

                foreach (var entity in result)
                {
                    entity.rgt = _tempRgtNum--;
                    entity.lft = _tempLftNum++;
                }
            }
            return CommonMethod.PageToJson(new { rows = result });
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
        /// <param name="parentId">公司父编号</param>
        /// <param name="level">级别</param>
        /// <returns></returns>
        public List<CompanyTree> ChildCompany(IEnumerable<CrmCompanyEntity> companys, string parentId, int level)
        {
            var baseCompanyEntities = companys as CrmCompanyEntity[] ?? companys.ToArray();
            var childList = baseCompanyEntities.Where(t => t.ParentId == parentId).ToList();

            var list = new List<CompanyTree>();
            level++;
            foreach (var companyEntity in childList)
            {
                var childs = ChildCompany(baseCompanyEntities, companyEntity.Id, level);
                list.Add(new CompanyTree()
                {
                    expanded = false,
                    isLeaf = !(childs.Count > 0),
                    level = level,
                    Id = companyEntity.Id,
                    ParentId = companyEntity.ParentId,
                    Code = companyEntity.Code,
                    FullName = companyEntity.FullName,
                    ShortName = companyEntity.ShortName,
                    Category = companyEntity.Category,
                    Contact = companyEntity.Contact,
                    Phone = companyEntity.Phone,
                    Fax = companyEntity.Fax,
                    Enabled = companyEntity.Enabled,
                    Remark = companyEntity.Remark
                });
                list.AddRange(childs);
            }
            return list;
        }

        #region  请求单位结构树

        /// <summary>
        /// 部门TreeJson
        /// </summary>
        /// <returns></returns>
        public JsonResult TreeJson()
        {
            var companys = new CrmCompanyBll().GetAllCompany();

            //企业
            var topCompany = companys.Where(x => x.ParentId == "0").ToList();
            var result = (from companyEntity in topCompany
                          let childs = ChildCompany(companys, companyEntity.Id)
                          select new TreeNode()
                          {
                              id = companyEntity.Id,
                              text = companyEntity.FullName,
                              value = "company",
                              img = "/Content/Images/Icon16/molecule.png",//tree.js处理路径
                              showcheck = false,
                              isexpand = true,
                              complete = true,
                              hasChildren = childs.Count > 0,
                              ChildNodes = childs
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 加载子公司信息
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companys">单位数据集</param>
        /// <param name="parentId">公司父编号</param>
        /// <returns></returns>
        public List<TreeNode> ChildCompany(IEnumerable<CrmCompanyEntity> companys, string parentId)
        {
            var baseCompanyEntities = companys as CrmCompanyEntity[] ?? companys.ToArray();
            var childList = baseCompanyEntities.Where(t => t.ParentId == parentId).ToList();

            var list = new List<TreeNode>();
            foreach (var companyEntity in childList)
            {
                var childs = ChildCompany(baseCompanyEntities, companyEntity.Id);
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
                //list.AddRange(childs);
            }
            return list;
        }

        #endregion

        /// <summary>
        /// 保存单位信息
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="entity">单位实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public string SubmitCompanyForm(CrmCompanyEntity entity)
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
                    flag = new CrmCompanyBll().Add(entity) != null;
                }
                else
                {
                    entity.UpdateBy = CurrentUser.CrmUser.LoginName;
                    entity.UpdateId = CurrentUser.CrmUser.Id;
                    entity.UpdateOn = DateTime.Now;
                    flag = new CrmCompanyBll().Update(entity) > 0;
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
        /// 删除单位
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位主键编号</param>
        /// <returns></returns>
        [HttpPost]
        public string DeleteCompany(string companyId)
        {
            string rtMsrg;
            int rtState;
            try
            {
                var flag = new CrmCompanyBll().BatchDelete(companyId);
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
        /// 单位详情
        /// </summary>
        /// <param name="companyId">单位主键编号</param>
        /// <returns></returns>
        public string SetForm(string companyId)
        {
            var entity = new CrmCompanyEntity();
            if (!string.IsNullOrEmpty(companyId))
            {
                entity = new CrmCompanyBll().Get(companyId);
            }

            return CommonMethod.ToJson(new { RtState = (int)OperationState.Success, CompanyId = entity.Id, FullName = entity.FullName });
        }


        /// <summary>
        /// 结合权限获取所有单位
        /// </summary>
        /// <param name="controlId">下拉控件ID</param>
        /// <param name="defaultSelId">默认选中的ID</param>
        /// <param name="defaultSel">是否默认选中本单位</param>
        /// <returns></returns>
        public string GetCompanyDropList(string controlId, string defaultSelId, bool defaultSel = false)
        {
            var str = new StringBuilder();
            try
            {
                var user = CurrentUser.CrmUser;
                str.AppendFormat("document.getElementById('{0}').options.length = 1;", controlId);
                var companys = new CrmCompanyBll().GetAllEnforcementUnit();

                //验证是有获取所有执法单位的权限，如没有只查本单位的权限
                var isAllEnforcementUnit = new MembershipManager().VerificationPermissions(user.Id, "Company", "Operation");
                companys = isAllEnforcementUnit
                               ? companys
                               : companys.Where(x => x.Id == user.CompanyId).ToList();

                var i = 1;
                if (companys.Any() && companys.Count > 1)
                {
                    str.Append("document.getElementById('" + controlId + "').options[" + 0 + "] = new Option('==请选择==', 'all', false, false);");
                }
                else if (companys.Any() && companys.Count == 1)
                {
                    i = 0;
                }
                foreach (var t in companys.Where(t => !string.IsNullOrEmpty(t.ShortName)))
                {
                    str.Append("document.getElementById('" + controlId + "').options[" + i + "] = new Option('" +
                                  t.ShortName + "', '" + t.Id + "', false, false);");

                    if (!string.IsNullOrEmpty(defaultSelId) && t.Id == defaultSelId)
                    {
                        str.Append("document.getElementById('" + controlId + "').options[" + i + "].selected=true;");
                    }
                    //默认选中本部门（多个单位,默认不要选中）
                    else if ((defaultSel && user.CompanyId == t.Id && string.IsNullOrEmpty(defaultSelId)) || t.Id == defaultSelId)
                    {
                        str.Append("document.getElementById('" + controlId + "').options[" + i + "].selected=true;");
                    }
                    else if (companys.Count == 1 && ((user.CompanyId == t.Id) || t.Id == defaultSelId))
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

    #region TreeGridJson 辅助类

    /// <summary>
    /// 单位树
    /// </summary>
    public class CompanyTree
    {
        public int rgt { get; set; }
        public int lft { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary>
        public bool expanded { get; set; }

        /// <summary>
        /// 是否是子节点
        /// </summary>
        public bool isLeaf { get; set; }

        /// <summary>
        /// 显示的级别
        /// </summary>
        public int level { get; set; }


        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Category { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int Enabled { get; set; }
        public string Remark { get; set; }
    }

    #endregion
}
