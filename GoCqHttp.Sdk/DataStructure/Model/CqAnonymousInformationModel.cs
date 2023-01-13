using EleCho.GoCqHttpSdk;
using System.Text.Json.Serialization;

#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Post
{
    internal class CqAnonymousInformationModel
    {
        public CqAnonymousInformationModel(CqAnonymousInfomation srcData)
        {
            id = srcData.Id;
            name = srcData.Name;
            flag = srcData.Flag;
        }

        [JsonConstructor]
        public CqAnonymousInformationModel(long id, string name, string flag)
        {
            this.id = id;
            this.name = name;
            this.flag = flag;
        }

        public long id { get; set; }
        public string name { get; set; }
        public string flag { get; set; }
    }
}