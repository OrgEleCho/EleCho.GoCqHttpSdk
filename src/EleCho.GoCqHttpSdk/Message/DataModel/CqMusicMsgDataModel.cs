#pragma warning disable CS8618

namespace EleCho.GoCqHttpSdk.Message.DataModel;

internal record class CqMusicMsgDataModel : CqMsgDataModel
{
    public CqMusicMsgDataModel()
    { }

    public CqMusicMsgDataModel(string type, long id)
    {
        this.type = type;
        this.id = id;
    }

    public string type { get; set; }
    public long id { get; set; }

    public static CqMusicMsgDataModel FromCqCode(CqCode code)
    {
        return new CqMusicMsgDataModel(
            code.GetString(nameof(type))!,
            code.GetLong(nameof(id)).GetValueOrDefault(0));
    }
}