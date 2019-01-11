//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_PUNISH_LEGISLATIOINDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/30 9:37:10
//  功能描述：INF_PUNISH_LEGISLATION数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Data;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// 案件法律法规 数据访问操作
    /// </summary>
    public class InfPunishLegislationDal : DalImp.BaseDal<InfPunishLegislationEntity>
    {
        public InfPunishLegislationDal()
        {
            Model = new InfPunishLegislationEntity();
        }


        /// <summary>
        /// 查询法律法规对比数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetComparePunishItem()
        {
            var strSql = string.Format("SELECT * FROM PunishCompare");

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

    }
}

