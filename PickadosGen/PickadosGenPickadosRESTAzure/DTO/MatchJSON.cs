using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickadosGenPickadosRESTAzureREST.DTO
{
    public class MatchJSON
    {
        [JsonProperty("match_id")]
        public string MatchId { get; set; }

        [JsonProperty("country_name")]
        public string Competition { get; set; }

        [JsonProperty("league_name")]
        public string League { get; set; }

        [JsonProperty("match_date")]
        public string MatchDate { get; set; }

        [JsonProperty("match_time")]
        public string MatchTime { get; set; }

        [JsonProperty("match_hometeam_name")]
        public string HomeTeam { get; set; }

        [JsonProperty("match_awayteam_name")]
        public string AwayTeam { get; set; }

        [JsonProperty("match_live")]
        public string Live { get; set; }

        public List<OddJSON> Odds { get; set; }
    }
}