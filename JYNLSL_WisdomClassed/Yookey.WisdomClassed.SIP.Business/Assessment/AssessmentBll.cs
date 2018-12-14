//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AssessmentBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/14 15:04:12
//  功能描述：Assessment业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using Yookey.WisdomClassed.SIP.Model.Assessment;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Assessment;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Model;
using System.Data;

namespace Yookey.WisdomClassed.SIP.Business.Assessment
{
    /// <summary>
    /// Assessment业务逻辑
    /// </summary>
    public class AssessmentBll : BaseBll<AssessmentEntity>
    {
        readonly AssessmentDal _assessmentDal = new AssessmentDal();
        public AssessmentBll()
        {
            BaseDal = new AssessmentDal();
        }


        /// <summary>
        /// 查询路面考核分页列表
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public List<AssessmentEntity> GetAssessmentPage(AssessmentEntity entity, out int totalRecords)
        {
            return _assessmentDal.GetAssessmentPage(entity, out totalRecords);
        }

        /// <summary>
        /// 查询路面考核分页列表
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public PageJqDatagrid<AssessmentEntity> GetAssessmentPageJqDatagrid(AssessmentEntity entity)
        {
            int totalRecords;
            var data = _assessmentDal.GetAssessmentPageJqDatagrid(entity, out totalRecords);

            var totalPage = (totalRecords + entity.PageSize - 1) / entity.PageSize;
            return new PageJqDatagrid<AssessmentEntity>
            {
                page = entity.PageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords
            };
        }

        /// <summary>
        /// 查询部门分组的统计报表
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <returns></returns>
        public DataTable GetAssessmentReportGroupByDept(string companyId, string stime, string etime)
        {
            DataTable reportData = _assessmentDal.GetAssessmentReportGroupByDept(companyId, stime, etime);
            if (reportData != null && reportData.Rows.Count > 0)
            {
                var nRow = reportData.NewRow();  //添加一行


                int totalDEPT = 0,// 中队数量汇总
                    totalSumUntreated = 0,//待办汇总
                    totalSumProcessed = 0, // 已办汇总
                    totalSumClassNo1 = 0, // 市容环境卫生 汇总
                    totalSumClassNo2 = 0, //  汇总
                    totalSumClassNo3 = 0, //   汇总
                    totalSumClassNo4 = 0, //  汇总
                    totalSumClassNo5 = 0, //   汇总
                    totalSumClassNo6 = 0, //  汇总
                    totalSumClassNo7 = 0, //   汇总
                    totalSumClassNo8 = 0, //  汇总
                    totalSumClassNo9 = 0; //   汇总


                foreach (DataRow row in reportData.Rows)
                {
                    var sumUntreated = int.Parse(row["SumUntreated"].ToString());
                    var sumProcessed = int.Parse(row["SumProcessed"].ToString());
                    var sumClassNo1 = int.Parse(row["SumClassNo1"].ToString());
                    var sumClassNo2 = int.Parse(row["SumClassNo2"].ToString());
                    var sumClassNo3 = int.Parse(row["SumClassNo3"].ToString());
                    var sumClassNo4 = int.Parse(row["SumClassNo4"].ToString());
                    var sumClassNo5 = int.Parse(row["SumClassNo5"].ToString());
                    var sumClassNo6 = int.Parse(row["SumClassNo6"].ToString());
                    var sumClassNo7 = int.Parse(row["SumClassNo7"].ToString());
                    var sumClassNo8 = int.Parse(row["SumClassNo8"].ToString());
                    var sumClassNo9 = int.Parse(row["SumClassNo9"].ToString());

                    totalDEPT++;// 中队数量汇总
                    totalSumUntreated += sumUntreated;//待办汇总
                    totalSumProcessed += sumProcessed; // 已办汇总
                    totalSumClassNo1 += sumClassNo1; // 市容环境卫生 汇总
                    totalSumClassNo2 += sumClassNo2; //  汇总
                    totalSumClassNo3 += sumClassNo3; //   汇总
                    totalSumClassNo4 += sumClassNo4; //  汇总
                    totalSumClassNo5 += sumClassNo5; //   汇总
                    totalSumClassNo6 += sumClassNo6; //  汇总
                    totalSumClassNo7 += sumClassNo7; //   汇总
                    totalSumClassNo8 += sumClassNo8; //  汇总
                    totalSumClassNo9 += sumClassNo9; //   汇总
                }

                nRow["CompanyName"] = "合计";
                nRow["DepartmentName"] = totalDEPT;
                nRow["SumUntreated"] = totalSumUntreated;
                nRow["SumProcessed"] = totalSumProcessed;
                nRow["SumClassNo1"] = totalSumClassNo1;
                nRow["SumClassNo2"] = totalSumClassNo2;
                nRow["SumClassNo3"] = totalSumClassNo3;
                nRow["SumClassNo4"] = totalSumClassNo4;
                nRow["SumClassNo5"] = totalSumClassNo5;
                nRow["SumClassNo6"] = totalSumClassNo6;
                nRow["SumClassNo7"] = totalSumClassNo7;
                nRow["SumClassNo8"] = totalSumClassNo8;
                nRow["SumClassNo9"] = totalSumClassNo9; ;

                reportData.Rows.Add(nRow);
            }

            return reportData;
        }

        /// <summary>
        /// 事务新增路面考核
        /// </summary>
        /// <param name="withhold"></param>
        /// <param name="assessmentProcess"></param>
        /// <returns></returns>
        public bool TransactionAddAssessment(AssessmentEntity withhold, AssessmentProcessEntity assessmentProcess)
        {
            return _assessmentDal.TransactionAddAssessment(withhold, assessmentProcess);
        }

        /// <summary>
        /// 事务处理路面考核
        /// </summary>
        /// <param name="withhold"></param>
        /// <param name="assessmentProcess"></param>
        /// <returns></returns>
        public bool TransactionHandleAssessment(AssessmentEntity withhold, AssessmentProcessEntity assessmentProcess)
        {
            return _assessmentDal.TransactionHandleAssessment(withhold, assessmentProcess);
        }

        /// <summary>
        /// 查询路面考核待办数量
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="deptId"></param>
        /// <param name="assignUserId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int GetAssessmentToDoNumber(string companyId, string deptId, string assignUserId, int state)
        {
            return _assessmentDal.GetAssessmentToDoNumber(companyId, deptId, assignUserId, state);
        }
    }
}
