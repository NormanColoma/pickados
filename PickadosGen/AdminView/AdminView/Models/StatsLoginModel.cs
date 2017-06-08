using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminView.Models
{
    public class StatsLoginModel
    {
        public string Title { get; set; }
        public string Theme { get; set; }

        public string AxisX { get; set; }
        public string AxisY { get; set; }

        public string Type { get; set; }
        public string DataPoints { get; set; }

        [Required]
        [Display(Name = "Fecha de inicio")]
        public DateTime InitialDate { get; set; }

        [Required]
        [Display(Name = "Fecha de fin")]
        public DateTime FinalDate { get; set; }

        public StatsLoginModel()
        {
            Title = App_Resources.properties_spa.login_stat_title;
            Theme = App_Resources.properties_spa.login_stat_theme;
            AxisX = App_Resources.properties_spa.login_stat_axisx;
            AxisY = App_Resources.properties_spa.login_stat_axisy;
            Type = App_Resources.properties_spa.login_stat_type;
            DataPoints = "";
        }

        public string DataPointsToString(Dictionary<string, int> DataPoints)
        {
            string datapoints = "[";

            foreach (KeyValuePair<string, int> DataPoint in DataPoints)
            {
                datapoints += "{ y: " + DataPoint.Value + ", label: \" " + DataPoint.Key + " \"},";
            }

            datapoints = datapoints.Substring(0, datapoints.Length - 1) + "]";

            return datapoints;
        }
    }
}