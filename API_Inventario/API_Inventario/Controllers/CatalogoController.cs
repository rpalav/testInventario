using Datos_Inventario.Dtos;
using Datos_Inventario.Repositorio.EstadoLote;
using Datos_Inventario.Repositorio.EstadoProducto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CatalogoController : ControllerBase
    {
        private readonly IEstadoLoteRepositorio _estadoLoteRepositorio;
        private readonly IEstadoProductoRepositorio _estadoProductoRepositorio;

        public CatalogoController(IEstadoLoteRepositorio estadoLoteRepositorio, IEstadoProductoRepositorio estadoProductoRepositorio)
        {
            _estadoLoteRepositorio = estadoLoteRepositorio;
            _estadoProductoRepositorio = estadoProductoRepositorio;
        }


        [HttpGet("GetCatalogoEstadoLote")]
        public async Task<IEnumerable<CatalogoDTO>> GetCatalogoEstadoLoteAsync()
        {
            var result = await _estadoLoteRepositorio.GetCatalogoAsync();
            return result;
        }



        [HttpGet("GetCatalogoEstadoProducto")]
        public async Task<IEnumerable<CatalogoDTO>> GetCatalogoEstadoProductoAsync()
        {
            var result = await _estadoProductoRepositorio.GetCatalogoAsync();
            return result;
        }
    }
}
