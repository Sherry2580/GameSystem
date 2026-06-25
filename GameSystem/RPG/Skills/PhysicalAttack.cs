using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameSystem.RPG.Skills
{
    internal class PhysicalAttack : Skill
    {
        // 物理攻擊：若 finalAttack 少於 0，對方還是扣 1 滴血
        public override int DoAttack(int finalAttack)
        {
            if (finalAttack <= 0)
                finalAttack = 1;
            Console.WriteLine($"使用物理攻擊，造成{finalAttack}點傷害");
            return finalAttack;
        }
    }
}
