using Datos_Inventario.Dtos;
using Datos_Inventario.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio_Inventario.Servicios
{
    public interface IAuthService
    {
        public Task<AuthResult> Login(CredencialesDTO credenciales);
    }
}
