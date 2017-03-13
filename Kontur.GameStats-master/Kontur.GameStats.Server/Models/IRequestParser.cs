using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server.Models
{
    interface IRequestParser
    {
        GameParameters Parse(string httpMethod, string url, string json);
    }
}
