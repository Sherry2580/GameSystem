using GameSystem.RPG.Characters;
using GameSystem.RPG.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.RPG
{
    internal class RPGPlayer : Character
    {
        public Backpack Backpack = new Backpack();

        // 建構子
        public RPGPlayer(string playerName)
        {
            this.Name = playerName;
            this.HP = 10;
            this.Attack = 5;
            this.Defense = 5;
            this.Agile = 5;
        }
        public void UseDrug()
        {
            int healHP = Backpack.GetDrug();
            if (healHP > 0)
            {
                this.HP += healHP;
                Console.WriteLine($"{Name}有一瓶 HP{healHP} 的藥水！HP補到{HP}");

            }
        }
        public void DecideAttack()
        {
            if (Backpack.Used_Magic == false)
            {
                currentAttack = AttackType.Physical;
            }
            else
            {
                Console.WriteLine("現在可以選擇攻擊為: 1. 物理攻擊 2. 冰凍攻擊 3. 火焰攻擊");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                    currentAttack = AttackType.Physical;
                else if (choice == 2)
                    currentAttack = AttackType.Ice;
                else
                    currentAttack = AttackType.Fire;
            }
        }

        // 新一關需要重置各項血量與能力
        public override void Reset()
        {
            this.HP = 10;
        }
    }
}
