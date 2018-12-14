//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_ActionInstanceDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:36
//  功能描述：FE_ActionInstance数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System.Collections.Generic;
using System.Data;
using Yookey;
using Yookey.WisdomClassed.SIP.Model.FlowEditor;
using System.Linq;
namespace Yookey.WisdomClassed.SIP.DataAccess.FlowEditor
{
    /// <summary>
    /// FE_ActionInstance数据访问操作
    /// </summary>
    public class FeActionInstanceDal : DalImp.BaseDal<FeActionInstanceEntity>
    {
        public FeActionInstanceDal()
        {
            Model = new FeActionInstanceEntity();
        }

        /// <summary>
        /// 得到接收到象
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="activityId">节点编号</param>
        /// <param name="isUnlock">-1 所有 0:不启用 1:启用</param>
        /// <returns></returns>
        public DataTable GetActionInstance(string activityId, int isUnlock)
        {
            var strSql = @"
SELECT 
FE_ActionInstance.[ActionInstanceID]
,FE_ActionInstance.[ActivityID]
,FE_ActionInstance.[CommunityID]
,FE_ActionInstance.[CommunityName]
,CASE ISNULL(FE_PickupUser.AutoID,'')
	WHEN '' THEN FE_ActionInstance.[UserID]
	ELSE FE_PickupUser.NewUserID
END AS [UserID]
,CASE ISNULL(FE_PickupUser.AutoID,'')
	WHEN '' THEN FE_ActionInstance.[UserName]
	ELSE FE_PickupUser.[NewUserName]
END AS [UserName]
,FE_ActionInstance.[IsUnlock],FE_ActionInstance.[Id]

FROM FE_ActionInstance
--INNER JOIN FE_Activity ON FE_Activity.ActivityID = FE_ActionInstance.ActivityID
LEFT JOIN FE_PickupUser ON FE_PickupUser.ActionInstanceID = FE_ActionInstance.ActionInstanceID
WHERE FE_ActionInstance.ActivityId = '@ActivityId'  
";
            strSql = strSql.Replace("@ActivityId", activityId);
            if (isUnlock >= 0)
                strSql += " AND FE_ActionInstance.IsUnlock = " + isUnlock;
            strSql += " ORDER BY FE_ActionInstance.CommunityName";
            var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            return dt;
        }
        /// <summary>
        /// 新增实体
        /// 添加人：张西琼
        /// 时间：2014/7/30
        /// </summary>
        /// <param name="fe"></param>
        /// <returns></returns>MO
        public bool AddEntity(FeActionInstanceEntity fe)
        {
            int isUnlock = 0;

            if (!fe.IsUnlock)
            {
                isUnlock = 1;
            }
            string strSql = string.Format(@"insert into FE_ActionInstance(ActionInstanceID,ActivityID,CommunityID,CommunityName,CreateBy,CreateOn,CreatorId,IsUnlock,RowStatus,UpdateBy,UpdateId,UpdateOn,UserID,UserName) 
values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},'{8}','{9}','{10}','{11}','{12}','{13}');",
   fe.ActionInstanceID, fe.ActivityID, fe.CommunityID, fe.CommunityName, fe.CreateBy, fe.CreateOn, fe.CreatorId, isUnlock, fe.RowStatus, fe.UpdateBy, fe.UpdateId, fe.UpdateOn, fe.UserID, fe.UserName);
            if (SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql, fe.GetParms()) > 0)
            {
                return true;
            }
            else return false;

        }
        /// <summary>
        /// 添加人：张西琼
        ///时间：2014/7/30
        /// </summary>
        /// <param name="ActionInstanceID"></param>
        /// <returns></returns>
        public string GetUserID(string ActionInstanceID)
        {
            string _strSql = @"
SELECT 
CASE ISNULL(FE_PickupUser.AutoID,'')
	WHEN '' THEN FE_ActionInstance.[UserID]
	ELSE FE_PickupUser.NewUserID
END AS [UserID]

FROM FE_ActionInstance
LEFT JOIN FE_PickupUser ON FE_PickupUser.ActionInstanceID = FE_ActionInstance.ActionInstanceID
WHERE FE_ActionInstance.ActionInstanceID = '@ActivityID'
";
            _strSql = _strSql.Replace("@ActivityID", ActionInstanceID);
            DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, _strSql).Tables[0];
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();

            return "";
        }

        /// <summary>
        /// 删除接收对象
        /// 添加人：张西琼
        /// 时间：2014/8/1
        /// </summary>
        /// <param name="id">ActionInstanceID</param>
        /// <returns></returns>
        public bool DelActionInstance(string id)
        {
            if (id == "")
                return false;
            string _strSql = "DELETE FROM FE_ActionInstance WHERE ActionInstanceID IN(" + id + ")";
            if (SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, _strSql) > 0)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 根据 activityId 删除所有接收对象
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="activityId"></param>
        /// <returns></returns>
        public bool DeleteByActivityId(string activityId)
        {
            var strSql = string.Format("DELETE FROM FE_ActionInstance WHERE ActivityID='{0}'", activityId);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql) > 0;
        }

        public bool UpdateActionInstance(FeActionInstanceEntity fe)
        {
            int isUnlock = 0;

            if (!fe.IsUnlock)
            {
                isUnlock = 1;
            }
            string strSql = string.Format(@"update FE_ActionInstance set ActionInstanceID='{0}', ActivityID='{1}',CommunityID='{2}',
CommunityName='{3}',CreateBy='{4}',
CreateOn='{5}',CreatorId='{6}',IsUnlock={7},RowStatus=0,
UpdateBy='{8}',UpdateId='{9}',UpdateOn='{10}',
UserID='{11}',UserName='{12}' where Id='{13}' ;select @@rowcount;", fe.ActionInstanceID, fe.ActivityID, fe.CommunityID,
   fe.CommunityName, fe.CreateBy, fe.CreateOn, fe.CreatorId, isUnlock, fe.UpdateBy, fe.UpdateId, fe.UpdateOn, fe.UserID, fe.UserName, fe.Id);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql, fe.GetParms()) > 0;

        }


          /// <summary>
        /// 获取流程下的所以人员
        /// </summary>
        /// <param name="FlowName">流程名称</param>
        /// <returns></returns>
        public List<string> GetProcessUser(string FlowName)
        {
            var userIds=new List<string>();
            string strSql = string.Format(@"SELECT I.USERID FROM [DBO].[FE_PROCESS] P
LEFT JOIN [DBO].[FE_ACTIVITY] A ON A.PROCESSID=P.PROCESSID
LEFT JOIN [DBO].[FE_ACTIONINSTANCE] I ON I.ACTIVITYID=A.ACTIVITYID
WHERE P.FlowName='{0}'
AND I.USERID IS NOT NULL", FlowName);
            DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            if (dt == null && dt.Rows.Count < 0)
            {
                return userIds;
            }
            else
            {
                userIds = dt.Select().Select(i => i[0].ToString()).ToList();
                return userIds;
            }
        }

    }
}

