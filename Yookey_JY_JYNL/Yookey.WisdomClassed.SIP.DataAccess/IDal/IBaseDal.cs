//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="IBaseDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-02
//  功能描述：数据访问层接口类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.IModel;

namespace Yookey.WisdomClassed.SIP.DataAccess.IDal
{
    public  interface IBaseDal<T> where T : IBaseModel<T>
    {      
        /// <summary>
        /// 根据主键Id获取实体
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        T Get(string id);

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        T Add(T model);

        /// <summary>
        /// 新增实体带事务
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="tran">事务名</param>
        /// <returns></returns>
        T Add(T model, SqlTransaction tran);

        /// <summary>
        /// 通过实体相应字段(Id,Version)修改实体
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        int Update(T model);

        /// <summary>
        /// 通过实体相应字段(Id,Version)修改实体,带事务
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="tran">事务名</param>
        /// <returns></returns>
        int Update(T model, SqlTransaction tran);

        /// <summary>
        /// 通过主键Id和version删除
        /// </summary>
        /// <param name="pk">主键Id</param>
        /// <param name="version">version</param>
        /// <returns></returns>
        int Delete(int pk, long version);

        /// <summary>
        /// 通过主键Id和version删除带事务
        /// </summary>
        /// <param name="pk">主键Id</param>
        /// <param name="version">version</param>
        /// <param name="tran">事务名</param>
        /// <returns></returns>
        int Delete(int pk, long version, SqlTransaction tran);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        DataSet QueryBase(QueryCondition condition);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        IList<T> Query(QueryCondition condition);

        /// <summary>
        /// 查询并返回总记录数
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        IList<T> Query(QueryCondition condition, out int recordCount);

        /// <summary>
        /// 查询并返回总记录数和总页数
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="recordCount">总记录数</param>
        /// <param name="pageCount">总页数</param>
        /// <returns></returns>
        IList<T> Query(QueryCondition condition, out int recordCount, out int pageCount);

        /// <summary>
        /// 查询返回数量
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        int QueryCount(QueryCondition condition);

        /// <summary>
        /// 查询结果的DataSet转为List
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="ds">数据集</param>
        /// <returns></returns>
        IList<T> DataSetToList(QueryCondition condition, DataSet ds);

        /// <summary>
        /// DataTable转为List
        /// </summary>
        /// <param name="dt">数据集</param>
        /// <returns></returns>
        List<T> DataTableToList(DataTable dt);

    }
}
