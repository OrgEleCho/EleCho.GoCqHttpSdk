using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 转发消息
    /// </summary>
    public record class CqForwardMsg : CqMsg
    {
        public override string MsgType => Consts.MsgType.Forward;

        public string Id { get; set; } = string.Empty;

        internal CqForwardMsg()
        { }

        public CqForwardMsg(string id) => Id = id;

        internal override CqMsgDataModel? GetDataModel() => new CqForwardMsgDataModel(Id);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqForwardMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Id = m.id;
        }
    }
}