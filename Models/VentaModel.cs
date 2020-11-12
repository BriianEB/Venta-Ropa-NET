using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentaRopa.Models
{
    public class VentaModel
    {
        [Key]
        [Required]
        public int VentaId { get; set; }

        [ForeignKey("Producto")]
        [Required]
        public int Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public int Total { get; set; }
    }
}
