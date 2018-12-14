//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LegislationItemDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/24 10:22:25
//  功能描述：LegislationItem数据访问类
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
    /// LegislationItem数据访问操作
    /// </summary>
    public class LegislationItemDal : DalImp.BaseDal<LegislationItemEntity>
    {
        public LegislationItemDal()
        {           
            Model = new LegislationItemEntity();
        }

        /// <summary>
        /// 查询路由信息
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
                var str = new StringBuilder(string.Format(@"SELECT Id,LegislationId,Num,ItemNo,ItemName,CreateOn FROM LegislationItem where LegislationId='{0}'", id));
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
                var str = new StringBuilder(string.Format(@"delete from LegislationItem where Legislationid='{0}'", id));
                int result= SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, str.ToString());
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
        public bool DeleteAnyou(string id)
        {
            try
            {
                var str = new StringBuilder(string.Format(@"delete from LegislationItem where Id='{0}'", id));
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
                                                                                                                                         
