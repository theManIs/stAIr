using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Model
{
    public static class StringHelper
    {
        static Random rnd = new Random();

        public static string Prepare(this string str)
        {
            str = Regex.Replace(str, @"[\+\-]\d+", (match) =>
            {
                if (match.Value.StartsWith("-"))
                    return "<color=red>" + match.Value + "</color>";
                else
                    return "<color=green>" + match.Value + "</color>";
            });

            str = Regex.Replace(str, @"%UNIT%", (match) =>
            {
                return (Player.Instance.Units.GetRnd(rnd)?.Name) ?? "Mr.Null";
            });

            str = Regex.Replace(str, @" I", (match) =>
            {
                return "\x00a0I";
            });
            return str;
        }

        public static IEnumerable<string> SplitEffects(this string str)
        {
            foreach (Match m in Regex.Matches(str, @"([\+\-]\d+[^\+\-]*)"))
                yield return m.Value;
        }
    }

    public static class EnumerableHelper
    {
        public static void Foreach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
                action(item);
        }
    }
}