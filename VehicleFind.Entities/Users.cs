using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleFind.Entities
{
    public class Users
    {
        [JsonProperty("id")]
        [Key]
        public int Id { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("surnName")]
        public string Surname { get; set; }
        [JsonProperty("cellNumber")]
        public string CellNumber { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
