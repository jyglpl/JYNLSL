using PetaPoco;
using Yookey.WisdomClassed.SIP.Business.BasePetaPoco;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model.Com;

namespace Yookey.SIP.ZHZF.Business.Com
{
    public class ComVersionManagementBll : BaseBll<ComVersionManagementEntity>
    {
        private static readonly ComVersionManagementDal Dal = new ComVersionManagementDal();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public Page<ComVersionManagementEntity> GetSearchResult(ComVersionManagementEntity search)
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
        /// 验证名称是否存在
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">名称</param>
        /// <param name="mobileType">手机类型</param>
        /// <returns></returns>
        public bool NameExists(string name, int id, int mobileType)
        {
            return Dal.NameExists(name, id, mobileType);
        }

        /// <summary>
        /// 验证版本序列号
        /// </summary>
        /// <param name="versionNo">验证的版本序列号</param>
        /// <param name="mobileType">手机类型</param>
        /// <returns></returns>
        public bool VersionNoExists(int versionNo, int mobileType)
        {
            return Dal.VersionNoExists(versionNo, mobileType);
        }

        /// <summary>
        /// 验证文件版本号
        /// </summary>
        /// <param name="fileVersionNo">验证的文件版本号</param>
        /// <param name="mobileType">手机类型</param>
        /// <returns></returns>
        public bool FileVersionExists(string fileVersionNo, int mobileType)
        {
            return Dal.FileVersionExists(fileVersionNo, mobileType);
        }

        /// <summary>
        /// 根据手机类型获取最新版本信息
        /// </summary>
        /// <returns></returns>
        public ComVersionManagementEntity GetNewVersionInfo(int mobileType)
        {
            return Dal.GetNewVersionInfo(mobileType);
        }
    }
}