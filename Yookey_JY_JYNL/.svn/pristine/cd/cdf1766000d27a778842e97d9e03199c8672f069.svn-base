using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.IllegalConstruction;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;

namespace Yookey.WisdomClassed.SIP.Business.IllegalConstruction
{
    public class IllegalCaseAttachBll
    {
        private static readonly IllegalCaseAttachDal Dal = new IllegalCaseAttachDal();

        /// <summary>
        /// 查询案件对应的附件
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        public List<IllegalCaseAttachEntity> GetAllResult(IllegalCaseAttachEntity search)
        {
            return Dal.GetAllResult(search);
        }

        /// <summary>
        /// 查询案件对应的附件
        /// </summary>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        public List<IllegalCaseAttachEntity> GetSearchResult(IllegalCaseAttachEntity search, List<string> types)
        {
            return Dal.GetSearchResult(search, types);
        }

        /// <summary>
        /// 新增附件材料
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool InsertIllegalCaseAttach(IllegalCaseAttachEntity search)
        {
            return Dal.InsertIllegalCaseAttach(search);
        }

        /// <summary>
        /// 根据主键更新附件
        /// </summary>
        /// <param name="PK_ID"></param>
        /// <returns></returns>
        public int UpdateIllegalCaseAttach(string PK_ID)
        {
            return Dal.UpdateIllegalCaseAttach(PK_ID);
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="PK_ID"></param>
        /// <returns></returns>
        public IllegalCaseAttachEntity searchEntity(string PK_ID)
        {
            return Dal.searchEntity(PK_ID);
        }


        /// <summary>
        /// 根据主键更新附件备注
        /// </summary>
        /// <param name="PK_ID"></param>
        /// <returns></returns>
        public int UpdateRemark(string PK_ID, string Remark)
        {
            return Dal.UpdateRemark(PK_ID, Remark);
        }
    }
}
