//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="CrmOpinionsBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014/12/26 15:16:41
//  功能描述：CrmOpinions业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Crm;

namespace Yookey.WisdomClassed.SIP.Business.Crm
{
    /// <summary>
    /// CrmOpinions业务逻辑
    /// </summary>
    public class CrmOpinionsBll : BaseBll<CrmOpinionsEntity>
    {
        public CrmOpinionsBll()
        {
            BaseDal = new CrmOpinionsDal();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            var entity = Get(id);
            entity.RowStatus = 0;
            return Update(entity) > 0;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public PageJqDatagrid<CrmOpinionsEntity> GetSearchResult(CrmOpinionsEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(CrmOpinionsEntity.Parm_CrmOpinions_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.CreatorId))
            {
                queryCondition.AddEqual(CrmOpinionsEntity.Parm_CrmOpinions_CreatorId, search.CreatorId);
            }
            if (!string.IsNullOrEmpty(search.Contents))
            {
                queryCondition.AddEqual(CrmOpinionsEntity.Parm_CrmOpinions_Contents, search.Contents);
            }
            //排序
            queryCondition.AddOrderBy(CrmOpinionsEntity.Parm_CrmOpinions_CreateOn, false);
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var list = Query(queryCondition);
            stopwatch.Stop();

            return new PageJqDatagrid<CrmOpinionsEntity>
            {
                page = 0,
                rows = list,
                total = 0,
                records = 0,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }



        /// <summary>
        /// 保存意见
        /// </summary>
        /// <param name="content">意见</param>
        /// <param name="user">当前用户</param>
        /// <returns></returns>
        public void SaveIdea(string content, BaseUserEntity user)
        {
            try
            {
                if (string.IsNullOrEmpty(content)) return;
                var queryCondition = QueryCondition.Instance.AddEqual(CrmOpinionsEntity.Parm_CrmOpinions_RowStatus,
                                                                      "1");
                queryCondition.AddEqual(CrmOpinionsEntity.Parm_CrmOpinions_CreatorId, user.Id);
                queryCondition.AddEqual(CrmOpinionsEntity.Parm_CrmOpinions_Contents, content);
                var list = Query(queryCondition);
                if (list.Count <= 0)
                {
                    var entity = new CrmOpinionsEntity()
                        {
                            Contents = content,
                            RowStatus = 1,
                            CreatorId = user.Id,
                            CreateBy = user.UserName,
                            CreateOn = DateTime.Now,
                            UpdateId = user.Id,
                            UpdateBy = user.UserName,
                            UpdateOn = DateTime.Now
                        };
                    Add(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
