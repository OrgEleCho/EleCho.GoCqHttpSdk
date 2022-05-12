namespace NullLib.GoCqHttpSdk.Message.DataModel
{
    internal class CqFaceMsgDataModel
    {
        public CqFaceMsgDataModel()
        {
        }

        public CqFaceMsgDataModel(int id) => this.id = id;

        public int id { get; set; }
    }
}
