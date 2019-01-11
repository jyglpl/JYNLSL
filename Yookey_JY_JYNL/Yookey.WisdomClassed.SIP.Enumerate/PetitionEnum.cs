using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Enumerate
{   
        /// <summary>
        /// 状态分类
        /// </summary>
        public enum PetitionStateType
        {
            /// <summary>
            /// 已登记
            /// </summary>
            [Description("已登记")]
            Registered = 0,

            /// <summary>
            /// 信访审批中
            /// </summary>
            [Description("审批中")]
            Application = 1,
            
            /// <summary>
            /// 信访已办结
            /// </summary>
            [Description("已办结")]
            Result = 3,

            // <summary>
            /// 全部
            /// </summary>
            [Description("全部")]
            All = 10
        }    
}
