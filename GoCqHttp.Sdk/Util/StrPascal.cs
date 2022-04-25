using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Util
{
    internal static class StrPascal
    {
        private static IEnumerable<string> SplitPascalStr(string pascalStr)
        {
            var sb = new StringBuilder();
            bool allUpperBefore = true;
            foreach (var c in pascalStr)
            {
                if (char.IsUpper(c))
                {
                    if (!allUpperBefore)
                    {
                        if (sb.Length > 0)
                        {
                            yield return sb.ToString();
                            allUpperBefore = true;
                            sb.Clear();
                        }
                    }

                    sb.Append(c);
                }
                else
                {
                    if (allUpperBefore && sb.Length > 1)
                    {
                        yield return sb.ToString().Substring(0, sb.Length - 1);
                        sb.Remove(0, sb.Length - 1);
                    }

                    sb.Append(c);
                    allUpperBefore = false;
                }
            }
            if (sb.Length > 0)
            {
                yield return sb.ToString();
            }
        }

        public static string? ToCamelStr(object? any)
        {
            if (any == null)
                return null;

            IEnumerator<string> chunks = SplitPascalStr(any.ToString()!).GetEnumerator();
            var sb = new StringBuilder();
            if (chunks.MoveNext())
            {
                sb.Append(chunks.Current.ToLower());

                while (chunks.MoveNext())
                {
                    sb.Append(chunks.Current);
                }

                return sb.ToString();
            }

            return string.Empty;
        }

        public static string? ToSnakeStr(object? any)
        {
            if (any == null)
                return null;

            IEnumerator<string> chunks = SplitPascalStr(any.ToString()!).GetEnumerator();
            var sb = new StringBuilder();
            if (chunks.MoveNext())
            {
                sb.Append(chunks.Current.ToLower());

                while (chunks.MoveNext())
                {
                    sb.Append('_');
                    sb.Append(chunks.Current.ToLower());
                }

                return sb.ToString();
            }

            return string.Empty;
        }
    }

    internal static class TypeExt
    {
        public static int ToInt(this bool b)
        {
            return b ? 1 : 0;
        }
        public static int ToInt(this bool? b)
        {
            if (!b.HasValue)
                return 0;
            
            return b.Value ? 1 : 0;
        }

        public static bool ToBool(this int i)
        {
            return i != 0;
        }

        public static bool ToBool(this int? i)
        {
            if (!i.HasValue)
                return false;

            return i.Value != 0;
        }
    }
}
