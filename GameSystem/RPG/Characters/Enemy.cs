using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameSystem.RPG.Characters
{
    internal class Enemy : Character
    {
        // 建構子
        public Enemy()
        {
            this.Name = "敵人";
            this.HP = 10;

            // 前五關：素質隨機 1~5
            this.Attack = rand.Next(1, 6);
            this.Defense = rand.Next(1, 6);
            this.Agile = rand.Next(1, 6);
        }

        // 第六關開始：抓前一關最高最低素質各 + 1
        public void Evolution()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"Attack", Attack },
                {"Defense", Defense },
                {"Agile", Agile }
            };

            var dictOrdered = dict.OrderByDescending(x => x.Value).ToList();
            dict[dictOrdered.First().Key]++;
            dict[dictOrdered.Last().Key]++;

            // 反射
            typeof(Enemy).GetField(dictOrdered.First().Key).SetValue(this, dict[dictOrdered.First().Key]);
            typeof(Enemy).GetField(dictOrdered.Last().Key).SetValue(this, dict[dictOrdered.Last().Key]);
        }


        // 新一關需要重置各項血量與能力
        public override void Reset()
        {
            this.HP = 10;
        }
    }
}
