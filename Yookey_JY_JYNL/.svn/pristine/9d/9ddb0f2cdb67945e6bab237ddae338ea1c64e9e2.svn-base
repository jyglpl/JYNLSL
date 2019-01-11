using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Com
{
    public class HolidaysController : BaseController
    {
        //
        // GET: /Holidays/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calender()
        {
            return View();
        }

        /// <summary>
        /// 设置节假日
        /// 添加人：周 鹏
        /// 添加时间：2015-01-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="setDate">设置的年月</param>
        /// <param name="holidays">节假日日期集</param>
        /// <returns>System.String.</returns>
        public string SaveHolidays(string setDate, string holidays)
        {
            try
            {
                if (!string.IsNullOrEmpty(setDate) && !string.IsNullOrEmpty(holidays))
                {
                    var holidaySplit = holidays.Split(',');
                    var date = Convert.ToDateTime(setDate);

                    var user = CurrentUser.CrmUser;

                    var list = holidaySplit.Select(s => new ComHolidaysEntity()
                        {
                            Id = Guid.NewGuid().ToString(),
                            HostDate = Convert.ToDateTime(date.ToString("yyyy-MM") + "-" + s),
                            RowStatus = 1,
                            CreatorId = user.Id,
                            CreateBy = user.UserName,
                            CreateOn = DateTime.Now,
                            UpdateId = user.Id,
                            UpdateBy = user.UserName,
                            UpdateOn = DateTime.Now
                        }).ToList();
                    return new ComHolidaysBll().SaveHostDate(list, date) ? "ok" : "error";
                }
            }
            catch (Exception)
            {
                return "error";
            }
            return "error";
        }

        /// <summary>
        /// 节假日查询
        /// 添加人：周 鹏
        /// 添加时间：2015-01-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns></returns>
        public string GetHolidays(string year, string month)
        {
            if (!string.IsNullOrEmpty(year) && !string.IsNullOrEmpty(month))
            {
                var list = new ComHolidaysBll().GetSearchResult(new ComHolidaysEntity() { HostDate = Convert.ToDateTime(year + "-" + month) });
                var str = "";
                if (list.Any())
                {
                    str = list.Aggregate(str, (current, item) => current + (item.HostDate.Day + ","));
                }
                if (str.Length > 0)
                    str = str.Substring(0, str.Length - 1);
                return str;
            }
            return "";
        }
    }
}
