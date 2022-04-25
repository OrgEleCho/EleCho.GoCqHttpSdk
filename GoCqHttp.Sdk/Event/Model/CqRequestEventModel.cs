namespace NullLib.GoCqHttpSdk.Event
{
    public abstract class CqRequestEventModel : CqEventModel
    {
        public override string post_type => "request";
        public abstract string request_type { get; }
    }
}
