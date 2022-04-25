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

        internal CqAtMsg() { }
        public CqAtMsg(long qq)
        {
            QQ = qq;
        }

        internal override void ReadDataModel(object model)
        {
            CqAtDataModel? m = model as CqAtDataModel;
            if (m == null)
                throw new ArgumentException();

            QQ = long.Parse(m.qq);
            Name = m.name;
        }

        internal override CqMsgModel GetModel()
        {
            if (Name == null)
                throw new ArgumentException(null, nameof(Name));

            return new CqMsgModel(Type, new CqAtDataModel(QQ.ToString(), Name));
        }
    }

    internal class CqAtDataModel
    {
        public CqAtDataModel()
        {
        }

        public CqAtDataModel(string qq, string name)
        {
            this.qq = qq;
            this.name = name;
        }

        public string qq { get; set; }
        public string name { get; set; }
    }
}
