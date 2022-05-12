namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    public class CqTextMsgDataModel
    {
        public string text { get; set; }

        internal CqTextMsgDataModel() { }

        public CqTextMsgDataModel(string text) => this.text = text;
    }
}
