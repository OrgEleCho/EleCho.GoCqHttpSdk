namespace NullLib.GoCqHttpSdk.Post.Model
{
    internal class CqNoticeOfflineFilePostModel : CqNoticePostModel
    {
        public override string notice_type => "offline_file";

        public long user_id { get; set; }
        public CqOfflineFileModel file { get; set; }
    }
}
