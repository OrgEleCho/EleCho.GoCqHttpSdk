
using EleCho.GoCqHttpSdk.Post.Model;
using System;

namespace EleCho.GoCqHttpSdk.Post
{
    /// <summary>
    /// 群成员禁言状态变更
    /// </summary>
    public class CqGroupMemberBanChangedPostContext : CqNoticePostContext
    {
        public override CqNoticeType NoticeType => CqNoticeType.GroupBan;

        public CqGroupBanChangeType ChangeType { get; set; }

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public long OperatorId { get; set; }
        public TimeSpan Duration { get; set; }

        internal CqGroupMemberBanChangedPostContext() { }

        internal override object? QuickOperationModel => null;
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