using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.RPG.Skills
{
    internal class IceAttack : MagicAttack
    {
        // 冰凍攻擊：無視防禦，固定讓對方 HP-3
        public override int DoAttack(int finalAttack)
        {
            finalAttack = 3;
            Console.WriteLine($"使用冰凍攻擊，造成{finalAttack}點傷害");
            return finalAttack;
        }
    }
}
