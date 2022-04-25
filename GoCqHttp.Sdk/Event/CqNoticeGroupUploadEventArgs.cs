namespace NullLib.GoCqHttpSdk.Event
{
    public class CqNoticeGroupUploadEventArgs : CqNoticeEventArgs
    {
        public override CqNoticeType NoticeType => CqNoticeType.GroupUpload;

        public long GroupId { get; set; }
        public long UserId { get; set; }
        public CqGroupUploadFile File { get; set; }

        internal override void WriteModel(CqEventModel model)
        {
            base.WriteModel(model);

            if (model is not CqNoticeGroupUploadEventModel noticeModel)
                return;

            noticeModel.group_id = GroupId;
            noticeModel.user_id = UserId;
            noticeModel.file = new CqGroupUploadFileModel(File);
        }

        internal override void ReadModel(CqEventModel model)
        {
            base.ReadModel(model);

            if (model is not CqNoticeGroupUploadEventModel noticeModel)
                return;

            GroupId = noticeModel.group_id;
            UserId = noticeModel.user_id;
            File = new CqGroupUploadFile(noticeModel.file);
        }
    }
}
