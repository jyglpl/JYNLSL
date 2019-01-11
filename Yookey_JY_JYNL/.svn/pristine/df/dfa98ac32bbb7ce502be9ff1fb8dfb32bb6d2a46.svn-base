//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ZipHelper.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-02
//  功能描述：请一定在此描述类用途
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace Yookey.WisdomClassed.SIP.Common
{
    public class ZipHelper
    {
        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="filesPath">文件路径</param>
        /// <param name="zipFilePath">压缩文件路径</param>
        /// <param name="zipPassword">压缩密码</param>
        public static void CreateZipFile(string filesPath, string zipFilePath,string zipPassword=null)
        {
            string[] filenames;
            if (Directory.Exists(filesPath))
            {
                filenames = Directory.GetFiles(filesPath);
            }
            else if(File.Exists(filesPath))
            {
                filenames = new[] {filesPath};
            }
            else
            {
                throw new Exception(String.Format("找不着源文件或目录 '{0}'", filesPath));
            }
            try
            {
                using (var s = new ZipOutputStream(File.Create(zipFilePath)))
                {
                    s.SetLevel(9); // 压缩级别 0-9
                    if(!string.IsNullOrEmpty(zipPassword))
                    {
                        s.Password = zipPassword; //Zip压缩文件密码
                    }
                    var buffer = new byte[4096]; //缓冲区大小
                    foreach (var file in filenames)
                    {
                        var entry = new ZipEntry(Path.GetFileName(file)) {DateTime = DateTime.Now};
                        s.PutNextEntry(entry);
                        using (var fs = File.OpenRead(file))
                        {
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }
                    s.Finish();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("文件压缩过程中发送异常 {0}", ex));
            }
        }

        /// <summary>
        /// 解压缩文件
        /// </summary>
        /// <param name="zipFilePath">源文件地址</param>
        public static void UnZipFile(string zipFilePath)
        {
            if (!File.Exists(zipFilePath))
            {
                throw new Exception(String.Format("找不着源文件 '{0}'", zipFilePath));
            }
            using (var s = new ZipInputStream(File.OpenRead(zipFilePath)))
            {
                ZipEntry theEntry;
                while ((theEntry = s.GetNextEntry()) != null)
                {
                    var directoryName = Path.GetDirectoryName(theEntry.Name);
                    var fileName = Path.GetFileName(theEntry.Name);

                    // create directory
                    if (directoryName != null)
                        if (directoryName.Length > 0)
                        {
                            Directory.CreateDirectory(directoryName);
                        }
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        using (var streamWriter = File.Create(theEntry.Name))
                        {
                            var data = new byte[2048];
                            while (true)
                            {
                                int size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
