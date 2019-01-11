using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BasePetaPoco;
using Yookey.WisdomClassed.SIP.DataAccess.GridManagement;
using Yookey.WisdomClassed.SIP.Model.GridManagement;

namespace Yookey.WisdomClassed.SIP.Business.GridManagement
{
    public class GridManagementFileScoreInfoBll : BaseBll<GridManagementFileScoreInfoEntity>
    {
        readonly GridManagementFileScoreInfoDal _dal = new GridManagementFileScoreInfoDal();

        /// <summary>
        /// 获取已扣分的年度
        /// </summary>
        /// <returns></returns>
        public DataTable GetYears()
        {
            try
            {
                return new GridManagementFileScoreInfoDal().GetYears();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据年份获取已扣分的季度
        /// </summary>
        /// <returns></returns>
        public DataTable GetQuarters(int year)
        {
            try
            {
                return new GridManagementFileScoreInfoDal().GetQuarters(year);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询各个区域扣分情况
        /// </summary>
        /// <param name="year">所属年度</param>
        /// <param name="quarter">所属季度</param> 
        /// <returns></returns>
        public DataTable GetData(int year, int quarter)
        {
            try
            {
                return _dal.GetData(year, quarter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询各个网格扣分情况
        /// </summary>
        /// <param name="year">所属年度</param>
        /// <param name="quarter">所属季度</param>
        /// <returns></returns>
        public DataTable GetGmData(int year, int quarter)
        {
            try
            {
                return _dal.GetGmData(year, quarter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询扣分详情Top10
        /// </summary>
        /// <param name="year">所属年度</param>
        /// <param name="quarter">所属季度</param>
        /// <returns></returns>
        public DataTable GetDataTable(int year, int quarter)
        {
            try
            {
                return _dal.GetDataTable(year, quarter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 扣分内容TOP
        /// </summary>
        /// <param name="year">所属年度</param>
        /// <param name="quarter">所属季度</param> 
        /// <returns></returns>
        public DataTable GetContentTop(int year, int quarter)
        {
            try
            {
                return _dal.GetContentTop(year, quarter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        /// <summary>
        /// 查询扣分详情列表
        /// </summary>
        /// <param name="year">所属年份</param>
        /// <param name="month">所属季度</param>
        /// <param name="keywords">查询关键字</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页请求条数</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> GetGradeData(int year, int month, string keywords, int pageIndex, int pageSize)
        {
            try
            {
                return _dal.GetGradeData(year, month, keywords, pageIndex, pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
