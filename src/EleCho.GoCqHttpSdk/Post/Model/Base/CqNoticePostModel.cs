namespace EleCho.GoCqHttpSdk.Post.Model.Base;

internal abstract class CqNoticePostModel : CqPostModel
{
    public override string post_type => "notice";
    public abstract string notice_type { get; }
}