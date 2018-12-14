using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Exam;
using Yookey.WisdomClassed.SIP.Model.Exam;

namespace Yookey.WisdomClassed.SIP.Business.Exam
{
    public class ExamThemeBll
    {
        private readonly ExamThemeDal _examThemeDal = new ExamThemeDal();

        /// <summary>
        /// 获取题库集合
        /// </summary>
        /// <returns></returns>
        public List<ExamThemeEntity> GetExamThemeList(ExamThemeEntity search)
        {
            return _examThemeDal.GetExamThemeList(search);
        }

        /// <summary>
        /// 获取试题信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public Page<ExamThemeEntity> GetQuestionInfo(string keywords, int pageSize = 30, int pageIndex = 1)
        {
            return _examThemeDal.GetQuestionInfo(keywords, pageSize, pageIndex);
        }

        /// <summary>
        /// 获取已考题库集合
        /// </summary>
        /// <returns></returns>
        public List<ExamThemeEntity> GetExamThemeList(ExamThemeEntity search,string Oid)
        {
            return _examThemeDal.GetExamThemeList(search, Oid);
        }

        /// <summary>
        /// 新增题库
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool InsertExamTheme(ExamThemeEntity search)
        {
            return _examThemeDal.InsertExamTheme(search);
        }

        /// <summary>
        /// 更新题库
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool UpdateExamTheme(ExamThemeEntity search)
        {
            return _examThemeDal.UpdateExamTheme(search);
        }

        /// <summary>
        /// 删除题库
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteExamTheme(string Id)
        {
            return _examThemeDal.DeleteExamTheme(Id);
        }
    }
}
