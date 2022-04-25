namespace NullLib.GoCqHttpSdk.Message
{
    public class CqMsgModel
    {
        public CqMsgModel(string type, object data)
        {
            this.type = type;
            this.data = data;
        }

        public string type { get; set; }
        public object data { get; set; }
    }

    public class CqMsgModel<TData> : CqMsgModel where TData : class
    {
        public CqMsgModel(string type, TData data) : base(type, data)
        {
            this.type = type;
            this.data = data;
        }

        public string type { get; set; }
        public new TData data { get => (base.data as TData)!; set => base.data = value; }
    }
}
