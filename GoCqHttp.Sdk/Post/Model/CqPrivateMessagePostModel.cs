using EleCho.GoCqHttpSdk.Enumeration;

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqPrivateMessagePostModel : CqMessagePostModel
    {
        public override string message_type => "private";

        /// <summary>
        /// <see cref="CqTempSource"/>
        /// </summary>
        public int temp_source { get; set; }
        public CqMsgSenderModel sender { get; set; }
    }
}