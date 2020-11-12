using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentaRopa.Models
{
    public class ReporteVentaModel
    {
        public string Producto { get; set; }

        public int Cantidad { get; set; }

        public int Total { get; set; }

        public int PromedioProducto { get; set; }
    }
}
