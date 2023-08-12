using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Violet.CommonHelper
{
    public class ReflectionHelper
    {
        public static string GetTableName<T>(T data)
        {
            return data.GetType().Name; 

        }

        public static Dictionary<string,object> ConvertObjectIntoDictionary<T>(T data)
        {
            Dictionary<string, object> dic= new Dictionary<string,object>();
            Type type = data.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                dic.Add(property.Name, property.GetValue(data));
            }

            return dic;
        }

        public static T ConvertDictionaryIntoObject<T>(Dictionary<string, object> dic)
        {
            var obj = Activator.CreateInstance<T>();
            Type type = typeof(T);

            foreach (var item in dic)
            {
                PropertyInfo property = type.GetProperty(item.Key);
                if (property != null && property.CanWrite)
                {
                    property.SetValue(obj, item.Value);
                }
            }

            return obj;
        }

        public static string[] GetAllPropertyNames<T>(T data)
        {
            int size = 0;
            Type type = data.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var item in properties)
            {
                size++;
            }

            string [] PropertyNames = new string[size];
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyNames[i] = properties[i].Name;
            }

            return PropertyNames;
        }

    }
}