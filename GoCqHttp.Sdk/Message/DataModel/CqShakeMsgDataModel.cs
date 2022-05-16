using EleCho.GoCqHttpSdk.Message.CqCodeDef;

namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal class CqShakeMsgDataModel : CqMsgDataModel
    {
        public static CqShakeMsgDataModel FromCqCode(CqCode code)
        {
            return new CqShakeMsgDataModel();
        }
    }
}