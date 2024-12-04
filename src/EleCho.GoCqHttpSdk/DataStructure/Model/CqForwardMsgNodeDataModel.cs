using EleCho.GoCqHttpSdk.Message.CqCodeDef;
using EleCho.GoCqHttpSdk.Message.DataModel;
using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.DataStructure.Model;

internal record class CqForwardMsgNodeDataModel : CqMsgDataModel
{
    public CqForwardMsgNodeDataModel()
    { }

    [JsonConstructor]
    public CqForwardMsgNodeDataModel(long? id, string? name, long? uin, CqMsgModel[]? content, CqMsgModel[]? seq)
    {
        this.id = id;
        this.name = name;
        this.uin = uin;
        this.content = content;
        this.seq = seq;
    }

    public long? id { get; private set; }
    public string? name { get; private set; }
    public long? uin { get; private set; }
    public CqMsgModel[]? content { get; private set; }
    public CqMsgModel[]? seq { get; private set; }

    public static CqForwardMsgDataModel FromCqCode(CqCode code)
    {
        return new CqForwardMsgDataModel();
    }
}