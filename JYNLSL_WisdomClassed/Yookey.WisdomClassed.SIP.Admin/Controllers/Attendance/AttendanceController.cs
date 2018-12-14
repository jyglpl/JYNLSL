using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yookey.WisdomClassed.SIP.Business.Attendance;

namespace Yookey.WisdomClassed.SIP.Admin.Controllers.Attendance
{
    public class AttendanceController : Controller
    {
        AttendanceBll _AttendanceBll = new AttendanceBll();
        //
        // GET: /Attendance/

        public ActionResult AttendanceIndex()
        {
            return View();
        }

        public string GetAttendance(string userName, int rows = 30, int page = 1)
        {
            var data = _AttendanceBll.GetAttendance(userName, rows, page);
            var result = Yookey.WisdomClassed.SIP.Common.PetaPoco.CommonMethod.PageToJson(Yookey.WisdomClassed.SIP.Common.PetaPoco.CommonMethod.PageToJqGridPage(data));
            return result;
        }
    }
}
