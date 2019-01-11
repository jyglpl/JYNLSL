//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_ProcessDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:36
//  功能描述：FE_Process数据访问类
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
    /// FE_Process数据访问操作
    /// </summary>
    public class FeProcessDal : DalImp.BaseDal<FeProcessEntity>
    {
        public FeProcessDal()
        {
            Model = new FeProcessEntity();
        }

        /// <summary>
        /// 启用流程
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="processId">流程编号</param>
        /// <param name="flowName">流程名称</param>
        /// <returns></returns>
        public bool OpenUnlock(string processId, string flowName)
        {
            string strSql = @"
UPDATE FE_Process SET IsUnlock = 0 WHERE ProcessID != '@ProcessID' AND FlowName='@FlowName' AND IsUnlock=1 
UPDATE FE_Process SET IsUnlock = 1 WHERE ProcessID = '@ProcessID'";
            strSql = strSql.Replace("@ProcessID", processId);
            strSql = strSql.Replace("@FlowName", flowName);

            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
        }


        /// <summary>
        /// 得到版本号
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="flowName">流程名称</param>
        /// <returns></returns>
        public string GetVersion(string flowName)
        {
            var strSql = string.Format("SELECT MAX(CONVERT(DECIMAL(18,1),REPLACE(ISNULL(CVersion,'0'),'V',''))) FROM FE_Process WHERE CVersion != '' AND flowName='{0}'", flowName);
            var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            var strReturnValue = "V1.0";
            if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
            {
                strReturnValue = "V" + (decimal.Parse(dt.Rows[0][0].ToString()) + 1);
            }
            return strReturnValue;
        }
        /// <summary>
        /// 得到流程记录
        /// 添加人：张西琼
        /// 添加时间：2014-07-22
        /// </summary>
        /// <param name="flowName">流程名称</param>
        /// <param name="IsUnlock">是否启用 0没有 1启用 不等于0或1就是所有</param>
        /// <param name="isMaxVersion">是否取最大版本号的流程记录</param>
        /// <returns></returns>
        public DataTable GetProcess(string flowName, int IsUnlock, bool isMaxVersion)
        {
            var strSql = "SELECT * FROM FE_Process WHERE 1=1 @Condtion ORDER BY FlowName";
            var strCon = "";
            if (!string.IsNullOrEmpty(flowName))
                strCon = " AND FlowName Like '" + flowName + "'";
            if (IsUnlock >= 0 && IsUnlock < 2)
            {
                strCon += " AND IsUnlock=" + IsUnlock;
            }
            if (isMaxVersion)
            {
                var strConTemp = " AND Replace(CVersion,'V','') IN (SELECT MAX(Replace(CVersion,'V','')) FROM FE_Process WHERE 1=1 @Condtion GROUP BY FlowName)";
                strConTemp = strConTemp.Replace("@Condtion", strCon);
                strCon += strConTemp;
            }

            strSql = strSql.Replace("@Condtion", strCon);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
        }

        /// <summary>
        /// 删除流程
        /// 添加人：张西琼
        /// 时间：2014/8/5
        /// </summary>
        /// <param name="processID"></param>
        /// <returns></returns>
        public bool DeleteProcess(string processID)
        {
            string _strSql = @"
DELETE FROM FE_ActionInstance WHERE ActivityID IN(SELECT ActivityID FROM FE_Activity WHERE ProcessID='@ProcessID')
DELETE FROM dbo.FE_RuleCode WHERE ActivityID IN(SELECT ActivityID FROM FE_Activity WHERE ProcessID='@ProcessID')
DELETE FROM FE_Action WHERE ProcessID='@ProcessID'
DELETE FROM FE_Activity WHERE ProcessID='@ProcessID'
DELETE FROM FE_Process WHERE ProcessID='@ProcessID'
";
            _strSql = _strSql.Replace("@ProcessID", processID);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, _strSql) > 0;
        }


        /// <summary>
        /// 得到版本号最大的流程ID
        /// </summary>
        /// <param name="flowName">流程名称</param>
        /// <returns></returns>
        public string GetVersionMaxProcessId(string flowName)
        {
            var strSql = "SELECT TOP 1 ProcessID FROM FE_Process WHERE ISNULL(CVersion,'') != '' AND FlowName ='" + flowName + "' AND IsUnlock=1 ORDER BY CONVERT(DECIMAL(18,0),REPLACE(CVersion,'V','0')) DESC";
            var dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            return dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "";
        }

        /// <summary>
        /// 执行Sql 语句
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string strSql)
        {
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
        }

        /// <summary>
        /// 执行Sql 语句
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <returns></returns>
        public bool ExecuteNonQuery(string strSql)
        {
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql) > 0;
        }
    }
}

