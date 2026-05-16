using GameSystem.Monopoly;
using GameSystem.PK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem
{
    internal class Game
    {
        public GameType gameType;
        public List<Player> players;
        private GameMode gameMode = null;

        public Game(GameType gameType, List<string> playerNames)
        {
            this.gameType = gameType;
            this.players = new List<Player>();  // 建一個所有玩家的名單
            Type type = Type.GetType($"GameSystem.{gameType}.{gameType}Game");
            gameMode = (GameMode)Activator.CreateInstance(type, new object[] { playerNames });


        }

        public void Start()
        {


            // 根據遊戲類型走不同流程
            // switch 用下面寫的反射的寫法取代
            //switch (gameType)
            //{
            //    case GameType.Monopoly:
            //        StartMonopoly();
            //        break;
            //    case GameType.PK:
            //        StartPK();
            //        break;
            //}

            // 反射
            gameMode.Start();
        }
    }
}
