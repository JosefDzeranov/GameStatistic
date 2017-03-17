using Kontur.GameStats.Server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server.Entity
{
public    class GameServerEntity
    {
        [JsonIgnoreAttribute]
        public string Id { get; set; }
        [JsonIgnoreAttribute]
        public string InfoId { get; set; }
        public string EndPoint { get; set; }
        public InfoGameEntity Info { get; set; }
    }
}
