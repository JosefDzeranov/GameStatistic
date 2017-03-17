using Kontur.GameStats.Server.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server.Reposit
{
    public interface IGameServerRepository
    {
        void DeleteExistGameServer(string endPoint);
        void AddGameServer(GameServerEntity item);
        void AddGameInfo(InfoGameEntity item);
    }
}
