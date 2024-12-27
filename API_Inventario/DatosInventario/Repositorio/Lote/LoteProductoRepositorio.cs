using Dominio_Inventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Datos_Inventario.Repositorio.Lote
{
    public class LoteProductoRepositorio : ILoteProductoRepositorio
    {

        private readonly InventarioContext _context;

        public LoteProductoRepositorio(InventarioContext context)
        {
            _context = context;
        }

        public async Task<LotesProductos?> GetByIdAsync(int id)
        {
            return await _context.LotesProductos.FindAsync(id);
        }

        public async Task<IEnumerable<LotesProductos>> GetAllAsync()
        {
            return await _context.LotesProductos.ToListAsync();
        }

        public async Task AddAsync(LotesProductos producto)
        {
            await _context.LotesProductos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LotesProductos producto)
        {
            _context.LotesProductos.Update(producto);

            _context.Entry(producto).Property(p => p.FechaCreacion).IsModified = false;
            _context.Entry(producto).Property(p => p.IdUsuarioCreacion).IsModified = false;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var producto = await GetByIdAsync(id);
            if (producto != null)
            {
                _context.LotesProductos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
