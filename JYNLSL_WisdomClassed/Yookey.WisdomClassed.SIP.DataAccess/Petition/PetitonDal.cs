using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.Petition;

namespace Yookey.WisdomClassed.SIP.DataAccess.Petition
{
    /// <summary>
    /// Petition数据访问操作
    /// </summary>
    public class PetitionDal : DalImp.BaseDal<PetitionEntity>
    {
        public PetitionDal()
        {
            Model = new PetitionEntity();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable QueryList(PetitionEntity pe, PetitionStateType status, string keyWords, int pageSize, int pageIndex, string sidx, string sord, out int totalRecords, string StartTime, string EndTime)
        {
            var strSql = new StringBuilder("");
            strSql.Append(@"select Id,PetitionUser,PetitionCompany,(select rskey from ComResource where Id = petitionsource) PetitionSource,
SourceNo,PetitionNo,ReceiveDate,Phone,Address,PetitionTitile,EndDate,
(select rskey from ComResource where Id = priority) Priority,
(select rskey from ComResource where Id = petitiontype) PetitionType,CreateOn,Status 
from petition where rowstatus=1");

            switch (status)
            {
                case PetitionStateType.Registered:
                    strSql.Append(" AND [STATUS]=10 ");
                    break;
                case PetitionStateType.Application:
                    strSql.Append(" AND [STATUS]>10 AND [STATUS]<=20");
                    break;
                case PetitionStateType.Result:
                    strSql.Append(" AND [STATUS]>=30");
                    break;
                case PetitionStateType.All:
                    break;
            }


            if (!string.IsNullOrEmpty(pe.Priority))
            {
                strSql.Append(" and Priority = " + pe.Priority + "");
            }

            if (!string.IsNullOrEmpty(pe.PetitionSource))
            {
                strSql.AppendFormat(" and PetitionSource in ('{0}') ", pe.PetitionSource);
            }

            if (!string.IsNullOrEmpty(pe.PetitionCompany))
            {
                strSql.AppendFormat(" and PetitionCompany='{0}'", pe.PetitionCompany);
            }

            if (!string.IsNullOrEmpty(pe.PetitionType))
            {
                strSql.AppendFormat(" and PetitionType='{0}'", pe.PetitionType);
            }

            if (!string.IsNullOrEmpty(keyWords))
            {
                strSql.AppendFormat(" and (PetitionUser like '%{0}%' or PetitionTitile like '%{0}%' or PetitionNo like '%{0}%') ", keyWords);
            }

            if (!string.IsNullOrEmpty(StartTime))
            {
                strSql.Append(" and CreateOn >= '" + StartTime + " 00:00:00'");
            }
            if (!string.IsNullOrEmpty(EndTime))
            {
                strSql.Append(" and CreateOn <= '" + EndTime + " 23:59:59'");
            }
            var sortField = "CreateOn"; //排序字段
            var sortType = "desc"; //排序类型
            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField,
                                                sortType, pageIndex, pageSize, out totalRecords);
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
            var strSql = string.Format("UPDATE petition SET [Status]+=1 WHERE Id='{0}'", id);
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
                var strSql = string.Format("UPDATE petition SET [Status]={0} WHERE Id='{1}'", state, id);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 保存附件
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="userEntity"></param>
        /// <returns></returns>
        public bool SaveFile(PetitionEntity entity, CrmUserEntity userEntity)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveFile");
            try
            {
                //保存附件
                var sbSql = new StringBuilder();
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
                            FileType = entity.AttachmentType,//附件类型
                            FileTypeName = entity.AttachmentType == "1" ? "信访上报附件" : "信访流程附件",
                            RowStatus = 1,
                            CreateOn = DateTime.Now,
                            CreatorId = userEntity.Id,
                            CreateBy = userEntity.RealName
                        };

                        if (attachInfo.Length >= 5)
                        {
                            receiveEntity.FileConvertAddress = attachInfo[4];
                        }

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
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public string GetNo(string Value)
        {
            int totalRecords;
            var sbSql = new StringBuilder();
            sbSql.Append(@"select  top 1 max(sourceno) SourceNo  from petition where rowstatus = 1 and SourceNo like '%" + Value + "%' group by sourceno order by sourceno desc ");

            DataTable dt = SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, sbSql.ToString(), "*", "", "sourceno",
                                                "desc", 1, 10, out totalRecords);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["SourceNo"].ToString();
            }
            return "";
        }

        /// <summary>
        /// 获取状态数量
        /// </summary>
        /// <returns></returns>
        public DataTable GetPetitionCount()
        {
            try
            {
                var strSql = @"SELECT (SELECT COUNT(*) FROM PETITION WHERE [STATUS]=10) AS  Registered,
(SELECT COUNT(*) FROM PETITION WHERE [STATUS]>10 AND [STATUS]<=20 AND ROWSTATUS=1) AS [Application],
(SELECT COUNT(*) FROM PETITION WHERE [STATUS]>=30 AND ROWSTATUS=1) AS Result,
(SELECT COUNT(*) FROM PETITION WHERE  ROWSTATUS=1) AS [All]";
                return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 验证是否已通过终审环节
        /// </summary>
        /// <param name="petionId">信访Id</param>
        /// <returns></returns>
        public bool CheckIsFinalExamine(string petionId)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.AppendFormat(@"SELECT COUNT(*) FROM CrmIdeaList AS CIL 
JOIN WF_Process AS WP ON CIL.ProcessID=WP.Id
JOIN CrmUser AS CU ON CU.Id=CIL.UserId
WHERE ResourceID='{0}'
AND WP.FullName='信访审批' AND [Type]=0 AND Duty='终审'", petionId);

                var obj = SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString());
                if (obj != null)
                {
                    return int.Parse(obj.ToString()) > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
