namespace NullLib.GoCqHttpSdk.Post
{
    internal class CqMessageSenderModel
    {
        public CqMessageSenderModel() { }
        public CqMessageSenderModel(CqMessageSender srcData)
        {
            user_id = srcData.UserId;
            nickname = srcData.Nickname;
            sex = srcData.Sex;
            age = srcData.Age;
        }
        public long user_id { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
    }
}
