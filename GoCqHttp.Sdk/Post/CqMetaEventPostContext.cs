using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Util;

namespace NullLib.GoCqHttpSdk.Post
{
    public abstract class CqMetaEventPostContext : CqPostContext
    {
        public override CqPostType EventType => CqPostType.MetaEvent;
        public abstract CqMetaType MetaEventType { get; }
    }
}
