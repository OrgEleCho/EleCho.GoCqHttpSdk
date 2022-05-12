namespace NullLib.GoCqHttpSdk.Post.Model
{
    internal class CqMetaHeartbeatPostModel : CqMetaPostModel
    {
        public override string meta_event_type => "heartbeat";
        /// <summary>
        /// ms
        /// </summary>
        public long interval { get; set; }
    }
}
