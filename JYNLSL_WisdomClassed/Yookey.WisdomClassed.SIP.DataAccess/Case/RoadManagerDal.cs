//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="RoadManagerDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/22 16:26:18
//  功能描述：RoadManager数据访问类
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
    /// RoadManager数据访问操作
    /// </summary>
    public class RoadManagerDal : DalImp.BaseDal<RoadManagerEntity>
    {
        public RoadManagerDal()
        {
            Model = new RoadManagerEntity();
        }

        /// <summary>
        /// 查询路段
        /// 添加人：周 鹏
        /// 添加时间：2014-12-28
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-03-18 周 鹏 增加按部门编号查询
        /// </history>
        /// <param name="deptId">部门编号</param>
        /// <returns></returns>
        public DataTable GetRoad(string deptId)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT RM.RoadNo,RM.RoadName,RM.ShowName FROM RoadManager AS RM WITH(NOLOCK)  ORDER BY RM.RoadNo ", deptId);

            var roadDt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            ////查询不到路段时，则查询所有的路段进行返回
            //if (roadDt == null || roadDt.Rows.Count <= 0)
            //{
            //    var strGetAllSql = string.Format("SELECT RM.RoadNo,RM.RoadName,RM.ShowName FROM RoadManager AS RM WITH(NOLOCK)  ORDER BY RM.RoadNo ");
            //    roadDt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strGetAllSql).Tables[0];
            //}
            return roadDt;
        }


        /// <summary>
        /// 根据路段名称获取路段代码
        /// 添加人：周 鹏
        /// 添加时间：2015-08-06
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="roadName">路段名称</param>
        /// <returns>System.String.</returns>
        public string GetRoadNoByRoadName(string roadName)
        {
            var roadNo = "";
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT RoadNo FROM RoadManager WHERE RoadName='{0}'", roadName);
            var roadDt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            
            if (roadDt != null && roadDt.Rows.Count > 0)
            {
                roadNo = roadDt.Rows[0]["RoadNo"].ToString();
            }
            return roadNo;
        }
    }
}

