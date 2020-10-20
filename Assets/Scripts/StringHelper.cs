using System;
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
            return str;
        }
    }
}