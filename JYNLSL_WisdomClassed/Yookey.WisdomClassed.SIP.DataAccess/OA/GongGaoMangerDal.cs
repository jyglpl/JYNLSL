using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.OA;

namespace Yookey.WisdomClassed.SIP.DataAccess.OA
{
    public class GongGaoMangerDal : BaseDal<GongGaoMangerEntity>
    {
        /// <summary>
        /// 事务发送公文
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SaveGongWen(List<GongGaoMangerEntity> list)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveDocNotPerson");
            try
            {

                var sbSql = new StringBuilder();

                //插入主表
                sbSql.AppendFormat("");

                //循环插入附表
                foreach (GongGaoMangerEntity person in list)
                {
                    sbSql.AppendFormat("");
                }

                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;

            }
            transaction.Commit();
            return true;
        }
    }
}
