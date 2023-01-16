using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetStrangerInformationAction : CqAction
    {
        public override CqActionType Type => CqActionType.GetStrangerInformation;

        public long UserId { get; set; }
        public bool NoCache { get; set; }

        public CqGetStrangerInformationAction(long userId, bool noCache)
        {
            UserId = userId;
            NoCache = noCache;
        }

        public CqGetStrangerInformationAction(long userId)
        {
            UserId = userId;
            NoCache = false;
        }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqGetStrangerInformationActionParamsModel(UserId, NoCache);
        }
    }
}