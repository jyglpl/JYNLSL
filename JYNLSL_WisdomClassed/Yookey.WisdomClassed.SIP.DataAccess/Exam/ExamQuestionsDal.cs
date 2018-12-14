using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Exam;

namespace Yookey.WisdomClassed.SIP.DataAccess.Exam
{
    public class ExamQuestionsDal : BaseDal<ExamQuestionsEntity>
    {
        /// <summary>
        /// 获取选中的题库类型
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<ExamQuestionsEntity> GetResultSearch(ExamQuestionsEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM ExamQuestions Where 1 = 1");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.Tid))
            {
                strSql.AppendFormat(@" AND Tid='{0}'", search.Tid);
            }
            if (!string.IsNullOrEmpty(search.Sid))
            {
                strSql.AppendFormat(@" AND Sid='{0}'", search.Sid);
            }
            return WriteDatabase.Query<ExamQuestionsEntity>(strSql.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 删除选中的题库类型
        /// </summary>
        /// <param name="Tid"></param>
        /// <returns></returns>
        public bool DeleteEexamQuestions(string Tid)
        {
            var strSql = string.Format(@"DELETE FROM ExamQuestions WHERE Tid = '{0}'", Tid);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 新增选中的题库类型
        /// </summary>
        /// <param name="Tid"></param>
        /// <param name="Sid"></param>
        /// <returns></returns>
        public bool InsertEexamQuestions(string Tid, string Sid)
        {
            var strSql = string.Format(@"INSERT INTO ExamQuestions (Id,Tid,Sid) VALUES ('{0}' ,'{1}' ,'{2}')", Guid.NewGuid().ToString(), Tid, Sid);
            return WriteDatabase.Execute(strSql) > 0;
        }
    }
}
