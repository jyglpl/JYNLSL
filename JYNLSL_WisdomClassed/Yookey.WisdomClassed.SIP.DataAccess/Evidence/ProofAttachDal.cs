using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Model.Evidence;

namespace Yookey.WisdomClassed.SIP.DataAccess.Evidence
{
    public class ProofAttachDal : BaseDal<ProofAttachEntity>
    {
        /// <summary>
        /// 获取执法记录附件
        /// </summary>
        /// <returns></returns>
        public List<ProofAttachEntity> GetSearchResult(ProofAttachEntity search)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM INF_PUNISH_ATTACH_PROOF Where 1 = 1");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(search.SYS_ID))
            {
                strSql.AppendFormat(@" AND SYS_ID='{0}'", search.SYS_ID);
            }
            if (!string.IsNullOrEmpty(search.KeyWords))
            {
                strSql.AppendFormat(@" AND ( filename LIKE '%{0}%' OR deviceno LIKE '%{1}%')", search.KeyWords, search.KeyWords);
            }
            if (!string.IsNullOrEmpty(search.FILENAME))
            {
                strSql.AppendFormat(@" AND filename LIKE '%{0}%'", search.FILENAME);
            }
            if (!string.IsNullOrEmpty(search.USERID))
            {
                strSql.AppendFormat(@" AND USERID='{0}'", search.USERID);
            }
            if (!string.IsNullOrEmpty(search.DEVICENO))
            {
                strSql.AppendFormat(@" AND deviceno LIKE '%{0}%'", search.DEVICENO);
            }
            if (!string.IsNullOrEmpty(search.FILETYPE))
            {
                strSql.AppendFormat(@" AND filetype='{0}'", search.FILETYPE);
            }
            if (!string.IsNullOrEmpty(search.StartDate))
            {
                strSql.AppendFormat(@" AND CREATEDATE >= '{0}'", search.StartDate + "00:00:00");
            }
            if (!string.IsNullOrEmpty(search.EndDate))
            {
                strSql.AppendFormat(@" AND CREATEDATE <= '{0}'", search.EndDate + "23:59:59");
            }
            if (!string.IsNullOrEmpty(search.ISUPFISNISH))
            {
                strSql.AppendFormat(@" AND ISUPFISNISH='{0}'", search.ISUPFISNISH);
            }
            strSql.Append(" ORDER BY CREATEDATE Desc");
            return WriteDatabase.Query<ProofAttachEntity>(strSql.ToString(), args.ToArray()).ToList();
        }

        /// <summary>
        /// 获取执法记录附件(xj)
        /// </summary>
        /// <returns></returns>
        public List<ProofAttachEntity> GetSearchResult(ProofAttachEntity search, string UserId)
        {
            string afsj = search.CTIME;
            string stratTime = "";
            string endTime = "";
            if (!string.IsNullOrEmpty(search.CTIME))
            {
                stratTime = Convert.ToDateTime(afsj).AddHours(-1).ToString("yyyy-MM-dd HH:mm:ss");
                endTime = Convert.ToDateTime(afsj).AddHours(1).ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (!string.IsNullOrEmpty(search.StartDate))
            {
                stratTime = search.StartDate + " 00:00:00";
            }
            if (!string.IsNullOrEmpty(search.EndDate))
            {
                endTime = search.EndDate + " 23:59:59";
            }

            string useridlist = "";
            string[] lst = UserId.Split(',');
            for (int i = 0; i < lst.Length; i++)
            {
                if (lst[i] != "")
                {
                    useridlist += "'" + lst[i] + "',";
                }
            }
            if (useridlist != "")
            {
                useridlist = useridlist.Substring(0, useridlist.Length - 1);
            }

            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT * FROM INF_PUNISH_ATTACH_PROOF Where 1=1");
            var args = new List<object>();
            if (!string.IsNullOrEmpty(stratTime))
            {
                strSql.AppendFormat(@" AND CTIME >= '{0}'", stratTime);
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strSql.AppendFormat(@" AND CTIME <= '{0}'", endTime);
            }
            if (!string.IsNullOrEmpty(useridlist))
            {
                strSql.AppendFormat(@" AND USERID in ({0})", useridlist);
            }
            if (!string.IsNullOrEmpty(search.ADDRESS))
            {
                strSql.AppendFormat(@" AND ADDRESS like '%{0}%'", search.ADDRESS);
            }

            strSql.Append(" ORDER BY CTIME Desc");
            return WriteDatabase.Query<ProofAttachEntity>(strSql.ToString(), args.ToArray()).ToList();
        }


        /// <summary>
        /// 删除电子证据信息
        /// </summary>
        /// <param name="sid">电子证据编号</param>
        /// <param name="type">删除类型：1：临时删除，2：永久删除</param>
        /// <returns></returns>
        public bool DeleteEvidence(string sid, string type)
        {
            try
            {
                var strSql = string.Format("update inf_punish_attach_proof set {0}=1 where Sys_Id='{1}'", type == "1" ? "ISTEMPORARYDEL" : "ISPERMANENTDEL", sid);
                return WriteDatabase.Execute(strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 更新电子证据信息
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public bool UpdateEvidence(ProofAttachEntity search)
        {
            try
            {
                var strSql = string.Format("update inf_punish_attach_proof set REMARK='{0}',ADDRESS='{1}',USERID='{3}',CTIME='{4}',FIRSTCATEGORYID='{5}',FIRSTCATEGORYNAME='{6}',SECONDCATEGORYID='{7}',SECONDCATEGORYNAME='{8}' where Sys_Id='{2}'", search.REMARK, search.ADDRESS, search.SYS_ID, search.USERID, search.CTIME, search.FIRSTCATEGORYID, search.FIRSTCATEGORYNAME, search.SECONDCATEGORYID, search.SECONDCATEGORYNAME);
                return WriteDatabase.Execute(strSql) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
