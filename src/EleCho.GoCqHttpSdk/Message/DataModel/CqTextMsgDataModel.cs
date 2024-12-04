#pragma warning disable CS8618

namespace EleCho.GoCqHttpSdk.Message.DataModel;

internal record class CqTextMsgDataModel : CqMsgDataModel
{
    public string text { get; set; }

    public CqTextMsgDataModel()
    { }

    public CqTextMsgDataModel(string text)
    {
        this.text = text;
    }

    public static CqTextMsgDataModel FromCqCode(CqCode code)
    {
        return new CqTextMsgDataModel(
            code.GetString(nameof(text))!);
    }
}