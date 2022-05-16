using EleCho.GoCqHttpSdk.Message.CqCodeDef;

#pragma warning disable CS8618

namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal class CqPokeMsgDataModel : CqMsgDataModel
    {
        public long qq { get; set; }

        internal CqPokeMsgDataModel()
        { }

        public CqPokeMsgDataModel(long qq) => this.qq = qq;

        public static CqPokeMsgDataModel FromCqCode(CqCode code)
        {
            return new CqPokeMsgDataModel(
                code.GetLong(nameof(qq)).GetValueOrDefault(0));
        }
    }
}