using API_Inventario.Util;
using Datos_Inventario.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio_Inventario.Servicios;

namespace API_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class ProductoController : ControllerBase
    {

        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productoService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productoService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductoDTO producto)
        {
            int iduser = ClaimsUser.GetIdUser(HttpContext);
            await _productoService.AddAsync(producto, iduser);
            return CreatedAtAction(nameof(GetById), new { id = producto.IdProducto }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductoDTO producto)
        {
            if (id != producto.IdProducto)
            {
                return BadRequest();
            }

            int iduser = ClaimsUser.GetIdUser(HttpContext);
            await _productoService.UpdateAsync(producto, iduser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productoService.DeleteAsync(id);
            return NoContent();
        }


    }
}
