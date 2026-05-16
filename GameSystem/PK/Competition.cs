using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.PK
{
    internal abstract class Competition
    {
        // 所有比賽都要實作 StartGame
        public abstract PkPlayer StartGame(List<PkPlayer> players);

        // 單淘汰細節
        protected (PkPlayer champion, List<PkPlayer> losers) SingleGameDetail(List<PkPlayer> players)
        {
            List<PkPlayer> losers = new List<PkPlayer>();
            // 晉級名單
            List<PkPlayer> winners = new List<PkPlayer>();

            // =============== 第一輪算法 =====================
            // 總人數 // 25人
            int totalPlayers = players.Count;
            int powerNum = 1;
            while (powerNum < totalPlayers)
            {
                powerNum *= 2;                  // 2^5 = 32
            }
            // 第一輪輪空數 // 32-25=7
            int restPlayerCount = powerNum - totalPlayers;
            // 第一輪要先打的人數 // 25-7=18
            int firstRoundPlayerCount = totalPlayers - restPlayerCount;

            // 第一輪比賽
            for (int i = 0; i < firstRoundPlayerCount; i += 2)
            {
                PkPlayer a = players[i];
                PkPlayer b = players[i + 1];
                PkPlayer loser = null;
                PkPlayer winner = Battle.StartBattle(a, b);
                if (winner == a)
                {
                    loser = b;
                }
                else
                {
                    loser = a;
                }
                winners.Add(winner);
                losers.Add(loser);
            }
            // 剩下的人第一輪輪空，直接晉級
            for (int i = firstRoundPlayerCount; i < totalPlayers; i++)
            {
                winners.Add(players[i]);
            }
            players = winners;

            // =============== 第二輪開始 =====================
            // 第二輪開始就是正常淘汰賽(有2的倍數次方了)
            while (players.Count > 1)
            {
                winners = new List<PkPlayer>();
                for (int i = 0; i < players.Count; i += 2)
                {
                    PkPlayer a = players[i];
                    PkPlayer b = players[i + 1];
                    PkPlayer loser = null;
                    PkPlayer winner = Battle.StartBattle(a, b);
                    if (winner == a)
                    {
                        loser = b;
                    }
                    else
                    {
                        loser = a;
                    }
                    winners.Add(winner);
                    losers.Add(loser);
                }
                players = winners;
            }
            return (players[0], losers);
        }
    }
}
