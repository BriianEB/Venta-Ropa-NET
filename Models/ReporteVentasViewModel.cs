using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VentaRopa.Models
{
    public class ReporteVentasViewModel
    {
        public IList<ReporteVentaModel> Ventas { get; set; }

        public int Total { get; set; }
    }
}
