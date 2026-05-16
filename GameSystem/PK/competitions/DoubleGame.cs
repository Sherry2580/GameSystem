using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.PK.Competitions
{
    internal class DoubleGame : Competition
    {
        // 雙淘汰
        public override PkPlayer StartGame(List<PkPlayer> players)
        {
            // 打勝部淘汰賽
            Console.WriteLine("勝部開始");
            (PkPlayer winnerChampion, List<PkPlayer> winnerlosers) = SingleGameDetail(players);
            // 敗部單淘汰賽
            Console.WriteLine("敗部開始");
            // 重置血量與能力
            foreach (PkPlayer p in winnerlosers)
            {
                p.Reset();
            }
            (PkPlayer loserChampion, List<PkPlayer> loserlosers) = SingleGameDetail(winnerlosers);
            // 決賽
            Console.WriteLine("總決賽");
            // 重置血量與能力
            winnerChampion.Reset();
            loserChampion.Reset();
            PkPlayer finalChampion = Battle.StartBattle(winnerChampion, loserChampion);
            return finalChampion;
        }
    }
}
