using EleCho.GoCqHttpSdk.Enumeration;
using EleCho.GoCqHttpSdk.Post.Model.Base;
using EleCho.GoCqHttpSdk.Utils;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles


namespace EleCho.GoCqHttpSdk.Post.Model;

internal class CqNoticeGroupAdminPostModel : CqNoticePostModel
{
    public override string notice_type => Consts.NoticeType.GroupAdmin;

    /// <summary>
    /// <see cref="CqGroupAdminChangeType"/>
    /// </summary>
    public string sub_type { get; set; }

    public long group_id { get; set; }

    public long user_id { get; set; }
}