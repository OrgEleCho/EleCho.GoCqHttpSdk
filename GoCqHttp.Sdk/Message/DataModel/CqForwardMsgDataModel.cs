namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqForwardMsgDataModel
    {
        public string id { get; set; }

        public CqForwardMsgDataModel() { }
        public CqForwardMsgDataModel(string id) => this.id = id;
    }
}
