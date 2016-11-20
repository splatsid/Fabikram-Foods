using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Moodify.DataModels
{
    class Order
    {

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public double Price { get; set; }

        [JsonProperty(PropertyName = "User")]
        public String User { get; set; }
    }
}
