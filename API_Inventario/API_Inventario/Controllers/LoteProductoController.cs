using API_Inventario.Util;
using Datos_Inventario.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio_Inventario.Servicios;
using Negocio_Inventario.Servicios.Impl;

namespace API_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoteProductoController : ControllerBase
    {

        private readonly ILoteProductoService _loteProductoService;

        public LoteProductoController(ILoteProductoService loteProductoService)
        {
            _loteProductoService = loteProductoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _loteProductoService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _loteProductoService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(LoteProductoDTO loteProducto)
        {

            int iduser = ClaimsUser.GetIdUser(HttpContext);
            await _loteProductoService.AddAsync(loteProducto, iduser);
            return CreatedAtAction(nameof(GetById), new { id = loteProducto.IdProducto }, loteProducto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LoteProductoDTO loteProducto)
        {
            if (id != loteProducto.IdProducto)
            {
                return BadRequest();
            }


            int iduser = ClaimsUser.GetIdUser(HttpContext);
            await _loteProductoService.UpdateAsync(loteProducto, iduser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _loteProductoService.DeleteAsync(id);
            return NoContent();
        }


        [HttpPost("GetLotesProductos")]
        public async Task<ActionResult<PaginacionResponse<LoteProductoDTO>>> GetLotesProductos(PaginacionRequestDTO request)
        {
            var result = await _loteProductoService.GetLotesProductos(request);
            return Ok(result);
        }
    }
}
