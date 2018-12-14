using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.GridManagement;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.GridManagement;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.GridManagement
{
    public class GridManagementController : BaseController
    {
        #region ActionResult
        /// <summary>
        /// 网格化台账管理
        /// </summary>
        /// <returns></returns>
        public ActionResult GridIndex()
        {
            var user = CurrentUser.CrmUser;

            //验证权限
            //var isCityPermission = new Membership.MembershipManager().Permissions(user.Id, "GridManagement", "CityPermission");
            //var isAreaPermission = new Membership.MembershipManager().Permissions(user.Id, "GridManagement", "AreaPermission");
            //var isDepartmentPermission = new Membership.MembershipManager().Permissions(user.Id, "GridManagement", "DepartmentPermission");

            var defaultUrl = Url.Action("MainIndex", "AssessmentManagement");
            //if (isCityPermission)
            //{
            //    defaultUrl = Url.Action("Index", "GridManagement");
            //}
            //else if (isAreaPermission)
            //{
            //    defaultUrl = Url.Action("DepartmentIndex", "GridManagement") + "?companyId=" + user.CompanyId;
            //}
            //else if (isDepartmentPermission)
            //{
            //    defaultUrl = Url.Action("Folder", "GridManagement") + "?companyId=" + user.CompanyId + "&departmentId=" + user.DepartmentId;
            //}
            ViewBag.DefaultUrl = defaultUrl;
            return View();
        }

        public ActionResult GridIndexNew()
        {
            var user = CurrentUser.CrmUser;

            //验证权限
            //var isCityPermission = new Membership.MembershipManager().Permissions(user.Id, "GridManagement", "CityPermission");
            //var isAreaPermission = new Membership.MembershipManager().Permissions(user.Id, "GridManagement", "AreaPermission");
            //var isDepartmentPermission = new Membership.MembershipManager().Permissions(user.Id, "GridManagement", "DepartmentPermission");

            var defaultUrl = "";
            var defaultIndx = "";
            //if (isCityPermission)
            //{
            //    defaultUrl = Url.Action("Index", "GridManagement");
            //    defaultIndx = "Index";
            //}
            //else if (isAreaPermission)
            //{
            //    defaultUrl = Url.Action("DepartmentIndex", "GridManagement") + "?companyId=" + user.CompanyId;
            //    defaultIndx = "DepartmentIndex";
            //}
            //else if (isDepartmentPermission)
            //{
            //    defaultUrl = Url.Action("Folder", "GridManagement") + "?companyId=" + user.CompanyId + "&departmentId=" + user.DepartmentId;
            //    defaultIndx = "Folder";
            //}
            ViewBag.DefaultUrl = defaultUrl;
            return View(defaultIndx);
        }

        /// <summary>
        /// add by lpl
        /// 2018-11-8
        /// 吴中区
        /// </summary>
        /// <returns></returns>
        public ActionResult MainIndex()
        {
            var defaultUrl = "";
            defaultUrl = Url.Action("MainIndex", "AssessmentManagement");
            ViewBag.DefaultUrl = defaultUrl;
            return View("GridIndex");
        }

        /// <summary>
        /// 网格化台账管理-全市
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //获取所有单位
            var company = new GridManagementBll().GetCompanys();
            //获取所有单位上传信息
            var companyNewUploadInfo = new GridManagementBll().GetCompanyNewUploadInfo();

            ViewData["Company"] = company;
            ViewData["CompanyNewUploadInfo"] = companyNewUploadInfo;
            return View();
        }

        /// <summary>
        /// 网格化管理-全区
        /// </summary>
        /// <returns></returns>
        public ActionResult DepartmentIndex(string companyId)
        {
            if (string.IsNullOrEmpty(companyId))
            {
                companyId = CurrentUser.CrmUser.CompanyId;   //当前登录用户所属单位ID
            }

            var companyEntity = new CrmCompanyBll().Get(companyId);
            var departments = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity() { CompanyId = companyId, IsLedger = 1 });

            ViewData["Company"] = companyEntity;

            return View(departments);
        }

        /// <summary>
        /// 网格化管理-台账
        /// </summary>
        /// <param name="companyId">所属单位</param>
        /// <param name="departmentId">所属部门</param>
        /// <param name="parentId">父级部门</param>
        /// <returns></returns>
        public ActionResult Folder(string companyId, string departmentId, string parentId)
        {
            var user = CurrentUser.CrmUser;
            if (string.IsNullOrEmpty(companyId))
            {
                companyId = user.CompanyId;         //当前登录用户所属单位ID
            }
            if (string.IsNullOrEmpty(departmentId))
            {
                departmentId = user.DeptId;   //当前登录用户所属部门ID
            }

            var companyEntity = new CrmCompanyBll().Get(companyId);
            var departmentEntity = new CrmDepartmentBll().Get(departmentId);

            var parentFolerEntity = new GridManagementInfoEntity();
            if (!string.IsNullOrEmpty(parentId))
            {
                parentFolerEntity = new GridManagementBll().SingleOrDefault(parentId);
            }


            ViewData["Company"] = companyEntity;
            ViewData["Department"] = departmentEntity;
            ViewData["ParentFolerEntity"] = parentFolerEntity;

            var gridList = new GridManagementBll().GetAllList(new GridManagementInfoEntity()
            {
                CompanyId = companyId,
                DeptId = departmentId,
                ParentId = parentId,
                GMType = departmentEntity.DeptType
            });

            //循环遍历计划子集文件夹的数量
            foreach (var gridManagementInfoEntity in gridList)
            {
                gridManagementInfoEntity.ChildCount = new GridManagementBll().ChildCount(gridManagementInfoEntity.ID);
            }

            return View(gridList);
        }

        /// <summary>
        /// 网格化管理-台账数据列表
        /// </summary>
        /// <param name="companyId">所属单位</param>
        /// <param name="departmentId">所属部门</param>
        /// <param name="parentId">台账分类ID</param>
        /// <param name="page">当前页索引</param>
        /// <returns></returns>
        public ActionResult FileList(string companyId, string departmentId, string parentId, int page = 1)
        {
            var user = CurrentUser.CrmUser;
            if (string.IsNullOrEmpty(companyId))
            {
                companyId = user.CompanyId;         //当前登录用户所属单位ID
            }
            if (string.IsNullOrEmpty(departmentId))
            {
                departmentId = user.DeptId;   //当前登录用户所属部门ID
            }

            var companyEntity = new CrmCompanyBll().Get(companyId);
            var departmentEntity = new CrmDepartmentBll().Get(departmentId);

            var parentFolerEntity = new GridManagementInfoEntity();
            var folerEntity = new GridManagementInfoEntity();
            if (!string.IsNullOrEmpty(parentId))
            {
                folerEntity = new GridManagementBll().Single(parentId);
                if (folerEntity != null && !string.IsNullOrEmpty(folerEntity.ID))
                {
                    parentFolerEntity = new GridManagementBll().SingleOrDefault(folerEntity.ParentId);
                }
            }

            ViewData["Company"] = companyEntity;
            ViewData["Department"] = departmentEntity;
            ViewData["FolerEntity"] = folerEntity;
            ViewData["ParentFolerEntity"] = parentFolerEntity;

            var list = new GridManagementFileInfoBll().GetSearchResult(new GridManagementFileInfoEntity()
            {
                CompanyId = companyId,
                DeptId = departmentId,
                GmId = parentId,
                page = new Page() { CurrentPage = page, PageSize = PageSize }
            });

            return View(list);
        }

        /// <summary>
        /// 网格化管理-评分
        /// </summary>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="departmentId">所属部门ID</param>
        /// <param name="parentId">网格ID</param>
        /// <param name="fileId">文件ID</param>
        /// <returns></returns>
        public ActionResult Grade(string companyId, string departmentId, string parentId, string fileId)
        {
            var entity = new GridManagementFileScoreInfoEntity
            {
                ID = Guid.NewGuid().ToString(),
                GmId = parentId,
                FileScoreTime = DateTime.Now,
                GmFileInfoId = fileId,
                CompanyId = companyId,
                DeptId = departmentId
            };

            return View(entity);
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns></returns>
        public ActionResult FileUpLoadPage(string companyId, string departmentId, string parentId)
        {
            var folerEntity = new GridManagementInfoEntity();
            if (!string.IsNullOrEmpty(parentId))
            {
                folerEntity = new GridManagementBll().Single(parentId);
            }

            var gridList = new GridManagementBll().GetSearchResult(new GridManagementInfoEntity()
            {
                CompanyId = companyId,
                DeptId = departmentId,
                ParentId = folerEntity.ParentId
            });

            ViewBag.CompanyId = companyId;
            ViewBag.DepartmentId = departmentId;

            ViewData["GridList"] = new SelectList(gridList, "Id", "GmName", folerEntity.ID);

            return View();
        }

        /// <summary>
        /// 添加文件夹
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public ActionResult AddFolder(string companyId, string departmentId, string parentId)
        {
            ViewBag.ParentId = parentId;
            ViewBag.CompanyId = companyId;
            ViewBag.DepartmentId = departmentId;

            return View();
        }

        /// <summary>
        /// 数据统计
        /// </summary>
        /// <param name="year"></param>
        /// <param name="quarter"></param>
        /// <returns></returns>
        public ActionResult GridStatistics(int year = 0, int quarter = 0)
        {
            var bll = new GridManagementFileScoreInfoBll();


            if (year == 0)
            {
                year = DateTime.Now.Year;
            }
            if (quarter == 0)
            {
                var currentQuarter = Convert.ToDouble(DateTime.Now.Month) / Convert.ToDouble(3);
                quarter = (int)Math.Ceiling(currentQuarter);
            }

            ViewData["Data"] = bll.GetData(year, quarter);  //查询各个区域扣分情况
            var gMdata = bll.GetGmData(year, quarter); //查询各个网格扣分情况
            ViewData["GM"] = bll.GetGmData(year, quarter);
            int b = gMdata.Rows.Cast<DataRow>().Sum(ia => int.Parse(ia["Score"].ToString()));
            var i = 0;
            var qwe = new string[gMdata.Rows.Count];
            foreach (DataRow item in gMdata.Rows)
            {
                qwe[i] = (double.Parse(item["Score"].ToString()) / b).ToString("0.0%");
                i++;
            }
            ViewData["arr"] = qwe;    //百分比
            ViewData["Table"] = bll.GetDataTable(year, quarter);   //查询数据列表
            ViewData["Years"] = bll.GetYears();

            ViewBag.DefaultYear = year;
            ViewBag.DefaultQuarter = quarter;

            return View();
        }

        /// <summary>
        /// 更多界面扣分明细列表
        /// </summary>
        /// <param name="year">扣分所属年度</param>
        /// <param name="quarter">扣分所属季度</param>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="deptId">所属部门ID</param>
        /// <param name="keywords">查询关键字</param>
        /// <param name="page">当前页码</param>
        /// <returns></returns>
        public ActionResult GridStatisticsMore(string year, string quarter, string companyId, string deptId, string keywords, int page = 1)
        {
            var gradeYear = DateTime.Now.Year;
            var gradeQuarter = (int)Math.Ceiling(Convert.ToDouble(DateTime.Now.Month) / Convert.ToDouble(3));

            if (!string.IsNullOrEmpty(year))
            {
                gradeYear = int.Parse(year);
            }

            if (!string.IsNullOrEmpty(quarter))
            {
                gradeQuarter = int.Parse(quarter);
            }


            ViewData["Years"] = new GridManagementFileScoreInfoBll().GetYears();

            ViewBag.DefaultYear = gradeYear;
            ViewBag.DefaultQuarter = gradeQuarter;
            ViewBag.Keywords = keywords;

            var data = new GridManagementFileScoreInfoBll().GetGradeData(gradeYear, gradeQuarter, keywords, page,
                                                                         PageSize);
            return View(data);
        }
        #endregion

        #region 数据请求
        /// <summary>
        /// 获取文件的路径
        /// </summary>
        /// <param name="id">文件ID</param>
        /// <param name="requestType">请求类别：Down\View</param>
        /// <returns></returns>
        public string GetFileUrl(string id, string requestType)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var entity = new GridManagementFileInfoBll().SingleOrDefault(id);
                if (entity != null && !string.IsNullOrEmpty(entity.ID) && !string.IsNullOrEmpty(entity.FileUrl))
                {
                    switch (CommonMethod.GetNetWork())
                    {
                        case CommonMethod.NetWorkEnum.Intranet:    //内网（直接访问存储服务器）
                            {
                                if (!string.IsNullOrEmpty(requestType))
                                {
                                    if (requestType.Equals("Down")) //下载
                                    {
                                        return AppConfig.LedgerFileViewLink + entity.FileUrl;
                                    }
                                    else
                                    {
                                        return !string.IsNullOrEmpty(entity.ConvertFileUrl)
                                                   ? (AppConfig.LedgerFileViewLink + entity.ConvertFileUrl)
                                                   : (AppConfig.LedgerFileViewLink + entity.FileUrl);
                                    }
                                }
                                break;
                            }
                        case CommonMethod.NetWorkEnum.OutNet:   //外网（将文件下载到应用服务器以供访问）
                            {
                                if (!string.IsNullOrEmpty(requestType))
                                {
                                    var urlpath = "/LedgerTempDown/";
                                    if (requestType.Equals("Down")) //下载
                                    {
                                        var saveAddr = AppConfig.FileSaveAddr + urlpath + entity.FileUrl;
                                        if (!System.IO.File.Exists(saveAddr))
                                        {
                                            //执行文件下载存储到本地
                                            CommonMethod.HttpDownload(AppConfig.LedgerFileViewLink + entity.FileUrl,
                                                                      saveAddr);

                                            return AppConfig.LedgerFileViewOutNetLink + urlpath + entity.FileUrl;
                                        }
                                        return AppConfig.LedgerFileViewOutNetLink + urlpath + entity.FileUrl;
                                    }
                                    else
                                    {
                                        var saveAddr = AppConfig.FileSaveAddr + urlpath +
                                                       (!string.IsNullOrEmpty(entity.ConvertFileUrl)
                                                            ? entity.ConvertFileUrl
                                                            : entity.FileUrl);


                                        if (!System.IO.File.Exists(saveAddr))
                                        {
                                            //下载地址
                                            var downLoadAddr = !string.IsNullOrEmpty(entity.ConvertFileUrl)
                                                                   ? (AppConfig.LedgerFileViewLink +
                                                                      entity.ConvertFileUrl)
                                                                   : (AppConfig.LedgerFileViewLink + entity.FileUrl);

                                            //执行文件下载存储到本地
                                            CommonMethod.HttpDownload(downLoadAddr, saveAddr);

                                            return AppConfig.LedgerFileViewOutNetLink + urlpath + (!string.IsNullOrEmpty(entity.ConvertFileUrl) ? entity.ConvertFileUrl : entity.FileUrl);
                                        }
                                        return AppConfig.LedgerFileViewOutNetLink + urlpath + (!string.IsNullOrEmpty(entity.ConvertFileUrl) ? entity.ConvertFileUrl : entity.FileUrl);
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            return "";
        }

        #endregion

        #region 数据提交
        /// <summary>
        /// 保存文件上传信息
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="fileAddress">文件地址</param>
        /// <param name="convertFileAddress">转换后的文件地址</param>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="deptId">所属部门ID</param>
        /// <param name="gridId">文件夹ID</param>
        /// <returns></returns>
        public string UpLoadFile(string fileName, string fileAddress, string convertFileAddress, string companyId, string deptId, string gridId)
        {
            var user = CurrentUser.CrmUser;
            try
            {
                var id = Guid.NewGuid().ToString();

                var entity = new GridManagementFileInfoEntity()
                {
                    ID = id,
                    GmFileName = fileName,
                    GmFileDescribe = "",
                    FileDel = 1,
                    FileDown = 1,
                    FileUrl = fileAddress,
                    ConvertFileUrl = convertFileAddress,
                    CompanyId = companyId.Trim(),
                    DeptId = deptId.Trim(),
                    GmId = gridId,
                    ROWSTATUS = 1,
                    CREATOR_ID = user.Id,
                    CREATE_BY = user.UserName,
                    CREATE_ON = DateTime.Now,
                    UPDATE_ID = user.Id,
                    UPDATE_BY = user.UserName,
                    UPDATE_ON = DateTime.Now
                };

                //数据保存
                new GridManagementFileInfoBll().PersistNewItem(entity);
                return id;
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        /// <summary>
        /// 保存评分信息
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="entity"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult GreadAdd(GridManagementFileScoreInfoEntity entity, FormCollection form)
        {
            var rtState = 0;
            try
            {
                var gradeQuarter = form["GradeQuarter"];
                int year = DateTime.Now.Year;
                int quarter = 1;

                if (!string.IsNullOrEmpty(gradeQuarter))
                {
                    year = int.Parse(gradeQuarter.Substring(0, 4));
                    quarter = int.Parse(gradeQuarter.Substring(5, 2));
                }

                var user = CurrentUser.CrmUser;
                entity.GradeYear = year;
                entity.GradeQuarter = quarter;
                entity.ROWSTATUS = 1;
                entity.CREATE_BY = user.UserName;
                entity.CREATE_ON = DateTime.Now;
                entity.CREATOR_ID = user.Id;
                entity.UPDATE_BY = user.UserName;
                entity.UPDATE_ID = user.Id;
                entity.UPDATE_ON = DateTime.Now;
                new GridManagementFileScoreInfoBll().PersistNewItem(entity);
                rtState = 0;
            }
            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "操作成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除上传的文件
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="ids">文件集（使用|进行分隔）</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult DeleteFile(string ids)
        {
            var rtState = 0;
            try
            {
                rtState = new GridManagementFileInfoBll().BatchDeleteFiles(ids) ? 0 : 1;
            }
            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "操作成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加文件夹
        /// </summary>
        /// <param name="folderName">文件夹名称</param>
        /// <param name="folderDircration">文件夹描述</param>
        /// <param name="sortCode">序号</param>
        /// <param name="parentId">上一级文件夹ID</param>
        /// <param name="companyId">所属单位ID</param>
        /// <param name="departmentId">所属部门ID</param>
        /// <returns></returns>
        public JsonResult SaveFolder(string folderName, string folderDircration, string companyId, string departmentId, int sortCode, string parentId)
        {
            var rtState = 0;
            try
            {
                var user = CurrentUser.CrmUser;
                //验证权限
                //var isCityPermission = new Membership.MembershipManager().Permissions(user.Id, "GridManagement", "CityPermission");
                //var isAreaPermission = new Membership.MembershipManager().Permissions(user.Id, "GridManagement", "AreaPermission");
                //var isDepartmentPermission = new Membership.MembershipManager().Permissions(user.Id, "GridManagement", "DepartmentPermission");

                var departmentEntity = new CrmDepartmentEntity();
                //if (!string.IsNullOrEmpty(departmentId))
                //{
                //    departmentEntity = new CrmDepartmentBll().SingleOrDefault(departmentId);
                //}

                //var companyId = "";
                //var departmentId = "";

                //if (isCityPermission)
                //{
                //    companyId = "";
                //    departmentId = "";
                //}
                //else if (isAreaPermission)
                //{
                //    companyId = user.CompanyId;
                //    departmentId = "";
                //}
                //else if (isDepartmentPermission)
                //{
                //    companyId = user.CompanyId;
                //    departmentId = user.DepartmentId;
                //}

                var entity = new GridManagementInfoEntity()
                {
                    ID = Guid.NewGuid().ToString(),
                    ParentId = string.IsNullOrEmpty(parentId) ? "" : parentId,
                    GmCode = "",
                    GmName = folderName,
                    SortCode = sortCode,
                    GMType = departmentEntity.DeptType,    //获取文件夹的类别
                    CompanyId = companyId,
                    DeptId = departmentId,
                    ROWSTATUS = 1,
                    CREATOR_ID = user.Id,
                    CREATE_BY = user.UserName,
                    CREATE_ON = DateTime.Now,
                    UPDATE_ID = user.Id,
                    UPDATE_BY = user.UserName,
                    UPDATE_ON = DateTime.Now
                };
                rtState = new GridManagementBll().PersistNewItem(entity) ? 0 : 1;   //创建文件
            }
            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "操作成功",
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="folderId">文件夹ID</param>
        /// <returns></returns>
        public JsonResult DeleteFolder(string folderId)
        {
            var rtState = 1;
            var rtMsg = "";
            //var delPermission = false;  //删除操作
            var delPermission = true;
            try
            {
                var user = CurrentUser.CrmUser;
                if (!string.IsNullOrEmpty(folderId))
                {
                    var entity = new GridManagementBll().SingleOrDefault(folderId);
                    if (entity != null && !string.IsNullOrEmpty(entity.ID))
                    {
                        //验证权限
                        //var isCityPermission = new Membership.MembershipManager().Permissions(user.Id, "GridManagement", "CityPermission");
                        //var isAreaPermission = new Membership.MembershipManager().Permissions(user.Id, "GridManagement", "AreaPermission");
                        //var isDepartmentPermission = new Membership.MembershipManager().Permissions(user.Id, "GridManagement", "DepartmentPermission");

                        var folderCompanyId = entity.CompanyId; //文件夹所属公司
                        var folderDeptId = entity.DeptId; //文件夹所属部门

                        //if (isCityPermission) //市级权限
                        //{
                        //    delPermission = true;
                        //}
                        //else if (isAreaPermission) //区级权限
                        //{
                        //    if (folderCompanyId.Equals(user.CompanyId))
                        //    {
                        //        delPermission = true;
                        //    }
                        //    else
                        //    {
                        //        rtMsg = "您没有权限对该文件夹进行删除操作！";
                        //    }
                        //}
                        //else if (isDepartmentPermission) //部门级权限
                        //{
                        //    if (folderCompanyId.Equals(user.CompanyId) && folderDeptId.Equals(user.DepartmentId))
                        //    //验证文件夹是否为当前部门所创建
                        //    {
                        //        delPermission = true;
                        //    }
                        //    else
                        //    {
                        //        rtMsg = "您没有权限对该文件夹进行删除操作！";
                        //    }
                        //}
                    }
                    if (delPermission) //执行删除
                    {
                        rtState = new GridManagementBll().Delete(folderId) ? 0 : 1;
                    }
                }
                else
                {
                    rtMsg = "传入值不正确！";
                }
            }
            catch (Exception)
            {
                rtState = 1;
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = rtMsg,
                rtState = rtState
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 数据统计报表
        /// <summary>
        /// 饼状图获取数据传入Echarts
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEchartsDate(int year, int quarter)
        {
            var bll = new GridManagementFileScoreInfoBll();
            var gMdata = bll.GetGmData(year, quarter);//查询各个网格扣分情况
            var list = (from p in gMdata.AsEnumerable()  //这个list是查出全部数据  
                        select new
                        {
                            Value = p.Field<int>("Score"),
                            Name = p.Field<string>("GMName")
                        }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 柱状图获取数据传入Echarts
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDate(int year, int quarter)
        {
            var bll = new GridManagementFileScoreInfoBll();
            //查询各个内容扣分情况
            DataTable gMdata = bll.GetContentTop(year, quarter);
            var list = (from p in gMdata.AsEnumerable()  //这个list是查出全部数据  
                        select new
                        {
                            Value = p.Field<int>("Score"),
                            Name = p.Field<string>("GMName")
                        }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
