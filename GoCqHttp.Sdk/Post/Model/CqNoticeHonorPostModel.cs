using NullLib.GoCqHttpSdk.Enumeration;

namespace NullLib.GoCqHttpSdk.Post.Model
{
    internal class CqNoticeHonorPostModel : CqNoticeNotifyPostModel
    {
        public override string sub_type => "honor";

        public long group_id { get; set; }
        public long user_id { get; set; }

        /// <summary>
        /// <see cref="CqHonorType"/>
        /// </summary>
        public string honor_type { get; set; }
    }
}
