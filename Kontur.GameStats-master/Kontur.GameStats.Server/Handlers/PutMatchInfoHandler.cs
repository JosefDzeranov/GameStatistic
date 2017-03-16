using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kontur.GameStats.Server.Models;
using Kontur.GameStats.Server.RequestParameters;
using Newtonsoft.Json;
using Kontur.GameStats.Server.Entity;

namespace Kontur.GameStats.Server.Handlers
{
    class PutMatchInfoHandler : IRequestHandler
    {
        public ServerResponse RequestHandle(GameParameters parameters)
        {
            var param = parameters as PutMatchInfoParameter;
            var match = JsonConvert.DeserializeObject<InfoMatchEntity>(param.Json);


        }
    }
}
