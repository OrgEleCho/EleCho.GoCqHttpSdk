namespace NullLib.GoCqHttpSdk.Post.Model
{
    internal class CqMetaLifecyclePostModel : CqMetaPostModel
    {
        public override string meta_event_type => "lifecycle";
        public string sub_type { get; set; }
    }
}