using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetGroupFileUrlAction : CqAction
    {
        public CqGetGroupFileUrlAction(long groupId, string fileId, int busid)
        {
            GroupId = groupId;
            FileId = fileId;
            Busid = busid;
        }

        public override CqActionType ActionType => CqActionType.GetGroupFileUrl;

        public long GroupId { get; set; }
        public string FileId { get; set; }
        public int Busid { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetGroupFileUrlActionParamsModel(GroupId, FileId, Busid);
        }
    }
}