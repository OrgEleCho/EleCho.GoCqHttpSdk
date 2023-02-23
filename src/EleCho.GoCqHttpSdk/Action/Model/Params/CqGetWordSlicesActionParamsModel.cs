#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetWordSlicesActionParamsModel : CqActionParamsModel
    {
        public CqGetWordSlicesActionParamsModel(string content)
        {
            this.content = content;
        }

        public string content { get; } 
    }
}