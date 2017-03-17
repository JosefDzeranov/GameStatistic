using Kontur.GameStats.Server.Entity;
using Kontur.GameStats.Server.Helpers;
using Kontur.GameStats.Server.Models;
using Kontur.GameStats.Server.Reposit;
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
    public class PutGameInfoHandler : IRequestHandler
    {
        private readonly IGameServerRepository _repository;
        private readonly IJsonConverter _jsonConverter;

        public PutGameInfoHandler(IGameServerRepository repository, IJsonConverter jsonConverter)
        {
            _repository = repository;
            _jsonConverter = jsonConverter;
        }



        public ServerResponse RequestHandle(GameParameters parameters)
        {
            if (parameters == null)
                return new ServerResponse()
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ResultText = string.Empty
                };

            var param = parameters as PutGameInfoParameters;


            var info = _jsonConverter.Deserialize<InfoGameEntity>(param.Json);
           // var info2 = _jsonConverter.Deserialize<InfoGameEntity>(param.Json);

            info.Id = Guid.NewGuid().ToString();//не тестируется 

            var gameServer = new GameServerEntity()
            {
                Id = Guid.NewGuid().ToString(),
                EndPoint = param.EndPoint,
                InfoId = info.Id,
                Info = info
            };

            _repository.DeleteExistGameServer(param.EndPoint);

            _repository.AddGameServer(gameServer);
            _repository.AddGameInfo(info);

            return new ServerResponse()
            {
                StatusCode = HttpStatusCode.OK,
                ResultText = string.Empty
            };
        }


    }
}
