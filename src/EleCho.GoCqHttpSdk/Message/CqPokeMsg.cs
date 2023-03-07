using EleCho.GoCqHttpSdk.Message.DataModel;
using EleCho.GoCqHttpSdk.Utils;
using System;

namespace EleCho.GoCqHttpSdk.Message
{
    /// <summary>
    /// 拍一拍消息段
    /// </summary>
    public record class CqPokeMsg : CqMsg
    {
        /// <summary>
        /// 消息类型: 拍一拍
        /// </summary>
        public override string MsgType => Consts.MsgType.Poke;

        /// <summary>
        /// 目标用户 QQ
        /// </summary>
        public long Target { get; set; }

        internal CqPokeMsg()
        { }

        /// <summary>
        /// 实例化拍一拍消息段
        /// </summary>
        /// <param name="target"></param>
        public CqPokeMsg(long target) => Target = target;

        internal override CqMsgDataModel? GetDataModel() => new CqPokeMsgDataModel(Target);

        internal override void ReadDataModel(CqMsgDataModel? model)
        {
            var m = model as CqPokeMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            Target = m.qq;
        }
    }
}