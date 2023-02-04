using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetGroupListActionResult : CqActionResult
    {
        internal CqGetGroupListActionResult() { }

        public IReadOnlyList<CqGroup> Groups { get; private set; } = new List<CqGroup>(0).AsReadOnly();

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetGroupListActionResultDataModel m)
                throw new ArgumentException();

            Groups = m.Select(fm => new CqGroup(fm)).ToList().AsReadOnly();
        }
    }
}
