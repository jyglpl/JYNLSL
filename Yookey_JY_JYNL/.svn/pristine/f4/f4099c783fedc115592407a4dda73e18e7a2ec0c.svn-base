using Yookey;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using DBHelper;

namespace Yookey.WisdomClassed.SIP.DataAccess.Mobile
{
    public class WsspDal
    {
        /// <summary>
        /// 查询一条数据 
        /// 添加人：叶念
        /// 添加时间：2014-12-24
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns></returns>
        public object GetExecuStr(string sql)
        {
            return SqlHelper.ExecuteScalar(SqlHelper.SqlConnStringRead, CommandType.Text, sql);
        }


        /// <summary>
        /// 生成日期随机码
        /// 添加人：叶念
        /// 添加时间：2014-12-24
        /// </summary>
        /// <returns></returns>
        public string GetRamCode()
        {
            #region
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
            #endregion
        }
        /// <summary>
        /// 添加人：叶念
        /// 添加时间：2014-12-24
        /// 返回上传目录相对路径
        /// </summary>
        /// <param name="fileType">上传文件类别</param>
        private string GetUpLoadPath(string fileType)
        {
            string path = "/" + fileType + "/";//图片保存的文件夹
            if (fileType == "Synthesis")  //如果传的文件夹类型是Synthesis（合成照片）,则将图片保存到Synthesis下面的SJ文件夹下面。
            {
                path += "SJ/";
            }
            path += DateTime.Now.ToString("yyyyMM") + "/" + DateTime.Now.ToString("dd");
            return path + "/";
        }
        public object Ob = new object();

        /// <summary>
        /// 写图片 返回图片路径
        /// 添加人：叶念
        /// 添加时间：2014-12-24
        /// </summary>
        /// <param name="fielType">上传文件类别,简易案件：Simple ,违停：Car</param>
        /// <param name="fileExt">文件扩展名</param>
        /// <param name="ff">图片二进制</param>
        public string WritePicture(string fielType, string fileExt, byte[] ff)
        {
            lock (Ob)
            {
                try
                {
                    var rootDirectory = ConfigurationManager.AppSettings["FileSaveUpLoad"];  //上传图片所对应的文件夹
                    var dirPath = rootDirectory + GetUpLoadPath(fielType);   //上传图片所对应的文件夹
                    if (!Directory.Exists(dirPath))  //目录不存在，则创建目录
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    var fileName = GetRamCode() + "." + fileExt; //随机文件名

                    string serverFileName = GetUpLoadPath(fielType) + fileName;  //上传图片路径(不包括根目录)

                    //执行写入图片
                    var fs = new FileStream(rootDirectory + serverFileName, FileMode.CreateNew, FileAccess.Write, FileShare.None, ff.Length, false);
                    fs.Write(ff, 0, ff.Length);
                    fs.Close();
                    fs.Dispose();

                    return serverFileName;
                }
                catch (Exception ex)
                {
                    var errorLog = ConfigurationManager.AppSettings["ErrroLog"];  //错误日志记录路径
                    var insetFile = errorLog + @"\WritePicture" + DateTime.Now.ToLongDateString() + "Log.txt";
                    var insertStream = new StreamWriter(insetFile, true);
                    insertStream.WriteLine("执行写入二进制图片出现异常，当前时间为：" + DateTime.Now.ToString() + "，异常信息：" + ex.Message);
                    insertStream.Close();
                    return "";
                }
            }
        }
    }
}




