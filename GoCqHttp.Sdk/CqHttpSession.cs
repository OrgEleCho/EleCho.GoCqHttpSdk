namespace NullLib.GoCqHttpSdk
{
    public class CqHttpSession : ICqActionSession
    {
        public CqActionSender ActionSender { get; }

        public CqHttpSession(CqHttpSessionOptions options)
        {
        }
    }
}