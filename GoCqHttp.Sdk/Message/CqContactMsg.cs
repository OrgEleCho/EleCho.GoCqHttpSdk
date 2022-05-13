using NullLib.GoCqHttpSdk.Enumeration;
using NullLib.GoCqHttpSdk.Message.DataModel;
using NullLib.GoCqHttpSdk.Util;
using System;

namespace NullLib.GoCqHttpSdk.Message
{
    /// <summary>
    /// 推荐好友/群
    /// </summary>
    [Obsolete(CqMsg.NotSupportedCqCodeTip)]
    public class CqContactMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Contact;

        internal CqContactMsg()
        { }

        public CqContactMsg(CqContactType type, long id)
        {
            ContactType = type;
            Id = id;
        }

        /// <summary>
        /// 推荐好友/群
        /// </summary>
        public CqContactType ContactType { get; set; }

        /// <summary>
        /// 被推荐的 QQ （群）号
        /// </summary>
        public long Id { get; set; }

        internal override CqMsgDataModel GetDataModel() => new CqContactMsgDataModel(CqEnum.GetString(ContactType), Id);

        internal override void ReadDataModel(CqMsgDataModel model)
        {
            CqContactMsgDataModel? m = model as CqContactMsgDataModel;
            if (m == null)
                throw new ArgumentException();

            ContactType = CqEnum.GetContactType(m.type);
            Id = m.id;
        }
    }
}