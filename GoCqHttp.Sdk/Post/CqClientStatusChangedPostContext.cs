using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Post.Model;

namespace NullLib.GoCqHttpSdk.Post
{
    public class CqClientStatusChangedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.ClientStatus;

        internal CqClientStatusChangedPostContext()
        { }

        public bool IsOnline { get; set; }
        public CqDevice Client { get; set; }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeClientStatusPostModel noticeModel)
                return;

            IsOnline = noticeModel.online;
            Client = new CqDevice(noticeModel.client);
        }

        internal override void WriteModel(CqPostModel model)
        {
            base.WriteModel(model);

            if (model is not CqNoticeClientStatusPostModel noticeModel)
                return;

            noticeModel.online = IsOnline;
            noticeModel.client = new CqDeviceModel(Client);
        }
    }
}