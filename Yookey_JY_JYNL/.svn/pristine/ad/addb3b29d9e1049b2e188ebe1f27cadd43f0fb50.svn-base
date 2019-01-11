//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FolderBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/11 17:21:36
//  功能描述：Folder业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.IO;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Work;
using Yookey.WisdomClassed.SIP.Model.Work;
using System.Linq;

namespace Yookey.WisdomClassed.SIP.Business.Work
{
    /// <summary>
    /// Folder业务逻辑
    /// </summary>
    public class FolderBll : BaseBll<FolderEntity>
    {
        /// <summary>
        /// 文档的主目录
        /// </summary>
        static private string FolderRootPath = string.Format(@"{0}{1}\", AppConfig.FileSaveAddr, "Folder");

        public FolderBll()
        {
            BaseDal = new FolderDal();
        }

        /// <summary>
        /// 获取用户共享文件夹
        /// 创建人：周庆
        /// 创建日期：2015年5月15日
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<FolderEntity> GetShareFolder(string UserId)
        {
            List<FolderEntity> lstShare = new List<FolderEntity>();
            if (!string.IsNullOrEmpty(UserId))//具有查看权限的
                lstShare = new FolderDal().GetShareFolder(UserId, FolderPermitionEntity.PermitionTypeEnum.View);
            return lstShare;

        }

        /// <summary>
        /// 删除文件
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="filePath"></param>
        public void DeleteFile(string filePath)
        {
            string fullPath = string.Format(@"{0}Folder", AppConfig.FileSaveAddr) + filePath;
            try
            {
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// 删除文件夹
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="UpdateId"></param>
        /// <param name="UpdateName"></param>
        public void DeleteFolder(string Id, string UpdateId, string UpdateName)
        {

            if (!string.IsNullOrEmpty(Id))
            {
                FolderEntity entity = Get(Id);
                if (entity != null)
                {
                    entity.RowStatus = 0;
                    entity.UpdateId = UpdateId;
                    entity.UpdateBy = UpdateName;
                    entity.UpdateOn = DateTime.Now;
                    Update(entity);
                    //todo:
                    //子文件夹和文件并没有被删除
                }

            }
        }

        /// <summary>
        /// 获取目录面包屑
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="UserId"></param>
        /// <returns>[0]文件夹Id [1]文件夹名称</returns>
        public List<string> GetActiveFolderPath(string FolderId, string UserId)
        {
            List<FolderEntity> lstFolders = GetUserFolders(UserId);
            List<string> lstPathId = new List<string>();
            GetParentPath(FolderId, lstFolders, ref lstPathId);
            lstPathId.Reverse();//将list倒序

            //获取文件夹名称
            List<string> lstPathName = new List<string>(); ;
            foreach (string id in lstPathId)
                lstPathName.Add(lstFolders.Where(x => x.Id == id).Select(x => x.FolderName).FirstOrDefault());
            //将他们拼接起来 xx\xx\
            string strPathIds = string.Join(@"\", lstPathId);
            string strPathNames = string.Join(@"\", lstPathName);
            List<string> lstResult = new List<string>();
            lstResult.Add(strPathIds);
            lstResult.Add(strPathNames);
            return lstResult;
        }

        /// <summary>
        /// 递归获取父级目录Id
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="lstFolders"></param>
        /// <param name="path"></param>
        private void GetParentPath(string FolderId, List<FolderEntity> lstFolders, ref List<string> path)
        {
            path.Add(FolderId);
            var parent = lstFolders.Where(x => x.Id == FolderId).Select(x => x.ParentId);
            if (parent.Count() == 0)
            {
                return;
            }
            else
            {
                string Id = parent.FirstOrDefault();
                GetParentPath(Id, lstFolders, ref path);
            }


        }

        /// <summary>
        /// 获取目录下的子目录和文件
        /// 创建人：周庆
        /// 创建日期：2015年5月12日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<FileSysEntity> GetFolderFilesAndFolders(string FolderId, string UserId)
        {
            List<FileSysEntity> filesAndFolders = new List<FileSysEntity>();
            if (FolderId == "share")//共享文件主目录Id
            {
                List<FolderEntity> shareFolder = new FolderDal().GetShareFolder(UserId, FolderPermitionEntity.PermitionTypeEnum.View);
                filesAndFolders.AddRange(shareFolder.Select(x => new FileSysEntity()
                {
                    Id = x.Id,
                    FileName = string.Format("{0}({1})", x.FolderName, x.CreateBy),
                    FileType = FileSysEntity.FileTypeEnum.Folder,
                    FileSize = "--",
                    FileDate = x.UpdateOn,
                    Extension = "folder"
                }).ToList());
            }
            else
            {
                //获取子目录
                List<FileSysEntity> childFoldes = new FolderDal().GetChildFolders(FolderId, UserId);
                filesAndFolders.AddRange(childFoldes);
                //获取文件
                List<FileSysEntity> lstFiles = GetFolderFiles(FolderId);
                filesAndFolders.AddRange(lstFiles);
            }
            return filesAndFolders;
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
            return new FolderDal().GetUserFolders(UserId);
        }

        /// <summary>
        /// 创建或修改文件夹
        /// 创建人：周庆
        /// 创建日期：2015年5月12日
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string CreateOrUpdateFolder(FolderEntity entity)
        {
            string Id = entity.Id;
            if (!string.IsNullOrEmpty(Id))
            {
                FolderEntity one = BaseDal.Get(Id);
                if (one != null)//修改
                {
                    entity.RowStatus = 1;
                    entity.UpdateOn = DateTime.Now;
                    BaseDal.Update(entity);
                    return Id;
                }
            }
            //新增
            Id = entity.Id = Guid.NewGuid().ToString();
            entity.RowStatus = 1;
            entity.CreateOn = DateTime.Now;
            entity.UpdateOn = DateTime.Now;
            BaseDal.Add(entity);
            //创建真实的文件夹，文件夹名称是ID
            //注意：所有的文件夹都是同一级目录的，通过folder表来呈现层级关系
            CreatePhyFolder(Id);
            return Id;
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
            return new FolderDal().ExistFolderName(ParentId, FolderName, UserId);
        }

        /// <summary>
        /// 创建硬盘上真实的文件夹
        /// 创建人：周庆
        /// 创建日期：2015年5月12日
        /// </summary>
        /// <param name="FolderName"></param>
        static public void CreatePhyFolder(string FolderName)
        {
            try
            {
                string dirPath = FolderRootPath + FolderName;
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取文件夹下的文件
        /// 创建人：周庆
        /// 创建日期：2015年5月12日
        /// </summary>
        /// <param name="FolderName">文件夹名称</param>
        /// <returns></returns>
        static public List<FileSysEntity> GetFolderFiles(string FolderName)
        {
            string dirPath = FolderRootPath + FolderName;
            List<FileSysEntity> lstFile = new List<FileSysEntity>();

            DirectoryInfo Folder = new DirectoryInfo(dirPath);
            foreach (FileInfo file in Folder.GetFiles())
            {
                lstFile.Add(new FileSysEntity()
                {
                    FileName = file.Name,
                    FileType = FileSysEntity.FileTypeEnum.File,
                    FileSize = (file.Length / 1024f).ToString("0.00") + "KB",
                    FileDate = file.LastWriteTime,
                    FullPath = string.Format("/Folder/{0}/{1}", FolderName, file.Name),
                    Extension = file.Extension.Substring(1)
                });
            }
            return lstFile;
        }
    }
}
