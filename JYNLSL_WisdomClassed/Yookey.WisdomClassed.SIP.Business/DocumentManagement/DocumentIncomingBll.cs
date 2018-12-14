using PetaPoco;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.DocumentManagement;
using Yookey.WisdomClassed.SIP.Model.DocumentManagement;

namespace Yookey.WisdomClassed.SIP.Business.DocumentManagement
{
    public class DocumentIncomingBll
    {
        private static readonly DocumentIncomingDal Dal = new DocumentIncomingDal();


        /// <summary>
        /// 新增收文
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertIncoming(DocumentIncomingEntity entity)
        {
            return Dal.InsertIncoming(entity);
        }

        /// <summary>
        /// 修改法文
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateIncoming(DocumentIncomingEntity entity)
        {
            return Dal.UpdateIncoming(entity);
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool UpdateStatus(string FormID, string UserId)
        {
            return Dal.UpdateStatus(FormID, UserId);
        }

        /// <summary>
        /// 获取收文
        /// </summary>
        /// <returns></returns>
        public List<DocumentIncomingEntity> GetSearchListIncoming(DocumentIncomingEntity search)
        {
            return Dal.GetSearchListIncoming(search);
        }

        /// <summary>
        /// 查询收文
        /// </summary>
        /// <returns></returns>

        public Page<DocumentIncomingEntity> GetSearchResult(string status, string Unit, int pageSize = 30, int pageIndex = 1)
        {
            return Dal.GetSearchResult(status, Unit, pageSize, pageIndex);
        }

        /// <summary>
        /// 未完成查询收文
        /// </summary>
        /// <returns></returns>

        public Page<DocumentIncomingEntity> GetSearchResultwwc(string paperType, string txtName, int pageSize = 30, int pageIndex = 1)
        {
            return Dal.GetSearchResultwwc(paperType, txtName, pageSize, pageIndex);
        }

        /// <summary>
        /// 删除收文
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteIncoming(string Pk_Id)
        {
            return Dal.DeleteIncoming(Pk_Id);
        }


        /// <summary>
        /// 收文统计
        /// </summary>
        /// <returns></returns>
        public List<DocumentTJ> GetDeptStatisticsData()
        {

            string StarTime = "2018-01-01";
            string EndTime = "2019-12-31";
            List<DocumentTJ> ctList = new List<DocumentTJ>();
            DataTable dt = Dal.GetDeptStatisticsData(StarTime, EndTime);
            int tot = 0;
            for (int i = 0; i < 12; i++)
            {
                DataRow[] dts = dt.Select("Month=" + "'" + (i + 1).ToString() + "'");
                if (dts.Length.Equals(1))
                {
                    DocumentTJ tj = new DocumentTJ()
                    {
                        Month = int.Parse(dts[0]["Month"].ToString()),
                        CT = dts[0]["CT"].ToString()
                    };
                    ctList.Add(tj);
                }
                else
                {
                    DocumentTJ tj = new DocumentTJ()
                    {
                        Month = int.Parse((i + 1).ToString()),
                        CT = "0"
                    };
                    ctList.Add(tj);
                }
                tot += Convert.ToInt32(ctList[i].CT);
            }
            DocumentTJ tjNew = new DocumentTJ();
            tjNew.Month = 13;
            tjNew.CT = tot.ToString();
            ctList.Add(tjNew);
            return ctList.OrderBy(p => p.Month).ToList();

        }

        /// <summary>
        /// 发文统计
        /// </summary>
        /// <returns></returns>
        public List<DocumentTJ> GetGwStatisticsData()
        {

            string StarTime = "2018-01-01";
            string EndTime = "2019-12-31";
            List<DocumentTJ> ctList = new List<DocumentTJ>();
            DataTable dt = Dal.GetGwStatisticsData(StarTime, EndTime);
            int tot = 0;
            for (int i = 0; i < 12; i++)
            {
                DataRow[] dts = dt.Select("Month=" + "'" + (i + 1).ToString() + "'");
                if (dts.Length.Equals(1))
                {
                    DocumentTJ tj = new DocumentTJ()
                    {
                        Month = int.Parse(dts[0]["Month"].ToString()),
                        CT = dts[0]["CT"].ToString()
                    };
                    ctList.Add(tj);
                }
                else
                {
                    DocumentTJ tj = new DocumentTJ()
                    {
                        Month = int.Parse((i + 1).ToString()),
                        CT = "0"
                    };
                    ctList.Add(tj);
                }
                tot += Convert.ToInt32(ctList[i].CT);
            }
            DocumentTJ tjNew = new DocumentTJ();
            tjNew.Month = 13;
            tjNew.CT = tot.ToString();
            ctList.Add(tjNew);
            return ctList.OrderBy(p => p.Month).ToList();

        }
    }

    public class DocumentTJ
    {
        public int Month { get; set; }

        public string CT { get; set; }

    }
}
