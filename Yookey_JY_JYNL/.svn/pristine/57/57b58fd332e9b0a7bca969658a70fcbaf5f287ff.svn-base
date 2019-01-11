using DBHelper;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Model.LawPunishInformation;

namespace Yookey.WisdomClassed.SIP.DataAccess.LawPunishInformation
{
    public class LegalPersonListDal : BaseDal<LegalPersonEntity>
    {
        /// <summary>
        /// 获取法人
        /// </summary>
        /// <returns></returns>
        public List<LegalPersonEntity> GetSearchListForPerson(LegalPersonEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT * FROM PunishmentLw WHERE Rowstatus = 1");
            if (!string.IsNullOrEmpty(search.ID))
            {
                strSql.AppendFormat(" And ID = '{0}'", search.ID);
            }

            ReadDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "李傲",
                FileName = "LegalPersonListDal.cs",
                ForUse = "获取法人列表",
                FunName = "GetSearchListForNaturalPerson"
            };
            return ReadDatabase.Query<LegalPersonEntity>(strSql.ToString()).ToList();
        }

        /// <summary>
        /// 查询法人列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public DataTable QueryLawpersonnelList(string Name, int pageSize, int pageIndex, string sidx, string sord, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT * FROM PunishmentLw WHERE RowStatus = 1");
                if (!string.IsNullOrEmpty(Name))
                {
                    strSql.AppendFormat(" AND (OrganizationCode LIKE '%{0}%' or PunishmentCod LIKE '%{0}%' or LegalName LIKE '%{0}%')", Name);
                }

                var sortField = "DecidedTime";
                var sortType = "ASC";
                if (!string.IsNullOrEmpty(sidx))
                {
                    sortField = sidx;
                    sortType = sord;
                }
                return SqlHelper.QueryPageBySql(SqlHelper.SqlConnStringRead, strSql.ToString(), "*", "", sortField, sortType, pageIndex, pageSize, out totalRecords);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 新增法人
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertLw(LegalPersonEntity entity)
        {
            //var strSql = new StringBuilder("");
            //strSql.AppendFormat
            var strSql = string.Format(@"INSERT INTO [dbo].[PunishmentLw]
                      (Id
                      ,RegistraNumber
                      ,OrganizationCode
                      ,PunishmentName
                      ,PunishmentCod
                      ,DocumentNumber
                      ,CategoryOne
                      ,CategoryTwo
                      ,FineMoney
                      ,ConfiscateMoney
                      ,PunishmentReason
                      ,PunishmentBasis
                      ,PunishmentVerdict
                      ,DishonestSeverity
                      ,DishonestValidity
                      ,DecidedName
                      ,DecidedTime
                      ,LegalName
                      ,LegalCardType
                      ,LegalCard
                      ,PunishmentDeadline
                      ,Implementation
                      ,State
                      ,Scope
                      ,PublicDeadline
                      ,InformationName
                      ,Note
                      ,IsPush
                      ,ROWSTATUS
                      ,CREATOR_ID
                      ,CREATE_BY
                      ,CREATE_ON
                      ,UPDATE_ID
                      ,UPDATE_BY
                      ,UPDATE_ON
                      )
                VALUES
                      ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}')",
                    entity.ID,
                    entity.RegistraNumber,
                    entity.OrganizationCode,
                    entity.PunishmentName,
                    entity.PunishmentCod,
                    entity.DocumentNumber,
                    entity.CategoryOne,
                    entity.CategoryTwo,
                    entity.FineMoney,
                    entity.ConfiscateMoney,
                    entity.PunishmentReason,
                    entity.PunishmentBasis,
                    entity.PunishmentVerdict,
                    entity.DishonestSeverity,
                    entity.DishonestValidity,
                    entity.DecidedName,
                    entity.DecidedTime,
                    entity.LegalName,
                    entity.LegalCardType,
                    entity.LegalCard,
                    entity.PunishmentDeadline,
                    entity.Implementation,
                    entity.State,
                    entity.Scope,
                    entity.PublicDeadline,
                    entity.InformationName,
                    entity.Note,
                    entity.IsPush,
                    entity.ROWSTATUS,
                    entity.CREATOR_ID,
                    entity.CREATE_BY,
                    entity.CREATE_ON,
                    entity.UPDATE_ID,
                    entity.UPDATE_BY,
                    entity.UPDATE_ON
                    );

            ReadDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "李傲",
                FileName = "LegalPersonListDal.cs",
                ForUse = "新增法人",
                FunName = "InsertLw"
            };

            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 修改法人
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateLw(LegalPersonEntity entity)
        {
            var strSql = string.Format(@"UPDATE [dbo].[PunishmentLw] SET
                       RegistraNumber='{1}'
                      ,OrganizationCode='{2}'
                      ,PunishmentName='{3}'
                      ,PunishmentCod='{4}'
                      ,DocumentNumber='{5}'
                      ,CategoryOne='{6}'
                      ,CategoryTwo='{7}'
                      ,FineMoney='{8}'
                      ,ConfiscateMoney='{9}'
                      ,PunishmentReason='{10}'
                      ,PunishmentBasis='{11}'
                      ,PunishmentVerdict='{12}'
                      ,DishonestSeverity='{13}'
                      ,DishonestValidity='{14}'
                      ,DecidedName='{15}'
                      ,DecidedTime='{16}'
                      ,LegalName='{17}'
                      ,LegalCardType='{18}'
                      ,LegalCard='{19}'
                      ,PunishmentDeadline='{20}'
                      ,Implementation='{21}'
                      ,State='{22}'
                      ,Scope='{23}'
                      ,PublicDeadline='{24}'
                      ,InformationName='{25}'
                      ,Note='{26}'
                      ,IsPush='{27}'
                      ,ROWSTATUS='{28}'
                      ,CREATOR_ID='{29}'
                      ,CREATE_BY='{30}'
                      ,CREATE_ON='{31}'
                      ,UPDATE_ID='{32}'
                      ,UPDATE_BY='{33}'
                      ,UPDATE_ON='{34}'
                      where ID='{0}'
                     ",
                    entity.ID,
                    entity.RegistraNumber,
                    entity.OrganizationCode,
                    entity.PunishmentName,
                    entity.PunishmentCod,
                    entity.DocumentNumber,
                    entity.CategoryOne,
                    entity.CategoryTwo,
                    entity.FineMoney,
                    entity.ConfiscateMoney,
                    entity.PunishmentReason,
                    entity.PunishmentBasis,
                    entity.PunishmentVerdict,
                    entity.DishonestSeverity,
                    entity.DishonestValidity,
                    entity.DecidedName,
                    entity.DecidedTime,
                    entity.LegalName,
                    entity.LegalCardType,
                    entity.LegalCard,
                    entity.PunishmentDeadline,
                    entity.Implementation,
                    entity.State,
                    entity.Scope,
                    entity.PublicDeadline,
                    entity.InformationName,
                    entity.Note,
                    entity.IsPush,
                    entity.ROWSTATUS,
                    entity.CREATOR_ID,
                    entity.CREATE_BY,
                    entity.CREATE_ON,
                    entity.UPDATE_ID,
                    entity.UPDATE_BY,
                    entity.UPDATE_ON
                    );

            ReadDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "李傲",
                FileName = "LegalPersonListDal.cs",
                ForUse = "修改法人",
                FunName = "InsertLw"
            };

            return WriteDatabase.Execute(strSql) > 0;
        }


        /// <summary>
        /// 删除法人
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteLegalPer(string ids)
        {
            //string[] id = ids.Split(',').ToArray();
            //var strSql = "";
            //for (int i = 0; i < id.Length; i++)
            //{
            //     strSql = string.Format(@"UPDATE PUNISHMENT SET ROWSTATUS='{0}' WHERE PK_ID='{1}'", (int)RowStatus.Delete, id[i]);

            //}

            var strSql = string.Format(@"UPDATE PUNISHMENT_LW SET ROWSTATUS='{0}' WHERE PK_ID='{1}'", (int)RowStatus.Delete, ids);
            return WriteDatabase.Execute(strSql) > 0;

        }
    }
}
