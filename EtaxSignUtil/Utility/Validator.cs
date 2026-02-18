using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EtaxSignUtil
{
    public static class Validator
    {
        // This could return a ValidationResult object etc
        public static List<string> Validate(object o)
        {
            List<string> ErrList = new List<string>();
            Type type = o.GetType();
            System.Reflection.PropertyInfo[] properties = type.GetProperties();
            Type attrType = typeof(ValidationAttribute);

            foreach (var propertyInfo in properties)
            {
                var attribute = propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attribute.Length == 0)
                    continue;
                string Description = ((DescriptionAttribute)attribute[0]).Description;

                object[] customAttributes = propertyInfo.GetCustomAttributes(attrType, true);

                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ValidationAttribute)customAttribute;

                    object value = propertyInfo.GetValue(o, System.Reflection.BindingFlags.GetProperty, null, null, null);
                    bool isValid = validationAttribute.IsValid(value);

                    if (!isValid)
                    {
                        if (validationAttribute.GetType() == typeof(System.ComponentModel.DataAnnotations.StringLengthAttribute))
                        {
                            var stringAtt = ((System.ComponentModel.DataAnnotations.StringLengthAttribute)(validationAttribute));
                            ErrList.Add($"{Description} : {value.ToString()} ความยาวต้องไม่เกิน {stringAtt.MaximumLength} ตัวอักษร");
                        }
                        else if (validationAttribute.GetType() == typeof(System.ComponentModel.DataAnnotations.RequiredAttribute))
                        {
                            var stringAtt = ((System.ComponentModel.DataAnnotations.RequiredAttribute)(validationAttribute));
                            ErrList.Add($"{Description} จำเป็นต้องระบุ");
                        }
                        else
                            ErrList.Add(validationAttribute.ErrorMessage);
                    }
                }
            }
            return ErrList;
        }
    }
}
