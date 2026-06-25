using GameSystem.RPG.Enums;
using GameSystem.RPG.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.RPG.Characters
{
    internal abstract class Character
    {
        protected Random rand = new Random(Guid.NewGuid().GetHashCode());
        public int Attack;  // 攻擊
        public int Defense; // 防禦
        public int Agile;   // 敏捷
        public int HP;      // 血
        public string Name; // 名字

        // 目前使用的攻擊種類(預設是物理攻擊)
        public AttackType currentAttack = AttackType.Physical;

        public void PK(Character defender)
        {
            // 閃避判定：對方敏捷每比攻擊者高 1, 多 10% 閃避, 上限 50%
            if (defender.Agile - Agile > 0)
            {
                int runChance = (defender.Agile - Agile) * 10;
                if (runChance > 50)
                    runChance = 50;

                if (rand.Next(1, 101) <= runChance)
                {
                    Console.WriteLine($"{defender.Name}閃避了{Name}的攻擊！");
                    return; //此次不pk了
                }
            }

            int finalAttack = Attack - defender.Defense;
            // 玩家可以決定這次要用哪種攻擊模式
            if (this is RPGPlayer p)
            {
                p.DecideAttack();
            }
            // 透過工廠拿到這次決定要使用的攻擊方式
            Skill skill = AttackFactory.CreateSkill(currentAttack);
            finalAttack = skill.DoAttack(finalAttack);
            defender.HP -= finalAttack;
            Console.WriteLine($"{Name}對{defender.Name}使用攻擊，{defender.Name}剩餘血量{defender.HP}");

            // 死亡時玩家檢查背包裡是否有藥水可以用
            if (defender is RPGPlayer player && player.HP <= 0)
            {
                player.UseDrug();
            }
        }
        public void ShowInformation()
        {
            Console.WriteLine($"{Name}目前有 - 攻擊:{Attack} 防禦:{Defense} 敏捷:{Agile} 血量:{HP}");
        }

        public abstract void Reset();
    }
}
