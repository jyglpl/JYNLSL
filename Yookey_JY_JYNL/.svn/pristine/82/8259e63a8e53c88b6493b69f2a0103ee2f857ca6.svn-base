using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.DataAccess.Mobile
{
    public class WSAllNumberDal
    {
        /// <summary>
        /// 获取所有票据号
        /// </summary>
        /// <param name="UseID">用户ID</param>
        /// <param name="LastDate">领用时间</param>
        /// <returns></returns>
        public DataTable GetWSAllNumber(string UseID, string LastDate)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat("");
            try
            {
                strSql.AppendFormat("select Autoid,wstype,wsno,Convert(varchar(100),wcreatedate,20) wcreatedate from wbrigade where users='{0}' and wstate='0' and isdestroy='0' and RowStatus=1", UseID);
                if (!LastDate.Equals(""))
                {
                    strSql.AppendFormat("and wcreatedate > '{0}'", LastDate);
                }

                strSql.AppendFormat("order by wcreatedate");
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region 验证罚款单编号

        /// <summary>
        /// 验证罚款单编号

        /// </summary>
        /// <param name="DeptID">部门</param>
        /// <param name="dt">所有罚款单编号的DataTable</param>
        /// <returns></returns>
        public string GetJYFMKCheck(string UserID, DataTable dt)
        {
            StringBuilder strb = new StringBuilder();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    switch (dr[0].ToString())
                    {
                        case "5元":
                            strb.Append(CheckJYFMK(UserID, "20120215002", dr[1].ToString()));
                            break;
                        case "10元":
                            strb.Append(CheckJYFMK(UserID, "20120215003", dr[1].ToString()));
                            break;
                        case "20元":
                            strb.Append(CheckJYFMK(UserID, "20120215005", dr[1].ToString()));
                            break;
                        case "50元":
                            strb.Append(CheckJYFMK(UserID, "20120215004", dr[1].ToString()));
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strb.ToString();
        }
        #endregion

        /// <summary>
        /// 验证文书罚款单编号是否正确
        /// </summary>
        /// <returns></returns>
        public string CheckJYFMK(string UserID, string WSType, string WSNO)
        {
            StringBuilder strb = new StringBuilder();
            try
            {
                string[] strWSNO;
                if (WSNO.IndexOf(',') != -1)
                {
                    strWSNO = WSNO.Split(new char[] { ',' });
                }
                else
                {
                    strWSNO = new string[] { WSNO };
                }
                for (int i = 0; i < strWSNO.Length; i++)
                {
                    string sql = string.Format("select count(*) c from wbrigade where users = '{0}' and WSType = '{1}' and WState = 0 and WSNO='{2}'", UserID, WSType, strWSNO[i]);
                    object obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sql);
                    if (obj.ToString() == "0")
                    {
                        if (strb.ToString() == "")
                        {
                            strb.Append(strWSNO[i]);
                        }
                        else
                        {
                            strb.Append("," + strWSNO[i]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strb.Append(WSNO);
                throw ex;
            }
            return strb.ToString();
        }

        public string GetJYFMKCheckByAndroid(string UserID, string AllNumber)
        {
            StringBuilder strb = new StringBuilder();
            string result = "";
            try
            {
                string[] numer = AllNumber.Split(new char[] { '|' });

                DataTable dt = new DataTable();
                DataColumn dc;
                DataRow dr;
                for (int i = 0; i < 2; i++)
                {
                    dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.String");
                    dt.Columns.Add(dc);
                }
                for (int i = 0; i < numer.Length; i++)
                {
                    dr = dt.NewRow();
                    dr[0] = numer[i].Split(new char[] { '-' })[0];
                    dr[1] = numer[i].Split(new char[] { '-' })[1];
                    dt.Rows.Add(dr);
                }
                result = GetJYFMKCheck(UserID, dt);
            }
            catch (Exception ex)
            {
                result = "";
            }
            return result;
        }
        /// <summary>
        ///  更新文书编号的使用状态
        /// </summary>
        /// <param name="list"></param>
        public bool UpdateWsState(List<String> list)
        {
            try
            {
                int result = SqlHelper.ExecuteSqlTran(SqlHelper.SqlConnStringWrite, list);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
