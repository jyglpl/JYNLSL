using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Yookey.WisdomClassed.SIP.Model.Base;

namespace Yookey.WisdomClassed.SIP.Model.Evaluation
{
    [TableName("EvaluationLog")]
    [PrimaryKey("Id")]
    [ExplicitColumns]
    public class EvaluationLogEntity
    {
        /// <summary>
        /// 自增字段
        /// </summary>
        [Column("Id")]
        [DataMember]
        public string Id { get; set; }

        private int _rowStatus = 1;
        /// <summary>
        /// 行状态(0:删除 1:正常)
        /// </summary>
        [Column("RowStatus")]
        [DataMember]
        public int RowStatus
        {
            get { return _rowStatus; }
            set { _rowStatus = value; }
        }

        /// <summary>
        /// 创建人Id
        /// </summary>
        [Column("CreatorId")]
        public string CreatorId { get; set; }

        private string _createby = string.Empty;
        /// <summary>
        /// 记录创建人
        /// </summary>
        [Column("CreateBy")]
        [DataMember]
        public string CreateBy
        {
            get { return _createby ?? string.Empty; }
            set { _createby = value; }
        }

        /// <summary>
        /// 记录创建时间
        /// </summary>
        [Column("CreateOn")]
        [DataMember]
        public DateTime CreateOn { get; set; }

        /// <summary>
        /// 更新人Id
        /// </summary>
        [Column("UpdateId")]
        public string UpdateId { get; set; }

        private string _updateby = string.Empty;
        /// <summary>
        /// 记录修改人
        /// </summary>
        [Column("UpdateBy")]
        [DataMember]
        public string UpdateBy
        {
            get { return _updateby ?? string.Empty; }
            set { _updateby = value; }
        }

        /// <summary>
        /// 记录修改时间
        /// </summary>
        [Column("UpdateOn")]
        [DataMember]
        public DateTime UpdateOn { get; set; }

        private Page _page;
        ///// <summary>
        ///// 分页实体
        ///// </summary>
        //public Page page
        //{
        //    get { return _page ?? new Page { PageSize = 10, CurrentPage = 1 }; }
        //    set { _page = value; }
        //}

        /// <summary>
        /// 考核对象Id
        /// </summary>
        [Column("EvaluationObjId")]
        [DataMember]
        public string EvaluationObjId { get; set; }

        /// <summary>
        /// 考核对象名称
        /// </summary>
        [Column("ObjName")]
        [DataMember]
        public string ObjName { get; set; }

        /// <summary>
        /// 所属考核模块Id
        /// </summary>
        [Column("EvaluationModId")]
        [DataMember]
        public string EvaluationModId { get; set; }

        /// <summary>
        /// 所属考核模块
        /// </summary>
        [Column("ModName")]
        [DataMember]
        public string ModName { get; set; }

        /// <summary>
        /// 考核项Id
        /// </summary>
        [Column("EvaluationProcId")]
        [DataMember]
        public string EvaluationProcId { get; set; }

        /// <summary>
        /// 考核项
        /// </summary>
        [Column("ProcName")]
        [DataMember]
        public string ProcName { get; set; }

        /// <summary>
        /// 考核细则Id
        /// </summary>
        [Column("EvaluationBasisId")]
        [DataMember]
        public string EvaluationBasisId { get; set; }

        /// <summary>
        /// 考核细则
        /// </summary>
        [Column("BasisName")]
        [DataMember]
        public string BasisName { get; set; }

        /// <summary>
        /// 考核方式Id
        /// </summary>
        [Column("EvaluationMethodId")]
        [DataMember]
        public string EvaluationMethodId { get; set; }

        /// <summary>
        /// 考核方式
        /// </summary>
        [Column("MethodName")]
        [DataMember]
        public string MethodName { get; set; }

        /// <summary>
        /// 奖惩
        /// </summary>
        [Column("IsRewards")]
        [DataMember]
        public int IsRewards { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        [Column("Points")]
        [DataMember]
        public double Points { get; set; }

        /// <summary>
        /// 分数占比
        /// </summary>
        [Column("Score")]
        [DataMember]
        public int Score { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Column("Remark")]
        [DataMember]
        public string Remark { get; set; }

        /// <summary>
        /// 考核人Id
        /// </summary>
        [Column("InspectorId")]
        [DataMember]
        public string InspectorId { get; set; }

        /// <summary>
        /// 考核人姓名
        /// </summary>
        [Column("InspectorName")]
        [DataMember]
        public string InspectorName { get; set; }

        /// <summary>
        /// 考核日期
        /// </summary>
        [Column("CheckDate")]
        [DataMember]
        public DateTime CheckDate { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        [DataMember]
        public string ImgSrc { get; set; }
    }
}
