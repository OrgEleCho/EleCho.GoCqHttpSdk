using System.Text.Json.Serialization;

namespace EleCho.GoCqHttpSdk.Action.Model.ResultData;

[method: JsonConstructor]
internal class CqGetStrangerInformationActionResultDataModel(long user_id, string nickname, string sex, int age, string qid, int level, int login_days) : CqActionResultDataModel
{

    //QQ 号
    public long user_id { get; } = user_id;
    //昵称
    public string nickname { get; } = nickname;
    //性别, male 或 female 或 unknown
    public string sex { get; } = sex;
    //年龄
    public int age { get; } = age;
    //qid ID身份卡
    public string qid { get; } = qid;
    //等级
    public int level { get; } = level;
    //等级
    public int login_days { get; } = login_days;


}
