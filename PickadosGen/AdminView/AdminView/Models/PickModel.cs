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
        [Display(Name = "Id")]
        [Editable(false)]
        public int Id { get; set; }

        [Display(Name = "Apuesta")]
        public double Odd { get; set; }

        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Display(Name = "Resultado")]
        public PickResultEnum PickResult { get; set; }

        [Display(Name = "Corredor de apuestas")]
        public string Bookie { get; set; }

        [Display(Name = "Nombre del goleador")]
        public string Scorer_name { get; set; }

        [Display(Name = "Resultado")]
        public PlayerEN Scorer_Player { get; set; }

        [Display(Name = "Nombre del equipo")]
        public string Team_name { get; set; }

        [Display(Name = "Resultado")]
        public string Score_time { get; set; }

        [Display(Name = "Resultado")]
        public ResultEnum Result { get; set; }

        [Display(Name = "Resultado")]
        public TimeEnum MatchTime { get; set; }

        [Display(Name = "Resultado")]
        public ResultEnum Result_b { get; set; }

        [Display(Name = "Resultado")]
        public LineEnum Line { get; set; }

        [Display(Name = "Resultado")]
        public double Quantity { get; set; }

        [Display(Name = "Resultado")]
        public bool Asian { get; set; }

        [Display(Name = "Resultado")]
        public ResultEnum HandicapResult { get; set; }

        [Display(Name = "Resultado")]
        public int HomeScore { get; set; }

        [Display(Name = "Resultado")]
        public int AwayScore { get; set; }
    }
}