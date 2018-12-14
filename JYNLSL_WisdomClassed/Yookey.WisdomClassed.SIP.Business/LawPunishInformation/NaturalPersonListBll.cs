using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.LawPunishInformation;
using Yookey.WisdomClassed.SIP.Model.LawPunishInformation;

namespace Yookey.WisdomClassed.SIP.Business.LawPunishInformation
{
    public class NaturalPersonListBll
    {
        private static readonly NaturalPersonListDal Dal = new NaturalPersonListDal();


        /// <summary>
        /// 获取自然人
        /// </summary>
        /// <returns></returns>
        public List<NaturalPersonEntity> GetSearchListForNaturalPerson(NaturalPersonEntity search)
        {
            return Dal.GetSearchListForNaturalPerson(search);
        }


        /// <summary>
        /// 查询自然人
        /// </summary>
        /// <returns></returns>
        public PageJqDatagrid<DataTable> GetSearchResult(string Name, string sidx, string sord, int pageSize = 15, int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;

            var data = Dal.QueryNppersonnelList(Name, pageSize, pageIndex, sidx, sord, out  totalRecords);

            data.TableName = "GetSearchDT";
            stopwatch.Stop();
            int totalPage = (totalRecords + pageSize - 1) / pageSize;   //计算页数
            return new PageJqDatagrid<DataTable>
            {
                page = pageIndex,
                rows = data,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        /// <summary>
        /// 新增自然人
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertCorpora(NaturalPersonEntity entity)
        {
            return Dal.InsertCorpora(entity);
        }

        /// <summary>
        /// 修改自然人
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateNatural(NaturalPersonEntity entity)
        {
            return Dal.UpdateNatural(entity);
        }

        /// <summary>
        /// 删除自然人
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleNatural(string PK_ID)
        {
            return Dal.DeleNatural(PK_ID);
        }
    }
}
