using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace HelperModel
{
    public class Users : HelperModelBase
    {
        [JsonProperty(PropertyName ="name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "clientName")]
        public string ClientName { get; set; }
    }
}
