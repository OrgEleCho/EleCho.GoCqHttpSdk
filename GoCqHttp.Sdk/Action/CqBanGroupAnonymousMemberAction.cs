using EleCho.GoCqHttpSdk.Action.Model.Params;
using EleCho.GoCqHttpSdk.DataStructure;
using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqBanGroupAnonymousMemberAction : CqAction
    {
        public CqBanGroupAnonymousMemberAction(long groupId, CqAnonymousInfomation? anonymous, TimeSpan duration)
        {
            GroupId = groupId;
            Anonymous = anonymous;
            Duration = duration;
        }

        public CqBanGroupAnonymousMemberAction(long groupId, string? anonymousFlag, TimeSpan duration)
        {
            GroupId = groupId;
            AnonymousFlag = anonymousFlag;
            Duration = duration;
        }

        public override CqActionType Type => CqActionType.BanGroupAnonymousMember;

        public long GroupId { get; set; }

        public CqAnonymousInfomation? Anonymous { get; set; }

        public string? AnonymousFlag { get; set; }

        public TimeSpan Duration { get; set; }


        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqBanGroupAnonymousMemberActionParamsModel(
                GroupId,
                Anonymous != null ? new Post.CqAnonymousInformationModel(Anonymous) : null,
                AnonymousFlag,
                Duration.ToLongTotalSeconds());
        }
    }
}
