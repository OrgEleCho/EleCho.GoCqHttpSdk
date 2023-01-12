using EleCho.GoCqHttpSdk.Utils;

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqMetaHeartbeatPostModel : CqMetaPostModel
    {
        public override string meta_event_type => Consts.MetaEventType.Heartbeat;

        /// <summary>
        /// ms
        /// </summary>
        public long interval { get; set; }
    }
}