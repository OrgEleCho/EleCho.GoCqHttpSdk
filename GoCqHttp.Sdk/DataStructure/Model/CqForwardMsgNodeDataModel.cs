using EleCho.GoCqHttpSdk.Message;
using EleCho.GoCqHttpSdk.Message.DataModel;
using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Model
{
    internal class CqForwardMsgNodeDataModel : CqMsgDataModel
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

        public long? id { get; set; }
        public string? name { get; set; }
        public long? uin { get; set; }
        public CqMsgModel[]? content { get; set; }
        public CqMsgModel[]? seq { get; set; }

        public static CqForwardMsgDataModel FromCqCode(CqCode code)
        {
            return new CqForwardMsgDataModel();
        }
    }
}