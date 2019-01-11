//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseOutDoorBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/2/1 9:11:45
//  功能描述：LicenseOutDoor业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.License;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.License;

namespace Yookey.WisdomClassed.SIP.Business.License
{
    /// <summary>
    /// LicenseOutDoor业务逻辑
    /// </summary>
    public class LicenseOutDoorBll : BaseBll<LicenseOutDoorEntity>
    {
        /// <summary>
        /// 办件查询
        /// 添加人：周 鹏
        /// 添加时间：2018-02-02
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="keyword">查询关键字</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="pageIndex">查询索引页</param>
        /// <param name="sidx">排序字段</param>
        /// <param name="sord">排序方式</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> QueryApplicantInfoList(string keyword, int pageSize, int pageIndex, string sidx, string sord)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;

            var data = new LicenseOutDoorDal().QueryApplicantInfoList(keyword, pageSize, pageIndex, sidx, sord, out totalRecords);
           
            data.TableName = "LicenseData";
            stopwatch.Stop();
            int totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
            return new PageJqDatagrid<DataTable>
            {
                page = pageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        public LicenseOutDoorBll()
        {
            BaseDal = new LicenseOutDoorDal();
        }

        /// <summary>
        /// 使用事务保存户外广告
        /// 添加人：周 鹏 
        /// 添加时间：2018-02-02
        /// </summary>
        /// <param name="mainEntity">主信息实体</param>
        /// <param name="licenseOutDoorEntity">户外广告实体</param>
        /// <param name="specList">规则集合</param>
        /// <returns></returns>
        public bool TransactionSaveOutDoor(LicenseMainEntity mainEntity, LicenseOutDoorEntity licenseOutDoorEntity, List<LicenseSpecEntity> specList)
        {
            try
            {
                return new LicenseOutDoorDal().TransactionSaveOutDoor(mainEntity, licenseOutDoorEntity, specList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据许可主键查询户外广告信息
        /// 添加人：周 鹏
        /// 添加时间：2018-02-02
        /// </summary>
        /// <param name="licenseId"></param>
        /// <returns></returns>
        public LicenseOutDoorEntity GetEntityByLicenseId(string licenseId)
        {
            var list = GetSearchResult(new LicenseOutDoorEntity() { LicenseId = licenseId });
            return list != null && list.Count > 0 ? list[0] : new LicenseOutDoorEntity();
        }

        /// <summary>
        /// 获取户外广告信息
        /// 添加人：周 鹏
        /// 添加时间：2018-02-02
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="search">查询实体</param> 
        /// <returns></returns>
        public List<LicenseOutDoorEntity> GetSearchResult(LicenseOutDoorEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(LicenseOutDoorEntity.Parm_LicenseOutDoor_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.LicenseId))
            {
                queryCondition.AddLike(LicenseOutDoorEntity.Parm_LicenseOutDoor_LicenseId, search.LicenseId);
            }
            return Query(queryCondition) as List<LicenseOutDoorEntity>;
        }

        /// <summary>
        /// 户外广告现场勘验
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool SaveOutDoorInquestCheckSpec(RequestOutDoorInquestCheckSpec request)
        {
            try
            {
                return new LicenseOutDoorDal().SaveOutDoorInquestCheckSpec(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 保存户外广告现场验收
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public
        bool SaveOutDoorAcceptanceCheckSpec(RequestOutDoorAcceptanceCheckSpec request)
        {
            try
            {
                return new LicenseOutDoorDal().SaveOutDoorAcceptanceCheckSpec(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
