using GameSystem.RPG.Characters;
using GameSystem.RPG.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.RPG
{
    internal class Shop
    {
        Random rand = new Random(Guid.NewGuid().GetHashCode());

        // 選道具
        public int Open(RPGPlayer player, int round)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"請選擇道具:");
                Console.WriteLine("1. 攻擊+2");
                Console.WriteLine("2. 防禦+2");
                Console.WriteLine("3. 敏捷+2");
                Console.WriteLine("4. 小復活藥水 (補5)");
                Console.WriteLine("5. 中復活藥水 (補10)");
                Console.WriteLine("6. 大復活藥水 (補20)");
                Console.WriteLine("7. 學會法力攻擊");
                Console.WriteLine("8. 隨機跳關 (6~10)");
                Console.Write("請輸入選項: ");

                int choice = int.Parse(Console.ReadLine());

                switch ((ItemType)choice)
                {
                    case ItemType.AttackUp:
                        if (player.Backpack.Used_AttackUp)
                        {
                            Console.WriteLine("此道具已經用過了，請重新選擇");
                            continue;
                        }
                        player.Attack += 2;
                        player.Backpack.Used_AttackUp = true;
                        Console.WriteLine($"攻擊+2，目前攻擊={player.Attack}");
                        return round;

                    case ItemType.DefenseUp:
                        if (player.Backpack.Used_DefenseUp)
                        {
                            Console.WriteLine("此道具已經用過了，請重新選擇");
                            continue;
                        }
                        player.Defense += 2;
                        player.Backpack.Used_DefenseUp = true;
                        Console.WriteLine($"防禦+2，目前防禦={player.Defense}");
                        return round;

                    case ItemType.AgileUp:
                        if (player.Backpack.Used_AgileUp)
                        {
                            Console.WriteLine("此道具已經用過了，請重新選擇");
                            continue;
                        }
                        player.Agile += 2;
                        player.Backpack.Used_AgileUp = true;
                        Console.WriteLine($"敏捷+2，目前敏捷={player.Agile}");
                        return round;

                    case ItemType.SmallDrug:
                        if (player.Backpack.Has_Drug)
                        {
                            Console.WriteLine("你已經有一瓶藥水了，請重新選擇");
                            continue;
                        }
                        player.Backpack.Drug_HP = 5;
                        player.Backpack.Has_Drug = true;
                        Console.WriteLine($"成功攜帶復活藥水（補{player.Backpack.Drug_HP}）");
                        return round;

                    case ItemType.MediumDrug:
                        if (player.Backpack.Has_Drug)
                        {
                            Console.WriteLine("你已經有一瓶藥水了，請重新選擇");
                            continue;
                        }
                        player.Backpack.Drug_HP = 10;
                        player.Backpack.Has_Drug = true;
                        Console.WriteLine($"成功攜帶復活藥水（補{player.Backpack.Drug_HP}）");
                        return round;

                    case ItemType.LargeDrug:
                        if (player.Backpack.Has_Drug)
                        {
                            Console.WriteLine("你已經有一瓶藥水了，請重新選擇");
                            continue;
                        }
                        player.Backpack.Drug_HP = 20;
                        player.Backpack.Has_Drug = true;
                        Console.WriteLine($"成功攜帶復活藥水（補{player.Backpack.Drug_HP}）");
                        return round;

                    case ItemType.Magic:
                        if (player.Backpack.Used_Magic)
                        {
                            Console.WriteLine("已具備法力攻擊能力，請重新選擇");
                            continue;
                        }
                        player.Backpack.Used_Magic = true;
                        Console.WriteLine($"{player.Name}學會了法力攻擊，之後攻擊可以選物理或是法力");
                        return round;

                    case ItemType.Jump:
                        int target = rand.Next(6, 11);
                        Console.WriteLine($"隨機跳關跳到第{target}關");
                        return target;
                }
            }

        }
    }
}
