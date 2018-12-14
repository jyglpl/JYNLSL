using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Exam;
using Yookey.WisdomClassed.SIP.Model.Exam;

namespace Yookey.WisdomClassed.SIP.Business.Exam
{
    public class QuetionTypeBll
    {
        private readonly QuetionTypeDal _quetionTypeDal = new QuetionTypeDal();

        /// <summary>
        /// 获取试题题库
        /// </summary>
        /// <returns></returns>
        public List<QuetionTypeEntity> GetQuestionTypeList()
        {
            return _quetionTypeDal.GetQuestionTypeList();
        }
    }
}
