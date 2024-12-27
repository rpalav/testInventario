using Datos_Inventario.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_Inventario.Servicios
{
    public interface ILoteProductoService
    {
        public Task<LoteProductoDTO> GetByIdAsync(int id);
        public Task<IEnumerable<LoteProductoDTO>> GetAllAsync();
        public Task AddAsync(LoteProductoDTO loteProducto, int iduser);
        public Task UpdateAsync(LoteProductoDTO loteProducto, int iduser);
        public Task DeleteAsync(int id);

        public Task<PaginacionResponse<LoteProductoDTO>> GetLotesProductos(PaginacionRequestDTO filtroBusqueda);
    }
}
