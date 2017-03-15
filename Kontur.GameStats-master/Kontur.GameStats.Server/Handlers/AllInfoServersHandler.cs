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
    class AllInfoServersHandler : IRequestHandler
    {
        private readonly GameDbContext db = new GameDbContext();
        public ServerResponse RequestHandle(GameParameters parameters)
        {

            var games = db.GameServerEntities;
          

                foreach (var game in games)
                {
                    try
                    {
                        var info = db.InfoGameEntities.FirstOrDefault(x => x.Id == game.InfoId);
                        game.Info = info;
                    }
                    catch (Exception ex) { }
                }
                return new ServerResponse() { StatusCode = HttpStatusCode.OK, ResultText = JsonConvert.SerializeObject(games) };
            }



        }
    
}
