using EleCho.GoCqHttpSdk.Post.Model;
using EleCho.GoCqHttpSdk.Util;

namespace EleCho.GoCqHttpSdk.Post
{
    internal class CqGroupFileModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public long size { get; set; }
        public long busid { get; set; }
    }
}