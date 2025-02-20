using System;
using System.Collections.Generic;

namespace Api_Ventas_Carrito.Models;

public partial class Articulo
{
    public int Id { get; set; }

    public string? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public string? Imagen { get; set; }

    public int? Stock { get; set; }

    public int? Sucursal { get; set; }

    public DateOnly? FechaCreacion { get; set; }
}
