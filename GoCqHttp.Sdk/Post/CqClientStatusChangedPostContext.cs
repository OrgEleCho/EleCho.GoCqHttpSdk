using EleCho.GoCqHttpSdk;

using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqClientStatusChangedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.ClientStatus;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal CqClientStatusChangedPostContext() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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
    }
}