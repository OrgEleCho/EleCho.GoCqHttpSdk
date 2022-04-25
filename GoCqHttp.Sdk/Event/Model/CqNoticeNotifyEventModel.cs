namespace NullLib.GoCqHttpSdk.Event
{
    public abstract class CqNoticeNotifyEventModel : CqNoticeEventModel
    {
        public override string notice_type => "notify";
        public abstract string sub_type { get; }
    }
}
