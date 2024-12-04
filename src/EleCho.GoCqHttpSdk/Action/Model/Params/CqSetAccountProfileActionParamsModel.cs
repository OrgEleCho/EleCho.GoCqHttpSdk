namespace EleCho.GoCqHttpSdk.Action.Model.Params;

internal class CqSetAccountProfileActionParamsModel(string nickname, string company, string email, string college, string personal_note) : CqActionParamsModel
{
    public string nickname { get; } = nickname;
    public string company { get; } = company;
    public string email { get; } = email;
    public string college { get; } = college;
    public string personal_note { get; } = personal_note;
}
