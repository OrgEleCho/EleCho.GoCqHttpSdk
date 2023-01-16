namespace EleCho.GoCqHttpSdk.Post
{
    public class CqFriendRequestPostQuickOperation : CqPostQuickOperation
    {
        public bool? Approve { get; set; }
        public string? Remark { get; set; }

        public override object? GetModel()
        {
            return new
            {
                approve = Approve,
                remark = Remark
            };
        }
    }
}