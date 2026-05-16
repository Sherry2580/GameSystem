using GameSystem.Monopoly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.Monopoly
{
    internal class Card
    {
        static Random rand = new Random();
        public static void UseCard(MonopolyPlayer player, MonopolyPlayer opponent)
        {
            Console.WriteLine($"{player.Name}使用了{player.CardName}");
            switch (player.CardName)
            {
                case CardType.兔子卡:
                    player.Score += 2;
                    break;
                case CardType.烏龜卡:
                    player.Score -= player.dice < 3 ? 1 : 2;
                    break;
                case CardType.天使卡:
                    opponent.Score += 2;
                    break;
                case CardType.惡魔卡:
                    opponent.Score -= opponent.Score < 3 ? 1 : 2;
                    break;
            }

        }
        // 方法2
        public static CardType DrawCard(string playerName)
        {
            CardType cardType = (CardType)rand.Next(1, 5);
            Console.WriteLine($"{playerName}抽到{cardType}!"); // CardType cardType在 print 的時候會自己轉成字串
            return cardType;
        }
    }
}
