using AdminView.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace AdminView.Models
{
    public class UserModel
    {
        [Display(Name = "Id")]
        [Editable(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "DNI")]
        public string Nif { get; set; }

        [Required]
        [Display(Name = "Alias")]
        public string Alias { get; set; }

        [Required]
        [Display(Name = "Email", ResourceType = typeof(textos))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Created_at", ResourceType = typeof(textos))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Created_at { get; set; }

        [Display(Name = "Updated_at", ResourceType = typeof(textos))]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Updated_at { get; set; }

        public string Password { get; set; }

        [Display(Name = "Is admin")]
        public bool Admin { get; set; }

        [Display(Name = "Is premium")]
        public bool Tipsterp { get; set; }

        [Display(Name = "Subscription_fee", ResourceType = typeof(textos))]
        [DataType(DataType.Currency)]
        public double Subscription_fee { get; set; }

        [Display(Name = "Locked", ResourceType = typeof(textos))]
        public bool Locked { get; set; }
    }
}