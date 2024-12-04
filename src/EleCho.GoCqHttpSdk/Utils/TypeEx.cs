using System;

namespace EleCho.GoCqHttpSdk.Utils;

internal static class TypeEx
{
    public static int ToInt(this bool? value)
    {
        if (!value.HasValue)
            return 0;

        return value.Value ? 1 : 0;
    }

    public static int? ToNullableInt(this bool? value)
    {
        if (!value.HasValue)
            return null;
        return value.Value ? 1 : 0;
    }

    public static int ToInt(this bool value)
    {
        return value ? 1 : 0;
    }

    public static bool ToBool(this int? value)
    {
        if (!value.HasValue)
            return false;

        return value.Value != 0;
    }

    public static bool ToBool(this int value)
    {
        return value != 0;
    }

    public static long ToLongTotalSeconds(this TimeSpan timeSpan)
    {
        return timeSpan.Ticks / TimeSpan.TicksPerSecond;
    }
}