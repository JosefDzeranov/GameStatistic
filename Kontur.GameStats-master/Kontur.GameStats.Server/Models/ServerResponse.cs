using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server.Models
{
    public class ServerResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ResultText { get; set; }

    }
}
