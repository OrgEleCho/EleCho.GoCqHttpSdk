using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetGroupRootFilesActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqGetGroupRootFilesActionResultDataModel(CqGroupFileModel[] files, CqGroupFolderModel[] folders)
        {
            this.files = files;
            this.folders = folders;
        }

        public CqGroupFileModel[] files { get;  }
        public CqGroupFolderModel[] folders { get; }
    }
}
