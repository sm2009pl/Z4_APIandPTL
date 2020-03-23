using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Z4_API
{
    [JsonArray]
    class TeamsCollection
    {
        public List<Teams> TeamsList { get; set; }
    }
}
