namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqGiftMsgDataModel
    {
        public CqGiftMsgDataModel() { }
        public CqGiftMsgDataModel(long qq, int id)
        {
            this.qq = qq;
            this.id = id;
        }

        public long qq { get; set; }
        public int id { get; set; }
    }
}
