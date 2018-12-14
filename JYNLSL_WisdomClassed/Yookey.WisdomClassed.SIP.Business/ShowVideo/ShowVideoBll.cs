using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.ShowVideo;
using Yookey.WisdomClassed.SIP.Model.ShowVideo;

namespace Yookey.WisdomClassed.SIP.Business.ShowVideo
{

    /// <summary>
    /// ShowVideo业务逻辑
    /// </summary>
    public class ShowVideoBll : BaseBll<ShowVideoEntity>
    {
        public ShowVideoBll()
        {
            BaseDal = new ShowVideoDal();
        }

        /// <summary>
        /// 查询所有有效的演示视频
        /// </summary>
        /// <returns></returns>
        public List<ShowVideoEntity> GetAllVideos()
        {
            try
            {
                return new ShowVideoDal().GetAllVideos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
