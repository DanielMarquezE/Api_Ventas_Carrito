using Api_Ventas_Carrito.Models;

namespace Api_Ventas_Carrito.DataAccess.Interfaces
{
    public interface IArticulosRepository<Articulo> : IDisposable
    {

        List<Articulo> findArticulos();
        Articulo findArticuloById(int idArticulo);
        Articulo storageArticulo(Articulo articulo);
        Articulo deleteArticuloById(int idArticulo);
        Articulo updateArticulo(Articulo articulo);
        List<ListArticulos> listArticulosModel();
        void Save();

    }
}
