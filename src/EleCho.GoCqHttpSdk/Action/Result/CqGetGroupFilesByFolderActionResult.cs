using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取群子目录文件列表操作结果
    /// </summary>
    public record class CqGetGroupFilesByFolderActionResult : CqActionResult
    {
        internal CqGetGroupFilesByFolderActionResult() { }

        /// <summary>
        /// 文件列表
        /// </summary>
        public CqGroupFile[] Files { get; private set; } = Array.Empty<CqGroupFile>();

        /// <summary>
        /// 文件夹列表
        /// </summary>
        public CqGroupFolder[] Folders { get; private set; } = Array.Empty<CqGroupFolder>();


        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetGroupFilesByFolderActionResultDataModel _m)
                throw new InvalidOperationException();

            Files = Array.ConvertAll(_m.files, m => new CqGroupFile(m));
            Folders = Array.ConvertAll(_m.folders, m => new CqGroupFolder(m));
        }
    }
}