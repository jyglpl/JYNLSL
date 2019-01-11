using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.OA;
using Yookey.WisdomClassed.SIP.Model.OA;

namespace Yookey.WisdomClassed.SIP.Business.OA
{
    public class DocNotfPersonBall
    {
        private static readonly DocNotfPersonDal Dal = new DocNotfPersonDal();

        /// <summary>
        /// 事务插入接收人
        /// add by lpl
        /// 2018-12-24
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertNotfPerson(List<DocNotfPersonEntity> list)
        {
            try
            {
                Dal.SaveDocNotPerson(list);
                return true;
            }
            catch (Exception e)
            {
   
                throw e;
            }
        }

        /// <summary>
        /// 查询公告通知接受人情况表
        /// 2018-12-24
        /// add by lpl
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public List<DocNotfPersonEntity> search(DocNotfPersonEntity entity, string limittime = null)
        {
            try
            {
                return Dal.SearchQuery(entity,limittime);
            }
            catch (Exception e)
            {
           
                throw e;
            }
        }

        /// <summary>
        /// 更新已读和未读状态
        /// </summary>
        /// <param name="ContetId"></param>
        /// <returns></returns>
        public bool UpdateDocState(string ContetId,string Pid)
        {
            try
            {
                return Dal.UpdateDocState(ContetId, Pid);
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        /// <summary>
        /// 判断是否已读
        /// </summary>
        /// <param name="ContetId"></param>
        /// <param name="Pid"></param>
        /// <returns></returns>
        public bool IsRead(string ContetId, string Pid)
        {
            return Dal.IsRead(ContetId, Pid);
        }


    }
}
