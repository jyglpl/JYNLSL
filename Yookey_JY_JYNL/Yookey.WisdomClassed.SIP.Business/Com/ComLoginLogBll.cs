//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComLoginLogBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/28 13:28:41
//  功能描述：ComLoginLog业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Business.Com
{
    /// <summary>
    /// ComLoginLog业务逻辑
    /// </summary>
    public class ComLoginLogBll : BaseBll<ComLoginLogEntity>
    {
        public ComLoginLogBll()
        {
            BaseDal = new ComLoginLogDal();
        }

        /// <summary>
        /// 操作日志查询
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <param name="model">模块</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public PageJqDatagrid<ComLoginLogEntity> GetCommonQuryGetCommonQury(int source, int status, string startTime, string endTime, int pageSzie = 15,
                                                              int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;

            var data = new ComLoginLogDal().GetCommonQury(source, status, startTime, endTime, pageSzie, pageIndex, out totalRecords);

            var list = ConvertListHelper<ComLoginLogEntity>.ConvertToList(data);

            stopwatch.Stop();
            var totalPage = (totalRecords + pageSzie - 1) / pageSzie;   //计算页数
            return new PageJqDatagrid<ComLoginLogEntity>
            {
                page = pageIndex,
                rows = list,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        /// <summary>
        /// 添加登录日志
        /// 添加人：周 鹏
        /// 添加时间：2015-08-11
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="source">登录来源（Web、PDA）</param>
        /// <param name="ip">登录IP</param>
        /// <param name="status">登录状态（成功、失败）</param>
        /// <param name="note">登录情况说明</param>
        /// <param name="account">登录账号</param>
        /// <param name="userName">登录人员姓名</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddLog(int source, string ip, int status, string note, string account, string userName)
        {
            try
            {
                var entity = new ComLoginLogEntity()
                {
                    Id = LogHelper.Id,
                    Source = source,
                    Ip = ip,
                    Status = status,
                    Note = note,
                    CreatorId = account,
                    CreateBy = userName,
                    CreateOn = DateTime.Now
                };
                BaseDal.Add(entity);
                if (status != 3)
                    LogHelper.Dispose();
                return true;
            }
            catch
            {
                return false;
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
            return new ComLoginLogDal().GetLoginErrorCount(account);
        }
    }
}
