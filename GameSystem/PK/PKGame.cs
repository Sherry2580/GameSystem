using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.PK
{
    internal class PKGame : GameMode
    {
        // 建構子
        public PKGame(List<string> players) : base(players)
        {
        }

        // PK 遊戲流程
        public override void Start()
        {
            Console.WriteLine("選擇賽制: ");
            Console.WriteLine("1. 一般對打");
            Console.WriteLine("2. 單淘汰");
            Console.WriteLine("3. 雙淘汰");
            int choice = int.Parse(Console.ReadLine());
            CompetitionType competitionType = (CompetitionType)choice;

            var PkPlayers = players.Select(x => (PkPlayer)x).ToList();

            // 反射
            Type type = Type.GetType($"GameSystem.PKGame.Competitions.{competitionType}Game");
            Competition competition = (Competition)Activator.CreateInstance(type);
            PkPlayer champion = competition.StartGame(PkPlayers);
            Console.WriteLine($"冠軍是 {champion.Name}!!! 剩餘血量：{champion.HP}");
        }
    }
}
