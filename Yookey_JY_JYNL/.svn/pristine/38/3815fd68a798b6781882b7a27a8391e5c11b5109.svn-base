using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.DocumentManagement;
using Yookey.WisdomClassed.SIP.Model.DocumentManagement;

namespace Yookey.WisdomClassed.SIP.Business.DocumentManagement
{
    public class DocumentOfficialBll
    {
        private static readonly DocumentOfficialDal Dal = new DocumentOfficialDal();

        /// <summary>
        /// 发文登记
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertOfficial(DocumentOfficialEntity entity)
        {
            return Dal.InsertOfficial(entity);
        }


        /// <summary>
        /// 修改发文
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateOfficial(DocumentOfficialEntity entity)
        {
            return Dal.UpdateOfficial(entity);
        }

        /// <summary>
        /// 获取发文
        /// </summary>
        /// <returns></returns>
        public List<DocumentOfficialEntity> GetSearchListOfficial(DocumentOfficialEntity search)
        {
            return Dal.GetSearchListOfficial(search);
        }

        /// <summary>
        /// 查询发文
        /// </summary>
        /// <returns></returns>
        //public PetaPoco.Page<DocumentOfficialEntity> GetSearchResult(DocumentOfficialEntity search)
        //{
        //    return Dal.GetSearchResult(search);
        //}
        public Page<DocumentOfficialEntity> GetSearchResult(string status, string userName, int pageSize = 30, int pageIndex = 1)
        {
            return Dal.GetSearchResult(status, userName, pageSize, pageIndex);
        }

        /// <summary>
        /// 删除发文
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteOfficial(string PK_ID)
        {
            return Dal.DeleteOfficial(PK_ID);
        }
    }
}
