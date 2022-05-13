#pragma warning disable CS8618

using NullLib.GoCqHttpSdk.Message.CqCodeDef;

namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqAnonymousMsgDataModel : CqMsgDataModel
    {
        public static CqAnonymousMsgDataModel FromCqCode(CqCode code)
        {
            return new CqAnonymousMsgDataModel();
        }
    }
}