using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Com
{
    public class NoticeController : BaseController
    {
        //
        // GET: /Notice/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            var entity = new ComNoticeEntity();
            SetDefaultData(entity);
            return View(entity);
        }

        /// <summary>
        /// 公告详情
        /// </summary>
        /// <param name="id">公告详情</param>
        /// <returns></returns>
        public ActionResult NoticeDetail(string id)
        {
            var entity = new ComNoticeEntity();
            if (!string.IsNullOrEmpty(id))
            {
                entity = new ComNoticeBll().Get(id);
                var files = new ComNoticeAttachBll().GetSearchResult(new ComNoticeAttachEntity() { ResourceId = id });
                ViewData["Files"] = files;
            }
            return View(entity);
        }


        /// <summary>
        /// 公告管理
        /// </summary>
        /// <returns></returns>
        public ActionResult NoticeManager()
        {
            return View();
        }
        /// <summary>
        /// 设置默认值
        /// 添加人：周 鹏
        /// 添加时间：2015-01-27
        /// </summary>
        /// <param name="entity"></param>
        private void SetDefaultData(ComNoticeEntity entity)
        {
            //通知类别
            var typeId = EnumOperate.ConvertEnumToListItems(typeof(NoticeType), entity.AType.ToString(CultureInfo.InvariantCulture));
            ViewData["Types"] = typeId;

            //是否置顶
            var top = EnumOperate.ConvertEnumToListItems(typeof(NoticeTop), entity.IsTop.ToString(CultureInfo.InvariantCulture));
            ViewData["NoticeTop"] = top;
        }

        /// <summary>
        /// 选择人员
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectPerson()
        {
            return View();
        }

        #region Ajax 获取数据
        /// <summary>
        /// 获取人员TreeJson数据
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDeptUserTree(string userids)
        {

            var checkUsers = new List<string>();   //已经选择的人员
            if (!string.IsNullOrEmpty(userids))
            {
                var splitUsers = userids.Split(',');
                checkUsers.AddRange(splitUsers.Where(splitUser => !string.IsNullOrEmpty(splitUser)));
            }

            var roleList = new BaseDepartmentBll().GetAllDetachments(); //部门
            var userList = new BaseUserBll().GetAllBaseUsers();  //人员
            var crmDeptEntities = roleList as BaseDepartmentEntity[] ?? roleList.ToArray();


            var topRole = new BaseCompanyBll().GetAllCompany();

            var result = (from crmRoleEntity in topRole
                          let childs = ChildTree(crmDeptEntities, crmRoleEntity.CompanyId.ToString(), userList, checkUsers)
                          select new TreeNode()
                          {
                              id = crmRoleEntity.CompanyId,
                              text = crmRoleEntity.FullName,
                              img = "/Content/Images/Icon16/molecule.png",
                              showcheck = true,
                              isexpand = true,
                              complete = true,
                              hasChildren = childs.Count > 0,
                              ChildNodes = childs
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 加载子部门
        /// 添加人：周 鹏
        /// 添加时间：2014-12-15
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="roleLists"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<TreeNode> ChildTree(IEnumerable<BaseDepartmentEntity> roleLists, string parentId, IEnumerable<BaseUserEntity> userLists, List<string> checkUsers)
        {
            var crmDeptEntities = roleLists as BaseDepartmentEntity[] ?? roleLists.ToArray();
            var childList = crmDeptEntities.Where(t => t.CompanyId == parentId).ToList();
            var list = new List<TreeNode>();
            foreach (var crmDeptEntity in childList)
            {
                var childs = ChildTree(crmDeptEntities, crmDeptEntity.DepartmentId, userLists, checkUsers);
                if (!childs.Any())
                {
                    childs = ChildUserTree(userLists, crmDeptEntity.DepartmentId, checkUsers);
                    childs = ChildUserTree(userLists, crmDeptEntity.DepartmentId, checkUsers);
                }
                list.Add(new TreeNode()
                {
                    id = crmDeptEntity.DepartmentId,
                    text = crmDeptEntity.FullName,
                    img = "/Content/Images/Icon16/hostname.png",
                    type = "Dept",
                    showcheck = true,
                    isexpand = false,
                    complete = true,
                    hasChildren = childs.Count > 0,
                    ChildNodes = childs
                });
            }
            return list;
        }

        /// <summary>
        /// 人员
        /// </summary>
        /// <param name="userLists">人员集</param>
        /// <param name="deptId">部门编号</param>
        /// <returns></returns>
        public List<TreeNode> ChildUserTree(IEnumerable<BaseUserEntity> userLists, string deptId, List<string> checkUsers)
        {
            var users = userLists.Where(x => x.DeptId == deptId);
            return users.Select(crmUserEntity => new TreeNode()
            {
                id = crmUserEntity.Id,
                text = crmUserEntity.UserName,
                value = crmUserEntity.Mobile,
                img = "/Content/Images/Icon16/user_suit.png",
                type = "User",
                showcheck = true,
                checkstate = checkUsers.Contains(crmUserEntity.Id) ? 2 : 0,
                isexpand = false,
                complete = true,
                hasChildren = false,
                ChildNodes = null
            }).ToList();
        }

        #endregion

        /// <summary>
        /// 保存公告通知
        /// 添加人：周 鹏
        /// 添加时间：2015-01-28
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="entity">通知实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Edit(ComNoticeEntity entity)
        {
            var rtState = 0;
            try
            {
                if (ModelState.IsValid)
                {
                    var user = CurrentUser.CrmUser;
                    entity.RowStatus = 1;
                    if (string.IsNullOrEmpty(entity.Id))
                    {
                        entity.CreatorId = user.Id;
                        entity.CreateBy = user.UserName;
                        entity.CreateOn = DateTime.Now;
                    }
                    else
                    {
                        entity.UpdateId = user.Id;
                        entity.UpdateBy = user.UserName;
                        entity.UpdateOn = DateTime.Now;
                    }
                    rtState = new ComNoticeBll().SaveNotice(entity) ? 0 : 1;
                }
            }
            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 公告通知管理所有数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public string ManagerGridPageList(int pageIndex = 1, int pageSize = 20)
        {

            int totalRecords;

            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var data = new ComNoticeBll().GetNotices(pageIndex, pageSize, out totalRecords);
            var resultrow = new StringBuilder("");
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    resultrow.AppendFormat(@"<tr onDblClick=OpenDetails('{0}')><td style='width: 50px; text-align: center;'>
                                  <input type='checkbox' value='{0}'/></td>
                                  <td style='width: 20px;'></td>
                                  <td style='width: 180px;'>{1}</td>
                                  <td>{2}</td>
                                  <td style='width: 100px; text-align: center;'>{3}</td>
                                  <td style='width: 20px;'></td></tr>", row["Id"], row["realname"], row["Title"], Convert.ToDateTime(row["SendTime"]).ToString(AppConst.DateFormat));
                }
            }

            stopwatch.Stop();
            var totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
            var result = new PageStringDatagrid
            {
                page = pageIndex,
                rows = resultrow.ToString(),
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
            return JsonConvert.SerializeObject(result);
        }


        /// <summary>
        /// 查询个人公告通知
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public string GridPageList(int pageIndex = 1, int pageSize = 20)
        {
            var user = CurrentUser.CrmUser;

            int totalRecords;

            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var data = new ComNoticeBll().GetUserNotice(user.Id, pageIndex, pageSize, out totalRecords);
            var resultrow = new StringBuilder("");
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    resultrow.AppendFormat(@"<tr onDblClick=OpenDetails('{0}')><td style='width: 50px; text-align: center;'>
                                  <input type='checkbox' value='{0}'/></td>
                                  <td style='width: 20px;'></td>
                                  <td style='width: 180px;'>{1}</td>
                                  <td>{2}</td>
                                  <td style='width: 100px; text-align: center;'>{3}</td>
                                  <td style='width: 20px;'></td></tr>", row["Id"], row["realname"], row["Title"], Convert.ToDateTime(row["SendTime"]).ToString(AppConst.DateFormat));
                }
            }

            stopwatch.Stop();
            var totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
            var result = new PageStringDatagrid
            {
                page = pageIndex,
                rows = resultrow.ToString(),
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
            return JsonConvert.SerializeObject(result);
        }


        /// <summary>
        /// 删除公告通知
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult UpNotice(string id)
        {
            var isOk = false;

            isOk = new ComNoticeBll().DeleteNotice(id);
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = isOk ? 1 : -1
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }
    }
}
