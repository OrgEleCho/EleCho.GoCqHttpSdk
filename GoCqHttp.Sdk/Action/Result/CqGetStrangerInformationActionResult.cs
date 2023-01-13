using EleCho.GoCqHttpSdk.Action.Model.Data;
using System.Security.Cryptography;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetStrangerInformationActionResult : CqActionResult
    {

        //QQ 号
        public long UserId { get; set; }
        //昵称
        public string Nickname { get; set; }
        //性别, male 或 female 或 unknown
        public string Sex { get; set; }
        //年龄
        public int Age { get; set; }
        //qid ID身份卡
        public string Qid { get; set; }
        //等级
        public int Level { get; set; }
        //等级
        public int LoginDays { get; set; }

        internal CqGetStrangerInformationActionResult()
        { }

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