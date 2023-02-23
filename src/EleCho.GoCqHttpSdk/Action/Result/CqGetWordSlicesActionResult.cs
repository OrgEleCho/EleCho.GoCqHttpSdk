using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;

namespace EleCho.GoCqHttpSdk.Action
{
    public record class CqGetWordSlicesActionResult : CqActionResult
    {

        internal CqGetWordSlicesActionResult() { }

        public string[] Slices { get; private set; } = Array.Empty<string>();

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetWordSlicesActionResultDataModel _m)
                throw new InvalidOperationException();

            Slices = _m.slices;
        }
    }
}