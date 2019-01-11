using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Instrument;

namespace Yookey.WisdomClassed.SIP.DataAccess.Instrument
{
    /// <summary>
    /// WSTOCKTABLE数据访问操作
    /// </summary>
    public class WSTOCKTABLEDal : DalImp.BaseDal<WSTOCKTABLEEntity>
    {
        public WSTOCKTABLEDal()
        {
            Model = new WSTOCKTABLEEntity();
        }
        /// <summary>
        /// 返回执行更新文书总库存表的SQL语句
        /// </summary>
        /// <param name="count"></param>
        /// <param name="count1"></param>
        /// <param name="wrscode"></param>
        /// <returns></returns>
        public string UpdateWSTOCKTABLE(int count, int count1, string wrscode)
        {
            string sql = string.Format("update WStockTable set FirstStock = FirstStock + {0},CurrentStock = CurrentStock + {1} where WSType='{2}'", count, count1, wrscode);
            return sql;
        }
    }
}
