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
    class GameInfoHandler : IRequestHandler
    {
        public GameInfoHandler( )
        {

        }
        public ServerResponse RequestHandle(GameParameters parameters)
        {
            var param = parameters as GameInfoParrameters;
           var info= JsonConvert.DeserializeObject<InfoGame>(param.Json);
            //записать в бд
           return new ServerResponse() { StatusCode = HttpStatusCode.OK, ResultText = "" };
        }
    }
}
