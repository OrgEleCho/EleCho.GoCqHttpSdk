using System;
using EleCho.GoCqHttpSdk.Action.Model.ResultData;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 判断能发送语音操作结果
    /// </summary>
    public class CqCanSendRecordActionResult : CqActionResult
    {
        internal CqCanSendRecordActionResult()
        { }

        /// <summary>
        /// 是否
        /// </summary>
        public bool Yes { get; private set; }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqCanSendRecordActionResultDataModel _m)
                throw new Exception();

            Yes = _m.yes;
        }
    }
}