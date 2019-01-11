using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Base
{
    public class StatusModel
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// 返回描述
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Content { get; set; }
    }

    public class ResultModel
    {
        /// <summary>
        /// 请求参数
        /// </summary>
        public string request_id { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public RsModel response { get; set; }
    }

    public class RsModel
    {
        /// <summary>
        /// 返回总数
        /// </summary>
        public int totalCount { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object result { get; set; }
    }
}
