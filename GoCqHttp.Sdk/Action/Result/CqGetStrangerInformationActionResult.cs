using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System.Security.Cryptography;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetStrangerInformationActionResult : CqActionResult
    {

        //QQ 号
        public long UserId { get; private set; }
        //昵称
        public string Nickname { get; private set; } = string.Empty;
        //性别, male 或 female 或 unknown
        public string Sex { get; private set; } = string.Empty;
        //年龄
        public int Age { get; private set; }
        //qid ID身份卡
        public string Qid { get; private set; } = string.Empty;
        //等级
        public int Level { get; private set; }
        //等级
        public int LoginDays { get; private set; }


        internal CqGetStrangerInformationActionResult() { }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is CqGetStrangerInformationActionResultDataModel dataModel)
            {
                UserId = dataModel.user_id;
                Nickname = dataModel.nickname;
                Sex = dataModel.sex;
                Age = dataModel.age;
                Qid = dataModel.qid;
                Level = dataModel.level;
                LoginDays = dataModel.login_days;

            }
        }
    }
}