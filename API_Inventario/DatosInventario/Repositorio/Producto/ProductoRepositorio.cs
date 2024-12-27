using Dominio_Inventario.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos_Inventario.Repositorio.Producto
{
    public class ProductoRepositorio : IProductoRepositorio
    {

        private readonly InventarioContext _context;

        public ProductoRepositorio(InventarioContext context)
        {
            _context = context;
        }

        public async Task<Productos?> GetByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<IEnumerable<Productos>> GetAllAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task AddAsync(Productos producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Productos producto)
        {
            _context.Productos.Update(producto);
            _context.Entry(producto).Property(p => p.FechaCreacion).IsModified = false;
            _context.Entry(producto).Property(p => p.IdUsuarioCreacion).IsModified = false;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var producto = await GetByIdAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
