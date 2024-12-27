using AutoMapper;
using Datos_Inventario;
using Datos_Inventario.Dtos;
using Datos_Inventario.Repositorio.Lote;
using Dominio_Inventario.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_Inventario.Servicios.Impl
{
    public class LoteProductoService : ILoteProductoService
    {
        private readonly IMapper _mapper;
        private readonly ILoteProductoRepositorio _loteProductoRepositorio;
        private readonly InventarioContext _context;

        public LoteProductoService(ILoteProductoRepositorio loteProductoRepositorio, IMapper mapper, InventarioContext context)
        {
            _loteProductoRepositorio = loteProductoRepositorio;
            _context = context;
            _mapper = mapper;
        }

        public async Task<LoteProductoDTO> GetByIdAsync(int id)
        {
            var result = await _loteProductoRepositorio.GetByIdAsync(id);
            return _mapper.Map<LoteProductoDTO>(result);
        }

        public async Task<IEnumerable<LoteProductoDTO>> GetAllAsync()
        { 
            var result = await _loteProductoRepositorio.GetAllAsync();
            return _mapper.Map<List<LoteProductoDTO>>(result);
        }

        public async Task AddAsync(LoteProductoDTO loteProducto, int iduser)
        {
            var data = _mapper.Map<LotesProductos>(loteProducto);
            data.FechaCreacion = DateTime.Now;
            data.IdUsuarioCreacion = iduser;
            await _loteProductoRepositorio.AddAsync(data);
        }

        public async Task UpdateAsync(LoteProductoDTO loteProducto, int iduser)
        {
            var data = _mapper.Map<LotesProductos>(loteProducto);
            data.IdUsuarioActualizacion = iduser;
            data.FechaActualizacion = DateTime.Now;
            await _loteProductoRepositorio.UpdateAsync(data);
        }

        public async Task DeleteAsync(int id)
        {
            await _loteProductoRepositorio.DeleteAsync(id);
        }


        public async Task<PaginacionResponse<LoteProductoDTO>> GetLotesProductos(PaginacionRequestDTO filtroBusqueda)
        {
            var query = _context.LotesProductos.Include(a => a.IdProductoNavigation).AsQueryable();

            if (!string.IsNullOrEmpty(filtroBusqueda.Filter))
            {
                query = query.Where(x => x.IdProductoNavigation != null && x.IdProductoNavigation.Nombre.Contains(filtroBusqueda.Filter));
            }


            if (filtroBusqueda.SortDirection.ToLower() == "asc")
            {
                query = query.OrderBy(x => EF.Property<object>(x, filtroBusqueda.SortField));
            }
            else
            {
                query = query.OrderByDescending(x => EF.Property<object>(x, filtroBusqueda.SortField));
            }


            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((filtroBusqueda.Page - 1) * filtroBusqueda.PageSize)
                .Take(filtroBusqueda.PageSize)
                .Select(a => new LoteProductoDTO
                {
                    IdLote = a.IdLote,
                    CodigoLote = a.CodigoLote,
                    NombreProducto = a.IdProductoNavigation.Nombre,
                    FechaFabricacion = a.FechaFabricacion,
                    FechaVencimiento = a.FechaVencimiento,
                    Precio = a.Precio,
                    Stock = a.Stock,
                    IdProducto = a.IdProducto
                })
                .ToListAsync();

            if (totalCount == 0)
            {
                throw new BusinessException("No se encontro informacion");
            }

            return new PaginacionResponse<LoteProductoDTO> { Items = items, TotalCount = totalCount };
        }
    }
}
