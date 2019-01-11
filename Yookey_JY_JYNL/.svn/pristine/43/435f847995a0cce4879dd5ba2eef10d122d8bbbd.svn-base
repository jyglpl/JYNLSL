using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Mobile
{

    public class BasisBll
    {
        readonly RoadManagerBll _roadManagerBll = new RoadManagerBll();


        /// <summary>
        /// 请求路段信息
        /// 添加人：周 鹏
        /// 添加时间：2014-12-28
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-03-18 周 鹏 增加按部门编号查询
        /// </history>
        /// <param name="context">{deptId:部门编号}</param>
        /// <returns></returns>
        public DataTable GetRoad(string context)
        {
            context = Regex.Replace(context, @"[\{\}]", "");
            context += ",";
            var deptId = Regex.Match(context, @"(?<=""deptId""\:"").*?(?="",)").Value;   //用户编号
            return _roadManagerBll.GetRoad(deptId);
        }
    }
}
