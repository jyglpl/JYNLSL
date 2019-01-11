//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="IllegalConstruction_AttachBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/4/14 14:05:55
//  功能描述：IllegalConstruction_Attach业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;

namespace Yookey.WisdomClassed.SIP.Business.IllegalConstruction
{
    /// <summary>
    /// IllegalConstruction_Attach业务逻辑
    /// </summary>
    public class IllegalConstructionAttachBll : BaseBll<IllegalConstructionAttachEntity>
    {
        public IllegalConstructionAttachBll()
        {
            BaseDal = new IllegalConstructionAttachDal();
        }


        /// <summary>
        /// 查询案件对应的附件
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        public List<IllegalConstructionAttachEntity> GetSearchResult(IllegalConstructionAttachEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(IllegalConstructionAttachEntity.Parm_IllegalConstruction_Attach_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                queryCondition.AddEqual(IllegalConstructionAttachEntity.Parm_IllegalConstruction_Attach_ResourceId, search.ResourceId);
            }
            queryCondition.AddOrderBy(IllegalConstructionAttachEntity.Parm_IllegalConstruction_Attach_CreateOn, true);
            return Query(queryCondition) as List<IllegalConstructionAttachEntity>;
        }

        /// <summary>
        /// 查询案件对应的附件
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <param name="types">附件的类型</param>
        /// <returns></returns>
        public List<IllegalConstructionAttachEntity> GetSearchResult(IllegalConstructionAttachEntity search, List<string> types)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(IllegalConstructionAttachEntity.Parm_IllegalConstruction_Attach_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                queryCondition.AddEqual(IllegalConstructionAttachEntity.Parm_IllegalConstruction_Attach_ResourceId, search.ResourceId);
            }
            if (types != null && types.Count > 0)
            {
                queryCondition.AddIn(IllegalConstructionAttachEntity.Parm_IllegalConstruction_Attach_FileType, string.Join(",", types.ToArray()));
            }
            queryCondition.AddOrderBy(IllegalConstructionAttachEntity.Parm_IllegalConstruction_Attach_CreateOn, true);
            return Query(queryCondition) as List<IllegalConstructionAttachEntity>;
        }

        /// <summary>
        /// 批量删除照片
        /// 添加人：周 鹏
        /// 添加时间：2015-03-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="ids">照片数据集,使用逗号分隔开</param>
        /// <returns></returns>
        public bool DeleteAttach(string ids)
        {
            return new IllegalConstructionAttachDal().DeleteAttach(ids);
        }


        /// <summary>
        /// 获取案件附件
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseinfoId">案件编号</param>
        /// <param name="fileViewLink"></param>
        /// <returns></returns>
        public DataTable GetFileList(string caseinfoId, string fileViewLink)
        {
            return new IllegalConstructionAttachDal().GetFileList(caseinfoId, fileViewLink);
        }


        /// <summary>
        /// 通过照片名称删除照片
        /// </summary>
        /// <param name="imgName">照片名称</param>
        /// <returns></returns>
        public bool DeleteAttachByImgName(string imgName)
        {
            return new IllegalConstructionAttachDal().DeleteAttachByImgName(imgName);
        }       
    }
}
