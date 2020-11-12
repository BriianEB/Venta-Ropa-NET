using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VentaRopa.Models
{
    public class ProductoModel
    {
        [Key]
        [Required]
        public int ProductoId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Precio { get; set; }
    }
}
