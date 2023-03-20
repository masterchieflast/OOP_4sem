using System.ComponentModel.DataAnnotations;

namespace Lab03
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomValidationAttribute : ValidationAttribute
    {
        public static bool IsValid(object value)
        {
            if (value == null) return true;
            var specialization = (string)value;
            return specialization == "ISiT" || specialization == "POIT" || specialization == "DIS" || specialization == "POIBMS";
        }
    }
}