using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos_Inventario.Dtos
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        public int IdEstadoProducto { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string Imagen { get; set; } = string.Empty;

    }
}
