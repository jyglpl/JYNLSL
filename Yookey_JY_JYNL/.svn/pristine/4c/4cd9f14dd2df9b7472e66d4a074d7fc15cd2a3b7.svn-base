using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.TestStatistic;
using Yookey.WisdomClassed.SIP.Model.TestStatistic;

namespace Yookey.WisdomClassed.SIP.Business.TestStatistic
{
   public class TestStatisticBLL
    {
       private static readonly TestStatisticDal Dal = new TestStatisticDal();

       public Page<ExamInfomationEntity> GetSearchResult(string txtName, int pageSize = 30, int pageIndex = 1)
        {
            return Dal.GetSearchResult(txtName, pageSize, pageIndex);
        }
    }
}
