using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Exam;
using Yookey.WisdomClassed.SIP.Model.Exam;

namespace Yookey.WisdomClassed.SIP.Business.Exam
{
    public class ExamInfoMationBll
    {
        private readonly ExamInfoMationDal _examInfoMationDal = new ExamInfoMationDal();

        /// <summary>
        /// 获取考试成绩
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<ExamInfoMationEntity> GetSearchResult(ExamInfoMationEntity entity)
        {
            return _examInfoMationDal.GetSearchResult(entity);
        }

        /// <summary>
        /// 获取考试成绩列表信息
        /// </summary>
        /// <param name="paperType"></param>
        /// <param name="keywords"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public Page<ExamInfoMationEntity> GetExamInfomation(string keywords, string Tid, string userId, int pageSize = 30, int pageIndex = 1)
        {
            return _examInfoMationDal.GetExamInfomation(keywords, Tid, userId, pageSize, pageIndex);
        }

        /// <summary>
        /// 插入考试成绩
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertExamInfomation(ExamInfoMationEntity entity)
        {
            return _examInfoMationDal.InsertExamInfomation(entity);
        }

       
    }
}
