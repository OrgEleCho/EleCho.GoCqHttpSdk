using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Model;
using System;

namespace EleCho.GoCqHttpSdk.Post
{
    public class CqGroupBanChangedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.GroupBan;

        public CqGroupBanChangeType ChangeType { get; set; }

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public long OperatorId { get; set; }
        public TimeSpan Duration { get; set; }

        internal CqGroupBanChangedPostContext()
        { }

        internal override void ReadModel(CqPostModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeGroupBanPostModel postModel)
                return;

            ChangeType = CqEnum.GetGroupBanChangeType(postModel.sub_type);
            GroupId = postModel.group_id;
            UserId = postModel.user_id;
            OperatorId = postModel.operator_id;
            Duration = TimeSpan.FromSeconds(postModel.duration);
        }
    }
}