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

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new());
        internal override void ReadDataModel(object model) { }
    }

    public class CqShakeDataModel
    {
        
    }
}
