using System;
using System.ComponentModel.DataAnnotations;

namespace AdminView.Models
{
    public class UserViewModels
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
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Created at...")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Created_at { get; set; }

        [Display(Name = "Updated at...")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Updated_at { get; set; }

        public string Password { get; set; }

        [Display(Name = "Is admin")]
        public bool Admin { get; set; }

        [Display(Name = "Is premium")]
        public bool Tipsterp { get; set; }

        [Display(Name = "Subscription fee")]
        [DataType(DataType.Currency)]
        public double Subscription_fee { get; set; }

        [Display(Name = "Is locked")]
        public bool Locked { get; set; }
    }
}