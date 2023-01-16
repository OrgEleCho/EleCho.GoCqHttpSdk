using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Post;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.Data
{
    /// <summary>
    /// 私聊消息和群聊消息的响应数据模型父类
    /// </summary>
    internal class CqSendMessageActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqSendMessageActionResultDataModel(long message_id)
        {
            this.message_id = message_id;
        }

        public long message_id { get; set; }
    }
}