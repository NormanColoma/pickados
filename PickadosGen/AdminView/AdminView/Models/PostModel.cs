using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.Enumerated.Pickados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AdminView.Resources;

namespace AdminView.Models
{
    public class PostModel
    {
        [Display(Name = "Id")]
        [Editable(false)]
        public int Id { get; set; }

        [Display(Name = "Created_at", ResourceType = typeof(textos))]
        [Editable(false)]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Created_at { get; set; }

        [Display(Name = "Updated_at", ResourceType = typeof(textos))]
        [Editable(false)]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Modified_at { get; set; }

        [Display(Name = "Stake", ResourceType = typeof(textos))]
        [Editable(false)]
        public double Stake { get; set; }

        [Display(Name = "Description", ResourceType = typeof(textos))]
        [Editable(false)]
        public string Description { get; set; }

        [Display(Name = "Private", ResourceType = typeof(textos))]
        [Editable(false)]
        public bool Private_ { get; set; }

        [Display(Name = "Odd", ResourceType = typeof(textos))]
        [Editable(false)]
        public double TotalOdd { get; set; }

        [Display(Name = "Result", ResourceType = typeof(textos))]
        [Editable(false)]
        public PickResultEnum PostResult { get; set; }

        [Display(Name = "Likes", ResourceType = typeof(textos))]
        [Editable(false)]
        public int Likeit { get; set; }

        [Display(Name = "Reports", ResourceType = typeof(textos))]
        [Editable(false)]
        public int Report { get; set; }

        [Display(Name = "Picks", ResourceType = typeof(textos))]
        [Editable(false)]
        public IList<PickModel> Picks { get; set; }

        [Display(Name = "Tipster", ResourceType = typeof(textos))]
        [Editable(false)]
        public UserModel Tipster { get; set; }

        [Display(Name = "Request", ResourceType = typeof(textos))]
        [Editable(false)]
        public RequestEN Request { get; set; }
    }
}   