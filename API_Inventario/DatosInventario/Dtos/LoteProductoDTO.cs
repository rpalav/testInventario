using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos_Inventario.Dtos
{
    public class LoteProductoDTO
    {
        public int IdLote { get; set; }

        public int IdProducto { get; set; }

        public int IdEstadoLote { get; set; }

        public string NombreProducto { get; set; } = string.Empty;

        public string CodigoLote { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public decimal Stock { get; set; }

        public DateTime? FechaFabricacion { get; set; }

        public DateTime? FechaVencimiento { get; set; }
    }
}
