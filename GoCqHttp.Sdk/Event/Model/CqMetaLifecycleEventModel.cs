namespace NullLib.GoCqHttpSdk.Event
{
    internal class CqMetaLifecycleEventModel : CqMetaEventModel
    {
        public override string meta_event_type => "lifecycle";
        public string sub_type { get; set; }
    }
}
