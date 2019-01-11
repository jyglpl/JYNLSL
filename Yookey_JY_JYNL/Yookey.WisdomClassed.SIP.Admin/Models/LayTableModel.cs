using System.Collections.Generic;

namespace Yookey.WisdomClassed.SIP.Admin.Models
{
    /// <summary>
    /// 返回数据状态
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LayTableModel<T>
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 返回描述
        /// </summary>
        public string msg { get; set; }

        public int count { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public List<T> data { get; set; }


    }

}