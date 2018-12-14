using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Exam;

namespace Yookey.WisdomClassed.SIP.DataAccess.Exam
{
    public class QuetionTypeDal : BaseDal<QuetionTypeEntity>
    {
        /// <summary>
        /// 获取试题题库
        /// </summary>
        /// <returns></returns>
        public List<QuetionTypeEntity> GetQuestionTypeList()
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM QuetionDataType Where 1 = 1");
            var args = new List<object>();
            return WriteDatabase.Query<QuetionTypeEntity>(strSql.ToString(), args.ToArray()).ToList();
        }
    }
}
