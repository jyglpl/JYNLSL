using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.DataAccess.DalImp;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Hr;

namespace Yookey.WisdomClassed.SIP.DataAccess.Hr
{
    /// <summary>
    /// WorkOvertime数据访问操作
    /// </summary>
    public class WorkOvertimeDal : DalImp.BaseDal<WorkOvertimeEntity>
    {
        public WorkOvertimeDal()
        {
            Model = new WorkOvertimeEntity();
        }
        /// <summary>
        /// 获取全部数据
        /// 添加人：周庆
        /// 添加日期：2015年4月23日
        /// </summary>
        /// <param name="companyId">单位ID</param>
        /// <param name="deptId">请求部门ID</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">截止时间</param>
        /// <param name="keyWords">关键字</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalRecords">总条数</param>
        /// <returns></returns>
        public DataTable GetSearchResult(string companyId, string deptId, string startTime, string endTime, string keyWords, int pageIndex, int pageSize, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT WO.Id ,DeptName,UserName,OvertimeReason,BeginTime,EndTime,Overtime ,
(CASE WHEN [Status] = -2 THEN '已作废'
WHEN [Status] = -1 THEN '审批不通过'
WHEN [Status] = 0 THEN '登记'
WHEN [Status] > 0 AND [Status] < 10 THEN '审批中'
WHEN [Status] = 10 THEN '审批通过' ELSE '审批不通过' END ) AS Status FROM WorkOvertime AS WO
WHERE WO.RowStatus=1");

            if (!string.IsNullOrEmpty(companyId) && !companyId.Equals("all"))
            {
                strSql.AppendFormat(" AND WO.CompanyId='{0}'", companyId);
            }
            if (!string.IsNullOrEmpty(deptId) && !deptId.Equals("all"))
            {
                strSql.AppendFormat(" AND WO.DeptId='{0}'", deptId);
            }
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND WO.BeginTime>='{0}' AND WO.BeginTime<='{1} 23:59:59.999'", startTime, endTime);
            }
            else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND WO.BeginTime>='{0}'", startTime);
            }
            else if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND WO.BeginTime<='{0} 23:59:59.999'", endTime);
            }
            else if (!string.IsNullOrEmpty(keyWords))
            {
                strSql.AppendFormat(" AND WO.UserName LIKE '%{0}%'", keyWords);
            }
            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "BeginTime", "DESC", pageIndex, pageSize, out totalRecords);
        }


        /// <summary>
        /// 事务保存加班
        /// 添加人：周 鹏
        /// 添加时间：2017-03-24
        /// </summary>
        /// <hisotry>
        /// 修改描述：时间+作者+描述
        /// </hisotry>
        /// <param name="entity">通知实体</param>
        /// <returns></returns>
        public bool TransactionSaveWorkOvertime(WorkOvertimeEntity entity)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveWorkOvertime");
            try
            {
                //var noticeId = "";
                if (Get(entity.Id) != null)
                {
                    //noticeId = entity.Id;
                    Update(entity, transaction);
                }
                else
                {
                    //noticeId = Guid.NewGuid().ToString();
                    //entity.Id = noticeId;
                    Add(entity, transaction);
                }


                //保存附件
                var sbSql = new StringBuilder();
                sbSql.AppendFormat("DELETE ComAttachment WHERE ResourceId='{0}'", entity.Id);
                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
                if (!(string.IsNullOrEmpty(entity.Attachment) || entity.Attachment.Split(',').Length.Equals(0)))
                {
                    var attachDal = new ComAttachmentDal();
                    var splitAttach = entity.Attachment.Split('|');
                    foreach (var attach in splitAttach)
                    {
                        var attachInfo = attach.Split(',');
                        var receiveEntity = new ComAttachmentEntity
                        {
                            Id = Guid.NewGuid().ToString(),
                            ResourceId = entity.Id,
                            FileName = attachInfo[2],
                            FileReName = attachInfo[3],
                            FileAddress = attachInfo[1],
                            RowStatus = 1,
                            CreateOn = DateTime.Now
                        };
                        attachDal.Add(receiveEntity, transaction);
                    }
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
        }

        /// <summary>
        /// 更改加班的状态，在当前状态上面加1
        /// 添加人：周 鹏
        /// 添加时间：2015-04-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <returns></returns>
        public bool UpdateState(string id)
        {
            var strSql = string.Format("UPDATE WorkOvertime SET [Status]+=1 WHERE Id='{0}'", id);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
        }

        /// <summary>
        /// 更改的状态
        /// 添加人：周 鹏
        /// 添加时间：2015-04-24
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public bool UpdateState(string id, int state)
        {
            try
            {
                var strSql = string.Format("UPDATE WorkOvertime SET [Status]={0} WHERE Id='{1}'", state, id);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 获取个人的全部加班记录
        /// 添加人：周庆
        /// 添加日期：2015年4月27日
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="deptId">部门Id</param>
        /// <param name="startTime">开始时间（不需要则null）</param>
        /// <param name="endTime">机制时间（不需要则null）</param>
        /// <param name="keyWords">关键字（不需要则null）</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="totalRecords">总记录条数</param>
        /// <returns></returns>
        public DataTable GetAllDataByUserDeptId(string userId, string deptId, string startTime, string endTime, string keyWords, int pageIndex, int pageSize, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT    Id ,
                                            DeptName ,
                                            UserName ,
                                            OvertimeReason ,
                                            BeginTime ,
                                            EndTime ,
                                            CONVERT(VARCHAR(5), Overtime) AS Overtime ,
                                            ( CASE WHEN [Status] = -2 THEN '已作废'
                                                   WHEN [Status] = -1 THEN '审批不通过'
                                                   WHEN [Status] = 0 THEN '登记'
                                                   WHEN [Status] > 0
                                                        AND [Status] < 10 THEN '审批中'
                                                   WHEN [Status] = 10 THEN '审批通过'
                                                   ELSE '审批不通过'
                                              END ) AS Status
                                    FROM    WorkOvertime
                                    WHERE   RowStatus = 1 AND UserId='{0}'", userId, deptId);


            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND BeginTime>='{0}' AND BeginTime<='{1} 23:59:59.999'", startTime, endTime);
            }
            else if (!string.IsNullOrEmpty(startTime) && string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND BeginTime>='{0}'", startTime);
            }
            else if (string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(" AND BeginTime<='{0} 23:59:59.999'", endTime);
            }
            else if (!string.IsNullOrEmpty(keyWords))
            {
                strSql.AppendFormat(" AND UserName LIKE '%{0}%'", keyWords);
            }
            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "BeginTime", "Desc", pageIndex, pageSize, out totalRecords);

        }


        /// <summary>
        /// 获取部门所有审核通过的加班记录
        /// 添加人：周 鹏
        /// 添加时间：2017-05-20
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="deptmentId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable GetWorkOvertimeByDepartment(string deptmentId, string startTime, string endTime)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT * FROM WorkOvertime WHERE RowStatus=1 AND [Status]=10  ");

                if (!string.IsNullOrEmpty(deptmentId) && !deptmentId.Equals("all"))
                {
                    strSql.AppendFormat("AND DeptId='{0}'", deptmentId);
                }
                if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
                {
                    strSql.AppendFormat("AND BeginTime>='{0}' AND BeginTime<='{1} 23:59:59.999'", startTime, endTime);
                }
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
