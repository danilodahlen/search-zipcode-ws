using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace zipcode_ws.Models
{
    public class ResultObject<T>
    {
        public T Object;
        public List<string> Errors = new List<string>();
    }

    public class ZipCodeModel
    {
        [JsonProperty("cep")]
        public string ZibCode { get; set; }

        [JsonProperty("logradouro")]
        public string Street { get; set; }

        [JsonProperty("bairro")]
        public string District { get; set; }

        [JsonProperty("localidade")]
        public string City { get; set; }

        [JsonProperty("uf")]
        public string State { get; set; }
    }
}