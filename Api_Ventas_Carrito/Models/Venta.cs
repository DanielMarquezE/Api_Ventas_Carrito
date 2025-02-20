using System;
using System.Collections.Generic;

namespace Api_Ventas_Carrito.Models;

public partial class Venta
{
    public int Id { get; set; }

    public int? IdProducto { get; set; }

    public int? IdCliente { get; set; }

    public int? CantidadProducto { get; set; }

    public decimal? TotalVenta { get; set; }

    public DateOnly? FechaVenta { get; set; }
}
