using System;
using System.Threading;
using NullLib.GoCqHttpSdk.Util;

namespace NullLib.GoCqHttpSdk.Message
{
    /// <summary>
    /// 推荐好友/群
    /// </summary>
    [Obsolete(CqMsg.NotSupportedCqCodeTip)]
    public class CqContactMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Contact;
        
        internal CqContactMsg() { }
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

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqContactDataModel(StrPascal.ToCamelStr(ContactType)!, Id));
        internal override void ReadDataModel(object model)
        {
            CqContactDataModel? m = model as CqContactDataModel;
            if (m == null)
                throw new ArgumentException();

            ContactType = m.type switch
            {
                "qq" => CqContactType.QQ,
                "group" => CqContactType.Group,
                _ => (CqContactType)(-1)
            };
            Id = m.id;
        }

        public enum CqContactType
        {
            QQ,
            Group
        }
    }

    internal class CqContactDataModel
    {
        public CqContactDataModel()
        {
        }

        public CqContactDataModel(string type, long id)
        {
            this.type = type;
            this.id = id;
        }

        public string type { get; set; }
        public long id { get; set; }
    }
}
