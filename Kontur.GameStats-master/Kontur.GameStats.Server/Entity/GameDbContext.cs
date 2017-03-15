using Kontur.GameStats.Server.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server.Entity
{
    class GameDbContext : DbContext
    {
        public GameDbContext()
            : base("DbConnection")
        { }
        public DbSet<GameServerEntity> GameServerEntities { get; set; }
        public DbSet<InfoGameEntity> InfoGameEntities { get; set; }

    }
}
