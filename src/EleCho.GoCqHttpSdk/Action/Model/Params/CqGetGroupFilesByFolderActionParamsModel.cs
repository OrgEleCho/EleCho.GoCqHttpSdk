#pragma warning disable IDE1006 // Naming Styles


namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetGroupFilesByFolderActionParamsModel : CqActionParamsModel
    {
        public CqGetGroupFilesByFolderActionParamsModel(long group_id, string folder_id)
        {
            this.group_id = group_id;
            this.folder_id = folder_id;
        }

        public long group_id { get; }
        public string folder_id { get; }
    }
}