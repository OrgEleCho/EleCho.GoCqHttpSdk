namespace NullLib.GoCqHttpSdk.Post.Model
{
    internal abstract class CqMetaPostModel : CqPostModel
    {
        public override string post_type => "meta_event";
        public abstract string meta_event_type { get; }
    }
}
