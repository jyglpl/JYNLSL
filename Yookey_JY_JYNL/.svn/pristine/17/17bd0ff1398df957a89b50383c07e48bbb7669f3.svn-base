using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Exam;
using Yookey.WisdomClassed.SIP.Model.Exam;

namespace Yookey.WisdomClassed.SIP.Business.Exam
{
    public class QuetionTitleBll
    {
        private readonly QuetionTitleDal _quetionTitleDal = new QuetionTitleDal();

        /// <summary>
        /// 获取试题类型
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<QuetionTitleEntity> GetResultSearch(QuetionTitleEntity search)
        {
            return _quetionTitleDal.GetResultSearch(search);
        }

        /// <summary>
        /// 删除获取试题类型
        /// </summary>
        /// <param name="Tid"></param>
        /// <returns></returns>
        public bool DeleteQuetionTitleTheme(string TItemId)
        {
            return _quetionTitleDal.DeleteQuetionTitleTheme(TItemId);
        }

        /// <summary>
        /// 新增获取试题类型
        /// </summary>
        /// <param name="Tid"></param>
        /// <param name="Sid"></param>
        /// <returns></returns>
        public bool InsertQuetionTitleTheme(string QuestionId, string TItemId, string QuestionsType)
        {
            return _quetionTitleDal.InsertQuetionTitleTheme(QuestionId, TItemId, QuestionsType);
        }
    }
}
