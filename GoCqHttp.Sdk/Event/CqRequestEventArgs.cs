namespace NullLib.GoCqHttpSdk.Event
{
    public abstract class CqRequestEventArgs : CqEventArgs
    {
        public override CqEventType EventType => CqEventType.Request;
        public abstract CqRequestType RequestType { get; }
    }
}
