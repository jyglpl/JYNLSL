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
    public class ExamInfoDal : BaseDal<ExamInfoEntity>
    {
        /// <summary>
        /// 获取考试列表信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public Page<ExamInfoEntity> GetExamInfo(string paperType, string keywords, int pageSize, int pageIndex)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM TestPeriod Where 1=1 AND isDeleted = 0");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(paperType))
            {
                strSql.AppendFormat(@" AND PaperType='{0}'", paperType);
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                strSql.AppendFormat(@" AND Title LIKE '%{0}%'", keywords);
            }
            strSql.Append(" ORDER BY StartDate Desc");
            return WriteDatabase.Page<ExamInfoEntity>(pageIndex, pageSize, strSql.ToString(), args.ToArray());
        }

        /// <summary>
        /// 获取考试列表信息
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="userId"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public DataTable QueryExamInfo(string keyword, string userId, string paperType, int pageSize, int pageIndex, string sidx, string sord, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append("SELECT * FROM TestPeriod Where 1=1 AND isDeleted = 0 ");
                if (!string.IsNullOrEmpty(paperType))
                {
                    strSql.AppendFormat(@" AND PaperType='{0}'", paperType);
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.AppendFormat(@" AND Title LIKE '%{0}%'", keyword);
                }
                var sortField = "CreateDate"; //排序字段
                var sortType = "DESC"; //排序类型

                if (!string.IsNullOrEmpty(sidx))
                {
                    sortField = sidx;
                    sortType = sord;
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField,
                                                sortType, pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取考试列表集合
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<ExamInfoEntity> GetExamInfoList(ExamInfoEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM TestPeriod Where isDeleted = 0");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.Tid))
            {
                strSql.AppendFormat(@" AND Tid='{0}'", search.Tid);
            }
            if (!string.IsNullOrEmpty(search.PaperType))
            {
                strSql.AppendFormat(@" AND PaperType='{0}'", search.PaperType);
            }
            if (!string.IsNullOrEmpty(search.keywords))
            {
                strSql.AppendFormat(@" AND Title LIKE '%{0}%'", search.keywords);
            }
            strSql.Append(" ORDER BY StartDate Desc");
            return WriteDatabase.Query<ExamInfoEntity>(strSql.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 新增考试
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool InsertExam(ExamInfoEntity entity)
        {
            var strSql = string.Format(@"INSERT INTO TestPeriod
(Tid,Title,Fraction,PassRatio,Pass,Time,StartDate,EndDate,Know,Publisher,SHName,PaperType,PaperOrderBy,PaperPatternBy,NYCD,ZJType,MultipleQuantity,SingleQuantity,JudgeQuantity,MultipleScore,ScoreScore,JudgeScore,TKQuantity,TKScore,JDQuantity,JDScore,ZWQuantity,ZWScore,LSQuantity,LSScore,FXQuantity,FXScore,ZHQuantity,ZHScore,ZHSc,Frequency,Unit,isMarking,isDeleted,CreateDate)
VALUES
('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}','{36}','{37}','{38}','{39}')",
entity.Tid, entity.Title, entity.Fraction, entity.PassRatio, entity.Pass, entity.Time, entity.StartDate, entity.EndDate, entity.Know, entity.Publisher, entity.SHName, entity.PaperType, entity.PaperOrderBy, entity.PaperPatternBy, entity.NYCD, entity.ZJType, entity.MultipleQuantity, entity.SingleQuantity, entity.JudgeQuantity, entity.MultipleScore, entity.ScoreScore, entity.JudgeScore, entity.TKQuantity, entity.TKScore, entity.JDQuantity, entity.JDScore, entity.ZWQuantity, entity.ZWScore, entity.LSQuantity, entity.LSScore, entity.FXQuantity, entity.FXScore, entity.ZHQuantity, entity.ZHScore, entity.ZHSc, entity.Frequency, entity.Unit, entity.isMarking, entity.isDeleted, entity.CreateDate);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 更新考试
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool UpdateExam(ExamInfoEntity entity)
        {
            var strSql = string.Format(@"UPDATE TestPeriod SET Title = '{0}',Fraction = '{1}',PassRatio = '{2}',Pass = '{3}',Time = '{4}',StartDate = '{5}',EndDate = '{6}',Know = '{7}',Publisher = '{8}',SHName = '{9}',PaperType = '{10}',PaperOrderBy = '{11}',PaperPatternBy = '{12}',NYCD = '{13}',ZJType = '{14}',MultipleQuantity = '{15}',
SingleQuantity = '{16}',JudgeQuantity = '{17}',MultipleScore = '{18}',ScoreScore = '{19}',JudgeScore = '{20}',TKQuantity = '{21}',TKScore = '{22}',JDQuantity = '{23}',JDScore = '{24}',ZWQuantity = '{25}',ZWScore = '{26}',LSQuantity = '{27}',LSScore = '{28}',FXQuantity = '{29}',FXScore = '{30}',ZHQuantity = '{31}',ZHScore = '{32}',ZHSc = '{33}',Frequency = '{34}',Unit = '{35}',isMarking = '{36}',isDeleted = '{37}',CreateDate = '{38}'
WHERE Tid = '{39}'", entity.Title, entity.Fraction, entity.PassRatio, entity.Pass, entity.Time, entity.StartDate, entity.EndDate, entity.Know, entity.Publisher, entity.SHName, entity.PaperType, entity.PaperOrderBy, entity.PaperPatternBy, entity.NYCD, entity.ZJType, entity.MultipleQuantity, entity.SingleQuantity, entity.JudgeQuantity, entity.MultipleScore, entity.ScoreScore, entity.JudgeScore, entity.TKQuantity, entity.TKScore, entity.JDQuantity, entity.JDScore, entity.ZWQuantity, entity.ZWScore, entity.LSQuantity, entity.LSScore, entity.FXQuantity, entity.FXScore, entity.ZHQuantity, entity.ZHScore, entity.ZHSc, entity.Frequency, entity.Unit, entity.isMarking, entity.isDeleted, entity.CreateDate, entity.Tid);
            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 根据主键删除考试
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteExam(string id)
        {
            var strSql = string.Format(@"DELETE FROM TestPeriod WHERE Tid = '{0}'", id);
            return WriteDatabase.Execute(strSql) > 0;
        }
    }
}
