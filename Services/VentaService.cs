using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentaRopa.Data;
using VentaRopa.Models;

namespace VentaRopa.Services
{
    public class VentaService
    {
        private readonly AppDbContext _context;
        private readonly ProductoService productoService;


        public VentaService(AppDbContext context, ProductoService productoService)
        {
            _context = context;
            this.productoService = productoService;
        }

        public void AddVenta(VentaViewModel ventaView)
        {
            ProductoModel producto = productoService.GetProducto(ventaView.Producto);

            VentaModel venta = new VentaModel
            {
                Producto = ventaView.Producto,
                Cantidad = ventaView.Cantidad,
                Total = (producto.Precio) * ventaView.Cantidad
            };

            _context.Add(venta);
            _context.SaveChanges();
        }

        public ReporteVentasViewModel GetReporteVentas()
        {
            var ventasQuery = (from venta in _context.Ventas
                        join producto in _context.Productos
                            on venta.Producto equals producto.ProductoId
                        select new ReporteVentaModel {
                            Producto = producto.Nombre,
                            Cantidad = venta.Cantidad,
                            Total = venta.Total,
                            PromedioProducto = producto.Precio
                        }).ToList();

            ReporteVentasViewModel reporte = new ReporteVentasViewModel {
                Ventas = ventasQuery,
                Total = (from venta in ventasQuery
                         select venta.Total).Sum()
            };

            return reporte;
        }
    }
}
