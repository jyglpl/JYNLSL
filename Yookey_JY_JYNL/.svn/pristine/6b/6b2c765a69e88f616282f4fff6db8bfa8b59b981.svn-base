using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Exam;

namespace Yookey.WisdomClassed.SIP.DataAccess.Exam
{
    public class ExamTypeDal : BaseDal<ExamTypeEntity>
    {
        /// <summary>
        /// 获取题库类型
        /// </summary>
        /// <returns></returns>
        public List<ExamTypeEntity> GetExamList(ExamTypeEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM TitleTotal Where 1 = 1");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.SubJectId))
            {
                strSql.AppendFormat(@" AND SubJectId='{0}'", search.SubJectId);
            }
            return WriteDatabase.Query<ExamTypeEntity>(strSql.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 新增题库类型
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool InsertEaxamType(ExamTypeEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO TitleTotal (SubJectId ,SubJectName ,SubJectRadio ,SubJectDuo ,SubJectPan ,SubjectIsStart ,CreateBy ,CreateDate ,QuetionID ,IsDeleted ,OrgID)
                                        VALUES ('{0}' ,'{1}' ,'{2}' ,'{3}' ,'{4}' ,'{5}' ,'{6}' ,'{7}' ,'{8}' ,'{9}' ,'{10}')", entity.SubJectId, entity.SubJectName, entity.SubJectRadio, entity.SubJectDuo, entity.SubJectPan, entity.SubjectIsStart, entity.CreateBy, entity.CreateDate, entity.QuetionID, entity.IsDeleted, entity.OrgID);
            return WriteDatabase.Execute(strSql) > 0;
        }
    }
}
