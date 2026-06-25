using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("請輸入玩家名字: ");
            string playerName = Console.ReadLine();

            Game game = new Game(playerName);
            game.Start();
        }
    }
}
