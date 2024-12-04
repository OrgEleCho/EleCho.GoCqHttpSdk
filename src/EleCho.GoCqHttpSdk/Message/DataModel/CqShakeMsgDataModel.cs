namespace EleCho.GoCqHttpSdk.Message.DataModel;

internal record class CqShakeMsgDataModel : CqMsgDataModel
{
    public static CqShakeMsgDataModel FromCqCode(CqCode code)
    {
        return new CqShakeMsgDataModel();
    }
}