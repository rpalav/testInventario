using AutoMapper;
using Datos_Inventario.Dtos;
using Datos_Inventario.Repositorio.EstadoLote;
using Datos_Inventario.Repositorio.EstadoProducto;
using Datos_Inventario.Repositorio.Lote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_Inventario.Servicios.Impl
{
    public class CatalogoService : ICatalogoService
    {

        private readonly IEstadoLoteRepositorio _estadoLoteRepositorio;
        private readonly IEstadoProductoRepositorio _estadoProductoRepositorio;

        public CatalogoService(IEstadoLoteRepositorio estadoLoteRepositorio, IEstadoProductoRepositorio estadoProductoRepositorio)
        {
            _estadoLoteRepositorio = estadoLoteRepositorio;
            _estadoProductoRepositorio = estadoProductoRepositorio;
        }

        public async Task<IEnumerable<CatalogoDTO>> GetCatalogoEstadoLoteAsync()
        {
            var result = await _estadoLoteRepositorio.GetCatalogoAsync();
            return result;
        }


        public async Task<IEnumerable<CatalogoDTO>> GetCatalogoEstadoProductoAsync()
        {
            var result = await _estadoProductoRepositorio.GetCatalogoAsync();
            return result;
        }
    }
}
