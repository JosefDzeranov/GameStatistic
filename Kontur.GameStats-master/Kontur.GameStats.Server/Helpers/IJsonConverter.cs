using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur.GameStats.Server.Helpers
{
    public interface IJsonConverter
    {
        T Deserialize<T>(string json);
        string Serialize<T>(T item);

    }
}
