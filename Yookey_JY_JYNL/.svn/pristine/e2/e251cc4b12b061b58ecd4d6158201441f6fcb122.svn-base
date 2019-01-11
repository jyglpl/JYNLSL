using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Exam;
using Yookey.WisdomClassed.SIP.Model.Exam;

namespace Yookey.WisdomClassed.SIP.Business.Exam
{
    public class ExamQuestionsBll
    {
        private readonly ExamQuestionsDal _examQuestionsDal = new ExamQuestionsDal();

        /// <summary>
        /// 获取选中的题库类型
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<ExamQuestionsEntity> GetResultSearch(ExamQuestionsEntity search)
        {
            return _examQuestionsDal.GetResultSearch(search);
        }

        /// <summary>
        /// 删除选中的题库类型
        /// </summary>
        /// <param name="Tid"></param>
        /// <returns></returns>
        public bool DeleteEexamQuestions(string Tid)
        {
            return _examQuestionsDal.DeleteEexamQuestions(Tid);
        }

        /// <summary>
        /// 新增选中的题库类型
        /// </summary>
        /// <param name="Tid"></param>
        /// <param name="Sid"></param>
        /// <returns></returns>
        public bool InsertEexamQuestions(string Tid, string Sid)
        {
            return _examQuestionsDal.InsertEexamQuestions(Tid, Sid);
        }
    }
}
