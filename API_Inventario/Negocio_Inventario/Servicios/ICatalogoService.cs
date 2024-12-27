using Datos_Inventario.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_Inventario.Servicios
{
    public interface ICatalogoService
    {
        public Task<IEnumerable<CatalogoDTO>> GetCatalogoEstadoLoteAsync();

        public Task<IEnumerable<CatalogoDTO>> GetCatalogoEstadoProductoAsync();
    }
}
