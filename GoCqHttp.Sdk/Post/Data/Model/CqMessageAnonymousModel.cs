namespace NullLib.GoCqHttpSdk.Post
{
    internal class CqMessageAnonymousModel
    {
        public CqMessageAnonymousModel() { }
        public CqMessageAnonymousModel(CqMessageAnonymous srcData)
        {
            id = srcData.Id;
            name = srcData.Name;
            flag = srcData.Flag;
        }
        public long id { get; set; }
        public string name { get; set; }
        public string flag { get; set; }
    }
}
