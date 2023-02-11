using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class CqCanSendRecordActionResult : CqActionResult
    {
        internal CqCanSendRecordActionResult()
        { }

        public bool Yes { get; private set; }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqCanSendRecordActionResultDataModel _m)
                throw new Exception();

            Yes = _m.yes;
        }
    }
}