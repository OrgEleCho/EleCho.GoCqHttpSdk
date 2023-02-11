using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class CqCheckUrlSafetyActionResult : CqActionResult
    {
        internal CqCheckUrlSafetyActionResult()
        {
        }


        /// <summary>
        /// 安全等级
        /// </summary>
        public CqUrlSafetyLevel Level { get; private set; }
        
        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqCheckUrlSafetyActionResultDataModel _m)
                throw new Exception();

            Level = (CqUrlSafetyLevel)_m.level;
        }
    }
}