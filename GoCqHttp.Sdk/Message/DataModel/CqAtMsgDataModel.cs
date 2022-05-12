namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqAtMsgDataModel
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
    }
}
