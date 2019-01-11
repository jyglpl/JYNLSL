using System;

using System.Collections.Generic;
using System.Globalization;
using System.Text;

using System.Net;

using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Net.Mail;

namespace Yookey.FTPService
{

    class ExecuteManager
    {
        /// <summary>
        /// FTP的IP地址
        /// </summary>
        private readonly string _ftpServerIp = ConfigurationManager.AppSettings["ftpAddress"];
        /// <summary>
        /// FTP账号
        /// </summary>
        private readonly string _ftpUserID = ConfigurationManager.AppSettings["username"];
        /// <summary>
        /// FTP密码
        /// </summary>
        private readonly string _ftpPassword = ConfigurationManager.AppSettings["password"];
        /// <summary>
        ///  下载文件的开始时间
        /// </summary>
        private readonly string _startTime = ConfigurationManager.AppSettings["StartTime"];
        /// <summary>
        /// FTP文件路径
        /// </summary>
        private static readonly string FtpPath = ConfigurationManager.AppSettings["FTPPath"];
        /// <summary>
        ///  下载后保存文件路径
        /// </summary>
        private static readonly string DownPath = ConfigurationManager.AppSettings["DownPath"];

        /// <summary>
        /// 是否需要下载文件
        /// </summary>
        private static string IsDownload = ConfigurationManager.AppSettings["Download"];
        /// <summary>
        /// 错误日志记录路径
        /// </summary>
        private readonly string _errorAddress = ConfigurationManager.AppSettings["ErrorAddress"];

        /// <summary>
        /// 上传保存路径路径
        /// </summary>
        private static string UpPath = ConfigurationManager.AppSettings["UpPath"];

        /// <summary>
        ///  是否需要上传
        /// </summary>
        private readonly string _isUpLoad = ConfigurationManager.AppSettings["isUpload"];

        /// <summary>
        /// 上传FTP的IP地址
        /// </summary>
        private readonly string _ftpServerIpUp = ConfigurationManager.AppSettings["ftpAddressUp"];
        /// <summary>
        /// 上传FTP账号
        /// </summary>
        private readonly string _ftpUserIDUp = ConfigurationManager.AppSettings["usernameUp"];
        /// <summary>
        /// 上传FTP密码
        /// </summary>
        private readonly string _ftpPasswordUp = ConfigurationManager.AppSettings["passwordUp"];

        /// <summary>
        /// 上传所对应的FTP目录
        /// </summary>
        private readonly string _ftpUploadPath = ConfigurationManager.AppSettings["ftpUpPath"];


