#pragma warning disable CS8618

using EleCho.GoCqHttpSdk.Message.CqCodeDef;

namespace EleCho.GoCqHttpSdk.Message.DataModel;

internal record class CqCardImageMsgDataModel : CqMsgDataModel
{
    public CqCardImageMsgDataModel()
    { }

    public CqCardImageMsgDataModel(string file, long? minwidth, long? minheight, long? maxwidth, long? maxheight, string? source, string? icon)
    {
        this.file = file;
        this.minwidth = minwidth;
        this.minheight = minheight;
        this.maxwidth = maxwidth;
        this.maxheight = maxheight;
        this.source = source;
        this.icon = icon;
    }

    public string file { get; set; }
    public long? minwidth { get; set; }
    public long? minheight { get; set; }
    public long? maxwidth { get; set; }
    public long? maxheight { get; set; }
    public string? source { get; set; }
    public string? icon { get; set; }

    public static CqCardImageMsgDataModel FromCqCode(CqCode code)
    {
        return new CqCardImageMsgDataModel(
            code.GetString(nameof(file))!,
            code.GetLong(nameof(minwidth)),
            code.GetLong(nameof(minheight)),
            code.GetLong(nameof(maxwidth)),
            code.GetLong(nameof(maxheight)),
            code.GetString(nameof(source)),
            code.GetString(nameof(icon)));
    }
}