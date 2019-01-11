//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComLoginLogDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/28 13:28:41
//  功能描述：ComLoginLog数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    /// <summary>
    /// ComLoginLog数据访问操作
    /// </summary>
    public class ComLoginLogDal : DalImp.BaseDal<ComLoginLogEntity>
    {
        public ComLoginLogDal()
        {
            Model = new ComLoginLogEntity();
        }

        /// <summary>
        /// 操作日志查询
        /// </summary>
        /// <param name="status"></param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public DataTable GetCommonQury(int source, int status, string startTime, string endTime, int pageSize, int pageIndex, out int totalRecords)
        {
            try
            {
                var str = new StringBuilder(@"select Id,Source,Ip,Status,Note,CreateBy,CreateOn from ComLoginLog where 1=1");
                str.Append(string.Format(@" AND Source ={0}", source));
                str.Append(string.Format(@" AND Status ={0}", status));
                if (!string.IsNullOrEmpty(startTime))
                    str.Append(string.Format(@" AND CreateOn>='{0}' ", startTime));
                if (!string.IsNullOrEmpty(endTime))
                    str.Append(string.Format(@" AND CreateOn<='{0}'  ", endTime));
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, str.ToString(), "*", "", "CreateOn", "DESC", pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取登录出错误的次数
        /// 添加人：周 鹏
        /// 添加时间：2015-08-11
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="account">登录账号</param>
        /// <returns>System.Int32.</returns>
        public int GetLoginErrorCount(string account)
        {
            try
            {
                var strSql =string.Format("SELECT COUNT(*) FROM ComLoginLog WHERE [Status]=4 AND CreatorId='{0}' AND DATEDIFF(MINUTE,CreateOn,GETDATE())<=2",account);
                var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql);
                if (obj!=null)
                {
                    return int.Parse(obj.ToString());
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

