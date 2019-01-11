using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Evaluation;
using Yookey.WisdomClassed.SIP.Model.Evaluation;

namespace Yookey.WisdomClassed.SIP.Business.Evaluation
{
    public class EvaluationAttachBll
    {
        private static readonly EvaluationAttachDal Dal = new EvaluationAttachDal();
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="search"></param>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public List<EvaluationAttachEntity> GetAllResult(EvaluationAttachEntity search)
        {
            return Dal.GetAllResult(search);
        }
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="search"></param>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public List<EvaluationAttachEntity> GetSearchResult(EvaluationAttachEntity search, List<string> types)
        {
            return Dal.GetSearchResult(search, types);
        }
        public List<EvaluationAttachEntity> GetSearchResult(EvaluationAttachEntity search)
        {
            return Dal.GetSearchResult(search);
        }
         /// <summary>
        /// 新增附件材料
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public bool Insert(EvaluationAttachEntity search)
        {
            return Dal.Insert(search);
        }
        /// <summary>
        /// 根据主键删除附件
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            return Dal.Delete(id);
        }
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EvaluationAttachEntity Get(string Id)
        {
            return Dal.Get(Id);
        }
         /// <summary>
        /// 根据主键更新附件备注
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int UpdateRemark(string Id, string Remark)
        {
            return Dal.UpdateRemark(Id, Remark);
        }
        /// <summary>
        /// 修改附件
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(EvaluationAttachEntity entity)
        {
            return Dal.Update(entity);
        }
    }
}
