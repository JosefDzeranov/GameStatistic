using Kontur.GameStats.Server.Entity;
using Kontur.GameStats.Server.Models;
using Kontur.GameStats.Server.RequestParameters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server.Handlers
{
    class PutGameInfoHandler : IRequestHandler
    {
        private readonly GameDbContext db = new GameDbContext();
        public PutGameInfoHandler()
        {

        }
        public ServerResponse RequestHandle(GameParameters parameters)
        {
            if (parameters == null) return new ServerResponse() { StatusCode = HttpStatusCode.BadRequest, ResultText = "" };
            var param = parameters as PutGameInfoParameters;
            var info = JsonConvert.DeserializeObject<InfoGameEntity>(param.Json);
            info.Id = Guid.NewGuid().ToString();
            var gameServer = new GameServerEntity() { Id = Guid.NewGuid().ToString(), EndPoint = param.EndPoint, InfoId = info.Id, Info = info };
            db.GameServerEntities.Add(gameServer);
            db.InfoGameEntities.Add(info);
            db.SaveChanges();
            return new ServerResponse() { StatusCode = HttpStatusCode.OK, ResultText = "" };
        }
    }
}
