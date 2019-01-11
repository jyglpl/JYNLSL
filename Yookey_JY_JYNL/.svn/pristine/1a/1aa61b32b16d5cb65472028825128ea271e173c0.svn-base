using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey;

namespace Yookey.WisdomClassed.SIP.DataAccess.Mobile
{
    public class ApproveDal
    {
        /// <summary>
        /// 案件管理,获取案件列表
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-06-15 周 鹏 userId 更改为deptId
        ///           2015-06-15 周 鹏 增加查询关键字
        /// </history>
        /// <param name="deptId">部门编号</param>
        /// <param name="fileViewLink">请求地点</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页请求条数</param>
        /// <param name="totalRecords">总条数</param>
        /// <param name="keyWords">查询关键字</param>
        /// <returns></returns>
        public DataTable GetCaseList(string deptId, string fileViewLink, int pageIndex, int pageSize, out int totalRecords, string keyWords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT IPC.Id,CaseDate AS CD,CONVERT(VARCHAR(10),CaseDate,120) AS AJDate,(CASE WHEN TargetType ='00120001' THEN TargetName ELSE TargetUnit END) AS TargetName,CaseAddress,
(RePersonelNameFist+' '+RePersonelNameSecond) AS Users,'{0}' AS FileView,
(SELECT TOP 1 FileAddress FROM INF_PUNISH_ATTACH WHERE ResourceId=IPC.Id ORDER BY CreateOn) AS FileAddress
FROM INF_PUNISH_CASEINFO AS IPC WITH(NOLOCK)
INNER JOIN INF_PUNISH_LEGISLATION AS IPL WITH(NOLOCK) ON IPC.Id=IPL.CASEINFOID AND IPL.RowStatus=1
WHERE IPC.RowStatus=1 ", fileViewLink);

            if (!string.IsNullOrEmpty(deptId))
            {
                strSql.AppendFormat(" AND IPC.DeptId='{0}'", deptId);
            }
            if (!string.IsNullOrEmpty(keyWords))
            {
                strSql.AppendFormat(" AND (IPC.TargetName LIKE '%{0}%' OR IPC.TargetUnit LIKE '%{0}%')", keyWords);
            }

            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CD", "DESC", pageIndex, pageSize, out totalRecords);

        }

        /// <summary>
        /// 获取案件附件
        /// 添加人：周 鹏
        /// 添加时间：2014-12-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseinfoId">案件编号</param>
        /// <param name="fileViewLink"></param>
        /// <returns></returns>
        public DataTable GetFileList(string caseinfoId, string fileViewLink)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT Id,'{0}' AS FileView,FileTypeName,FileAddress FROM INF_PUNISH_ATTACH WHERE RowStatus=1 AND ResourceId='{1}' ORDER BY CreateOn", fileViewLink, caseinfoId);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获取案件附件
        /// 添加人：周 鹏
        /// 添加时间：2018-11-26
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseinfoId">案件编号</param>
        /// <param name="fileType">类型</param>
        /// <param name="fileViewLink"></param>
        /// <returns></returns>
        public DataTable GetFileList(string caseinfoId, string fileType, string fileViewLink)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT Id,'{0}' AS FileView,FileTypeName,FileAddress FROM INF_PUNISH_ATTACH WHERE RowStatus=1 AND ResourceId='{1}' AND FileType='{2}' ORDER BY CreateOn", fileViewLink, caseinfoId, fileType);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }
    }
}
