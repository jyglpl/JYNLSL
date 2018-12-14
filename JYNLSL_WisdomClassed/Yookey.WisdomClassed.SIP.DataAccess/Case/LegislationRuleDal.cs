//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LegislationRuleDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/24 10:22:25
//  功能描述：LegislationRule数据访问类
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
    /// LegislationRule数据访问操作
    /// </summary>
    public class LegislationRuleDal : DalImp.BaseDal<LegislationRuleEntity>
    {
        public LegislationRuleDal()
        {           
            Model = new LegislationRuleEntity();
        }

        public DataTable GetCommonQury(string id, int pageSize, int pageIndex, out int totalRecords)
        {
            try
            {
                var str = new StringBuilder(string.Format(@" SELECT  A.Id,A.LegislationId,A.ItemNo,A.PunishContent,A.PunishMax,A.PunishMin,
                                        C.RsKey PunishType,B.RsKey Measurement,A.RowStatus,A.OrderNo FROM LegislationRule A 
                                        LEFT JOIN 
                                        (SELECT * FROM ComResource WHERE ParentId='0018') B ON A.Measurement=B.Id
                                        LEFT JOIN
                                        (SELECT * FROM ComResource WHERE ParentId='0017')C ON   A.PunishType=C.Id
                                        WHERE A.LegislationId='{0}'", id));
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, str.ToString(), "*", "", "OrderNo", "DESC", pageIndex, pageSize, out totalRecords);
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
                var str = new StringBuilder(string.Format(@"delete from LegislationRule where Legislationid='{0}'", id));
                int result= SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, str.ToString());
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 删除处罚依据数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteRule(string id)
        {
            try
            {
                var str = new StringBuilder(string.Format(@"delete from LegislationRule where Id='{0}'", id));
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
                                                                                                                                         
