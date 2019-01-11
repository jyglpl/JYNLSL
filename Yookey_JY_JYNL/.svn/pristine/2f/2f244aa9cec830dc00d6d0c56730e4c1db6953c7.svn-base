using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.TempDetain
{
    /// <summary>
    /// 暂扣信息实体
    /// 创建人：周庆
    /// 创建日期：2015年5月5日
    /// </summary>
    public class TempDetailEntity
    {
        /// <summary>
        /// 暂扣基本信息
        /// </summary>
        public TempDetainInfoEntity Info { get; set; }
        /// <summary>
        /// 暂扣物品信息
        /// </summary>
        public List<TempDetainGoodsEntity> LstGoods { get; set; }
        /// <summary>
        /// 暂扣附件信息
        /// </summary>
        public List<TempDetainAttachEntity> LstAttach { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public TempDetailEntity() {
            Info = new TempDetainInfoEntity();
            LstGoods = new List<TempDetainGoodsEntity>();
            LstAttach = new List<TempDetainAttachEntity>();
        }
       
    }
}
