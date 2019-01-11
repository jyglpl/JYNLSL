//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmIdeaListDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/8/5 14:27:36
//  功能描述：CrmIdeaList数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using DBHelper;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Yookey;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.DataAccess.Crm
{
    /// <summary>
    /// CrmIdeaList数据访问操作
    /// </summary>
    public class CrmIdeaListDal : DalImp.BaseDal<CrmIdeaListEntity>
    {
        public CrmIdeaListDal()
        {
            Model = new CrmIdeaListEntity();
        }


        /// <summary>
        /// 获取消息的最大日期
        /// </summary>
        /// <param name="formid">表单编号</param>
        /// <returns></returns>
        public string GetIdeaListCreateDate(string formid)
        {
            string sbSql = "SELECT MAX(CreateOn) FROM CrmIdeaList WHERE ResourceID = '" + formid + "'";
            return SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql).ToString();
        }

        /// <summary>
        /// 查询意见
        /// 添加人：周 鹏
        /// 添加时间：2014-08-07
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<CrmIdeaListEntity> GetSearchResult(CrmIdeaListEntity search)
        {
            var sqlWhere = new StringBuilder("");
            if (!string.IsNullOrEmpty(search.Duty))
            {
                sqlWhere.AppendFormat(@" And Duty = '{0}'", search.Duty);
            }
            var strSql = string.Format(@"SELECT CI.*,CU.RealName UserName FROM CrmIdeaList AS CI WITH(NOLOCK)
JOIN CrmUser AS CU WITH(NOLOCK) ON CI.UserId=CU.Id
WHERE ResourceID='{0}' {1} ORDER BY CreateOn", search.ResourceID, sqlWhere);
            var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            return DataTableToList(dt);
        }


        /// <summary>
        /// 查询意见
        /// 添加人：周 鹏
        /// 添加时间：2014-09-12
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">办件编号</param>
        /// <returns></returns>
        public DataTable GetMobileFlow(string resourceId)
        {
            var strSql = string.Format(@"SELECT CU.UserName,Idea,Duty AS Duty,CI.CreateOn AS Adate FROM CrmIdeaList AS CI WITH(NOLOCK)
INNER JOIN CrmUser AS CU WITH(NOLOCK) ON CI.UserId=CU.Id
WHERE ResourceID='{0}' ORDER BY CI.CreateOn DESC", resourceId);
            var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            return dt;
        }

        /// <summary>
        /// 根据办件编号、流程名称查询审批意见
        /// 添加人：周 鹏
        /// 添加时间：2014-12-24
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        ///           2015-02-06 周 鹏 修改Sql语句
        ///           2015-02-28 周 鹏 修改用户表的关联
        /// </history>
        /// <param name="resourceId">办件编号</param>
        /// <param name="flowName">流程名称</param>
        /// <returns>DataTable Columns->UserName:用户名称,Idea:意见,Duty:环节名称,Adate:审批日期</returns>
        public DataTable GetFlowIdea(string resourceId, string flowName, int Itype = 0)
        {
            var strSql = new StringBuilder("");
            //            strSql.AppendFormat(@"SELECT CU.UserName,Idea,Duty AS Duty,CONVERT(VARCHAR(10),CI.CreateOn,25) AS Adate FROM CrmIdeaList AS CI WITH(NOLOCK)
            //INNER JOIN CrmUser AS CU WITH(NOLOCK) ON CI.UserId=CU.Id
            //INNER JOIN WF_Process AS WP WITH(NOLOCK) ON CI.ProcessID=WP.Id
            //WHERE ResourceID='{0}' AND WP.[Name]='{1}' ORDER BY CI.CreateOn", resourceId, flowName);

            strSql.AppendFormat(@"SELECT  UserName ,Duty ,
        ( SELECT    Idea
          FROM      dbo.CrmIdeaList AS CIL
          WHERE     CIL.CreateOn = MAX(Adate)
                    AND ResourceID = '{0}') AS Idea ,
        CONVERT(VARCHAR(19), MAX(Adate), 25) AS Adate
FROM    ( SELECT    CU.RealName AS UserName ,
                    Idea ,
                    Duty AS Duty ,
                    CI.CreateOn AS Adate
          FROM      CrmIdeaList AS CI WITH ( NOLOCK )
                    INNER JOIN dbo.CrmUser AS CU WITH ( NOLOCK ) ON CI.UserId = CU.Id
                    INNER JOIN WF_Process AS WP WITH ( NOLOCK ) ON CI.ProcessID = WP.Id
          WHERE     ResourceID = '{0}'
                    AND WP.[Name] = '{1}'
                    AND CI.[Type] = '{2}'
        ) AS TB
GROUP BY UserName ,Duty ORDER BY Adate", resourceId, flowName, Itype);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }


        /// <summary>
        /// 根据办件编号、流程名称查询审批意见
        /// 添加人：周 鹏
        /// 添加时间：2014-12-24
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        ///           2015-02-06 周 鹏 修改Sql语句
        ///           2015-02-28 周 鹏 修改用户表的关联
        /// </history>
        /// <param name="resourceId">办件编号</param>
        /// <param name="flowName">流程名称</param>
        /// <returns>DataTable Columns->UserName:用户名称,Idea:意见,Duty:环节名称,Adate:审批日期</returns>
        public DataTable GetFlowIdeaForHr(string resourceId, string flowName)
        {
            var strSql = new StringBuilder("");
            //            strSql.AppendFormat(@"SELECT CU.UserName,Idea,Duty AS Duty,CONVERT(VARCHAR(10),CI.CreateOn,25) AS Adate FROM CrmIdeaList AS CI WITH(NOLOCK)
            //INNER JOIN CrmUser AS CU WITH(NOLOCK) ON CI.UserId=CU.Id
            //INNER JOIN WF_Process AS WP WITH(NOLOCK) ON CI.ProcessID=WP.Id
            //WHERE ResourceID='{0}' AND WP.[Name]='{1}' ORDER BY CI.CreateOn", resourceId, flowName);

            strSql.AppendFormat(@"SELECT  UserName ,Duty ,
        ( SELECT    Idea
          FROM      dbo.CrmIdeaList AS CIL
          WHERE     CIL.CreateOn = MAX(Adate)
                    AND ResourceID = '{0}') AS Idea ,
        CONVERT(VARCHAR(19), MAX(Adate), 25) AS Adate
FROM    ( SELECT    CU.RealName AS UserName ,
                    Idea ,
                    Duty AS Duty ,
                    CI.CreateOn AS Adate
          FROM      CrmIdeaList AS CI WITH ( NOLOCK )
                    INNER JOIN dbo.CrmUser AS CU WITH ( NOLOCK ) ON CI.UserId = CU.Id
                    INNER JOIN WF_Process AS WP WITH ( NOLOCK ) ON CI.ProcessID = WP.Id
          WHERE     ResourceID = '{0}'
                    AND WP.[Name] = '{1}'
        ) AS TB
GROUP BY UserName ,Duty ORDER BY Adate", resourceId, flowName);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 根据办件编号查询审批意见
        /// 添加人：周 鹏
        /// 添加时间：2018-02-24
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">办件编号</param>
        /// <returns>DataTable Columns->UserName:用户名称,Idea:意见,Duty:环节名称,Adate:审批日期</returns>
        public DataTable GetFlowIdea(string resourceId)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT  UserName ,Duty ,
        ( SELECT    Idea
          FROM      dbo.CrmIdeaList AS CIL
          WHERE     CIL.CreateOn = MAX(Adate)
                    AND ResourceID = '{0}') AS Idea ,
        CONVERT(VARCHAR(19), MAX(Adate), 25) AS Adate
FROM    ( SELECT    CU.RealName AS UserName ,
                    Idea ,
                    Duty AS Duty ,
                    CI.CreateOn AS Adate
          FROM      CrmIdeaList AS CI WITH ( NOLOCK )
                    INNER JOIN dbo.CrmUser AS CU WITH ( NOLOCK ) ON CI.UserId = CU.Id
                    INNER JOIN WF_Process AS WP WITH ( NOLOCK ) ON CI.ProcessID = WP.Id
          WHERE     ResourceID = '{0}'
        ) AS TB
GROUP BY UserName ,Duty ORDER BY Adate", resourceId);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 根据办件编号、流程名称查询最后一条审批意见
        /// 添加人：周 鹏
        /// 添加时间：2015-01-22
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">办件编号</param>
        /// <param name="flowName">流程名称</param>
        /// <returns>DataTable Columns->UserName:用户名称,Idea:意见,Duty:环节名称,Adate:审批日期</returns>
        public DataTable GetLastFlowIdea(string resourceId, string flowName)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT TOP 1 CU.RealName AS UserName,Idea,Duty AS Duty,CI.CreateOn AS Adate FROM CrmIdeaList AS CI WITH(NOLOCK)
INNER JOIN CrmUser AS CU WITH(NOLOCK) ON CI.UserId=CU.Id
INNER JOIN WF_Process AS WP WITH(NOLOCK) ON CI.ProcessID=WP.Id
WHERE ResourceID='{0}' AND WP.[Name]='{1}' ORDER BY CI.CreateOn DESC", resourceId, flowName);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];

        }


        /// <summary>
        /// 根据办件编号、流程名称删除意见【删除非退回的意见】
        /// 添加人：周 鹏
        /// 添加时间：2015-01-22
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">办件编号</param>
        /// <param name="flowName">流程名称</param>
        /// <returns></returns>
        public bool DeleteIdea(string resourceId, string flowName)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"DELETE CrmIdeaList WHERE [Type]=0 AND ProcessID=(SELECT TOP 1 Id FROM WF_Process WHERE FullName='{0}' AND RowStatus=1) AND ResourceID='{1}'", flowName, resourceId);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()) > 0;
        }

        /// <summary>
        /// 获取办件的最后一次审批日期
        /// 添加人：周 鹏
        /// 添加时间：2015-06-26
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">办件编号</param>
        /// <returns>DateTime.</returns>
        public DateTime GetMaxIdeaTimeByResourceId(string resourceId)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT MAX(CreateOn) AS IdeaTime FROM CrmIdeaList WHERE ResourceID='{0}'", resourceId);
            var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString());
            return obj != null && !string.IsNullOrEmpty(obj.ToString()) ? Convert.ToDateTime(obj.ToString()).AddDays(1) : DateTime.Now;
        }

        /// <summary>
        /// 获取案件预审的意见
        /// 添加人：周 鹏
        /// 添加时间：2015-07-28
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">案件主键ID</param>
        /// <returns>DataTable.</returns>
        public DataTable GetPunishCaseFirstTrialIdea(string resourceId)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT CU.RealName AS UserName,CIL.Duty,CIL.Idea,CONVERT(VARCHAR(10),CIL.CreateOn,25) AS Adate FROM CrmIdeaList AS CIL
INNER JOIN CrmUser AS CU ON CIL.UserId=CU.Id
WHERE CIL.ResourceID='{0}' AND CIL.ProcessID='0' AND CIL.ProcessInstanceID=''
ORDER BY CIL.CreateOn", resourceId);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获取许可的消息集合
        /// </summary>
        /// <returns></returns>
        public List<CrmIdeaListEntity> GetIdeaListByLicense()
        {
            var strSql = string.Format(@"select I.*,CU.RealName UserName from CrmIdeaList I inner join LicenseMain LM on LM.Id=I.ResourceID
LEFT JOIN CrmUser CU ON CU.Id=I.UserId
where LM.RowStatus=1 
order by I.CreateOn DESC");
            var ideaList = DataTableToList(SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql).Tables[0]);
            return ideaList;

        }

        /// <summary>
        /// 获取信访的消息结合
        /// </summary>
        /// <returns></returns>
        public DataTable GetIdeaListByPetition(string Id)
        {
            var strSql = string.Format(@"select Idea,realname UserName,ideas.createon Adate from crmidealist ideas LEFT JOIN CrmUser CU ON CU.Id=ideas.UserId where resourceid = '" + Id + "' order by Adate");
            var ideaList = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql).Tables[0];
            return ideaList;
        }
    }
}

