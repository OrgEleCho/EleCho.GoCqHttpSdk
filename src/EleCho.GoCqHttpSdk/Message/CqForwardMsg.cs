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
        /// <summary>
        /// 消息段类型: 转发消息
        /// </summary>
        public override string MsgType => Consts.MsgType.Forward;

        /// <summary>
        /// 转发消息 ID
        /// </summary>
        public string Id { get; set; } = string.Empty;

        internal CqForwardMsg()
        { }

        /// <summary>
        /// 构建转发消息
        /// </summary>
        /// <param name="id"></param>
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