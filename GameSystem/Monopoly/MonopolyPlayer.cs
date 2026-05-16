using GameSystem.Monopoly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem.Monopoly
{
    internal class MonopolyPlayer : Player
    {
        public int Score;
        public CardType CardName = CardType.未持有;
        public int dice;

        // 建構子
        public MonopolyPlayer(string name) : base(name)
        {
            this.Score = 0;
            this.CardName = CardType.未持有;
            this.dice = 0;
        }

        public override void ShowInformation()
        {
            Console.WriteLine($"{Name} 目前總步數: {Score}");
        }

        public void ThrowDice()
        {
            this.dice = Dice.ThrowDice(this.Name, 1);
            this.Score += this.dice;
        }
        public void UseCard(MonopolyPlayer opponent)
        {
            Card.UseCard(this, opponent);
            this.CardName = CardType.未持有;    // 使用完清空卡片
        }
        public void DrawCard()
        {
            this.CardName = Card.DrawCard(this.Name);
        }
        public bool CheckHasCard()
        {
            return this.CardName != CardType.未持有;
        }
    }
}
