using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleFind.MigrationBate
{
    public class Models
    {
        [JsonProperty("id")]
        [Key]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("range")]
        public string Range { get; set; }

        public virtual ICollection<Specifications> Specifications { get; set; }
    }
}
