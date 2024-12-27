using Datos_Inventario.Dtos;
using Dominio_Inventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos_Inventario.Repositorio.EstadoLote
{
    public interface IEstadoLoteRepositorio
    {
        Task<IEnumerable<CatalogoDTO>> GetCatalogoAsync();
    }
}
