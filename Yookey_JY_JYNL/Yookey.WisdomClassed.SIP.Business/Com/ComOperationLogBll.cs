//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComOperationLogBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/28 13:28:41
//  功能描述：ComOperationLog业务逻辑类
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
    /// ComOperationLog业务逻辑
    /// </summary>
    public  class ComOperationLogBll : BaseBll<ComOperationLogEntity>
    {
        public ComOperationLogBll()
        {
            BaseDal = new ComOperationLogDal();
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
        public PageJqDatagrid<ComOperationLogEntity> GetCommonQuryGetCommonQury(int logType, string startTime, string endTime, int pageSzie = 15,
                                                              int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;

            var data = new ComOperationLogDal().GetCommonQury(logType, startTime, endTime, pageSzie, pageIndex, out totalRecords);

            var list = ConvertListHelper<ComOperationLogEntity>.ConvertToList(data);

            stopwatch.Stop();
            var totalPage = (totalRecords + pageSzie - 1) / pageSzie;   //计算页数
            return new PageJqDatagrid<ComOperationLogEntity>
            {
                page = pageIndex,
                rows = list,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }



        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <param name="controller">控制器名称</param>
        /// <param name="modelName">模块名称</param>
        /// <param name="action">方法</param>
        /// <param name="handleType">操作类型</param>
        /// <param name="note">文本</param>
        /// <param name="userId">操作用户编号</param>
        /// <param name="userName">操作用户名称</param>
        /// <returns></returns>
        public bool AddLog(LogType logType, string controller, string modelName, string action, HandleType handleType, string note,
            string userId,string userName)
        {
            try
            {
                ComOperationLogEntity entity = new ComOperationLogEntity()
                {
                    Id = LogHelper.Id,
                    LogType = (int)logType,
                    Controller = controller,
                    ModelName = modelName,
                    Action = action,
                    HandleTypeId = ((int)handleType).ToString(),
                    Note = note,
                    Ip = LogHelper.GetUserIp,
                    CreatorId = userId,
                    CreateBy = userName,
                    CreateOn=DateTime.Now
                };
                BaseDal.Add(entity);
                return true;
            }
            catch {
                return false;
            }
            
        }
    }
}
