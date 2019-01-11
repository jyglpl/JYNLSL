//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="Consent_AttachBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：叶念
//  创建日期：2015/7/29 13:54:33
//  功能描述：Consent_Attach业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess;
using Yookey.WisdomClassed.SIP.DataAccess.Consent;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Consent;

namespace Yookey.WisdomClassed.SIP.Business.Consent
{
    /// <summary>
    /// Consent_Attach业务逻辑
    /// </summary>
    public class Consent_AttachBll : BaseBll<Consent_AttachEntity>
    {
        public Consent_AttachBll()
        {
            BaseDal = new Consent_AttachDal();
        }

        public List<Consent_AttachEntity> GetSearchResult(Consent_AttachEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(Consent_AttachEntity.Parm_Consent_Attach_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ResourceId))
            {
                queryCondition.AddEqual(Consent_AttachEntity.Parm_Consent_Attach_ResourceId, search.ResourceId);
            }
            queryCondition.AddOrderBy(Consent_AttachEntity.Parm_Consent_Attach_CreateOn, true);
            return Query(queryCondition) as List<Consent_AttachEntity>;
        }

        /// <summary>
        /// 用于手机端请求附件
        /// 添加人：周 鹏
        /// 添加时间：2015-09-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="resourceId">许可主键编号</param>
        /// <param name="netWork">当前请求网络的类型</param>
        /// <returns>DataTable.</returns>
        public DataTable GetFiles(string resourceId, CommonMethod.NetWorkEnum netWork)
        {
            var fileViewLink = AppConfig.FileViewLink;
            switch (netWork)
            {
                case CommonMethod.NetWorkEnum.Intranet:   //内网
                    fileViewLink = AppConfig.FileViewLink;
                    break;
                case CommonMethod.NetWorkEnum.OutNet:     //外网
                    fileViewLink = AppConfig.FileViewOutNetLink;
                    break;
            }
            return new Consent_AttachDal().GetFiles(resourceId, fileViewLink);
        }
    }
}
