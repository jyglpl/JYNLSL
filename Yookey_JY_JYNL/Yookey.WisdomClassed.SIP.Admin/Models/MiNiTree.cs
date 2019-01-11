using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yookey.WisdomClassed.SIP.Admin.Models
{
    /// <summary>
    /// 树结构封装类
    /// MiNi接口规范
    /// add by lpl
    /// 2019-1-8
    /// </summary>
    public class MiniTree
    {
        private string Id;
        private string parentId;
        private string Text ;
        private object Children;




        public string id { get => Id; set => Id = value; }
        public string text { get => Text; set => Text = value; }
        public object children { get => Children; set => Children = value; }
        public string ParentId { get => parentId; set => parentId = value; }
    }
}