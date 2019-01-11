using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetaPoco;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.DoubleRandom;

namespace Yookey.WisdomClassed.SIP.DataAccess.DoubleRandom
{
    public class DoubleRandomEnterpriseDal : BaseDal<DoubleRandomEnterpriseEntity>
    {
        /// <summary>
        /// 获取企业列表
        /// </summary>
        /// <returns></returns>
        public List<DoubleRandomEnterpriseEntity> GetSearchListForEnterprise(DoubleRandomEnterpriseEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT * FROM DOUBLE_RANDOM_ENTERPRISE WHERE Rowstatus = 1");

            if (!string.IsNullOrEmpty(search.ID))
            {
                strSql.AppendFormat(" And ID = '{0}'", search.ID);
            }

            ReadDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "徐俊",
                FileName = "DoubleRandomEnterpriseDal.cs",
                ForUse = "查询企业双随机企业列表",
                FunName = "GetSearchListForEnterprise"
            };
            return ReadDatabase.Query<DoubleRandomEnterpriseEntity>(strSql.ToString()).ToList();
        }


        /// <summary>
        /// 查询企业双随机企业列表
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        //public Page<DoubleRandomEnterpriseEntity> GetSearchResult(DoubleRandomEnterpriseEntity search)
        //{
        //    var sbWhere = new StringBuilder();
        //    var args = new List<object>();
        //    sbWhere.Append(Database.GetFormatSql<DoubleRandomEnterpriseEntity>("Where {0}=1 ", u => u.ROWSTATUS));
        //    if (!string.IsNullOrEmpty(search.COMPANY_NAME))
        //    {
        //        sbWhere.Append(Database.GetFormatSql<DoubleRandomEnterpriseEntity>(" AND {0} LIKE '%'+@COMPANY_NAME+'%'", t => t.COMPANY_NAME));
        //        args.Add(new { ProductNo = search.COMPANY_NAME });
        //    }
        //    //排序
        //    sbWhere.Append(Database.GetFormatSql<DoubleRandomEnterpriseEntity>(" order by {0} desc", t => t.CREATE_ON));
        //    ReadDatabase.Comment = new StringExtension.SqlComment
        //    {
        //        Author = "周鹏",
        //        FileName = "DoubleRandomEnterpriseDal.cs",
        //        ForUse = "查询企业双随机企业列表",
        //        FunName = "GetSearchResult"
        //    };
        //    return ReadDatabase.Page<DoubleRandomEnterpriseEntity>(search.page.CurrentPage, search.page.PageSize,
        //                                                           sbWhere.ToString(), args.ToArray());
        //}

        public Page<DoubleRandomEnterpriseEntity> GetSearchResult(string paperType, string txtName, int pageSize, int pageIndex)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM DOUBLE_RANDOM_ENTERPRISE WHERE ROWSTATUS='1'");
            var args = new List<object>();

            strSql.Append(" ORDER BY COMPANY_NAME Desc");
            return WriteDatabase.Page<DoubleRandomEnterpriseEntity>(pageIndex, pageSize, strSql.ToString(), args.ToArray());
        }

        /// <summary>
        /// 新增企业
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertEnt(DoubleRandomEnterpriseEntity entity)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"INSERT INTO [dbo].[DOUBLE_RANDOM_ENTERPRISE]
           ([ID]
           ,[COMPANY_NAME]
           ,[ORGANIZATION_CODE]
           ,[LEGAL_REPRESENTATIVE]
           ,[PHONE]
           ,[REGISTERED_ADDRESS]
           ,[PRODUCTION_ADDRESS]
           ,[INDUSTRY_CATEGORYI]
           ,[INDUSTRY_CATEGORYI_Name]
           ,[INDUSTRY_CATEGORYII]
           ,[INDUSTRY_CATEGORYII_Name]
           ,[INDUSTRY_CATEGORYIII]
           ,[INDUSTRY_CATEGORYIII_Name]
           ,[ROWSTATUS]
           ,[CREATOR_ID]
           ,[CREATE_BY]
           ,[CREATE_ON]
           ,[UPDATE_ID]
           ,[UPDATE_BY]
           ,[UPDATE_ON])
     VALUES
           ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')",
                    entity.ID,
                    entity.COMPANY_NAME,
                    entity.ORGANIZATION_CODE,
                    entity.LEGAL_REPRESENTATIVE,
                    entity.PHONE,
                    entity.REGISTERED_ADDRESS,
                    entity.PRODUCTION_ADDRESS,
                    entity.INDUSTRY_CATEGORYI,
                    entity.INDUSTRY_CATEGORYI_NAME,
                    entity.INDUSTRY_CATEGORYII,
                    entity.INDUSTRY_CATEGORYII_NAME,
                    entity.INDUSTRY_CATEGORYIII,
                    entity.INDUSTRY_CATEGORYIII_NAME,
                    entity.ROWSTATUS,
                    entity.CREATOR_ID,
                    entity.CREATE_BY,
                    entity.CREATE_ON,
                    entity.UPDATE_ID,
                    entity.UPDATE_BY,
                    entity.UPDATE_ON);

            ReadDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "徐俊",
                FileName = "DoubleRandomEnterpriseDal.cs",
                ForUse = "新增企业",
                FunName = "InsertEnt"
            };

            return ReadDatabase.Execute(strSql.ToString()) == 1 ? true : false;
        }

        /// <summary>
        /// 更新企业
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEnt(DoubleRandomEnterpriseEntity entity)
        {
            return false;
        }
    }
}
