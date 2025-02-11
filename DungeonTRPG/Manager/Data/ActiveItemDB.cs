﻿using DungeonTRPG.EntitySystem.ActiveEffect;
using DungeonTRPG.Interface;
using DungeonTRPG.Items;
using DungeonTRPG.Utility.Enums;
using Newtonsoft.Json;

namespace DungeonTRPG.Manager.Data
{
    internal class ActiveItemDB
    {
        [JsonProperty]
        public Dictionary<int, ActiveItem> Items { get; } = new Dictionary<int, ActiveItem>()
        {
            { 1000, new ActiveItem("체력 물약", "사용시 체력을 10 회복한다.", new List<Job>{ Job.None }, new List<IEffect>(){ new HpRecovery(10) }, UseableIn.Both) },
            { 1001, new ActiveItem("체력 물약", "사용시 체력을 50 회복한다.", new List <Job> { Job.None }, new List<IEffect>(){ new HpRecovery(50) }, UseableIn.Both) },
            { 1002, new ActiveItem("체력 물약", "사용시 체력을 100 회복한다.", new List <Job> { Job.None }, new List<IEffect>(){ new HpRecovery(100) }, UseableIn.Both) },
            { 1003, new ActiveItem("체력 물약", "사용시 체력을 200 회복한다.", new List <Job> { Job.None }, new List<IEffect>(){ new HpRecovery(200) }, UseableIn.Both) },
            { 1004, new ActiveItem("체력 물약", "사용시 체력을 전부 회복한다.", new List <Job> { Job.None }, new List<IEffect>(){ new HpRecovery(9999999) }, UseableIn.OnlyCombat) },
            { 1005, new ActiveItem("마나 물약", "사용시 마나를 10 회복한다.", new List <Job> { Job.None }, new List<IEffect>(){ new MpRecovery(10) }, UseableIn.Both) },
            { 1006, new ActiveItem("마나 물약", "사용시 마나를 50 회복한다.", new List <Job> { Job.None }, new List<IEffect>(){ new MpRecovery(50) }, UseableIn.Both) },
            { 1007, new ActiveItem("마나 물약", "사용시 마나를 100 회복한다.", new List <Job> { Job.None }, new List<IEffect>(){ new MpRecovery(100) }, UseableIn.Both) },
            { 1008, new ActiveItem("마나 물약", "사용시 마나를 200 회복한다.", new List <Job> { Job.None }, new List<IEffect>(){ new MpRecovery(200) }, UseableIn.Both) },
            { 1009, new ActiveItem("마나 물약", "사용시 마나를 전부 회복한다.", new List <Job> { Job.None }, new List<IEffect>(){ new MpRecovery(9999999) }, UseableIn.OnlyCombat) },
            { 1010, new ActiveItem("돌맹이", "적에게 던져 데미지를 입힌다.", new List <Job> { Job.None }, new List<IEffect>(){ new HpDamageFixed(10) }, UseableIn.OnlyCombat) },
            { 1011, new ActiveItem("단검", "적에게 던져 데미지를 입힌다.", new List <Job> { Job.None }, new List<IEffect>(){ new HpDamageFixed(30) }, UseableIn.OnlyCombat) },
            { 1012, new ActiveItem("화염병", "적에게 던져 주변 모두에게 데미지를 입힌다.", new List <Job> { Job.None }, new List<IEffect>(){ new RecklessCharge(50) }, UseableIn.OnlyCombat) },
            { 1013, new ActiveItem("폭탄", "폭팔시켜 주변 모두에게 데미지를 입힌다.", new List <Job> { Job.None }, new List<IEffect>(){ new RecklessCharge(100) }, UseableIn.OnlyCombat) },
            { 1014, new ActiveItem("나무로 만든 창", "적에게 던져 데미지를 입힌다.", new List <Job> { Job.Warrior }, new List<IEffect>(){ new HpDownWithATK(50, 1.0f) }, UseableIn.OnlyCombat) },
            { 1015, new ActiveItem("돌로 만든 창", "적에게 던져 데미지를 입힌다.", new List <Job> { Job.Warrior }, new List<IEffect>(){ new HpDownWithATK(70, 1.0f) }, UseableIn.OnlyCombat) },
            { 1016, new ActiveItem("철로 만든 창", "적에게 던져 데미지를 입힌다.", new List <Job> { Job.Warrior }, new List<IEffect>(){ new HpDownWithATK(100, 1.0f) }, UseableIn.OnlyCombat) },
            { 1017, new ActiveItem("고통의 물약 I", "적에게 던져 데미지를 입힌다.", new List <Job> { Job.Mage }, new List<IEffect>(){ new HpDownWithATK(50, 1.0f) }, UseableIn.OnlyCombat) },
            { 1018, new ActiveItem("고통의 물약 II", "적에게 던져 데미지를 입힌다.", new List <Job> { Job.Mage }, new List<IEffect>(){ new HpDownWithATK(70, 1.0f) }, UseableIn.OnlyCombat) },
            { 1019, new ActiveItem("고통의 물약 III", "적에게 던져 데미지를 입힌다.", new List <Job> { Job.Mage }, new List<IEffect>(){ new HpDownWithATK(100, 1.0f) }, UseableIn.OnlyCombat) },
            { 1020, new ActiveItem("불화살", "적에게 쏴 데미지를 입힌다.", new List <Job> { Job.Archer }, new List<IEffect>(){ new HpDownWithATK(50, 1.0f) }, UseableIn.OnlyCombat) },
            { 1021, new ActiveItem("폭팔형 화살", "적에게 쏴 데미지를 입힌다.", new List <Job> { Job.Archer }, new List<IEffect>(){ new HpDownWithATK(70, 1.0f) }, UseableIn.OnlyCombat) },
            { 1022, new ActiveItem("고대 화살", "적에게 쏴 데미지를 입힌다.", new List <Job> { Job.Archer }, new List<IEffect>(){ new HpDownWithATK(100, 1.0f) }, UseableIn.OnlyCombat) },
            { 1023, new ActiveItem("번개의 돌", "번개를 불러와 적에게 데미지를 입히고 일정 확률로 움직이지 못하게 한다.", new List <Job> { Job.None }, new List<IEffect>(){ new StunningBlow(30) }, UseableIn.OnlyCombat) },           
        };

        public ActiveItem GetByKey(int key)
        {
            if (Items.ContainsKey(key))
            {
                return Items[key];
            }
            return null;
        }
    }
}
