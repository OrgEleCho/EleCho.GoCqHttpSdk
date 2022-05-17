using EleCho.GoCqHttpSdk.DataStructure;

namespace EleCho.GoCqHttpSdk.Post
{
    internal class CqMsgAnonymousModel
    {
        public CqMsgAnonymousModel()
        { }

        public CqMsgAnonymousModel(CqMsgAnonymous srcData)
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