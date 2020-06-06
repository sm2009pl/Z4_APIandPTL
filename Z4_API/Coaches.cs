using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Z4_API
{
    class Coaches
    {

        [JsonIgnore]    
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

        public List<Season> seasons { get; set; }
    }
}
