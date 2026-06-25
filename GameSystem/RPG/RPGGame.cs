using GameSystem.RPG.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.RPG
{
    internal class RPGGame : GameMode
    {
        RPGPlayer player;
        Enemy enemy;
        Shop shop = new Shop();

        // 建構子
        public RPGGame(List<string> players) : base(players)
        {
            // 建立玩家
            this.player = new RPGPlayer(players[0]);
        }

        public override void Start()
        {
            for (int round = 1; round <= 10; round++)
            {
                // 第6關開始每關開始前可以選道具 -> 進商店
                if (round >= 6)
                {

                    round = shop.Open(player, round);
                }

                Console.WriteLine($"第{round}關開始");
                if (round <= 5)
                {
                    enemy = new Enemy();
                }
                else
                {
                    enemy.Evolution();
                }

                player.ShowInformation();
                enemy.ShowInformation();

                int playerWin = Battle.StartBattle(player, enemy);

                if (playerWin == 0)
                {
                    Console.WriteLine($"玩家{player.Name}在第{round}關挑戰失敗，遊戲結束");
                    return;
                }
                Console.WriteLine($"第{round}關通過");

                // 每關過後補滿 HP
                player.Reset();
                enemy.Reset();
            }
            Console.WriteLine($"恭喜破完全部關卡!");
        }
    }
}
