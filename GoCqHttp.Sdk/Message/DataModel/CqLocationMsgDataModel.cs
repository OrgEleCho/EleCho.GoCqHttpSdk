namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    public class CqLocationMsgDataModel
    {
        internal CqLocationMsgDataModel() { }
        public CqLocationMsgDataModel(double lat, double lon, string? title, string? content)
        {
            this.lat = lat;
            this.lon = lon;
            this.title = title;
            this.content = content;
        }

        public double lat { get; set; }
        public double lon { get; set; }
        public string? title { get; set; }
        public string? content { get; set; }
    }
}
