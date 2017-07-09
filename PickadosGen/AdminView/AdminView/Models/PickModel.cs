using AdminView.Resources;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.Enumerated.Pickados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminView.Models
{
    public class PickModel
    {
        public string Type { get; set; }

        public int Post { get; set; }

        [Display(Name = "Id")]
        [Editable(false)]
        public int Id { get; set; }

        [Display(Name = "Odd", ResourceType = typeof(textos))]
        public double Odd { get; set; }

        [Display(Name = "Description", ResourceType = typeof(textos))]
        public string Description { get; set; }

        [Display(Name = "Result", ResourceType = typeof(textos))]
        public PickResultEnum PickResult { get; set; }

        [Display(Name = "Bookie", ResourceType = typeof(textos))]
        public string Bookie { get; set; }

        [Display(Name = "Scorer_name", ResourceType = typeof(textos))]
        public string Scorer_name { get; set; }

        [Display(Name = "Scorer_player", ResourceType = typeof(textos))]
        public PlayerEN Scorer_Player { get; set; }

        [Display(Name = "Team_name", ResourceType = typeof(textos))]
        public string Team_name { get; set; }

        [Display(Name = "Score_time", ResourceType = typeof(textos))]
        public string Score_time { get; set; }

        [Display(Name = "Result", ResourceType = typeof(textos))]
        public ResultEnum Result { get; set; }

        [Display(Name = "Match_time", ResourceType = typeof(textos))]
        public TimeEnum MatchTime { get; set; }

        [Display(Name = "Result", ResourceType = typeof(textos))]
        public ResultEnum Result_b { get; set; }

        [Display(Name = "Line", ResourceType = typeof(textos))]
        public LineEnum Line { get; set; }

        [Display(Name = "Quantity", ResourceType = typeof(textos))]
        public double Quantity { get; set; }

        [Display(Name = "Asian", ResourceType = typeof(textos))]
        public bool Asian { get; set; }

        [Display(Name = "Handicap_result", ResourceType = typeof(textos))]
        public ResultEnum HandicapResult { get; set; }

        [Display(Name = "Home_score", ResourceType = typeof(textos))]
        public int HomeScore { get; set; }

        [Display(Name = "Away_score", ResourceType = typeof(textos))]
        public int AwayScore { get; set; }
    }
}