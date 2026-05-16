using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.PK.Competitions
{
    internal class SingleGame : Competition
    {
        // 單淘汰
        public override PkPlayer StartGame(List<PkPlayer> players)
        {
            (PkPlayer champion, List<PkPlayer> losers) = SingleGameDetail(players);
            return champion;
        }
    }
}
