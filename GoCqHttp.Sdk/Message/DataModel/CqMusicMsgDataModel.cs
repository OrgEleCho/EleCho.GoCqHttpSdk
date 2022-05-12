namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    public class CqMusicMsgDataModel
    {
        internal CqMusicMsgDataModel() { }
        public CqMusicMsgDataModel(string type, long id)
        {
            this.type = type;
            this.id = id;
        }

        public string type { get; set; }
        public long id { get; set; }
    }
}
