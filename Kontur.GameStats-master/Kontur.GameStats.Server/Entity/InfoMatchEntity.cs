using Kontur.GameStats.Server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server.Entity
{
    class InfoMatchEntity
    {
        [JsonIgnoreAttribute]
        public string Id { get; set; }
        public string Map { get; set; }
        public string GameMode { get; set; }
        public int FragLimit { get; set; }
        public int TimeLimit { get; set; }
        public double TimeElapsed { get; set; }
        public string ScoreboardId { get; set; }
        public List<PlayerEntity> Scoreboard { get; set; }
        [JsonIgnoreAttribute]
        public string Timestamp { get; set; }

    }
}
