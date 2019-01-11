namespace Yookey.WisdomClassed.SIP.Model.Base
{
    public class Page
    {
        /// <summary>
        /// 每页的记录数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页索引
        /// </summary>
        public int CurrentPage { get; set; }
    }

    public class YkPage
    {
        public PageData data { get; set; }

        public string errorMessage { get; set; }

        public bool success { get; set; }
    }

    public class PageData
    {
        public int totalRecordNumber { get; set; }

        public int totalPageNumber { get; set; }

        public pageable pageable { get; set; }

        public object content { get; set; }

        public object data { get; set; }

        public int draw { get; set; }

        public int recordsFiltered { get; set; }

        public int recordsTotal { get; set; }
    }

    public class pageable
    {
        public int pageNumber { get; set; }

        public int pageSize { get; set; }

        public string order { get; set; }
    }
}
