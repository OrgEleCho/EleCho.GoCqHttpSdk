using NullLib.GoCqHttpSdk.Message.CqCodeDef;

#pragma warning disable CS8618

namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqAtMsgDataModel : CqMsgDataModel
    {
        public CqAtMsgDataModel()
        {
        }

        public CqAtMsgDataModel(string qq, string? name)
        {
            this.qq = qq;
            this.name = name;
        }

        public string qq { get; set; }
        public string? name { get; set; }

        public static CqAtMsgDataModel FromCqCode(CqCode code)
        {
            return new CqAtMsgDataModel(
                code.GetString(nameof(qq))!,
                code.GetString(nameof(name)));
        }
    }
}