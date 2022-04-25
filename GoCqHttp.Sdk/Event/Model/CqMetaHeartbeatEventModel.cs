namespace NullLib.GoCqHttpSdk.Event
{
    internal class CqMetaHeartbeatEventModel : CqMetaEventModel
    {
        public override string meta_event_type => "heartbeat";
        /// <summary>
        /// ms
        /// </summary>
        public long interval { get; set; }
    }
}
