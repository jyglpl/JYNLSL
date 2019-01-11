using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    public class ComNumberDal
    {
        /// <summary>
        /// 获取流水号的最大值
        /// </summary>
        /// <param name="strBick">字符串</param>
        /// <param name="numleng">流水号的长度</param>
        /// <param name="dataField">表的字段名</param>
        /// <param name="tableName">表名集合</param>
        /// <param name="where">查询条件无需where</param>
        /// <param name="qsh">起始号</param>
        /// <returns>最大流水号</returns>
        public string GetMaxCode(string strBick, int numleng, string dataField, string[] tableName, string where, int qsh)
        {

            var strSql = " SELECT ItemNo FROM( ";
            strSql += "SELECT  " + dataField + " AS ItemNo FROM " + tableName[0].Trim() + " WHERE 1=1 "
                        + "AND LEN(" + dataField + ")=" + Convert.ToString(strBick.Length + numleng) + " AND " + dataField
                        + " LIKE '" + strBick + "%' " + where + " ";
            if (tableName.Length > 1)
            {
                for (int i = 1; i < tableName.Length; i++)
                {
                    if (tableName[i].Trim() != "")
                    {
                        strSql += " UNION SELECT " + dataField + " AS ItemNo From " + tableName[i].Trim() + " WHERE 1=1 "
                                   + "AND LEN(" + dataField + ")=" + Convert.ToString(strBick.Length + numleng) + " AND " + dataField
                                   + " LIKE '" + strBick + "%' " + where + " ";
                    }
                }
            }
            strSql += " ) AS UserTable ORDER BY CAST(SUBSTRING(ItemNo,LEN('" + strBick + "')+1,"
                            + " LEN(ItemNo)+1-LEN('" + strBick + "')) AS INT) DESC";


            object itemNo = SqlHelper.ExecuteReader(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);

            var maxId = 1;
            //查询所有流水号并返回最大值
            if (itemNo == null || itemNo.ToString() == "")
                maxId = 1;
            else
            {
                if (itemNo.ToString().Trim() == "")
                {
                    maxId = 1;
                }
                if (itemNo.ToString().Trim().Length > numleng && itemNo.ToString().Trim().Length > strBick.Length)
                {
                    if (itemNo.ToString().Trim().Substring(strBick.Length, numleng).Trim().Length == numleng)
                    {
                        maxId = int.Parse(itemNo.ToString().Trim().Substring(strBick.Length, numleng).Trim()) + 1;
                    }
                    else
                        maxId = 1;
                }
                else
                    maxId = 1;
            }
            return maxId <= qsh ? qsh.ToString().PadLeft(numleng, '0') : maxId.ToString().PadLeft(numleng, '0');
        }

        /// <summary>
        /// 获取流水号的最大值
        /// </summary>
        /// <param name="strBick">字符串</param>
        /// <param name="numleng">流水号的长度</param>
        /// <param name="dataField">表的字段名</param>
        /// <param name="tableName">表名</param>
        /// <param name="where">查询条件无需where</param>
        /// <param name="qsh">起始号</param>
        /// <returns>最大流水号</returns>
        public string GetMaxCode(string strBick, int numleng, string dataField, string tableName, string where, int qsh)
        {
            var tables = tableName.Split(new char[] { ',', '，' });

            var strSql = "SELECT TOP 1 " + dataField + " FROM " + tables[0].Trim() + " WHERE 1=1 "
                            + "AND LEN(" + dataField + ")=" + Convert.ToString(strBick.Length + numleng) + " AND " + dataField
                            + " LIKE '" + strBick + "%' " + where + " ORDER BY CAST(SUBSTRING(" + dataField + ",LEN('" + strBick + "')+1,"
                            + " LEN(" + dataField + ")+1-LEN('" + strBick + "')) AS INT) DESC ";
            object itemNo = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
            int maxId = 1;
            //查询所有流水号并返回最大值
            if (itemNo == null || itemNo.ToString() == "")
                maxId = 1;
            else
            {
                if (itemNo.ToString().Trim() == "")
                {
                    maxId = 1;
                }
                if (itemNo.ToString().Trim().Length > numleng && itemNo.ToString().Trim().Length > strBick.Length)
                {
                    if (itemNo.ToString().Trim().Substring(strBick.Length, numleng).Trim().Length == numleng)
                    {
                        maxId = int.Parse(itemNo.ToString().Trim().Substring(strBick.Length, numleng).Trim()) + 1;
                    }
                    else
                        maxId = 1;
                }
                else
                    maxId = 1;
            }
            return maxId <= qsh ? qsh.ToString().PadLeft(numleng, '0') : maxId.ToString().PadLeft(numleng, '0');
        }
    }
}
