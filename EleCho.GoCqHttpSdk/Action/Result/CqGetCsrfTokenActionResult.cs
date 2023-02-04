using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetCsrfTokenActionResult : CqActionResult
    {
        internal CqGetCsrfTokenActionResult()
        {
        }

        public int Token { get; private set; }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetCsrfTokenActionResultDataModel _m)
                throw new Exception();

            Token = _m.token;
        }
    }
}