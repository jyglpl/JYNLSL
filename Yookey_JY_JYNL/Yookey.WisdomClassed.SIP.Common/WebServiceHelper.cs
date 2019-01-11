//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="WebServiceHelper.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2014-01-03
//  功能描述：动态调用WebServices
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Net;
using System.Text;
using System.Web.Services.Description;
using Microsoft.CSharp;

namespace Yookey.WisdomClassed.SIP.Common
{
    public class WebServiceHelper
    {
        /// <summary>           
        /// 动态调用web服务         
        /// </summary>          
        /// <param name="url">WSDL服务地址</param> 
        /// <param name="methodname">方法名</param>           
        /// <param name="args">参数</param>           
        /// <returns></returns>          
        public static object InvokeWebService(string url, string methodname, object[] args)
        {
            return InvokeWebService(url, null, methodname, args);
        }
        /// <summary>          
        /// 动态调用web服务 
        /// </summary>          
        /// <param name="url">WSDL服务地址</param>
        /// <param name="classname">类名</param>  
        /// <param name="methodname">方法名</param>  
        /// <param name="args">参数</param> 
        /// <returns></returns>
        public static object InvokeWebService(string url, string classname, string methodname, object[] args)
        {
            const string @namespace = "EnterpriseServerBase.WebService.DynamicWebCalling";
            if (string.IsNullOrEmpty(classname))
            {
                classname = GetWsClassName(url);
            }
            try
            {                   //获取WSDL   
                var wc = new WebClient();
                var stream = wc.OpenRead(url + "?WSDL");
                if (stream != null)
                {
                    var sd = ServiceDescription.Read(stream);
                    var sdi = new ServiceDescriptionImporter();
                    sdi.AddServiceDescription(sd, "", "");
                    var cn = new CodeNamespace(@namespace);
                    //生成客户端代理类代码          
                    var ccu = new CodeCompileUnit();
                    ccu.Namespaces.Add(cn);
                    sdi.Import(cn, ccu);
                    var icc = new CSharpCodeProvider();
                    //设定编译参数                 
                    var cplist = new CompilerParameters {GenerateExecutable = false, GenerateInMemory = true};
                    cplist.ReferencedAssemblies.Add("System.dll");
                    cplist.ReferencedAssemblies.Add("System.XML.dll");
                    cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                    cplist.ReferencedAssemblies.Add("System.Data.dll");
                    //编译代理类                 
                    var cr = icc.CompileAssemblyFromDom(cplist, ccu);
                    if (cr.Errors.HasErrors)
                    {
                        var sb = new StringBuilder();
                        foreach (CompilerError ce in cr.Errors)
                        {
                            sb.Append(ce);
                            sb.Append(Environment.NewLine);
                        }
                        throw new Exception(sb.ToString());
                    }
                    //生成代理实例，并调用方法   
                    var assembly = cr.CompiledAssembly;
                    var t = assembly.GetType(@namespace + "." + classname, true, true);
                    var obj = Activator.CreateInstance(t);
                    var mi = t.GetMethod(methodname);
                    return mi.Invoke(obj, args);
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
        }
        private static string GetWsClassName(string wsUrl)
        {
            var parts = wsUrl.Split('/');
            var pps = parts[parts.Length - 1].Split('.');
            return pps[0];
        }
    }
}
