namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    public class CqXmlMsgDataModel
    {
        public string data { get; set; }
        public string resid { get; set; }

        internal CqXmlMsgDataModel() { }
        public CqXmlMsgDataModel(string data, string resid)
        {
            this.data = data;
            this.resid = resid;
        }
    }
}
