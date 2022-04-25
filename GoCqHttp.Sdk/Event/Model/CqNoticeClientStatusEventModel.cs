namespace NullLib.GoCqHttpSdk.Event
{
    internal class CqNoticeClientStatusEventModel : CqNoticeEventModel
    {
        public override string notice_type => "client_status";

        public bool online { get; set; }
        public CqDeviceModel client { get; set; }
    }
}
