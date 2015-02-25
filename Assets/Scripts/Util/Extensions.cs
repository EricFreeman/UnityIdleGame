using System;
using System.Collections.Generic;

namespace Assets.Scripts.Util
{
    public static class Extensions
    {
        public static string ToFormat(this string s, params object[] p)
        {
            return string.Format(s, p);
        }

        public static void Each<T>(this IEnumerable<T> items, Action<T> a)
        {
            foreach (var item in items)
            {
                a(item);
            }
        }
    }
}
