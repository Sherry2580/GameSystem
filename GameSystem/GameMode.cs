using GameSystem.Monopoly;
using GameSystem.PK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem
{
    // 抽象父類別
    internal abstract class GameMode
    {
        public List<Player> players = new List<Player>();

        public GameMode(List<string> playerNames)
        {
            // 根據遊戲類型建立相應的玩家
            Type playType = Type.GetType($"{this.GetType().Namespace}.{this.GetType().Name.Replace("Game", "Player")}");
            foreach (string name in playerNames)
            {
                Player player = Activator.CreateInstance(playType, new object[] { name }) as Player;
                players.Add(new MonopolyPlayer(name));
            }

        }

        public abstract void Start();
        public void ShowPlayersInfo()
        {
            foreach (Player p in players)
            {
                p.ShowInformation();
            }
        }
    }
}
