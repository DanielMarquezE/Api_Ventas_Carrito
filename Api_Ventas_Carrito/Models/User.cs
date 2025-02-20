using System;
using System.Collections.Generic;

namespace Api_Ventas_Carrito.Models;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? IsAdmin { get; set; }

    public int? IdCliente { get; set; }
}
