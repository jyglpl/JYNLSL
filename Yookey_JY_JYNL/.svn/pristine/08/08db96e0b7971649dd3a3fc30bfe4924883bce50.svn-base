using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Report;

namespace Yookey.WisdomClassed.SIP.Business.Report
{
    /// <summary>
    /// 案件报表业务逻辑
    /// </summary>
    public class CaseReportBll
    {
        private readonly CaseReportDal _caseReportDal = new CaseReportDal();
        private readonly BaseDepartmentBll _baseDepartmentBll = new BaseDepartmentBll();

        /// <summary>
        /// 处理情况统计表
        /// 添加人：周 鹏
        /// 添加时间：2015-05-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2017-03-16 周 鹏 增加单位编号
        /// </history>
        /// <param name="companyId"></param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable. Columns :SumCount 已开停违单 SumHandle 未处理单 CarCount 已开停违单 CarHandle 未处理单 CaseCount 已开停违单 CaseHandle 未处理单</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable QueryHandlingInformation(string companyId, string caseType, string startTime, string endTime)
        {
            try
            {
                var reportData = _caseReportDal.QueryHandlingInformation(companyId, caseType, startTime, endTime);
                if (reportData != null && reportData.Rows.Count > 0)
                {
                    var nRow = reportData.NewRow();  //添加一行
                    int totalSumCount = 0,
                        totalSumHandle = 0,
                        totalCarCount = 0,
                        totalCarHandle = 0,
                        totalCaseCount = 0,
                        totalCaseHandle = 0;

                    foreach (DataRow row in reportData.Rows)
                    {
                        var sumCount = int.Parse(row["SumCount"].ToString());
                        var sumHandle = int.Parse(row["SumHandle"].ToString());
                        var carCount = int.Parse(row["CarCount"].ToString());
                        var carHandle = int.Parse(row["CarHandle"].ToString());
                        var caseCount = int.Parse(row["CaseCount"].ToString());
                        var caseHandle = int.Parse(row["CaseHandle"].ToString());

                        totalSumCount += sumCount;
                        totalSumHandle += sumHandle;
                        totalCarCount += carCount;
                        totalCarHandle += carHandle;
                        totalCaseCount += caseCount;
                        totalCaseHandle += caseHandle;
                    }

                    nRow["DeptName"] = "合计";
                    nRow["SumCount"] = totalSumCount;
                    nRow["SumHandle"] = totalSumHandle;
                    nRow["CarCount"] = totalCarCount;
                    nRow["CarHandle"] = totalCarHandle;
                    nRow["CaseCount"] = totalCaseCount;
                    nRow["CaseHandle"] = totalCaseHandle;

                    reportData.Rows.Add(nRow);
                }

                return reportData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// 案件明细统计
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>

        public DataTable QueryCaseDetailsInformation(string startTime, string endTime, string deptid, string ProcessTypeId, string State, string ClassNo, string targetType, string keywords, string sidx, string sord)
        {
            try
            {
                return _caseReportDal.QueryCaseDetailsInformation(startTime, endTime, deptid, ProcessTypeId, State, ClassNo, targetType, keywords, sidx, sord);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 年度各中队统计汇总表
        /// 添加人：周 鹏
        /// 添加时间：2015-05-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="year">年度</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable QueryAnnualSummary(int year)
        {
            try
            {
                //去年的12月26日至今年的12月25日
                var startTime = Convert.ToDateTime(Convert.ToDateTime(year + "-01-01").AddYears(-1).Year + "-12-26");
                var endTime = Convert.ToDateTime(year + "-12-25");

                if (year == DateTime.Now.Year)
                {
                    endTime = Convert.ToDateTime(DateTime.Now.AddMonths(1).ToString("yyyy-MM") + "-25");
                }
                var deptDt = _baseDepartmentBll.GetAllDetachment();       //所有中队

                var oldData = new DataTable();   //老数据
                if (year == 2015)    //查询2015年1至7月份的老数据
                {
                    oldData = _caseReportDal.OldYearReportTotal();
                }

                var sumaryDt = new DataTable();
                sumaryDt.Columns.Add("DeptName");
                sumaryDt.Columns.Add("Types");
                sumaryDt.Columns.Add("1");
                sumaryDt.Columns.Add("2");
                sumaryDt.Columns.Add("3");
                sumaryDt.Columns.Add("4");
                sumaryDt.Columns.Add("5");
                sumaryDt.Columns.Add("6");
                sumaryDt.Columns.Add("7");
                sumaryDt.Columns.Add("8");
                sumaryDt.Columns.Add("9");
                sumaryDt.Columns.Add("10");
                sumaryDt.Columns.Add("11");
                sumaryDt.Columns.Add("12");
                sumaryDt.Columns.Add("Total");


                var totalnRow = sumaryDt.NewRow();
                totalnRow["DeptName"] = "合计";
                totalnRow["Types"] = "停违";

                var totalnRow1 = sumaryDt.NewRow();
                totalnRow1["DeptName"] = "合计";
                totalnRow1["Types"] = "案件";

                var totalnRow2 = sumaryDt.NewRow();
                totalnRow2["DeptName"] = "合计";
                totalnRow2["Types"] = "罚款";

                //纵向合计
                var totalSumCar = 0;
                var totalSumCase = 0;
                var totalSumMoney = 0;

                //循环遍历部门
                foreach (var baseDepartmentEntity in deptDt)
                {
                    #region 各项值计算
                    var nRow = sumaryDt.NewRow();
                    nRow["DeptName"] = baseDepartmentEntity.FullName;
                    nRow["Types"] = "停违";

                    var nRow1 = sumaryDt.NewRow();
                    nRow1["DeptName"] = baseDepartmentEntity.FullName;
                    nRow1["Types"] = "案件";

                    var nRow2 = sumaryDt.NewRow();
                    nRow2["DeptName"] = baseDepartmentEntity.FullName;
                    nRow2["Types"] = "罚款";

                    var sTime = startTime;

                    //横向合计
                    var sumNoticeCase = 0;
                    var sumCase = 0;
                    var sumMoney = 0;

                    sTime = sTime.AddMonths(1);

                    //循环遍历月份取数据
                    for (; sTime <= endTime; sTime = sTime.AddMonths(1))
                    {
                        var qmonth = sTime.Month.ToString(CultureInfo.InvariantCulture);

                        //停违、案件、处罚金额
                        int caseNoticeCount = 0, caseCount = 0, moneyCount = 0;

                        //查询2015年1-7月数据
                        if (year == 2015 && sTime.Month < 8)
                        {
                            if (oldData != null && oldData.Rows.Count > 0)
                            {
                                var sdrCase = oldData.Select(string.Format("DeptId='{0}' AND Date='{1}'", baseDepartmentEntity.DepartmentId, year + "-" + qmonth.PadLeft(2, '0')));
                                if (sdrCase.Length > 0)
                                {
                                    caseNoticeCount = !string.IsNullOrEmpty(sdrCase[0]["CaseTotalCount"].ToString())
                                                          ? int.Parse(sdrCase[0]["CaseTotalCount"].ToString())
                                                          : 0;
                                    caseCount = !string.IsNullOrEmpty(sdrCase[0]["CaseCount"].ToString())
                                                          ? int.Parse(sdrCase[0]["CaseCount"].ToString())
                                                          : 0;
                                    moneyCount = !string.IsNullOrEmpty(sdrCase[0]["CaseMoney"].ToString())
                                                          ? int.Parse(sdrCase[0]["CaseMoney"].ToString())
                                                          : 0;
                                }
                            }
                        }
                        else
                        {

                            var qstartTime = sTime.AddMonths(-1).ToString("yyyy-MM") + "-26";
                            var qendTime = sTime.ToString("yyyy-MM") + "-25";

                            //停违（开具停违单）
                            var noticeCaseCountDt = _caseReportDal.GetCaseCountDistinctNotice(qstartTime, qendTime);
                            //案件处理数据及处罚金额数
                            var handleDt = _caseReportDal.GetCaseHandle(qstartTime, qendTime);


                            var sdrNoticeCase = noticeCaseCountDt.Select(string.Format("DeptId='{0}'", baseDepartmentEntity.DepartmentId));
                            var sdrHandle = handleDt.Select(string.Format("DeptId='{0}'", baseDepartmentEntity.DepartmentId));

                            caseNoticeCount = sdrNoticeCase.Length > 0 ? int.Parse(sdrNoticeCase[0]["CaseCount"].ToString()) : 0;
                            caseCount = sdrHandle.Length > 0 ? int.Parse(sdrHandle[0]["CaseCount"].ToString()) : 0;
                            moneyCount = sdrHandle.Length > 0 ? int.Parse(sdrHandle[0]["HandleMoney"].ToString()) : 0;
                        }

                        //每条数据横向合计
                        sumNoticeCase += caseNoticeCount;
                        sumCase += caseCount;
                        sumMoney += moneyCount;

                        var carCountValue = caseNoticeCount > 0 ? caseNoticeCount.ToString() : "";
                        var caseCountValue = caseCount > 0 ? caseCount.ToString() : "";
                        var moneyCountValue = moneyCount > 0 ? moneyCount.ToString() : "";
                        nRow[qmonth] = carCountValue;
                        nRow1[qmonth] = caseCountValue;
                        nRow2[qmonth] = moneyCountValue;

                        var totalCar = totalnRow[qmonth].ToString();
                        var totalCase = totalnRow1[qmonth].ToString();
                        var totalMoney = totalnRow2[qmonth].ToString();

                        //合计行每月数据
                        totalnRow[qmonth] = !string.IsNullOrEmpty(totalCar) ? (int.Parse(totalCar) + caseNoticeCount).ToString() : carCountValue;
                        totalnRow1[qmonth] = !string.IsNullOrEmpty(totalCase) ? (int.Parse(totalCase) + caseCount).ToString() : caseCountValue;
                        totalnRow2[qmonth] = !string.IsNullOrEmpty(totalMoney) ? (int.Parse(totalMoney) + moneyCount).ToString() : moneyCountValue;
                    }


                    nRow["Total"] = sumNoticeCase > 0 ? sumNoticeCase.ToString() : "";
                    nRow1["Total"] = sumCase > 0 ? sumCase.ToString() : "";
                    nRow2["Total"] = sumMoney > 0 ? sumMoney.ToString() : "";

                    sumaryDt.Rows.Add(nRow);
                    sumaryDt.Rows.Add(nRow1);
                    sumaryDt.Rows.Add(nRow2);

                    totalSumCar += sumNoticeCase;
                    totalSumCase += sumCase;
                    totalSumMoney += sumMoney;
                    #endregion
                }

                totalnRow["Total"] = totalSumCar > 0 ? totalSumCar.ToString() : "";
                totalnRow1["Total"] = totalSumCase > 0 ? totalSumCase.ToString() : "";
                totalnRow2["Total"] = totalSumMoney > 0 ? totalSumMoney.ToString() : "";

                sumaryDt.Rows.Add(totalnRow);
                sumaryDt.Rows.Add(totalnRow1);
                sumaryDt.Rows.Add(totalnRow2);

                return sumaryDt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 案件汇总统计
        /// 添加人：周 鹏
        /// 添加时间：2015-05-21
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable.</returns>
        public DataTable CaseCatalogSumary(string companyId, string caseType, string startTime, string endTime)
        {
            try
            {
                var sumaryDt = new DataTable();
                sumaryDt.Columns.Add("ItemName");       //案由名称
                sumaryDt.Columns.Add("CaseCount");      //本月案件数
                sumaryDt.Columns.Add("CaseSumCount");   //累计案件数
                sumaryDt.Columns.Add("MoneyCount");     //本月罚款额
                sumaryDt.Columns.Add("MoneySumCount");  //累计罚款额


                //本月
                var queryMonthDt = _caseReportDal.CaseCatalogSumary(companyId, caseType, startTime, endTime);


                //累计汇总（请求开始时间的所属年份最小的会计月开始时间）
                startTime = Convert.ToDateTime(startTime).AddYears(-1).Year + "-12-26";

                ////老数据2015年1月至7月
                //var oldData = new DataTable();
                //if (Convert.ToDateTime(endTime).Year == 2015)
                //{
                //    oldData = _caseReportDal.OldCatalogSumaryTotal();
                //    startTime = "2015-07-25";
                //}

                var queryTotalDt = _caseReportDal.CaseCatalogSumary(companyId, caseType, startTime, endTime);


                //循环遍历月份数据,查询累计汇总中是否存在相同的案由名称,存在则计算合并数据
                foreach (DataRow row in queryMonthDt.Rows)
                {
                    var nRow = sumaryDt.NewRow();

                    var itemName = row["ItemName"].ToString();
                    var caseCount = int.Parse(row["CT"].ToString());
                    var money = int.Parse(row["CFMoney"].ToString());


                    nRow["ItemName"] = itemName;
                    nRow["CaseCount"] = caseCount;
                    nRow["MoneyCount"] = money;

                    nRow["CaseSumCount"] = caseCount;
                    nRow["MoneySumCount"] = money;


                    var caseSumCount = 0;
                    var moneySumCount = 0;

                    //查询累计数据中是否存存相同的数据
                    var totalRow = queryTotalDt.Select(string.Format("ItemName='{0}'", itemName));
                    if (totalRow.Length > 0)
                    {
                        caseSumCount = int.Parse(totalRow[0]["CT"].ToString());
                        moneySumCount = int.Parse(totalRow[0]["CFMoney"].ToString());

                        nRow["CaseSumCount"] = caseSumCount;
                        nRow["MoneySumCount"] = moneySumCount;

                        queryTotalDt.Rows.Remove(totalRow[0]);
                    }

                    ////查询老数据
                    //if (oldData.Rows.Count > 0)
                    //{
                    //    var oldTotalRow = oldData.Select(string.Format("ItemName='{0}'", itemName));
                    //    if (oldTotalRow.Length > 0)
                    //    {
                    //        var oldCaseSumCount = int.Parse(oldTotalRow[0]["MonthCaseTotal"].ToString());
                    //        var oldMoneySumCount = int.Parse(oldTotalRow[0]["CaseTotal"].ToString());


                    //        nRow["CaseSumCount"] = caseSumCount + oldCaseSumCount;
                    //        nRow["MoneySumCount"] = moneySumCount + oldMoneySumCount;

                    //        oldData.Rows.Remove(oldTotalRow[0]);
                    //    }
                    //}
                    sumaryDt.Rows.Add(nRow);
                }

                //循环遍历累计汇总数据,查询月份以及老数据中是否存在相同的案由数据,不存在则添加到临时表中
                foreach (DataRow row in queryTotalDt.Rows)
                {
                    var itemName = row["ItemName"].ToString();

                    var nRow = sumaryDt.NewRow();
                    nRow["ItemName"] = itemName;

                    var caseSumCount = int.Parse(row["CT"].ToString());
                    var moneySumCount = int.Parse(row["CFMoney"].ToString());

                    nRow["CaseCount"] = 0;
                    nRow["MoneyCount"] = 0;
                    nRow["CaseSumCount"] = caseSumCount;
                    nRow["MoneySumCount"] = moneySumCount;

                    ////查询老数据
                    //if (oldData.Rows.Count > 0)
                    //{
                    //    var oldTotalRow = oldData.Select(string.Format("ItemName='{0}'", itemName));
                    //    if (oldTotalRow.Length > 0)
                    //    {
                    //        var oldCaseSumCount = int.Parse(oldTotalRow[0]["MonthCaseTotal"].ToString());
                    //        var oldMoneySumCount = int.Parse(oldTotalRow[0]["CaseTotal"].ToString());


                    //        nRow["CaseSumCount"] = caseSumCount + oldCaseSumCount;
                    //        nRow["MoneySumCount"] = moneySumCount + oldMoneySumCount;

                    //        oldData.Rows.Remove(oldTotalRow[0]);
                    //    }
                    //}
                    sumaryDt.Rows.Add(nRow);
                }

                ////循环遍历累计汇总数据,查询月份和累计汇总是否存在相同的案由数据,不存在则添加到临时表中
                //if (oldData != null && oldData.Rows.Count > 0)
                //{
                //    foreach (DataRow row in oldData.Rows)
                //    {
                //        var nRow = sumaryDt.NewRow();
                //        var itemName = row["ItemName"].ToString();
                //        nRow["ItemName"] = itemName;

                //        var caseSumCount = int.Parse(row["MonthCaseTotal"].ToString());
                //        var moneySumCount = int.Parse(row["CaseTotal"].ToString());

                //        nRow["CaseCount"] = 0;
                //        nRow["MoneyCount"] = 0;
                //        nRow["CaseSumCount"] = caseSumCount;
                //        nRow["MoneySumCount"] = moneySumCount;
                //        sumaryDt.Rows.Add(nRow);
                //    }
                //}

                var dv = sumaryDt.DefaultView;
                dv.Sort = "ItemName";
                sumaryDt = dv.ToTable();

                var totalCaseCount = 0;
                var totalCaseSumCount = 0;
                var totalMoneyCount = 0;
                var totalMoneySumCount = 0;

                //计算合计
                foreach (DataRow row in sumaryDt.Rows)
                {
                    totalCaseCount += int.Parse(row["CaseCount"].ToString());
                    totalCaseSumCount += int.Parse(row["CaseSumCount"].ToString());
                    totalMoneyCount += int.Parse(row["MoneyCount"].ToString());
                    totalMoneySumCount += int.Parse(row["MoneySumCount"].ToString());
                }

                var totalnRow = sumaryDt.NewRow();
                totalnRow["ItemName"] = "合计";
                totalnRow["CaseCount"] = totalCaseCount;
                totalnRow["MoneyCount"] = totalMoneyCount;
                totalnRow["CaseSumCount"] = totalCaseSumCount;
                totalnRow["MoneySumCount"] = totalMoneySumCount;

                sumaryDt.Rows.Add(totalnRow);
                return sumaryDt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 案件汇总日登记统计
        /// </summary>
        /// <returns></returns>
        public int CaseCatalogDay(string startTime, string endTime)
        {
            try
            {
                var dayCount = _caseReportDal.CaseCatalogDay(startTime, endTime);
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 执法月报表
        /// 添加人：周 鹏
        /// 添加时间：2015-05-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="total">计算累计</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable.</returns>
        public DataTable CaseMonth(string companyId, string total, string startTime, string endTime)
        {
            try
            {
                var sumaryDt = new DataTable();

                var nStartTime = Convert.ToDateTime(startTime);
                var nEndTime = Convert.ToDateTime(endTime);

                var oldTotalData = new DataTable();


                //计算累计
                if (!string.IsNullOrEmpty(total) && total.Equals("checked"))
                {
                    //查询2015-01月至04月的案件汇总数据
                    if ((nStartTime.Year == 2017 || nStartTime.Year == 2016) && nEndTime.Year == 2017)
                    {
                        oldTotalData = _caseReportDal.OldYearReportTotal();
                    }
                    startTime = Convert.ToDateTime(endTime).AddYears(-1).Year + "-04-26";
                }
                else
                {
                    oldTotalData = _caseReportDal.OldYearReportTotal(nStartTime.AddMonths(1).ToString("yyyy-MM-01"));
                }

                var educationDt = _caseReportDal.CaseEducation(companyId, startTime, endTime);         //案件纠处
                var caseHandleDt = _caseReportDal.CaseHandleInfo(companyId, startTime, endTime);       //案件违章查处情况
                var caseHandleByProcess = _caseReportDal.CaseHandleInfoByPunishProcess(companyId, startTime, endTime);   //按简易、一般统计案件处理情况

                //var dismantleBdDt = _caseReportDal.DismantleAdAndBd(startTime, endTime, 2); //违法建筑拆除数
                //var dismantleAdDt = _caseReportDal.DismantleAdAndBd(startTime, endTime, 3); //户外广告拆除数



                var dismantleBdDt = new DataTable();
                var dismantleAdDt = new DataTable();


                #region 定义数据字段
                //教育纠处（起）
                sumaryDt.Columns.Add("Ed_00090001");  //市容环境卫生
                sumaryDt.Columns.Add("Ed_00090002");  //城市规划
                sumaryDt.Columns.Add("Ed_00090003");  //城市绿化
                sumaryDt.Columns.Add("Ed_00090004");  //市政设施
                sumaryDt.Columns.Add("Ed_00090005");  //公安交通
                sumaryDt.Columns.Add("Ed_00090006");  //工商行政管理
                sumaryDt.Columns.Add("Ed_00090007");  //环境保护
                sumaryDt.Columns.Add("Ed_00090008");  //水利水务
                sumaryDt.Columns.Add("Ed_TotalCount");   //小计

                //违章查询（起）
                sumaryDt.Columns.Add("Case_00090001");  //市容环境卫生
                sumaryDt.Columns.Add("Case_00090002");  //城市规划
                sumaryDt.Columns.Add("Case_00090003");  //城市绿化
                sumaryDt.Columns.Add("Case_00090004");  //市政设施
                sumaryDt.Columns.Add("Case_00090005");  //公安交通
                sumaryDt.Columns.Add("Case_00090006");  //工商行政管理
                sumaryDt.Columns.Add("Case_00090007");  //环境保护
                sumaryDt.Columns.Add("Case_00090008");  //水利水务
                sumaryDt.Columns.Add("Case_TotalCount");   //小计

                //罚款金额（元）
                sumaryDt.Columns.Add("Case_00090001_Money");  //市容环境卫生
                sumaryDt.Columns.Add("Case_00090002_Money");  //城市规划
                sumaryDt.Columns.Add("Case_00090003_Money");  //城市绿化
                sumaryDt.Columns.Add("Case_00090004_Money");  //市政设施
                sumaryDt.Columns.Add("Case_00090005_Money");  //公安交通
                sumaryDt.Columns.Add("Case_00090006_Money");  //工商行政管理
                sumaryDt.Columns.Add("Case_00090007_Money");  //环境保护
                sumaryDt.Columns.Add("Case_00090008_Money");  //水利水务
                sumaryDt.Columns.Add("Case_TotalMoney");      //小计

                //一般、简易案件量及处理金额
                sumaryDt.Columns.Add("Case_Punish");      //一般
                sumaryDt.Columns.Add("Case_PunishMoney"); //一般罚款
                sumaryDt.Columns.Add("Case_Simple");      //简易
                sumaryDt.Columns.Add("Case_SimpleMoney"); //简易罚款


                //各项案件结案数与罚款金额所占当月总数的比例统计表

                //结案数比例
                sumaryDt.Columns.Add("CaseCloseProportion_00090001");  //市容环境卫生
                sumaryDt.Columns.Add("CaseCloseProportion_00090002");  //城市规划
                sumaryDt.Columns.Add("CaseCloseProportion_00090003");  //城市绿化
                sumaryDt.Columns.Add("CaseCloseProportion_00090004");  //市政设施
                sumaryDt.Columns.Add("CaseCloseProportion_00090005");  //公安交通
                sumaryDt.Columns.Add("CaseCloseProportion_00090006");  //工商行政管理
                sumaryDt.Columns.Add("CaseCloseProportion_00090007");  //环境保护
                sumaryDt.Columns.Add("CaseCloseProportion_00090008");  //水利水务

                //罚款金额比例
                sumaryDt.Columns.Add("PunishMoneyProportion_00090001");  //市容环境卫生
                sumaryDt.Columns.Add("PunishMoneyProportion_00090002");  //城市规划
                sumaryDt.Columns.Add("PunishMoneyProportion_00090003");  //城市绿化
                sumaryDt.Columns.Add("PunishMoneyProportion_00090004");  //市政设施
                sumaryDt.Columns.Add("PunishMoneyProportion_00090005");  //公安交通
                sumaryDt.Columns.Add("PunishMoneyProportion_00090006");  //工商行政管理
                sumaryDt.Columns.Add("PunishMoneyProportion_00090007");  //环境保护
                sumaryDt.Columns.Add("PunishMoneyProportion_00090008");  //水利水务


                //拆除违章建筑
                sumaryDt.Columns.Add("DismantleBdCount");   //数量
                sumaryDt.Columns.Add("DismantleBdArea");    //面积

                //拆除户外广告
                sumaryDt.Columns.Add("DismantleAdCount");   //数量
                sumaryDt.Columns.Add("DismantleAdArea");    //面积

                #endregion

                var nRow = sumaryDt.NewRow();

                //所有字符初始化为空值
                foreach (DataColumn column in sumaryDt.Columns)
                {
                    nRow[column.ColumnName] = "";
                }

                if (educationDt != null && educationDt.Rows.Count > 0 || (oldTotalData != null && oldTotalData.Rows.Count > 0))
                {
                    #region 教育纠处小项

                    //该类似代码仅用于2015年累计统计
                    int oldEd00090001 = 0,
                        oldEd00090002 = 0,
                        oldEd00090003 = 0,
                        oldEd00090004 = 0,
                        oldEd00090005 = 0,
                        oldEd00090006 = 0,
                        oldEd00090007 = 0,
                        oldEd00090008 = 0;

                    if (oldTotalData != null && oldTotalData.Rows.Count > 0)
                    {
                        var oldTotalRow = oldTotalData.Rows[0];
                        oldEd00090001 = int.Parse(oldTotalRow["Ed_00090001"].ToString());
                        oldEd00090002 = int.Parse(oldTotalRow["Ed_00090002"].ToString());
                        oldEd00090003 = int.Parse(oldTotalRow["Ed_00090003"].ToString());
                        oldEd00090004 = int.Parse(oldTotalRow["Ed_00090004"].ToString());
                        oldEd00090005 = int.Parse(oldTotalRow["Ed_00090005"].ToString());
                        oldEd00090006 = int.Parse(oldTotalRow["Ed_00090006"].ToString());
                        oldEd00090007 = int.Parse(oldTotalRow["Ed_00090007"].ToString());
                        oldEd00090008 = int.Parse(oldTotalRow["Ed_00090008"].ToString());
                    }


                    var educationTotalCount = 0;

                    var ed00090001 = 0;
                    var ed00090001Rows = educationDt.Select(string.Format("ClassNo='{0}'", "00090001"));
                    if (ed00090001Rows.Length > 0)
                    {
                        ed00090001 = int.Parse(ed00090001Rows[0]["Number"].ToString());
                    }
                    ed00090001 += oldEd00090001;

                    var ed00090002 = 0;
                    var ed00090002Rows = educationDt.Select(string.Format("ClassNo='{0}'", "00090002"));
                    if (ed00090002Rows.Length > 0)
                    {
                        ed00090002 = int.Parse(ed00090002Rows[0]["Number"].ToString());
                    }
                    ed00090002 += oldEd00090002;

                    var ed00090003 = 0;
                    var ed00090003Rows = educationDt.Select(string.Format("ClassNo='{0}'", "00090003"));
                    if (ed00090003Rows.Length > 0)
                    {
                        ed00090003 = int.Parse(ed00090003Rows[0]["Number"].ToString());
                    }
                    ed00090003 += oldEd00090003;

                    var ed00090004 = 0;
                    var ed00090004Rows = educationDt.Select(string.Format("ClassNo='{0}'", "00090004"));
                    if (ed00090004Rows.Length > 0)
                    {
                        ed00090004 = int.Parse(ed00090004Rows[0]["Number"].ToString());
                    }
                    ed00090004 += oldEd00090004;

                    var ed00090005 = 0;
                    var ed00090005Rows = educationDt.Select(string.Format("ClassNo='{0}'", "00090005"));
                    if (ed00090005Rows.Length > 0)
                    {
                        ed00090005 = int.Parse(ed00090005Rows[0]["Number"].ToString());
                    }
                    ed00090005 += oldEd00090005;

                    var ed00090006 = 0;
                    var ed00090006Rows = educationDt.Select(string.Format("ClassNo='{0}'", "00090006"));
                    if (ed00090006Rows.Length > 0)
                    {
                        ed00090006 = int.Parse(ed00090006Rows[0]["Number"].ToString());
                    }
                    ed00090006 += oldEd00090006;

                    var ed00090007 = 0;
                    var ed00090007Rows = educationDt.Select(string.Format("ClassNo='{0}'", "00090007"));
                    if (ed00090007Rows.Length > 0)
                    {
                        ed00090007 = int.Parse(ed00090007Rows[0]["Number"].ToString());
                    }
                    ed00090007 += oldEd00090007;

                    var ed00090008 = 0;
                    var ed00090008Rows = educationDt.Select(string.Format("ClassNo='{0}'", "00090008"));
                    if (ed00090008Rows.Length > 0)
                    {
                        ed00090008 = int.Parse(ed00090008Rows[0]["Number"].ToString());
                    }
                    ed00090008 += oldEd00090008;

                    educationTotalCount = ed00090001 + ed00090002 + ed00090003 + ed00090004 + ed00090005 + ed00090006 +
                                          ed00090007 + ed00090008;

                    nRow["Ed_00090001"] = ed00090001 > 0 ? ed00090001.ToString() : "";
                    nRow["Ed_00090002"] = ed00090002 > 0 ? ed00090002.ToString() : "";
                    nRow["Ed_00090003"] = ed00090003 > 0 ? ed00090003.ToString() : "";
                    nRow["Ed_00090004"] = ed00090004 > 0 ? ed00090004.ToString() : "";
                    nRow["Ed_00090005"] = ed00090005 > 0 ? ed00090005.ToString() : "";
                    nRow["Ed_00090006"] = ed00090006 > 0 ? ed00090006.ToString() : "";
                    nRow["Ed_00090007"] = ed00090007 > 0 ? ed00090007.ToString() : "";
                    nRow["Ed_00090008"] = ed00090008 > 0 ? ed00090008.ToString() : "";

                    nRow["Ed_TotalCount"] = educationTotalCount > 0 ? educationTotalCount.ToString() : "";

                    #endregion
                }

                if (caseHandleDt != null && caseHandleDt.Rows.Count > 0 || (oldTotalData != null && oldTotalData.Rows.Count > 0))
                {
                    #region 违章处理小项

                    //该类似代码仅用于2015年累计统计
                    int oldCase00090001 = 0,
                        oldCase00090002 = 0,
                        oldCase00090003 = 0,
                        oldCase00090004 = 0,
                        oldCase00090005 = 0,
                        oldCase00090006 = 0,
                        oldCase00090007 = 0,
                        oldCase00090008 = 0;

                    double oldCase00090001Money = 0,
                        oldCase00090002Money = 0,
                        oldCase00090003Money = 0,
                        oldCase00090004Money = 0,
                        oldCase00090005Money = 0,
                        oldCase00090006Money = 0,
                        oldCase00090007Money = 0,
                        oldCase00090008Money = 0;

                    if (oldTotalData != null && oldTotalData.Rows.Count > 0)
                    {
                        var oldTotalRow = oldTotalData.Rows[0];
                        oldCase00090001 = int.Parse(oldTotalRow["Case_00090001"].ToString());
                        oldCase00090002 = int.Parse(oldTotalRow["Case_00090002"].ToString());
                        oldCase00090003 = int.Parse(oldTotalRow["Case_00090003"].ToString());
                        oldCase00090004 = int.Parse(oldTotalRow["Case_00090004"].ToString());
                        oldCase00090005 = int.Parse(oldTotalRow["Case_00090005"].ToString());
                        oldCase00090006 = int.Parse(oldTotalRow["Case_00090006"].ToString());
                        oldCase00090007 = int.Parse(oldTotalRow["Case_00090007"].ToString());
                        oldCase00090008 = int.Parse(oldTotalRow["Case_00090008"].ToString());

                        oldCase00090001Money = double.Parse(oldTotalRow["Case_00090001_Money"].ToString());
                        oldCase00090002Money = double.Parse(oldTotalRow["Case_00090002_Money"].ToString());
                        oldCase00090003Money = double.Parse(oldTotalRow["Case_00090003_Money"].ToString());
                        oldCase00090004Money = double.Parse(oldTotalRow["Case_00090004_Money"].ToString());
                        oldCase00090005Money = double.Parse(oldTotalRow["Case_00090005_Money"].ToString());
                        oldCase00090006Money = double.Parse(oldTotalRow["Case_00090006_Money"].ToString());
                        oldCase00090007Money = double.Parse(oldTotalRow["Case_00090007_Money"].ToString());
                        oldCase00090008Money = double.Parse(oldTotalRow["Case_00090008_Money"].ToString());
                    }

                    var caseTotalCount = 0;   //案件量小计
                    double caseTotalMoney = 0;   //罚款金额小计

                    var case00090001 = 0;      //案件数
                    double case00090001Money = 0; //罚款金额
                    var case00090001Rows = caseHandleDt.Select(string.Format("ClassNo='{0}'", "00090001"));
                    if (case00090001Rows.Length > 0)
                    {
                        case00090001 = int.Parse(case00090001Rows[0]["CaseCount"].ToString());
                        case00090001Money = Convert.ToDouble(case00090001Rows[0]["CFMoney"].ToString());
                    }
                    case00090001 += oldCase00090001;
                    case00090001Money += oldCase00090001Money;

                    var case00090002 = 0;
                    double case00090002Money = 0;
                    var case00090002Rows = caseHandleDt.Select(string.Format("ClassNo='{0}'", "00090002"));
                    if (case00090002Rows.Length > 0)
                    {
                        case00090002 = int.Parse(case00090002Rows[0]["CaseCount"].ToString());
                        case00090002Money = Convert.ToDouble(case00090002Rows[0]["CFMoney"].ToString());
                    }

                    case00090002 += oldCase00090002;
                    case00090002Money += oldCase00090002Money;

                    var case00090003 = 0;
                    double case00090003Money = 0;
                    var case00090003Rows = caseHandleDt.Select(string.Format("ClassNo='{0}'", "00090003"));
                    if (case00090003Rows.Length > 0)
                    {
                        case00090003 = int.Parse(case00090003Rows[0]["CaseCount"].ToString());
                        case00090003Money = Convert.ToDouble(case00090003Rows[0]["CFMoney"].ToString());
                    }
                    case00090003 += oldCase00090003;
                    case00090003Money += oldCase00090003Money;

                    var case00090004 = 0;
                    double case00090004Money = 0;
                    var case00090004Rows = caseHandleDt.Select(string.Format("ClassNo='{0}'", "00090004"));
                    if (case00090004Rows.Length > 0)
                    {
                        case00090004 = int.Parse(case00090004Rows[0]["CaseCount"].ToString());
                        case00090004Money = Convert.ToDouble(case00090004Rows[0]["CFMoney"].ToString());
                    }

                    case00090004 += oldCase00090004;
                    case00090004Money += oldCase00090004Money;

                    var case00090005 = 0;
                    double case00090005Money = 0;
                    var case00090005Rows = caseHandleDt.Select(string.Format("ClassNo='{0}'", "00090005"));
                    if (case00090005Rows.Length > 0)
                    {
                        case00090005 = int.Parse(case00090005Rows[0]["CaseCount"].ToString());
                        case00090005Money = Convert.ToDouble(case00090005Rows[0]["CFMoney"].ToString());
                    }
                    case00090005 += oldCase00090005;
                    case00090005Money += oldCase00090005Money;

                    var case00090006 = 0;
                    double case00090006Money = 0;
                    var case00090006Rows = caseHandleDt.Select(string.Format("ClassNo='{0}'", "00090006"));
                    if (case00090006Rows.Length > 0)
                    {
                        case00090006 = int.Parse(case00090006Rows[0]["CaseCount"].ToString());
                        case00090006Money = Convert.ToDouble(case00090006Rows[0]["CFMoney"].ToString());
                    }
                    case00090006 += oldCase00090006;
                    case00090006Money += oldCase00090006Money;

                    var case00090007 = 0;
                    double case00090007Money = 0;
                    var case00090007Rows = caseHandleDt.Select(string.Format("ClassNo='{0}'", "00090007"));
                    if (case00090007Rows.Length > 0)
                    {
                        case00090007 = int.Parse(case00090007Rows[0]["CaseCount"].ToString());
                        case00090007Money = Convert.ToDouble(case00090007Rows[0]["CFMoney"].ToString());
                    }
                    case00090007 += oldCase00090007;
                    case00090007Money += oldCase00090007Money;

                    var case00090008 = 0;
                    double case00090008Money = 0;
                    var case00090008Rows = caseHandleDt.Select(string.Format("ClassNo='{0}'", "00090008"));
                    if (case00090008Rows.Length > 0)
                    {
                        case00090008 = int.Parse(case00090008Rows[0]["CaseCount"].ToString());
                        case00090008Money = Convert.ToDouble(case00090008Rows[0]["CFMoney"].ToString());
                    }
                    case00090008 += oldCase00090008;
                    case00090008Money += oldCase00090008Money;

                    caseTotalCount = case00090001 + case00090002 + case00090003 + case00090004 + case00090005 +
                                     case00090006 + case00090007 + case00090008;
                    caseTotalMoney = case00090001Money + case00090002Money + case00090003Money + case00090004Money +
                                     case00090005Money + case00090006Money + case00090007Money + case00090008Money;

                    nRow["Case_00090001"] = case00090001 > 0 ? case00090001.ToString() : "";
                    nRow["Case_00090002"] = case00090002 > 0 ? case00090002.ToString() : "";
                    nRow["Case_00090003"] = case00090003 > 0 ? case00090003.ToString() : "";
                    nRow["Case_00090004"] = case00090004 > 0 ? case00090004.ToString() : "";
                    nRow["Case_00090005"] = case00090005 > 0 ? case00090005.ToString() : "";
                    nRow["Case_00090006"] = case00090006 > 0 ? case00090006.ToString() : "";
                    nRow["Case_00090007"] = case00090007 > 0 ? case00090007.ToString() : "";
                    nRow["Case_00090008"] = case00090008 > 0 ? case00090008.ToString() : "";
                    nRow["Case_TotalCount"] = caseTotalCount > 0 ? caseTotalCount.ToString() : "";


                    //nRow["Case_00090001_Money"] = case00090001Money > 0 ? case00090001Money.ToString() : "";
                    //nRow["Case_00090002_Money"] = case00090002Money > 0 ? case00090002Money.ToString() : "";
                    //nRow["Case_00090003_Money"] = case00090003Money > 0 ? case00090003Money.ToString() : "";
                    //nRow["Case_00090004_Money"] = case00090004Money > 0 ? case00090004Money.ToString() : "";
                    //nRow["Case_00090005_Money"] = case00090005Money > 0 ? case00090005Money.ToString() : "";
                    //nRow["Case_00090006_Money"] = case00090006Money > 0 ? case00090006Money.ToString() : "";
                    //nRow["Case_00090007_Money"] = case00090007Money > 0 ? case00090007Money.ToString() : "";
                    //nRow["Case_00090008_Money"] = case00090008Money > 0 ? case00090008Money.ToString() : "";
                    //nRow["Case_TotalMoney"] = caseTotalMoney > 0 ? caseTotalMoney.ToString() : "";


                    nRow["Case_00090001_Money"] = case00090001Money > 0 ? Convert.ToString(case00090001Money) : "";
                    nRow["Case_00090002_Money"] = case00090002Money > 0 ? Convert.ToString(case00090002Money) : "";
                    nRow["Case_00090003_Money"] = case00090003Money > 0 ? Convert.ToString(case00090003Money) : "";
                    nRow["Case_00090004_Money"] = case00090004Money > 0 ? Convert.ToString(case00090004Money) : "";
                    nRow["Case_00090005_Money"] = case00090005Money > 0 ? Convert.ToString(case00090005Money) : "";
                    nRow["Case_00090006_Money"] = case00090006Money > 0 ? Convert.ToString(case00090006Money) : "";
                    nRow["Case_00090007_Money"] = case00090007Money > 0 ? Convert.ToString(case00090007Money) : "";
                    nRow["Case_00090008_Money"] = case00090008Money > 0 ? Convert.ToString(case00090008Money) : "";
                    nRow["Case_TotalMoney"] = caseTotalMoney > 0 ? Convert.ToString(caseTotalMoney) : "";



                    #endregion

                    #region 结案数据与罚款所占比例

                    var doubleCaseTotalCount = Convert.ToDouble(caseTotalCount);
                    var doubleCaseTotalMoney = Convert.ToDouble(caseTotalMoney);
                    if (caseTotalCount > 0)
                    {
                        if (case00090001 > 0)
                            nRow["CaseCloseProportion_00090001"] = Math.Round(case00090001 / doubleCaseTotalCount * 100, 2) + "%";
                        if (case00090002 > 0)
                            nRow["CaseCloseProportion_00090002"] = Math.Round(case00090002 / doubleCaseTotalCount * 100, 2) + "%";
                        if (case00090003 > 0)
                            nRow["CaseCloseProportion_00090003"] = Math.Round(case00090003 / doubleCaseTotalCount * 100, 2) + "%";
                        if (case00090004 > 0)
                            nRow["CaseCloseProportion_00090004"] = Math.Round(case00090004 / doubleCaseTotalCount * 100, 2) + "%";
                        if (case00090005 > 0)
                            nRow["CaseCloseProportion_00090005"] = Math.Round(case00090005 / doubleCaseTotalCount * 100, 2) + "%";
                        if (case00090006 > 0)
                            nRow["CaseCloseProportion_00090006"] = Math.Round(case00090006 / doubleCaseTotalCount * 100, 2) + "%";
                        if (case00090007 > 0)
                            nRow["CaseCloseProportion_00090007"] = Math.Round(case00090007 / doubleCaseTotalCount * 100, 2) + "%";
                        if (case00090008 > 0)
                            nRow["CaseCloseProportion_00090008"] = Math.Round(case00090008 / doubleCaseTotalCount * 100, 2) + "%";
                    }

                    if (caseTotalMoney > 0)
                    {
                        if (case00090001Money > 0)
                            nRow["PunishMoneyProportion_00090001"] = Math.Round(case00090001Money / doubleCaseTotalMoney * 100, 2) + "%";
                        if (case00090002Money > 0)
                            nRow["PunishMoneyProportion_00090002"] = Math.Round(case00090002Money / doubleCaseTotalMoney * 100, 2) + "%";
                        if (case00090003Money > 0)
                            nRow["PunishMoneyProportion_00090003"] = Math.Round(case00090003Money / doubleCaseTotalMoney * 100, 2) + "%";
                        if (case00090004Money > 0)
                            nRow["PunishMoneyProportion_00090004"] = Math.Round(case00090004Money / doubleCaseTotalMoney * 100, 2) + "%";
                        if (case00090005Money > 0)
                            nRow["PunishMoneyProportion_00090005"] = Math.Round(case00090005Money / doubleCaseTotalMoney * 100, 2) + "%";
                        if (case00090006Money > 0)
                            nRow["PunishMoneyProportion_00090006"] = Math.Round(case00090006Money / doubleCaseTotalMoney * 100, 2) + "%";
                        if (case00090007Money > 0)
                            nRow["PunishMoneyProportion_00090007"] = Math.Round(case00090007Money / doubleCaseTotalMoney * 100, 2) + "%";
                        if (case00090008Money > 0)
                            nRow["PunishMoneyProportion_00090008"] = Math.Round(case00090008Money / doubleCaseTotalMoney * 100, 2) + "%";
                    }

                    #endregion
                }

                if (caseHandleByProcess != null && caseHandleByProcess.Rows.Count > 0 || (oldTotalData != null && oldTotalData.Rows.Count > 0))
                {
                    #region 简易、一般案件量及罚款金额小计

                    var punishRows = caseHandleByProcess.Select(string.Format("PunishProcess IN ({0})", "'00280002','00280003'"));  //一般案件（包含重大案件）
                    var simpleRows = caseHandleByProcess.Select(string.Format("PunishProcess='{0}'", "00280001"));  //简易案件
                    var punishCount = 0;
                    double punishMoney = 0;
                    var simpleCount = 0;
                    double simpleMoney = 0;
                    if (punishRows.Length > 0)
                    {
                        foreach (var punishRow in punishRows)
                        {
                            punishCount += int.Parse(punishRow["CaseCount"].ToString());
                            punishMoney += Convert.ToDouble(punishRow["CFMoney"].ToString());
                        }
                    }
                    if (simpleRows.Length > 0)
                    {
                        simpleCount = int.Parse(simpleRows[0]["CaseCount"].ToString());
                        simpleMoney = Convert.ToDouble(simpleRows[0]["CFMoney"].ToString());
                    }

                    //该类似代码仅用于2015年累计统计
                    int oldCasePunish = 0; double oldCasePunishMoney = 0;
                    int oldCaseSimple = 0; double oldCaseSimpleMoney = 0;
                    if (oldTotalData != null && oldTotalData.Rows.Count > 0)
                    {
                        var oldTotalRow = oldTotalData.Rows[0];
                        oldCasePunish = int.Parse(oldTotalRow["Case_Punish"].ToString());
                        oldCasePunishMoney = Convert.ToDouble(oldTotalRow["Case_PunishMoney"].ToString());
                        oldCaseSimple = int.Parse(oldTotalRow["Case_Simple"].ToString());
                        oldCaseSimpleMoney = Convert.ToDouble(oldTotalRow["Case_SimpleMoney"].ToString());
                    }

                    punishCount += oldCasePunish;
                    punishMoney += oldCasePunishMoney;
                    simpleCount += oldCaseSimple;
                    simpleMoney += oldCaseSimpleMoney;

                    //一般、简易案件量及处理金额
                    nRow["Case_Punish"] = punishCount > 0 ? punishCount.ToString() : "";      //一般
                    nRow["Case_PunishMoney"] = punishMoney > 0 ? Convert.ToString(punishMoney) : ""; //一般罚款
                    nRow["Case_Simple"] = simpleCount > 0 ? simpleCount.ToString() : "";      //简易
                    nRow["Case_SimpleMoney"] = simpleMoney > 0 ? Convert.ToString(simpleMoney) : ""; //简易罚款

                    #endregion
                }

                if (dismantleBdDt != null && dismantleBdDt.Rows.Count > 0)
                {
                    #region 违章搭建

                    var dismantleBdCount = 0;
                    double dismantleBdArea = 0;

                    dismantleBdCount = int.Parse(dismantleBdDt.Rows[0]["Number"].ToString());
                    dismantleBdArea = double.Parse(dismantleBdDt.Rows[0]["Area"].ToString());

                    //该类似代码仅用于2015年累计统计
                    int oldDismantleBdCount = 0, oldDismantleBdArea = 0;
                    if (oldTotalData != null && oldTotalData.Rows.Count > 0)
                    {
                        var oldTotalRow = oldTotalData.Rows[0];
                        oldDismantleBdCount = int.Parse(oldTotalRow["DismantleBdCount"].ToString());
                        oldDismantleBdArea = int.Parse(oldTotalRow["DismantleBdArea"].ToString());
                    }
                    dismantleBdCount += oldDismantleBdCount;
                    dismantleBdArea += oldDismantleBdArea;

                    dismantleBdArea = Math.Round(dismantleBdArea, 2);
                    nRow["DismantleBdCount"] = dismantleBdCount > 0 ? dismantleBdCount.ToString() : "";
                    nRow["DismantleBdArea"] = dismantleBdArea > 0 ? String.Format("{0:F}", dismantleBdArea) : "";

                    #endregion
                }

                if (dismantleAdDt != null && dismantleAdDt.Rows.Count > 0)
                {
                    #region 拆除广告

                    var dismantleAdCount = 0;
                    double dismantleAdArea = 0;

                    dismantleAdCount = int.Parse(dismantleAdDt.Rows[0]["Number"].ToString());
                    dismantleAdArea = double.Parse(dismantleAdDt.Rows[0]["Area"].ToString());

                    //该类似代码仅用于2015年累计统计
                    int oldDismantleAdCount = 0, oldDismantleAdArea = 0;
                    if (oldTotalData != null && oldTotalData.Rows.Count > 0)
                    {
                        var oldTotalRow = oldTotalData.Rows[0];
                        oldDismantleAdCount = int.Parse(oldTotalRow["DismantleAdCount"].ToString());
                        oldDismantleAdArea = int.Parse(oldTotalRow["DismantleAdArea"].ToString());
                    }
                    dismantleAdCount += oldDismantleAdCount;
                    dismantleAdArea += oldDismantleAdArea;


                    nRow["DismantleAdCount"] = dismantleAdCount > 0 ? dismantleAdCount.ToString() : "";
                    nRow["DismantleAdArea"] = dismantleAdArea > 0 ? String.Format("{0:F}", dismantleAdArea) : "";

                    #endregion
                }

                sumaryDt.Rows.Add(nRow);
                return sumaryDt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 执法月报表
        /// 添加人：周 鹏
        /// 添加时间：2017-03-17
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <returns>DataTable.</returns>
        public DataTable CarReport(string companyId, string deptId, string startTime, string endTime)
        {
            try
            {
                var reportData = _caseReportDal.GetCarReport(companyId, deptId, startTime, endTime);


                if (reportData != null && reportData.Rows.Count > 0)
                {
                    var nRow = reportData.NewRow();  //添加一行


                    int totalPDADJ = 0,
                        totalDNDJ = 0,
                        totalYDSH = 0,
                        totalYSHT = 0,
                        totalYZF = 0,
                        totalYZDSH = 0,
                        totalSDSH = 0,
                        totalSTG = 0,
                        totalSWTG = 0,
                        totalCL = 0,
                        totalJY = 0,
                        totalYJ = 0,
                        totalDYJ = 0;

                    foreach (DataRow row in reportData.Rows)
                    {
                        var PDADJ = int.Parse(row["PDADJ"].ToString());
                        var DNDJ = int.Parse(row["DNDJ"].ToString());
                        var YDSH = int.Parse(row["YDSH"].ToString());
                        var YSHT = int.Parse(row["YSHT"].ToString());
                        var YZF = int.Parse(row["YZF"].ToString());
                        var YZDSH = int.Parse(row["YZDSH"].ToString());
                        var SDSH = int.Parse(row["SDSH"].ToString());
                        var STG = int.Parse(row["STG"].ToString());
                        var SWTG = int.Parse(row["SWTG"].ToString());
                        var CL = int.Parse(row["CL"].ToString());
                        var JY = int.Parse(row["JY"].ToString());
                        var YJ = int.Parse(row["YJ"].ToString());
                        var DYJ = int.Parse(row["DYJ"].ToString());

                        totalPDADJ += PDADJ;
                        totalDNDJ += DNDJ;
                        totalYDSH += YDSH;
                        totalYSHT += YSHT;
                        totalYZF += YZF;
                        totalYZDSH += YZDSH;
                        totalSDSH += SDSH;
                        totalSTG += STG;
                        totalSWTG += SWTG;
                        totalCL += CL;
                        totalJY += JY;
                        totalYJ += YJ;
                        totalDYJ += DYJ;
                    }

                    nRow["Id"] = "totalRow";
                    nRow["DepartmentName"] = "合计";
                    nRow["PDADJ"] = totalPDADJ;
                    nRow["DNDJ"] = totalDNDJ;
                    nRow["YDSH"] = totalYDSH;
                    nRow["YSHT"] = totalYSHT;
                    nRow["YZF"] = totalYZF;
                    nRow["YZDSH"] = totalYZDSH;
                    nRow["SDSH"] = totalSDSH;
                    nRow["STG"] = totalSTG;
                    nRow["SWTG"] = totalSWTG;
                    nRow["CL"] = totalCL;
                    nRow["JY"] = totalJY;
                    nRow["YJ"] = totalYJ;
                    nRow["DYJ"] = totalDYJ;

                    reportData.Rows.Add(nRow);
                }
                return reportData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
