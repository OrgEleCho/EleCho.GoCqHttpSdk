using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Post;

namespace EleCho.GoCqHttpSdk.Action.Result.Model.Data
{
    /// <summary>
    /// 私聊消息和群聊消息的响应数据模型父类
    /// </summary>
    internal abstract class CqSendMsgActionResultDataModel : CqActionResultDataModel
    {
        public int message_id { get; set; }
    }



    internal class CqGetMsgActionResultDataModel : CqActionResultDataModel
    {
        public bool group { get; set; }
        public int message_id { get; set; }
        public int real_id { get; set; }
        public CqMsgSenderModel sender { get; set; }
        public int time { get; set; }
        public CqMsgModel[] message { get; set; }
        public string raw_message { get; set; }
    }
}