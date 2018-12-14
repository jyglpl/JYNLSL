using DBHelper;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Attendance;

namespace Yookey.WisdomClassed.SIP.DataAccess.Attendance
{
    public class AttendanceDal : BaseDal<AttendanceEntity>
    {
        /// <summary>
        /// 添加考勤签到记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertAttendance(AttendanceEntity entity)
        {

            var strSql = string.Format(@"INSERT INTO Attendance
(Id,CompanyId,CompanyName,DepartmentId,DepartmentName,UserId,UserName,ClockTime,ClockPlace,Longitude,Latitude)
VALUES
('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", entity.Id, entity.CompanyId, entity.CompanyName, entity.DepartmentId, entity.DepartmentName, entity.UserId, entity.UserName, entity.ClockTime, entity.ClockPlace, entity.Longitude, entity.Latitude);


            int result = SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString());

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取考勤签到
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public Page<AttendanceEntity> GetAttendance(string userName, int pageSize, int pageIndex)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM Attendance");
            if (!string.IsNullOrEmpty(userName))
            {
                strSql.AppendFormat(" where UserName LIKE '%{0}%'", userName);
            }
            var args = new List<object>();
            return WriteDatabase.Page<AttendanceEntity>(pageIndex, pageSize, strSql.ToString(), args.ToArray());
        }
    }
}
