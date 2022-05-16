using EleCho.GoCqHttpSdk.Model;

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal abstract class CqPostModel : CqWsDataModel
    {
        public abstract string post_type { get; }

        public long time { get; set; }
        public long self_id { get; set; }
    }
}