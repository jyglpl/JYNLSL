//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="QueryCondition.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-02
//  功能描述：查询类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.Model
{
    /// <summary>
    /// 在此描述QueryCondition的说明
    /// </summary>
    [Serializable]
    public class QueryCondition
    {
        #region 变量
        //查询字段列表
        public IList<string> SelectFields;
        //查询表格
        //string table;
        //排序规则列表
        readonly IList<KeyValuePair<string, bool>> _orderBys;
        //基本查询条件
        readonly IList<Condition> _conditions;
        //分页配置
        PagerOptions _po;
        //是否只获取记录条数
        bool _getCount;
        //或查询
        readonly IList<OrCondition> _orConditions;
        //join的主表
        string _joinMaster;
        //join主表的主键
        string _joinMasterPk;
        //JOIN的表
        readonly IList<KeyValuePair<string, JoinOnCondition>> _joinTables;

        #endregion

        #region 构造函数
        private QueryCondition()
        {
            SelectFields = new List<string>();
            _orderBys = new List<KeyValuePair<string, bool>>();
            _conditions = new List<Condition>();
            _orConditions = new List<OrCondition>();
            _joinTables = new List<KeyValuePair<string, JoinOnCondition>>();
            _joinMasterPk = string.Empty;
            _joinMaster = string.Empty;
        }

        public static QueryCondition Instance
        {
            get
            {
                return new QueryCondition();
            }
        }
        #endregion

        #region 查询条件
        /// <summary>
        /// 新增一个等于条件，单表
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="value">等于值</param>
        /// <returns></returns>
        public QueryCondition AddEqual(string fieldName, string value)
        {
            _conditions.Add(new Condition(fieldName, value, QueryOperator.Equal));
            return this;
        }

        /// <summary>
        /// 新增一个等于条件，多表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">等于值</param>
        /// <returns></returns>
        public QueryCondition AddEqual(string tableName, string fieldName, string value)
        {
            _conditions.Add(new Condition(tableName + "." + fieldName, value, QueryOperator.Equal));
            return this;
        }

        /// <summary>
        /// 新增一个不相等条件，单表
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public QueryCondition AddNotEqual(string fieldName, string value)
        {
            _conditions.Add(new Condition(fieldName, value, QueryOperator.NotEqual));
            return this;
        }

        /// <summary>
        /// 新增一个不相等条件，多表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">等于值</param>
        /// <returns></returns>
        public QueryCondition AddNotEqual(string tableName, string fieldName, string value)
        {
            _conditions.Add(new Condition(tableName + "." + fieldName, value, QueryOperator.NotEqual));
            return this;
        }

        /// <summary>
        /// 新增一个大于条件，单表
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public QueryCondition AddLarger(string fieldName, string value)
        {
            _conditions.Add(new Condition(fieldName, value, QueryOperator.Larger));
            return this;
        }

        /// <summary>
        /// 新增一个大于条件，多表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">等于值</param>
        /// <returns></returns>
        public QueryCondition AddLarger(string tableName, string fieldName, string value)
        {
            _conditions.Add(new Condition(tableName + "." + fieldName, value, QueryOperator.Larger));
            return this;
        }

        /// <summary>
        /// 新增一个小于条件，单表
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public QueryCondition AddSmaller(string fieldName, string value)
        {
            _conditions.Add(new Condition(fieldName, value, QueryOperator.Smaller));
            return this;
        }

        /// <summary>
        /// 新增一个小于条件，多表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">等于值</param>
        /// <returns></returns>
        public QueryCondition AddSmaller(string tableName, string fieldName, string value)
        {
            _conditions.Add(new Condition(tableName + "." + fieldName, value, QueryOperator.Smaller));
            return this;
        }

        /// <summary>
        /// 新增一个大于等于条件，单表
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">等于值</param>
        /// <returns></returns>
        public QueryCondition AddEqualLarger(string fieldName, string value)
        {
            _conditions.Add(new Condition(fieldName, value, QueryOperator.EqualLarger));
            return this;
        }

        /// <summary>
        /// 新增一个大于等于条件，多表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">等于值</param>
        /// <returns></returns>
        public QueryCondition AddEqualLarger(string tableName, string fieldName, string value)
        {
            _conditions.Add(new Condition(tableName + "." + fieldName, value, QueryOperator.EqualLarger));
            return this;
        }

        /// <summary>
        /// 新增一个小于等于条件，单表
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">等于值</param>
        /// <returns></returns>
        public QueryCondition AddEqualSmaller(string fieldName, string value)
        {
            _conditions.Add(new Condition(fieldName, value, QueryOperator.EqualSmaller));
            return this;
        }

        /// <summary>
        /// 新增一个小于等于条件，多表
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">等于值</param>
        /// <returns></returns>
        public QueryCondition AddEqualSmaller(string tableName, string fieldName, string value)
        {
            _conditions.Add(new Condition(tableName + "." + fieldName, value, QueryOperator.EqualSmaller));
            return this;
        }

        /// <summary>
        /// 新增Like查询条件
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public QueryCondition AddLike(string fieldName, string value)
        {
            _conditions.Add(new Condition(fieldName, value, QueryOperator.Like));
            return this;
        }

        /// <summary>
        /// 新增In查询条件
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns></returns>
        public QueryCondition AddIn(string fieldName, string value)
        {
            _conditions.Add(new Condition(fieldName, value, QueryOperator.In));
            return this;
        }

        /// <summary>
        /// 新增OR查询条件
        /// </summary>
        /// <param name="or">OrCondition</param>
        /// <returns></returns>
        public QueryCondition AddOr(OrCondition or)
        {
            _orConditions.Add(or);
            return this;
        }
        #endregion

        #region 排序
        /// <summary>
        /// 新增排序规则，单表
        /// </summary>
        /// <param name="fieldName">排序字段名称</param>
        /// <param name="asc">是否是ASC</param>
        /// <returns></returns>
        public QueryCondition AddOrderBy(string fieldName, bool asc)
        {
            _orderBys.Add(new KeyValuePair<string, bool>(fieldName, asc));
            return this;
        }

        /// <summary>
        /// 新增排序规则，多表
        /// </summary>
        /// <param name="tableName">表名，用于JOIN时排序</param>
        /// <param name="fieldName">排序字段名称</param>
        /// <param name="asc">是否是ASC</param>
        /// <returns></returns>
        public QueryCondition AddOrderBy(string tableName, string fieldName, bool asc)
        {
            _orderBys.Add(new KeyValuePair<string, bool>(tableName.ToLower() + "." + fieldName, asc));
            return this;
        }
        #endregion

        #region 分页
        public QueryCondition SetPager(int currentPage, int pageSize)
        {
            _po = new PagerOptions(currentPage, pageSize);
            return this;
        }

        public PagerOptions GetPager()
        {
            return _po;
        }
        #endregion

        #region 基本信息
        /// <summary>
        /// 设置单表查询字段
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <returns></returns>
        public QueryCondition AddSelectFields(string fieldName)
        {
            SelectFields.Add(fieldName);
            return this;
        }

        /// <summary>
        /// 设置多表查询字段
        /// </summary>
        /// <param name="tableName">表格名称</param>
        /// <param name="fieldName">字段名称</param>
        /// <returns></returns>
        public QueryCondition AddSelectFields(string tableName, string fieldName)
        {
            SelectFields.Add(tableName + "." + fieldName);
            return this;
        }

        /// <summary>
        /// 只获取条数
        /// </summary>
        /// <returns></returns>
        public QueryCondition JustGetCount()
        {
            _getCount = true;
            return this;
        }
        #endregion

        #region 解析
        public string ParseSql(string table, string pk, out SqlParameter[] parms)
        {
            int totalParms = 0;
            if (_conditions != null) totalParms += _conditions.Count(t => t.Op != QueryOperator.In);
            //条件数即参数个数
            foreach (var orc in _orConditions)
            {
                totalParms += orc.Conditions.Count(t => t.Op != QueryOperator.In);
            }
            parms = new SqlParameter[totalParms];

            #region 验证条件
            if (string.IsNullOrEmpty(table))
            {
                throw new ApplicationException("必须设置查询的表名！");
            }
            if (SelectFields.Count == 0)
                SelectFields.Add("*");
            #endregion

            var sb = new StringBuilder();
            if (_po == null)
            {
                sb.Append("SELECT ");
                if (_getCount)
                    sb.Append("COUNT(*)");
                else
                {
                    var fields = GetSelectFields();
                    sb.Append(fields);
                }
                sb.Append(" FROM ").Append(table).Append(" WITH(NOLOCK) WHERE 1=1 ");

                sb.Append(GetWhere(parms));

                #region 排序)
                if (!_getCount)
                {
                    if (_orderBys.Count > 0)
                    {
                        int i = 0;
                        sb.Append(" ORDER BY ");
                        foreach (KeyValuePair<string, bool> order in _orderBys)
                        {
                            if (i > 0)
                            {
                                sb.Append(",");
                            }
                            sb.Append(order.Key).Append(" ").Append(order.Value ? "ASC" : "DESC");
                            i++;
                        }
                    }
                }
                #endregion
            }
            else
            {
                sb.AppendFormat("select count({0}) from {1} WITH(NOLOCK) where 1=1", pk, table);
                sb.Append(GetWhere(parms) + ";");

                sb.AppendFormat("SELECT TOP ({0}) {1}", _po.PageSize, GetSelectFields().ToLower());
                sb.AppendFormat(@" FROM (SELECT {0},row_number() OVER", GetSelectFields());
                #region 排序

                if (!_getCount && _orderBys.Count > 0)
                {
                    var i = 0;
                    sb.Append(" (ORDER BY ");
                    foreach (var order in _orderBys)
                    {
                        if (i > 0)
                        {
                            sb.Append(",");
                        }
                        sb.Append(order.Key).Append(" ").Append(order.Value ? "ASC" : "DESC");
                        i++;
                    }
                    sb.Append(")");
                }
                else
                {
                    sb.AppendFormat(@"( ORDER BY {0} DESC )", pk);
                }

                #endregion

                sb.AppendFormat(@" AS row_number FROM  {0} WITH(NOLOCK) WHERE  1 = 1", table);
                sb.Append(GetWhere(parms));
                sb.AppendFormat(@") AS query WHERE  row_number > {0} ORDER BY row_number", (_po.CurrentPage - 1) * _po.PageSize);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 转为为Where条件
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        private string GetWhere(SqlParameter[] parms)
        {
            StringBuilder sb = new StringBuilder();
            #region 普通条件
            var current = 0;
            foreach (var c in _conditions)
            {
                if (c.Op == QueryOperator.In)
                {
                    sb.Append(" AND ").Append(c.FieldName).AppendFormat(" IN ({0})", c.Value);
                    continue;
                }
                if (c.Op == QueryOperator.Like)
                {
                    sb.Append(" AND ").Append(c.FieldName).Append(" LIKE '%'+@PARM" + current + "+'%'");
                }
                else
                {
                    sb.Append(" AND ").Append(c.FieldName).Append(QueryOperatorManager.GetOperator(c.Op) + "@PARM").
                        Append(current);
                }
                var parm = new SqlParameter("@PARM" + current, c.Value);
                parms[current] = parm;
                current++;
            }
            #endregion
            #region 或条件
            var orCount = 0;
            if (_orConditions.Count > 0)
            {
                sb.Append(" AND (");
                foreach (var orc in _orConditions)
                {
                    if (orc.Conditions.Count > 0)
                    {
                        foreach (var c in orc.Conditions)
                        {
                            if (orCount > 0)
                            {
                                sb.Append(" OR ");
                            }
                            if (c.Op == QueryOperator.In)
                            {
                                sb.Append(c.FieldName).AppendFormat(" IN ({0})", c.Value);
                                continue;
                            }
                            if (c.Op == QueryOperator.Like)
                            {
                                sb.Append(c.FieldName).Append(" LIKE '%'+@PARM" + current + "+'%'");
                            }
                            else
                            {
                                sb.Append(c.FieldName).Append(QueryOperatorManager.GetOperator(c.Op) + "@PARM").Append(
                                    current);
                            }
                            orCount++;
                            var parm = new SqlParameter("@PARM" + current, c.Value);
                            parms[current] = parm;
                            current++;
                        }
                    }
                }
                sb.Append(")");
            }
            #endregion
            return sb.ToString();
        }


        /// <summary>
        /// 将QueryCondition转换成Where SQL Script
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="pk">主键字段</param>
        /// <param name="parms">参数列表</param>
        /// <param name="isAddOrder">是否要排序</param>
        /// <returns></returns>
        public string ParseWhereSql(string table, string pk, out SqlParameter[] parms, bool isAddOrder = true)
        {
            int totalParms = 0;
            totalParms += _conditions.Count;
            //条件数即参数个数
            foreach (OrCondition orc in _orConditions)
            {
                totalParms += orc.Conditions.Count;
            }
            parms = new SqlParameter[totalParms];

            #region 验证条件

            if (string.IsNullOrEmpty(table))
            {
                throw new ApplicationException("必须设置查询的表名！");
            }

            #endregion

            StringBuilder sb = new StringBuilder();
            #region 普通条件

            int current = 0;
            foreach (Condition c in _conditions)
            {
                if (c.Op == QueryOperator.In)
                {
                    sb.Append(" AND ").Append(c.FieldName).AppendFormat(" IN ({0})", c.Value);
                    continue;
                }
                if (c.Op == QueryOperator.Like)
                {
                    sb.Append(" AND ").Append(c.FieldName).Append(" LIKE '%'+@PARM" + current + "+'%'");
                }
                else
                {
                    sb.Append(" AND ").Append(c.FieldName).Append(QueryOperatorManager.GetOperator(c.Op) + "@PARM").
                        Append(current);
                }
                SqlParameter parm = new SqlParameter("@PARM" + current, c.Value);
                parms[current] = parm;
                current++;
            }

            #endregion

            #region 或条件

            int orCount = 0;
            if (_orConditions.Count > 0)
            {

                sb.Append(" AND (");
                foreach (OrCondition orc in _orConditions)
                {
                    if (orc.Conditions.Count > 0)
                    {

                        foreach (Condition c in orc.Conditions)
                        {
                            if (orCount > 0)
                            {
                                sb.Append(" OR ");
                            }
                            if (c.Op == QueryOperator.In)
                            {
                                sb.Append(c.FieldName).AppendFormat(" IN ({0})", c.Value);
                                continue;
                            }
                            if (c.Op == QueryOperator.Like)
                            {
                                sb.Append(c.FieldName).Append(" LIKE '%'+@PARM" + current + "+'%'");
                            }
                            else
                            {
                                sb.Append(c.FieldName).Append(QueryOperatorManager.GetOperator(c.Op) + "@PARM").Append(
                                    current);
                            }
                            orCount++;
                            SqlParameter parm = new SqlParameter("@PARM" + current, c.Value);
                            parms[current] = parm;
                            current++;
                        }

                    }
                }
                sb.Append(")");
            }

            #endregion

            #region 排序
            if (!_getCount)
            {
                if (_orderBys.Count > 0 && isAddOrder)
                {
                    int i = 0;
                    sb.Append(" ORDER BY ");
                    foreach (KeyValuePair<string, bool> order in _orderBys)
                    {
                        if (i > 0)
                        {
                            sb.Append(",");
                        }
                        sb.Append(order.Key).Append(" ").Append(order.Value ? "ASC" : "DESC");
                        i++;
                    }
                }
            }
            #endregion
            return sb.ToString();
        }

        private string ParseJoinSql(out SqlParameter[] parms)
        {
            int totalParms = 0;
            totalParms += _conditions.Count;
            //条件数即参数个数
            foreach (OrCondition orc in _orConditions)
            {
                totalParms += orc.Conditions.Count;
            }
            parms = new SqlParameter[totalParms];

            #region 验证条件
            if (string.IsNullOrEmpty(_joinMaster))
                throw new ApplicationException("多表查询请通过SetJoinMaster(table)设置联查主表的表名！");
            if (_joinTables.Count == 0)
                throw new ApplicationException("多表查询请通过AddJoinTable(table,JoinOnCondition)设置需要联查的表名！");
            if (SelectFields.Count == 0)
                throw new ApplicationException("多表查询请通过AddSelectFields(table,field)方法设置需要查询的字段名！");
            #endregion

            StringBuilder sb = new StringBuilder();
            if (_po == null)
            {
                sb.Append("SELECT ");
                if (_getCount)
                    sb.Append("COUNT(*)");
                else
                {
                    string fields = GetSelectFields();
                    sb.Append(fields);
                }
                sb.Append(" FROM " + _joinMaster + " " + _joinMaster.ToLower());
                foreach (KeyValuePair<string, JoinOnCondition> kvp in _joinTables)
                {
                    sb.Append(" " + TableJoinModeManager.GetJoinMode(kvp.Value.Mode) + " " + kvp.Key + " " + kvp.Key.ToLower());
                    sb.Append(" on");
                    sb.Append(" " + kvp.Value.Table1.ToLower() + "." + kvp.Value.Table1Field + "=" + kvp.Value.Table2.ToLower() + "." + kvp.Value.Table2Field);
                }

                sb.Append(" WHERE 1=1 ");
            }
            else
            {
                if (string.IsNullOrEmpty(_joinMasterPk))
                {
                    throw new ApplicationException("分页查询请通过SetJoinMasterPK(pk)方法设置主表的主键！");
                }
                sb.Append("DECLARE @indextable table(TCWANGQIANIndexTableId int identity(1,1) PRIMARY KEY,TCWANGQIANIndexTableNid int);");
                sb.AppendFormat("INSERT INTO @indextable(TCWANGQIANIndexTableNid) SELECT {0} FROM {1} WITH(nolock) WHERE 1=1", _joinMasterPk, _joinMaster);
            }

            #region 普通条件
            int current = 0;
            foreach (Condition c in _conditions)
            {
                if (c.Op == QueryOperator.In)
                {
                    sb.Append(" AND ").Append(c.FieldName).AppendFormat(" IN ({0})", c.Value);
                    continue;
                }
                if (c.Op == QueryOperator.Like)
                {
                    sb.Append(" AND ").Append(c.FieldName).Append(" LIKE '%'+@PARM" + current + "+'%'");
                }
                else
                {
                    sb.Append(" AND ").Append(c.FieldName).Append(QueryOperatorManager.GetOperator(c.Op) + "@PARM").Append(current);
                }
                SqlParameter parm = new SqlParameter("@PARM" + current, c.Value);
                parms[current] = parm;
                current++;
            }
            #endregion

            #region 或条件
            foreach (OrCondition orc in _orConditions)
            {
                if (orc.Conditions.Count > 0)
                {
                    sb.Append(" AND (");
                    int i = 0;
                    foreach (Condition c in orc.Conditions)
                    {
                        if (i > 0)
                        {
                            sb.Append(" OR ");
                        }
                        if (c.Op == QueryOperator.In)
                        {
                            sb.Append(c.FieldName).AppendFormat(" IN ({0})", c.Value);
                            continue;
                        }
                        if (c.Op == QueryOperator.Like)
                        {
                            sb.Append(c.FieldName).Append(" LIKE '%'+@PARM" + current + "+'%'");
                        }
                        else
                        {
                            sb.Append(c.FieldName).Append(QueryOperatorManager.GetOperator(c.Op) + "@PARM").Append(current);
                        }
                        i++;
                        SqlParameter parm = new SqlParameter("@PARM" + current, c.Value);
                        parms[current] = parm;
                        current++;
                    }
                    sb.Append(")");
                }
            }
            #endregion

            #region 排序
            if (!_getCount)
            {
                if (_orderBys.Count > 0)
                {
                    int i = 0;
                    sb.Append(" ORDER BY ");
                    foreach (KeyValuePair<string, bool> order in _orderBys)
                    {
                        if (i > 0)
                        {
                            sb.Append(",");
                        }
                        sb.Append(order.Key).Append(" ").Append(order.Value ? "ASC" : "DESC");
                        i++;
                    }
                }
            }
            #endregion

            if (_po != null)
            {
                sb.Append(";SELECT recrowcount=@@ROWCOUNT;");
                sb.AppendFormat("SELECT {0} FROM @indextable as t0 JOIN {1} AS t1 WITH (nolock) ON (t0.TCWANGQIANIndexTableNid = t1.{2} AND t0.TCWANGQIANIndexTableId > {3} AND t0.TCWANGQIANIndexTableId <= {4})", GetSelectFields().ToLower().Replace(_joinMaster.ToLower() + ".", "t1."), _joinMaster, _joinMasterPk, (_po.CurrentPage - 1) * _po.PageSize, _po.CurrentPage * _po.PageSize);
            }

            return sb.ToString();
        }

        private string GetSelectFields()
        {
            string fields = string.Empty;
            foreach (string f in SelectFields)
            {
                fields += f + ",";
            }
            fields = fields.TrimEnd(',');
            if (string.IsNullOrEmpty(fields))
                fields = "*";
            return fields;
        }
        #endregion

        #region 连表查询
        /// <summary>
        /// 设置join查询时的主表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public QueryCondition SetJoinMaster(string tableName)
        {
            _joinMaster = tableName;
            return this;
        }

        /// <summary>
        /// 新增一个JOIN的表格
        /// </summary>
        /// <param name="tableName">表格名称</param>
        /// <param name="md">JOIN方式，见枚举：JoinOnCondition</param>
        /// <returns></returns>
        public QueryCondition AddJoinTable(string tableName, JoinOnCondition md)
        {
            _joinTables.Add(new KeyValuePair<string, JoinOnCondition>(tableName, md));
            return this;
        }

        /// <summary>
        /// 设置主表的主键，分页时设置
        /// </summary>
        /// <param name="pk">主键名称</param>
        /// <returns></returns>
        public QueryCondition SetJoinMasterPK(string pk)
        {
            _joinMasterPk = pk;
            return this;
        }

        #endregion


        public DataSet Query()
        {
            SqlParameter[] parms;
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, ParseJoinSql(out parms), parms);
        }
    }

    #region 查询条件
    public class Condition
    {
        public string FieldName { get; set; }
        public string Value { get; set; }
        public QueryOperator Op { get; set; }

        public Condition(string fieldName, string value, QueryOperator op)
        {
            FieldName = fieldName;
            Value = value;
            Op = op;
        }
    }
    #endregion

    #region 或查询
    public class OrCondition
    {
        public IList<Condition> Conditions;

        private OrCondition()
        {
            Conditions = new List<Condition>();
        }

        public static OrCondition Instance
        {
            get
            {
                return new OrCondition();
            }
        }

        public OrCondition AddEqual(string fieldName, string value)
        {
            Conditions.Add(new Condition(fieldName, value, QueryOperator.Equal));
            return this;
        }

        public OrCondition AddNotEqual(string fieldName, string value)
        {
            Conditions.Add(new Condition(fieldName, value, QueryOperator.NotEqual));
            return this;
        }

        public OrCondition AddLarger(string fieldName, string value)
        {
            Conditions.Add(new Condition(fieldName, value, QueryOperator.Larger));
            return this;
        }

        public OrCondition AddSmaller(string fieldName, string value)
        {
            Conditions.Add(new Condition(fieldName, value, QueryOperator.Smaller));
            return this;
        }

        public OrCondition AddEqualLarger(string fieldName, string value)
        {
            Conditions.Add(new Condition(fieldName, value, QueryOperator.EqualLarger));
            return this;
        }

        public OrCondition AddEqualSmaller(string fieldName, string value)
        {
            Conditions.Add(new Condition(fieldName, value, QueryOperator.EqualSmaller));
            return this;
        }

        public OrCondition AddLike(string fieldName, string value)
        {
            Conditions.Add(new Condition(fieldName, value, QueryOperator.Like));
            return this;
        }

        /// <summary>
        /// 新增In查询条件
        /// </summary>
        /// <param name="fieldName">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns></returns>
        public OrCondition AddIn(string fieldName, string value)
        {
            Conditions.Add(new Condition(fieldName, value, QueryOperator.In));
            return this;
        }
    }
    #endregion

    #region JoinOnCondition
    public class JoinOnCondition
    {
        public string Table1 { get; set; }

        public string Table2 { get; set; }

        public string Table1Field { get; set; }

        public string Table2Field { get; set; }

        public TableJoinMode Mode { get; set; }

        public JoinOnCondition(string table1, string table2, string table1Field, string table2Field, TableJoinMode mode)
        {
            Table1 = table1;
            Table1Field = table1Field;
            Table2 = table2;
            Table2Field = table2Field;
            Mode = mode;
        }
    }
    #endregion

    #region 分页设置类
    public class PagerOptions
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public PagerOptions(int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
    }
    #endregion

    #region 操作符
    /// <summary>
    /// 查询操作符枚举
    /// </summary>
    public enum QueryOperator
    {
        Equal,
        Larger,
        Smaller,
        EqualLarger,
        EqualSmaller,
        NotEqual,
        Like,
        In
    }

    public class QueryOperatorManager
    {
        public static string GetOperator(QueryOperator op)
        {
            if (op == QueryOperator.EqualLarger)
                return ">=";
            if (op == QueryOperator.Equal)
                return "=";
            if (op == QueryOperator.EqualSmaller)
                return "<=";
            if (op == QueryOperator.Smaller)
                return "<";
            if (op == QueryOperator.NotEqual)
                return "!=";
            if (op == QueryOperator.Larger)
                return ">";
            if (op == QueryOperator.Like)
                return "like";
            return string.Empty;
        }
    }
    #endregion

    #region 连表查询方式
    public enum TableJoinMode
    {
        InnerJoin,
        OuterJoin,
        LeftJoin,
        RightJoin,
        Join
    }

    public class TableJoinModeManager
    {
        /// <summary>
        /// 获取JOIN的sql表达式
        /// </summary>
        /// <param name="md"></param>
        /// <returns></returns>
        public static string GetJoinMode(TableJoinMode md)
        {
            if (md == TableJoinMode.InnerJoin)
                return "inner join";
            if (md == TableJoinMode.LeftJoin)
                return "left join";
            if (md == TableJoinMode.OuterJoin)
                return "outer join";
            if (md == TableJoinMode.RightJoin)
                return "right join";
            if (md == TableJoinMode.Join)
                return "join";
            return "join";
        }
    }
    #endregion

    /// <summary>
    /// 分页类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Page<T>
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public long CurrentPage { get; set; }
        /// <summary>
        /// 总分页数
        /// </summary>
        public long TotalPages { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public long TotalRecords { get; set; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public long PageSize { get; set; }
        /// <summary>
        /// 记录集
        /// </summary>
        public IList<T> Items { get; set; }
    }

    /// <summary>
    /// 分页类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageObject<T>
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public long CurrentPage { get; set; }
        /// <summary>
        /// 总分页数
        /// </summary>
        public long TotalPages { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public long TotalRecords { get; set; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public long PageSize { get; set; }
        /// <summary>
        /// 记录集
        /// </summary>
        public T Items { get; set; }
    }

    public class Page<T, TU>
    {
        public T Model { get; set; }

        /// <summary>
        /// 记录集
        /// </summary>
        public Page<TU> ItemList { get; set; }
    }


    /// <summary>
    /// 分页类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageJqDatagrid<T>
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 总分页数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int records { get; set; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public long PageSize { get; set; }
        /// <summary>
        /// 查询花费时长
        /// </summary>
        public string costtime { get; set; }

        /// <summary>
        /// 记录集
        /// </summary>
        public object rows { get; set; }
    }

    /// <summary>
    /// 分页类型
    /// </summary>
    public class PageStringDatagrid
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 总分页数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int records { get; set; }

        /// <summary>
        /// 查询花费时长
        /// </summary>
        public string costtime { get; set; }

        /// <summary>
        /// 记录集
        /// </summary>
        public string rows { get; set; }
    }

    /// <summary>
    /// Jquery Grid分页实体类
    /// </summary>
    public class JqDataGrid<T>
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 总分页数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int records { get; set; }
        /// <summary>
        /// 查询花费时长
        /// </summary>
        public string costtime { get; set; }
        /// <summary>
        /// 记录集
        /// </summary>
        public IList<T> rows { get; set; }
    }
}
