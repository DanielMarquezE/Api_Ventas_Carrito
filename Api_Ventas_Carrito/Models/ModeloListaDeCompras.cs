namespace Api_Ventas_Carrito.Models
{
    public class ModeloListaDeCompras
    {
        public int Id { get; set; }

        public string CodeProducto { get; set; }

        public string NombreCliente { get; set; }

        public string imagen { get; set; }

        public int? CantidadProducto { get; set; }

        public decimal? TotalVenta { get; set; }

        public DateOnly? FechaVenta { get; set; }
    }
}
