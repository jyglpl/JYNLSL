//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_CAR_CHECKSIGNBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/22 16:26:18
//  功能描述：INF_CAR_CHECKSIGN业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Case;
using System.Linq;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// INF_CAR_CHECKSIGN业务逻辑
    /// </summary>
    public class InfCarChecksignBll : BaseBll<InfCarChecksignEntity>
    {
        public InfCarChecksignBll()
        {
            BaseDal = new InfCarChecksignDal();
        }

        /// <summary>
        /// 获取数据列表
        /// 添加人：张 晖
        /// 添加时间：2014-12-22
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        ///           2015-04-03 周 鹏 修改数据源
        /// </hisotry>
        /// <param name="search">查询实体</param>
        /// <param name="qType">查询类型：未审批、作废审批</param>
        /// <returns></returns>
        public PageJqDatagrid<CarList> GetSearchResult(CarList search, string qType)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var data = new InfCarChecksignDal().GetSearchResult(search, qType);
            var list = ConvertListHelper<CarList>.ConvertToList(data);
            foreach (var entity in list)
            {
                var day = AppConfig.DayYJ - (DateTime.Now - entity.CheckDate).Days;
                entity.DayNum = day <= 0 ? 0 : day;
            }
            stopwatch.Stop();
            return new PageJqDatagrid<CarList>
            {
                page = 1,
                rows = list,
                total = 1,
                records = list.Count,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }


        /// <summary>
        /// 违章停车数据查询
        /// 添加人：周 鹏
        /// 添加时间：2015-04-07
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="carNo">车牌号码</param>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">所属部门</param>
        /// <param name="state">查询状态</param>
        /// <param name="startDate">查询开始时间</param>
        /// <param name="endDate">查询截止时间</param>
        /// <param name="noticeNo">通知书编号</param>
        /// <param name="caseinfoNo">案件编号</param>
        /// <param name="address">地点</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> GetSearchResult(string carNo, string companyId, string deptId, string state, string startDate, string endDate, string noticeNo, string caseinfoNo, string address, int pageIndex, int pageSize, string sidx, string sord)
        {
            int totalRecords;
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var data = new InfCarChecksignDal().GetSearchResult(carNo, companyId, deptId, state, startDate, endDate, noticeNo, caseinfoNo, address, pageIndex, pageSize, sidx, sord, out totalRecords);
            int totalPage = (totalRecords + pageSize - 1) / pageSize;
            stopwatch.Stop();
            return new PageJqDatagrid<DataTable>
            {
                page = pageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        public int GetParkingCount(string startTime, string endTime)
        {
            return new InfCarChecksignDal().GetParkingCount(startTime, endTime);
        }

        public List<InfCarChecksignEntity> GetCommonQury(string caseWhere, string carWhere, int pageIndex, int pageSzie, out int totalRecord)
        {
            return new InfCarChecksignDal().GetCommonQury(caseWhere, carWhere, pageIndex, pageSzie, out totalRecord);
        }

        /// <summary>
        /// 获取数据列表
        /// 添加人：张晖
        /// 添加时间：2014-1-8
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>

        /// <returns></returns>
        public PageJqDatagrid<InfCarChecksignEntity> GetQuery(string caseWhere, string carWhere, int pageSzie = 15, int pageIndex = 1)
        {

            int totalRecord = 0;
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = GetCommonQury(caseWhere, carWhere, pageIndex, pageSzie, out totalRecord);

            int totalPage = (totalRecord + pageSzie - 1) / pageSzie;
            stopwatch.Stop();

            return new PageJqDatagrid<InfCarChecksignEntity>
            {
                page = pageIndex,
                rows = result,
                total = totalPage,
                records = totalRecord,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }


        /// <summary>
        /// 查询照片的详细信息
        /// 添加人：周 鹏
        /// 添加时间：2015-04-10
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="fileId">照片ID信息</param>
        /// <returns>DataTable.</returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable QueryPhotoDetails(string fileId)
        {
            try
            {
                return new InfCarChecksignDal().QueryPhotoDetails(fileId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据车牌号码进行查询【用于手机端】
        /// 添加人：周 鹏
        /// 添加时间：2015-05-15
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="fileViewLink">附件预览地址</param>
        /// <param name="carNo">车牌号码</param>
        /// <returns>DataTable Columns->CarNo CheckDate CheckSignAddress FileView</returns>
        public DataTable MobileGetSearchResult(string fileViewLink, string carNo)
        {
            try
            {
                carNo = carNo.ToUpper();
                return new InfCarChecksignDal().MobileGetSearchResult(fileViewLink, carNo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 请求违章停车详情
        /// 添加人：周 鹏
        /// 添加时间：2015-05-15
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">主键ID</param>
        /// <returns>DataTable.</returns>
        public DataTable MobileGetCarDetails(string id)
        {
            try
            {
                return new InfCarChecksignDal().MobileGetCarDetails(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<InfCarChecksignEntity> GetCarDetails(string No)
        {
            try
            {
                var queryCondition = QueryCondition.Instance.AddEqual(InfCarChecksignEntity.Parm_INF_CAR_CHECKSIGN_RowStatus, "1");
                if (!string.IsNullOrEmpty(No))
                {
                    queryCondition.AddEqual(InfCarChecksignEntity.Parm_INF_CAR_CHECKSIGN_CarNo, No);
                }
                return Query(queryCondition) as List<InfCarChecksignEntity>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取案件附件
        /// 添加人：周 鹏
        /// 添加时间：2015-05-19
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseinfoId">案件编号</param>
        /// <param name="fileViewLink"></param>
        /// <returns></returns>
        public DataTable GetFileList(string caseinfoId, string fileViewLink)
        {
            try
            {
                return new InfCarChecksignDal().GetFileList(caseinfoId, fileViewLink);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询违章停车处理数据
        /// 添加人：周 鹏
        /// 添加时间：2015-06-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="handleType">处理类型</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页请求条数</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryHandleGrid(string startTime, string endTime, string handleType, int pageIndex = 1,
                                         int pageSize = 15)
        {
            try
            {
                int totalRecord;
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var result = new InfCarChecksignDal().QueryHandleGrid(startTime, endTime, handleType, pageIndex, pageSize, out totalRecord);
                var totalPage = (totalRecord + pageSize - 1) / pageSize;

                stopwatch.Stop();
                return new PageJqDatagrid<DataTable>
                {
                    page = pageIndex,
                    rows = result,
                    total = totalPage,
                    records = totalRecord,
                    costtime = stopwatch.ElapsedMilliseconds.ToString()
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 验证是否重复贴单
        /// </summary>
        /// <param name="carNo">车牌号码</param>
        /// <param name="type">验证源：一级审核、二级审核</param>
        /// <returns></returns>
        public bool CheckRepeat(string carNo, string type)
        {
            return new InfCarChecksignDal().CheckRepeat(carNo, type);
        }

        /// <summary>
        /// 获取未处理的数据
        /// </summary>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <returns></returns>
        public DataTable GetUnYJ(string stime, string etime)
        {
            return new InfCarChecksignDal().GetUnYJ(stime, etime);
        }
    }
}
