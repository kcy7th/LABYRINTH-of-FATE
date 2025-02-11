﻿using DungeonTRPG.Entity;
using DungeonTRPG.Interface;

namespace DungeonTRPG.EntitySystem.ActiveEffect
{
    internal class HpDamageATK: IEffect
    {
        float modifier;
        int TotalDamage;
        public HpDamageATK(float modifier)
        {
            this.modifier = modifier;
        }

        //타겟의 Hp가 시전자의 공격력*설정된 값(modifier)만큼 감소하는 효과
        public void UseEffect(Character caster, Character target)
        {
            TotalDamage = (int)(caster.Stat.Atk*modifier);
            target.Damaged(TotalDamage);
        }
    }
}
