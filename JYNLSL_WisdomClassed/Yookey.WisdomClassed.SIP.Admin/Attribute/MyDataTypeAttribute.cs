using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Yookey.WisdomClassed.SIP.Admin.Attribute
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MyDataTypeAttribute : ValidationAttribute
    {
        private readonly DataType _dataType;
        public MyDataTypeAttribute(DataType dataType)
        {
            _dataType = dataType;
            ErrorMessage = "类型不正确";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;
            switch (_dataType)
            {
                case DataType.DateTime:
                    DateTime datetime;
                    return DateTime.TryParse(value.ToString(), out datetime);
            }
            return true;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            ErrorMessage = validationContext.DisplayName + "类型不正确";
            return IsValid(value)
                       ? ValidationResult.Success
                       : new ValidationResult(String.Format("{0}类型不正确", validationContext.DisplayName));
        }
    }
    
    public class MyDataTypeValidator : DataAnnotationsModelValidator<MyDataTypeAttribute>
    {
        public MyDataTypeValidator(ModelMetadata metadata, ControllerContext context, MyDataTypeAttribute attribute)
            : base(metadata, context, attribute)
        {
            if (context.HttpContext.Request.Form.Count.Equals(0)) return;
            if (attribute.IsValid(context.HttpContext.Request.Form[metadata.PropertyName])) return;
            var propertyName = metadata.PropertyName;
            context.Controller.ViewData.ModelState[propertyName].Errors.Clear();
            context.Controller.ViewData.ModelState[propertyName].Errors.Add(attribute.ErrorMessage);
        }
    }
}