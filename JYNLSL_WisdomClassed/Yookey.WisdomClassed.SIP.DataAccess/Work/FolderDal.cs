//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FolderDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/11 17:21:36
//  功能描述：Folder数据访问类
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
    /// Folder数据访问操作
    /// </summary>
    public class FolderDal : DalImp.BaseDal<FolderEntity>
    {
        public FolderDal()
        {
            Model = new FolderEntity();
        }

        /// <summary>
        /// 获取用户的共享文件夹
        /// 创建人：周庆
        /// 创建日期：2015年5月15日
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="type">权限</param>
        /// <returns></returns>
        public List<FolderEntity> GetShareFolder(string UserId,FolderPermitionEntity.PermitionTypeEnum type)
        {
            var selSql = string.Format(@"SELECT folder.Id,folder.FolderName,folder.ParentId,folder.RowStatus,folder.Version,folder.CreatorId,folder.CreateBy,folder.CreateOn,folder.UpdateId,folder.UpdateBy,folder.UpdateOn FROM Folder
                                            LEFT JOIN FolderPermition permition ON permition.FolderId = folder.Id
                                            WHERE permition.UserId = '{0}' AND permition.Permition = {1} AND permition.RowStatus = 1 AND Folder.RowStatus = 1", UserId, (int)type);
            var reader = SqlHelper.ExecuteReader(SqlHelper.SqlConnStringRead, CommandType.Text, selSql);
            var lstFolder = new List<FolderEntity>();
            while (reader.Read())
            {
                lstFolder.Add(new FolderEntity(reader));
            }
            return lstFolder;
        }

        /// <summary>
        /// 文件夹名称是否存在
        /// 创建人：周庆
        /// 创建日期：2015年5月12日
        /// </summary>
        /// <param name="ParentId">父目录Id</param>
        /// <param name="FolderName">文件夹名称</param>
        /// <param name="UserId">用户Id</param>
        /// <returns>true 存在 false 不存在</returns>
        public bool ExistFolderName(string ParentId, string FolderName, string UserId)
        {
            var selSql = string.Format(@"SELECT COUNT(id) FROM Folder
                                            WHERE FolderName = '{0}' AND ParentId='{1}' AND CreatorId = '{2}' AND RowStatus = 1", FolderName, ParentId, UserId);
            var count = Convert.ToInt32(SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, System.Data.CommandType.Text, selSql));
            return count > 0;
        }

        /// <summary>
        /// 获取目录下的所有子目录(不分页)
        /// 创建人：周庆
        /// 创建日期：2015年5月12日
        /// </summary>
        /// <param name="ParentId">父目录Id</param>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public List<FileSysEntity> GetChildFolders(string ParentId, string UserId)
        {
            var selSql = string.Format(@"SELECT Id,FolderName,UpdateOn FROM Folder
                                            WHERE ParentId = '{0}' AND CreatorId = '{1}' AND RowStatus = 1 ORDER BY CreateOn", ParentId, UserId);
            var reader = SqlHelper.ExecuteReader(SqlHelper.SqlConnStringRead, CommandType.Text, selSql);
            var lstFolder = new List<FileSysEntity>();
            while (reader.Read())
            {
                lstFolder.Add(new FileSysEntity(reader));
            }
            return lstFolder;
        }


        /// <summary>
        /// 获取用户的所有文件夹
        /// 创建人：周庆
        /// 创建日期：2015年5月12日
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public List<FolderEntity> GetUserFolders(string UserId)
        {
            var selSql = string.Format(@"SELECT Id,FolderName,ParentId,RowStatus,Version,CreatorId,CreateBy,CreateOn,UpdateId,UpdateBy,UpdateOn FROM Folder
                                            WHERE CreatorId = '{0}' AND RowStatus = 1 ORDER BY CreateOn", UserId);
            var reader = SqlHelper.ExecuteReader(SqlHelper.SqlConnStringRead, CommandType.Text, selSql);
            var lstFolder = new List<FolderEntity>();
            while (reader.Read())
            {
                lstFolder.Add(new FolderEntity(reader));
            }
            return lstFolder;
        }
    }
}

