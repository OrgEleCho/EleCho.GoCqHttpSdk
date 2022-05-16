using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
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
    }
}