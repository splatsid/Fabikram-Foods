using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Moodify.ViewModels;

namespace Moodify.DataModels
{
    public class JsonUserModel
    {
        [JsonProperty(PropertyName = "Id")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "Password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "Favourites")]
        public String Favourites{ get; set; }

    }
}
