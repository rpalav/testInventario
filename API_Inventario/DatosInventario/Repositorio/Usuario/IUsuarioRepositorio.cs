using Datos_Inventario.Dtos;
using Dominio_Inventario.Modelos;

namespace Datos_Inventario.Repositorio.Usuario
{
    public interface IUsuarioRepositorio
    {
        Task<Usuarios?> Login(CredencialesDTO credenciales);
    }
}
