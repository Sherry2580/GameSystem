using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GameSystem
{
    internal enum GameType
    {
        [Description("大富翁遊戲")]
        Monopoly = 1,
        [Description("PK遊戲")]
        PK
    }
}
