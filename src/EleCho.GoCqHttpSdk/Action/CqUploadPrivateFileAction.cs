using EleCho.GoCqHttpSdk.Action.Model.Params;


namespace EleCho.GoCqHttpSdk.Action
{
    public class CqUploadPrivateFileAction : CqAction
    {
        public CqUploadPrivateFileAction(long userId, string file, string name)
        {
            UserId = userId;
            File = file;
            Name = name;
        }

        public override CqActionType ActionType => CqActionType.UploadPrivateFile;

        public long UserId { get; set; }
        public string File { get; set; }
        public string Name { get; set; }

        internal override CqActionParamsModel GetParamsModel()
        {
            return new CqUploadPrivateFileActionParamsModel(UserId, File, Name);
        }
    }
}