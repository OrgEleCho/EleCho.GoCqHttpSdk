using System;
using System.Text.RegularExpressions;

namespace EleCho.GoCqHttpSdk.MessageMatching
{
    /// <summary>
    /// 消息匹配特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class CqMessageMatchAttribute : Attribute
    {
        internal Regex Regex { get; }

        /// <summary>
        /// 正则表达式
        /// </summary>
        public string Pattern { get; }

        public CqMessageMatchAttribute(string pattern)
        {
            if (pattern == null)
                throw new ArgumentNullException(nameof(pattern));

            Pattern = pattern;
            Regex = new(pattern);
        }

        public CqMessageMatchAttribute(string pattern, RegexOptions options)
        {
            if (pattern == null)
                throw new ArgumentNullException(nameof(pattern));

            Pattern = pattern;
            Regex = new(pattern, options);
        }
    }
}