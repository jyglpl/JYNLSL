//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FE_ActionInstanceBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/7/16 16:58:36
//  功能描述：FE_ActionInstance业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.FlowEditor;
using Yookey.WisdomClassed.SIP.Model.FlowEditor;
using Yookey.WisdomClassed.SIP.Model;


namespace Yookey.WisdomClassed.SIP.Business.FlowEditor
{
    /// <summary>
    /// FE_ActionInstance业务逻辑
    /// </summary>
    public class FeActionInstanceBll : BaseBll<FeActionInstanceEntity>
    {
        public FeActionInstanceBll()
        {
            BaseDal = new FeActionInstanceDal();
        }


        /// <summary>
        /// 得到接收到象
        /// 添加人：周 鹏
        /// 添加时间：2014-07-18
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry> 
        /// <param name="activityId">节点编号</param>
        /// <param name="isUnlock">-1 所有 0:不启用 1:启用</param>
        /// <returns></returns>
        public DataTable GetActionInstance(string activityId, int isUnlock)
        {
            return new FeActionInstanceDal().GetActionInstance(activityId, isUnlock);
        }

        public List<FeActionInstanceEntity> GetActionEntity(string activityId, int isUnlock)
        {

            DataTable dt = new FeActionInstanceBll().GetActionInstance(activityId, isUnlock);
            List<FeActionInstanceEntity> list = new List<FeActionInstanceEntity>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FeActionInstanceEntity feA = new FeActionInstanceEntity();

                    feA.ActionInstanceID = dt.Rows[i][0].ToString();
                    feA.ActivityID = dt.Rows[i][1].ToString();
                    feA.CommunityID = dt.Rows[i][2].ToString();
                    feA.CommunityName = dt.Rows[i][3].ToString();
                    feA.UserID = dt.Rows[i][4].ToString();
                    feA.UserName = dt.Rows[i][5].ToString();
                    feA.IsUnlock = Convert.ToBoolean(dt.Rows[i][6].ToString());
                    feA.Id = dt.Rows[i][7].ToString();
                    list.Add(feA);
                }

            }
            return list;

        }
        /// <summary>
        /// 批量保存实体，若列表中的保存出现错误，将停止对后续实体的保存
        /// 添加人：张西琼
        /// 时间：2014/7/30
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SaveEntityList(List<FeActionInstanceEntity> list)
        {
            bool istrue = false;
            foreach (var item in list)
            {
                bool isSucess = ExitstActionInstanceID(item.ActionInstanceID);
                if (isSucess)
                {
                    bool isDel = new FeActionInstanceDal().DelActionInstance(item.ActionInstanceID);
                    if (isDel)
                    {
                        if (new FeActionInstanceDal().AddEntity(item))
                        {
                            istrue = true;
                        }
                        else
                        {
                            istrue = false;
                            break;
                        }
                    }
                    else
                    {
                        istrue = false;
                        break;
                    }
                }
                else
                {
                    if (new FeActionInstanceDal().AddEntity(item))
                    {
                        istrue = true;
                    }
                    else
                    {
                        istrue = false;
                        break;
                    }
                }
            }
            return istrue;
        }


        /// <summary>
        /// 保存接收对象
        /// 添加人：周 鹏
        /// 时间时间：2014-08-07
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// </summary>
        /// <param name="list">对象集合</param>
        /// <param name="activityId">activityId</param>
        /// <returns></returns>
        public bool SaveActionInstance(List<FeActionInstanceEntity> list, string activityId)
        {
            try
            {
                //先批量删除
                new FeActionInstanceDal().DeleteByActivityId(activityId);

                //批量添加
                if (list != null && list.Count > 0)
                {
                    foreach (var entity in list)
                    {
                        entity.Id = Guid.NewGuid().ToString();
                        entity.ActionInstanceID = Guid.NewGuid().ToString();
                        entity.ActivityID = activityId;
                        entity.IsUnlock = true;
                        entity.CreateOn = DateTime.Now;
                        entity.UpdateOn = DateTime.Now;
                        Add(entity);
                    }
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 验证是否存在
        /// 添加人：张西琼
        /// 时间：2014/7/30
        /// </summary>
        /// <param name="actionInstanceID"></param>
        /// <returns></returns>
        private bool ExitstActionInstanceID(string actionInstanceID)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(FeActionInstanceEntity.Parm_FE_ActionInstance_ActionInstanceID, actionInstanceID);
            //queryCondition.AddEqual(FeActivityEntity.Parm_FE_Activity_ActivityID, activityId);
            return QueryCount(queryCondition) > 0;
        }
        /// <summary>
        /// 删除接收对象
        /// 添加人：张西琼
        /// 时间：2014/8/1
        /// </summary>
        /// <param name="id">ActionInstanceID</param>
        /// <returns></returns>
        public bool DelActionInstance(string id)
        {
            return new FeActionInstanceDal().DelActionInstance(id);
        }

        /// <summary>
        /// 接收对象查询
        /// 添加人：周 鹏
        /// 添加时间：2014-08-07
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<FeActionInstanceEntity> GetSearchResultByEnd(FeActionInstanceEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(FeActionInstanceEntity.Parm_FE_ActionInstance_RowStatus, "0");                
            if (!string.IsNullOrEmpty(search.ActivityID))
            {
                queryCondition.AddEqual(FeActionInstanceEntity.Parm_FE_ActionInstance_ActivityID, search.ActivityID);
            }
            if (!string.IsNullOrEmpty(search.CommunityID))
            {
                queryCondition.AddLike(FeActionInstanceEntity.Parm_FE_ActionInstance_CommunityID, search.CommunityID);
            }
            queryCondition.AddOrderBy(FeActionInstanceEntity.Parm_FE_ActionInstance_CreateOn, false);
            return Query(queryCondition) as List<FeActionInstanceEntity>;
        }

        /// <summary>
        /// 获取流程下的所以人员
        /// </summary>
        /// <param name="FlowName">流程名称</param>
        /// <returns></returns>
        public List<string> GetProcessUser(string FlowName)
        {
            var userIds = new List<string>();
            if (string.IsNullOrEmpty(FlowName))
                return userIds;
            return new FeActionInstanceDal().GetProcessUser(FlowName);
        }
    }



}
