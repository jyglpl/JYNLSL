using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.LawPunishInformation;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Model.LawPunishInformation;

namespace Yookey.WisdomClassed.SIP.Business.LawPunishInformation
{
    public class LegalPersonListBll
    {
        private static readonly LegalPersonListDal Dal = new LegalPersonListDal();

        /// <summary>
        /// 获取法人
        /// </summary>
        /// <returns></returns>
        public List<LegalPersonEntity> GetSearchListForPerson(LegalPersonEntity search)
        {
            return Dal.GetSearchListForPerson(search);
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

            var data = Dal.QueryLawpersonnelList(Name, pageSize, pageIndex, sidx, sord, out  totalRecords);

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
        /// 新增法人
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertLw(LegalPersonEntity entity)
        {
            return Dal.InsertLw(entity);
        }

        /// <summary>
        /// 更新法人
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateLw(LegalPersonEntity entity)
        {
            return Dal.UpdateLw(entity);
        }


        /// <summary>
        /// 删除法人
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteLegalPer(string PK_ID)
        {
            return Dal.DeleteLegalPer(PK_ID);
        }
    }
}
