using Datos_Inventario.Dtos;
using Dominio_Inventario.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos_Inventario.Repositorio.EstadoProducto
{
    public class EstadoProductoRepositorio : IEstadoProductoRepositorio
    {
        private readonly InventarioContext _context;

        public EstadoProductoRepositorio(InventarioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CatalogoDTO>> GetCatalogoAsync()
        {
            return await _context.EstadosProductos.Select(a => new CatalogoDTO { 
                Id = a.IdEstadoProducto, 
                Valor = a.NombreEstado }).ToListAsync();            
        }
    }
}
