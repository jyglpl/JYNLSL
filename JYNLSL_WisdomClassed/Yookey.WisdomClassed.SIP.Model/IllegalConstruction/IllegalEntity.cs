using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.IllegalConstruction
{
    public class IllegalEntity
    {
        //责任单位Id
        public string UnitId { get; set; }
        //责任单位
        public string ResponsUnit { get; set; }
        //案件总数
        public int TotalCase { get; set; }
        //结案数量
        public int FinishCase { get; set; }
        //未结案数量
        public int NotClosed { get; set; }
        //拆除数量
        public int Dismantle { get; set; }
        //拆除面积
        public double DismantleArea { get; set; }
    }
}
