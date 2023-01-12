using EleCho.GoCqHttpSdk.DataStructure;


namespace EleCho.GoCqHttpSdk.Post
{

    internal class CqGroupMsgSenderModel : CqMsgSenderModel
    {
        public CqGroupMsgSenderModel()
        { }

        public CqGroupMsgSenderModel(CqGroupMsgSender srcData) : base(srcData)
        {
            role = CqEnum.GetString(srcData.Role) ?? string.Empty;
            card = srcData.Card;
            area = srcData.Area;
            level = srcData.Level;
            title = srcData.Title;
        }

        public string role { get; set; }
        public string card { get; set; }
        public string area { get; set; }
        public string level { get; set; }
        public string title { get; set; }
    }
}