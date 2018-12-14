using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Attendance;
using Yookey.WisdomClassed.SIP.Model.Attendance;

namespace Yookey.WisdomClassed.SIP.Business.Attendance
{
   public class AttendanceBll
    {
       private static readonly AttendanceDal Dal = new AttendanceDal();
       /// <summary>
       /// 添加考勤签到记录
       /// </summary>
       /// <param name="entity"></param>
       /// <returns></returns>
       public bool InsertAttendance(AttendanceEntity entity)
       {
           return Dal.InsertAttendance(entity);
       }

       /// <summary>
       /// 获取考勤签到
       /// </summary>
       /// <param name="paperType"></param>
       /// <param name="txtName"></param>
       /// <param name="pageSize"></param>
       /// <param name="pageIndex"></param>
       /// <returns></returns>
       public Page<AttendanceEntity> GetAttendance(string userName, int pageSize = 30, int pageIndex = 1)
       {
           return Dal.GetAttendance(userName,pageSize, pageIndex);
       }

    }
}
