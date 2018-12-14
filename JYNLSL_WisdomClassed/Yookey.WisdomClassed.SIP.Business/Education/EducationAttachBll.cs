using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Education;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Education;

namespace Yookey.WisdomClassed.SIP.Business.Education
{
    /// <summary>
    /// EducationAttach业务逻辑
    /// </summary>
    public class EducationAttachBll : BaseBll<EducationAttachEntity>
    {
        public EducationAttachBll()
        {
            BaseDal = new EducationAttachDal();
        }

        /// <summary>
        /// 查询附件
        /// </summary>
        /// <returns></returns>
        public IList<EducationAttachEntity> GetListByResourceId(string resourceId, string fileType)
        {
            try
            {
                var queryCondition = QueryCondition.Instance.AddEqual(EducationAttachEntity.Parm_EducationAttach_RowStatus, "1");
                if (!string.IsNullOrEmpty(resourceId))
                {
                    queryCondition.AddEqual(EducationAttachEntity.Parm_EducationAttach_ResourceId, resourceId);
                }
                if (!string.IsNullOrEmpty(fileType))
                {
                    queryCondition.AddEqual(EducationAttachEntity.Parm_EducationAttach_FileType, fileType);
                }
                //排序
                queryCondition.AddOrderBy(EducationAttachEntity.Parm_EducationAttach_CreateOn, true);
                return Query(queryCondition);
            }
            catch (Exception)
            {
                return new List<EducationAttachEntity>();
            }
        }

        /// <summary>
        /// 查询案件对应的附件
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        public List<EducationAttachEntity> GetSearchResult(EducationAttachEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(EducationAttachEntity.Parm_EducationAttach_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                queryCondition.AddEqual(EducationAttachEntity.Parm_EducationAttach_ResourceId, search.ResourceId);
            }
            queryCondition.AddOrderBy(EducationAttachEntity.Parm_EducationAttach_CreateOn, true);
            return Query(queryCondition) as List<EducationAttachEntity>;
        }

        /// <summary>
        /// 创建附件信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string CreateEducationAttachInfo(EducationAttachEntity entity)
        {
            if (string.IsNullOrEmpty(entity.ResourceId)) return null;
            string Id = entity.Id = Guid.NewGuid().ToString();
            entity.RowStatus = 1;
            BaseDal.Add(entity);
            return Id;
        }
    }
}
