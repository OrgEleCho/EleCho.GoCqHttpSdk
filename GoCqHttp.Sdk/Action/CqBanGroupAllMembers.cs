using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    public class CqBanGroupAllMembersAction : CqAction
    {
        public CqBanGroupAllMembersAction(long groupId, bool enable)
        {
            GroupId = groupId;
            Enable = enable;
        }

        public override CqActionType Type => CqActionType.BanGroupAllMembers;

        public long GroupId { get; set; }
        public bool Enable { get; set; }
        
        
        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqBanGroupAllMembersActionParamsModel(GroupId, Enable);
        }
    }
}