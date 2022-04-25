using System.Reflection;
using System.Text.Json.Serialization;

namespace NullLib.GoCqHttpSdk.Event
{
    public abstract class CqEventModel
    {
        public abstract string post_type { get; }

        public long time { get; set; }
        public long self_id { get; set; }
    }
}
