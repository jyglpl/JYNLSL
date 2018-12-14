﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17929
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.17929 版自动生成。
// 
#pragma warning disable 1591

namespace Yookey.WisdomClassed.SIP.Admin.PictureService
{
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "PictureServiceSoap", Namespace = "http://tempuri.org/")]
    public partial class PictureService : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback WritePictureOperationCompleted;

        private System.Threading.SendOrPostCallback WritePictureSecondOperationCompleted;

        private System.Threading.SendOrPostCallback DeletePicOperationCompleted;

        private System.Threading.SendOrPostCallback MakewatermarkNewOperationCompleted;

        private System.Threading.SendOrPostCallback CopNewPicOperationCompleted;

        private bool useDefaultCredentialsSetExplicitly;

        /// <remarks/>
        public PictureService()
        {
            this.Url = "http://192.168.1.180/GSCGPictureService/PictureService.asmx";
            if ((this.IsLocalFileSystemWebService(this.Url) == true))
            {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else
            {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

        /// <remarks/>
        public PictureService(string url)
        {
            this.Url = url;
            if ((this.IsLocalFileSystemWebService(this.Url) == true))
            {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else
            {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

        public new string Url
        {
            get
            {
                return base.Url;
            }
            set
            {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true)
                            && (this.useDefaultCredentialsSetExplicitly == false))
                            && (this.IsLocalFileSystemWebService(value) == false)))
                {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }

        public new bool UseDefaultCredentials
        {
            get
            {
                return base.UseDefaultCredentials;
            }
            set
            {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

        /// <remarks/>
        public event WritePictureCompletedEventHandler WritePictureCompleted;

        /// <remarks/>
        public event WritePictureSecondCompletedEventHandler WritePictureSecondCompleted;

        /// <remarks/>
        public event DeletePicCompletedEventHandler DeletePicCompleted;

        /// <remarks/>
        public event MakewatermarkNewCompletedEventHandler MakewatermarkNewCompleted;

        /// <remarks/>
        public event CopNewPicCompletedEventHandler CopNewPicCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/WritePicture", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string WritePicture(string fielType, string fileExt, [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")] byte[] ff)
        {
            object[] results = this.Invoke("WritePicture", new object[] {
                        fielType,
                        fileExt,
                        ff});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void WritePictureAsync(string fielType, string fileExt, byte[] ff)
        {
            this.WritePictureAsync(fielType, fileExt, ff, null);
        }

        /// <remarks/>
        public void WritePictureAsync(string fielType, string fileExt, byte[] ff, object userState)
        {
            if ((this.WritePictureOperationCompleted == null))
            {
                this.WritePictureOperationCompleted = new System.Threading.SendOrPostCallback(this.OnWritePictureOperationCompleted);
            }
            this.InvokeAsync("WritePicture", new object[] {
                        fielType,
                        fileExt,
                        ff}, this.WritePictureOperationCompleted, userState);
        }

        private void OnWritePictureOperationCompleted(object arg)
        {
            if ((this.WritePictureCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.WritePictureCompleted(this, new WritePictureCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/WritePictureSecond", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string WritePictureSecond(string fielType, string fileExt, string fileName, [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")] byte[] ff)
        {
            object[] results = this.Invoke("WritePictureSecond", new object[] {
                        fielType,
                        fileExt,
                        fileName,
                        ff});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void WritePictureSecondAsync(string fielType, string fileExt, string fileName, byte[] ff)
        {
            this.WritePictureSecondAsync(fielType, fileExt, fileName, ff, null);
        }

        /// <remarks/>
        public void WritePictureSecondAsync(string fielType, string fileExt, string fileName, byte[] ff, object userState)
        {
            if ((this.WritePictureSecondOperationCompleted == null))
            {
                this.WritePictureSecondOperationCompleted = new System.Threading.SendOrPostCallback(this.OnWritePictureSecondOperationCompleted);
            }
            this.InvokeAsync("WritePictureSecond", new object[] {
                        fielType,
                        fileExt,
                        fileName,
                        ff}, this.WritePictureSecondOperationCompleted, userState);
        }

        private void OnWritePictureSecondOperationCompleted(object arg)
        {
            if ((this.WritePictureSecondCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.WritePictureSecondCompleted(this, new WritePictureSecondCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/WriteFile", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string WriteFile(string fielType, string fileName, string fileExt, [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")] byte[] ff)
        {
            object[] results = this.Invoke("WriteFile", new object[] {
                        fielType,
                        fileName,
                        fileExt,
                        ff});
            return ((string)(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DeletePic", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DeletePic(string fileName)
        {
            this.Invoke("DeletePic", new object[] {
                        fileName});
        }

        /// <remarks/>
        public void DeletePicAsync(string fileName)
        {
            this.DeletePicAsync(fileName, null);
        }

        /// <remarks/>
        public void DeletePicAsync(string fileName, object userState)
        {
            if ((this.DeletePicOperationCompleted == null))
            {
                this.DeletePicOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeletePicOperationCompleted);
            }
            this.InvokeAsync("DeletePic", new object[] {
                        fileName}, this.DeletePicOperationCompleted, userState);
        }

        private void OnDeletePicOperationCompleted(object arg)
        {
            if ((this.DeletePicCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeletePicCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/MakewatermarkNew", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string MakewatermarkNew(string FilePath1, string FilePath2, string FilePath3, string FileName, string checktime, int width, int height, string mode, string type)
        {
            object[] results = this.Invoke("MakewatermarkNew", new object[] {
                        FilePath1,
                        FilePath2,
                        FilePath3,
                        FileName,
                        checktime,
                        width,
                        height,
                        mode,
                        type});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void MakewatermarkNewAsync(string FilePath1, string FilePath2, string FilePath3, string FileName, string checktime, int width, int height, string mode, string type)
        {
            this.MakewatermarkNewAsync(FilePath1, FilePath2, FilePath3, FileName, checktime, width, height, mode, type, null);
        }

        /// <remarks/>
        public void MakewatermarkNewAsync(string FilePath1, string FilePath2, string FilePath3, string FileName, string checktime, int width, int height, string mode, string type, object userState)
        {
            if ((this.MakewatermarkNewOperationCompleted == null))
            {
                this.MakewatermarkNewOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMakewatermarkNewOperationCompleted);
            }
            this.InvokeAsync("MakewatermarkNew", new object[] {
                        FilePath1,
                        FilePath2,
                        FilePath3,
                        FileName,
                        checktime,
                        width,
                        height,
                        mode,
                        type}, this.MakewatermarkNewOperationCompleted, userState);
        }

        private void OnMakewatermarkNewOperationCompleted(object arg)
        {
            if ((this.MakewatermarkNewCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MakewatermarkNewCompleted(this, new MakewatermarkNewCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CopNewPic", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CopNewPic(string FilePath, string FileName)
        {
            object[] results = this.Invoke("CopNewPic", new object[] {
                        FilePath,
                        FileName});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void CopNewPicAsync(string FilePath, string FileName)
        {
            this.CopNewPicAsync(FilePath, FileName, null);
        }

        /// <remarks/>
        public void CopNewPicAsync(string FilePath, string FileName, object userState)
        {
            if ((this.CopNewPicOperationCompleted == null))
            {
                this.CopNewPicOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCopNewPicOperationCompleted);
            }
            this.InvokeAsync("CopNewPic", new object[] {
                        FilePath,
                        FileName}, this.CopNewPicOperationCompleted, userState);
        }

        private void OnCopNewPicOperationCompleted(object arg)
        {
            if ((this.CopNewPicCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CopNewPicCompleted(this, new CopNewPicCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }

        private bool IsLocalFileSystemWebService(string url)
        {
            if (((url == null)
                        || (url == string.Empty)))
            {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024)
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0)))
            {
                return true;
            }
            return false;
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void WritePictureCompletedEventHandler(object sender, WritePictureCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class WritePictureCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal WritePictureCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void WritePictureSecondCompletedEventHandler(object sender, WritePictureSecondCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class WritePictureSecondCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal WritePictureSecondCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void DeletePicCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void MakewatermarkNewCompletedEventHandler(object sender, MakewatermarkNewCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MakewatermarkNewCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal MakewatermarkNewCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void CopNewPicCompletedEventHandler(object sender, CopNewPicCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CopNewPicCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal CopNewPicCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591