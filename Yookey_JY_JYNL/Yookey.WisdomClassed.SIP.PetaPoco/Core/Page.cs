// <copyright file="Page.cs" company="PetaPoco - CollaboratingPlatypus">
//      Apache License, Version 2.0 https://github.com/CollaboratingPlatypus/PetaPoco/blob/master/LICENSE.txt
// </copyright>
// <author>PetaPoco - CollaboratingPlatypus</author>
// <date>2015/12/05</date>

using System.Collections.Generic;
using System.Data;

namespace PetaPoco
{
    /// <summary>
    ///     Holds the results of a paged request.
    /// </summary>
    /// <typeparam name="T">The type of Poco in the returned result set</typeparam>
    public class Page<T>
    {
        /// <summary>
        ///     The current page number contained in this page of result set
        /// </summary>
        public long CurrentPage { get; set; }

        /// <summary>
        ///     The total number of pages in the full result set
        /// </summary>
        public long TotalPages { get; set; }

        /// <summary>
        ///     The total number of records in the full result set
        /// </summary>
        public long TotalItems { get; set; }

        /// <summary>
        ///     The number of items per page
        /// </summary>
        public long ItemsPerPage { get; set; }

        /// <summary>
        ///     The actual records on this page
        /// </summary>
        public List<T> Items { get; set; }

        /// <summary>
        ///     User property to hold anything.
        /// </summary>
        public DataTable Context { get; set; }
    }




    public class JqGridPage
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public long page { get; set; }
        /// <summary>
        /// 总分页数
        /// </summary>
        public long total { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public long records { get; set; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public long PageSize { get; set; }
        /// <summary>
        /// 记录集
        /// </summary>
        public object rows { get; set; }
        /// <summary>
        /// 查询花费时长
        /// </summary>
        public string costTime { get; set; }
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

}