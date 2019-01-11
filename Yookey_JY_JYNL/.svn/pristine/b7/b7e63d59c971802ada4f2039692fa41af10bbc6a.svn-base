using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BasePetaPoco;
using Yookey.WisdomClassed.SIP.DataAccess.GridManagement;
using Yookey.WisdomClassed.SIP.Model.GridManagement;

namespace Yookey.WisdomClassed.SIP.Business.GridManagement
{
    public class GridManagementFileInfoBll : BaseBll<GridManagementFileInfoEntity>
    {
        /// <summary>
        /// 台账管理数据信息查询
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public PageJqDatagrid<GridManagementFileInfoEntity> GetSearchResult(GridManagementFileInfoEntity search)
        {
            try
            {
                return new GridManagementFileInfoDal().GetSearchResult(search);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">数据集（使用|进行分隔）</param>
        /// <returns></returns>
        public bool BatchDeleteFiles(string ids)
        {
            try
            {
                var list = new List<string>();
                if (!string.IsNullOrEmpty(ids))
                {
                    var idSplit = ids.Split('|');
                    list.AddRange(idSplit.Where(id => !string.IsNullOrEmpty(id)));
                    return new GridManagementFileInfoDal().BatchDeleteFiles(list);
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
