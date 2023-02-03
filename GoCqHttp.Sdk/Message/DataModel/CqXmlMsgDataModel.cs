#pragma warning disable CS8618


namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal record class CqXmlMsgDataModel : CqMsgDataModel
    {
        public string data { get; set; }
        public string? resid { get; set; }

        public CqXmlMsgDataModel()
        { }

        public CqXmlMsgDataModel(string data, string? resid)
        {
            this.data = data;
            this.resid = resid;
        }

        public static CqXmlMsgDataModel FromCqCode(CqCode code)
        {
            return new CqXmlMsgDataModel(
                code.GetString(nameof(data))!,
                code.GetString(nameof(resid)));
        }
    }
}