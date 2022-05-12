namespace NullLib.GoCqHttpSdk.Post.Model
{
    internal class CqNoticeClientStatusPostModel : CqNoticePostModel
    {
        public override string notice_type => "client_status";

        public bool online { get; set; }
        public CqDeviceModel client { get; set; }
    }
}