        public void Transfer()
        {
            try
            {
                string time = "";
                if (DateTime.Now.Hour < 10)//获取小时
                {
                    time += "0" + DateTime.Now.Hour;
                }
                else
                {
                    time = DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture);
                }
                if (DateTime.Now.Minute < 10)//获取分钟
                {
                    time += "0" + DateTime.Now.Minute;
                }
                else
                {
                    time += DateTime.Now.Minute;
                }
                if (DateTime.Now.Second < 10)//获取秒
                {
                    time += "0" + DateTime.Now.Second;
                }
                else
                {
                    time += DateTime.Now.Second;
                }

                //var dbTxt = _errorAddress + @"\Time" + DateTime.Now.ToLongDateString() + ".txt";
                //var stream = new StreamWriter(dbTxt, true);
                //stream.WriteLine("正在执行时间:)" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                //stream.Close();

                if (time == _startTime)//如果当前时间等于指定时间时执行同步数据的方法
                {
                    //是否需要执行下载文件
                    if (IsDownload.Equals("1"))
                    {
                        try
                        {
                            FileStruct[] dirS = GetDirectorList(FtpPath);
                            if (dirS.Length > 0)
                            {
                                foreach (FileStruct dir in dirS)
                                {
                                    FileStruct[] files = GetDirectorList(FtpPath + dir.Name);
                                    if (files.Length > 0)
                                    {
                                        foreach (FileStruct dirr in files)
                                        {
                                            FileStruct[] filess = GetFileList(FtpPath + dir.Name + "\\" + dirr.Name);
                                            if (filess.Length > 0)
                                            {
                                                foreach (FileStruct file in filess)
                                                {
                                                    bool b = Download(FtpPath + dir.Name + "\\" + dirr.Name, file.Name, dir.Name + "\\" + dirr.Name);
                                                    if (b)
                                                    {
                                                        DeleteFileName(FtpPath + dir.Name + "\\" + dirr.Name, file.Name);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        FileStruct[] filess = GetFileList(FtpPath + dir.Name);
                                        if (filess.Length > 0)
                                        {
                                            foreach (FileStruct file in filess)
                                            {
                                                bool b = Download(FtpPath + dir.Name, file.Name, dir.Name);
                                                if (b)
                                                {
                                                    DeleteFileName(FtpPath + dir.Name, file.Name);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var dbUpDown = _errorAddress + @"\ErrorDown" + DateTime.Now.ToLongDateString() + ".txt";
                            var streamUpDown = new StreamWriter(dbUpDown, true);
                            streamUpDown.WriteLine("下载数据时出现异常：" + ex.Message + " 时间:)" + DateTime.Now.ToString());
                            streamUpDown.Close();
                        }
                    }

                    //判断是否需要往服务器上传数据
                    if (_isUpLoad.Equals("1"))
                    {
                        var aDir = new DirectoryInfo(DownPath);
                        var dirs = aDir.GetDirectories();
                        foreach (DirectoryInfo files in dirs)
                        {

                            FileInfo[] fileInfo = files.GetFiles();
                            if (fileInfo.Length > 0)
                            {
                                //MakeDir(ftpUploadPath, files.Name, ftpServerIPUp, ftpUserIDUp, ftpPasswordUp);
                            }
                            foreach (FileInfo nextFile in fileInfo)  //遍历文件
                            {
                                try
                                {
                                    var bl = UploadFile_Two(_ftpUploadPath, nextFile.DirectoryName + "\\" + nextFile.Name, _ftpServerIpUp, _ftpUserIDUp, _ftpPasswordUp);
                                    if (bl)
                                    {
                                        //上传成功后，删除本地文件
                                        File.Delete(nextFile.DirectoryName + @"\" + nextFile.Name);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    var dbUpload = _errorAddress + @"\ErrorUpLoad" + DateTime.Now.ToLongDateString() + ".txt";
                                    var streamdbUpload = new StreamWriter(dbUpload, true);
                                    streamdbUpload.WriteLine("上传文件时出现错误：" + ex.Message + " 时间:)" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                                    streamdbUpload.Close();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string dbTxt = _errorAddress + @"\ErrorTime" + DateTime.Now.ToLongDateString() + ".txt";
                var stream = new StreamWriter(dbTxt, true);
                stream.WriteLine("正在执行异常为：" + ex.Message + " 时间:)" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                stream.Close();
            }
        }

        /// <summary>
        /// 获取目录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private FileStruct[] GetDirectorList(string path)
        {
            try
            {
                Uri ftpUei = new Uri(_ftpServerIp + path);
                clsFTP cf = new clsFTP(ftpUei, _ftpUserID, _ftpPassword);
                FileStruct[] filestr = cf.ListDirectories();

                string dbNameTxt = _errorAddress + @"\GetDirectory" + DateTime.Now.ToLongDateString() + ".txt";
                StreamWriter stream = new StreamWriter(dbNameTxt, true);
                stream.WriteLine("获取文件目录成功。" + "目录个数为：" + filestr.Length + "时间:)" + DateTime.Now.ToString());
                stream.Close();

                return filestr;

            }
            catch (Exception ex)
            {
                string dbNameTxt = _errorAddress + @"\ErrorGetDirectory" + DateTime.Now.ToLongDateString() + ".txt";
                StreamWriter stream = new StreamWriter(dbNameTxt, true);
                stream.WriteLine("获取文件目录失败。异常为：" + ex.Message + "时间:)" + DateTime.Now.ToString());
                stream.Close();
                FileStruct[] filestr = new FileStruct[0];
                return filestr;
            }
        }
        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private FileStruct[] GetFileList(string path)
        {
            try
            {
                Uri ftpUei = new Uri(_ftpServerIp + path);
                clsFTP cf = new clsFTP(ftpUei, _ftpUserID, _ftpPassword);
                FileStruct[] filestr = cf.ListFiles();

                string dbNameTxt = _errorAddress + @"\GetFile" + DateTime.Now.ToLongDateString() + ".txt";
                StreamWriter stream = new StreamWriter(dbNameTxt, true);
                stream.WriteLine("获取文件成功。" + "文件个数为：" + filestr.Length + "时间:)" + DateTime.Now.ToString());
                stream.Close();
                return filestr;

            }
            catch (Exception ex)
            {
                string dbNameTxt = _errorAddress + @"\ErrorGetFile" + DateTime.Now.ToLongDateString() + ".txt";
                StreamWriter stream = new StreamWriter(dbNameTxt, true);
                stream.WriteLine("获取文件失败。异常为：" + ex.Message + "时间:)" + DateTime.Now.ToString());
                stream.Close();
                FileStruct[] filestr = new FileStruct[0];
                return filestr;
            }
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public bool Download(string filePath, string fileName, string dirName)////上面的代码实现了从ftp服务器下载文件的功能
        {
            try
            {
                Uri FtpUEI = new Uri(_ftpServerIp + filePath);
                clsFTP cf = new clsFTP(FtpUEI, _ftpUserID, _ftpPassword);
                bool b = cf.DownloadFile(fileName, DownPath, dirName);
                if (b)
                {

                    //Stream = new StreamWriter(dbNameTxt, true);
                    //Stream.WriteLine("获取文件成功。文件名为：" + fileName + "时间:)" + DateTime.Now.ToString());
                    //Stream.Close();
                    return true;
                }
                else
                {

                    string dbTxt = _errorAddress + @"\ErrorGet" + DateTime.Now.ToLongDateString() + ".txt";
                    StreamWriter Strea = new StreamWriter(dbTxt, true);
                    Strea.WriteLine("获取文件失败。错误信息为" + cf.ErrorMsg + " 文件名为：" + fileName + "时间:)" + DateTime.Now.ToString());
                    Strea.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                string dbNameTxt = _errorAddress + @"\ErrorGet" + DateTime.Now.ToLongDateString() + ".txt";
                StreamWriter Stream = new StreamWriter(dbNameTxt, true);
                Stream.WriteLine("获取文件失败。错误为：" + ex.Message + ";文件名为：" + fileName + "时间:)" + DateTime.Now.ToString());
                Stream.Close();
                return false;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool DeleteFileName(string filePath, string fileName)
        {
            try
            {
                string dbNameTxt = _errorAddress + @"\Delete" + DateTime.Now.ToLongDateString() + ".txt";
                StreamWriter Stream;
                Uri FtpUEI = new Uri(_ftpServerIp + filePath);
                clsFTP cf = new clsFTP(FtpUEI, _ftpUserID, _ftpPassword);
                bool b = cf.DeleteFile(fileName);
                if (b)
                {

                    Stream = new StreamWriter(dbNameTxt, true);
                    Stream.WriteLine("删除文件成功。文件名为：" + fileName + "时间:)" + DateTime.Now.ToString());
                    Stream.Close();
                    return true;
                }
                else
                {
                    string dbxt = _errorAddress + @"\ErrorDelete" + DateTime.Now.ToLongDateString() + ".txt";
                    StreamWriter Strea = new StreamWriter(dbxt, true);
                    Strea.WriteLine("删除文件失败。错误信息为" + cf.ErrorMsg + " 文件名为：" + fileName + "时间:)" + DateTime.Now.ToString());
                    Strea.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                string dbNameTxt = _errorAddress + @"\ErrorDelete" + DateTime.Now.ToLongDateString() + ".txt";
                StreamWriter Stream = new StreamWriter(dbNameTxt, true);
                Stream.WriteLine("删除文件失败。错误为：" + ex.Message + ";文件名为：" + fileName + "时间:)" + DateTime.Now.ToString());
                Stream.Close();
                return false;
            }
        }


        public bool UploadFile(string filePath, string locufullPath, string ip, string uid, string pwd)
        {
            try
            {
                var dbNameTxt = _errorAddress + @"\UpLoad" + DateTime.Now.ToLongDateString() + ".txt";
                var ftpUei = new Uri(ip + filePath);
                var cf = new clsFTP(ftpUei, uid, pwd);
                var b = cf.UploadFile(locufullPath);
                if (!b)
                    b = cf.UploadFile(locufullPath);
                if (b)
                {

                    var stream = new StreamWriter(dbNameTxt, true);
                    stream.WriteLine("上传文件成功。文件名为：" + locufullPath + "时间:)" + DateTime.Now.ToString());
                    stream.Close();
                    return true;
                }
                else
                {
                    string dbxt = _errorAddress + @"\ErrorDelete" + DateTime.Now.ToLongDateString() + ".txt";
                    var strea = new StreamWriter(dbxt, true);
                    strea.WriteLine("上传文件失败。错误信息为" + cf.ErrorMsg + " 文件名为：" + locufullPath + "时间:)" + DateTime.Now.ToString());
                    strea.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                var dbNameTxt = _errorAddress + @"\ErrorDelete" + DateTime.Now.ToLongDateString() + ".txt";
                var stream = new StreamWriter(dbNameTxt, true);
                stream.WriteLine("上传文件失败。错误为：" + ex.Message + ";文件名为：" + locufullPath + "时间:)" + DateTime.Now.ToString());
                stream.Close();
                return false;
            }
        }


        public bool UploadFile_Two(string upPath, string locufullPath, string ip, string uid, string pwd)
        {
            try
            {
                var ftp = new FtpUpDown(ip, uid, pwd);
                return ftp.Upload_Two(locufullPath, upPath);
            }
            catch (Exception ex)
            {
                var dbNameTxt = _errorAddress + @"\ErrorUpload" + DateTime.Now.ToLongDateString() + ".txt";
                var stream = new StreamWriter(dbNameTxt, true);
                stream.WriteLine("上传文件失败。错误为：" + ex.Message + ";文件名为：" + locufullPath + "时间:)" + DateTime.Now.ToString());
                stream.Close();
            }
            return false;
        }


        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <param name="dirName">文件名</param>
        /// <param name="ip"></param>
        /// <param name="uid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool MakeDir(string filePath, string dirName, string ip, string uid, string pwd)
        {
            try
            {
                var dbNameTxt = _errorAddress + @"\Create" + DateTime.Now.ToLongDateString() + ".txt";
                var ftpUei = new Uri(ip + filePath);
                var cf = new clsFTP(ftpUei, uid, pwd);
                bool b;
                if (!cf.DirectoryExist(dirName))
                {
                    b = cf.MakeDirectory(dirName);
                }
                else
                {
                    return true;
                }
                if (b)
                {
                    var stream = new StreamWriter(dbNameTxt, true);
                    stream.WriteLine("创建目录成功。目录名为：" + dirName + "时间:)" + DateTime.Now.ToString());
                    stream.Close();
                    return true;
                }
                else
                {

                    var dbTxt = _errorAddress + @"\ErrorCreate" + DateTime.Now.ToLongDateString() + ".txt";
                    var strea = new StreamWriter(dbTxt, true);
                    strea.WriteLine("创建目录失败。错误信息为" + cf.ErrorMsg + " 目录名为：" + dirName + "时间:)" + DateTime.Now.ToString());
                    strea.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("远程服务器返回错误: (550)", System.StringComparison.Ordinal) >= 0)
                {
                    var ftpUei = new Uri(_ftpServerIp + filePath);
                    var cf1 = new clsFTP(ftpUei, _ftpUserID, _ftpPassword);
                    if (!cf1.DirectoryExist(dirName))
                    {
                       cf1.MakeDirectory(dirName);
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    var dbNameTxt = _errorAddress + @"\ErrorCreate" + DateTime.Now.ToLongDateString() + ".txt";
                    var stream = new StreamWriter(dbNameTxt, true);
                    stream.WriteLine("创建文件失败。错误为：" + ex.Message + ";目录名为：" + dirName + "时间:)" + DateTime.Now.ToString());
                    stream.Close();
                    return false;
                }
            }

            return false;
        }
        /// <summary>
        /// 移动目录
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="DirectoryName"></param>
        /// <returns></returns>
        public bool MoveFile(string filePath, string fileName, string DirectoryName)
        {
            try
            {
                var dbNameTxt = _errorAddress + @"\Move" + DateTime.Now.ToLongDateString() + ".txt";
                var ftpUei = new Uri(_ftpServerIp + filePath);
                var cf = new clsFTP(ftpUei, _ftpUserID, _ftpPassword);
                var b = cf.MoveFileToAnotherDirectory(fileName, DirectoryName);
                if (b)
                {

                    var stream = new StreamWriter(dbNameTxt, true);
                    stream.WriteLine("移动文件成功。文件名为：" + fileName + "时间:)" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    stream.Close();
                    return true;
                }
                else
                {
                    var strea = new StreamWriter(dbNameTxt, true);
                    strea.WriteLine("移动文件失败。错误信息为" + cf.ErrorMsg + " 文件名为：" + fileName + "时间:)" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    strea.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                var dbNameTxt = _errorAddress + @"\ErrorMovee" + DateTime.Now.ToLongDateString() + ".txt";
                var stream = new StreamWriter(dbNameTxt, true);
                stream.WriteLine("移动文件失败。错误为：" + ex.Message + ";文件名为：" + fileName + "时间:)" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                stream.Close();
                return false;
            }
        }
    }
}

