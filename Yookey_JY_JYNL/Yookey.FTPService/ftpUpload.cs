using System;

using System.Collections.Generic;

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
    public class FtpUpDown
    {
        string ftpServerIP;
        string ftpUserID;
        string ftpPassword;
        FtpWebRequest reqFTP;
        private void Connect(String path)//����ftp
        {
            // ����uri����FtpWebRequest����
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(path));
            // ָ�����ݴ�������
            reqFTP.UseBinary = true;
            // ftp�û���������
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
        }
        public FtpUpDown(string ftpServerIP, string ftpUserID, string ftpPassword)
        {
            this.ftpServerIP = ftpServerIP;
            this.ftpUserID = ftpUserID;
            this.ftpPassword = ftpPassword;
        }
        //���������
        private string[] GetFileList(string path, string WRMethods)//����Ĵ���ʾ������δ�ftp�������ϻ���ļ��б�
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            try
            {
                Connect(path);
                reqFTP.Method = WRMethods;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.Default);//�����ļ���
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                // to remove the trailing '\n'
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                throw (ex);
                //System.Windows.Forms.MessageBox.Show(ex.Message);
                downloadFiles = null;
                return downloadFiles;
            }
        }
        public string[] GetFileList(string path)//����Ĵ���ʾ������δ�ftp�������ϻ���ļ��б�
        {
            return GetFileList("ftp://" + ftpServerIP + "/" + path, WebRequestMethods.Ftp.ListDirectory);
        }
        public string[] GetFileList()//����Ĵ���ʾ������δ�ftp�������ϻ���ļ��б�
        {
            return GetFileList("ftp://" + ftpServerIP + "/", WebRequestMethods.Ftp.ListDirectory);
        }
        public bool Upload(string filename, string UpPath) //����Ĵ���ʵ���˴�ftp�����������ļ��Ĺ���
        {
            bool bl = false;
            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + ftpServerIP + "/" + UpPath + fileInf.Name;
            Connect(uri);//���� 
            // Ĭ��Ϊtrue�����Ӳ��ᱻ�ر�
            // ��һ������֮��ִ��
            reqFTP.KeepAlive = false;
            // ָ��ִ��ʲô����
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            // �ϴ��ļ�ʱ֪ͨ�������ļ��Ĵ�С
            reqFTP.ContentLength = fileInf.Length;
            // �����С����Ϊkb 
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            // ��һ���ļ���(System.IO.FileStream) ȥ���ϴ����ļ�
            FileStream fs = fileInf.OpenRead();
            try
            {
                // ���ϴ����ļ�д����
                Stream strm = reqFTP.GetRequestStream();
                // ÿ�ζ��ļ�����kb
                contentLen = fs.Read(buff, 0, buffLength);
                // ������û�н���
                while (contentLen != 0)
                {
                    // �����ݴ�file stream д��upload stream 
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                // �ر�������
                strm.Close();
                fs.Close();

                bl = true;

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message, "Upload Error");

                throw new Exception(ex.Message);
            }
            return bl;
        }


        public bool Upload_Two(string filename, string UpPath) //����Ĵ���ʵ���˴�ftp�����������ļ��Ĺ���
        {
            bool bl = false;
            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
            FtpWebRequest reqFTP;
            // ����uri����FtpWebRequest����   
            //reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileInf.Name));
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            // ָ�����ݴ�������
            reqFTP.UseBinary = true;
            // ftp�û���������  
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

            // Ĭ��Ϊtrue�����Ӳ��ᱻ�ر�  
            // ��һ������֮��ִ��  
            reqFTP.KeepAlive = false;
            // ָ��ִ��ʲô����  
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            // ָ�����ݴ�������  
            reqFTP.UseBinary = true;
            // �ϴ��ļ�ʱ֪ͨ�������ļ��Ĵ�С
            reqFTP.ContentLength = fileInf.Length;
            // �����С����Ϊ2kb  
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            //var infodbNameTxt = @"C:\FILEINFO" + DateTime.Now.ToLongDateString() + ".txt";
            //var infostream = new StreamWriter(infodbNameTxt, true);
            //infostream.WriteLine("FTP UserID:" + ftpUserID + ",PWD:" + ftpPassword + "��ʼִ��OpenRead����");
            //infostream.Close();

            // ��һ���ļ��� (System.IO.FileStream) ȥ���ϴ����ļ�  
            FileStream fs = fileInf.OpenRead();
            try
            {
                //infostream = new StreamWriter(infodbNameTxt, true);
                //infostream.WriteLine("��ʼִ��GetRequestStream����,URL:" + uri);
                //infostream.Close();

                // ���ϴ����ļ�д����  
                Stream strm = reqFTP.GetRequestStream();

                //infostream = new StreamWriter(infodbNameTxt, true);
                //infostream.WriteLine("��ʼִ��Read����");
                //infostream.Close();

                // ÿ�ζ��ļ�����2kb  
                contentLen = fs.Read(buff, 0, buffLength);

                // ������û�н���  
                while (contentLen != 0)
                {
                    // �����ݴ�file stream д�� upload stream  
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                // �ر�������  
                strm.Close();
                fs.Close();
                bl = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return bl;
        }


        public bool Download(string filePath, string fileName, out string errorinfo)////����Ĵ���ʵ���˴�ftp�����������ļ��Ĺ���
        {
            try
            {
                String onlyFileName = Path.GetFileName(fileName);
                string newFileName = filePath + "\\" + onlyFileName;
                if (File.Exists(newFileName))
                {
                    errorinfo = string.Format("�����ļ�{0}�Ѵ���,�޷�����", newFileName);
                    return false;
                }
                string url = "ftp://" + ftpServerIP + "/" + fileName;
                Connect(url);//���� 
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];
                readCount = ftpStream.Read(buffer, 0, bufferSize);
                FileStream outputStream = new FileStream(newFileName, FileMode.Create);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
                errorinfo = "";
                return true;
            }
            catch (Exception ex)
            {
                errorinfo = string.Format("��{0},�޷�����", ex.Message);
                return false;
            }
        }
        //ɾ���ļ�
        public void DeleteFileName(string fileName)
        {
            try
            {
                FileInfo fileInf = new FileInfo(fileName);
                string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
                Connect(uri);//���� 
                // Ĭ��Ϊtrue�����Ӳ��ᱻ�ر�
                // ��һ������֮��ִ��
                reqFTP.KeepAlive = false;
                // ָ��ִ��ʲô����
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "ɾ������");

                throw (ex);
            }
        }
        //����Ŀ¼
        public void MakeDir(string dirName)
        {
            try
            {
                string uri = "ftp://" + ftpServerIP + "/" + dirName;
                Connect(uri);//���� 
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw (ex);
            }
        }
        //ɾ��Ŀ¼
        public void delDir(string dirName)
        {
            try
            {
                string uri = "ftp://" + ftpServerIP + "/" + dirName;
                Connect(uri);//���� 
                reqFTP.Method = WebRequestMethods.Ftp.RemoveDirectory;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);

                throw (ex);
            }
        }
        //����ļ���С
        public long GetFileSize(string filename)
        {

            long fileSize = 0;
            try
            {
                FileInfo fileInf = new FileInfo(filename);
                string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
                Connect(uri);//���� 
                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                fileSize = response.ContentLength;
                response.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);

                throw (ex);
            }
            return fileSize;
        }
        //�ļ�����
        public void Rename(string currentFilename, string newFilename)
        {
            try
            {
                FileInfo fileInf = new FileInfo(currentFilename);
                string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
                Connect(uri);//����
                reqFTP.Method = WebRequestMethods.Ftp.Rename;
                reqFTP.RenameTo = newFilename;

                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                //Stream ftpStream = response.GetResponseStream();
                //ftpStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);

                throw (ex);
            }
        }
        //����ļ�����
        public string[] GetFilesDetailList()
        {
            return GetFileList("ftp://" + ftpServerIP + "/", WebRequestMethods.Ftp.ListDirectoryDetails);
        }
        //����ļ�����
        public string[] GetFilesDetailList(string path)
        {
            return GetFileList("ftp://" + ftpServerIP + "/" + path, WebRequestMethods.Ftp.ListDirectoryDetails);
        }
    }
}
