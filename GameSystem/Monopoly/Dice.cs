using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.Monopoly
{
    internal class Dice
    {
        static Random rand = new Random();
        public static int ThrowDice(string playerName, int diceNumber = 1)
        {
            int dice = 0;
            while (diceNumber > 0)
            {
                diceNumber--;
                dice += rand.Next(1, 7);
            }
            Console.WriteLine($"{playerName}擲出{dice}");
            return dice;
        }
    }
}
