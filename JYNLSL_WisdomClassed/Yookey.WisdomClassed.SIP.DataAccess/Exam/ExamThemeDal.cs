using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Exam;

namespace Yookey.WisdomClassed.SIP.DataAccess.Exam
{
    public class ExamThemeDal : BaseDal<ExamThemeEntity>
    {
        /// <summary>
        /// 获取题库集合
        /// </summary>
        /// <returns></returns>
        public List<ExamThemeEntity> GetExamThemeList(ExamThemeEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM ThemeItem Where 1 = 1");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.TItemId))
            {
                strSql.AppendFormat(@" AND TItemId='{0}'", search.TItemId);
            }
            if (!string.IsNullOrEmpty(search.SubJectId))
            {
                strSql.AppendFormat(@" AND SubJectId='{0}'", search.SubJectId);
            }
            if (!string.IsNullOrEmpty(search.QuestionsType))
            {
                strSql.AppendFormat(@" AND QuestionsType='{0}'", search.QuestionsType);
            }
            return WriteDatabase.Query<ExamThemeEntity>(strSql.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 获取题库集合
        /// </summary>
        /// <returns></returns>
        public List<ExamThemeEntity> GetExamThemeList(ExamThemeEntity search,string Oid)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"select item.*,tb.answer as UserAnswer,tb.isError from 
(select * from OldAnswer where oid='{0}')
tb left join ThemeItem item on tb.TitemId = item.TItemId where 1=1 ", Oid);
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.QuestionsType))
            {
                strSql.AppendFormat(@" AND QuestionsType='{0}'", search.QuestionsType);
            }
            return WriteDatabase.Query<ExamThemeEntity>(strSql.ToString(), args.ToArray()).ToList();
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
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM ThemeItem Where 1=1 ");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(keywords))
            {
                strSql.AppendFormat(@" AND TItemName LIKE '%{0}%'", keywords);
            }
            strSql.Append(" ORDER BY CreateDate Desc");
            return WriteDatabase.Page<ExamThemeEntity>(pageIndex, pageSize, strSql.ToString(), args.ToArray());
        }

        /// <summary>
        /// 新增题库
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool InsertExamTheme(ExamThemeEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO ThemeItem(TItemId,TItemName,SubJectId,QuestionsType,CreateBy,CreateDate,IsDeleted,DeptID,Answer,NYCD,a,b,c,d,e,f,g,h,ScoreShu,Format)
VALUES
('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')",
entity.TItemId, entity.TItemName, entity.SubJectId, entity.QuestionsType, entity.CreateBy, entity.CreateDate, entity.IsDeleted, entity.DeptID, entity.Answer, entity.NYCD, entity.a, entity.b, entity.c, entity.d, entity.e, entity.f, entity.g, entity.h, entity.ScoreShu, entity.Format);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 更新题库
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool UpdateExamTheme(ExamThemeEntity entity)
        {
            var strSql = string.Format(@"UPDATE ThemeItem SET TItemId = '{0}',TItemName = '{1}',SubJectId = '{2}',QuestionsType = '{3}',CreateBy = '{4}',CreateDate = '{5}',IsDeleted = '{6}',DeptID = '{7}',Answer = '{8}',NYCD = '{9}',a = '{10}',b = '{11}',c = '{12}',d = '{13}',e = '{14}',f = '{15}',g = '{16}',h = '{17}',ScoreShu = '{18}',Format = '{19}'
 WHERE TItemId='{20}'",
entity.TItemId, entity.TItemName, entity.SubJectId, entity.QuestionsType, entity.CreateBy, entity.CreateDate, entity.IsDeleted, entity.DeptID, entity.Answer, entity.NYCD, entity.a, entity.b, entity.c, entity.d, entity.e, entity.f, entity.g, entity.h, entity.ScoreShu, entity.Format, entity.TItemId);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 删除题库
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteExamTheme(string Id)
        {
            var strSql = string.Format(@"DELETE FROM ThemeItem WHERE TItemId = '{0}'", Id);
            return WriteDatabase.Execute(strSql) > 0;
        }
    }
}
