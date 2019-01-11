using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Exam;

namespace Yookey.WisdomClassed.SIP.DataAccess.Exam
{
    public class QuetionTitleDal : BaseDal<QuetionTitleEntity>
    {
        /// <summary>
        /// 获取试题类型
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<QuetionTitleEntity> GetResultSearch(QuetionTitleEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM QuetionTitleThemeInfo Where 1 = 1");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.TItemId))
            {
                strSql.AppendFormat(@" AND TItemId='{0}'", search.TItemId);
            }
            return WriteDatabase.Query<QuetionTitleEntity>(strSql.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 删除试题类型
        /// </summary>
        /// <param name="Tid"></param>
        /// <returns></returns>
        public bool DeleteQuetionTitleTheme(string TItemId)
        {
            var strSql = string.Format(@"DELETE FROM QuetionTitleThemeInfo WHERE TItemId = '{0}'", TItemId);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 新增试题类型
        /// </summary>
        /// <param name="Tid"></param>
        /// <param name="Sid"></param>
        /// <returns></returns>
        public bool InsertQuetionTitleTheme(string QuestionId, string TItemId, string QuestionsType)
        {
            var strSql = string.Format(@"INSERT INTO QuetionTitleThemeInfo (QTTID,QuetionID,SubJectId,TItemId,Remarks)VALUES('{0}','{1}','{2}','{3}','{4}')", Guid.NewGuid().ToString(), QuestionId, QuestionsType, TItemId, "");
            return WriteDatabase.Execute(strSql) > 0;
        }
    }
}
