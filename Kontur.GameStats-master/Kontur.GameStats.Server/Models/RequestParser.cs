using Kontur.GameStats.Server.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server.Models
{
    class RequestParser : IRequestParser
    {
        public GameParameters Parse(string httpMethod, string url, string json)
        {
            if (url == "/servers/info")
                return new AllInfoServersParameters();
            string[] segments = url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (segments[0] == "servers" && segments[2] == "info" && httpMethod == "GET")
            {
                return new GetGameInfoParameters() { EndPoint = segments[1] };
   
            }
            if (segments[0] == "servers" && segments[2] == "info" && httpMethod == "PUT")
            {
                return new PutGameInfoParameters() { EndPoint = segments[1], Json = json };
                // return new { EndPoint = segments[1], Parameters = json };
            }
            if (segments[0] == "servers" && segments[2] == "matches" && httpMethod == "PUT")
            {
                return new MatchInfoParameter() { EndPoint = segments[1], Timestamp = segments[3], Json = json };
            }
            if (segments[2] == "servers" && segments[4] == "matches" && httpMethod == "GET")
            {
                return new EmptyParametters();
                //return new { EndPoint = segments[1], TimeStamp = segments[3] };
            }
            return null;
        }
    }
}
