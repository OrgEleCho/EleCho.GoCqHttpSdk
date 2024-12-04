namespace EleCho.GoCqHttpSdk.Post;

/// <summary>
/// 家好友请求上报快速操作
/// </summary>
public class CqFriendRequestPostQuickOperation : CqPostQuickOperation
{
    /// <summary>
    /// 同意
    /// </summary>
    public bool? Approve { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }

    internal override object? GetModel()
    {
        if (Approve != null)
            return null;

        return new
        {
            approve = Approve,
            remark = Remark
        };
    }
}