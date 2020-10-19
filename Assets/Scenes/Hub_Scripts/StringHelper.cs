using System;
using System.Text.RegularExpressions;

namespace Hub_UI
{
    public static class StringHelper
    {
        static Random rnd = new Random();

        public static string Highlight(this string str)
        {
            str = Regex.Replace(str, @"[\+\-]\d+", (match) =>
            {
                if (match.Value.StartsWith("-"))
                    return "<color=red>" + match.Value + "</color>";
                else
                    return "<color=green>" + match.Value + "</color>";
            });

            str = Regex.Replace(str, @"%NAME%", (match) =>
            {
                return (Bus.Units.Value.GetRnd(rnd)?.Name) ?? "Mr.Null";
            });
            return str;
        }
    }
}