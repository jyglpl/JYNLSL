using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.DataAccess.DalImp;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.SealUp;

namespace Yookey.WisdomClassed.SIP.DataAccess.SealUp
{
    /// <summary>
    /// SealUp数据访问操作
    /// </summary>
    public class SealUpDal : BaseDal<SealUpEntity>
    {
        public SealUpDal()
        {
            Model = new SealUpEntity();
        }

        /// <summary>
        /// 更改案件的状态
        /// 添加人：周 鹏
        /// 添加时间：2014-12-23
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="id">案件编号</param>
        /// <param name="state">状态值</param>
        /// <returns></returns>
        public bool UpdateCaseState(string id, int state)
        {
            try
            {
                var strSql = string.Format("UPDATE SealUp SET [State]={0} WHERE Id='{1}'", state, id);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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
                var strSql = string.Format("UPDATE SealUp SET [State]={0} WHERE Id='{1}'", state, id);
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 删除查封
        /// </summary>
        /// <param name="ids">查分ID</param>
        /// <returns></returns>
        public bool BatchDelete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            try
            {
                var strSql = string.Format("UPDATE [SealUp] SET [RowStatus] =0 WHERE [Id] IN ('{0}')", string.Join(",'", id));
                return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        /// <summary>
        /// 数据查询
        /// 添加人：周 鹏
        /// 添加时间：2016-01-08
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns>Page&lt;SealUpEntity&gt;.</returns>
        public DataTable GetSearchResult(string keyword, int pageSize, int pageIndex, out int totalRecords)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@" SELECT CASE  WHEN [state]=0 then '登记' WHEN [state]=10 THEN '查封审批通过' WHEN  [state]<10 and[state]>0  
 then '查封审批中' WHEN [state]>10 and  [state]<20 then '解除查封审批中'  WHEN [state]=20 THEN '解封审批通过' end AS State, 
Id, CaseInfoNo, DataSource, ReSource, ReSourceName, CompanyId,
 CompanyName, DepartmentId, DepartmentName, RePersonelIdFist, RePersonelIdSecond,
  RePersonelNameFist, RePersonelNameSecond, UdPersonelIdFirst, UdPersonelIdSecond,
   UdPersonelNameFirst, UdPersonelNameSecond, CaseDate,
    CaseAddress ,TargetName 
     FROM SealUp  WHERE RowStatus=1 ");
            //if (!string.IsNullOrEmpty(companyId))
            //{
            //    strSql.AppendFormat(" AND CompanyId='{0}'", companyId);
            //}
            if (!string.IsNullOrEmpty(keyword))
            {
                strSql.AppendFormat(" AND CompanyName LIKE '%{0}%' OR DepartmentName LIKE '%{0}%' OR RePersonelNameFist LIKE '%{0}%'" +
                                     " OR RePersonelNameSecond LIKE '%{0}%' OR CaseAddress LIKE '%{0}%' OR TargetName LIKE '%{0}%'", keyword);
            }
            return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", "CaseDate", "Desc", pageIndex, pageSize, out totalRecords);
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
            var strSql = string.Format("UPDATE SealUp SET [State]+=1 WHERE Id='{0}'", id);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, strSql) > 0;
        }

        /// <summary>
        /// 事务保存查封物品信息
        /// </summary>
        /// <param name="sealup">查封实体</param>
        /// <param name="sealUpGoodsList">查封物品</param>
        /// <returns></returns>
        public bool TransactionSave(SealUpEntity sealup, List<SealUpGoodsEntity> sealUpGoodsList, string legislationId, string legislationItemId, string legislationGistId)
        {
            var transaction = new TransactionLoader().BeginTransaction("SealUp");
            try
            {
                var checkEntity = Get(sealup.Id);
                var sealupId = sealup.Id;
                if (checkEntity != null && !string.IsNullOrEmpty(checkEntity.Id))
                {
                    Update(sealup, transaction);  //修改
                }
                else
                {
                    Add(sealup, transaction);     //新增
                }

                if (sealUpGoodsList.Any())
                {
                    var sql = string.Format("DELETE SealUpGoods WHERE SealUpId='{0}' ", sealup.Id);
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sql);
                }

                new SealUpLegislationDal().SavePunishLegislation(sealupId, legislationId, legislationItemId,
                                                                        legislationGistId, transaction);
                var index = 0;
                foreach (var item in sealUpGoodsList)
                {
                    new SealUpGoodsDal().Add(item, transaction);
                    index++;
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
    }
}
