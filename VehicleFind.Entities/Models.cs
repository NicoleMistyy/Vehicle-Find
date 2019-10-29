using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleFind.Entities
{
    public class Models
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("range")]
        public string Range { get; set; }

        public virtual ICollection<Specifications> Specifications { get; set; }
    }
}
