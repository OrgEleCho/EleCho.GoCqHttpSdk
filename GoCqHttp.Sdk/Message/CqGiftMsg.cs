using NullLib.GoCqHttpSdk.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk.Message
{
    public class CqGiftMsg : CqMsg
    {
        public override string Type => Consts.MsgType.Gift;

        internal CqGiftMsg() { }
        public CqGiftMsg(long qq, CqGiftId id)
        {
            QQ = qq;
            Id = id;
        }

        public long QQ { get; set; }
        public CqGiftId Id { get; set; }

        internal override CqMsgModel GetModel() => new CqMsgModel(Type, new CqGiftDataModel(QQ, (int)Id));
        internal override void ReadDataModel(object model)
        {
            var m = model as CqGiftDataModel;
            if (m == null)
                throw new ArgumentException();

            QQ = m.qq;
            Id = (CqGiftId)m.id;
        }
    }

    public enum CqGiftId
    {
        /// <summary>
        /// 甜 Wink
        /// </summary>
        SweetWink = 0,
        /// <summary>
        /// 快乐肥宅水
        /// </summary>
        HappyCola = 1,
        /// <summary>
        /// 幸运手链
        /// </summary>
        LuckyHandCatenary = 2,
        /// <summary>
        /// 卡布奇诺
        /// </summary>
        Cappuccino = 3,
        /// <summary>
        /// 猫咪手表
        /// </summary>
        MeowWatch = 4,
        /// <summary>
        /// 绒绒手套
        /// </summary>
        FuzzyGloves = 5,
        /// <summary>
        /// 彩虹糖果
        /// </summary>
        RainbowCandy = 6,
        /// <summary>
        /// 坚强
        /// </summary>
        Strong = 7,
        /// <summary>
        /// 告白话筒
        /// </summary>
        ConfessionsMicrophone = 8,
        /// <summary>
        /// 牵你的手
        /// </summary>
        HandInYourHand = 9,
        /// <summary>
        /// 可爱猫咪
        /// </summary>
        CuteCat = 10,
        /// <summary>
        /// 神秘面具
        /// </summary>
        MysteriousMask = 11,
        /// <summary>
        /// 我超忙的
        /// </summary>
        IAmSuperBusy = 12,
        /// <summary>
        /// 爱心口罩
        /// </summary>
        LoveMask = 13
    }

    internal class CqGiftDataModel
    {
        public CqGiftDataModel() { }
        public CqGiftDataModel(long qq, int id)
        {
            this.qq = qq;
            this.id = id;
        }

        public long qq { get; set; }
        public int id { get; set; }
    }
}
