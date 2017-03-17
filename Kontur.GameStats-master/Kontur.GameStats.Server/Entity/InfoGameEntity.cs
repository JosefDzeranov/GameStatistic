using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server.Entity
{
    public class InfoGameEntity
    {
        [JsonIgnoreAttribute]
        public string Id { get; set; }
        public string Name { get; set; }
        private List<String> _gameModes { get; set; }
        public List<string> GameModes
        {
            get { return _gameModes; }
            set { _gameModes = value; }
        }

        [Required]
        [JsonIgnoreAttribute]
        public string StringsAsString
        {
            get { return String.Join(",", _gameModes); }
            set { _gameModes = value.Split(',').ToList(); }
        }
    }
}
