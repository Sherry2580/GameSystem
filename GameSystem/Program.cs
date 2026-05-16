using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 選擇遊戲
            Console.WriteLine("請選擇遊戲: ");
            List<string> gameNames = GetGameNames();
            for (int i = 0; i < gameNames.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {gameNames[i]}");
            }
            int gameChoice = int.Parse(Console.ReadLine());
            GameType gameType = (GameType)gameChoice;

            // 輸入人數
            Console.Write("請輸入遊玩人數: ");
            int count = int.Parse(Console.ReadLine());

            // 輸入每位玩家名稱
            List<string> playerNames = new List<string>();
            for (int i = 0; i < count; i++)
            {
                Console.Write($"請輸入第 {i + 1} 位玩家名字: ");
                string name = Console.ReadLine();
                playerNames.Add(name);
            }

            // 建立遊戲並開始
            Game game = new Game(gameType, playerNames);
            game.Start();
        }

        static List<string> GetGameNames()
        {
            return typeof(GameType).GetFields(BindingFlags.Public | BindingFlags.Static).Select(x => x.GetCustomAttribute<DescriptionAttribute>().Description).ToList();
        }

    }
}
