namespace NullLib.GoCqHttpSdk.Event
{
    internal class CqNoticeOfflineFileEventModel : CqNoticeEventModel
    {
        public override string notice_type => "offline_file";

        public long user_id { get; set; }
        public CqOfflineFileModel file { get; set; }
    }
}
