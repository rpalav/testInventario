using Datos_Inventario.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_Inventario.Servicios
{
    public interface IProductoService
    {
        public Task<ProductoDTO> GetByIdAsync(int id);
        public Task<IEnumerable<ProductoDTO>> GetAllAsync();
        public Task AddAsync(ProductoDTO Producto, int idUsuario);
        public Task UpdateAsync(ProductoDTO Producto, int idUsuario);
        public Task DeleteAsync(int id);
    }
}
