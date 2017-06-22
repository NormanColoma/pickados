using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminView.Models
{
    public class LoginModel
    {
        public string Title { get; set; }
        public string Theme { get; set; }

        public string AxisX { get; set; }
        public string AxisY { get; set; }

        public string Type { get; set; }

        public string Label { get; set; }
        public string Data { get; set; }



        [Required]
        [Display(Name = "Fecha de inicio")]
        public DateTime InitialDate { get; set; }

        [Required]
        [Display(Name = "Fecha de fin")]
        public DateTime FinalDate { get; set; }

        public LoginModel()
        {
            Title = App_Resources.properties_spa.login_stat_title;
            Theme = App_Resources.properties_spa.login_stat_theme;
            AxisX = App_Resources.properties_spa.login_stat_axisx;
            AxisY = App_Resources.properties_spa.login_stat_axisy;
            Type = App_Resources.properties_spa.login_stat_type;
        }

        public void completeInfoStat(Dictionary<string, int> statinfo)
        {
            Label = JsonConvert.SerializeObject(new List<string>(statinfo.Keys));
            Data = JsonConvert.SerializeObject(new List<int>(statinfo.Values));
        }
    }
}