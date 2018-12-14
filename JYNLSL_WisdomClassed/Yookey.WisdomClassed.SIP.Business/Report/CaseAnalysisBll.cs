using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.Base;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Report;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Business.Report
{
    /// <summary>
    /// 案件分析
    /// </summary>
    public class CaseAnalysisBll
    {
        readonly ComResourceBll _comResourceBll = new ComResourceBll();
        readonly BaseDepartmentBll _baseDepartmentBll = new BaseDepartmentBll();
        readonly CaseAnalysisDal _caseAnalysisDal = new CaseAnalysisDal();

        #region 按类型分析

        /// <summary>
        /// 按八大类统计出案件量
        /// 添加人：周 鹏
        /// 添加时间：2015-05-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-06-05 周 鹏 增加按时间区间
        /// </history>
        /// <param name="chartType">图表类型-> bar:柱状图,pie:饼图</param>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <param name="classNo">八大类所属类型</param>
        /// <returns>System.String.</returns>
        public string ReportChartByClass(string chartType, string type, string sTime = "", string eTime = "", string classNo = "", string caseType = "")
        {
            try
            {
                DateTime startTime;
                DateTime endTime;
                TimeInterval(type, sTime, eTime, out startTime, out  endTime);

                //查询数据
                var data = _caseAnalysisDal.GetCaseTotalByClasses(startTime.ToString(AppConst.DateFormat), endTime.ToString(AppConst.DateFormat), classNo, caseType);

                return AppendChart(chartType, data, "ClassName", "Total");
            }
            catch (Exception ex)
            {
                return "[[]]";
            }
        }
        #endregion

        #region 按案件类别

        /// <summary>
        /// 按案件类别统计出案件量
        /// 添加人：周 鹏
        /// 添加时间：2015-06-11
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="chartType">图表类型-> bar:柱状图,pie:饼图</param>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <returns>System.String.</returns>
        public string ReportCharByClassify(string chartType, string type, string sTime = "", string eTime = "")
        {
            try
            {
                DateTime startTime;
                DateTime endTime;
                TimeInterval(type, sTime, eTime, out startTime, out  endTime);

                //查询数据
                var data = _caseAnalysisDal.GetCaseTotalByClassify(startTime.ToString(AppConst.DateFormat), endTime.ToString(AppConst.DateFormat));

                return AppendChart(chartType, data, "CaseType", "Total");
            }
            catch (Exception ex)
            {
                return "[[]]";
            }
        }

        #endregion

        #region 按中队分析

        /// <summary>
        /// 按中队统计出案件量（柱状图）
        /// 添加人：周 鹏
        /// 添加时间：2015-05-25
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-06-05 周 鹏 增加按时间区间
        ///           2015-06-11 周 鹏 增加按分类统计
        /// </history>
        /// <param name="chartType">图表类型-> bar:柱状图,pie:饼图</param>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <param name="reportType">统计类型:Total 按总量, Classify 按类别</param>
        /// <returns>System.String.</returns>
        public string ReportByDept(string chartType, string type, string companyId, string deptId, string sTime = "", string eTime = "", string reportType = "Total")
        {
            try
            {
                DateTime startTime;
                DateTime endTime;
                TimeInterval(type, sTime, eTime, out startTime, out  endTime);
                //查询数据
                var data = _caseAnalysisDal.GetCaseTotalByDept(companyId, deptId, startTime.ToString(AppConst.DateFormat),
                                                               endTime.ToString(AppConst.DateFormat), reportType);

                if (reportType.Equals("Total"))         //按总量
                {
                    return AppendChart(chartType, data, "DeptName", "Total");
                }
                if (reportType.Equals("Classify"))      //按类型
                {
                    return AppendDeptClassifyChart(companyId, deptId, data);
                }
                if (reportType.Equals("Legislation"))  //按八大类
                {
                    return AppendDeptLegChart(companyId, deptId, data);
                }
                return "[[]]";
            }
            catch (Exception ex)
            {
                return "[[]]";
            }
        }

        /// <summary>
        /// 拼接按单位/中队分析,按类别JSON
        /// 添加人：周 鹏
        /// 添加时间：2015-06-11
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="data">数据源</param>
        /// <returns>System.String.</returns>
        private string AppendDeptClassifyChart(string companyId, string deptId, DataTable data)
        {
            var json = new StringBuilder("");
            try
            {
                var categories = new StringBuilder("");     //X轴 类型
                categories.Append("cate:[");
                var totalDetails = new StringBuilder("");   //Y轴 数据
                totalDetails.Append("data:[");

                var educationJson = new StringBuilder("");  //教育纠处
                var simpleCaseJson = new StringBuilder(""); //简易案件
                var carJson = new StringBuilder("");        //违法停车
                var punishCaseJson = new StringBuilder(""); //一般案件
                var tempCaseJson = new StringBuilder("");   //暂扣物品


                //var allDepts = _baseDepartmentBll.GetAllDetachment();   //所有中队

                if (!string.IsNullOrEmpty(companyId) && companyId.Equals("all"))        //按单位统计
                {
                    var allCompanys = new CrmCompanyBll().GetAllEnforcementUnit();
                    foreach (var crmCompanyEntity in allCompanys)
                    {
                        categories.AppendFormat("'{0}',", crmCompanyEntity.FullName);  //　添加至X轴

                        var educationRows = data.Select(string.Format("CaseType='{0}' AND CompanyId='{1}'", "现场纠处", crmCompanyEntity.Id));
                        var simpleCaseRows = data.Select(string.Format("CaseType='{0}' AND CompanyId='{1}'", "简易案件", crmCompanyEntity.Id));
                        var carCaseRows = data.Select(string.Format("CaseType='{0}' AND CompanyId='{1}'", "违法停车", crmCompanyEntity.Id));
                        var punishCaseRows = data.Select(string.Format("CaseType='{0}' AND CompanyId='{1}'", "一般案件", crmCompanyEntity.Id));
                        var tempCaseRows = data.Select(string.Format("CaseType='{0}' AND CompanyId='{1}'", "暂扣物品", crmCompanyEntity.Id));

                        //查询各中队的教育纠处、简易、一般、重大数量
                        var educationTotal = educationRows.Length > 0 ? educationRows[0]["Total"] : 0;
                        var simpleCaseTotal = simpleCaseRows.Length > 0 ? simpleCaseRows[0]["Total"] : 0;
                        var carCaseTotal = carCaseRows.Length > 0 ? carCaseRows[0]["Total"] : 0;
                        var punishCaseTotal = punishCaseRows.Length > 0 ? punishCaseRows[0]["Total"] : 0;
                        var tempCaseTotal = tempCaseRows.Length > 0 ? tempCaseRows[0]["Total"] : 0;


                        educationJson.AppendFormat("{0},", educationTotal);
                        simpleCaseJson.AppendFormat("{0},", simpleCaseTotal);
                        carJson.AppendFormat("{0},", carCaseTotal);
                        punishCaseJson.AppendFormat("{0},", punishCaseTotal);
                        tempCaseJson.AppendFormat("{0},", tempCaseTotal);
                    }
                }
                else
                {
                    //按中队统计

                    var allDepts = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity() { CompanyId = companyId });
                    if (!string.IsNullOrEmpty(deptId) && !deptId.Equals("all"))
                    {
                        allDepts = allDepts.Where(x => x.Id == deptId).ToList();
                    }

                    foreach (var baseDepartmentEntity in allDepts)
                    {
                        categories.AppendFormat("'{0}',", baseDepartmentEntity.FullName);  //　添加至X轴

                        var educationRows = data.Select(string.Format("CaseType='{0}' AND DeptId='{1}'", "现场纠处", baseDepartmentEntity.Id));
                        var simpleCaseRows = data.Select(string.Format("CaseType='{0}' AND DeptId='{1}'", "简易案件", baseDepartmentEntity.Id));
                        var carCaseRows = data.Select(string.Format("CaseType='{0}' AND DeptId='{1}'", "违法停车", baseDepartmentEntity.Id));
                        var punishCaseRows = data.Select(string.Format("CaseType='{0}' AND DeptId='{1}'", "一般案件", baseDepartmentEntity.Id));
                        var tempCaseRows = data.Select(string.Format("CaseType='{0}' AND DeptId='{1}'", "暂扣物品", baseDepartmentEntity.Id));

                        //查询各中队的教育纠处、简易、一般、重大数量
                        var educationTotal = educationRows.Length > 0 ? educationRows[0]["Total"] : 0;
                        var simpleCaseTotal = simpleCaseRows.Length > 0 ? simpleCaseRows[0]["Total"] : 0;
                        var carCaseTotal = carCaseRows.Length > 0 ? carCaseRows[0]["Total"] : 0;
                        var punishCaseTotal = punishCaseRows.Length > 0 ? punishCaseRows[0]["Total"] : 0;
                        var tempCaseTotal = tempCaseRows.Length > 0 ? tempCaseRows[0]["Total"] : 0;


                        educationJson.AppendFormat("{0},", educationTotal);
                        simpleCaseJson.AppendFormat("{0},", simpleCaseTotal);
                        carJson.AppendFormat("{0},", carCaseTotal);
                        punishCaseJson.AppendFormat("{0},", punishCaseTotal);
                        tempCaseJson.AppendFormat("{0},", tempCaseTotal);
                    }
                }

                totalDetails.Append("{");
                totalDetails.AppendFormat("name:'教育纠处',data:[{0}]", educationJson.Remove(educationJson.Length - 1, 1));  //格式移除最后一个“,”号
                totalDetails.Append("},");

                totalDetails.Append("{");
                totalDetails.AppendFormat("name:'简易案件',data:[{0}]", simpleCaseJson.Remove(simpleCaseJson.Length - 1, 1));  //格式移除最后一个“,”号
                totalDetails.Append("},");

                totalDetails.Append("{");
                totalDetails.AppendFormat("name:'违法停车',data:[{0}]", carJson.Remove(carJson.Length - 1, 1));             //格式移除最后一个“,”号
                totalDetails.Append("},");

                totalDetails.Append("{");
                totalDetails.AppendFormat("name:'一般案件',data:[{0}]", punishCaseJson.Remove(punishCaseJson.Length - 1, 1));  //格式移除最后一个“,”号
                totalDetails.Append("},");

                totalDetails.Append("{");
                totalDetails.AppendFormat("name:'暂扣物品',data:[{0}]", tempCaseJson.Remove(tempCaseJson.Length - 1, 1));  //格式移除最后一个“,”号
                totalDetails.Append("}");


                totalDetails.Append("]");
                categories.Append("]");
                json.Append("{" + categories + "," + totalDetails + "}");
            }
            catch (Exception ex)
            {
                return "[[]]";
            }
            return json.ToString();
        }

        /// <summary>
        /// 拼接按单位/中队分析,按八大类JSON
        /// 添加人：周 鹏
        /// 添加时间：2017-03-27
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">部门ID</param>
        /// <param name="data">数据源</param>
        /// <returns>System.String.</returns>
        private string AppendDeptLegChart(string companyId, string deptId, DataTable data)
        {
            var json = new StringBuilder("");
            try
            {
                var categories = new StringBuilder("");     //X轴 类型
                categories.Append("cate:[");
                var totalDetails = new StringBuilder("");   //Y轴 数据
                totalDetails.Append("data:[");

                var leg0001 = new StringBuilder("");              //市容环境卫生
                var leg0002 = new StringBuilder("");             //城市规划
                var leg0003 = new StringBuilder("");             //城市绿化
                var leg0004 = new StringBuilder("");             //市政设施
                var leg0005 = new StringBuilder("");             //公安交通
                var leg0006 = new StringBuilder("");             //工商行政管理
                var leg0007 = new StringBuilder("");             //环境保护
                var leg0008 = new StringBuilder("");             //水利水务

                if (!string.IsNullOrEmpty(companyId) && companyId.Equals("all")) //按单位统计
                {
                    var allCompanys = new CrmCompanyBll().GetAllEnforcementUnit();
                    foreach (var crmCompanyEntity in allCompanys)
                    {
                        categories.AppendFormat("'{0}',", crmCompanyEntity.FullName); //　添加至X轴

                        var leg0001Rows = data.Select(string.Format("ClassNo='{0}' AND CompanyId='{1}'", "00090001", crmCompanyEntity.Id));
                        var leg0002Rows = data.Select(string.Format("ClassNo='{0}' AND CompanyId='{1}'", "00090002", crmCompanyEntity.Id));
                        var leg0003Rows = data.Select(string.Format("ClassNo='{0}' AND CompanyId='{1}'", "00090003", crmCompanyEntity.Id));
                        var leg0004Rows = data.Select(string.Format("ClassNo='{0}' AND CompanyId='{1}'", "00090004", crmCompanyEntity.Id));
                        var leg0005Rows = data.Select(string.Format("ClassNo='{0}' AND CompanyId='{1}'", "00090005", crmCompanyEntity.Id));
                        var leg0006Rows = data.Select(string.Format("ClassNo='{0}' AND CompanyId='{1}'", "00090006", crmCompanyEntity.Id));
                        var leg0007Rows = data.Select(string.Format("ClassNo='{0}' AND CompanyId='{1}'", "00090007", crmCompanyEntity.Id));
                        var leg0008Rows = data.Select(string.Format("ClassNo='{0}' AND CompanyId='{1}'", "00090008", crmCompanyEntity.Id));


                        //查询各中队的八大类数据
                        var leg0001Total = leg0001Rows.Length > 0 ? leg0001Rows[0]["Total"] : 0;
                        var leg0002Total = leg0002Rows.Length > 0 ? leg0002Rows[0]["Total"] : 0;
                        var leg0003Total = leg0003Rows.Length > 0 ? leg0003Rows[0]["Total"] : 0;
                        var leg0004Total = leg0004Rows.Length > 0 ? leg0004Rows[0]["Total"] : 0;
                        var leg0005Total = leg0005Rows.Length > 0 ? leg0005Rows[0]["Total"] : 0;
                        var leg0006Total = leg0006Rows.Length > 0 ? leg0006Rows[0]["Total"] : 0;
                        var leg0007Total = leg0007Rows.Length > 0 ? leg0007Rows[0]["Total"] : 0;
                        var leg0008Total = leg0008Rows.Length > 0 ? leg0008Rows[0]["Total"] : 0;


                        leg0001.AppendFormat("{0},", leg0001Total);
                        leg0002.AppendFormat("{0},", leg0002Total);
                        leg0003.AppendFormat("{0},", leg0003Total);
                        leg0004.AppendFormat("{0},", leg0004Total);
                        leg0005.AppendFormat("{0},", leg0005Total);
                        leg0006.AppendFormat("{0},", leg0006Total);
                        leg0007.AppendFormat("{0},", leg0007Total);
                        leg0008.AppendFormat("{0},", leg0008Total);
                    }
                }
                else
                {
                    var allDepts = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity() { CompanyId = companyId });
                    if (!string.IsNullOrEmpty(deptId) && !deptId.Equals("all"))
                    {
                        allDepts = allDepts.Where(x => x.Id == deptId).ToList();
                    }

                    foreach (var baseDepartmentEntity in allDepts)
                    {
                        categories.AppendFormat("'{0}',", baseDepartmentEntity.FullName); //　添加至X轴

                        var leg0001Rows = data.Select(string.Format("ClassNo='{0}' AND DeptId='{1}'", "00090001", baseDepartmentEntity.Id));
                        var leg0002Rows = data.Select(string.Format("ClassNo='{0}' AND DeptId='{1}'", "00090002", baseDepartmentEntity.Id));
                        var leg0003Rows = data.Select(string.Format("ClassNo='{0}' AND DeptId='{1}'", "00090003", baseDepartmentEntity.Id));
                        var leg0004Rows = data.Select(string.Format("ClassNo='{0}' AND DeptId='{1}'", "00090004", baseDepartmentEntity.Id));
                        var leg0005Rows = data.Select(string.Format("ClassNo='{0}' AND DeptId='{1}'", "00090005", baseDepartmentEntity.Id));
                        var leg0006Rows = data.Select(string.Format("ClassNo='{0}' AND DeptId='{1}'", "00090006", baseDepartmentEntity.Id));
                        var leg0007Rows = data.Select(string.Format("ClassNo='{0}' AND DeptId='{1}'", "00090007", baseDepartmentEntity.Id));
                        var leg0008Rows = data.Select(string.Format("ClassNo='{0}' AND DeptId='{1}'", "00090008", baseDepartmentEntity.Id));


                        //查询各中队的八大类数据
                        var leg0001Total = leg0001Rows.Length > 0 ? leg0001Rows[0]["Total"] : 0;
                        var leg0002Total = leg0002Rows.Length > 0 ? leg0002Rows[0]["Total"] : 0;
                        var leg0003Total = leg0003Rows.Length > 0 ? leg0003Rows[0]["Total"] : 0;
                        var leg0004Total = leg0004Rows.Length > 0 ? leg0004Rows[0]["Total"] : 0;
                        var leg0005Total = leg0005Rows.Length > 0 ? leg0005Rows[0]["Total"] : 0;
                        var leg0006Total = leg0006Rows.Length > 0 ? leg0006Rows[0]["Total"] : 0;
                        var leg0007Total = leg0007Rows.Length > 0 ? leg0007Rows[0]["Total"] : 0;
                        var leg0008Total = leg0008Rows.Length > 0 ? leg0008Rows[0]["Total"] : 0;


                        leg0001.AppendFormat("{0},", leg0001Total);
                        leg0002.AppendFormat("{0},", leg0002Total);
                        leg0003.AppendFormat("{0},", leg0003Total);
                        leg0004.AppendFormat("{0},", leg0004Total);
                        leg0005.AppendFormat("{0},", leg0005Total);
                        leg0006.AppendFormat("{0},", leg0006Total);
                        leg0007.AppendFormat("{0},", leg0007Total);
                        leg0008.AppendFormat("{0},", leg0008Total);

                    }
                }
                totalDetails.Append("{");
                totalDetails.AppendFormat("name:'市容环境卫生',data:[{0}]", leg0001.Remove(leg0001.Length - 1, 1));  //格式移除最后一个“,”号
                totalDetails.Append("},");

                totalDetails.Append("{");
                totalDetails.AppendFormat("name:'城市规划',data:[{0}]", leg0002.Remove(leg0002.Length - 1, 1));  //格式移除最后一个“,”号
                totalDetails.Append("},");

                totalDetails.Append("{");
                totalDetails.AppendFormat("name:'城市绿化',data:[{0}]", leg0003.Remove(leg0003.Length - 1, 1));  //格式移除最后一个“,”号
                totalDetails.Append("},");

                totalDetails.Append("{");
                totalDetails.AppendFormat("name:'市政设施',data:[{0}]", leg0004.Remove(leg0004.Length - 1, 1));  //格式移除最后一个“,”号
                totalDetails.Append("},");

                totalDetails.Append("{");
                totalDetails.AppendFormat("name:'公安交通',data:[{0}]", leg0005.Remove(leg0005.Length - 1, 1));  //格式移除最后一个“,”号
                totalDetails.Append("},");

                totalDetails.Append("{");
                totalDetails.AppendFormat("name:'工商行政管理',data:[{0}]", leg0006.Remove(leg0006.Length - 1, 1));  //格式移除最后一个“,”号
                totalDetails.Append("},");

                totalDetails.Append("{");
                totalDetails.AppendFormat("name:'环境保护',data:[{0}]", leg0007.Remove(leg0007.Length - 1, 1));  //格式移除最后一个“,”号
                totalDetails.Append("},");

                totalDetails.Append("{");
                totalDetails.AppendFormat("name:'水利水务',data:[{0}]", leg0008.Remove(leg0008.Length - 1, 1));  //格式移除最后一个“,”号
                totalDetails.Append("}");


                totalDetails.Append("]");
                categories.Append("]");
                json.Append("{" + categories + "," + totalDetails + "}");
            }
            catch (Exception ex)
            {
                return "[[]]";
            }
            return json.ToString();
        }

        #endregion

        #region 按时间走势分析

        /// <summary>
        /// 按日期统计每月的案件量
        /// 添加人：周 鹏
        /// 添加时间：2015-06-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <param name="reportType">统计类型:Total 按总量, Classify 按类别</param>
        /// <returns>DataTable</returns>
        public string GetCaseTotalByDate(string type, string sTime = "", string eTime = "", string reportType = "Total")
        {
            try
            {
                DateTime startTime;
                DateTime endTime;
                TimeInterval(type, sTime, eTime, out startTime, out  endTime);
                //查询数据
                var data = _caseAnalysisDal.GetCaseTotalByDate(startTime.ToString(AppConst.DateFormat), endTime.ToString(AppConst.DateFormat), reportType);

                return AppendDataChart(data, startTime, endTime, reportType);
            }
            catch (Exception ex)
            {
                return "[[]]";
            }
        }

        /// <summary>
        /// 接接按时间趋势分析折线图
        /// 添加人：周 鹏
        /// 添加时间：2015-06-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="data">数据源</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="reportType">统计类型:Total 按总量, Classify 按类别</param>
        /// <returns>System.String.</returns>
        private string AppendDataChart(DataTable data, DateTime startTime, DateTime endTime, string reportType = "Total")
        {
            var json = new StringBuilder("");
            try
            {
                var categories = new StringBuilder("");     //X轴 类型
                categories.Append("cate:[");
                var totalDetails = new StringBuilder("");   //Y轴 数据
                totalDetails.Append("data:[");

                var caseTotalJson = new StringBuilder("");      //案件总量

                var educationJson = new StringBuilder("");      //现场纠处
                var simpleCaseJson = new StringBuilder("");     //简易案件
                var carCaseJson = new StringBuilder("");        //违法停车
                var punishCaseJson = new StringBuilder("");     //一般案件
                var tempCaseJson = new StringBuilder("");       //暂扣物品


                for (var dtN = startTime; dtN <= endTime; dtN = dtN.AddMonths(1))
                {
                    var date = dtN.ToString("yyyy") + "-" + dtN.ToString("MM");
                    categories.AppendFormat("'{0}',", dtN.ToString("yyyy-MM"));       //添加至X轴

                    if (reportType.Equals("Total"))
                    {
                        var dataRows = data.Select(string.Format("CaseDate='{0}'", date));
                        var caseTotal = dataRows.Length > 0 ? dataRows[0]["Total"] : 0;
                        caseTotalJson.AppendFormat("{0},", caseTotal);
                    }
                    else
                    {
                        var educationRows = data.Select(string.Format("CaseType='{0}' AND CaseDate='{1}'", "现场纠处", date));
                        var simpleCaseRows = data.Select(string.Format("CaseType='{0}' AND CaseDate='{1}'", "简易案件", date));
                        var carCaseRows = data.Select(string.Format("CaseType='{0}' AND CaseDate='{1}'", "违法停车", date));
                        var punishCaseRows = data.Select(string.Format("CaseType='{0}' AND CaseDate='{1}'", "一般案件", date));
                        var tempCaseRows = data.Select(string.Format("CaseType='{0}' AND CaseDate='{1}'", "暂扣物品", date));


                        //现场纠处、简易、一般、违停、暂扣
                        var educationTotal = educationRows.Length > 0 ? educationRows[0]["Total"] : 0;
                        var simpleCaseTotal = simpleCaseRows.Length > 0 ? simpleCaseRows[0]["Total"] : 0;
                        var punishCaseTotal = punishCaseRows.Length > 0 ? punishCaseRows[0]["Total"] : 0;
                        var carhCaseTotal = carCaseRows.Length > 0 ? carCaseRows[0]["Total"] : 0;
                        var tempCaseTotal = tempCaseRows.Length > 0 ? tempCaseRows[0]["Total"] : 0;


                        educationJson.AppendFormat("{0},", educationTotal);
                        simpleCaseJson.AppendFormat("{0},", simpleCaseTotal);
                        punishCaseJson.AppendFormat("{0},", punishCaseTotal);
                        carCaseJson.AppendFormat("{0},", carhCaseTotal);
                        tempCaseJson.AppendFormat("{0},", tempCaseTotal);
                    }
                }

                if (reportType.Equals("Total"))
                {
                    totalDetails.Append("{");
                    totalDetails.AppendFormat("name:'案件总量',data:[{0}]",
                                              caseTotalJson.Remove(caseTotalJson.Length - 1, 1)); //格式移除最后一个“,”号
                    totalDetails.Append("}");
                }
                else
                {
                    totalDetails.Append("{");
                    totalDetails.AppendFormat("name:'现场纠处',data:[{0}]", educationJson.Remove(educationJson.Length - 1, 1));  //格式移除最后一个“,”号
                    totalDetails.Append("},");

                    totalDetails.Append("{");
                    totalDetails.AppendFormat("name:'简易案件',data:[{0}]", simpleCaseJson.Remove(simpleCaseJson.Length - 1, 1));  //格式移除最后一个“,”号
                    totalDetails.Append("},");

                    totalDetails.Append("{");
                    totalDetails.AppendFormat("name:'违法停车',data:[{0}]", carCaseJson.Remove(carCaseJson.Length - 1, 1));      //格式移除最后一个“,”号
                    totalDetails.Append("},");

                    totalDetails.Append("{");
                    totalDetails.AppendFormat("name:'一般案件',data:[{0}]", punishCaseJson.Remove(punishCaseJson.Length - 1, 1));  //格式移除最后一个“,”号
                    totalDetails.Append("},");

                    totalDetails.Append("{");
                    totalDetails.AppendFormat("name:'暂扣物品',data:[{0}]", tempCaseJson.Remove(tempCaseJson.Length - 1, 1));       //格式移除最后一个“,”号
                    totalDetails.Append("}");
                }

                totalDetails.Append("]");
                categories.Append("]");
                json.Append("{" + categories + "," + totalDetails + "}");
            }
            catch (Exception ex)
            {
                return "[[]]";
            }
            return json.ToString();
        }


        #endregion

        #region 按处理情况

        /// <summary>
        /// 按处理情况
        /// 添加人：周 鹏
        /// 添加时间：2015-06-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="chartType">图表类型-> bar:柱状图,pie:饼图</param>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="caseType">案件类型</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <returns>System.String.</returns>
        public string ReportByHandle(string chartType, string type, string caseType, string sTime = "", string eTime = "")
        {
            try
            {
                DateTime startTime;
                DateTime endTime;
                TimeInterval(type, sTime, eTime, out startTime, out endTime);
                //查询数据
                var data = _caseAnalysisDal.GetCaseTotalByHandle(startTime.ToString(AppConst.DateFormat),
                                                               endTime.ToString(AppConst.DateFormat), caseType);

                return AppendChart(chartType, data, "HandleType", "Total");
            }
            catch (Exception ex)
            {
                return "[[]]";
            }
        }

        #endregion

        #region 按阶段分析
        /// <summary>
        /// 按八大类统计出案件量
        /// 添加人：周 鹏
        /// 添加时间：2015-06-11
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="chartType">图表类型-> bar:柱状图,pie:饼图</param>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <returns>System.String.</returns>
        public string ReportCharByStage(string chartType, string type, string sTime = "", string eTime = "")
        {
            try
            {
                DateTime startTime;
                DateTime endTime;
                TimeInterval(type, sTime, eTime, out startTime, out  endTime);

                //查询数据
                var data = _caseAnalysisDal.GetCaseTotalByStage(startTime.ToString(AppConst.DateFormat), endTime.ToString(AppConst.DateFormat));

                return AppendChart(chartType, data, "CaseProcess", "Total");
            }
            catch (Exception ex)
            {
                return "[[]]";
            }
        }
        #endregion

        #region 按城市顽疾
        /// <summary>
        /// 按城市顽疾
        /// 添加人：周 鹏
        /// 添加时间：2015-06-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="chartType">图表类型-> bar:柱状图,pie:饼图</param>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <returns>System.String.</returns>
        public string ReportCharByCityIlls(string chartType, string type, string sTime = "", string eTime = "")
        {
            try
            {
                DateTime startTime;
                DateTime endTime;
                TimeInterval(type, sTime, eTime, out startTime, out  endTime);

                //查询数据
                var data = _caseAnalysisDal.GetCaseTotalByCityIlls(startTime.ToString(AppConst.DateFormat), endTime.ToString(AppConst.DateFormat));

                return AppendChart(chartType, data, "CaseType", "Total");
            }
            catch (Exception ex)
            {
                return "[[]]";
            }
        }
        #endregion

        #region 通用方法

        /// <summary>
        /// 计算时间区间
        /// 添加人：周 鹏
        /// 添加时间：2015-06-05
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="type">类型：month 按月 week 按周 time 按时间区间</param>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">截止时间</param>
        /// <param name="startTime">计算后的开始时间</param>
        /// <param name="endTime">计算后的截止时间</param>
        public void TimeInterval(string type, string sTime, string eTime, out DateTime startTime, out DateTime endTime)
        {
            var dt = DateTime.Now;
            startTime = new DateTime();
            endTime = new DateTime();
            switch (type)
            {
                case "week":   //按周
                    {
                        startTime = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一
                        endTime = startTime.AddDays(6);  //本周周日
                    }
                    break;
                case "month":  //按月
                    {
                        startTime = dt.AddDays(1 - dt.Day);  //本月月初
                        endTime = startTime.AddMonths(1).AddDays(-1);  //本月月未
                    }
                    break;
                case "time":   //按时间区间
                    {
                        startTime = Convert.ToDateTime(sTime);
                        endTime = Convert.ToDateTime(eTime);
                    }
                    break;
            }
        }

        /// <summary>
        /// 拼接图表
        /// 添加人：周 鹏
        /// 添加时间：2015-06-05
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="chartType">图表类型-> bar:柱状图,pie:饼图</param>
        /// <param name="dataSource">数据源</param>
        /// <param name="columnName">显示名称</param>
        /// <param name="totalName">统计数据</param>
        /// <returns>System.String.</returns>
        public string AppendChart(string chartType, DataTable dataSource, string columnName, string totalName)
        {
            var json = new StringBuilder("");
            try
            {
                if (!string.IsNullOrEmpty(chartType) && dataSource != null && dataSource.Rows.Count > 0)
                {
                    if (chartType.Equals("bar"))      //按柱状图
                    {
                        var categories = new StringBuilder("");     //X轴 类型
                        categories.Append("cate:[");
                        var totalDetails = new StringBuilder("");   //Y轴 数据
                        totalDetails.Append("data:[");

                        foreach (DataRow row in dataSource.Rows)
                        {
                            categories.AppendFormat("'{0}',", row[columnName]);  //　添加至X轴
                            totalDetails.AppendFormat("{0},", row[totalName]);   //  添加至Y轴
                        }

                        categories.Remove(categories.Length - 1, 1);  //格式移除最后一个“,”号
                        totalDetails.Remove(totalDetails.Length - 1, 1);  //格式移除最后一个“,”号

                        totalDetails.Append("]");
                        categories.Append("]");
                        json.Append("{" + categories + "," + totalDetails + "}");
                    }
                    else if (chartType.Equals("pie")) //按饼图
                    {
                        var list = new List<string>();
                        list.AddRange(from DataRow row in dataSource.Rows select string.Format("['{0}',{1}]", row[columnName], row[totalName]));
                        json.Append("[" + string.Join(",", list.ToArray()) + "]");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return json.ToString();
        }


        #endregion

        #region 违法停车案件量按时间走势图

        /// <summary>
        /// 按日期统计每月的案件量
        /// 添加人：周 鹏
        /// 添加时间：2015-06-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public string GetCarTotalByDate()
        {
            var json = new StringBuilder("");
            try
            {
                var dateNow = DateTime.Now;     //当前时间
                var startTime = Convert.ToDateTime(dateNow.AddMonths(-5).ToString("yyyy-MM") + "-01");     //前5个月
                var endTime = Convert.ToDateTime(Convert.ToDateTime(dateNow.ToString("yyyy-MM") + "-01")  //后6个月
                           .AddMonths(7)
                           .AddDays(-1)
                           .ToString(AppConst.DateFormat));

                var data = _caseAnalysisDal.GetCarTotalByDate(startTime.ToString(AppConst.DateFormat), endTime.ToString(AppConst.DateFormat));

                var categories = new StringBuilder("");     //X轴 类型
                categories.Append("cate:[");
                var totalDetails = new StringBuilder("");   //Y轴 数据
                totalDetails.Append("data:[");

                var caseTotalJson = new StringBuilder("");      //案件总量


                for (var dtN = startTime; dtN <= endTime; dtN = dtN.AddMonths(1))
                {
                    var date = dtN.ToString("yyyy") + "-" + dtN.ToString("MM");
                    categories.AppendFormat("'{0}',", dtN.ToString("yyyy-MM"));       //添加至X轴

                    var dataRows = data.Select(string.Format("CaseDate='{0}'", date));
                    var caseTotal = dataRows.Length > 0 ? dataRows[0]["Total"] : 0;
                    caseTotalJson.AppendFormat("{0},", caseTotal);
                }

                totalDetails.Append("{");
                totalDetails.AppendFormat("name:'违法停车',data:[{0}]",
                                          caseTotalJson.Remove(caseTotalJson.Length - 1, 1)); //格式移除最后一个“,”号
                totalDetails.Append("}");

                totalDetails.Append("]");
                categories.Append("]");
                json.Append("{" + categories + "," + totalDetails + "}");

            }
            catch (Exception ex)
            {
                return "[[]]";
            }
            return json.ToString();
        }
        #endregion

    }
}

