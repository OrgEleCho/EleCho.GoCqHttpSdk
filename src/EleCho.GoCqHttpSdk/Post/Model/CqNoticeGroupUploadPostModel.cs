#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

using EleCho.GoCqHttpSdk.DataStructure.Model;

namespace EleCho.GoCqHttpSdk.Post.Model;

internal class CqNoticeGroupUploadPostModel : CqNoticePostModel
{
    public override string notice_type => "group_upload";

    public long group_id { get; set; }
    public long user_id { get; set; }
    public CqGroupUploadedFileModel file { get; set; }
}