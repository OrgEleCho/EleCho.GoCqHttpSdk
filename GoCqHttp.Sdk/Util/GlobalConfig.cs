using System;
using System.Text;

namespace EleCho.GoCqHttpSdk.Utils
{
    public static class GlobalConfig
    {
        public static TimeSpan WaitTimeout = TimeSpan.FromSeconds(5);
        public static int WebSocketBufferSize = 1024;
        public static Encoding TextEncoding = Encoding.UTF8;
    }
}