using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

//Copyright (c) https://github.com/Xuxunguinho All rights reserved
namespace lizzie.extensions
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        ///  Getting values from an object property dynamically
        /// </summary>
        /// <param name="fields">Props name</param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static object GetValue(this IEnumerable<string> fields, object item)
        {
            object finalvalue = null;
            var enumerable = fields as string[] ?? fields.ToArray();
            for (var i = 0; i <= enumerable.Count() - 1; i++)
            {
                var props = TypeDescriptor.GetProperties(item);
                var value = props[enumerable[i]]?.GetValue(item);

                if (i >= enumerable.Length - 1)
                {
                    finalvalue = value;
                    continue;
                }
                props = TypeDescriptor.GetProperties(value);
                var finalProp = enumerable[i + 1];
                if (value is null) return new object();
                finalvalue = props[finalProp]?.GetValue(value);
                break;
            }
            return finalvalue;
        }

        /// <summary> 
        /// deserializes an expression with the purpose of getting the operands into a string[]
        /// eg: x=> x.People.Nome  -> {Peolpe,Nome}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field">Expression</param>
        /// <returns></returns>
        public static string[] DeserializeExpr<T>(this Expression<Func<T, object>> field)
        {
            try
            {
                var props = TypeDescriptor.GetProperties(field.Body.GetType());
                var obj = props["Operand"]?.GetValue(field.Body)?.ToString() ?? field.Body.ToString();
                var strfinal = obj?.Split('.').RightItems(0);
                return strfinal?.ToArray() ?? new string[] { };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// checks whether an Enumerable is null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            try
            {
                if (source == null)
                    return true;
                return source?.Count() < 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return true;
            }
        }

        /// <summary>
        /// create an instance of the object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateInstance<T>()
        {
            var obj = TypeDescriptor.CreateInstance(null, typeof(T), null, null);
            return (T) obj;
        }
        //Same helper, but in an extension class (public static class),
        //but could be in a base class also.

    }
}