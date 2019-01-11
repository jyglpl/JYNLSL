//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="TempDetainInfo_ProcessDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/13 17:13:46
//  功能描述：TempDetainInfo_Process数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.TempDetain;

namespace Yookey.WisdomClassed.SIP.DataAccess.TempDetain
{
    /// <summary>
    /// TempDetainInfo_Process数据访问操作
    /// </summary>
    public class TempDetainInfoProcessDal : DalImp.BaseDal<TempDetainInfoProcessEntity>
    {
        public TempDetainInfoProcessDal()
        {
            Model = new TempDetainInfoProcessEntity();
        }

        /// <summary>
        /// 通过暂扣Id查询审核过程
        /// </summary>
        /// <param name="tempId"></param>
        /// <returns></returns>
        public List<TempDetainInfoProcessEntity> GetTempDetainInfoProcessList(string tempId)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * 
                            FROM TempDetainInfo_Process WITH(NOLOCK)
                            WHERE RowStatus=1 AND TempDetainInfoId='{0}' ",tempId);

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString());
            return list != null && list.Tables.Count > 0 ? DataTableToList(list.Tables[0]) : new List<TempDetainInfoProcessEntity>();
        }

    }
}

