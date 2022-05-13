using System;

namespace NullLib.GoCqHttpSdk
{
    public struct CqWsSessionOptions
    {
        public Uri BaseUri { get; set; }
        public bool UseApiEndPoint { get; set; }
        public bool UseEventEndPoint { get; set; }

        public string? AccessToken { get; set; }
    }
}