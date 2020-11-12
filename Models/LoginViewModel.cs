using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VentaRopa.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Clave { get; set; }
    }
}
