using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Exam;

namespace Yookey.WisdomClassed.SIP.DataAccess.Exam
{
    public class OldAnswerDal : BaseDal<OldAnswerEntity>
    {
        /// <summary>
        /// 新增考试
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool InsertOld(OldAnswerEntity Entity)
        {
            var strSql = string.Format(@"INSERT INTO OldAnswer
(OId,TitemId,Answer,isError,NumItem)
VALUES
('{0}','{1}','{2}','{3}','{4}')",
Entity.OId, Entity.TitemId, Entity.Answer, Entity.isError, Entity.NumItem);
            return WriteDatabase.Execute(strSql) > 0;
        }
    }
}
