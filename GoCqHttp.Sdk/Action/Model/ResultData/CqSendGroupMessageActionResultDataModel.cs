using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.Data
{
    internal class CqSendGroupMessageActionResultDataModel : CqSendMessageActionResultDataModel
    {
        // 继承父类属性
        [JsonConstructor]
        public CqSendGroupMessageActionResultDataModel(long message_id) : base(message_id)
        {
        }
    }
}