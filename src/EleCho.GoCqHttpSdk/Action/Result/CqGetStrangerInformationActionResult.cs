using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System.Security.Cryptography;

namespace EleCho.GoCqHttpSdk.Action
{
    /// <summary>
    /// 获取陌生人信息操作结果
    /// </summary>
    public record class CqGetStrangerInformationActionResult : CqActionResult
    {

        /// <summary>
        /// QQ 号
        /// </summary>
        public long UserId { get; private set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; private set; } = string.Empty;
        
        /// <summary>
        /// 性别
        /// </summary>
        public CqGender Gender { get; private set; } = CqGender.Unknown;

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; private set; }
        
        /// <summary>
        /// QID
        /// </summary>
        public string Qid { get; private set; } = string.Empty;
        
        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; private set; }
        
        /// <summary>
        /// 登陆天数
        /// </summary>
        public int LoginDays { get; private set; }


        internal CqGetStrangerInformationActionResult() { }

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is CqGetStrangerInformationActionResultDataModel dataModel)
            {
                UserId = dataModel.user_id;
                Nickname = dataModel.nickname;
                Gender = CqEnum.GetGender(dataModel.sex);
                Age = dataModel.age;
                Qid = dataModel.qid;
                Level = dataModel.level;
                LoginDays = dataModel.login_days;

            }
        }
    }
}