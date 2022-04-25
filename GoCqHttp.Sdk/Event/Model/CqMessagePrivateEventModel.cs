namespace NullLib.GoCqHttpSdk.Event
{
    internal class CqMessagePrivateEventModel : CqMessageEventModel
    {
        public override string message_type => "private";

        /// <summary>
        /// <see cref="CqTempSourceType"/>
        /// </summary>
        public string temp_source { get; set; }
    }
}
