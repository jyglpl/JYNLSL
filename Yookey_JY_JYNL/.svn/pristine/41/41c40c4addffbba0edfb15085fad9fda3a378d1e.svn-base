//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_ActivityDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:36
//  功能描述：FE_Activity数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System.Data;
using Yookey;
using Yookey.WisdomClassed.SIP.Model.FlowEditor;

namespace Yookey.WisdomClassed.SIP.DataAccess.FlowEditor
{
    /// <summary>
    /// FE_Activity数据访问操作
    /// </summary>
    public class FeActivityDal : DalImp.BaseDal<FeActivityEntity>
    {
        public FeActivityDal()
        {
            Model = new FeActivityEntity();
        }

        /// <summary>
        /// 根据流程编号得到结点记录
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// </summary>
        /// <param name="processId">流程编号</param>
        /// <returns></returns>
        public DataTable GetActivity(string processId)
        {
            var strSql =
                string.Format(
                    @"SELECT * FROM FE_Activity WHERE ProcessID='{0}' ORDER BY CONVERT(INT,REPLACE(REPLACE(REPLACE(NoneID,'C',''),'EStart','-1'),'EEnd','0'))", processId);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
        }

        /// <summary>
        /// 退回接收对象 ID 更新
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="formerProcessId">修改前的流程ID</param>
        /// <param name="processId">修改后的流程ID</param>
        /// <returns></returns>
        public bool UpdateReturnActivityId(string formerProcessId, string processId)
        {
            var formerDt = GetActivity(formerProcessId);
            var dt = GetActivity(processId);

            var strSql = "";
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].IsNull("SendORWithdrawalActivityID") || dt.Rows[i]["SendORWithdrawalActivityID"].ToString().Equals(""))
                    continue;

                var strSendOrWithdrawalActivityId = "";
                var strTemp = dt.Rows[i]["SendORWithdrawalActivityID"].ToString();
                //3:发送人 1:至发启人 2:至发启人并结束流程
                if (strTemp != "1" && strTemp != "2" && strTemp != "3")
                {
                    var rowsFormer = formerDt.Select("ActivityID='" + strTemp + "'");
                    var rows = dt.Select("NoneID='" + rowsFormer[0]["NoneID"] + "'");
                    strSendOrWithdrawalActivityId = rows[0]["ActivityID"].ToString();
                }
                else
                    strSendOrWithdrawalActivityId = strTemp;
                strSql += "UPDATE FE_Activity SET SendORWithdrawalActivityID='" + strSendOrWithdrawalActivityId + "' WHERE ActivityID='" + dt.Rows[i]["ActivityID"] + "';";
            }
            if (strSql.Equals(""))
                return false;
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
        }
        /// <summary>
        /// 删除操作
        /// 添加人：张西琼
        /// 时间：2014/8/6
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public bool DeleActivity(string activityId)
        {
            string strSql = string.Format(@"delete dbo.FE_Activity where ActivityID='{0}'", activityId);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql) > 0;
        }


        /// <summary>
        /// 得到结点记录
        /// </summary>
        /// <param name="processId">流程编号</param>
        /// <param name="noneId">节点编号</param>
        /// <returns></returns>
        public DataTable GetActivity(string processId, string noneId)
        {
            var strSql = "SELECT * FROM FE_Activity WHERE NoneID='" + noneId + "' AND ProcessID='" + processId + "'";
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
        }

    }
}

