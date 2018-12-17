using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Yookey.WisdomClassed.SIP.Business.BasePetaPoco;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.DataAccess.GridManagement;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.GridManagement;

namespace Yookey.WisdomClassed.SIP.Business.GridManagement
{
    public class GridManagementBll : BaseBll<GridManagementInfoEntity>
    {
        private static readonly GridManagementDal Dal = new GridManagementDal();
        /// <summary>
        /// 根据组织编号查询文件
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public DataTable GetGridManagementByCompanyId(string companyId)
        {
            try
            {
                return Dal.GetGridManagementByCompanyId(companyId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据单位ID获取单位上传的文件总数
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public int GetCompanyUpLoadCount(string companyId)
        {
            try
            {
                return new GridManagementDal().GetCompanyUpLoadCount(companyId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取所有单位信息和已上传的情况
        /// </summary>
        /// <returns>Columns-> Id：单位ID FullName：单位全称 ShortName：单位简称 UpCount：已上传数</returns>
        public DataTable GetCompanys()
        {
            try
            {
                return new GridManagementDal().GetCompanys();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据单位ID获取单位的最新上传的情况
        /// </summary>
        /// <returns>Columns-> DeptId：部门ID DeptName：部门名称 NewTime：最新上传时间</returns>
        public DataTable GetCompanyNewUploadInfo()
        {
            try
            {
                //获取所有单位
                var companyList = new CrmCompanyBll().GetAllCompany(new CrmCompanyEntity() { });

                //获取所有部门
                var departmentList = new CrmDepartmentBll().GetAllDepartment(new CrmDepartmentEntity() { IsLedger = 1 });

                var newUploadInfoDt = new DataTable();

                newUploadInfoDt.Columns.Add("CompanyId"); //单位ID
                newUploadInfoDt.Columns.Add("DeptId"); //部门ID
                newUploadInfoDt.Columns.Add("DeptName"); //部门名称
                newUploadInfoDt.Columns.Add("NewTime"); //最新上传时间

                foreach (CrmCompanyEntity entity in companyList)
                {
                    var companyUploadInfo = GetCompanyNewUploadInfo(entity.Id);
                    if (companyUploadInfo != null && companyUploadInfo.Rows.Count > 0)
                    {
                        foreach (DataRow row in companyUploadInfo.Rows)
                        {
                            var nRow = newUploadInfoDt.NewRow();
                            nRow["CompanyId"] = entity.Id;
                            nRow["DeptId"] = row["DeptId"];
                            nRow["DeptName"] = row["DeptName"];
                            nRow["NewTime"] = row["NewTime"];

                            newUploadInfoDt.Rows.Add(nRow);
                        }

                        if (companyUploadInfo.Rows.Count == 1) //单位上传情况需要显示两个部门，需补充
                        {
                            int tempIndex = 0;
                            var deptList = departmentList.Where(x => x.CompanyId == entity.Id);
                            foreach (var deptEntity in deptList)
                            {
                                if (tempIndex > 0) //过滤第一个“区局”
                                {
                                    var nRow = newUploadInfoDt.NewRow();
                                    nRow["CompanyId"] = entity.Id;
                                    nRow["DeptId"] = deptEntity.Id;
                                    nRow["DeptName"] = deptEntity.ShortName;
                                    nRow["NewTime"] = "无";
                                    newUploadInfoDt.Rows.Add(nRow);
                                }

                                tempIndex++;
                                if (tempIndex >= 2)
                                    break;
                            }
                        }
                    }
                    else
                    {
                        int tempIndex = 0;
                        var deptList = departmentList.Where(x => x.CompanyId == entity.Id);
                        foreach (var deptEntity in deptList)
                        {
                            if (tempIndex > 0) //过滤第一个“区局”
                            {
                                var nRow = newUploadInfoDt.NewRow();
                                nRow["CompanyId"] = entity.Id;
                                nRow["DeptId"] = deptEntity.Id;
                                nRow["DeptName"] = deptEntity.ShortName;
                                nRow["NewTime"] = "无";
                                newUploadInfoDt.Rows.Add(nRow);
                            }

                            tempIndex++;
                            if (tempIndex >= 3)
                                break;
                        }
                    }
                }
                return newUploadInfoDt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 根据单位ID获取单位的最新上传的情况
        /// </summary>
        /// <param name="companyId">单位ID</param>
        /// <returns>Columns-> DeptId：部门ID DeptName：部门名称 NewTime：最新上传时间</returns>
        public DataTable GetCompanyNewUploadInfo(string companyId)
        {
            try
            {
                return new GridManagementDal().GetCompanyNewUploadInfo(companyId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 查询网格化设置
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<GridManagementInfoEntity> GetSearchResult(GridManagementInfoEntity search,
                                                              params
                                                                  Expression<Func<GridManagementInfoEntity, object>>[]
                                                                  expressions)
        {
            try
            {
                return new GridManagementDal().GetSearchResult(search, expressions);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 查询网格化设置
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        public List<GridManagementInfoEntity> GetAllList(GridManagementInfoEntity search)
        {
            try
            {
                return new GridManagementDal().GetSearchResult(search);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据父编号获取文件夹子集数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int ChildCount(string id)
        {
            try
            {
                return new GridManagementDal().ChildCount(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 根据父编号获取文件夹子集数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            try
            {
                return new GridManagementDal().Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
