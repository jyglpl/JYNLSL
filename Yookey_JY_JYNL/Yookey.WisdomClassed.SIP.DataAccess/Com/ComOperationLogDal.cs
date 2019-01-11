//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComOperationLogDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/28 13:28:41
//  功能描述：ComOperationLog数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    /// <summary>
    /// ComOperationLog数据访问操作
    /// </summary>
    public class ComOperationLogDal : DalImp.BaseDal<ComOperationLogEntity>
    {
        public ComOperationLogDal()
        {           
            Model = new ComOperationLogEntity();
        }

        /// <summary>
        /// 操作日志查询
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <param name="model">模块</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable GetCommonQury(int logType, string startTime, string endTime, int pageSize, int pageIndex, out int totalRecords)
        {
            try
            {
                var str = new StringBuilder(@"select Id,LogType,Controller,ModelName,Action,HandleTypeId,Note,Ip,
                CreateBy,CreateOn from ComOperationLog where 1=1");
                if (logType!=null)
                    str.Append(string.Format(@" AND LogType ={0}", logType));
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
    }
}
                                                                                                                                         
