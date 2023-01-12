#pragma warning disable CS8618


namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal class CqAnonymousMsgDataModel : CqMsgDataModel
    {
        public static CqAnonymousMsgDataModel FromCqCode(CqCode code)
        {
            return new CqAnonymousMsgDataModel();
        }
    }
}