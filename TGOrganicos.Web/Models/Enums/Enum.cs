using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TGOrganicos.Web.Models.Enums
{
    public static class Enums
    {
        public static string GetDescription(this System.Enum e)
        {
            FieldInfo f = e.GetType().GetField(e.ToString());
            DescriptionAttribute[] attrs = f.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            return attrs.Length > 0 ? attrs[0].Description : e.ToString();
        }

        public static string GetGeneric<T>(this System.Enum e) where T : GenericAttribute
        {
            FieldInfo f = e.GetType().GetField(e.ToString());
            GenericAttribute[] attrs = f.GetCustomAttributes(typeof(T), false) as GenericAttribute[];
            return attrs.Length > 0 ? attrs[0].Value : e.ToString();
        }
    }

    public class GenericAttribute : Attribute
    {
        private string value;

        public GenericAttribute(string value)
        {
            this.value = value;
        }

        public string Value
        {
            get
            {
                return this.value;
            }
        }
    }

    public static class EnunsUtils
    {
        public static IList<T> EnumToList<T>()
        {
            if (!typeof(T).IsEnum)
                throw new Exception("T não é um tipo de Enum!");

            IList<T> list = new List<T>();
            Type type = typeof(T);
            if (type != null)
            {
                Array enumValues = Enum.GetValues(type);
                foreach (T value in enumValues)
                {
                    list.Add(value);
                }
            }
            return list;
        }

        public static object GetFieldsToList<T>()
        {
            return PrepareEnumListToDDLByEnumType<T>(EnumToList<T>());
        }

        public static object PrepareEnumListToDDLByEnumType<T>(IList<T> enumList)
        {
            IList<object> list = new List<object>();

            foreach (var enumItem in enumList)
            {
                int key = Convert.ToInt32(enumItem);
                string text = ((Enum)Enum.ToObject(typeof(T), enumItem)).GetDescription();
                list.Add(new { Description = text, Id = key });
            }
            return list;
        }

        public static List<StructEnum> GetFieldsToListStructEnum<T>()
        {
            return PrepareEnumListToDDLByEnumTypeStructEnum<T>(EnumToList<T>());
        }

        public static List<StructEnum> PrepareEnumListToDDLByEnumTypeStructEnum<T>(IList<T> enumList)
        {
            List<StructEnum> list = new List<StructEnum>();

            foreach (var enumItem in enumList)
            {
                int key = Convert.ToInt32(enumItem);
                string text = ((Enum)Enum.ToObject(typeof(T), enumItem)).GetDescription();
                list.Add(new StructEnum { Description = text, Id = key });
            }
            return list;
        }

        public class StructEnum
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }
    }
}