//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="IBaseDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-02
//  功能描述：数据访问层基础类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using Yookey;
using Yookey.WisdomClassed.SIP.DataAccess.IDal;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.IModel;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.DataAccess.DalImp
{
    public class BaseDal<T> : IBaseDal<T> where T : IBaseModel<T>
    {
        /// <summary>
        /// 实体
        /// </summary>
        public T Model { get; set; }

        /// <summary>
        /// 通过实体获取参数
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public virtual SqlParameter[] GetParmsByModel(T model)
        {
            var pars = model.GetParms();
            var parsAll = new SqlParameter[pars.Length + 2];
            for (int i = 0; i < pars.Length; i++)
            {
                parsAll[i] = pars[i];
            }
            parsAll[parsAll.Length - 2] = new SqlParameter(model.Parm_Id, model.Id);
            parsAll[parsAll.Length - 1] = new SqlParameter(model.Parm_Version, model.Version);
            return parsAll;
        }

        /// <summary>
        /// 根据主键Id获取实体
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        public virtual T Get(string id)
        {
            try
            {
                QueryCondition condition = QueryCondition.Instance.AddEqual(Model.Parm_Id, id);
                IList<T> data = Query(condition);
                if (data.Count > 0)
                    return data[0];
                return default(T);
            }
            catch (Exception e)
            {
                throw new Exception("获取单条数据时出错，请重试！", e);
            }
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public virtual T Add(T model)
        {
            SqlParameter[] parms = model.GetParms();
            parms = model.SetParmsValueByModelForAdd(model, parms);
            string id = Convert.ToString(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringWrite, CommandType.Text, model.Sql_Insert, parms).ToString());
            // model.Id = id;
            return model;
        }

        /// <summary>
        /// 新增实体带事务
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="tran">事务名</param>
        /// <returns></returns>
        public virtual T Add(T model, SqlTransaction tran)
        {
            SqlParameter[] parms = model.GetParms();
            parms = model.SetParmsValueByModelForAdd(model, parms);
            string id = Convert.ToString(SqlHelper.ExecuteScalar(tran, CommandType.Text, model.Sql_Insert, parms).ToString());
            // model.Id = id;
            return model;
        }

        /// <summary>
        /// 通过实体相应字段(Id,Version)修改实体
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public virtual int Update(T model)
        {
            SqlParameter[] pars = GetParmsByModel(model);
            pars = model.SetParmsValueByModelForUpdate(model, pars);
            return int.Parse(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringWrite, CommandType.Text, model.Sql_Update, pars).ToString());
        }

        /// <summary>
        /// 通过实体相应字段(Id,Version)修改实体,带事务
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="tran">事务名</param>
        /// <returns></returns>
        public virtual int Update(T model, SqlTransaction tran)
        {
            SqlParameter[] pars = GetParmsByModel(model);
            pars = model.SetParmsValueByModelForUpdate(model, pars);
            return int.Parse(SqlHelper.ExecuteScalar(tran, CommandType.Text, model.Sql_Update, pars).ToString());
        }

        /// <summary>
        /// 通过主键Id和version删除
        /// </summary>
        /// <param name="pk">主键Id</param>
        /// <param name="version">version</param>
        /// <returns></returns>
        public virtual int Delete(int pk, long version)
        {
            var parms = new SqlParameter[2];
            parms[0] = new SqlParameter("Id", pk);
            parms[1] = new SqlParameter("Version", version);
            return int.Parse(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringWrite, CommandType.Text, Model.Sql_Delete, parms).ToString());
        }

        /// <summary>
        /// 通过主键Id和version删除带事务
        /// </summary>
        /// <param name="pk">主键Id</param>
        /// <param name="version">version</param>
        /// <param name="tran">事务名</param>
        /// <returns></returns>
        public virtual int Delete(int pk, long version, SqlTransaction tran)
        {
            var parms = new SqlParameter[2];
            parms[0] = new SqlParameter("Id", pk);
            parms[1] = new SqlParameter("Version", version);
            return int.Parse(SqlHelper.ExecuteScalar(tran, CommandType.Text, Model.Sql_Delete, parms).ToString());
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public virtual DataSet QueryBase(QueryCondition condition)
        {
            if (condition != null)
            {
                SqlParameter[] parms;
                string sql = condition.ParseSql(Model.TB_Name, Model.Parm_Id, out parms);
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sql, parms);
            }
            return null;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public virtual IList<T> Query(QueryCondition condition)
        {
            DataSet ds = QueryBase(condition);
            return DataSetToList(condition, ds);
        }

        /// <summary>
        /// 查询并返回总记录数
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public virtual IList<T> Query(QueryCondition condition, out int recordCount)
        {
            recordCount = 0;
            DataSet ds = QueryBase(condition);
            if (ds != null && ds.Tables[0] != null)
                recordCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            return DataSetToList(condition, ds);
        }

        /// <summary>
        /// 查询并返回总记录数和总页数
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="pageCount">总页数</param>
        /// <returns></returns>
        public virtual IList<T> Query(QueryCondition condition, out int recordCount, out int pageCount)
        {
            recordCount = 0;
            pageCount = 0;
            DataSet ds = QueryBase(condition);
            if (ds != null && ds.Tables[0] != null)
            {
                recordCount = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                int pageSize = condition.GetPager().PageSize;
                pageCount = (recordCount + pageSize - 1) / pageSize;
            }
            return DataSetToList(condition, ds);
        }

        /// <summary>
        /// 查询返回数量
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public virtual int QueryCount(QueryCondition condition)
        {
            condition.JustGetCount();
            DataSet ds = QueryBase(condition);
            if (ds != null && ds.Tables[0] != null)
                return int.Parse(ds.Tables[0].Rows[0][0].ToString());
            return 0;
        }

        /// <summary>
        /// 查询结果的DataSet转为List
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="ds">数据集</param>
        /// <returns></returns>
        public virtual IList<T> DataSetToList(QueryCondition condition, DataSet ds)
        {
            try
            {
                IList<T> list = new List<T>();
                if (ds != null && ds.Tables.Count > 0)
                {
                    IList<string> fields = condition.SelectFields;
                    DataTable dt = condition.GetPager() != null ? ds.Tables[1] : ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(Model.SetModelValueByDataRow(dr, fields));
                    }
                }
                return list;
            }
            catch (Exception e)
            {
                throw new Exception("将数据表转换成对象时出错！", e);
            }
        }

        /// <summary>
        /// DataTable转为List
        /// </summary>
        /// <param name="dt">数据集</param>
        /// <returns></returns>
        public virtual List<T> DataTableToList(DataTable dt)
        {
            return (from DataRow dr in dt.Rows select Model.SetModelValueByDataRow(dr)).ToList();
        }
    }
}
