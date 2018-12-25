using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.DataAccess.Base;
using Yookey.WisdomClassed.SIP.Enumerate;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Model.OA;

namespace Yookey.WisdomClassed.SIP.DataAccess.OA
{
    public class DocNotfPersonDal : BaseDal<DocNotfPersonEntity>
    {
        /// <summary>
        /// 事务插入接收人
        /// 该事务后期增加插入公告表的内容
        /// add by lpl
        /// 2018-12-24
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SaveDocNotPerson(List<DocNotfPersonEntity> list)
        {
            var transaction = new TransactionLoader().BeginTransaction("SaveDocNotPerson");
            try
            {

                var sbSql = new StringBuilder();

                foreach (DocNotfPersonEntity person in list)
                {
                    sbSql.AppendFormat(@"INSERT INTO dbo.DocNotfPerson(Name,Pid,FilePath,IsJS,RowStatus,CreatorId,CreateBy,CreateOn,UpdateId,UpdateBy,UpdateOn,ContentId,Title,Category,Publisher,ReleaseTime)
                                        VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}');", person.Name,person.Pid,person.FilePath,person.IsJS,person.RowStatus,person.CreatorId,person.CreateBy,person.CreateOn,person.UpdateId,person.UpdateBy,person.UpdateOn,person.ContentId,person.Title,person.Category,person.Publisher, person.ReleaseTime);
                }

                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
        
            }
            transaction.Commit();
            return true;
        }



        /// <summary>
        /// 更新已读和未读状态
        /// </summary>
        /// <param name="ContetId"></param>
        /// <returns></returns>
        public bool UpdateDocState(string ContetId, string Pid)
        {
            var transaction = new TransactionLoader().BeginTransaction("UpdateDocState");
            try
            {

                var sbSql = new StringBuilder("");

                sbSql.AppendFormat("UPDATE dbo.DocNotfPerson SET IsJS = 1 WHERE ContentId = '{0}' AND Pid = '{1}';", ContetId,Pid);
                sbSql.AppendFormat("UPDATE dbo.DocumentNotification SET JieShouCount = JieShouCount + 1 WHERE Id = '{0}';",ContetId);

                SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;

            }
 
        }

        /// <summary>
        /// 判断是否已读
        /// </summary>
        /// <param name="ContetId"></param>
        /// <param name="Pid"></param>
        /// <returns></returns>
        public bool IsRead(string ContetId,string Pid)
        {
            try
            {
                var sbSql = new StringBuilder("");
                sbSql.AppendFormat("SELECT * FROM dbo.DocNotfPerson WHERE ContentId = '{0}' AND Pid = '{1}'",ContetId,Pid);

                DataTable dt = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, sbSql.ToString()).Tables[0];

                if (dt.Rows[0]["IsJS"].ToString() == "1")
                {
                    //已读
                    return true;
                }
                else
                {
                    //未读
                    return false;
                }


            }
            catch (Exception e)
            {
              
                throw e;
            }
        }

        public List<DocNotfPersonEntity> SearchQuery(DocNotfPersonEntity entity, string limittime = null)
        {

            var strSql = new StringBuilder("");
            strSql.AppendFormat(@"SELECT Id,ContentId,Pid,Title,ReleaseTime,IsJS,Publisher,Category,(SELECT RealName FROM dbo.CrmUser WHERE dbo.CrmUser.Id = dbo.DocNotfPerson.Pid) AS Name FROM dbo.DocNotfPerson WHERE RowStatus = 1 ");

            if (!string.IsNullOrEmpty(entity.Pid))
            {
                strSql.AppendFormat("AND Pid = '{0}'", entity.Pid);

            }

            if (!string.IsNullOrEmpty(entity.ContentId))
            {
                strSql.AppendFormat("AND ContentId = '{0}'", entity.ContentId);
            }

            if (!string.IsNullOrEmpty(entity.Title))
            {
                strSql.AppendFormat("AND Title LIKE '%{0}%'", entity.Title);
            }

            //时间范围搜索
            if (!string.IsNullOrEmpty(limittime))
            {
                string[] arryTime = limittime.Split('至');

                string startTime = arryTime[0];
                string endTime = arryTime[1];

                strSql.AppendFormat("AND ReleaseTime > '{0}' AND ReleaseTime < '{1}'", startTime, endTime);
            }

            //通告类型
            if (!string.IsNullOrEmpty(entity.Category))
            {
                strSql.AppendFormat("AND Category = '{0}'", entity.Category);
            }

            var list = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];

    
            return ToList<DocNotfPersonEntity>(list); 

        }


        /// <summary>    
        /// DataTable 转换为List 集合    
        /// </summary>    
        /// <typeparam name="TResult">类型</typeparam>    
        /// <param name="dt">DataTable</param>    
        /// <returns></returns>    
        public static List<T> ToList<T>(DataTable dt) where T : class, new()
        {
            //创建一个属性的列表    
            List<PropertyInfo> prlist = new List<PropertyInfo>();
            //获取TResult的类型实例  反射的入口    

            Type t = typeof(T);

            //获得TResult 的所有的Public 属性 并找出TResult属性和DataTable的列名称相同的属性(PropertyInfo) 并加入到属性列表     
            Array.ForEach<PropertyInfo>(t.GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) prlist.Add(p); });

            //创建返回的集合    

            List<T> oblist = new List<T>();

            foreach (DataRow row in dt.Rows)
            {
                //创建TResult的实例    
                T ob = new T();
                //找到对应的数据  并赋值    
                prlist.ForEach(p => { if (row[p.Name] != DBNull.Value) p.SetValue(ob, row[p.Name], null); });
                //放入到返回的集合中.    
                oblist.Add(ob);
            }
            return oblist;
        }


    }


}
