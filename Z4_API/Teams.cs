using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Z4_API
{
    public class Teams
    {
        [JsonIgnore]
        public int id { get; set; }
        public string School { get; set; }
        //public string Mascot { get; set; }
        public string Abbreviation { get; set; }
        public string Conference { get; set; }
        public string Division { get; set; }
        public List<Coaches> coaches { get; set; } = new List<Coaches>();




    }
}