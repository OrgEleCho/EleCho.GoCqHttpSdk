namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqContactMsgDataModel
    {
        public CqContactMsgDataModel()
        {
        }

        public CqContactMsgDataModel(string type, long id)
        {
            this.type = type;
            this.id = id;
        }

        public string type { get; set; }
        public long id { get; set; }
    }
}
