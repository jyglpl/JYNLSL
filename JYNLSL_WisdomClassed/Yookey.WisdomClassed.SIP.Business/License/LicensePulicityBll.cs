//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicensePulicityBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：城程游
//  作    者：周 鹏
//  创建日期：2017/11/30 13:27:37
//  功能描述：LicensePulicity业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.License;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.License;

namespace Yookey.WisdomClassed.SIP.Business.License
{
    /// <summary>
    /// LicensePulicity业务逻辑
    /// </summary>
    public class LicensePulicityBll : BaseBll<LicensePulicityEntity>
    {
        public LicensePulicityBll()
        {
            BaseDal = new LicensePulicityDal();
        }

        /// <summary>
        /// 许可公示数据查询
        /// </summary>
        /// <history>
        /// </history>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryLicensePulicitylist(string keyword, int pageSize,
                                       int pageIndex, string sidx, string sord)
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                int totalRecords;
                var data = new LicensePulicityDal().QueryLicensePulicitylist(keyword, pageSize, pageIndex, sidx, sord, out totalRecords);
                data.TableName = "CaseDT";
                stopwatch.Stop();
                var totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
                return new PageJqDatagrid<DataTable>
                {
                    page = pageIndex,
                    rows = data,
                    total = totalPage,
                    records = totalRecords,
                    costtime = stopwatch.ElapsedMilliseconds.ToString()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 批量保存处罚公示数据
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public bool TransactionSaveLicensePulicity(List<LicensePulicityEntity> lists)
        {
            try
            {
                return new LicensePulicityDal().TransactionSaveLicensePulicity(lists);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 从许可系统中同步许可的数据
        /// </summary>
        /// <returns></returns>
        public bool SyncLicensePulicityFormSystem()
        {
            try
            {
                var LicensePulicityData = new LicenseMainDal().GetUnPublicLicensePulicity();   //获取未同步的处罚数据
                if (LicensePulicityData != null && LicensePulicityData.Rows.Count > 0)
                {
                    var list = (from DataRow row in LicensePulicityData.Rows
                                select new LicensePulicityEntity()
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    LicenseId = row["Id"].ToString(),
                                    XK_WSH = row["XK_WSH"].ToString(),
                                    XK_XMMC = row["XK_XMMC"].ToString(),
                                    XK_BM = row["XK_BM"].ToString(),
                                    XK_NR = row["XK_NR"].ToString(),
                                    XK_XDR = row["XK_XDR"].ToString(),
                                    XK_XDR_SHXYM = row["XK_XDR_SHXYM"].ToString(),
                                    XK_XDR_ZDM = row["XK_XDR_ZDM"].ToString(),
                                    XK_XDR_GSDJ = row["XK_XDR_GSDJ"].ToString(),
                                    XK_XDR_SFZ = row["XK_XDR_SFZ"].ToString(),
                                    XK_FR = row["XK_FR"].ToString(),
                                    XK_JDRQ =Convert.ToDateTime(row["XK_JDRQ"].ToString()),
                                    XK_JZQ = Convert.ToDateTime(row["XK_JZQ"].ToString()),
                                    XK_XZJG = row["XK_XZJG"].ToString(),
                                    XK_ZT = row["XK_ZT"].ToString(),
                                    XK_SYFW = row["FW"].ToString(),                                   
                                    DFBM = "320508",
                                    SJC = DateTime.Now,
                                    WhetherPublic = 1,
                                    IsPush = 0,
                                    RowStatus = 1,
                                    CreateOn = DateTime.Now,
                                    UpdateOn = DateTime.Now
                                }).ToList();

                    return TransactionSaveLicensePulicity(list);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 推送处罚公示数据
        /// </summary>
        /// <returns></returns>
        public bool PushLicensePulicity()
        {
            try
            {
                var LicensePulicityData = new LicensePulicityDal().GetUnPushPunishments();
                return new LicensePulicityDal().TransactionPushPunishment(LicensePulicityData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
