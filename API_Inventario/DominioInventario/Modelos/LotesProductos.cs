﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Dominio_Inventario.Modelos;

public partial class LotesProductos
{
    public int IdLote { get; set; }

    public int IdProducto { get; set; }

    public int IdEstadoLote { get; set; }

    public string CodigoLote { get; set; }

    public decimal Precio { get; set; }

    public decimal Stock { get; set; }

    public DateTime? FechaFabricacion { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public int IdUsuarioCreacion { get; set; }

    public int? IdUsuarioActualizacion { get; set; }

    public virtual EstadosLotes IdEstadoLoteNavigation { get; set; }

    public virtual Productos IdProductoNavigation { get; set; }
}