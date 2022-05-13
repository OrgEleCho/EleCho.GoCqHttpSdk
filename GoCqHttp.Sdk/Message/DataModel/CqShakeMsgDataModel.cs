using NullLib.GoCqHttpSdk.Message.CqCodeDef;

namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqShakeMsgDataModel : CqMsgDataModel
    {
        public static CqShakeMsgDataModel FromCqCode(CqCode code)
        {
            return new CqShakeMsgDataModel();
        }
    }
}