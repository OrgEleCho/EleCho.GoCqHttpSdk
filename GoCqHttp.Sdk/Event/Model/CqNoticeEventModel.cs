namespace NullLib.GoCqHttpSdk.Event
{
    public abstract class CqNoticeEventModel : CqEventModel
    {
        public override string post_type => "notice";
        public abstract string notice_type { get; }
    }
}
