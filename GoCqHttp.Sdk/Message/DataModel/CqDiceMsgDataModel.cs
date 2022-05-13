#pragma warning disable CS8618

using NullLib.GoCqHttpSdk.Message.CqCodeDef;

namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqDiceMsgDataModel : CqMsgDataModel
    {
        public static CqDiceMsgDataModel FromCqCode(CqCode code)
        {
            return new CqDiceMsgDataModel();
        }
    }
}