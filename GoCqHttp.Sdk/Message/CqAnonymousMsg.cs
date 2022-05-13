using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    /// <summary>
    /// 匿名发消息
    /// 提示: 当收到匿名消息时, 需要通过 消息事件的群消息 的 anonymous 字段判断
    /// </summary>
    [Obsolete(CqMsg.NotSupportedCqCodeTip)]
    public class CqAnonymousMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Anonymous;

        /// <summary>
        /// 说明: 可选, 表示无法匿名时是否继续发送
        /// 可能的值: 0, 1
        /// </summary>
        public int? Ignore { get; set; }

        internal override CqMsgDataModel GetDataModel() => new CqAnonymousMsgDataModel();

        internal override void ReadDataModel(CqMsgDataModel model)
        { }
    }
}