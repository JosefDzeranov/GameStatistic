﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server.Models
{
    class MatchInfoParameter : GameParameters
    {
        public string EndPoint { get; set; }
        public string Timestamp { get; set; }
        public string Json { get; set; }
    }
}
