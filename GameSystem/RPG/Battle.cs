using GameSystem.RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.RPG
{
    internal class Battle
    {
        public static int StartBattle(RPGPlayer a, Enemy b)
        {
            // 若玩家敏捷 >= 敵人, 玩家先攻
            bool playerFirst = a.Agile >= b.Agile;

            // 有人沒血量了就停戰
            while (a.HP > 0 && b.HP > 0)
            {
                if (playerFirst)
                {
                    // 玩家先攻
                    a.PK(b);
                    if (b.HP <= 0)
                        break;
                    b.PK(a);
                }
                else
                {
                    // 敵人先攻
                    b.PK(a);
                    if (a.HP <= 0)
                        break;
                    a.PK(b);
                }
            }

            int playerWin = a.HP > 0 ? 1 : 0;
            return playerWin;
        }
    }
}
