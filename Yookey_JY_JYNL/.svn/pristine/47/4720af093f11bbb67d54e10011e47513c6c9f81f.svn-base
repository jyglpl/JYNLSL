using DBHelper;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Exam;

namespace Yookey.WisdomClassed.SIP.DataAccess.Exam
{
    public class ExamInfoMationDal : BaseDal<ExamInfoMationEntity>
    {
        /// <summary>
        /// 获取考试成绩
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<ExamInfoMationEntity> GetSearchResult(ExamInfoMationEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM ExamInfomation Where 1 = 1");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.Tid))
            {
                strSql.AppendFormat(@" AND Tid='{0}'", search.Tid);
            }
            if (!string.IsNullOrEmpty(search.Id))
            {
                strSql.AppendFormat(@" AND Id='{0}'", search.Id);
            }
            if (!string.IsNullOrEmpty(search.Uid))
            {
                strSql.AppendFormat(@" AND Uid='{0}'", search.Uid);
            }
            return WriteDatabase.Query<ExamInfoMationEntity>(strSql.ToString(), args.ToArray()).ToList();
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
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM ExamInfomation Where 1 = 1");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(Tid))
            {
                strSql.AppendFormat(@" AND Tid='{0}'", Tid);
            }
            if (!string.IsNullOrEmpty(userId))
            {
                strSql.AppendFormat(@" AND Uid='{0}'", userId);
            }
            return WriteDatabase.Page<ExamInfoMationEntity>(pageIndex, pageSize, strSql.ToString(), args.ToArray());
        }

        /// <summary>
        /// 插入考试成绩
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertExamInfomation(ExamInfoMationEntity entity)
        {
            string strSql = string.Format("insert into ExamInfomation (Id,Tid,Uid,Time,Source,OId,IsPiYue,IsShenPi) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", entity.Id, entity.Tid, entity.Uid, DateTime.Now, entity.ExamScore, entity.OId, entity.IsPiYue, entity.IsShenPi);
            return WriteDatabase.Execute(strSql) > 0;
        }

       
    }
}
