//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="XmlHelper.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-02
//  功能描述：XML帮助类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.IO;

namespace Yookey.WisdomClassed.SIP.Common
{
    public class XmlHelper
    {
        /// <summary>   
        /// 将类的对象序列化后保存到本地xml文件   
        /// </summary>   
        /// <param name="entityObj">一个对象</param>   
        /// <param name="fileName">本地xml文件路径</param>   
        public static void XmlSerialize(object entityObj, string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(entityObj.GetType());
                serializer.Serialize(stream, entityObj);
            }
        }

        /// <summary>   
        /// 读取序列化后保存在本地的xml文件成一个对象   
        /// </summary>   
        /// <param name="filename"></param>   
        /// <param name="entityType"></param>   
        /// <returns></returns>   
        public static object XmlDeserialize(string filename, Type entityType)
        {
            object obj;
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(entityType);
                obj = serializer.Deserialize(stream);
            }
            return obj;
        }

        /// <summary>   
        /// 将对象序列化成二进制文件保存到本地   
        /// </summary>   
        /// <param name="obj">对象</param>   
        /// <param name="fileName">二进制文件路径</param>   
        public static void BinSerialize(object obj, string fileName)
        {
            using (var strm = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                System.Runtime.Serialization.IFormatter fmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                fmt.Serialize(strm, obj);
                strm.Flush();
            }
        }

        /// <summary>   
        /// 将序列化的二进制文件反序列化成一个对象   
        /// </summary>   
        /// <param name="fileName"></param>   
        /// <returns></returns>   
        public static object BinDeserialize(string fileName)
        {
            object obj;
            using (Stream strm = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                System.Runtime.Serialization.IFormatter fmt = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                strm.Position = 0;
                strm.Seek(0, SeekOrigin.Begin);
                obj = fmt.Deserialize(strm);
            }
            return obj;
        }  
    }
}
