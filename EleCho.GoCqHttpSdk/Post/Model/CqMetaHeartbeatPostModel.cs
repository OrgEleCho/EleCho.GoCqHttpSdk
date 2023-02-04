using EleCho.GoCqHttpSdk.DataStructure.Model;
using EleCho.GoCqHttpSdk.Utils;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE1006 // Naming Styles

namespace EleCho.GoCqHttpSdk.Post.Model
{
    internal class CqMetaHeartbeatPostModel : CqMetaPostModel
    {
        public override string meta_event_type => Consts.MetaEventType.Heartbeat;

        public CqStatusModel status { get; set; }

        /// <summary>
        /// ms
        /// </summary>
        public long interval { get; set; }
    }
}