using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.PK.Competitions
{
    internal class NormalGame : Competition
    {
        public override PkPlayer StartGame(List<PkPlayer> players)
        {
            return Battle.StartBattle(players[0], players[1]);
        }
    }
}
