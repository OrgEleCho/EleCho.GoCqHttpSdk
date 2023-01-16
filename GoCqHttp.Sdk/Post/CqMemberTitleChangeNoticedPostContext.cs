
using EleCho.GoCqHttpSdk.Post.Model;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqMemberTitleChangeNoticedPostContext : CqNotifyNoticePostContext
    {
        public override CqNotifyType NotifyType => CqNotifyType.Title;

        public long GroupId { get; set; }

        public long UserId { get; set; }

        public string NewTitle { get; set; } = string;


        internal CqMemberTitleChangeNoticedPostContext() { }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if(model is not CqNoticeTitlePostModel msgModel)
                return;

            GroupId = msgModel.group_id;
            UserId = msgModel.user_id;
            NewTitle = msgModel.title;
        }
    }
}
