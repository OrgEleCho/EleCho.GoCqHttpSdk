using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 文本转语音消息段
    /// </summary>
    public record class CqTtsMsg : CqMsg
    {
        internal CqTtsMsg()
        {
        }

        /// <summary>
        /// 构建文本转语音消息段
        /// </summary>
        /// <param name="text"></param>
        public CqTtsMsg(string text)
        {
            Text = text;
        }

        /// <summary>
        /// 消息段类型: 文本转语音
        /// </summary>
        public override string MsgType => Consts.MsgType.TTS;

        /// <summary>
        /// 文本内容
        /// </summary>
        public string Text { get; set; } = string.Empty;

        internal override CqMsgDataModel? GetDataModel()
        {
            return new CqTtsMsgDataModel(Text);
        }

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            if (model is not CqTtsMsgDataModel m)
                throw new ArgumentException();

            Text = m.text;
        }
    }
}