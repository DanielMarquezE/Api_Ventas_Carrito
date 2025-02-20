namespace Api_Ventas_Carrito.Models
{
    public class ListArticulos
    {
        public int Id { get; set; }

        public string? Codigo { get; set; }

        public string? Descripcion { get; set; }

        public decimal? Precio { get; set; }

        public string? Imagen { get; set; }

        public int? Stock { get; set; }
        public string? Tienda { get; set; }

    }
}
