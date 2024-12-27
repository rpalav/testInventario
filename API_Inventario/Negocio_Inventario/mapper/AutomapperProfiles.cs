using AutoMapper;
using Datos_Inventario.Dtos;
using Dominio_Inventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_Inventario.mapper
{
    public class AutomapperProfiles : Profile
    {

        public AutomapperProfiles()
        {
            CreateMap<LoteProductoDTO, LotesProductos>().ReverseMap();
            CreateMap<ProductoDTO, Productos>().ReverseMap();
        }
    }
}
