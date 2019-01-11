//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="BaseBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-02
//  功能描述：业务逻辑类基础层
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data.SqlClient;
using Yookey.WisdomClassed.SIP.DataAccess.IDal;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.IModel;

namespace Yookey.WisdomClassed.SIP.Business.BllImp
{
    public class BaseBll<T> where T : IBaseModel<T> 
    {
        /// <summary>
        /// 实例化数据访问层接口
        /// </summary>
        protected IBaseDal<T> BaseDal { get; set; }

        /// <summary>
        /// 根据主键Id获取实体
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        public virtual T Get(string id)
        {
            return BaseDal.Get(id);
        }

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public virtual T Add(T model)
        {
            return BaseDal.Add(model);
        }

        /// <summary>
        /// 新增实体带事务
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="tran">事务名</param>
        /// <returns></returns>
        public virtual T Add(T model,SqlTransaction tran)
        {
            return BaseDal.Add(model, tran);
        }

        /// <summary>
        /// 通过实体相应字段(Id,Version)修改实体
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public virtual int Update(T model)
        {
            return BaseDal.Update(model);
        }

        /// <summary>
        /// 通过实体相应字段(Id,Version)修改实体,带事务
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="tran">事务名</param>
        /// <returns></returns>
        public virtual int Update(T model, SqlTransaction tran)
        {
            return BaseDal.Update(model, tran);
        }

        /// <summary>
        /// 通过主键Id和version删除
        /// </summary>
        /// <param name="pk">主键Id</param>
        /// <param name="version">version</param>
        /// <returns></returns>
        public virtual int Delete(int pk, long version)
        {
            return BaseDal.Delete(pk, version);
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
            return BaseDal.Delete(pk, version,tran);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public virtual IList<T> Query(QueryCondition condition)
        {
            return BaseDal.Query(condition);
        }

        /// <summary>
        /// 查询并返回总记录数
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="recordCount">总记录数</param>
        /// <returns></returns>
        public virtual IList<T> Query(QueryCondition condition, out int recordCount)
        {
            return BaseDal.Query(condition, out recordCount);
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
            return BaseDal.Query(condition, out recordCount, out pageCount);
        }

        /// <summary>
        /// 查询返回数量
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public virtual int QueryCount(QueryCondition condition)
        {
            return BaseDal.QueryCount(condition);
        }
    }
}
