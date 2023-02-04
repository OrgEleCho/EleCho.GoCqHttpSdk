 using System;

namespace EleCho.GoCqHttpSdk
{
    public struct CqHttpSessionOptions
    {
        public Uri BaseUri { get; set; }

        public string? AccessToken { get; set; }
    }
}