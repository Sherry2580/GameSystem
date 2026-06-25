using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.RPG
{
    internal class Backpack
    {
        // 道具使用狀態 (一二三各只能用一次)
        public bool Used_AttackUp;
        public bool Used_DefenseUp;
        public bool Used_AgileUp;
        public bool Has_Drug;           // 是否攜帶藥水 (只能帶一瓶)
        public int Drug_HP;             // 這瓶藥水能補多少血（大中小不同）
        public bool Used_Magic;         // 已經有魔法攻擊了


        // 玩家死掉時，看背包有沒有藥水可以復活
        public int GetDrug()
        {
            if (!Has_Drug)
                return 0;

            Has_Drug = false;   // 藥水用掉了
            return Drug_HP;
        }
    }
}
