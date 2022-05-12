namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    public class CqJsonMsgDataModel
    {
        public string data { get; set; }
        public int resid { get; set; }

        internal CqJsonMsgDataModel() { }
        public CqJsonMsgDataModel(string data, int resid)
        {
            this.data = data;
            this.resid = resid;
        }
    }
}
