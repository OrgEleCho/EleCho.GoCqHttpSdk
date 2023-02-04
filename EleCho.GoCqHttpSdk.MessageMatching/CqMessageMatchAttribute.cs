using System;
using System.Text.RegularExpressions;

namespace EleCho.GoCqHttpSdk.MessageMatching
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class CqMessageMatchAttribute : Attribute
    {
        internal Regex Regex { get; }
        
        public string Pattern { get; }

        public CqMessageMatchAttribute(string pattern)
        {
            Pattern = pattern;
            Regex = new(pattern);
        }

        public CqMessageMatchAttribute(string pattern, RegexOptions options)
        {
            Pattern = pattern;
            Regex = new(pattern, options);
        }
    }
}