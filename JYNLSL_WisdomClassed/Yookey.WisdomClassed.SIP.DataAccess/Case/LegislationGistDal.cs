//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LegislationGistDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/24 10:22:25
//  功能描述：LegislationGist数据访问类
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
    /// LegislationGist数据访问操作
    /// </summary>
    public class LegislationGistDal : DalImp.BaseDal<LegislationGistEntity>
    {
        public LegislationGistDal()
        {           
            Model = new LegislationGistEntity();
        }

        /// <summary>
        /// 查询法律法规信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable GetCommonQury(string id, int pageSize, int pageIndex, out int totalRecords)
        {
            try
            {
                var str = new StringBuilder(string.Format(@"SELECT Id,LegislationItemId,Num,ItemNo,GistName,
                                    GistStrip,GistClause,GistItem,DutyName,DutyStrip,DutyClause,DutyItem,
                                    LawContent,StipulateFirst,StipulateSecond,ReCaseAbstract,
                                    ReOpinion,ReHarm,HaCaseAbstract,HaOpinion,EndCaseAbstract,
                                    EndPunishments,EndExecute,EndLawsuit,EndOpinion,PunishMethod,
                                    Records,OrderNo,RowStatus,CreatorId,CreateBy,CreateOn,
                                    UpdateId,UpdateBy,UpdateOn FROM LegislationGist Where 
                                    LegislationItemId='{0}'", id));
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, str.ToString(), "*", "", "CreateOn", "DESC", pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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
                var str = new StringBuilder(string.Format(@"Delete From LegislationGist Where LegislationItemId In
                                 ( Select Id From LegislationItem where Legislationid='{0}')", id));
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, str.ToString());
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 删除案由数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteGist(string id)
        {
            try
            {
                var str = new StringBuilder(string.Format(@"Delete From LegislationGist Where Id='{0}' ", id));
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, str.ToString());
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }


}
                                                                                                                                         
