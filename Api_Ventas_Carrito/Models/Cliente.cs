using System;
using System.Collections.Generic;

namespace Api_Ventas_Carrito.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Direccion { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }
}
