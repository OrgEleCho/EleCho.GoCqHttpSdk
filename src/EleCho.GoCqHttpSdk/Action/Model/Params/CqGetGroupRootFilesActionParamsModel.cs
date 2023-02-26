#pragma warning disable IDE1006 // Naming Styles


namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetGroupRootFilesActionParamsModel : CqActionParamsModel
    {
        public CqGetGroupRootFilesActionParamsModel(long group_id)
        {
            this.group_id = group_id;
        }

        public long group_id { get; }
    }
}