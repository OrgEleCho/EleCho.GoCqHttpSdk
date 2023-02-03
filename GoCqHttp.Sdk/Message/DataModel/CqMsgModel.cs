#pragma warning disable CS8618
#pragma warning disable IDE1006

namespace EleCho.GoCqHttpSdk.Message.DataModel
{
    internal record class CqMsgModel
    {
        public CqMsgModel(string type, CqMsgDataModel? data)
        {
            this.type = type;
            this.data = data;
        }

        public string type { get; set; }
        public CqMsgDataModel? data { get; set; }
    }

    internal record class CqMsgModel<TData> : CqMsgModel where TData : CqMsgDataModel
    {
        public CqMsgModel(string type, TData? data) : base(type, data)
        {
            this.type = type;
            this.data = data;
        }

        public new TData? data { get => base.data as TData; set => base.data = value; }
    }
}