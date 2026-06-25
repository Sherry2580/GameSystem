using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.RPG.Skills
{
    internal class FireAttack : MagicAttack
    {
        // 火焰攻擊：無視防禦，固定讓對方 HP-4
        public override int DoAttack(int finalAttack)
        {
            finalAttack = 4;
            Console.WriteLine($"使用火焰攻擊，造成{finalAttack}點傷害");
            return finalAttack;
        }
    }
}
