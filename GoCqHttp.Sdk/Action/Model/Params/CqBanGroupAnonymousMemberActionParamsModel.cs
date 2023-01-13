using EleCho.GoCqHttpSdk.Post;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqBanGroupAnonymousMemberActionParamsModel : CqActionParamsModel
    {
        public CqBanGroupAnonymousMemberActionParamsModel(long group_id, CqAnonymousInformationModel? anonymous, string? anonymous_flag, long duration)
        {
            this.group_id = group_id;
            this.anonymous = anonymous;
            this.anonymous_flag = anonymous_flag;
            this.duration = duration;
        }

        public long group_id { get; set; }
        public CqAnonymousInformationModel? anonymous { get; set; }
        public string? anonymous_flag { get; set; }
        public long duration { get; set; }
    }
}
