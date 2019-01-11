using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.TestStatistic;

namespace Yookey.WisdomClassed.SIP.DataAccess.TestStatistic
{
   public  class TestStatisticDal : BaseDal<ExamInfomationEntity>
    {

       public Page<ExamInfomationEntity> GetSearchResult( string txtName, int pageSize, int pageIndex)
       {
           var strSql = new StringBuilder("");
           strSql.AppendFormat(@"SELECT tp.Title AS TE ,tp.isDeleted AS KS,tp.Fraction FR,EI.Tid,ei.uid ,MAX(tp.PassRatio)AS SO ,MIN(EI.Time)AS Date ,COUNT(*) AS ZS FROM dbo.ExamInfomation AS EI , TestPeriod as tp GROUP BY EI.Tid,ei.uid ,tp.Title,tp.Fraction,tp.isDeleted");
           var args = new List<object>();
           return WriteDatabase.Page<ExamInfomationEntity>(pageIndex, pageSize, strSql.ToString(), args.ToArray());
       }
    }
}
