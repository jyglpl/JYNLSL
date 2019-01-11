using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Admin.Models;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Model;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers
{
    public class WorkListController : BaseController
    {

        readonly CrmMessageWorkBll _crmMessageWorkBll = new CrmMessageWorkBll();    //待办事宜

        //
        // GET: /WorkList/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询消息条数
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public string GridWorkCount()
        {
            var user = CurrentUser.CrmUser;
            var data = _crmMessageWorkBll.WorkListCount(user.Id);
            var result = JsonConvert.SerializeObject(data);
            return result;
        }

        /// <summary>
        /// 查询消息列表
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="category">类型</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public string GridPageList(string category, int pageIndex = 1, int pageSize = 20)
        {
            var user = CurrentUser.CrmUser;

            int totalRecords;

            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var data = _crmMessageWorkBll.GetSearchWork(user.Id, category, pageIndex, pageSize, out totalRecords);
            var resultrow = new StringBuilder("");
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    resultrow.AppendFormat(@"<tr onDblClick=OpenDetails('{0}','{1}')><td style='width: 50px; text-align: center;'>
                                  <input type='checkbox' value='{0}'/></td>
                                  <td style='width: 20px;'></td>
                                  <td style='width: 180px;'>{2}</td>
                                  <td>{3}</td>
                                  <td style='width: 100px; text-align: center;'>{4}</td>
                                  <td style='width: 20px;'></td></tr>", row["Id"], row["ContentTypeID"], row["UserName"], row["Titles"], row["StartDate"]);
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
        /// 查询消息列表
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">编号</param>
        /// <param name="htype">操作类型</param>
        /// <returns></returns>
        public JsonResult UpWorkList(string id, string htype)
        {
            var isOk = false;

            if (htype.Equals("read"))
            {
                isOk = _crmMessageWorkBll.UpdateWorkListState(id, DateTime.Now, 1);
            }
            else if (htype.Equals("del") || htype.Equals("renew"))
            {
                isOk = _crmMessageWorkBll.DeleteWorkList(id, htype);
            }
            var rtEntity = new StatusModel<DBNull>
            {
                rtData = null,
                rtMsrg = "成功",
                rtState = isOk ? 1 : -1
            };
            return Json(rtEntity, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 请求消息详情
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">消息编号</param>
        /// <returns></returns>
        public string GetWorkDetails(string id)
        {
            var details = _crmMessageWorkBll.GetWorkListDetails(id);
            return JsonConvert.SerializeObject(details);
        }

        /// <summary>
        /// 获取当前
        /// </summary>
        /// <returns></returns>
        public int GetUntreatedCount()
        {
            var user = CurrentUser.CrmUser;
            return _crmMessageWorkBll.GetUntreatedCount(user.Id);
        }
    }
}
