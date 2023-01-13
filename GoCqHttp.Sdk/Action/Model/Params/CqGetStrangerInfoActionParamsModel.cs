﻿namespace EleCho.GoCqHttpSdk.Action.Model.Params
{
    internal class CqGetStrangerInfoActionParamsModel : CqActionParamsModel
    {
        public CqGetStrangerInfoActionParamsModel(long user_id, bool no_cache)
        {
            this.user_id = user_id;
            this.no_cache = no_cache;
        }

        public long user_id { get; set; }
        public bool no_cache { get; set; }
    }
}