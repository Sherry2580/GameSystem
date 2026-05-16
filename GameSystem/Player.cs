using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem
{
    internal abstract class Player
    {
        public string Name;
        // 建構子
        public Player(string name)
        {
            this.Name = name;
        }

        // 每個子類別自己決定要顯示什麼資訊
        public abstract void ShowInformation();
    }
}
