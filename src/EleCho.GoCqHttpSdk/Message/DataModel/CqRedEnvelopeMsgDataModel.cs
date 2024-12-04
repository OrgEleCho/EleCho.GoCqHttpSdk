#pragma warning disable CS8618

using EleCho.GoCqHttpSdk.Message.CqCodeDef;

namespace EleCho.GoCqHttpSdk.Message.DataModel;

internal record class CqRedEnvelopeMsgDataModel : CqMsgDataModel
{
    public string title { get; set; }

    public CqRedEnvelopeMsgDataModel()
    { }

    public CqRedEnvelopeMsgDataModel(string title) => this.title = title;

    public static CqRedEnvelopeMsgDataModel FromCqCode(CqCode code)
    {
        return new CqRedEnvelopeMsgDataModel(
            code.GetString(nameof(title))!);
    }
}