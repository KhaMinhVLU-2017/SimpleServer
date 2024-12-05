using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleServer.Helpers
{
    public static class TypeHelper
    {
        public static object CastToObject(this IDictionary<string, object> dic, Type target)
        {
            var objectCreated = Activator.CreateInstance(target, null);
            foreach (string key in dic.Keys)
            {
                //Get the property
                var property = target.GetProperties().FirstOrDefault(s => s.Name.Equals(key, StringComparison.InvariantCultureIgnoreCase));

                if (property is null) continue;
                //Convert the value to the property type
                var convertedValue = Convert.ChangeType(dic[key], property.PropertyType);
                property.SetValue(objectCreated, convertedValue);
            }
            return objectCreated;
        }
    }
}