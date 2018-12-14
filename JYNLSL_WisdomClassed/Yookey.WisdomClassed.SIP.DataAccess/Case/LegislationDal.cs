//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LegislationDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/24 10:22:25
//  功能描述：Legislation数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Data;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    /// <summary>
    /// Legislation数据访问操作
    /// </summary>
    public class LegislationDal : DalImp.BaseDal<LegislationEntity>
    {
        public LegislationDal()
        {
            Model = new LegislationEntity();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            try
            {
                var str = new StringBuilder(string.Format(@"delete from Legislation where Id='{0}'", id));
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, str.ToString());
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public DataTable GetLegislation(string keywords, int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT * FROM Legislation WHERE RowStatus=1 ");
                if (!string.IsNullOrEmpty(keywords))
                {
                    strSql.AppendFormat(@" AND (ItemNo LIKE '%{0}%')", keywords);
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "Num", "ASC", pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        #region 插入语句.
        /// <summary>
        /// 4.2.1	违法行为
        /// </summary>
        public string InsertLegislation
        {
            get
            {
                StringBuilder sb = new StringBuilder("");
                sb.Append(@"insert into [Legislation]([Id]
                       ,[Num]
                       ,[ItemCode]
                       ,[ItemType]
                       ,[ItemNo]
                       ,[ItemAct]
                       ,[ClassNo]
                       ,[ClassName]
                       ,[OrderNo]
                       ,[IsSync])");
                sb.Append(" values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')");
                return sb.ToString();
            }
        }
        /// <summary>
        /// 4.2.3	法律条例
        /// </summary>
        public string InsertLegislationGist
        {
            get
            {
                StringBuilder sb = new StringBuilder("");
                sb.Append(@"insert into LegislationGist(id,legislationitemid,num,itemno,gistname,dutyname,stipulatefirst,stipulatesecond,issync)");
                sb.Append(" values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')");
                return sb.ToString();
            }

        }
        /// <summary>
        /// 4.2.2	适用案由
        /// </summary>
        public string InsertLegislationItem
        {
            get
            {
                StringBuilder sb = new StringBuilder("");
                sb.Append(@"insert into LegislationItem(id,legislationid,num,itemno,itemname,orderno,issync)");
                sb.Append(" values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')");
                return sb.ToString();
            }
        }
        /// <summary>
        /// 4.2.4	处罚标准
        /// </summary>
        public string InsertLegislationRule
        {
            get
            {
                StringBuilder sb = new StringBuilder("");
                sb.Append(@"insert into LegislationRule(id,itemno,legislationid,punishcontent,punishdesc,punishtype,measurement,punishmax,punishmin,orderno,issync)");
                sb.Append(" values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')");
                return sb.ToString();
            }
        }
        #endregion

        #region 查询语句
        /// <summary>
        /// 4.2.1	违法行为
        /// </summary>
        public string GetLegislation()
        {
            try
            {
                string sql = "select Id CaseInfoID,Num,ItemCode,ItemType,ItemNo,ItemAct,ClassNo,ClassName,OrderNo  from [dbo].[Legislation] where IsSync is null";
                return sql;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 4.2.3	法律条例
        /// </summary>
        public string GetLegislationGist()
        {
            try
            {
                string sql = "select Id CaseInfoID,LegislationItemId,Num,ItemNo,GistName,DutyName,StipulateFirst,StipulateSecond from [dbo].[LegislationGist] where IsSync is null";
                return sql;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 4.2.2	适用案由
        /// </summary>
        public string GetLegislationItem()
        {
            try
            {
                string sql = "select Id CaseInfoID,LegislationId,Num,ItemNo,ItemName,OrderNo from [dbo].[LegislationItem] where IsSync is null";
                return sql;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 4.2.4	处罚标准
        /// </summary>
        public string GetLegislationRule()
        {
            try
            {
                string sql = "select Id CaseInfoID,ItemNo,LegislationId,PunishContent,PunishDesc,PunishType,Measurement,PunishMax,PunishMin,OrderNo from [dbo].[LegislationRule] where IsSync is null";
                return sql;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region 路段内容
        /// <summary>
        /// 路段插入
        /// </summary>
        public string RoadManager
        {
            get
            {
                StringBuilder sb = new StringBuilder("");
                sb.Append("insert into RoadManager(Id,ROADNO,ROADNAME,IsSync)");
                sb.Append(" values('{0}','{1}','{2}','{3}')");
                return sb.ToString();
            }
        }
        /// <summary>
        /// 查询内容
        /// </summary>
        /// <returns></returns>
        public string GetRoadManager()
        {
            try
            {
                string sql = "select Id CaseInfoID,ROADNO,ROADNAME  from RoadManager where IsSync is null";
                return sql;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        #endregion


        /// <summary>
        /// 查询法律法规
        /// 添加人：周 鹏
        /// 添加时间：2015-03-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="qType">查询类型：Legislation,LegislationItem,LegislationGist,LegislationRule</param>
        /// <returns></returns>
        public DataTable MobileQueryLegislation(string qType)
        {
            try
            {
                var strSql = "";
                switch (qType)
                {
                    case "Legislation":
                        strSql = string.Format("SELECT Id,ItemCode,ItemNo,ItemAct,ClassNo,ClassName FROM Legislation WHERE RowStatus=1 ORDER BY ItemNo,Num");
                        break;
                    case "LegislationItem":
                        strSql = string.Format("SELECT Id,LegislationId,ItemNo,ItemName FROM LegislationItem WHERE RowStatus=1 ORDER BY ItemNo,Num");
                        break;
                    case "LegislationGist":
                        strSql = string.Format("SELECT Id,LegislationItemId,ItemNo,GistName,DutyName,StipulateFirst,StipulateSecond,OrderNo FROM LegislationGist WHERE RowStatus=1 ORDER BY ItemNo,Num");
                        break;
                    case "LegislationRule":
                        strSql = string.Format("SELECT Id,LegislationId,PunishContent,PunishDesc,PunishMax,PunishMin,OrderNo FROM LegislationRule WHERE RowStatus=1");
                        break;
                }
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

