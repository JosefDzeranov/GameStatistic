using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kontur.GameStats.Server.Entity;

namespace Kontur.GameStats.Server.Reposit
{
    class GameServerRepository : IGameServerRepository
    {
        private readonly GameDbContext dbContext;
        public GameServerRepository()
        {
            dbContext = new GameDbContext();
        }
        public void AddGameInfo(InfoGameEntity item)
        {
            dbContext.InfoGameEntities.Add(item);
            dbContext.SaveChanges();
        }

        public void AddGameServer(GameServerEntity item)
        {
            dbContext.GameServerEntities.Add(item);
            dbContext.SaveChanges();
        }

        public void DeleteExistGameServer(string endPoint)
        {
            var isGameServer = dbContext.GameServerEntities.First(x => x.EndPoint == endPoint);
            if (isGameServer == null)
            {
                InfoGameEntity infoGame = new InfoGameEntity() { Id = isGameServer.InfoId };
                dbContext.InfoGameEntities.Attach(infoGame);
                dbContext.InfoGameEntities.Remove(infoGame);
                dbContext.GameServerEntities.Remove(isGameServer);
            }
        }
    }
}
