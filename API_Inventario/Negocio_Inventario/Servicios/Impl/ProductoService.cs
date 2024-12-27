using AutoMapper;
using Datos_Inventario;
using Datos_Inventario.Dtos;
using Datos_Inventario.Repositorio.Lote;
using Datos_Inventario.Repositorio.Producto;
using Dominio_Inventario.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_Inventario.Servicios.Impl
{
    public class ProductoService : IProductoService
    {

        private readonly IMapper _mapper;
        private readonly IProductoRepositorio _ProductoRepositorio;

        public ProductoService(IProductoRepositorio ProductoRepositorio, IMapper mapper)
        {
            _ProductoRepositorio = ProductoRepositorio;
            _mapper = mapper;
        }

        public async Task<ProductoDTO> GetByIdAsync(int id)
        {
            var result = await _ProductoRepositorio.GetByIdAsync(id);
            return _mapper.Map<ProductoDTO>(result);
        }

        public async Task<IEnumerable<ProductoDTO>> GetAllAsync()
        {
            var result = await _ProductoRepositorio.GetAllAsync();
            return _mapper.Map<List<ProductoDTO>>(result);
        }

        public async Task AddAsync(ProductoDTO Producto, int idUsuario)
        {
            var data = _mapper.Map<Productos>(Producto);
            data.FechaCreacion = DateTime.Now;
            data.IdUsuarioCreacion = idUsuario;
            await _ProductoRepositorio.AddAsync(data);
        }

        public async Task UpdateAsync(ProductoDTO Producto, int idUsuario)
        {
            var data = _mapper.Map<Productos>(Producto);
            data.FechaActualizacion = DateTime.Now;
            data.IdUsuarioActualizacion = idUsuario;
            await _ProductoRepositorio.UpdateAsync(data);
        }

        public async Task DeleteAsync(int id)
        {
            await _ProductoRepositorio.DeleteAsync(id);
        }

    }
}
