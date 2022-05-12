namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    public class CqRedEnvelopeMsgDataModel
    {
        public string title { get; set; }
        internal CqRedEnvelopeMsgDataModel() { }

        public CqRedEnvelopeMsgDataModel(string title) => this.title = title;
    }
}
