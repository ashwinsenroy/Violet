using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace Violet.CommonHelper
{
    public class ReflectionHelper
    {
        public static string GetTableName<T>(T data)
        {
            return data.GetType().Name;

        }

        public static Dictionary<string, object> ConvertObjectIntoDictionary<T>(T data)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
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

        public static string[] GetPropertyNames(Dictionary<string, object> dic) // this method will take in the dictionary and return names of all the properties i.e key names...
        {
            int size = 0;
            int i = 0;
            foreach (var item in dic)
            {
                size++;
            }

            string[] PropertyNames = new string[size];
            foreach (var property in dic)
            {
                PropertyNames[i] = property.Key;
                i++;
            }

            return PropertyNames;
        }

        public static Dictionary<string, object> FilterOutPropertiesWithKeyAttribute<T>(Dictionary<string, object> dic, T data)  // this will filter out all the prpoerties of class with key attribute i.e it filters primary key frm the dictionary..
        {
            Dictionary<string, object> filteredDic = new Dictionary<string, object>();
            Type type = data.GetType();
            int i = 0;
            foreach (var item in dic)
            {
                PropertyInfo propertyInfo = type.GetProperty(item.Key);
                if (propertyInfo != null && propertyInfo.CanWrite)
                {
                    bool hasKeyAttribute = Attribute.IsDefined(propertyInfo, typeof(KeyAttribute));
                    if (hasKeyAttribute)
                    {
                        i++;  // if property has key attribute increment i by 1, just using this logic for debugging purpose..
                    }
                    else
                    {
                        filteredDic.Add(item.Key, item.Value);
                    }

                }
            }

            return filteredDic;
        }

        public static int NumberofPropertiesWithoutKeyAttribute<T>(Dictionary<string, object> dic, T data)  // this will filter out all the prpoerties of class with key attribute i.e it filters primary key frm the dictionary..
        {
            Dictionary<string, object> filteredDic = new Dictionary<string, object>();
            Type type = data.GetType();
            int i = 0;
            int j = 0;
            foreach (var item in dic)
            {
                PropertyInfo propertyInfo = type.GetProperty(item.Key);
                if (propertyInfo != null && propertyInfo.CanWrite)
                {
                    bool hasKeyAttribute = Attribute.IsDefined(propertyInfo, typeof(KeyAttribute));
                    if (hasKeyAttribute)
                    {
                        i++;  // if property has key attribute increment i by 1, just using this logic for debugging purpose..
                    }
                    else
                    {
                        j++;  // if property has no key attribute, j increments   
                    }

                }
            }

            return j++;
        }
    }
}