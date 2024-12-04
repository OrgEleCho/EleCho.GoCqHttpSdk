using EleCho.GoCqHttpSdk.DataStructure.Model;
using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqGetGroupFilesByFolderActionResultDataModel(CqGroupFileModel[] files, CqGroupFolderModel[] folders) : CqActionResultDataModel
{
    public CqGroupFileModel[] files { get; } = files;
    public CqGroupFolderModel[] folders { get; } = folders;
}
