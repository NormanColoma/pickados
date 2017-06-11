using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.Enumerated.Pickados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminView.Models
{
    public class PostModel
    {
        [Display(Name = "Id")]
        [Editable(false)]
        public int Id { get; set; }

        [Display(Name = "Creado en")]
        [Editable(false)]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Created_at { get; set; }

        [Display(Name = "Modificado en")]
        [Editable(false)]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Modified_at { get; set; }

        [Display(Name = "Inversión")]
        [Editable(false)]
        public double Stake { get; set; }

        [Display(Name = "Descripción")]
        [Editable(false)]
        public string Description { get; set; }

        [Display(Name = "Privado")]
        [Editable(false)]
        public bool Private_ { get; set; }

        [Display(Name = "Cuota final")]
        [Editable(false)]
        public double TotalOdd { get; set; }

        [Display(Name = "Resultado")]
        [Editable(false)]
        public PickResultEnum PostResult { get; set; }

        [Display(Name = "Me gusta")]
        [Editable(false)]
        public int Likeit { get; set; }

        [Display(Name = "Denuncias")]
        [Editable(false)]
        public int Report { get; set; }

        [Display(Name = "Picks")]
        [Editable(false)]
        public IList<PickModel> Picks { get; set; }

        [Display(Name = "Tipster")]
        [Editable(false)]
        public UserModel Tipster { get; set; }

        [Display(Name = "Peticiones")]
        [Editable(false)]
        public RequestEN Request { get; set; }
    }
}   