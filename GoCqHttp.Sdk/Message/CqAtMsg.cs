using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    /// <summary>
    /// @某人
    /// </summary>
    public class CqAtMsg : CqMsg
    {
        public override string Type => Consts.MsgType.At;

        /// <summary>
        /// 说明: @的 QQ 号, all 表示全体成员
        /// 可能的值: QQ 号, all
        /// </summary>
        public long QQ { get; set; }

        public string? Name { get; set; }

        internal CqAtMsg()
        { }

        public CqAtMsg(long qq)
        {
            QQ = qq;
        }

        internal override void ReadDataModel(CqMsgDataModel model)
        {
            CqAtMsgDataModel? m = model as CqAtMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            QQ = long.Parse(m.qq);
            Name = m.name;
        }

        internal override CqMsgDataModel GetDataModel()
        {
            return new CqAtMsgDataModel(QQ.ToString(), Name);
        }
    }
}