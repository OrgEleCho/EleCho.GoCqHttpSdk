namespace EleCho.GoCqHttpSdk.Post.Model.Base;

internal abstract class CqRequestPostModel : CqPostModel
{
    public override string post_type => "request";
    public abstract string request_type { get; }
}