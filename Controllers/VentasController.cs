using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VentaRopa.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using VentaRopa.Services;
using Microsoft.AspNetCore.Authorization;

namespace VentaRopa.Controllers
{
    [Authorize]
    public class VentasController : Controller
    {
        private readonly VentaService ventaService;
        private readonly ProductoService productoService;

        public VentasController(VentaService ventaService, ProductoService productoService)
        {
            this.ventaService = ventaService;
            this.productoService = productoService;
        }

        public IActionResult Crear()
        {
            IList<ProductoModel> productos = productoService.GetProductos();
            VentaViewModel viewModel = new VentaViewModel();

            foreach (ProductoModel producto in productos)
            {
                viewModel.Productos.Add(new SelectListItem { 
                    Value = producto.ProductoId.ToString(),
                    Text = producto.Nombre
                });
            }
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear([Bind("Producto,Cantidad")] VentaViewModel venta)
        {
            if (ModelState.IsValid)
            {
                ventaService.AddVenta(venta);

                return RedirectToAction("Index", "Home");
            }

            return View(venta);
        }

        public IActionResult Reporte()
        {
            ReporteVentasViewModel reporteVentas = ventaService.GetReporteVentas();

            return View(reporteVentas);
        }
    }
}
