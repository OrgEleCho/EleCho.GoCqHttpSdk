using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetStrangerInfoAction : CqAction
    {
        public override CqActionType Type => CqActionType.GetStrangerInfo;

        public long UserId { get; set; }
        public bool NoCache { get; set; }

        public CqGetStrangerInfoAction(long userId, bool noCache)
        {
            UserId = userId;
            NoCache = noCache;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetStrangerInfoActionParamsModel(UserId, NoCache);
        }
    }
}