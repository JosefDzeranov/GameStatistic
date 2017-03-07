using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server.Models
{
    class GameServer
    {
        public string EndPoint { get; set; }
        public string Name { get; set; }
        public string[] GameModes { get; set; }
    }
}
