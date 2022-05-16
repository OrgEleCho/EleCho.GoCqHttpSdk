using System;

namespace EleCho.GoCqHttpSdk
{
    public struct CqRHttpSessionOptions
    {
        public Uri BaseUri { get; set; }
        public string? AccessToken { get; set; }
    }
}