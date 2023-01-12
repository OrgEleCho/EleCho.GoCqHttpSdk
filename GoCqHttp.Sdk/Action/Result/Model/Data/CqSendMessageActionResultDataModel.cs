using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk.Action.Model.Data
{
    /// <summary>
    /// 私聊消息和群聊消息的响应数据模型父类
    /// </summary>
    internal class CqSendMessageActionResultDataModel : CqActionResultDataModel
    {
        public long message_id { get; set; }
    }
}