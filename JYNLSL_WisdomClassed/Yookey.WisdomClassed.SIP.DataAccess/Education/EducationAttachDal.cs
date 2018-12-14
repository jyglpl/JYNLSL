using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Education;

namespace Yookey.WisdomClassed.SIP.DataAccess.Education
{
    /// <summary>
    /// EducationAttach数据访问操作
    /// </summary>
    public class EducationAttachDal : DalImp.BaseDal<EducationAttachEntity>
    {
        public EducationAttachDal()
        {
            Model = new EducationAttachEntity();
        }
    }
}
