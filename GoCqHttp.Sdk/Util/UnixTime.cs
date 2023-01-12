using System;

namespace EleCho.GoCqHttpSdk.Utils
{
    internal static class UnixTime
    {
        public static long DateToUnix(DateTime time)
        {
            return new DateTimeOffset(time).ToUnixTimeSeconds();
        }

        public static DateTime DateFromUnix(long unixTime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).DateTime;
        }
    }
}