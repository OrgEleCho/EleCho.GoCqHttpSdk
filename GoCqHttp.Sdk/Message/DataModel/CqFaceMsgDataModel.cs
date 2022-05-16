using EleCho.GoCqHttpSdk.Message.CqCodeDef;

#pragma warning disable CS8618

namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal class CqFaceMsgDataModel : CqMsgDataModel
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
}