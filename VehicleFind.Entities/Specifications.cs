﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleFind.Entities
{
    public class Specifications
    {
        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("modelId")]
        public int ModelId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }

        public virtual Models Model { get; set; }
    }
}
