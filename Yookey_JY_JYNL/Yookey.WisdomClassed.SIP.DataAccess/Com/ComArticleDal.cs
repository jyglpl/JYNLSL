using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.DataAccess.Com
{
    /// <summary>
    /// 【通用文章类】数据访问操作
    /// </summary>
    public class ComArticleDal : DalImp.BaseDal<ComArticleEntity>
    {
        public ComArticleDal()
        {
            Model = new ComArticleEntity();
        }
    }
}