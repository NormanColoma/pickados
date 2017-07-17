using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PickadosGenPickadosRESTAzureREST.DTO
{
    public class SportEventDTO
    {
        private String country_name;
        public String CountryName
        {
            get { return country_name; }
            set { country_name = value; }
        }

        private String league_name;
        public String League
        {
            get { return league_name; }
            set { league_name = value; }
        }

        private String match_hometeam_name;
        public String HomeTeam
        {
            get { return match_hometeam_name; }
            set { match_hometeam_name = value; }
        }

        private String match_awayteam_name;
        public String AwayTeam
        {
            get { return match_awayteam_name; }
            set { match_awayteam_name = value; }
        }

    }
}