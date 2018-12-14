using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Work
{
    
    /// <summary>
    /// 文件/文件夹信息
    /// </summary>
    public class FileSysEntity
    {
        public FileSysEntity(SqlDataReader reader)
        {
            Id = reader["Id"].ToString();
            FileName = reader["FolderName"].ToString();
            FileType = FileTypeEnum.Folder;
            FileSize = "--";
            FileDate = Convert.ToDateTime(reader["UpdateOn"]);
            Extension = "folder";
 
        }
        public FileSysEntity() { }

        /// <summary>
        /// 文件夹类型
        /// </summary>
      public enum FileTypeEnum
        {
            File,
            Folder
        }

      /// <summary>
      /// 文件Id
      /// </summary>
      public string Id{ get; set; }
       
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get;set;}

        /// <summary>
        /// 文件后缀
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public FileTypeEnum FileType { get; set; }

        /// <summary>
        /// 文件类型名称
        /// </summary>
        public string FileTypeName
        {
            get
            {
                string fileTypeName = "";
                switch (FileType) { 
                    case FileTypeEnum.Folder:
                        fileTypeName = "文件夹";
                        break;
                    case FileTypeEnum.File:
                        fileTypeName = Extension+"文件";
                        break;
                }
                return fileTypeName;
            
            }
        }
       /// <summary>
       /// 文件大小
       /// </summary>
        public string FileSize { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime FileDate { get; set; }

        /// <summary>
        /// 完整路径(相对路径，可用于下载)
        /// </summary>
        public string FullPath { get; set; }
    }
}
