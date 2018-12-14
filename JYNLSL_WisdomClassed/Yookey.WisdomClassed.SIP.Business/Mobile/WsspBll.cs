using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Mobile;

namespace Yookey.WisdomClassed.SIP.Business.Mobile
{
    public class WsspBll
    {
       
        /// <summary>
        /// 查询一条数据 
        /// 添加人：叶念
        /// 添加时间：2014-12-24
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns></returns>
        public object GetExecuStr(string sql)
        {
            return new WsspDal().GetExecuStr(sql);
        }
        /// <summary>
        /// 保存图片到数据库
        /// 添加人：叶念
        /// 添加时间：2014-12-24
        /// </summary>
        /// <param name="fielType">上传文件类别,简易案件：Simple ,违停：Car</param>
        /// <param name="fileExt">文件扩展名</param>
        /// <param name="ff">图片二进制</param>
        /// <returns></returns>
        public string WritePicture(string fielType, string fileExt, byte[] ff)
        {
            return new WsspDal().WritePicture(fielType, fileExt, ff);
        }
    }

}