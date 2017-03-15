using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kontur.GameStats.Server.Models;
using Kontur.GameStats.Server.RequestParameters;
using Kontur.GameStats.Server.Entity;
using System.Net;
using Newtonsoft.Json;

namespace Kontur.GameStats.Server.Handlers
{
    class GetGameInfoHandler : IRequestHandler
    {
        private readonly GameDbContext db = new GameDbContext();

        public ServerResponse RequestHandle(GameParameters parameters)
        {
            var param = parameters as GetGameInfoParameters;
            var game = db.GameServerEntities.FirstOrDefault(x => x.EndPoint == param.EndPoint);
            if (game == null)
            {
                return new ServerResponse() { ResultText = "", StatusCode = HttpStatusCode.NotFound };
            }
            game.Info = db.InfoGameEntities.FirstOrDefault(x => x.Id == game.InfoId);
            return new ServerResponse() { StatusCode = HttpStatusCode.OK, ResultText = JsonConvert.SerializeObject(game) };
        }
    }
}
