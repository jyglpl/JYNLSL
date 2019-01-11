using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Exam;
using Yookey.WisdomClassed.SIP.Model.Exam;

namespace Yookey.WisdomClassed.SIP.Business.Exam
{
    public class ExamInfoBll
    {
        private readonly ExamInfoDal _examInfoDal = new ExamInfoDal();

        /// <summary>
        /// 获取考试列表信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public Page<ExamInfoEntity> GetExamInfo(string paperType, string keywords, int pageSize = 30, int pageIndex = 1)
        {
            return _examInfoDal.GetExamInfo(paperType, keywords, pageSize, pageIndex);
        }

        /// <summary>
        /// 获取考试列表信息
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="userId"></param>
        /// <param name="sidx"></param>
        /// <param name="sord"></param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryExamInfo(string keywords, string userId, string paperType, string sidx, string sord, int pageSzie = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;

            var data = _examInfoDal.QueryExamInfo(keywords, userId, paperType, pageSzie, pageIndex, sidx, sord, out totalRecords);

            data.TableName = "ExamInfoDT";
            stopwatch.Stop();
            int totalPage = (totalRecords + pageSzie - 1) / pageSzie;   //计算页数
            return new PageJqDatagrid<DataTable>
            {
                page = pageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        /// <summary>
        /// 获取考试列表集合
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<ExamInfoEntity> GetExamInfoList(ExamInfoEntity search)
        {
            return _examInfoDal.GetExamInfoList(search);
        }

        /// <summary>
        /// 新增考试
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool InsertExam(ExamInfoEntity search)
        {
            return _examInfoDal.InsertExam(search);
        }

        /// <summary>
        /// 更新考试
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool UpdateExam(ExamInfoEntity search)
        {
            return _examInfoDal.UpdateExam(search);
        }

        /// <summary>
        /// 根据主键删除考试
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteExam(string id)
        {
            return _examInfoDal.DeleteExam(id);
        }
    }
}
