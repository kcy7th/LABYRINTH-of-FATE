﻿namespace DungeonTRPG.Utility.Enums
{
    public enum State
    {
        None,
        Burn, // 중독: 도트 데미지
        Sleep, // 수면: 턴 패스, 공격시 -> 추가데미지 + 상태 해제
        Poison, // 독: 도트 데미지
        Confusion, // 혼란: 공격 시 미스
        Stun, // 기절: 턴 패스
    }
}
