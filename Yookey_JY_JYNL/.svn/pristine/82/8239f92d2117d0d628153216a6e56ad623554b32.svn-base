//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComAttachmentBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/22 10:52:20
//  功能描述：ComAttachment业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Business.Com
{
    /// <summary>
    /// ComAttachment业务逻辑
    /// </summary>
    public class ComAttachmentBll : BaseBll<ComAttachmentEntity>
    {
        private ComAttachmentDal _dal = new ComAttachmentDal();
        public ComAttachmentBll()
        {
            BaseDal = new ComAttachmentDal();
        }

        /// <summary>
        ///  通过资源Id删除附件（假删）
        ///  添加人：周庆
        ///  添加日期：2015年4月23日
        /// </summary>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public int DeleteAttachementByResourceId(string resourceId)
        {
            return _dal.DeleteAttachmentByResourceId(resourceId);
        }

        /// <summary>
        /// 数据查询
        /// 添加人：周 鹏
        /// 添加时间：2015-04-27
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">The search.</param>
        /// <returns>List&lt;ComAttachmentEntity&gt;.</returns>
        public List<ComAttachmentEntity> GetSearchResult(ComAttachmentEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(ComAttachmentEntity.Parm_ComAttachment_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                queryCondition.AddEqual(ComAttachmentEntity.Parm_ComAttachment_ResourceId,search.ResourceId);
            }
            if (!string.IsNullOrEmpty(search.FileType))
            {
                queryCondition.AddEqual(ComAttachmentEntity.Parm_ComAttachment_FileType, search.FileType);
            }
            queryCondition.AddOrderBy(ComAttachmentEntity.Parm_ComAttachment_CreateOn, true);
            return Query(queryCondition) as List<ComAttachmentEntity>;
        }

        /// <summary>
        /// 保存附件
        /// </summary>
        /// <param name="resourceId">外键编号</param>
        /// <param name="attachments">附件数据集，以逗号分隔</param>
        /// <returns></returns>
        public bool SaveAttachment(string resourceId, string attachments)
        {
            return _dal.SaveAttachment(resourceId, attachments);
        }
    }
}
