using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.DocumentManagement;
using Yookey.WisdomClassed.SIP.Model.DocumentManagement;

namespace Yookey.WisdomClassed.SIP.Business.DocumentManagement
{
   public class DocumentAttachBll
   {
       private static readonly DocumentAttachDal Dal = new DocumentAttachDal();

        /// <param name="search">查询条件</param>
        /// <returns></returns>
       public List<DocumentIncomingAttachEntity> GetSearchResult(DocumentIncomingAttachEntity search, List<string> types)
        {
            return Dal.GetSearchResult(search, types);
        }


       /// <summary>
       /// 根据Id查找附件
       /// </summary>
       /// <param name="search"></param>
       /// <returns></returns>
       public List<DocumentIncomingAttachEntity> GetAllResult(DocumentIncomingAttachEntity search)
       {
           return Dal.GetAllResult(search);
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
       /// 新增附件材料
       /// </summary>
       /// <param name="search"></param>
       /// <returns></returns>
       public bool InsertDocumentCaseAttach(DocumentIncomingAttachEntity search)
       {
           return Dal.InsertDocumentCaseAttach(search);
       }
    }
}
