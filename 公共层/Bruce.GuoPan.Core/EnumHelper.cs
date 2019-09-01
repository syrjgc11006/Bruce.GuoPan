using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bruce.GuoPan.Core
{
    public static class EnumHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nameInstend"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value, bool nameInstend = true)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }
            FieldInfo field = type.GetField(name);
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (attribute == null && nameInstend == true)
            {
                return name;
            }
            return attribute == null ? null : attribute.Description;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> EnumToDictionary<T>()
        {
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                throw new System.Exception("不是枚举类型");
            }
            Dictionary<int, string> values = new Dictionary<int, string>();
            FieldInfo[] enumItems = type.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (FieldInfo fieldInfo in enumItems)
            {
                var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                int value = (int)fieldInfo.GetValue(type);
                string desc = (attributes.Length > 0) ? attributes[0].Description : value.ToString();
                if (values.ContainsKey(value))
                {
                    values[value] = desc;
                }
                else
                {
                    values.Add(value, desc);
                }
            }
            return values;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<string, string> EnumToDict<T>()
        {
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                throw new System.Exception("不是枚举类型");
            }
            Dictionary<string, string> values = new Dictionary<string, string>();
            FieldInfo[] enumItems = type.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (FieldInfo fieldInfo in enumItems)
            {
                var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                string value = fieldInfo.Name.ToString();
                string desc = (attributes.Length > 0) ? attributes[0].Description : value.ToString();
                if (values.ContainsKey(value))
                {
                    values[value] = desc;
                }
                else
                {
                    values.Add(value, desc);
                }
            }
            return values;
        }
    }
}
