using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetModelShowActionResult : CqActionResult
    {
        internal CqGetModelShowActionResult()
        {
            Variants = Array.Empty<CqModelShowVariant>();
        }

        public CqModelShowVariant[] Variants { get; private set; }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetModelShowActionResultDataModel _m)
                throw new Exception();

            Variants = Array.ConvertAll(_m.variants, variantmodel => new CqModelShowVariant(variantmodel));
        }
    }
}