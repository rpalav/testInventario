﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos_Inventario.Dtos
{
    public class PaginacionResponse<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
