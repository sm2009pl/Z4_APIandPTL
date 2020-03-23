using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Z4_API
{
    [JsonArray]
    class CoachesCollection
    { 
        public List<Coaches> CoachesList { get; set; }
    }
}
