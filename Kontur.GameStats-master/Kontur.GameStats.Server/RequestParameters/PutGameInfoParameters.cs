using Kontur.GameStats.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server.RequestParameters
{
  public  class PutGameInfoParameters : GameParameters
    {
        public string Json { get; set; }
        public string EndPoint { get; set; }
       

    }
}
