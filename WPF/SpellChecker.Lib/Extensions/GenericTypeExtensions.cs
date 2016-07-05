using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellChecker.Lib.Models;

namespace SpellChecker.Lib.Extensions
{
    /// <summary>
    /// This class is used for T type as "enum".  T must belong to "enum" type.
    /// </summary>
    internal class GenericTypeExtensions
    {
        /// <summary>
        /// get name from given enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public string GetNameByEnum<T>(T typeId)
        {
            return Enum.GetName(typeof(T), typeId);
        }

        /// <summary>
        /// get equivalent enum object from given intteger value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public T GetEnumByInteger<T>(int value)
        {
            Type type = typeof(T);

            if (!type.IsEnum)
            {
                throw new ArgumentException("Enum expected.", "TEnum");
            }

            return (T)Enum.Parse(type, value.ToString(), true);
        }


        /// <summary>
        /// get all types (text,value) for an "enum" type. Result is returned in a list of <text,value>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<TextValue> GetAllTargetTypes<T>()
        {
            List<TextValue> list = new List<TextValue>();
            foreach (T value in Enum.GetValues(typeof(T)))
            {
                list.Add(new TextValue { text = GetNameByEnum(value), value = (int)Enum.Parse(typeof(T), GetNameByEnum(value)) });
            }

            return list;
        }
    }
}
