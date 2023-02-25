using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    public record class CqGetGroupFileUrlActionResult : CqActionResult
    {
        internal CqGetGroupFileUrlActionResult() { }

        public string Url { get; private set; } = string.Empty;

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetGroupFileUrlActionResultDataModel _m)
                throw new InvalidOperationException();

            Url = _m.url;
        }
    }
}