//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComNoteDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/9 10:53:33
//  功能描述：ComNote数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using Yookey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Com;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    /// <summary>
    /// ComNote数据访问操作
    /// </summary>
    public class ComNoteDal : DalImp.BaseDal<ComNoteEntity>
    {
        public ComNoteDal()
        {
            Model = new ComNoteEntity();
        }

        /// <summary>
        /// 短信消息查询
        /// </summary>
        /// <param name="person">名称</param>
        /// <param name="phoneNumber">手机号码</param>
        /// <param name="dateStart">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable GetCommonQury(string person, string phoneNumber, string dateStart, string dateEnd, int pageSize, int pageIndex, out int totalRecords)
        {
            try
            {
                var str = new StringBuilder(@"SELECT * FROM ComNoteContent Where 1=1");
                if (!string.IsNullOrEmpty(person))
                    str.Append(string.Format(@" AND ReceivePhone LIKE '%{0}%'", person));
                if (!string.IsNullOrEmpty(phoneNumber))
                    str.Append(string.Format(@" AND ReceivePhone LIKE '%{0}%'", phoneNumber));
                if (!(string.IsNullOrEmpty(dateStart) && string.IsNullOrEmpty(dateEnd)))
                    str.Append(string.Format(@" AND ReceiveTime>='{0}' AND ReceiveTime<='{1}' ", dateStart, dateEnd));
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, str.ToString(), "*", "", "ReceiveTime", "DESC", pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询详细实体数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ComNoteContentEntity QueryNoteContent(string id)
        {
            try
            {
                var str = new StringBuilder(@"SELECT * FROM ComNoteContent Where 1=1");
                if (!string.IsNullOrEmpty(id))
                    str.Append(string.Format(@" AND id='{0}'", id));
                var tb = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, str.ToString()).Tables[0];
                if (tb != null)
                    return TableToList(new ComNoteContentEntity().ConvertList, tb)[0];
                return new ComNoteContentEntity();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取手机号码数据
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public List<Node> GetNodeQury(string pId)
        {
            try
            {
//                var str = new StringBuilder(string.Format(@"WITH Dept as(
//SELECT Id id,ParentId pId,FullName name FROM CrmCompany 
//WHERE FullName ='{0}'
//UNION ALL 
//SELECT AAA.Id id,AAA.ParentId pId,AAA.FullName name from Dept,
//CrmCompany AAA
//where Dept.id = AAA.ParentId  )
//SELECT * FROM Dept 
//UNION ALL
//SELECT BB.Id id,BB.CompanyId pId,BB.FullName name FROM  Dept AA ,
//CrmDepartment BB
//WHERE AA.Id=BB.CompanyId
//UNION ALL
//SELECT U.Mobile id,U.DepartmentId pId,U.RealName name FROM 
//CrmUser U,  Dept AA ,CrmDepartment BB
//WHERE AA.Id=BB.CompanyId AND U.DepartmentId=BB.Id", pId));

                var str = new StringBuilder("");
                str.AppendFormat(@"WITH Dept as(
SELECT Id id,ParentId pId,FullName name ,SortCode FROM CrmCompany WHERE FullName ='姑苏区城市管理行政执法局'
UNION ALL 
SELECT AAA.Id id,AAA.ParentId pId,AAA.FullName name,AAA.SortCode FROM Dept,CrmCompany AAA WHERE AAA.RowStatus=1 AND Dept.id = AAA.ParentId )
SELECT * FROM Dept
UNION ALL
SELECT BB.Id id,BB.CompanyId pId,BB.FullName name,BB.SortCode FROM  Dept AA ,CrmDepartment BB WHERE BB.RowStatus=1 AND AA.Id=BB.CompanyId
UNION ALL
SELECT U.Mobile id,U.DepartmentId pId,U.RealName name,U.SortCode FROM CrmUser U, Dept AA ,CrmDepartment BB 
WHERE U.RowStatus=1 AND AA.Id=BB.CompanyId AND U.DepartmentId=BB.Id
ORDER BY pId,SortCode");

                var tb = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, str.ToString()).Tables[0];
                if (tb != null)
                    return TableToList(new Node().ConvertList, tb);
                return new List<Node>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private static List<T> TableToList<T>(Func<DataRow, T> func, DataTable dt) where T : new()
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            var list = new List<T>(dt.Rows.Count);
            list.AddRange(from DataRow dr in dt.Rows select func(dr));
            return list;
        }

        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteMessage(string id)
        {
            try
            {
                var strNote = new StringBuilder(string.Format("DELETE FROM ComNote WHERE ResourcesId='{0}'",
                    id));
                var strNoteContent = new StringBuilder(string.Format("DELETE FROM ComNoteContent WHERE Id='{0}'",
                    id));
                int resultNote = SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strNote.ToString());
                int resultNoteContent = SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strNoteContent.ToString());
                return resultNote > 0 && resultNoteContent > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 保存短信消息集合
        /// </summary>
        /// <param name="noteContent"></param>
        /// <returns></returns>
        public bool SaveNoteContent(ComNoteContentEntity noteContent)
        {
            try
            {
                var str = new StringBuilder("INSERT INTO ComNoteContent(Id,ReceivePhone,MistakeInfo,ReceiveTime,SendPerson)");
                str.Append(string.Format(@" VALUES('{0}' ,'{1}','{2}','{3}','{4}')", noteContent.Id, noteContent.ReceivePhone,
                    noteContent.MistakeInfo, noteContent.ReceiveTime, noteContent.SendPerson));
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, str.ToString());
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

          /// <summary>
        /// 按期无效短信
        /// </summary>
        /// <param name="resourcesId">案件编号</param>
        /// <returns></returns>
        public bool DelteByFormId(string resourcesId)
        {
            if (string.IsNullOrEmpty(resourcesId))
                return false;
            try
            {
                var str = string.Format("update ComNote set RowStatus=0 where ResourcesId='{0}'",resourcesId);
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, str.ToString());
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

       
    }
}

