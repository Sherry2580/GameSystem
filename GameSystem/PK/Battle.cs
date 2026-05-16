using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.PK
{
    internal class Battle
    {
        public static PkPlayer StartBattle(PkPlayer a, PkPlayer b)
        {
            PkPlayer winner = null;
            // 敏捷高的人先攻, 相同則以名字排序低的人先攻
            (PkPlayer first, PkPlayer second) = b.Name.CompareTo(a.Name) > 1 ? (a, b) : (b, a);
            (first, second) = a.Agile > b.Agile ? (a, b) : (first, second);

            // 有人沒血量了就停戰
            while (a.HP > 0 && b.HP > 0)
            {
                first.PK(second);
                if (second.HP <= 0)
                    break;
                second.PK(first);
            }

            winner = a.HP > 0 ? a : b;
            return winner;
        }
    }
}
