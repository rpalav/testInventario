using Datos_Inventario.Dtos;
using Dominio_Inventario.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos_Inventario.Repositorio.EstadoLote
{
    public class EstadoLoteRepositorio : IEstadoLoteRepositorio
    {
        private readonly InventarioContext _context;

        public EstadoLoteRepositorio(InventarioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CatalogoDTO>> GetCatalogoAsync()
        {
            return await _context.EstadosLotes.Select(a => new CatalogoDTO
            {
                Id = a.IdEstadoLote,
                Valor = a.Nombre
            }).ToListAsync();
        }
    }
}
