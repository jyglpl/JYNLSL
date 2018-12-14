using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Yookey.WisdomClassed.SIP.DataAccess.Mobile;

namespace Yookey.WisdomClassed.SIP.Business.Mobile
{
    public class WSAllNumberBll
    {
        readonly WSAllNumberDal _wsallnumberDal = new WSAllNumberDal();
        /// <summary>
        /// 根据用户ID和领用时间获取所有票据号
        /// </summary>
        /// <param name="context">用户ID</param>
        /// <param name="netWork">最后领用的时间</param>
        /// <returns></returns>
        public DataTable GetWSAllNumber(string context)
        {
            try
            {
                context = Regex.Replace(context, @"[\{\}]", "");
                context += ",";
                var UseID = Regex.Match(context, @"(?<=""UseID""\:"").*?(?="",)").Value;        //人员ID
                var LastDate = Regex.Match(context, @"(?<=""LastDate""\:"").*?(?="",)").Value;  //最后领用的时间
                return _wsallnumberDal.GetWSAllNumber(UseID, LastDate);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// 验证票据号是否正确
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string CheckJYFMK(string context)
        {
            context = Regex.Replace(context, @"[\{\}]", "");
            context += ",";
            var UseID = Regex.Match(context, @"(?<=""UseID""\:"").*?(?="",)").Value;        //人员ID
            var AllNumber = Regex.Match(context, @"(?<=""AllNumber""\:"").*?(?="",)").Value;   //文书类型
           // var WSNO = Regex.Match(context, @"(?<=""WSNO""\:"").*?(?="",)").Value;     //票据号
            return _wsallnumberDal.GetJYFMKCheckByAndroid(UseID, AllNumber);
            StringBuilder strb = new StringBuilder();
            return strb.ToString();
        }

        /// <summary>
        /// 验证票据号是否正确
        /// </summary>
        /// <param name="bill">票据编号</param>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public string CheckJYFMK(string bill,string userId)
        {
            return _wsallnumberDal.GetJYFMKCheckByAndroid(userId, bill);
        }

        /// <summary>
        /// 更新票据号状态
        /// </summary>
        /// <param name="context">DeptID 部门编号 WSNO  文书编号 UserId 用户ID</param>
        public bool UpdateJYFMK(string context)
        {
            bool result=false;
            context = Regex.Replace(context, @"[\{\}]", "");
            context += ",";
            var DeptID = Regex.Match(context, @"(?<=""DeptID""\:"").*?(?="",)").Value;  //部门编号
            var WSNO = Regex.Match(context, @"(?<=""wsno""\:"").*?(?="",)").Value;    //文书编号
            var UserId = Regex.Match(context, @"(?<=""UserId""\:"").*?(?="",)").Value;   //用户ID
            List<String> list = new List<String>();
            string[] strWSNO, FMKnum, FMKtype;
            if (WSNO != null)
            {
                FMKnum = WSNO.Split(new char[] { '|' });
                for (int i = 0; i < FMKnum.Length; i++)
                {
                    FMKtype = FMKnum[i].Split(new char[] { '-' });
                    if (FMKtype[1].IndexOf(',') != -1)
                    {
                        strWSNO = FMKtype[1].Split(new char[] { ',' });
                    }
                    else
                    {
                        strWSNO = new string[] { FMKtype[1] };
                    }

                    for (int j = 0; j < strWSNO.Length; j++)
                    {
                        string wstype = "";
                        if (FMKtype[0].ToString().Equals("5元"))
                        {
                            wstype = "20120215002";
                        }
                        else if (FMKtype[0].ToString().Equals("10元"))
                        {
                            wstype = "20120215003";
                        }
                        else if (FMKtype[0].ToString().Equals("20元"))
                        {
                            wstype = "20120215005";
                        }
                        else if (FMKtype[0].ToString().Equals("50元"))
                        {
                            wstype = "20120215004";
                        }
                        //更改文书的使用状态
                        string NewID = Guid.NewGuid().ToString();
                        list.Add(string.Format("insert into WUseRecord values ('{0}','{1}','{2}','{3}','{4}','{5}',GETDATE(),0,0,null,'{6}',getdate(),'{7}','{8}',getdate())",
                            NewID, UserId, wstype, DeptID, strWSNO[j], UserId, UserId, UserId, UserId));
                        list.Add(string.Format("update wbrigade set wstate='3',usedate=GETDATE() where users='{1}' and wstype='{2}' and wsno='{3}'", DateTime.Now.ToString(), UserId, wstype, strWSNO[j]));
                    }
                }
               result= _wsallnumberDal.UpdateWsState(list);
            }
            return result;
        }

        /// <summary>
        /// 更新票据号状态
        /// </summary>
        /// <param name="deptId">部门ID</param>
        /// <param name="billNo">票据编号</param>
        /// <param name="userId">用户ID</param>
        public bool UpdateJYFMK(string deptId,string billNo,string userId)
        {
            bool result = false;

            var DeptID = deptId;
            var WSNO = billNo;
            var UserId = userId;
            List<String> list = new List<String>();
            string[] strWSNO, FMKnum, FMKtype;
            if (WSNO != null)
            {
                FMKnum = WSNO.Split(new char[] { '|' });
                for (int i = 0; i < FMKnum.Length; i++)
                {
                    FMKtype = FMKnum[i].Split(new char[] { '-' });
                    if (FMKtype[1].IndexOf(',') != -1)
                    {
                        strWSNO = FMKtype[1].Split(new char[] { ',' });
                    }
                    else
                    {
                        strWSNO = new string[] { FMKtype[1] };
                    }

                    for (int j = 0; j < strWSNO.Length; j++)
                    {
                        string wstype = "";
                        if (FMKtype[0].ToString().Equals("5元"))
                        {
                            wstype = "20120215002";
                        }
                        else if (FMKtype[0].ToString().Equals("10元"))
                        {
                            wstype = "20120215003";
                        }
                        else if (FMKtype[0].ToString().Equals("20元"))
                        {
                            wstype = "20120215005";
                        }
                        else if (FMKtype[0].ToString().Equals("50元"))
                        {
                            wstype = "20120215004";
                        }
                        //更改文书的使用状态
                        string NewID = Guid.NewGuid().ToString();
                        list.Add(string.Format("insert into WUseRecord values ('{0}','{1}','{2}','{3}','{4}','{5}',GETDATE(),0,0,null,'{6}',getdate(),'{7}','{8}',getdate())",
                            NewID, UserId, wstype, DeptID, strWSNO[j], UserId, UserId, UserId, UserId));
                        list.Add(string.Format("update wbrigade set wstate='3',usedate=GETDATE() where users='{1}' and wstype='{2}' and wsno='{3}'", DateTime.Now.ToString(), UserId, wstype, strWSNO[j]));
                    }
                }
                result = _wsallnumberDal.UpdateWsState(list);
            }
            return result;
        }
    }
}
