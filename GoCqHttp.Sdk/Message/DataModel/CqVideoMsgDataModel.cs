namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    public class CqVideoMsgDataModel
    {
        internal CqVideoMsgDataModel() { }
        public CqVideoMsgDataModel(string file, string? cover, int? c)
        {
            this.file = file;
            this.cover = cover;
            this.c = c;
        }

        public string file { get; set; }
        public string? cover { get; set; }
        public int? c { get; set; }
    }
}
