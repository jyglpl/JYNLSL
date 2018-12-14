using System.Collections.Generic;

namespace Yookey.WisdomClassed.SIP.Admin.Models
{
    /// <summary>
    /// 系统单个菜单实体类
    /// </summary>
    public class TreeMenuNode
    {
        #region properties
        public string ModuleId { get; set; }
        public string FullName { get; set; }
        public string Icon { get; set; }
        public int Leaf { get; set; }
        public string Location { get; set; }
        public int OpenFlag { get; set; }
        /// <summary>
        /// 所属系统编号
        /// </summary>
        public string Systemid { get; set; } 
        /// <summary>
        /// 消息数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 菜单级别
        /// </summary>
        public int MenuLevel { get; set; }

        /// <summary>
        /// 父编号
        /// </summary>
        public string ParentId { get; set; }
        public IList<TreeMenuNode> Children { get; set; }
        #endregion
    }

    /// <summary>
    /// Ztree 实体类
    /// </summary>
    public class ZTreeNode
    {
        #region properties
        public string id { get; set; }
        public string pId { get; set; }
        public string name { get; set; }
        public bool open { get; set; }
        public string icon { get; set; }
        public string type { get; set; }
        public string openFlag { get; set; }
        #endregion  properties
    }


    public class TreeNode
    {
        public string id { get; set; }
        public string text { get; set; }
        public string value { get; set; }
        /// <summary>
        /// URL
        /// </summary>
        public string Location { get; set; }
        public string parentnodes { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string type { get; set; }
        public string img { get; set; }
        /// <summary>
        /// 是否显示多选
        /// </summary>
        public bool showcheck { get; set; }

        /// <summary>
        /// 选中状态 0：不选 1：全选 2：半选
        /// 创建人：周庆
        /// 创建日期：2015年5月15日
        /// </summary>
        public int checkstate { get; set; }
        /// <summary>
        /// 是否展开
        /// </summary>
        public bool isexpand { get; set; }
        public bool complete { get; set; }
        public bool hasChildren { get; set; }
        public List<TreeNode> ChildNodes { get; set; }
    }

    
    public class TreeCombox
    {
        public string id { set; get; }
        public string text { set; get; }
        public string state { get; set; }
        public List<TreeCombox> children { get; set; }
    }
}