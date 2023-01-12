namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal class CqRpsMsgDataModel : CqMsgDataModel
    {
        public static CqRpsMsgDataModel FromCqCode(CqCode code)
        {
            return new CqRpsMsgDataModel();
        }
    }
}