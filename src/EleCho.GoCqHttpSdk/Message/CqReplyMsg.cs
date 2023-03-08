using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    public record class CqReplyMsg : CqMsg
    {
        public override string MsgType => Consts.MsgType.Reply;

#pragma warning disable CS8618

        internal CqReplyMsg()
        { }

#pragma warning restore CS8618

        /// <summary>
        /// 实例化回复消息
        /// </summary>
        /// <param name="id"></param>
        public CqReplyMsg(long id)
        {
            Id = id;
        }

        /// <summary>
        /// 实例化自定义回复消息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="qq"></param>
        /// <param name="seq"></param>
        public CqReplyMsg(string text, long qq, long seq)
        {
            Text = text;
            UserId = qq;
            Seq = seq;

            Time = DateTime.Now;
        }

        /// <summary>
        /// 回复的消息 ID (必须是当前会话的消息)
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 自定义回复消息内容
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// 自定义回复消息的 QQ
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 自定义回复消息的事件
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 起始序列号
        /// </summary>
        public long Seq { get; set; }

        internal override CqMsgDataModel? GetDataModel() => new CqReplyMsgDataModel(Id, Text, UserId, new DateTimeOffset(Time).ToUnixTimeSeconds(), Seq);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqReplyMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Id = m.id;
            Text = m.text;
            UserId = m.qq;
            Time = DateTimeOffset.FromUnixTimeSeconds(m.time).DateTime;
            Seq = m.seq;
        }
    }
}