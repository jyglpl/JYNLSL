//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CAR_HANDLERBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/22 16:26:18
//  功能描述：INF_CAR_HANDLER业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// INF_CAR_HANDLER业务逻辑
    /// </summary>
    public class InfCarHandlerBll : BaseBll<InfCarHandlerEntity>
    {
        public InfCarHandlerBll()
        {
            BaseDal = new InfCarHandlerDal();
        }

        /// <summary>
        /// 数据查询
        /// 添加人：周 鹏
        /// 添加时间：2015-04-07
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="checkSignId">外键编号</param>
        /// <returns>DataTable.</returns>
        public PageJqDatagrid<DataTable> GetSearchResult(string checkSignId)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var data = new InfCarHandlerDal().GetSearchResult(checkSignId);
            stopwatch.Stop();

            return new PageJqDatagrid<DataTable>
            {
                page = 1,
                rows = data,
                total = 1,
                records = 1,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }
    }
}
