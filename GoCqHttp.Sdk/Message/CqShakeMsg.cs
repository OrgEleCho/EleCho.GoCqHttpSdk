using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    /// <summary>
    /// 窗口抖动（戳一戳
    /// 相当于戳一戳最基本类型的快捷方式
    /// </summary>
    [Obsolete(CqMsg.NotSupportedCqCodeTip)]
    public class CqShakeMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Shake;

        internal override CqMsgDataModel GetDataModel() => new CqShakeMsgDataModel();

        internal override void ReadDataModel(CqMsgDataModel model)
        { }
    }
}