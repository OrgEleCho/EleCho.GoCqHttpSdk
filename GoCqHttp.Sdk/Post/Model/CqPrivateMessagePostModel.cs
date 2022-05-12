using NullLib.GoCqHttpSdk.Enumeration;

namespace NullLib.GoCqHttpSdk.Post.Model
{
    internal class CqPrivateMessagePostModel : CqMessagePostModel
    {
        public override string message_type => "private";

        /// <summary>
        /// <see cref="CqTempSourceType"/>
        /// </summary>
        public string temp_source { get; set; }
    }
}
