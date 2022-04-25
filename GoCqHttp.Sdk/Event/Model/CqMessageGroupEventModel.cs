namespace NullLib.GoCqHttpSdk.Event
{
    internal class CqMessageGroupEventModel : CqMessageEventModel
    {
        public override string message_type => "group";

        public long group_id { get; set; }
        public CqMessageAnonymousModel? anonymous { get; set; }
    }
}
