using Newtonsoft.Json;

namespace Kontur.GameStats.Server.Entity
{
    public class PlayerEntity
    {
        [JsonIgnoreAttribute]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Frags { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }

    }
}