using EleCho.GoCqHttpSdk.Action.Model.Params;

using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqSetGroupSpecialTitleAction : CqAction
    {
        public CqSetGroupSpecialTitleAction(long groupId, long userId, string specialTitle) :
            this(groupId, userId, specialTitle, TimeSpan.FromSeconds(-1))
        {
        }

        public CqSetGroupSpecialTitleAction(long groupId, long userId, string specialTitle, TimeSpan duration)
        {
            UserId = userId;
            GroupId = groupId;
            SpecialTitle = specialTitle;
            Duration = duration;
        }

        public override CqActionType ActionType => CqActionType.SetGroupSpecialTitle;
        
        public long GroupId { get; set; }
        public long UserId { get; set; }
        public string SpecialTitle { get; set; }
        public TimeSpan Duration { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqSetGroupSpecialTitleActionParamsModel(GroupId, UserId, SpecialTitle, Duration.ToLongTotalSeconds());
        }
    }
}
