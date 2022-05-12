using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Util
{
    public static class GlobalConfig
    {
        public static TimeSpan WaitTimeout = TimeSpan.FromSeconds(5);
        public static int WebSocketBufferSize = 1024;
        public static Encoding TextEncoding = Encoding.UTF8;
    }
}
