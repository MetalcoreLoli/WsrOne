using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsr1.Core.ValidationModel
{
    public class Validator
    {
        public static bool IsValidModel<T>(T obj)
        {
            Type typeOfObject = typeof(T);
            var properties = typeOfObject.GetProperties();
            foreach (var property in properties)
            {
                bool isValidProperty = property.GetCustomAttributes(false).All(a => (a as IValidationAttribute).IsValid(typeOfObject.GetProperty(property.Name).GetValue(obj)));
                if (!isValidProperty)
                    return false;
            }
            return true;
        }

        public static bool IsValidProperty<T>(T obj, string propertyName)
        {
            Type typeOfObject = typeof(T);
            var property = typeOfObject.GetProperty(propertyName);
            return property.GetCustomAttributes(false).All(a => (a as IValidationAttribute).IsValid(property.GetValue(obj)));
        }
    }
}
