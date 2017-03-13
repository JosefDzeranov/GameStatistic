using Kontur.GameStats.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server.Handlers
{
    interface IRequestHandler
    {
        ServerResponse RequestHandle(GameParameters parameters);
    }
}
