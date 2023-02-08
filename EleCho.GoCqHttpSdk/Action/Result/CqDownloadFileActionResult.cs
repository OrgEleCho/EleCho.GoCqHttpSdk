using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqDownloadFileActionResult : CqActionResult
    {
        internal CqDownloadFileActionResult()
        {
        }

        public string File { get; private set; } = string.Empty;

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqDownloadFileActionResultDataModel _m)
                throw new Exception();

            File = _m.file;
        }
    }
}