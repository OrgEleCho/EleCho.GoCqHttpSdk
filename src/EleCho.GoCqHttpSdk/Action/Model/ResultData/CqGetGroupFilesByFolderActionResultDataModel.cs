using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData
{
    internal class CqGetGroupFilesByFolderActionResultDataModel : CqActionResultDataModel
    {
        [JsonConstructor]
        public CqGetGroupFilesByFolderActionResultDataModel(CqGroupFileModel[] files, CqGroupFolderModel[] folders)
        {
            this.files = files;
            this.folders = folders;
        }

        public CqGroupFileModel[] files { get; }
        public CqGroupFolderModel[] folders { get; }
    }
}
