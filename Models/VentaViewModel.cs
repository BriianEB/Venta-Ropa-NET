using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VentaRopa.Models
{
    public class VentaViewModel
    {
        [Required]
        public int Producto { get; set; }

        public IList<SelectListItem> Productos { get; set; }

        [Required]
        public int Cantidad { get; set; }


        public VentaViewModel()
        {
            Productos = new List<SelectListItem>();
        }
    }
}
