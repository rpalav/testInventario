using Datos_Inventario.Dtos;
using Dominio_Inventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos_Inventario.Repositorio.EstadoProducto
{
    public interface IEstadoProductoRepositorio
    {
        Task<IEnumerable<CatalogoDTO>> GetCatalogoAsync();
    }
}
