using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickadosGenPickadosRESTAzureREST.DTO
{
    public class OddJSON
    {
        [JsonProperty("match_id")]
        public string MatchId { get; set; }

        [JsonProperty("odd_bookmakers")]
        public string Bookie { get; set; }

        [JsonProperty("odd_1")]
        public string Odd1 { get; set; }

        [JsonProperty("odd_x")]
        public string OddX { get; set; }

        [JsonProperty("odd_2")]
        public string Odd2 { get; set; }

        [JsonProperty("o+2.5")]
        public string Over { get; set; }

        [JsonProperty("u+2.5")]
        public string Under { get; set; }

    }
}