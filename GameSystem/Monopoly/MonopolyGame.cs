using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.Monopoly
{
    internal class MonopolyGame : GameMode
    {
        // 建構子
        public MonopolyGame(List<string> players) : base(players)
        {
        }

        // 大富翁流程
        public override void Start()
        {
            bool gameEnd = false;

            var monopolyPlayers = players.Select(x => (MonopolyPlayer)x).ToList();
            while (!gameEnd)
            {
                foreach (MonopolyPlayer currentPlayer in monopolyPlayers)
                {
                    // 某個玩家擲骰子
                    currentPlayer.ThrowDice();
                    // 隨機選敵人
                    if (currentPlayer.CheckHasCard())
                    {
                        MonopolyPlayer opponent = GetRandomOpponent(monopolyPlayers);
                        currentPlayer.UseCard(opponent);
                    }
                    Console.WriteLine($"{currentPlayer.Name} 目前總步數: {currentPlayer.Score}");

                    // 判斷是否抽卡
                    if (currentPlayer.Score % 10 == 0)
                    {
                        currentPlayer.DrawCard();
                    }
                    if (currentPlayer.Score >= 100)
                    {
                        Console.WriteLine($"{currentPlayer.Name} 贏了!");
                        gameEnd = true;
                        break;
                    }
                }
            }
        }
        // 隨機選敵人(除了自己以外)
        static MonopolyPlayer GetRandomOpponent(List<MonopolyPlayer> allPlayers)
        {
            Random rand = new Random();
            //LINQ
            //鍊式寫法
            MonopolyPlayer player = allPlayers.OrderBy(x => rand.Next(0, allPlayers.Count)).First();
            return player;
        }
    }
}
