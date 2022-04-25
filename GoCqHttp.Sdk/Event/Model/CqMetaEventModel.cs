namespace NullLib.GoCqHttpSdk.Event
{
    internal abstract class CqMetaEventModel : CqEventModel
    {
        public override string post_type => "meta_event";
        public abstract string meta_event_type { get; }
    }
}
