using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.PK
{
    internal class PkPlayer : Player
    {
        Random rand = new Random(Guid.NewGuid().GetHashCode());
        public int Attack;  // 攻擊
        public int Defense; // 防禦
        public int Agile;   // 敏捷
        public int HP;      // 血
        // public int Number = 0;

        // 建構子
        public PkPlayer(string name) : base(name)
        {
            // this.Number = number;
            this.HP = 10;
            this.Attack = rand.Next(6, 11);
            this.Defense = rand.Next(6, 11);
            this.Agile = rand.Next(6, 11);
        }
        public override void ShowInformation()
        {
            Console.WriteLine($"參賽者 {Name} 目前有 - 攻擊:{Attack} 防禦:{Defense} 敏捷:{Agile} 血量:{HP}");
        }
        public void PK(PkPlayer defend)
        {
            int finalAttack = Attack - defend.Defense;

            if (finalAttack <= 0)
                finalAttack = 1;
            defend.HP -= finalAttack;

            Console.WriteLine($"{Name} 對 {defend.Name} 造成{finalAttack}點傷害，剩餘血量{defend.HP}");
        }
        // 新一輪需要重置各項血量與能力
        public void Reset()
        {
            this.HP = 10;
            this.Attack = rand.Next(6, 11);
            this.Defense = rand.Next(6, 11);
            this.Agile = rand.Next(6, 11);
        }
    }
}
