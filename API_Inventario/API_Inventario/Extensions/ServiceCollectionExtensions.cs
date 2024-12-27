using Datos_Inventario;
using Datos_Inventario.Repositorio.EstadoLote;
using Datos_Inventario.Repositorio.EstadoProducto;
using Datos_Inventario.Repositorio.Lote;
using Datos_Inventario.Repositorio.Producto;
using Datos_Inventario.Repositorio.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Negocio_Inventario.Servicios;
using Negocio_Inventario.Servicios.Impl;

namespace API_Inventario.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInventarioServices(
         this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            services.AddDbContext<InventarioContext>(optionsAction);

            services.AddScoped<IEstadoLoteRepositorio, EstadoLoteRepositorio>();
            services.AddScoped<IEstadoProductoRepositorio, EstadoProductoRepositorio>();
            services.AddScoped<ILoteProductoRepositorio, LoteProductoRepositorio>();
            services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICatalogoService, CatalogoService>();
            services.AddScoped<ILoteProductoService, LoteProductoService>();
            services.AddScoped<IProductoService, ProductoService>();
            return services;
        }


    }
}
