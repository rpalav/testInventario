using Datos_Inventario.Dtos;
using Dominio_Inventario.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos_Inventario.Repositorio.Usuario
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly InventarioContext _context;

        public UsuarioRepositorio(InventarioContext context)
        {
            _context = context;
        }

        public async Task<Usuarios?> Login(CredencialesDTO credenciales)
        {
            
            var usuario = await _context.Usuarios.Include(u => u.Credenciales).FirstOrDefaultAsync(u => u.NombreUsuario.Equals(credenciales.Usuario)); 
            if (usuario != null && usuario.Credenciales != null && usuario.Credenciales.FirstOrDefault().Contrasenia.Equals(credenciales.Password)) 
            { 
                return usuario; 
            }
            return null;
        }
    }
}
