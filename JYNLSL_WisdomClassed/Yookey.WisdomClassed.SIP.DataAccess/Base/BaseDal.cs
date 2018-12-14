using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using PetaPoco;
using System.Data;

namespace Yookey.WisdomClassed.SIP.DataAccess.Base
{
    /// <summary>
    /// 持久层基类
    /// </summary>
    /// <typeparam name="T">
    /// 实体类型
    /// </typeparam>
    public class BaseDal<T> : IDal<T> where T : new()
    {
        //public DateTime MinDate = Convert.ToDateTime("1900-01-01");
        //public string ProjectName = ConfigurationManager.AppSettings["ProjectName"] ?? string.Empty;
        public BaseDal()
        {
            //平台读库
            ReadDatabase = new Database("SQLConnStringRead");

            //平台写库
            WriteDatabase = new Database("SQLConnStringWrite");
        }

        /// <summary>
        /// 写数据库
        /// </summary>
        public Database WriteDatabase { get; set; }

        /// <summary>
        /// 读数据库
        /// </summary>
        public Database ReadDatabase { get; set; }


        /// <summary>
        /// 用主键查找相关的实体
        /// </summary>
        /// <param name="key">主健值</param>
        /// <returns>返回的实体,没有则抛出异常</returns>
        public T Single(object key)
        {
            WriteDatabase.Comment = new StringExtension.SqlComment()
            {
                Author = String.Format("系统项目组-{0}", ""),
                FileName = @"Persistance\Base\BasePersistance.cs",
                ForUse = "用主键查找相关的实体",
                FunName = "Single"
            };
            return ReadDatabase.Single<T>(key);
        }

        /// <summary>
        /// 用主键查找相关的实体
        /// </summary>
        /// <param name="key">主健值</param>
        /// <returns>返回的实体,没有则返回一个默认值</returns>
        public T SingleOrDefault(object key)
        {
            WriteDatabase.Comment = new StringExtension.SqlComment()
            {
                Author = String.Format("系统项目组-{0}", ""),
                FileName = @"Persistance\Base\BasePersistance.cs",
                ForUse = "用主键查找相关的实体",
                FunName = "SingleOrDefault"
            };
            return ReadDatabase.SingleOrDefault<T>(key);
        }

        /// <summary>
        /// 更新实体
        /// Add BY lxy on 2013-01-08
        /// </summary>
        /// <param name="item">实体</param>
        /// <returns></returns>
        public bool PersistUpdatedItem(T item)
        {
            WriteDatabase.Comment = new StringExtension.SqlComment
            {
                Author = String.Format("系统项目组-{0}", ""),
                FileName = @"Persistance\Base\BasePersistance.cs",
                ForUse = "更新实体加版本控制",
                FunName = "PersistUpdatedItem"
            };
            return WriteDatabase.Update(item) > 0;
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="key">实体</param>
        /// <returns>成功为true,错误为false</returns>
        public bool PersistDeletedItem(object key)
        {
            WriteDatabase.Comment = new StringExtension.SqlComment()
            {
                Author = String.Format("系统项目组-{0}", ""),
                FileName = @"Persistance\Base\BasePersistance.cs",
                ForUse = "删除实体",
                FunName = "PersistDeletedItem"
            };
            return WriteDatabase.Delete<T>(key) > 0;
        }

        /// <summary>
        /// 新建实体
        /// </summary>
        /// <param name="item">
        /// 实体
        /// </param>
        /// <returns>
        /// 数据库中记录ID
        ///  </returns>
        public bool PersistNewItem(T item)
        {
            WriteDatabase.Comment = new StringExtension.SqlComment()
            {
                Author = String.Format("系统项目组-{0}", ""),
                FileName = @"Persistance\Base\BasePersistance.cs",
                ForUse = "新建实体",
                FunName = "PersistNewItem"
            };
            return !string.IsNullOrEmpty(WriteDatabase.Insert(item).ToString());
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="page">当前页索引</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="sql">SQL Script</param>
        /// <param name="isPage">是否分页(false:不分页，查询全部 ，true:分页)</param>
        /// <param name="args">参数列表</param>
        /// <returns></returns>
        public Page<T> Page(long page, long pageSize, string sql = null, List<object> args = null, bool isPage = true)
        {
            WriteDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "BASEDAL",
                FileName = "BaseDal.cs",
                ForUse = "分页查询",
                FunName = "Page"
            };
            if (!isPage)
            {
                IEnumerable<T> result;
                if (args == null || args.Count.Equals(0))
                {
                    result = WriteDatabase.Query<T>(sql);
                }
                else
                {
                    result = WriteDatabase.Query<T>(sql, args.ToArray());
                }
                return new Page<T> { Items = result.ToList(), CurrentPage = page, ItemsPerPage = pageSize };
            }
            return ReadDatabase.Page<T>(page, pageSize, sql, (args ?? new List<object>()).ToArray());
        }


        /// <summary>
        /// 开始事务
        /// </summary>
        public void BeginTransaction()
        {
            WriteDatabase.BeginTransaction();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
            WriteDatabase.CompleteTransaction();
        }

        /// <summary>
        /// 结束事务
        /// </summary>
        public void AbortTransaction()
        {
            WriteDatabase.AbortTransaction();
        }

    }
}