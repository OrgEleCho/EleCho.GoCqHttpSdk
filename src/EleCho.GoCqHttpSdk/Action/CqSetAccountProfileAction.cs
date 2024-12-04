using EleCho.GoCqHttpSdk.Action.Model.Params;

namespace EleCho.GoCqHttpSdk.Action;

/// <summary>
/// 设置账户信息
/// </summary>
/// <remarks>
/// 实例化对象
/// </remarks>
/// <param name="nickname">昵称</param>
/// <param name="company">公司</param>
/// <param name="eMail">邮箱</param>
/// <param name="college">大学</param>
/// <param name="personalNote">个性签名</param>
public class CqSetAccountProfileAction(string nickname, string company, string eMail, string college, string personalNote) : CqAction
{

    /// <summary>
    /// 操作类型
    /// </summary>
    public override CqActionType ActionType => CqActionType.SetAccountProfile;

    /// <summary>
    /// 昵称
    /// </summary>
    public string Nickname { get; set; } = nickname;

    /// <summary>
    /// 公司
    /// </summary>
    public string Company { get; set; } = company;

    /// <summary>
    /// 电子邮箱
    /// </summary>
    public string EMail { get; set; } = eMail;

    /// <summary>
    /// 大学
    /// </summary>
    public string College { get; set; } = college;

    /// <summary>
    /// 个性签名
    /// </summary>
    public string PersonalNote { get; set; } = personalNote;

    internal override CqActionParamsModel GetParamsModel()
    {
        return new CqSetAccountProfileActionParamsModel(Nickname, Company, EMail, College, PersonalNote);
    }
}
