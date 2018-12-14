//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CAR_HANDLERDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/22 16:26:18
//  功能描述：INF_CAR_HANDLER数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System.Data;
using System.Text;
using Yookey;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// INF_CAR_HANDLER数据访问操作
    /// </summary>
    public class InfCarHandlerDal : DalImp.BaseDal<InfCarHandlerEntity>
    {
        public InfCarHandlerDal()
        {
            Model = new InfCarHandlerEntity();
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
        public DataTable GetSearchResult(string checkSignId)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(
                @"SELECT BU.RealName,ICH.HandContent,ICH.HandleIp,ICH.HandDate,ICH.HandReason FROM INF_CAR_HANDLER AS ICH WITH(NOLOCK)
JOIN CrmUser AS BU WITH(NOLOCK) ON ICH.HandPersonId=BU.Id
WHERE ICH.CheckSigniId='{0}'
ORDER BY ICH.HandDate", checkSignId);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }
    }
}

