//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_ActionDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:36
//  功能描述：FE_Action数据访问类
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
    /// FE_Action数据访问操作
    /// </summary>
    public class FeActionDal : DalImp.BaseDal<FeActionEntity>
    {
        public FeActionDal()
        {
            Model = new FeActionEntity();
        }

        /// <summary>
        /// 根据流程编号、欲发送结点得到接收结点
        /// </summary>
        /// <param name="activityId">欲发送结点</param>
        /// <param name="processId">流程编号</param>
        /// <returns></returns>
        public DataTable GetTakeSendFE_Action(string activityId, string processId)
        {
            var strSql = @"
SELECT 
FE_Activity.ActivityID
,FE_Activity.NoneName
,FE_Action.FromPoint

FROM FE_Activity
INNER JOIN
(
	SELECT FromPoint,Topoint FROM FE_Action 
		WHERE FE_Action.ProcessID='@ProcessID' AND FE_Action.FromPoint = (SELECT NoneID FROM FE_Activity WHERE ActivityID = '@ActivityID')
) AS FE_Action ON FE_Action.Topoint = FE_Activity.NoneID
WHERE FE_Activity.ProcessID='@ProcessID'

GROUP BY
FE_Activity.ActivityID
,FE_Activity.NoneName
,FE_Action.FromPoint";
            strSql = strSql.Replace("@ActivityID", activityId);
            strSql = strSql.Replace("@ProcessID", processId);
            var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 根据流程编号、开始结点得到接收结点
        /// </summary>
        /// <param name="fromPoint">开始节点编号</param>
        /// <param name="processId">流程编号</param>
        /// <returns></returns>
        public DataTable GetTakeStartFE_Action(string fromPoint, string processId)
        {
            var strSql = @"
SELECT 
FE_Activity.ActivityID
,FE_Activity.NoneName
,FE_Action.FromPoint

FROM FE_Activity
INNER JOIN
(
	SELECT FromPoint,Topoint FROM FE_Action 
		WHERE FE_Action.ProcessID='@ProcessID' AND FE_Action.FromPoint = '@FromPoint'
) AS FE_Action ON FE_Action.Topoint = FE_Activity.NoneID
WHERE FE_Activity.ProcessID='@ProcessID'

GROUP BY
FE_Activity.ActivityID
,FE_Activity.NoneName
,FE_Action.FromPoint";
            strSql = strSql.Replace("@FromPoint", fromPoint);
            strSql = strSql.Replace("@ProcessID", processId);
            var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            return dt;
        }
    }
}

