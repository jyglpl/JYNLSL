//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="FolderPermitionBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/5/11 17:21:36
//  功能描述：FolderPermition业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Data;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Work;
using Yookey.WisdomClassed.SIP.Model.Base;
using Yookey.WisdomClassed.SIP.Model.Work;

namespace Yookey.WisdomClassed.SIP.Business.Work
{
    /// <summary>
    /// FolderPermition业务逻辑
    /// </summary>
    public class FolderPermitionBll : BaseBll<FolderPermitionEntity>
    {
        public FolderPermitionBll()
        {
            BaseDal = new FolderPermitionDal();
        }

        /// <summary>
        /// 获取共享文件夹的人员信息
        /// 创建人：周庆
        /// 创建日期：2015年5月15日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="type"></param>
        /// <returns>[0] ids [1] names</returns>
        public List<string> GetShareFolderUserInfo(string FolderId, FolderPermitionEntity.PermitionTypeEnum type)
        {
            List<string> lstResult = new List<string>();
            if (!string.IsNullOrEmpty(FolderId))
            {
                DataTable table = new FolderPermitionDal().GetShareFolderUserInfo(FolderId, type);
                List<string> lstId = new List<string>();
                List<string> lstName = new List<string>();
                foreach (DataRow row in table.Rows)
                {
                    lstId.Add(row["UserId"].ToString());
                    lstName.Add(row["UserName"].ToString());
                }
                lstResult.Add(string.Join(";", lstId));
                lstResult.Add(string.Join(";", lstName));
            }
            return lstResult;
        }

        /// <summary>
        /// 获取文件夹共享人员Id
        /// 创建人：周庆
        /// 创建日期：2015年5月15日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<string> GetShareFolderUserId(string FolderId, FolderPermitionEntity.PermitionTypeEnum type)
        {
            List<string> lstResult = new List<string>();
            if (!string.IsNullOrEmpty(FolderId))
            {
                DataTable table = new FolderPermitionDal().GetShareFolderUserInfo(FolderId, type);
                List<string> lstId = new List<string>();
                foreach (DataRow row in table.Rows)
                {
                    lstResult.Add(row["UserId"].ToString());
                }
            }
            return lstResult;
        }

        /// <summary>
        /// 创建或激活文件夹对用户权限
        /// 创建人：周庆
        /// 创建日期：2015年5月14日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="UserId"></param>
        /// <param name="type"></param>
        /// <param name="currentUser"></param>
        public void CreateOrActivePermition(string FolderId, string UserId, FolderPermitionEntity.PermitionTypeEnum type,BaseUserEntity currentUser)
        {
            if (!string.IsNullOrEmpty(FolderId) && !string.IsNullOrEmpty(UserId))
            {
                FolderPermitionDal _folderPermitionDal = new FolderPermitionDal();
                FolderPermitionEntity permition=_folderPermitionDal.GetPermition(FolderId, UserId, type);
                if (permition != null)
                {
                    if (permition.RowStatus == 0)
                    {
                        //重新激活权限
                        permition.RowStatus = 1;
                        permition.UpdateId = currentUser.Id;
                        permition.UpdateBy = currentUser.UserName;
                        permition.UpdateOn = DateTime.Now;
                        _folderPermitionDal.Update(permition);
                    }
                }
                else
                {
                    permition = new FolderPermitionEntity();
                    //创建权限
                    permition.Id = Guid.NewGuid().ToString();
                    permition.FolderId = FolderId;
                    permition.UserId=UserId;
                    permition.RowStatus = 1;
                    permition.Permition = (int)type;
                    permition.CreatorId = currentUser.Id;
                    permition.CreateBy = currentUser.UserName;
                    permition.CreateOn = DateTime.Now;
                    permition.UpdateId = currentUser.Id;
                    permition.UpdateBy = currentUser.UserName;
                    permition.UpdateOn = DateTime.Now;
                    _folderPermitionDal.Add(permition);
                }
            }
        }

        /// <summary>
        /// 设置用户文件夹权限
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="Users"></param>
        /// <param name="type">权限类型</param>
        /// <param name="currentUser"></param>
        /// <returns>-1:FolderId为空</returns>
        public int SetFolderPermition(string FolderId, List<string> Users, FolderPermitionEntity.PermitionTypeEnum type, BaseUserEntity currentUser)
        {
            int result = -1;
            if (!string.IsNullOrEmpty(FolderId))
            {
                if (Users != null)
                {
                    //删除文件夹的所有权限
                    DeletePermition(FolderId, type,currentUser);
                    result = 0;
                  foreach (string user in Users)
                  {
                      CreateOrActivePermition(FolderId, user, type, currentUser);
                      result++;
                  }
                }
            }
            return result;
        }

        /// <summary>
        /// 删除文件夹权限
        /// 创建人：周庆
        /// 创建日期：2015年5月13日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="type">权限类型</param>
        /// <returns></returns>
        public int DeletePermition(string FolderId, FolderPermitionEntity.PermitionTypeEnum type, BaseUserEntity currentUser)
        {
            int result = -1;
            if (!string.IsNullOrEmpty(FolderId))
            {
                result = new FolderPermitionDal().DeletePermition(FolderId, type);
            }
            return result;
        }

        /// <summary>
        /// 获取一个文件夹的所有权限
        /// 创建人：周庆
        /// 创建日期：2015年5月14日
        /// </summary>
        /// <param name="FolderId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<FolderPermitionEntity> GetFolderPermition(string FolderId, FolderPermitionEntity.PermitionTypeEnum type, BaseUserEntity currentUser)
        {
            List<FolderPermitionEntity> lstPermition = new List<FolderPermitionEntity>();
            if (!string.IsNullOrEmpty(FolderId))
            {
                lstPermition = new FolderPermitionDal().GetFolderPermition(FolderId, type);
            }
            return lstPermition;
        }
    }
}
