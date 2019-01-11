//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="LicenseHandUsersDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：安监安监企业调查表
//  作    者：叶念
//  创建日期：2018-03-21 18:11:24
//  功能描述：LicenseHandUsers数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Model.License;
using System;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using System.Data;
using System.Data.SqlClient;
using Yookey.WisdomClassed.SIP.Model;
namespace Yookey.WisdomClassed.SIP.DataAccess.License
{
    /// <summary>
    /// LicenseHandUsers数据访问操作
    /// </summary>
    public class LicenseHandUsersDal : DalImp.BaseDal<LicenseHandUsersEntity>
    {
        public LicenseHandUsersDal()
        {           
            Model = new LicenseHandUsersEntity();
        }

        /// <summary>
        /// 设置派送人员
        /// </summary>
        /// <param name="LicenseHandUserIdRequest"></param>        
        /// <returns></returns>
        public bool SetLicenseHandUserIds(LicenseHandUserIdRequest setIds)
        {
            if (setIds == null || string.IsNullOrEmpty(setIds.LicenseId) || setIds.HandType == 0)
                return false;
            var transaction = new TransactionLoader().BeginTransaction("SaveOutDoorInquestCheckSpec");
            var licenseMain = new LicenseMainDal().Get(setIds.LicenseId);
            var sendUser = new CrmUserDal().Get(setIds.SendUserId);
            if(licenseMain==null)
                return false;
            
            var deleSqlStr = string.Format("DELETE CRMMESSAGEWORK WHERE ID IN (SELECT MESSAGEWORKID FROM LICENSEHANDUSERS WHERE FORMID='{0}' AND HANDTYPE={1})", setIds.LicenseId, setIds.HandType);
            SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, deleSqlStr.ToString());//删除已有转派人员
             deleSqlStr = string.Format("DELETE LICENSEHANDUSERS WHERE FORMID='{0}' AND HANDTYPE='{1}'", setIds.LicenseId, setIds.HandType);
            SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, deleSqlStr.ToString());//删除待办

            var formAdress=string.Empty;
            var contentType=string.Empty;
            var title = string.Empty;
            Random rdm = new Random();
            switch (licenseMain.ItemCode)
            {
               case "JS050800ZJ-XK-0090"://店招标牌
                    formAdress = "/LicenseOutDoor/Entity?Radom" + rdm.NextDouble().ToString();
                   contentType = (setIds.HandType == 1 ? "00050008" : "00050009");
                   title = "【店招标牌转派】" + "来自" + sendUser.RealName + "的店招标牌" + (setIds.HandType == 1 ? "现场踏勘" : "现场验收") + "转派";
                   break;
               case "JS050800ZJ-XK-0020"://临时占道
                   formAdress = "/LicenseJeeves/Entity?Radom" + rdm.NextDouble().ToString();
                   contentType = (setIds.HandType == 1 ? "00050012" : "00050013");
                   title = "【临时占道转派】" + "来自" + sendUser.RealName + "的临时占道" + (setIds.HandType == 1 ? "现场踏勘" : "现场验收") + "转派";
                   break;
               case "JS050800ZJ-XK-0190"://大型户外广告
                   formAdress = "/LicensePositionOutDoor/Entity?Radom" + rdm.NextDouble().ToString();
                   contentType = (setIds.HandType == 1 ? "00050010" : "00050011");
                   title = "【大型户外广告转派】" + "来自" + sendUser.RealName + "的大型户外广告" + (setIds.HandType == 1 ? "现场踏勘" : "现场验收") + "转派";
                   break;
               default:
                   formAdress=string.Empty;
                   contentType=string.Empty;
                   break;
            }
            var licenseHand = new LicenseHandUsersEntity();
            var messageWork = new CrmMessageWorkEntity();
            try
            {
                foreach (var item in setIds.UserIds)
                {
                    messageWork.Id = Guid.NewGuid().ToString();

                    licenseHand.Id = Guid.NewGuid().ToString();
                    licenseHand.IsHandle = 0;
                    licenseHand.FormId = setIds.LicenseId;
                    licenseHand.CreateOn = DateTime.Now;
                    licenseHand.RowStatus = 1;
                    licenseHand.HandType = setIds.HandType;
                    licenseHand.UserId = item;
                    licenseHand.IsHandle = 0;
                    licenseHand.MessageWorkId = messageWork.Id;
                    this.Add(licenseHand, transaction);//保存派送人员

                    messageWork.FormID = setIds.LicenseId;
                    messageWork.FormAddress = formAdress;
                    messageWork.FormData="转派";
                    messageWork.ContentTypeID = contentType;
                    messageWork.IsReply = 0;
                    messageWork.State = 0;
                    messageWork.RowStatus = 1;
                    messageWork.SenderID = sendUser.Id;
                    messageWork.StartDate = DateTime.Now;
                    messageWork.ActionerID = item;       //接受人ID
                    messageWork.CreateOn = DateTime.Now;
                    messageWork.Titles = title;
                    new CrmMessageWorkDal().Add(messageWork, transaction);

                }
                transaction.Commit();
                return true;
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message, ex);
            }

        }

         /// <summary>
        /// 设置已经处理（派送和待办）
        /// </summary>
        /// <param name="limits"></param>
        /// <returns></returns>
        public bool SetIsHandle(LicenseHandLimitsRequest limits,SqlTransaction transaction)
        {
            try
            {
                var list = this.GetSearchResult(new LicenseHandUsersEntity() { FormId = limits.LicenseId, HandType = limits.HandType, UserId = limits.HandUserId });
                if (list.Count <= 0)
                    return false;
                list[0].IsHandle = 1;//已处理
                list[0].HandleDate = DateTime.Now;
                this.Update(list[0], transaction);
                var crmMessageWorkDal = new CrmMessageWorkDal();
                var messageWork = crmMessageWorkDal.Get(list[0].MessageWorkId);
                messageWork.State = 2;
                messageWork.ExecuteDate = DateTime.Now;
                crmMessageWorkDal.Update(messageWork, transaction);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取许可案件派送人信息
        /// 添加人：周 鹏
        /// 添加时间：2018-02-05
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="search">查询实体</param> 
        /// <returns></returns>
        public List<LicenseHandUsersEntity> GetSearchResult(LicenseHandUsersEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(LicenseHandUsersEntity.Parm_LicenseHandUsers_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.FormId))
            {
                queryCondition.AddEqual(LicenseHandUsersEntity.Parm_LicenseHandUsers_FormId, search.FormId);
            }

            if (!string.IsNullOrEmpty(search.UserId))
            {
                queryCondition.AddEqual(LicenseHandUsersEntity.Parm_LicenseHandUsers_UserId, search.UserId);
            }
            if (search.HandType != 0)
            {
                queryCondition.AddEqual(LicenseHandUsersEntity.Parm_LicenseHandUsers_HandType, search.HandType.ToString());
            }
            //排序
            queryCondition.AddOrderBy(LicenseHandUsersEntity.Parm_LicenseHandUsers_CreateOn, true);
            return Query(queryCondition) as List<LicenseHandUsersEntity>;
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
