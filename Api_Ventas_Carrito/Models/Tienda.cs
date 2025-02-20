using System;
using System.Collections.Generic;

namespace Api_Ventas_Carrito.Models;

public partial class Tienda
{
    public int Id { get; set; }

    public string? Sucursal { get; set; }

    public string? Direccion { get; set; }
}
