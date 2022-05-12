namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    public class CqPokeMsgDataModel
    {
        public long qq { get; set; }

        internal CqPokeMsgDataModel() { }
        public CqPokeMsgDataModel(long qq) => this.qq = qq;
    }
}
