//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AccountModels.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周鹏
//  创建日期：2014-01-03
//  功能描述：请一定在此描述类用途
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Yookey.WisdomClassed.SIP.Admin.Models
{

    public class ChangePasswordModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "旧密码不能为空！")]
        [DataType(DataType.Password)]
        [Display(Name = "旧密码")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "新密码不能为空！")]
        [StringLength(100, ErrorMessage = "{0}不能少于{2}个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        public string ResultMsg { get; set; }
    }

    public class LogOnModel
    {
        [Required(ErrorMessage = "请输入登录名")]
        [Display(Name = "登录名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        [Required(ErrorMessage = "请输入验证码")]
        [Display(Name = "验证码")]
        public string VerificationCode { get; set; }

        [Display(Name = "记住密码")]
        public bool RememberMe { get; set; }

        public string ErrorMsg { get; set; }
    }

    public class SetPwd
    {
        [Required(ErrorMessage = "请输入原密码")]
        [DataType(DataType.Password)]
        [Display(Name = "原密码")]
        public string OldPwd { get; set; }

        [Required(ErrorMessage = "请输入新密码")]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewFPwd { get; set; }

      
        public string ErrorMsg { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "登录名")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "真实姓名")]
        public string TrueName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "邮箱地址")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0}不能少于{2}个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string Password { get; set; }

    }
}
