using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminView.Models
{
    public class StatModel
    {
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }

        public string Label { get; set; }
        public string Data { get; set; }

        public void completeInfoStat(Dictionary<string, int> statinfo)
        {
            Label = JsonConvert.SerializeObject(new List<string>(statinfo.Keys));
            Data = JsonConvert.SerializeObject(new List<int>(statinfo.Values));
        }
    }
}