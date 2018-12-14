using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Business.DoubleRandom;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;
using Yookey.WisdomClassed.SIP.Admin.Controllers;
using Newtonsoft.Json.Converters;
using Yookey.WisdomClassed.SIP.Common.PetaPoco;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Model.Crm;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Business.Com;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.PenaltyCaseSafty;
using System.Threading;

namespace Yookey.WisdomClassed.SIP.Admin.Areas.SIP.Controllers
{
    public class DoubleRandomController : BaseController
    {
        DoubleRandomEnterpriseBll _EntBll = new DoubleRandomEnterpriseBll();
        DoubleRandomRoadBll _RoadBll = new DoubleRandomRoadBll();
        DoubleRandomConstructionSiteBll _SiteBll = new DoubleRandomConstructionSiteBll();
        ComResourceBll _ComResourseBll = new ComResourceBll();

        //
        // GET: /ZFYWCL/DoubleRandom/

        #region View

        /// <summary>
        /// 双随机首页
        /// </summary>
        /// <returns></returns>
        public ActionResult DoubleRandomIndex(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                type = "1";
            }
            ViewBag.Type = type;
            return View();
        }

        /// <summary>
        /// 双随机结果
        /// </summary>
        /// <returns></returns>
        public ActionResult DoubleRandomResult(string Id, string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                type = "1";
            }
            ViewData["Id"] = Id;
            ViewBag.Type = type;
            return View();
        }
        /// <summary>
        /// 获取双随机结果列表
        /// </summary>
        /// <param name="txtName"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <summary>
        public string GetDoubleRandomData(string startTime, string endTime, string type, int rows = 30, int page = 1)
        {
            string randomType = "-1";
            if (!string.IsNullOrEmpty(type))
            {
                randomType = type;
            }
            if (!string.IsNullOrEmpty(startTime))
            {
                startTime = Convert.ToDateTime(startTime).ToString("yyyy-MM-dd");
                startTime = startTime + " 00:00:00.000";
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                endTime = Convert.ToDateTime(endTime).ToString("yyyy-MM-dd");
                endTime = endTime + " 23:59:59.997";
            }
            var data = new DoubleRandomSpotChecksBll().GetDoubleRandomSpotChecksList(startTime, endTime, randomType, rows, page);
            var result = CommonMethod.PageToJson(CommonMethod.PageToJqGridPage(data));
            return result;
        }

        /// <summary>
        /// 抽查结果详细
        /// </summary>
        /// <returns></returns>
        public ActionResult DoubleRandomDetail(string parentId, string type)
        {
            ViewBag.ParentId = parentId;
            ViewBag.RandomType = type;
            return View();
        }

        /// <summary>
        /// 抽查结果详细
        /// </summary>
        /// <returns></returns>
        public ActionResult DoubleRandomDetailResult(string parentId, string type)
        {
            ViewBag.ParentId = parentId;
            ViewBag.RandomType = type;
            return View();
        }


        /// <summary>
        /// 抽查结果列表
        /// </summary>
        /// <returns></returns>
        public string DoubleRandomDetailData(string parentId)
        {
            List<DoubleRandomObjLogEntity> data = new List<DoubleRandomObjLogEntity>();
            var datas = new DoubleRandomObjLogBll().GetBy(parentId);
            foreach (var item in datas)
            {
                item.TeamName = "";
                item.TypeName = "";
                if (!string.IsNullOrEmpty(item.TeamId))
                {
                    var tName = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity { Id = item.TeamId });
                    if (tName.Count > 0)
                    {
                        item.TeamName = tName[0].FullName;
                    }
                }
                if (!string.IsNullOrEmpty(item.TypeId))
                {
                    var pName = new ComResourceBll().GetSearchResult(new ComResourceEntity { Id = item.TypeId });
                    if (pName.Count > 0)
                    {
                        item.TypeName = pName[0].RsKey;
                    }
                }
                data.Add(item);
            }
            var result = JsonConvert.SerializeObject(data);
            return result;
        }

        /// <summary>
        /// 选择双随机人员
        /// </summary>
        /// <returns></returns>
        public ActionResult ChoosePerson(int num)
        {
            ViewBag.Num = num;
            var companys = new CrmCompanyBll().GetAllCompany();
            var dataAll = companys.Where(x => x.ParentId == "0").ToList();

            //所属机构
            var companyList = companys.Where(x => x.ParentId == dataAll[0].Id).OrderBy(p => p.SortCode).ToList();
            companyList.Insert(0, new CrmCompanyEntity { Id = "", FullName = "==请选择==" });
            ViewData["CompanyList"] = new SelectList(companyList, "Id", "FullName", "");

            //var personList = new CrmUserBll().GetAllUsers();
            ViewBag.PersonList = new List<CrmUserEntity>();
            return View();
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public string GetUserDropList(string companyId, string deptid)
        {
            if (deptid == "all")
            {
                deptid = "";
            }
            var udt = new CrmUserBll().GetAllUsers(new CrmUserEntity() { CompanyId = companyId, DepartmentId = deptid }).OrderBy(p => p.SortCode).ToList();
            var result = JsonConvert.SerializeObject(udt);
            return result;
        }

        /// <summary>
        /// 选择双随机对象
        /// </summary>
        /// <returns></returns>
        public ActionResult ChooseObject(string num)
        {
            var user = CurrentUser.CrmUser;
            //所属大队
            var teamList = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity()).ToList();
            teamList = teamList.Where(p => p.ParentId != "0").ToList();
            teamList.Insert(0, new CrmDepartmentEntity { Id = "", FullName = "==请选择==" });
            if (num == "1")//双随机抽查
            {
                var ccList = teamList.Where(p => p.Id == user.DeptId).ToList();
                if (ccList.Count > 0)
                {
                    ViewData["TeamList"] = new SelectList(ccList, "Id", "FullName", user.DeptId);
                }
                else
                {
                    ViewData["TeamList"] = new SelectList(teamList, "Id", "FullName", user.DeptId);
                }
            }
            if (num == "0")//双随机督查
            {
                ViewData["TeamList"] = new SelectList(teamList, "Id", "FullName", "");
            }
            //所属类型
            var typeList = _ComResourseBll.GetSearchResult(new ComResourceEntity { ParentId = "0094" }).ToList();
            typeList.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TypeList"] = new SelectList(typeList, "Id", "RSKEY", "");

            //所属类型(企业)
            List<ComResourceEntity> qyList = new List<ComResourceEntity>();
            qyList.Insert(0, new ComResourceEntity { Id = "", RsKey = "企业" });
            ViewData["QYList"] = new SelectList(qyList, "Id", "RSKEY", "");

            ViewBag.Type = num;
            return View();
        }

        /// <summary>
        /// 等待界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Loading(string Id,string Type)
        {
            ViewData["Id"] = Id;
            ViewData["Type"] = Type;
            return View();
        }
        /// <summary>
        /// 保存双随机结果
        /// </summary>
        /// <param name="entity">表单实体</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveRandomResult(string checkMemberIds, string checkMembers, string checkObjIds, string checkObjs, string checkObjTeams, string checkObjTypes, string type)
        {
            var user = CurrentUser.CrmUser;
            //双随机批次
            DoubleRandomSpotChecksEntity spotEntity = new DoubleRandomSpotChecksEntity();
            spotEntity.Id = Guid.NewGuid().ToString();
            spotEntity.CreatorId = user.Id;
            spotEntity.CreateBy = user.UserName;
            spotEntity.CreateOn = DateTime.Now;
            spotEntity.RowStatus = 1;
            spotEntity.UpdateOn = DateTime.Now;
            spotEntity.RandomType = type;
            spotEntity.IsDispatch = 0;
            //双随机记录
            DoubleRandomObjLogEntity entity = new DoubleRandomObjLogEntity();
            entity.ParentId = spotEntity.Id;
            entity.CreatorId = user.Id;
            entity.CreateBy = user.UserName;
            entity.CreateOn = DateTime.Now;
            entity.RowStatus = 1;
            entity.UpdateOn = DateTime.Now;
            entity.IsDispatch = 0;
            //entity.FinishTime = null;

            var isOk = false;
            var rtMsg = "";

            List<string> memberIdsList = new List<string>();
            List<string> membersList = new List<string>();
            List<string> checkObjIdsList = new List<string>();
            List<string> checkObjsList = new List<string>();
            List<string> checkObjTeamsList = new List<string>();
            List<string> checkObjTypesList = new List<string>();
            try
            {
                if (!string.IsNullOrEmpty(checkMemberIds))
                {
                    checkMemberIds = checkMemberIds.Trim('★').Trim();
                    checkMembers = checkMembers.Trim('★').Trim();
                    memberIdsList = checkMemberIds.Split('★').ToList();
                    membersList = checkMembers.Split('★').ToList();
                    spotEntity.CheckGroup = memberIdsList.Count();
                    spotEntity.CheckPersonNum = checkMemberIds.Split(';', '★').ToList().Count();
                }
                if (!string.IsNullOrEmpty(checkObjIds))
                {
                    checkObjIds = checkObjIds.Trim(';').Trim();
                    checkObjs = checkObjs.Trim(';').Trim();
                    checkObjTeams = checkObjTeams.Trim(';').Trim();
                    checkObjTypes = checkObjTypes.Trim(';').Trim();
                    checkObjIdsList = checkObjIds.Split(';').ToList();
                    checkObjsList = checkObjs.Split(';').ToList();
                    checkObjTeamsList = checkObjTeams.Split(';').ToList();
                    checkObjTypesList = checkObjTypes.Split(';').ToList();
                }


                spotEntity.CheckNo = checkObjIdsList.Count();
                spotEntity.ObjNo = checkObjIdsList.Count();
                isOk = new DoubleRandomSpotChecksBll().Insert(spotEntity);

                //OverallMemberIdsList = memberIdsList;




                //for (int i = 0; i < checkObjIdsList.Count; i++)
                //{
                //    Random r = new Random();
                //    int random = r.Next(0, memberIdsList.Count - 1);
                //    entity.InspectorIds = memberIdsList[random];
                //    entity.InspectorNames = membersList[random];

                //    entity.Id = Guid.NewGuid().ToString();
                //    entity.ObjId = checkObjIdsList[i];
                //    entity.ObjName = checkObjsList[i];
                //    entity.TeamId = checkObjTeamsList[i];
                //    entity.TypeId = checkObjTypesList[i];
                //    isOk = new DoubleRandomObjLogBll().Insert(entity);
                //}

                List<string> deptList = new List<string>();

                double numCount = (double)checkObjIdsList.Count() / (double)memberIdsList.Count();
                numCount = Math.Ceiling(numCount);
                int numListCount = int.Parse(numCount.ToString());

                //循环次数
                //int num = checkObjIdsList.Count() % memberIdsList.Count() != 0 ? (checkObjIdsList.Count() / memberIdsList.Count()) + 1 : checkObjIdsList.Count() / memberIdsList.Count();
                for (int i = 0; i < checkObjIdsList.Count; i++)
                {
                    string users = "";
                    string usersid = "";
                    //抽查对象
                    entity.Id = Guid.NewGuid().ToString();
                    entity.ObjId = checkObjIdsList[i];
                    entity.ObjName = checkObjsList[i];
                    int j = CheckUser(memberIdsList, membersList, numListCount, out users, out usersid);
                    entity.InspectorIds = usersid;
                    entity.InspectorNames = users;
                    entity.TeamId = checkObjTeamsList[i];
                    entity.TypeId = checkObjTypesList[i];
                    isOk = new DoubleRandomObjLogBll().Insert(entity);
                    OverallMemberIdsList.Add(usersid);

                }

                //int num = checkObjIdsList.Count() % memberIdsList.Count() != 0 ? (checkObjIdsList.Count() / memberIdsList.Count()) + 1 : checkObjIdsList.Count() / memberIdsList.Count();
                //spotEntity.CheckNo = num;
                //spotEntity.ObjNo = checkObjIdsList.Count();
                //isOk = new DoubleRandomSpotChecksBll().Insert(spotEntity);
                //for (int i = 0; i < memberIdsList.Count(); i++)
                //{
                //    entity.InspectorIds = memberIdsList[i];
                //    entity.InspectorNames = membersList[i];
                //    var ranArr = GetRandomArray(num, 0, checkObjIdsList.Count);//随机一次
                //    for (int j = 0; j < ranArr.Length; j++)
                //    {
                //        entity.Id = Guid.NewGuid().ToString();
                //        entity.ObjId = checkObjIdsList[ranArr[j]];
                //        entity.ObjName = checkObjsList[ranArr[j]];
                //        entity.TeamId = checkObjTeamsList[ranArr[j]];
                //        entity.TypeId = checkObjTypesList[ranArr[j]];
                //        isOk = new DoubleRandomObjLogBll().Insert(entity);
                //    }
                //}
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
                rtMsrg = spotEntity.Id.ToString()
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        List<string> OverallMemberIdsList = new List<string>();
        

        public int CheckUser(List<string> users, List<string> usersName ,int count,out string usersNames, out string userId)
        {
            Thread.Sleep(100);
            Random r = new Random();
            int random = r.Next(0, users.Count);
            //OverallMemberIdsList.Where(p=>p ==
            if (OverallMemberIdsList.Any())
            {
                int counts = 0;
                List<string> lst = OverallMemberIdsList.Where(p => p == users[random]).ToList();
                if (lst.Count > 0 )
                {
                    counts++;
                }
                //for (int i = 0; i < OverallMemberIdsList.Count; i++)
                //{
                //    if (OverallMemberIdsList[i] == users[random])
                //    {
                //        counts++;
                //    }
                //}
                if (counts < count)
                {
                    userId = users[random];
                    usersNames = usersName[random];
                    return random;
                }
                else
                {
                    CheckUser(users,usersName, count,out usersNames,out userId);
                }
            }
            else
            {
                userId = users[random];
                usersNames = usersName[random];
                return random;
            }
            return random;
            
            //var q = from string s in OverallMemberIdsList
            //        where s == users[random].ToString()
            //            select s;
            //if (q.Count() <= count)
            //{
            //    return random;
            //}
            //else
            //{
            //    CheckUser(users,count);
            //}
            //return random;
        }


        /// <summary>
        /// 双随机对象管理
        /// </summary>
        /// <returns></returns>
        public ActionResult ObjectManager(string teamId, string typeId, string objName, int rows = 30, int page = 1)
        {
            //所属大队
            var teamList = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity()).ToList();
            teamList = teamList.Where(p => p.ParentId != "0" && p.FullName.Contains("社工委") || p.FullName.Contains("街道")).ToList();
            teamList.Insert(0, new CrmDepartmentEntity { Id = "", FullName = "==请选择==" });
            ViewData["TeamList"] = new SelectList(teamList, "Id", "FullName", teamId);
            //所属类型
            var typeList = _ComResourseBll.GetSearchResult(new ComResourceEntity { ParentId = "0094" }).ToList();
            ViewBag.TypeList = typeList;
            List<int> typeCount = new List<int>();
            int count = 0;
            foreach (var item in typeList)
            {
                count = new DoubleRandomObjBll().GetSearchList(new DoubleRandomObjEntity { TeamId = teamId, TypeId = item.Id }).Count;
                typeCount.Add(count);
            }
            ViewData["TypeCountList"] = typeCount;

            var data = new EnterpriseBll().QueryEnterpriseList(objName, null, null, rows, page);
            ViewBag.QYCount = data.records;
            return View();
        }

        public string GetObjectManager(string teamId, string typeId, string objName, int rows = 30, int page = 1)
        {
            if (string.IsNullOrEmpty(typeId))
            {
                typeId = "00940001";
            }
            var data = new DoubleRandomObjBll().GetDoubleRandomObjList(teamId, typeId, objName, rows, page);
            foreach (var item in data.Items)
            {
                item.TeamName = new CrmDepartmentBll().Get(item.TeamId).FullName;
            }
            var result = CommonMethod.PageToJson(CommonMethod.PageToJqGridPage(data));
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteRandomResult(string parentId)
        {
            var isOk = false;
            try
            {
                if (!string.IsNullOrEmpty(parentId))
                {
                    parentId = parentId.Trim();
                    if (new DoubleRandomObjLogBll().DeleteLog(parentId) && new DoubleRandomSpotChecksBll().DeleteSpot(parentId))
                    {
                        isOk = true;
                    }
                    else
                    {
                        isOk = false;
                    }
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 派发
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DispatchRandomResult(string parentId)
        {
            var isOk = false;
            try
            {
                if (!string.IsNullOrEmpty(parentId))
                {
                    parentId = parentId.Trim();
                    if (new DoubleRandomObjLogBll().UpdateLog(parentId))
                    {
                        new DoubleRandomSpotChecksBll().UpdateIsDispatch(parentId);
                        isOk = true;
                    }
                    else
                    {
                        isOk = false;
                    }
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteDoubleRandomObj(string ids)
        {
            var isOk = false;
            try
            {
                if (!string.IsNullOrEmpty(ids))
                {
                    ids = ids.Trim(',');
                    List<string> idList = ids.Split(',').ToList();
                    foreach (var item in idList)
                    {
                        if (new DoubleRandomObjBll().DeleteObj(item))
                        {
                            isOk = true;
                        }
                        else
                        {
                            isOk = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                isOk = false;
            }
            var result = new StatusModel<DBNull>
            {
                rtState = isOk ? 1 : -1,
                rtData = null,
                rtObj = null,
                rtMsrg = "成功"
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 对象新增
        /// </summary>
        /// <returns></returns>
        public ActionResult DoubleRandomObjAdd(string id)
        {
            var model = new DoubleRandomObjEntity();
            var user = CurrentUser.CrmUser;
            if (string.IsNullOrEmpty(id))
            {
                model.Id = Guid.NewGuid().ToString();
                model.CreateOn = DateTime.Now;
                model.CreatorId = user.Id;
                model.CreateBy = user.UserName;
                model.RowStatus = 1;
            }
            else
            {
                model = new DoubleRandomObjBll().Get(id);
            }
            //所属大队
            var teamList = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity()).ToList();
            teamList = teamList.Where(p => p.ParentId != "0" && p.FullName.Contains("社工委") || p.FullName.Contains("街道")).ToList();
            teamList.Insert(0, new CrmDepartmentEntity { Id = "", FullName = "==请选择==" });
            ViewData["TeamList"] = new SelectList(teamList, "Id", "FullName", model.TeamId);
            //所属类型
            var typeList = _ComResourseBll.GetSearchResult(new ComResourceEntity { ParentId = "0094" }).ToList();
            typeList.Insert(0, new ComResourceEntity { Id = "", RsKey = "==请选择==" });
            ViewData["TypeList"] = new SelectList(typeList, "Id", "RSKEY", model.TypeId);

            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveDoubleRandomObj(DoubleRandomObjEntity entity)
        {
            var isOk = false;
            var rtMsg = "";
            try
            {
                entity.UpdateOn = DateTime.Now;
                entity.RowStatus = (int)RowStatus.Normal;
                if (!string.IsNullOrEmpty(entity.Id))
                {
                    var ent = new DoubleRandomObjBll().Get(entity.Id);
                    if (ent != null)
                    {
                        entity.CreateBy = ent.CreateBy;
                        entity.CreatorId = ent.CreatorId;
                        entity.CreateOn = ent.CreateOn;
                        entity.UpdateBy = CurrentUser.CrmUser.UserName;
                        entity.UpdateId = CurrentUser.CrmUser.Id;
                        isOk = new DoubleRandomObjBll().Update(entity);
                    }
                }
                else
                {
                    entity.Id = Guid.NewGuid().ToString();
                    entity.CreateBy = CurrentUser.CrmUser.UserName;
                    entity.CreatorId = CurrentUser.CrmUser.Id;
                    entity.CreateOn = DateTime.Now;
                    entity.RandomNo = new DoubleRandomObjBll().GetRandomNo(entity.TeamId) + 1;
                    isOk = new DoubleRandomObjBll().Insert(entity);
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

        #region 企业界面

        /// <summary>
        /// 企业编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult EnterpriseEdit(string Pk_Id)
        {
            DoubleRandomEnterpriseEntity EnterpriseEntity = null;

            ///行业类型大类
            List<ComResourceEntity> CATEGORYI_List = _ComResourseBll.GetListBy("0084", "");
            CATEGORYI_List.Insert(0, new ComResourceEntity { Id = "", RsKey = "--请选择--" });
            ViewData["INDUSTRY_CATEGORYI_List"] = new SelectList(CATEGORYI_List, "Id", "RsKey", "");

            ///行业类型中类
            List<ComResourceEntity> CATEGORYII_List = _ComResourseBll.GetListBy("0085", "");
            CATEGORYII_List.Insert(0, new ComResourceEntity { Id = "", RsKey = "--请选择--" });
            ViewData["INDUSTRY_CATEGORYII_List"] = new SelectList(CATEGORYII_List, "Id", "RsKey", "");

            ///行业类型中类
            List<ComResourceEntity> CATEGORYIII_List = _ComResourseBll.GetListBy("0086", "");
            CATEGORYIII_List.Insert(0, new ComResourceEntity { Id = "", RsKey = "--请选择--" });
            ViewData["INDUSTRY_CATEGORYIII_List"] = new SelectList(CATEGORYIII_List, "Id", "RsKey", "");

            var EntList = _EntBll.GetSearchListForEnterprise(new DoubleRandomEnterpriseEntity { ID = Pk_Id });
            if (!string.IsNullOrEmpty(Pk_Id))
            {
                if (EntList.Count > 0)
                {
                    EnterpriseEntity = EntList.Where(p => p.ID == Pk_Id).ToList()[0];
                }
            }
            else
            {
                EnterpriseEntity = new DoubleRandomEnterpriseEntity();
                EnterpriseEntity.ID = Guid.NewGuid().ToString();
            }
            return View(EnterpriseEntity);
        }

        /// <summary>
        /// 企业列表
        /// </summary>
        /// <returns></returns>
        public ActionResult EnterpriseList(string txtName, int rows = 30, int page = 10)
        {
            //var search = new DoubleRandomEnterpriseEntity
            //{
            //    page = new Page { CurrentPage = page, PageSize = PageSize }
            //};
            //var list = new DoubleRandomEnterpriseBll().GetSearchResult(search);
            //return View(new DoubleRandomEnterpriseBll().GetSearchResult(search));
            //var data = _EntBll.GetSearchResult("1", txtName, rows, page);
            //var result = Yookey.WisdomClassed.SIP.Common.PetaPoco.CommonMethod.PageToJson(Yookey.WisdomClassed.SIP.Common.PetaPoco.CommonMethod.PageToJqGridPage(data));
            //return result;

            return View();
        }


        #endregion

        #region 门店

        /// <summary>
        /// 门店列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ShopList()
        {
            return View();
        }

        /// <summary>
        /// 门店编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult ShopEdit()
        {
            return View();
        }

        #endregion


        #endregion

        #region Mothod

        #region 企业方法


        public string GetCompany(string txtName, int rows = 30, int page = 10)
        {
            var data = _EntBll.GetSearchResult("1", txtName, rows, page);
            var result = Yookey.WisdomClassed.SIP.Common.PetaPoco.CommonMethod.PageToJson(Yookey.WisdomClassed.SIP.Common.PetaPoco.CommonMethod.PageToJqGridPage(data));
            return result;
        }

        /// <summary>
        /// 保存企业
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public string SaveEnterprise(DoubleRandomEnterpriseEntity entity, FormCollection collection)
        {
            string RtMsrg;
            int RtState;
            try
            {
                bool flag;

                var EntEntityList = _EntBll.GetSearchListForEnterprise(new DoubleRandomEnterpriseEntity { ID = entity.ID });
                var EntEntity = EntEntityList.Count > 0 ? EntEntityList[0] : null;

                if (EntEntity == null)
                {
                    EntEntity = new DoubleRandomEnterpriseEntity();
                    EntEntity.ID = entity.ID;
                    EntEntity.COMPANY_NAME = entity.COMPANY_NAME;
                    EntEntity.ORGANIZATION_CODE = entity.ORGANIZATION_CODE;
                    EntEntity.LEGAL_REPRESENTATIVE = entity.LEGAL_REPRESENTATIVE;
                    EntEntity.PHONE = entity.PHONE;
                    EntEntity.REGISTERED_ADDRESS = entity.REGISTERED_ADDRESS;
                    EntEntity.PRODUCTION_ADDRESS = entity.PRODUCTION_ADDRESS;
                    EntEntity.INDUSTRY_CATEGORYI = entity.INDUSTRY_CATEGORYI;
                    EntEntity.INDUSTRY_CATEGORYI_NAME = !string.IsNullOrEmpty(EntEntity.INDUSTRY_CATEGORYI) ? _ComResourseBll.GetListBy("", EntEntity.INDUSTRY_CATEGORYI)[0].RsKey : "";
                    EntEntity.INDUSTRY_CATEGORYII = entity.INDUSTRY_CATEGORYII;
                    EntEntity.INDUSTRY_CATEGORYII_NAME = !string.IsNullOrEmpty(EntEntity.INDUSTRY_CATEGORYII) ? _ComResourseBll.GetListBy("", EntEntity.INDUSTRY_CATEGORYII)[0].RsKey : "";
                    EntEntity.INDUSTRY_CATEGORYIII = entity.INDUSTRY_CATEGORYIII;
                    EntEntity.INDUSTRY_CATEGORYIII_NAME = !string.IsNullOrEmpty(EntEntity.INDUSTRY_CATEGORYIII) ? _ComResourseBll.GetListBy("", EntEntity.INDUSTRY_CATEGORYIII_NAME)[0].RsKey : "";
                    EntEntity.ROWSTATUS = 1;
                    EntEntity.CREATOR_ID = "";
                    EntEntity.CREATE_BY = "";
                    EntEntity.CREATE_ON = DateTime.Now;
                    EntEntity.UPDATE_ID = "";
                    EntEntity.UPDATE_BY = "";
                    EntEntity.UPDATE_ON = DateTime.Now;
                    flag = _EntBll.InsertEnt(EntEntity);
                }
                else
                {
                    EntEntity.COMPANY_NAME = entity.COMPANY_NAME;
                    EntEntity.ORGANIZATION_CODE = entity.ORGANIZATION_CODE;
                    EntEntity.LEGAL_REPRESENTATIVE = entity.LEGAL_REPRESENTATIVE;
                    EntEntity.PHONE = entity.PHONE;
                    EntEntity.REGISTERED_ADDRESS = entity.REGISTERED_ADDRESS;
                    EntEntity.PRODUCTION_ADDRESS = entity.PRODUCTION_ADDRESS;
                    EntEntity.INDUSTRY_CATEGORYI = entity.INDUSTRY_CATEGORYI;
                    EntEntity.INDUSTRY_CATEGORYI_NAME = EntEntity.INDUSTRY_CATEGORYI != "" ? _ComResourseBll.GetListBy("", EntEntity.INDUSTRY_CATEGORYI)[0].RsKey : "";
                    EntEntity.INDUSTRY_CATEGORYII = entity.INDUSTRY_CATEGORYII;
                    EntEntity.INDUSTRY_CATEGORYII_NAME = EntEntity.INDUSTRY_CATEGORYII != "" ? _ComResourseBll.GetListBy("", EntEntity.INDUSTRY_CATEGORYII)[0].RsKey : "";
                    EntEntity.INDUSTRY_CATEGORYIII = entity.INDUSTRY_CATEGORYIII;
                    EntEntity.INDUSTRY_CATEGORYIII_NAME = EntEntity.INDUSTRY_CATEGORYIII != "" ? _ComResourseBll.GetListBy("", EntEntity.INDUSTRY_CATEGORYIII_NAME)[0].RsKey : "";
                    EntEntity.ROWSTATUS = 1;
                    EntEntity.CREATOR_ID = entity.CREATOR_ID;
                    EntEntity.CREATE_BY = entity.CREATE_BY;
                    EntEntity.CREATE_ON = entity.CREATE_ON;
                    EntEntity.UPDATE_ID = "";
                    EntEntity.UPDATE_BY = "";
                    EntEntity.UPDATE_ON = DateTime.Now;
                    flag = _EntBll.UpdateEnt(EntEntity);
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


        /// <summary>
        /// 保存双随机
        /// </summary>
        /// <returns></returns>
        public string SaveDoubleRandom()
        {
            return "";
        }

        [HttpPost]
        public string GetListPage(string limit, string offset)
        {
            List<DoubleRandomEnterpriseEntity> list = _EntBll.GetSearchListForEnterprise(new DoubleRandomEnterpriseEntity { });
            var s = new
            {
                total = list.Count,
                rows = list
            };

            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd" };
            var result = JsonConvert.SerializeObject(s, timeConverter);

            return result;
        }

        #endregion

        #region 双随机抽取对象
        /// <summary>
        /// 随机人员分组
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public JsonResult RandomPerson(string ids, int num)
        {
            ids = ids.Trim(';');
            //string[] idArr = ids.Split(';');
            //形成抽查人员string
            StringBuilder sbMember = new StringBuilder();
            //形成抽查人员Id的string
            StringBuilder sbMemberIds = new StringBuilder();

            var user = CurrentUser.CrmUser;
            var groupInfo = new GroupInfo();
            var isOk = false;
            var rtMsg = "";
            try
            {
                if (!string.IsNullOrEmpty(ids) && !string.IsNullOrEmpty(ids.Trim(';').Trim()))
                {
                    List<string> memberIdsList = ids.Split(';').ToList();
                    int s = memberIdsList.Count / num;
                    int y = memberIdsList.Count % num;
                    if (y > 0)
                    {
                        s = s + 1;
                    }
                    for (int m = 0; m < s; m++)
                    {
                        string memberStr = "";
                        string memberIds = "";
                        if (memberIdsList.Count < num)
                        {
                            for (int i = 0; i < memberIdsList.Count; i++)
                            {
                                memberStr += GetMemberName(memberIdsList[i]) + ";";
                                memberIds += memberIdsList[i] + ";";
                            }
                        }
                        else
                        {
                            var ranArr = GetRandomArray(num, 0, memberIdsList.Count);//随机一次
                            for (int i = 0; i < ranArr.Length; i++)
                            {
                                memberIds += memberIdsList[ranArr[i]] + ";";
                                memberStr += GetMemberName(memberIdsList[ranArr[i]]) + ";";
                            }
                            for (int i = 0; i < ranArr.Length; i++)
                            {
                                for (int j = i + 1; j < ranArr.Length; j++)
                                {
                                    if (ranArr[i] < ranArr[j])
                                    {
                                        var arr = ranArr[i];
                                        ranArr[i] = ranArr[j];
                                        ranArr[j] = arr;
                                    }
                                }
                            }
                            for (int j = 0; j < num; j++)
                            {
                                memberIdsList.Remove(memberIdsList[ranArr[j]]);
                            }
                        }
                        sbMember.Append(memberStr.Trim(';')).Append("★");
                        sbMemberIds.Append(memberIds.Trim(';')).Append("★");
                    }
                    isOk = true;
                    rtMsg = "分组成功！";
                    groupInfo.groupID = sbMemberIds.ToString();
                    groupInfo.groupName = sbMember.ToString();
                }
                else
                {
                    rtMsg = "请勾选相关人员！";
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
                rtObj = groupInfo,
                rtMsrg = rtMsg
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public string GetMemberName(string id)
        {
            return new CrmUserBll().Get(id).RealName;
        }

        /// <summary>
        /// 双随机人员
        /// </summary>
        /// <returns></returns>
        public string GetRandomPerson(string companyId, string deptId, string num)
        {
            if (deptId == "all")
            {
                deptId = "";
            }
            var udt = new CrmUserBll().GetAllUsers(new CrmUserEntity() { CompanyId = companyId, DepartmentId = deptId });
            int numb = Convert.ToInt32(num);
            if (int.Parse(num) > udt.Count)
            {
                num = udt.Count.ToString();
            }
            var groupInfo = new GroupInfo();
            //List<CrmUserEntity> entityList = new List<CrmUserEntity>();
            var ranArr = GetRandomArray(int.Parse(num), 0, udt.Count);//随机一次
            for (int i = 0; i < ranArr.Length; i++)
            {
                groupInfo.groupName += udt[ranArr[i]].RealName + ";";
                groupInfo.groupID += udt[ranArr[i]].Id + ";";
                //entityList.Add(udt[ranArr[i]]);
            }
            //ViewData["ObjList"] = entityList;
            var result = JsonConvert.SerializeObject(groupInfo);
            return result;
            //return View();
        }

        /// <summary>
        /// 双随机人员
        /// </summary>
        /// <returns></returns>
        public string GetRandomPersonFrom(string names, string ids, string num)
        {
            names = names.Trim().Trim(';');
            ids = ids.Trim().Trim(';');
            var nameList = names.Split(';');
            var idsList = ids.Split(';');
            int numb = Convert.ToInt32(num);
            if (int.Parse(num) > idsList.Length)
            {
                num = idsList.Length.ToString();
            }
            var groupInfo = new GroupInfo();
            var ranArr = GetRandomArray(int.Parse(num), 0, idsList.Length);//随机一次
            for (int i = 0; i < ranArr.Length; i++)
            {
                groupInfo.groupName += nameList[ranArr[i]] + ";";
                groupInfo.groupID += idsList[ranArr[i]] + ";";
            }
            var result = JsonConvert.SerializeObject(groupInfo);
            return result;
        }

        /// <summary>
        /// 双随机对象
        /// </summary>
        /// <returns></returns>
        public string RandomObj(string teamId, string typeId, string num)
        {
            DataTable entDt = new EnterpriseBll().QueryEnterpriseList();
            foreach (var item in entDt.Rows)
            {

            }
            int numb = Convert.ToInt32(num);
            DoubleRandomObjEntity entity = new DoubleRandomObjEntity();
            entity.TeamId = teamId;
            entity.TypeId = typeId;
            List<DoubleRandomObjEntity> entityList = new List<DoubleRandomObjEntity>();
            var objList = new DoubleRandomObjBll().GetSearchList(entity);
            if (int.Parse(num) > objList.Count)
            {
                num = objList.Count.ToString();
            }
            var ranArr = GetRandomArray(int.Parse(num), 0, objList.Count);//随机一次
            for (int i = 0; i < ranArr.Length; i++)
            {
                entityList.Add(objList[ranArr[i]]);
            }
            //ViewData["ObjList"] = entityList;
            var result = JsonConvert.SerializeObject(entityList);
            return result;
            //return View();
        }

        /// <summary>
        /// 双随机督查对象部门
        /// </summary>
        /// <returns></returns>
        public string RandomObjFromDept(string num)
        {
            int numb = Convert.ToInt32(num);
            //所属大队
            var teamList = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity()).ToList();
            teamList = teamList.Where(p => p.ParentId != "0").ToList();

            List<CrmDepartmentEntity> entityList = new List<CrmDepartmentEntity>();
            if (int.Parse(num) > teamList.Count)
            {
                num = teamList.Count.ToString();
            }
            var ranArr = GetRandomArray(int.Parse(num), 0, teamList.Count);//随机一次
            for (int i = 0; i < ranArr.Length; i++)
            {
                entityList.Add(teamList[ranArr[i]]);
            }
            var result = JsonConvert.SerializeObject(entityList);
            return result;
        }

        /// <summary>
        /// 双随机督查对象类型
        /// </summary>
        /// <returns></returns>
        public string RandomObjFromType(string num)
        {
            int numb = Convert.ToInt32(num);
            //所属大队
            var typeList = _ComResourseBll.GetSearchResult(new ComResourceEntity { ParentId = "0094" }).ToList();

            List<ComResourceEntity> entityList = new List<ComResourceEntity>();
            if (int.Parse(num) > typeList.Count)
            {
                num = typeList.Count.ToString();
            }
            var ranArr = GetRandomArray(int.Parse(num), 0, typeList.Count);//随机一次
            for (int i = 0; i < ranArr.Length; i++)
            {
                entityList.Add(typeList[ranArr[i]]);
            }
            var result = JsonConvert.SerializeObject(entityList);
            return result;
        }

        /// <summary>
        /// 双随机抽取企业
        /// </summary>
        /// <returns></returns>
        public string RandomObjFromQY(string num)
        {
            int numb = Convert.ToInt32(num);
            List<ComResourceEntity> qyList = new List<ComResourceEntity>();
            DataTable entDt = new EnterpriseBll().QueryEnterpriseList();
            string str = string.Empty;

            List<ComResourceEntity> entityList = new List<ComResourceEntity>();
            List<string> lst = new List<string>();

            var ranArr = GetRandomArray(int.Parse(num), 0, entDt.Rows.Count);//随机一次
            for (int i = 0; i < ranArr.Length; i++)
            {
                entityList.Add(new ComResourceEntity()
                {
                    RsKey = entDt.Rows[ranArr[i]]["企业名称"].ToString()
                });
            }

            //for (int i = 0; i < int.Parse(num); i++)
            //{
            //    Random r = new Random();
            //    int random = r.Next(0, entDt.Rows.Count);
            //    DataRow dataRow = entDt.Rows[random];

            //    //EntList entity = new EntList() { RsKey = dataRow["企业名称"].ToString() };

            //    lst.Add(dataRow["企业名称"].ToString());


            //    ComResourceEntity entity = new ComResourceEntity()
            //    {
            //        RsKey = dataRow["企业名称"].ToString()
            //    };
            //    entityList.Add(entity);
            //}

            // if (entDt != null && entDt.Rows.Count > 0)
            //{
            //    qyList = (from p in entDt.AsEnumerable()
            //                  select new ComResourceEntity  //new一个TempDetainInfoEntity对象  
            //            {
            //                RsKey = p.Field<string>("企业名称")
            //            }).ToList(); //将这个TempDetainInfoEntity类对象转换成list  
            //}


            //List<ComResourceEntity> entityList = new List<ComResourceEntity>();
            //if (int.Parse(num) > qyList.Count)
            //{
            //    num = qyList.Count.ToString();
            //}
            //var ranArr = GetRandomArray(int.Parse(num), 0, qyList.Count);//随机一次
            //for (int i = 0; i < ranArr.Length; i++)
            //{
            //    entityList.Add(qyList[ranArr[i]]);
            //}
            var result = JsonConvert.SerializeObject(entityList);
            return result;
        }

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="Number">随机数个数</param>
        /// <param name="minNum">随机数下限</param>
        /// <param name="maxNum">随机数上限</param>
        /// <returns></returns>
        public int[] GetRandomArray(int Number, int minNum, int maxNum)
        {
            int j;
            int[] b = new int[Number];
            Random r = new Random();
            for (j = 0; j < Number; j++)
            {
                int i = r.Next(minNum, maxNum);
                int num = 0;
                for (int k = 0; k < j; k++)
                {
                    if (b[k] == i)
                    {
                        num = num + 1;
                    }
                }
                if (num == 0)
                {
                    b[j] = i;
                }
                else
                {
                    j = j - 1;
                }
            }
            return b;
        }

        /// <summary>
        /// 判断任务是否派发
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public string CheckLogIsDisPatch(string parentId)
        {
            List<DoubleRandomObjLogEntity> LogList =  new DoubleRandomObjLogBll().GetBy(parentId);
            if (LogList.Any())
            {
                if (LogList[0].IsDispatch == 1)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            return "1";
        }

        #endregion
        
    }
    /// <summary>
    /// 返回值
    /// </summary>
    public class GroupInfo
    {
        public string groupID { get; set; }
        public string groupName { get; set; }
    }

    /// <summary>
    /// 企业
    /// </summary>
    public class EntList {
        public string RsKey { get; set; }
    }
}
