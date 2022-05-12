using NullLib.GoCqHttpSdk.Enumeration;

namespace NullLib.GoCqHttpSdk.Post.Model
{
    internal class CqRequestGroupPostModel : CqRequestPostModel
    {
        public override string request_type => "group";

        /// <summary>
        /// <see cref="CqRequestGroupType"/>
        /// </summary>
        public string sub_type { get; set; }
        public long group_id { get; set; }
        public long user_id { get; set; }
        public string comment { get; set; }
        public string flag { get; set; }
    }
}
