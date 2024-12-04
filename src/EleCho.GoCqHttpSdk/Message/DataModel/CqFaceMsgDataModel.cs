using EleCho.GoCqHttpSdk.Message.CqCodeDef;

namespace EleCho.GoCqHttpSdk.Message.DataModel;

internal record class CqFaceMsgDataModel : CqMsgDataModel
{
    public CqFaceMsgDataModel()
    {
    }

    public CqFaceMsgDataModel(int id) => this.id = id;

    public int id { get; set; }

    public static CqFaceMsgDataModel FromCqCode(CqCode code)
    {
        return new CqFaceMsgDataModel(code.GetInt(nameof(id)).GetValueOrDefault(0));
    }
}