using EleCho.GoCqHttpSdk.Message.CqCodeDef;

namespace EleCho.GoCqHttpSdk.Message.DataModel;

internal record class CqRpsMsgDataModel : CqMsgDataModel
{
    public static CqRpsMsgDataModel FromCqCode(CqCode code)
    {
        return new CqRpsMsgDataModel();
    }
}