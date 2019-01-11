using System.Collections.Generic;

namespace Yookey.WisdomClassed.SIP.Admin.Models
{
    /// <summary>
    /// 返回数据状态
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StatusModel<T>
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        public int rtState { get; set; }

        /// <summary>
        /// 返回描述
        /// </summary>
        public string rtMsrg { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public List<T> rtData { get; set; }

        public T rtObj { get; set; }
    }

    /// <summary>
    /// 桌面菜单
    /// </summary>
    public class DesktopMenuStatusModel
    {
        /// <summary>
        /// 返回状态
        /// </summary>
        public int rtState { get; set; }

        /// <summary>
        /// 返回描述
        /// </summary>
        public string rtMsrg { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public List<List<TreeMenuNode>> rtData { get; set; }
    }
}