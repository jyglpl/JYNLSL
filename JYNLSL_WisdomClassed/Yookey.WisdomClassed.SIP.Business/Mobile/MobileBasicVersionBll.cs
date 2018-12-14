using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Mobile;
using Yookey.WisdomClassed.SIP.Model;
using Yookey.WisdomClassed.SIP.Model.Mobile;

namespace Yookey.WisdomClassed.SIP.Business.Mobile
{
    public class MobileBasicVersionBll : BaseBll<MobileBasicVersionEntity>
    {
        public MobileBasicVersionBll()
        {
            BaseDal = new MobileBasicVersionDal();
        }

        /// <summary>
        /// 获取配置表的基础数据信息
        /// </summary>
        /// <param name="maxVersion"></param>
        /// <returns></returns>
        public string BasicVersion(string maxVersion)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(MobileBasicVersionEntity.Parm_Mobile_BasicVersion_RowStatus, "1");
            //查询大于版本号的数据
            queryCondition.AddLarger(MobileBasicVersionEntity.Parm_Mobile_BasicVersion_VersionNum, maxVersion);
            queryCondition.AddOrderBy(MobileBasicVersionEntity.Parm_Mobile_BasicVersion_VersionNum, true);
            var list = Query(queryCondition);
            var sqlList = new List<string>();
            if (list.Count > 0)
            {
                foreach (var item in list)  
                {
                    if (!string.IsNullOrEmpty(item.CreateSql))
                    {
                        sqlList.Add(item.CreateSql);
                    }
                    if (!string.IsNullOrEmpty(item.InsertSql))
                    {
                        sqlList.Add(item.InsertSql);
                    }
                    sqlList.Add(string.Format("INSERT INTO Mobile_BasicVersion VALUES ('{0}','{1}','','')", item.Id, item.VersionNum));
                }
                return string.Join(";", sqlList.ToArray());
            }
            else
            {
                return "";
            }
        }
    }
}
