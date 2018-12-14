using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Exam;
using Yookey.WisdomClassed.SIP.Model.Exam;

namespace Yookey.WisdomClassed.SIP.Business.Exam
{
    public class ExamTypeBll
    {
        private readonly ExamTypeDal _examInfoDal = new ExamTypeDal();

        /// <summary>
        /// 获取题库类型
        /// </summary>
        /// <returns></returns>
        public List<ExamTypeEntity> GetExamList(ExamTypeEntity search)
        {
            return _examInfoDal.GetExamList(search);
        }

        /// <summary>
        /// 新增题库类型
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool InsertEaxamType(ExamTypeEntity search)
        {
            return _examInfoDal.InsertEaxamType(search);
        }
    }
}
