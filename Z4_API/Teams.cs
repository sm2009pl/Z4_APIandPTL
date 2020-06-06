using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Z4_API
{
    class Teams
    {
        public int id { get; set; }
        public string school { get; set; }
        public string abbreviation { get; set; }
        public string conference { get; set; }

        [JsonIgnore]
        public List<Coaches> Coaches { get; set; } = new List<Coaches>();

    }
}