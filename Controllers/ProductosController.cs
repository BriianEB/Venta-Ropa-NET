using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VentaRopa.Models;
using VentaRopa.Services;
using Microsoft.AspNetCore.Authorization;

namespace VentaRopa.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        private ProductoService productoService;

        public ProductosController(ProductoService productoService)
        {
            this.productoService = productoService;
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear([Bind("Nombre,Precio")] ProductoModel producto)
        {
            if (ModelState.IsValid)
            {
                productoService.AddProducto(producto);

                return RedirectToAction("Index", "Home");
            }

            return View(producto);
        }
    }
}
