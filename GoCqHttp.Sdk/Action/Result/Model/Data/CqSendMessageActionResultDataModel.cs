using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk.Action.Result.Model.Data
{
    /// <summary>
    /// 私聊消息和群聊消息的响应数据模型父类
    /// </summary>
    internal abstract class CqSendMessageActionResultDataModel : CqActionResultDataModel
    {
        public int message_id { get; set; }
    }
}