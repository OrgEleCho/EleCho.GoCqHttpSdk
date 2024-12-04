namespace EleCho.GoCqHttpSdk.Message.DataModel;

internal record class CqLocationMsgDataModel : CqMsgDataModel
{
    public CqLocationMsgDataModel()
    { }

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

    public static CqLocationMsgDataModel FromCqCode(CqCode code)
    {
        return new CqLocationMsgDataModel(
            code.GetDouble(nameof(lat)).GetValueOrDefault(0),
            code.GetDouble(nameof(lon)).GetValueOrDefault(0),
            code.GetString(nameof(title)),
            code.GetString(nameof(content)));
    }
}