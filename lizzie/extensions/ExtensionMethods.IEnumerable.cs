using System.Collections.Generic;
using System.Linq;

//Copyright (c) https://github.com/Xuxunguinho All rights reserved.
namespace lizzie.extensions
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int RightCount<T>(this IEnumerable<T> source, T item)
        {
            var list = source?.ToList();
            if (list != null && !list.Any()) return 0;

            if (list != null)
            {
                var idx = list.IndexOf(item);
                var i = list.Count - (idx + 1);

                return i;
            }
            else return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int LeftCount<T>(this IEnumerable<T> source, T item)
        {
            var enumerable = source as IList<T> ?? source.ToList();
            var list = enumerable?.ToList();
            if (list.Any())
            {
                var countr = enumerable.RightCount(item);
                var count = list.Count - countr;

                return count;
            }
            else return 0;
        }

        /// <summary>
        /// Obtem o item a esquerda do item especificado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static T LeftItem<T>(this IEnumerable<T> source, T item)
        {
            var list = source?.ToList();
            if (list != null)
            {
                var idx = list.IndexOf(item);
                return idx > 1 ? list[idx - 1] : list.FirstOrDefault();
            }
            else
            {
                return default(T);
            }
        }

        public static IEnumerable<T> LeftItems<T>(this IEnumerable<T> source, T item)
        {
            var enumerable = source as T[] ?? source.ToArray();
            if (!enumerable.Contains(item)) return new List<T>();
            var listleft = CreateInstance<List<T>>();
            var idx = enumerable.ToList().IndexOf(item);
            if (idx > 0)
            {
                for (var i = 0; i < idx; i++)
                {
                    listleft.Add(enumerable[i]);
                }
                return listleft;
            }
            else return new List<T>();
        }

        public static IEnumerable<T> LeftItems<T>(this IEnumerable<T> source, int index)
        {
            var enumerable = source as T[] ?? source.ToArray();

            var item = enumerable[index];

            if (!enumerable.Contains(item)) return new List<T>();
            var listleft = CreateInstance<List<T>>();
            var idx = enumerable.ToList().IndexOf(item);
            if (idx > 0)
            {
                for (var i = 0; i < idx; i++)
                {
                    listleft.Add(enumerable[i]);
                }
                return listleft;
            }
            else return new List<T>();
        }

        public static IEnumerable<T> RightItems<T>(this IEnumerable<T> source, T item)
        {
            var enumerable = source as T[] ?? source.ToArray();
            if (!enumerable.Contains(item)) return new List<T>();
            var listleft = CreateInstance<List<T>>();
            var idx = enumerable.ToList().IndexOf(item);
            var list = enumerable.ToList();
            if (list.Count > idx)
            {
                for (var i = idx + 1; i < list.Count; i++)
                {
                    listleft.Add(enumerable[i]);
                }
                return listleft;
            }
            else return new List<T>();
        }

        public static IEnumerable<T> RightItems<T>(this IEnumerable<T> source, int index)
        {
            var enumerable = source as T[] ?? source.ToArray();

            var item = enumerable[index];

            if (!enumerable.Contains(item)) return new List<T>();
            var listleft = CreateInstance<List<T>>();
            var idx = enumerable.ToList().IndexOf(item);
            var list = enumerable.ToList();
            if (list.Count > idx)
            {
                for (var i = idx + 1; i < list.Count; i++)
                {
                    listleft.Add(enumerable[i]);
                }
                return listleft;
            }
            else return new List<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static T RightItem<T>(this IEnumerable<T> source, T item)
        {
            var list = source?.ToList();
            if (list != null)
            {
                var idx = list.IndexOf(item);

                return idx < list.Count - 1 ? list[idx + 1] : default(T);
            }
            else
            {
                return default(T);
            }
        }

        public static T LastOrdefaultItem<T>(this IEnumerable<T> source)
        {
            if (source == null) return default(T);
            var list = source?.ToList();
            if (list.IsNullOrEmpty()) return default(T);
            var idx = list.Count - 1;
            return list[idx];
        }
    }
}