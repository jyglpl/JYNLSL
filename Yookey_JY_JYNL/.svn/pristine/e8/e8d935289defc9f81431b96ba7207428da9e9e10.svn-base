//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FolderPermitionDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/11 17:21:36
//  功能描述：FolderPermition数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Yookey.WisdomClassed.SIP.Model.Work;

namespace Yookey.WisdomClassed.SIP.DataAccess.Work
{
    /// <summary>
    /// FolderPermition数据访问操作
    /// </summary>
    public class FolderPermitionDal : DalImp.BaseDal<FolderPermitionEntity>
    {
        public FolderPermitionDal()
        {           
            Model = new FolderPermitionEntity();
        }

        /// <summary>
        /// 获取共享文件夹的权限
        /// 创建人：周庆
        /// 创建日期：2015年5月15日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="type"></param>
        /// <returns>DataTable [UserId][UserName]</returns>
        public DataTable GetShareFolderUserInfo(string FolderId, FolderPermitionEntity.PermitionTypeEnum type)
        {
            string selSQL = string.Format(@"
                                            SELECT
	                                            u.UserId,
	                                            u.RealName UserName
                                            FROM FolderPermition p
                                            left JOIN JCXXDB.dbo.Base_User u on u.UserId=p.UserId
                                            WHERE p.FolderId = '{0}'
                                            AND p.Permition = {1}
                                            AND p.RowStatus = 1", FolderId,(int)type);
            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, selSQL).Tables[0];
        }

        /// <summary>
        /// 获取一个文件夹的某个权限
        /// 创建人：周庆
        /// 创建日期：2015年5月14日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<FolderPermitionEntity> GetFolderPermition(string FolderId, FolderPermitionEntity.PermitionTypeEnum type)
        {
            string selSQL = string.Format(@"SELECT
	                                            Id,
	                                            FolderId,
	                                            UserId,
	                                            Permition,
	                                            RowStatus,
	                                            Version,
	                                            CreatorId,
	                                            CreateBy,
	                                            CreateOn,
	                                            UpdateId,
	                                            UpdateBy,
	                                            UpdateOn
                                            FROM FolderPermition
                                            WHERE FolderId = '{0}'
                                            AND Permition = {1}",FolderId,(int)type);
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.SqlConnStringRead, CommandType.Text, selSQL);
            List<FolderPermitionEntity> lstPermition = new List<FolderPermitionEntity>();
            while (reader.Read())
            {
                lstPermition.Add(new FolderPermitionEntity(reader));
            }
            return lstPermition;
        
        }

        /// <summary>
        /// 删除文件夹权限
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="UserId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int DeletePermition(string FolderId, string UserId, FolderPermitionEntity.PermitionTypeEnum type)
        {
            string updateSql = string.Format(@"UPDATE FolderPermition
                                                SET RowStatus = 0
                                                WHERE UserId = '{0}'
                                                AND FolderId = '{1}'
                                                AND Permition ={2} ", UserId, FolderId,(int)type);
          return  SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, updateSql);
        }

        /// <summary>
        /// 删除文件夹权限
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="UserId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int DeletePermition(string FolderId,FolderPermitionEntity.PermitionTypeEnum type)
        {
            string updateSql = string.Format(@"UPDATE FolderPermition
                                                SET RowStatus = 0
                                                WHERE FolderId = '{0}'
                                                AND Permition ={1} ", FolderId, (int)type);
            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringWrite, CommandType.Text, updateSql);
        }

        /// <summary>
        /// 获取权限
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="UserId"></param>
        /// <returns>返回一个权限集合</returns>
        public List<FolderPermitionEntity> GetPermition(string FolderId, string UserId)
        {
            string selSQL = string.Format(@"SELECT
	                                            Id,
                                                UserId,
	                                            FolderId,
	                                            Permition,
	                                            RowStatus,
	                                            Version,
	                                            CreatorId,
	                                            CreateBy,
	                                            CreateOn,
	                                            UpdateId,
	                                            UpdateBy,
	                                            UpdateOn
                                            FROM FolderPermition
                                            WHERE UserId = '{0}'
                                            AND FolderId = '{1}'", UserId,FolderId);
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.SqlConnStringRead, CommandType.Text, selSQL);
            List<FolderPermitionEntity> lstPermition = new List<FolderPermitionEntity>();
            while (reader.Read())
            {
                lstPermition.Add(new FolderPermitionEntity(reader));
            }
            return lstPermition;
        }

        /// <summary>
        /// 获取权限
        /// 创建人：周庆
        /// 创建日期：2015年5月14日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="UserId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public FolderPermitionEntity GetPermition(string FolderId, string UserId,FolderPermitionEntity.PermitionTypeEnum type)
        {
            string selSQL = string.Format(@"SELECT
	                                            Id,
                                                UserId,
	                                            FolderId,
	                                            Permition,
	                                            RowStatus,
	                                            Version,
	                                            CreatorId,
	                                            CreateBy,
	                                            CreateOn,
	                                            UpdateId,
	                                            UpdateBy,
	                                            UpdateOn
                                            FROM FolderPermition
                                            WHERE UserId = '{0}'
                                            AND FolderId = '{1}'
                                            AND Permition ={2}", UserId, FolderId,(int)type);
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.SqlConnStringRead, CommandType.Text, selSQL);
            FolderPermitionEntity permition=null;
            while (reader.Read())
            {
               permition=new FolderPermitionEntity(reader);
            }
            return permition;
        }
    }
}
                                                                                                                                         
