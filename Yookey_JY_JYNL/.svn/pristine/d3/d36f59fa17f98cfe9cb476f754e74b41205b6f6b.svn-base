using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.FingerPrint;

namespace Yookey.WisdomClassed.SIP.DataAccess.FingerPrint
{
    /// <summary>
    /// FingerPrint数据访问操作
    /// </summary>
    public class FingerPrintDal : DalImp.BaseDal<FingerPrintEntity>
    {
        public FingerPrintDal()
        {
            Model = new FingerPrintEntity();
        }

       /// <summary>
        /// 获取用户指纹数据
       /// </summary>
       /// <param name="userId"></param>
       /// <param name="serialnumber"></param>
       /// <returns></returns>
        public List<FingerPrintEntity> GetSearchResult(string userId, string serialnumber)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(FingerPrintEntity.Parm_FingerPrint_RowStatus, "1");
            if (!string.IsNullOrEmpty(userId))
            {
                queryCondition.AddEqual(FingerPrintEntity.Parm_FingerPrint_UserId, userId);
            }
            if (!string.IsNullOrEmpty(serialnumber))
            {
                queryCondition.AddEqual(FingerPrintEntity.Parm_FingerPrint_SerialNumber, serialnumber);
            }
            return Query(queryCondition) as List<FingerPrintEntity>;
        }

        /// <summary>
        /// 更新指纹绑定状态
        /// </summary>
        /// <param name="status"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public bool UpdateFnierPrintStatus(int status, string serialNumber)
        {
            var strSql = string.Format("UPDATE FingerPrint SET RowStatus = {0}  ,UpdateOn = GETDATE()  WHERE SerialNumber='{1}' ", status, serialNumber);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql.ToString()) > 0;
        }

    }
}
