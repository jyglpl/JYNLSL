using PetaPoco;
using Yookey.WisdomClassed.SIP.Business.BasePetaPoco;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.WisdomClassed.SIP.Business.Com
{
    public class ComApiAccountBll : BaseBll<ComApiAccountEntity>
    {
        private static readonly ComApiAccountDal Dal = new ComApiAccountDal();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public Page<ComApiAccountEntity> GetSearchResult(ComApiAccountEntity search)
        {
            return Dal.GetSearchResult(search);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">Id集合（以,分隔）</param>
        /// <returns></returns>
        public bool BatchDelete(string ids)
        {
            return Dal.BatchDelete(ids);
        }

        /// <summary>
        /// 验证帐号ID是否存在
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="accountId">帐号ID</param>
        /// <returns></returns>
        public bool AccountIdExists(string accountId, int id)
        {
            return Dal.AccountIdExists(accountId, id);
        }

        /// <summary>
        /// 根据接口账号获取实体
        /// </summary>
        /// <param name="accountId">帐号ID</param>
        /// <returns></returns>
        public ComApiAccountEntity GetComApiAccount(string accountId)
        {
            return Dal.GetComApiAccount(accountId);
        }
    }
}