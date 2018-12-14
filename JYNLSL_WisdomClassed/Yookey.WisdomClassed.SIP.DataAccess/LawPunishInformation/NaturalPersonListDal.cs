using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.LawPunishInformation;
using PetaPoco;
using Yookey.WisdomClassed.SIP.Enumerate;
using System.Data;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.DataAccess.LawPunishInformation
{
    public class NaturalPersonListDal : BaseDal<NaturalPersonEntity>
    {

        /// <summary>
        /// 获取自然人
        /// </summary>
        /// <returns></returns>
        public List<NaturalPersonEntity> GetSearchListForNaturalPerson(NaturalPersonEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT * FROM PunishmentNp WHERE Rowstatus = 1");
            if (!string.IsNullOrEmpty(search.ID))
            {
                strSql.AppendFormat(" And ID = '{0}'", search.ID);
            }

            ReadDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "李傲",
                FileName = "NaturalPersonListDal.cs",
                ForUse = "获取自然人列表",
                FunName = "GetSearchListForNaturalPerson"
            };
            return ReadDatabase.Query<NaturalPersonEntity>(strSql.ToString()).ToList();
        }

        /// <summary>
        /// 查询自然人列表
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public DataTable QueryNppersonnelList(string Name, int pageSize, int pageIndex, string sidx, string sord, out int totalRecords)
        {
            try
            {
                var strSql = new StringBuilder("");
                strSql.Append(@"SELECT * FROM PunishmentNp WHERE RowStatus = 1");
                if (!string.IsNullOrEmpty(Name))
                {
                    strSql.AppendFormat(" AND (NaturalName LIKE '%{0}%' or IdCard LIKE '%{0}%' or DocumentNumber LIKE '%{0}%')", Name);
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
        /// 新增自然人
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertCorpora(NaturalPersonEntity entity)
        {
            
           var strSql=string.Format(@"INSERT INTO [dbo].[PunishmentNp]
                   (ID
                   ,NaturalName
                   ,IdCardType
                   ,IdCard
                   ,IllegalName
                   ,DocumentNumber
                   ,PunishmentBasis
                   ,PunishmentResults
                   ,FineMoney
                   ,DishonestSeverity
                   ,DishonestValidity
                   ,OtherName
                   ,DecidedTime
                   ,InformationName
                   ,Note
                   ,MainDishonest
                   ,PublicDeadline
                   ,IsPush
                   ,ROWSTATUS
                   ,CREATOR_ID
                   ,CREATE_BY
                   ,CREATE_ON
                   ,UPDATE_ID
                   ,UPDATE_BY
                   ,UPDATE_ON)
             VALUES
                   ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}')",
                    entity.ID,
                    entity.NaturalName,
                    entity.IdCardType,
                    entity.IdCard,
                    entity.IllegalName,
                    entity.DocumentNumber,
                    entity.PunishmentBasis,
                    entity.PunishmentResults,
                    entity.FineMoney,
                    entity.DishonestSeverity,
                    entity.DishonestValidity,
                    entity.OtherName,
                    entity.DecidedTime,
                    entity.InformationName,
                    entity.Note,
                    entity.MainDishonest,
                    entity.PublicDeadline,
                    entity.IsPush,
                    entity.ROWSTATUS,
                    entity.CREATOR_ID,
                    entity.CREATE_BY,
                    entity.CREATE_ON,
                    entity.UPDATE_ID,
                    entity.UPDATE_BY,
                    entity.UPDATE_ON);
            return WriteDatabase.Execute(strSql) > 0;
        }


//        /// <summary>
//        /// 修改自然人
//        /// </summary>
//        /// <param name="entity"></param>
//        /// <returns></returns>
        public bool UpdateNatural(NaturalPersonEntity entity)
        {
            var strSql = string.Format(@"UPDATE  [dbo].[PunishmentNp] SET
                       NaturalName='{1}'
                      ,IdCardType='{2}'
                      ,IdCard='{3}'
                      ,IllegalName='{4}'
                      ,DocumentNumber='{5}'
                      ,PunishmentBasis='{6}'
                      ,PunishmentResults='{7}'
                      ,FineMoney='{8}'
                      ,DishonestSeverity='{9}'
                      ,DishonestValidity='{10}'
                      ,OtherName='{11}'
                      ,DecidedTime='{12}'
                      ,InformationName='{13}'
                      ,Note='{14}'
                      ,MainDishonest='{15}'
                      ,PublicDeadline='{16}'
                      ,ROWSTATUS='{17}'
                      ,CREATOR_ID='{18}'
                      ,CREATE_BY='{19}'
                      ,CREATE_ON='{20}'
                      ,UPDATE_ID='{21}'
                      ,UPDATE_BY='{22}'
                      ,UPDATE_ON='{23}'
                      ,IsPush='{24}'
                       WHERE ID='{0}'",
                      entity.ID,
                      entity.NaturalName,
                      entity.IdCardType,
                      entity.IdCard,
                      entity.IllegalName,
                      entity.DocumentNumber,
                      entity.PunishmentBasis,
                      entity.PunishmentResults,
                      entity.FineMoney,
                      entity.DishonestSeverity,
                      entity.DishonestValidity,
                      entity.OtherName,
                      entity.DecidedTime,
                      entity.InformationName,
                      entity.Note,
                      entity.MainDishonest,
                      entity.PublicDeadline,
                      entity.ROWSTATUS,
                      entity.CREATOR_ID,
                      entity.CREATE_BY,
                      entity.CREATE_ON,
                      entity.UPDATE_ID,
                      entity.UPDATE_BY,
                      entity.UPDATE_ON,
                      entity.IsPush);

            ReadDatabase.Comment = new StringExtension.SqlComment
            {
                Author = "李傲",
                FileName = "NaturalPersonListDal.cs",
                ForUse = "修改自然人",
                FunName = "UpdateNatural"
            };

            return WriteDatabase.Execute(strSql) > 0;
        }

        /// <summary>
        /// 删除自然人
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleNatural(string ids)
        {
            var strSql = string.Format(@"UPDATE PUNISHMENT_NP SET ROWSTATUS='{0}' WHERE PK_ID='{1}'", (int)RowStatus.Delete, ids);
            return WriteDatabase.Execute(strSql) > 0;
        }

    }
}
