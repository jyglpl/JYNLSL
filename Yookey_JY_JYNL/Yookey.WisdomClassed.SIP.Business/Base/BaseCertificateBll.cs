//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Base_CertificateBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/3/18 14:51:40
//  功能描述：Base_Certificate业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Business.Base
{
    /// <summary>
    /// 执法证管理业务逻辑
    /// </summary>
    public class BaseCertificateBll : BaseBll<BaseCertificateEntity>
    {
        public BaseCertificateBll()
        {
            BaseDal = new BaseCertificateDal();
        }

        /// <summary>
        /// 查询证件管理类型
        /// </summary>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public DataTable GetCertificateType(string typeid)
        {
            return new BaseCertificateDal().GetCertificateType(typeid);
        }

        /// <summary>
        /// 判断用户有无此证件
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <param name="typeid">证件类型</param>
        /// <returns></returns>
        public int CheckHadCardByType(string uid, string typeid)
        {
            return new BaseCertificateDal().CheckHadCardByType(uid, typeid);
        }


        /// <summary>
        /// 根据用户编号查询详情实体
        /// 添加人：周 鹏
        /// 添加时间：2015-04-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">用户ID</param>
        /// <returns>BaseCertificateEntity.</returns>
        /// <exception cref="System.Exception"></exception>
        public BaseCertificateEntity GetEntityByUserId(string userId)
        {
            try
            {
                return new BaseCertificateDal().GetEntityByUserId(userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 执法证统计
        /// </summary>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> GetCertificateReport(string CardType, string Deptid, string LYTimeStart, string LYTimeEnd, string NJTimeStart, string NJTimeEnd, string HZTimeStart, string HZTimeEnd, int pageSize = 35, int pageIndex = 1)
        {
            int totalRecords = 1;
            var totalPage = (totalRecords + pageSize - 1) / pageSize;
            var data = new BaseCertificateDal().GetCertificateData(CardType, Deptid, LYTimeStart, LYTimeEnd, NJTimeStart, NJTimeEnd, HZTimeStart, HZTimeEnd, pageIndex, pageSize, out totalRecords);
            totalRecords = 35;
            var finalData = data.Clone();   //克隆一个数据表结构
            int sumJD = 0, sumZF = 0, sumZJ = 0;
            for (var i = 0; i < data.Rows.Count; i++)
            {
                var row = data.Rows[i];
                var Companyid = row["Companyid"].ToString();      //部门Id
                var jd = int.Parse(row["JDCounts"].ToString());
                var zf = int.Parse(row["ZFCounts"].ToString());
                var zj = int.Parse(row["counts"].ToString());

                finalData.Rows.Add(row.ItemArray);

                if (i < data.Rows.Count - 1)
                {
                    var nextCompanyid = data.Rows[i + 1]["Companyid"].ToString();    //下一条数据的部门编号
                    if (Companyid.Equals(nextCompanyid))
                    {
                        sumJD += jd;
                        sumZF += zf;
                        sumZJ += zj;

                    }
                    else
                    {
                        sumJD += jd;
                        sumZF += zf;
                        sumZJ += zj;

                        #region 计算合计
                        
                        var CompanyName = row["CompanyName"].ToString();
                        const string deptName = "合计";

                        var nRow = finalData.NewRow();
                        nRow["CompanyName"] = CompanyName;
                        nRow["DepartmentName"] = deptName;
                        nRow["Companyid"] = Companyid;
                        nRow["JDCounts"] = sumJD;
                        nRow["ZFCounts"] = sumZF;
                        nRow["counts"] = sumZJ;

                        sumJD = 0;
                        sumZF = 0;
                        sumZJ = 0;
                        finalData.Rows.Add(nRow);     //添加合计数据至表
                        #endregion

                    }
                }
                else
                {
                    sumJD += jd;
                    sumZF += zf;
                    sumZJ += zj;

                    #region 计算合计
                    var CompanyName = row["CompanyName"].ToString();
                    const string deptName = "合计";

                    var nRow = finalData.NewRow();
                    nRow["CompanyName"] = CompanyName;
                    nRow["DepartmentName"] = deptName;
                    nRow["Companyid"] = Companyid;
                    nRow["JDCounts"] = sumJD;
                    nRow["ZFCounts"] = sumZF;
                    nRow["counts"] = sumZJ;

                    sumJD = 0;
                    sumZF = 0;
                    sumZJ = 0;
                    finalData.Rows.Add(nRow);     //添加合计数据至表

                    #endregion
                }
            }
            return new PageJqDatagrid<DataTable>
            {
                page = pageIndex,
                rows = finalData,
                total = totalPage,
                records = totalRecords,
            };
        }
    }
}
