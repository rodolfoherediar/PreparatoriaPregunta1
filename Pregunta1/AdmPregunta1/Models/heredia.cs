using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdmPregunta1.Models
{
    public enum PlaceType
    {
        Casa = 1,
        Universidad = 2,
        Colegio = 3,
        Trabajo = 4,
        Restaurante = 5

    }
    public class heredia
    {
        [Key]
        public int herediaID { get; set; }

        [StringLength(30, ErrorMessage = "The field {0} must contein between {2} and {1} characteres", MinimumLength = 2)]
        [Required(ErrorMessage = "You must enter the field {0}")]
        [Display(Name = "Nombre completo")]
        public string Friendofheredia { get; set; }

        [Required]
        public PlaceType Place { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Cumpleaños")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
    }
}