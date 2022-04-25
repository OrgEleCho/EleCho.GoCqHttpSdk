namespace NullLib.GoCqHttpSdk.Event
{
    public class CqRequestFriendEventArgs : CqRequestEventArgs
    {
        public override CqRequestType RequestType => CqRequestType.Friend;

        public long UserId { get; set; }
        public string Comment { get; set; }
        public string Flag { get; set; }

        internal CqRequestFriendEventArgs() { }

        internal override void ReadModel(CqEventModel model)
        {
            base.ReadModel(model);

            if (model is not CqRequestFriendEventModel requestModel)
                return;

            UserId = requestModel.user_id;
            Comment = requestModel.comment;
            Flag = requestModel.flag;
        }

        internal override void WriteModel(CqEventModel model)
        {
            base.WriteModel(model);

            if (model is not CqRequestFriendEventModel requestModel)
                return;

            requestModel.user_id = UserId;
            requestModel.comment = Comment;
            requestModel.flag = Flag;
        }
    }
}
