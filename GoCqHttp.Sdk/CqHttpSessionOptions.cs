using System;

namespace NullLib.GoCqHttpSdk
{
    public struct CqHttpSessionOptions
    {
        public Uri BaseUri { get; set; }
        
        public string? AccessToken { get; set; }
    }
}
