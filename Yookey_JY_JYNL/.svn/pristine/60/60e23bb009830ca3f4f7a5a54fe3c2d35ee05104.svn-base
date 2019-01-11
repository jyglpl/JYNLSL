using Yookey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Mobile;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.DataAccess.Mobile
{
    public class MobileBasicDal : DalImp.BaseDal<MobileBasicEntity>
    {
        public MobileBasicDal()
        {
            Model = new MobileBasicEntity();
        }
        public DataTable QueryBasis(IEnumerable<string> tbVes)
        {
            var strSql = new StringBuilder("");
            foreach (var item in tbVes)
            {
                strSql.AppendFormat(" SELECT DataSql FROM {0} WHERE VersionNum>{1} UNION", item.Split(':')[0], item.Split(':')[1]);
            }
            strSql.Remove(strSql.Length - 5, 5);  //移除最后一个UNIONI
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }
    }
    
}
