using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Exam
{
    public class ExamEnumEntity
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string RsKey { get; set; }

    }
}
