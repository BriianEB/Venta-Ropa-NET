using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentaRopa.Data;
using VentaRopa.Models;

namespace VentaRopa.Services
{
    public class ProductoService
    {
        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public IList<ProductoModel> GetProductos()
        {
            return _context.Productos.ToList();
        }

        public ProductoModel GetProducto(int id)
        {
            return _context.Productos.FirstOrDefault(p => p.ProductoId == id);
        }

        public void AddProducto(ProductoModel producto)
        {
            _context.Add(producto);
            _context.SaveChanges();
        }
    }
}
