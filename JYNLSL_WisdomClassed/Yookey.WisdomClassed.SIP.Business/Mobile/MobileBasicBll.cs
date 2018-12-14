using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Mobile;
using Yookey.WisdomClassed.SIP.Model.Mobile;

namespace Yookey.WisdomClassed.SIP.Business.Mobile
{
   /// <summary>
    /// Mobile_Basic业务逻辑
    /// </summary>
    public class MobileBasicBll : BaseBll<MobileBasicEntity>
    {
        public MobileBasicBll()
        {
            BaseDal = new MobileBasicDal();
        }

        public string QueryBasis(string tbVersion)
        {
            try
            {
                var strSql = new StringBuilder("");
                var tbVes = tbVersion.Split(',');
                if (tbVes.Length > 0)
                {
                    var basisDt = new MobileBasicDal().QueryBasis(tbVes);
                    if (basisDt != null && basisDt.Rows.Count > 0)
                    {
                        foreach (DataRow row in basisDt.Rows)
                        {
                            strSql.Append(row["DataSql"] + ";");
                        }
                        return strSql.Remove(strSql.Length - 1, 1).ToString(); //移除最后;号
                    }
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return "";
        }
    }
}
