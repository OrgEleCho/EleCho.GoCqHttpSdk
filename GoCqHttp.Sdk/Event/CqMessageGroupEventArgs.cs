namespace NullLib.GoCqHttpSdk.Event
{
    public class CqMessageGroupEventArgs : CqMessageEventArgs
    {
        public override CqMessageType MessageType => CqMessageType.Group;

        public long GroupId { get; set; }
        public CqMessageAnonymous? Anonymous { get; set; }

        internal CqMessageGroupEventArgs() { }

        internal override void WriteModel(CqEventModel model)
        {
            base.WriteModel(model);

            if (model is not CqMessageGroupEventModel msgModel)
                return;

            GroupId = msgModel.group_id;
            Anonymous = msgModel.anonymous == null ? null : new CqMessageAnonymous(msgModel.anonymous);
        }

        internal override void ReadModel(CqEventModel model)
        {
            base.ReadModel(model);

            if (model is not CqMessageGroupEventModel msgModel)
                return;

            msgModel.group_id = GroupId;
            msgModel.anonymous = Anonymous == null ? null : new CqMessageAnonymousModel(Anonymous);
        }
    }
}
