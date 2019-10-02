using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace HelperModel
{
    public class HelperModelBase : IHelperModelBase
    {

        [JsonProperty(PropertyName ="_id")]
        public string Id { get; set; }
    }
}
