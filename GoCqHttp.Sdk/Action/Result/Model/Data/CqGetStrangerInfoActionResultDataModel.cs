using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.Action.Model.Data
{
    internal class CqGetStrangerInfoActionResultDataModel : CqActionResultDataModel
    {
        public CqGetStrangerInfoActionResultDataModel(long user_id, string nickname, string sex, int age, string qid, int level, int login_days)
        {
            this.user_id = user_id;
            this.nickname = nickname;
            this.sex = sex;
            this.age = age;
            this.qid = qid;
            this.level = level;
            this.login_days = login_days;
        }

        //QQ 号
        public long user_id { get; set; }
        //昵称
        public string nickname { get; set; }
        //性别, male 或 female 或 unknown
        public string sex { get; set; }
        //年龄
        public int age { get; set; }
        //qid ID身份卡
        public string qid { get; set; }
        //等级
        public int level { get; set; }
        //等级
        public int login_days { get; set; }


    }
}
