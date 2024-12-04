#pragma warning disable CS8618

namespace EleCho.GoCqHttpSdk.Message.DataModel;

internal record class CqShareMsgDataModel : CqMsgDataModel
{
    public CqShareMsgDataModel()
    { }

    public CqShareMsgDataModel(string url, string title, string? content, string? image)
    {
        this.url = url;
        this.title = title;
        this.content = content;
        this.image = image;
    }

    public string url { get; set; }
    public string title { get; set; }
    public string? content { get; set; }
    public string? image { get; set; }

    public static CqShareMsgDataModel FromCqCode(CqCode code)
    {
        return new CqShareMsgDataModel(
            code.GetString(nameof(url))!,
            code.GetString(nameof(title))!,
            code.GetString(nameof(content)),
            code.GetString(nameof(image)));
    }
}